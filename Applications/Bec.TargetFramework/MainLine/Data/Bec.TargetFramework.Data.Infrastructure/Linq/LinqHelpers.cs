using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Bec.TargetFramework.Data.Infrastructure.Linq
{
    public static class LinqHelpers
    {
        private static readonly MethodInfo OrderByMethod = typeof(Queryable).GetMethods().Single(method => method.Name == "OrderBy" && method.GetParameters().Length == 2);
        private static readonly MethodInfo OrderByDescendingMethod = typeof(Queryable).GetMethods().Single(method => method.Name == "OrderByDescending" && method.GetParameters().Length == 2);
        private static readonly MethodInfo ThenByMethod = typeof(Queryable).GetMethods().Single(method => method.Name == "ThenBy" && method.GetParameters().Length == 2);
        private static readonly MethodInfo ThenByDescendingMethod = typeof(Queryable).GetMethods().Single(method => method.Name == "ThenByDescending" && method.GetParameters().Length == 2);

        public static IOrderedQueryable<T> ApplyOrdering<T>(IQueryable<T> source, string propertyName, MethodInfo orderingMethod)
        {
            var props = propertyName.Split('.');
            var type = typeof(T);
            var arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (var pi in props.Select(prop => type.GetProperty(prop)))
            {
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            var delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            var lambda = Expression.Lambda(delegateType, expr, arg);

            return (IOrderedQueryable<T>)orderingMethod
                .MakeGenericMethod(typeof(T), type)
                .Invoke(null, new object[] { source, lambda });
        }


        public static string GetName(Expression<Func<object>>exp)
        {
            MemberExpression body = exp.Body as MemberExpression;
            if (body==null)
            {
                UnaryExpression uBody = (UnaryExpression)exp.Body;
                body = uBody.Operand as MemberExpression;
            }

            return body.Member.Name;
        }
        public static IOrderedQueryable<T> OrderByProperty<T>(this IQueryable<T> source, string propertyName)
        {
            return ApplyOrdering(source, propertyName, OrderByMethod);
        }

        public static IOrderedQueryable<T> OrderByDescendingProperty<T>(this IQueryable<T> source, string propertyName)
        {
            return ApplyOrdering(source, propertyName, OrderByDescendingMethod);
        }

        public static IOrderedQueryable<T> ThenByProperty<T>(this IOrderedQueryable<T> source, string propertyName)
        {
            return ApplyOrdering(source, propertyName, ThenByMethod);
        }

        public static IOrderedQueryable<T> ThenByDescendingProperty<T>(this IOrderedQueryable<T> source, string propertyName)
        {
            return ApplyOrdering(source, propertyName, ThenByDescendingMethod);
        }

        //public static T[] ApplySortingPaging<T>(this IOrderedQueryable<T> query, SortingPagingDto sortingPaging)
        //{
        //    var firstPass = true;
        //    foreach (var sortOrder in sortingPaging.SortOrders)
        //    {
        //        if (firstPass)
        //        {
        //            firstPass = false;
        //            query = sortOrder.ColumnOrder == SortOrderDto.SortOrder.Ascending
        //                        ? query.OrderBy(sortOrder.ColumnName) :
        //                          query.OrderByDescending(sortOrder.ColumnName);
        //        }
        //        else
        //        {
        //            query = sortOrder.ColumnOrder == SortOrderDto.SortOrder.Ascending
        //                        ? query.ThenBy(sortOrder.ColumnName) :
        //                          query.ThenByDescending(sortOrder.ColumnName);
        //        }
        //    }

        //    var result = query.Skip((sortingPaging.PageNumber - 1) *
        //      sortingPaging.NumberRecords).Take(sortingPaging.NumberRecords).ToArray();

        //    return result;
        //}

        private static readonly MethodInfo StringContainsMethod =
  typeof(string).GetMethod(@"Contains", BindingFlags.Instance |
  BindingFlags.Public, null, new[] { typeof(string) }, null);

        private static readonly MethodInfo BooleanEqualsMethod =
          typeof(bool).GetMethod(@"Equals", BindingFlags.Instance |
          BindingFlags.Public, null, new[] { typeof(bool) }, null);

        private static readonly MethodInfo GuidHasValueMethod =
          typeof(Guid?).GetMethod(@"HasValue", BindingFlags.Instance |
          BindingFlags.Public, null, new Type[] { }, null);

        public static Expression<Func<TDbType, bool>>
          BuildPredicate<TDbType, TSearchCriteria>(TSearchCriteria searchCriteria)
        {
            var predicate = Bec.TargetFramework.Data.Infrastructure.Linq.PredicateBuilder.True<TDbType>();

            // Iterate the search criteria properties
            var searchCriteriaPropertyInfos = searchCriteria.GetType().GetProperties();
            foreach (var searchCriteriaPropertyInfo in searchCriteriaPropertyInfos)
            {
                // Get the name of the DB field, which may not be the same as the property name.
                var dbFieldName = GetDbFieldName(searchCriteriaPropertyInfo);
                // Get the target DB type (table)
                var dbType = typeof(TDbType);
                // Get a MemberInfo for the type's field (ignoring case
                // so "FirstName" works as well as "firstName")
                var dbFieldMemberInfos = dbType.GetMember(dbFieldName,
                    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).ToList();

                if (dbFieldMemberInfos.Count > 0)
                {
                    var dbFieldMemberInfo = dbFieldMemberInfos.Single();

                    if (dbFieldMemberInfo.MemberType.Equals(MemberTypes.Property))
                    {
                        var memberType = ((PropertyInfo)dbFieldMemberInfo).PropertyType;

                        // STRINGS
                        if (searchCriteriaPropertyInfo.PropertyType == typeof(string) && memberType == typeof(string))
                        {
                            predicate = ApplyStringCriterion(searchCriteria,
                              searchCriteriaPropertyInfo, dbType, dbFieldMemberInfo, predicate);
                        }
                        // BOOLEANS
                        else if (searchCriteriaPropertyInfo.PropertyType == typeof(bool?) && (memberType == typeof(bool) || memberType == typeof(bool?)))
                        {
                            predicate = ApplyBoolCriterion(searchCriteria,
                              searchCriteriaPropertyInfo, dbType, dbFieldMemberInfo, predicate);
                        }
                        // GUID?
                        else if (searchCriteriaPropertyInfo.PropertyType == typeof(Guid?) && (memberType == typeof(Guid) || memberType == typeof(Guid?)))
                        {
                            predicate = ApplyGuidCriterion(searchCriteria,
                              searchCriteriaPropertyInfo, dbType, dbFieldMemberInfo, predicate);
                        }
                        // INT?
                        else if (searchCriteriaPropertyInfo.PropertyType == typeof(int?) && (memberType == typeof(int) || memberType == typeof(int?)))
                        {
                            predicate = ApplyIntCriterion(searchCriteria,
                              searchCriteriaPropertyInfo, dbType, dbFieldMemberInfo, predicate);
                        }
                        // DEALS WITH AN ARRAY OF INTS OR (x OR y OR Z)
                        else if (searchCriteriaPropertyInfo.PropertyType == typeof(string) && (memberType == typeof(int) || memberType == typeof(int?)))
                        {
                            // try and cast to array of ints
                            if (searchCriteriaPropertyInfo.GetValue(searchCriteria) != null &&
                                !string.IsNullOrEmpty(searchCriteriaPropertyInfo.GetValue(searchCriteria).ToString()))
                            {
                                string[] values = searchCriteriaPropertyInfo.GetValue(searchCriteria).ToString().Split(',');

                                if (values.Length > 0)
                                {
                                    var inner = Bec.TargetFramework.Data.Infrastructure.Linq.PredicateBuilder.False<TDbType>();

                                    // check can be converted to int
                                    int intValue = -1;

                                    int.TryParse(values[0], out intValue);

                                    if (intValue != -1)
                                    {
                                        // process values
                                        foreach (string s in values)
                                        {
                                            inner = ApplyIntFromArrayAndCriterion(searchCriteria,
                                  searchCriteriaPropertyInfo, Convert.ToInt32(s), dbType, dbFieldMemberInfo, inner);
                                        }
                                    }

                                    predicate = predicate.And(inner);
                                }
                            }
                        }
                        // DEALS WITH AN ARRAY OF String OR (x OR y OR Z)
                        else if (searchCriteriaPropertyInfo.PropertyType == typeof(string[]) && (memberType == typeof(int) || memberType == typeof(int?)))
                        {
                            // try and cast to array of ints
                            if (searchCriteriaPropertyInfo.GetValue(searchCriteria) != null)
                            {
                                string[] searchValues = searchCriteriaPropertyInfo.GetValue(searchCriteria) as string[];
                                string[] values = searchValues.Where(item => item != string.Empty).ToArray();
                                if (values!= null && values.Length > 0)
                                {
                                    var inner = Bec.TargetFramework.Data.Infrastructure.Linq.PredicateBuilder.False<TDbType>();

                                    // check can be converted to int
                                    int intValue = -1;

                                    int.TryParse(values[0], out intValue);

                                    if (intValue != -1)
                                    {
                                        // process values
                                        foreach (string s in values)
                                        {
                                            if (!string.IsNullOrEmpty(s))
                                            {
                                                inner = ApplyIntFromArrayAndCriterion(searchCriteria,
                                                searchCriteriaPropertyInfo, Convert.ToInt32(s), dbType, dbFieldMemberInfo, inner);    
                                            }
                                        }
                                    }

                                    predicate = predicate.And(inner);
                                }
                            }
                        }
                    }
                    // ADD MORE TYPES...
                }
                //Deals with filter key & value
                else if (searchCriteriaPropertyInfo.PropertyType == typeof(List<PropertyInfo>))
                {
                    var listPis = searchCriteriaPropertyInfo.GetValue(searchCriteria) as List<PropertyInfo>;

                    if (listPis != null)
                    {
                        var searchQuery = searchCriteria.GetType().GetProperty("SearchQuery").GetGetMethod().Invoke(searchCriteria, new object[] { }) as string;

                        if (!string.IsNullOrEmpty(searchQuery))
                        {
                            var inner = Bec.TargetFramework.Data.Infrastructure.Linq.PredicateBuilder.False<TDbType>();

                            listPis.ForEach(pi =>
                            {
                                dbFieldMemberInfos = dbType.GetMember(pi.Name,
                                     BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).ToList();
                                if (dbFieldMemberInfos.Count > 0)
                                {
                                    var memberTypeFromPI = dbFieldMemberInfos.Single();
                                    inner = ApplyStringOrCriterion(searchCriteria, searchQuery, dbType, memberTypeFromPI, inner);
                                }

                            });

                            predicate = predicate.And(inner);
                        }
                    }
                }
            }
                 
            return predicate;
        }

        private static Expression<Func<TDbType, bool>> ApplyStringCriterion<TDbType,
            TSearchCriteria>(TSearchCriteria searchCriteria, PropertyInfo searchCriterionPropertyInfo,
            Type dbType, MemberInfo dbFieldMemberInfo, Expression<Func<TDbType, bool>> predicate)
        {
            // Check if a search criterion was provided
            var searchString = searchCriterionPropertyInfo.GetValue(searchCriteria) as string;
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return predicate;
            }

            // Then "and" it to the predicate.
            // e.g. predicate = predicate.And(x => x.firstName.Contains(searchCriterion.FirstName)); ...
            // Create an "x" as TDbType
            var dbTypeParameter = Expression.Parameter(dbType, @"x");
            // Get at x.firstName
            var dbFieldMember = Expression.MakeMemberAccess(dbTypeParameter, dbFieldMemberInfo);
            // Create the criterion as a constant
            var criterionConstant = new Expression[] { Expression.Constant(searchString) };
            // Create the MethodCallExpression like x.firstName.Contains(criterion)
            var containsCall = Expression.Call(dbFieldMember, StringContainsMethod, criterionConstant);
            // Create a lambda like x => x.firstName.Contains(criterion)
            var lambda = Expression.Lambda(containsCall, dbTypeParameter) as Expression<Func<TDbType, bool>>;
            // Apply!
            return predicate.And(lambda);
        }

        private static Expression<Func<TDbType, bool>> ApplyStringOrCriterion<TDbType,
            TSearchCriteria>(TSearchCriteria searchCriteria, string value,
            Type dbType, MemberInfo dbFieldMemberInfo, Expression<Func<TDbType, bool>> predicate)
        {
            var dbTypeParameter = Expression.Parameter(dbType, @"x");
            // Get at x.firstName
            var dbFieldMember = Expression.MakeMemberAccess(dbTypeParameter, dbFieldMemberInfo);
            // Create the criterion as a constant
            var criterionConstant = new Expression[] { Expression.Constant(value) };
            // Create the MethodCallExpression like x.firstName.Contains(criterion)
            var containsCall = Expression.Call(dbFieldMember, StringContainsMethod, criterionConstant);
            // Create a lambda like x => x.firstName.Contains(criterion)
            var lambda = Expression.Lambda(containsCall, dbTypeParameter) as Expression<Func<TDbType, bool>>;
            // Apply!
            return predicate.Or(lambda);
        }

        private static Expression<Func<TDbType, bool>> ApplyBoolCriterion<TDbType,
          TSearchCriteria>(TSearchCriteria searchCriteria, PropertyInfo searchCriterionPropertyInfo,
          Type dbType, MemberInfo dbFieldMemberInfo, Expression<Func<TDbType, bool>> predicate)
        {
            // Check if a search criterion was provided
            var searchBool = searchCriterionPropertyInfo.GetValue(searchCriteria) as bool?;
            if (searchBool == null)
            {
                return predicate;
            }
            // Then "and" it to the predicate.
            // e.g. predicate = predicate.And(x => x.isActive.Contains(searchCriterion.IsActive)); ...
            // Create an "x" as TDbType
            var dbTypeParameter = Expression.Parameter(dbType, @"x");
            // Get at x.isActive
            var dbFieldMember = Expression.MakeMemberAccess(dbTypeParameter, dbFieldMemberInfo);
            // Create the criterion as a constant
            var criterionConstant = new Expression[] { Expression.Constant(searchBool) };
            // Create the MethodCallExpression like x.isActive.Equals(criterion)
            var equalsCall = Expression.Call(dbFieldMember, BooleanEqualsMethod, criterionConstant);
            // Create a lambda like x => x.isActive.Equals(criterion)
            var lambda = Expression.Lambda(equalsCall, dbTypeParameter) as Expression<Func<TDbType, bool>>;
            // Apply!
            return predicate.And(lambda);
        }

        private static Expression<Func<TDbType, bool>> ApplyGuidCriterion<TDbType,
          TSearchCriteria>(TSearchCriteria searchCriteria, PropertyInfo searchCriterionPropertyInfo,
          Type dbType, MemberInfo dbFieldMemberInfo, Expression<Func<TDbType, bool>> predicate)
        {
            // Check if a search criterion was provided
            var searchBool = searchCriterionPropertyInfo.GetValue(searchCriteria) as Guid?;
            if (searchBool == null)
            {
                return predicate;
            }

            if (!searchBool.HasValue)
                return predicate;

            var dbTypeParameter = Expression.Parameter(dbType, @"x");
            // Get at x.isActive
            var dbFieldMember = Expression.MakeMemberAccess(dbTypeParameter, dbFieldMemberInfo);

            var value = Expression.Constant(searchBool, searchBool.GetType());

            var converted = value.Type != dbFieldMember.Type
                ? (Expression)Expression.Convert(value, dbFieldMember.Type)
                : (Expression)value;

            var body = Expression.MakeBinary(ExpressionType.Equal, dbFieldMember, converted);

            // Create a lambda like x => x.isActive.Equals(criterion)
            var lambda = Expression.Lambda(body, dbTypeParameter) as Expression<Func<TDbType, bool>>;
            // Apply!
            return predicate.And(lambda);
        }

        private static Expression<Func<TDbType, bool>> ApplyIntCriterion<TDbType,
         TSearchCriteria>(TSearchCriteria searchCriteria, PropertyInfo searchCriterionPropertyInfo,
         Type dbType, MemberInfo dbFieldMemberInfo, Expression<Func<TDbType, bool>> predicate)
        {
            // Check if a search criterion was provided
            var searchBool = searchCriterionPropertyInfo.GetValue(searchCriteria) as int?;
            if (searchBool == null)
            {
                return predicate;
            }

            if (!searchBool.HasValue)
                return predicate;

            var dbTypeParameter = Expression.Parameter(dbType, @"x");
            // Get at x.isActive
            var dbFieldMember = Expression.MakeMemberAccess(dbTypeParameter, dbFieldMemberInfo);

            var value = Expression.Constant(searchBool, searchBool.GetType());

            var converted = value.Type != dbFieldMember.Type
                ? (Expression)Expression.Convert(value, dbFieldMember.Type)
                : (Expression)value;

            var body = Expression.MakeBinary(ExpressionType.Equal, dbFieldMember, converted);

            // Create a lambda like x => x.isActive.Equals(criterion)
            var lambda = Expression.Lambda(body, dbTypeParameter) as Expression<Func<TDbType, bool>>;
            // Apply!
            return predicate.And(lambda);
        }

        private static Expression<Func<TDbType, bool>> ApplyIntFromArrayAndCriterion<TDbType,
         TSearchCriteria>(TSearchCriteria searchCriteria, PropertyInfo searchCriterionPropertyInfo, int intValue,
         Type dbType, MemberInfo dbFieldMemberInfo, Expression<Func<TDbType, bool>> predicate)
        {
            // Check if a search criterion was provided
            var searchBool = intValue;

            var dbTypeParameter = Expression.Parameter(dbType, @"x");
            // Get at x.isActive
            var dbFieldMember = Expression.MakeMemberAccess(dbTypeParameter, dbFieldMemberInfo);

            var value = Expression.Constant(searchBool, searchBool.GetType());

            var converted = value.Type != dbFieldMember.Type
                ? (Expression)Expression.Convert(value, dbFieldMember.Type)
                : (Expression)value;

            var body = Expression.MakeBinary(ExpressionType.Equal, dbFieldMember, converted);

            // Create a lambda like x => x.isActive.Equals(criterion)
            var lambda = Expression.Lambda(body, dbTypeParameter) as Expression<Func<TDbType, bool>>;
            // Apply!
            return predicate.Or(lambda);
        }

        private static string GetDbFieldName(PropertyInfo propertyInfo)
        {
            var fieldMapAttribute =
                 propertyInfo.GetCustomAttributes(typeof(DbFieldMapAttribute), false).FirstOrDefault();
            var dbFieldName = fieldMapAttribute != null ?
                    ((DbFieldMapAttribute)fieldMapAttribute).Field : propertyInfo.Name;
            return dbFieldName;
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class DbFieldMapAttribute : Attribute
    {
        public string Field { get; set; }

        public DbFieldMapAttribute(string field)
        {
            Field = field;
        }
    }

    public class SortingPagingDto
    {
        public SortOrderDto[] SortOrders { get; set; }

        public int PageNumber { get; set; }

        public int NumberRecords { get; set; }

        public int PageSize { get; set; }
    }

    public class SortOrderDto
    {
        public enum SortOrder
        {
            Ascending,
            Descending
        }

        public string ColumnName { get; set; }

        public SortOrder ColumnOrder { get; set; }
    }

    public static class PredicateBuilder
    {
        /// <summary>
        /// Creates a predicate that evaluates to true.
        /// </summary>
        public static Expression<Func<T, bool>> True<T>()
        {
            return param => true;
        }

        /// <summary>
        /// Creates a predicate that evaluates to false.
        /// </summary>
        public static Expression<Func<T, bool>> False<T>()
        {
            return param => false;
        }

        /// <summary>
        /// Creates a predicate expression from the specified lambda expression.
        /// </summary>
        public static Expression<Func<T, bool>> Create<T>(Expression<Func<T, bool>> predicate)
        {
            return predicate;
        }

        /// <summary>
        /// Combines the first predicate with the second using the logical "and".
        /// </summary>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.AndAlso);
        }

        /// <summary>
        /// Combines the first predicate with the second using the logical "or".
        /// </summary>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.OrElse);
        }

        /// <summary>
        /// Negates the predicate.
        /// </summary>
        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expression)
        {
            var negated = Expression.Not(expression.Body);
            return Expression.Lambda<Func<T, bool>>(negated, expression.Parameters);
        }

        /// <summary>
        /// Combines the first expression with the second using the specified merge function.
        /// </summary>
        private static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // zip parameters (map from parameters of second to parameters of first)
            var map = first.Parameters
                .Select((f, i) => new { f, s = second.Parameters[i] })
                .ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with the parameters in the first
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            // create a merged lambda expression with parameters from the first expression
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        private class ParameterRebinder : System.Linq.Expressions.ExpressionVisitor
        {
            private readonly Dictionary<ParameterExpression, ParameterExpression> map;

            private ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
            {
                this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
            }

            public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
            {
                return new ParameterRebinder(map).Visit(exp);
            }

            protected override Expression VisitParameter(ParameterExpression p)
            {
                ParameterExpression replacement;

                if (map.TryGetValue(p, out replacement))
                {
                    p = replacement;
                }

                return base.VisitParameter(p);
            }
        }
    }
}