using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BrockAllen.MembershipReboot
{
    internal class GenericMethodActionBuilder<TargetBase, ParamBase>
    {
        private readonly Dictionary<Type, Action<TargetBase, ParamBase>> actionCache = new Dictionary<Type, Action<TargetBase, ParamBase>>();

        private readonly Type targetType;
        private readonly string method;

        public GenericMethodActionBuilder(Type targetType, string method)
        {
            this.targetType = targetType;
            this.method = method;
        }

        public Action<TargetBase, ParamBase> GetAction(ParamBase paramInstance)
        {
            var paramType = paramInstance.GetType();

            if (!this.actionCache.ContainsKey(paramType))
            {
                this.actionCache.Add(paramType, this.BuildActionForMethod(paramType));
            }

            return this.actionCache[paramType];
        }

        private Action<TargetBase, ParamBase> BuildActionForMethod(Type paramType)
        {
            var handlerType = this.targetType.MakeGenericType(paramType);

            var ehParam = Expression.Parameter(typeof(TargetBase));
            var evtParam = Expression.Parameter(typeof(ParamBase));
            var invocationExpression =
                Expression.Lambda(
                    Expression.Block(
                        Expression.Call(
                            Expression.Convert(ehParam, handlerType),
                            handlerType.GetMethod(this.method),
                            Expression.Convert(evtParam, paramType))),
                    ehParam, evtParam);

            return (Action<TargetBase, ParamBase>)invocationExpression.Compile();
        }
    }
}