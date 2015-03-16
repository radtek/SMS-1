using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
//Bec.TargetFramework.Entities
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
//using Fabrik.Common;
using Omu.ValueInjecter;

namespace Bec.TargetFramework.Business.Logic
{
    using Bec.TargetFramework.Aop.Aspects;
    using Bec.TargetFramework.Business.Infrastructure.Interfaces;
    using Bec.TargetFramework.Entities;
    using EnsureThat;

    [Trace(TraceExceptionsOnly = true)]
    public class ClassificationDataLogic : LogicBase, IClassificationDataLogic
    {
        public ClassificationDataLogic(ILogger logger, ICacheProvider cacheProvider) : base(logger, cacheProvider)
        {
        }

        public List<CountryCodeDTO> GetCountries()
        {
            List<CountryCodeDTO> countries = new List<CountryCodeDTO>();

            using (
                var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading,
                    this.Logger))
            {
                countries = CountryCodeConverter.ToDtos(scope.DbContext.CountryCodes);
            }

            return countries;
        }
    
        /// <summary>
        /// Returns root category values
        /// </summary>
        /// <param name="typeId"></param>
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
                    using (
                        var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading,
                            this.Logger))
                    {
                        // load all vclassification
                        var classificationDTOs = VClassificationConverter.ToDtos(scope.DbContext.VClassifications);

                        cacheClient.Add<List<VClassificationDTO>>(key, classificationDTOs, DateTime.Now.AddHours(1));

                        cachedList = classificationDTOs;
                    }
                }

                // create list entries
                list.AddRange(cachedList.Where(s => s.Categoryname.Equals(typeName)).ToList().Select(s => new ClassificationTypeDTO{
                    ClassificationTypeCategoryID = s.ClassificationTypeCategoryID,Name = s.Name.Trim(),ClassificationTypeID = s.Classificationtypeid}).ToArray());
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
            List<ClassificationTypeDTO> list = new List<ClassificationTypeDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var repository = scope.GetGenericRepositoryNoTracking<ClassificationType, int>();

                repository.FindAll(item => item.ParentClassificationTypeCategoryID.Equals(classificationTypeID))
                          .ToList()
                          .ForEach(it =>
                          {
                              var dto = new ClassificationTypeDTO();
                              dto.InjectFrom(it);

                              list.Add(dto);
                          });
            }

            return list.OrderBy(item => item.Name).ToList();
        }

        /// <summary>
        /// Returns classificationtypeid
        /// </summary>
        public int GetClassificationDataForTypeName(string categoryName, string typeName)
        {
            int classificationTypeID = 0;

            string key = "AllVClassificationDTO";

            List<ClassificationTypeDTO> list = new List<ClassificationTypeDTO>();

            using (var cacheClient = this.CacheProvider.CreateCacheClient(Logger))
            {
                var cachedList = cacheClient.Get<List<VClassificationDTO>>(key);

                if (cachedList == null)
                {
                    using (
                        var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading,
                            this.Logger))
                    {
                        // load all vclassification
                        var classificationDtos = VClassificationConverter.ToDtos(scope.DbContext.VClassifications);

                        cacheClient.Add<List<VClassificationDTO>>(key, classificationDtos, DateTime.Now.AddHours(1));

                        cachedList = classificationDtos;
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
