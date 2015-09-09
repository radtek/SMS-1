using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure;
using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Business.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class ClassificationDataLogicController : LogicBase
    {
        public ClassificationDataLogicController()
        {
        }

        public List<CountryCodeDTO> GetCountries()
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().CountryCodes.ToDtos();
            }
        }

        /// <summary>
        /// Returns root category values
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public List<ClassificationTypeDTO> GetRootClassificationDataForTypeName(string typeName)
        {
            Ensure.That(typeName).IsNotNull();

            List<ClassificationTypeDTO> list = new List<ClassificationTypeDTO>();

            string key = "AllVClassificationDTO";

            using (var cacheClient = this.CacheProvider.CreateCacheClient(Logger))
            {
                var cachedList = cacheClient.Get<List<VClassificationDTO>>(key);

                if (cachedList == null)
                {
                    using (var scope = DbContextScopeFactory.CreateReadOnly())
                    {
                        // load all vclassification
                        cachedList = scope.DbContexts.Get<TargetFrameworkEntities>().VClassifications.ToDtos();
                        cacheClient.Set<List<VClassificationDTO>>(key, cachedList, DateTime.Now.AddHours(1));
                    }
                }

                // create list entries
                list.AddRange(cachedList.Where(s => s.Categoryname.Equals(typeName)).ToList().Select(s => new ClassificationTypeDTO
                {
                    ClassificationTypeCategoryID = s.ClassificationTypeCategoryID,
                    Name = s.Name.Trim(),
                    ClassificationTypeID = s.Classificationtypeid
                }).ToArray());
            }
            return list.OrderBy(item => item.Name).ToList();
        }

        /// <summary>
        /// Returns sub category values
        /// </summary>
        /// <param name="classificationTypeID"></param>
        /// <returns></returns>
        public List<ClassificationTypeDTO> GetSubClassificationDataForParentID(int classificationTypeID)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().ClassificationTypes.Where(x => x.ClassificationTypeID == classificationTypeID).OrderBy(x => x.Name).ToDtos();
            }
        }

        /// <summary>
        /// Returns classificationtypeid
        /// </summary>
        public int GetClassificationDataForTypeName(string categoryName, string typeName)
        {
            string key = "AllVClassificationDTO";

            List<ClassificationTypeDTO> list = new List<ClassificationTypeDTO>();

            using (var cacheClient = this.CacheProvider.CreateCacheClient(Logger))
            {
                var cachedList = cacheClient.Get<List<VClassificationDTO>>(key);

                if (cachedList == null)
                {
                    using (var scope = DbContextScopeFactory.CreateReadOnly())
                    {
                        // load all vclassification
                        cachedList = scope.DbContexts.Get<TargetFrameworkEntities>().VClassifications.ToDtos();
                        cacheClient.Set<List<VClassificationDTO>>(key, cachedList, DateTime.Now.AddHours(1));
                    }
                }

                // create list entries
                list.AddRange(cachedList.Where(s => s.Categoryname.ToLower().Trim().Equals(categoryName.ToLower().Trim()) && s.Name.ToLower().Trim().Equals(typeName.ToLower().Trim())).ToList().Select(s => new ClassificationTypeDTO
                {
                    ClassificationTypeCategoryID = s.ClassificationTypeCategoryID,
                    Name = s.Name.Trim(),
                    ClassificationTypeID = s.Classificationtypeid
                }).ToArray());
            }

            Ensure.That(list.Count)
                .WithExtraMessageOf(
                    () => "No classification data for categoryname:" + categoryName + " name:" + typeName)
                .IsNot(0);

            return list.First().ClassificationTypeID;
        }

    }
}
