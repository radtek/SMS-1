using System;
using System.Collections.Generic;
using System.Linq;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
//Bec.TargetFramework.Entities
using Bec.TargetFramework.Entities.Injections;
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
    public class OperationLogic : LogicBase, IOperationLogic
    {
        public OperationLogic(ILogger logger, ICacheProvider cacheProvider) : base(logger, cacheProvider)
        {
        }

        public List<VOperationDTO> GetAllOperationDTO(bool showDeleted)
        {
            ////bool showDeleted = true;
            var dtoList = new List<VOperationDTO>();

            //using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            //{
            //    scope.DbContext..ToList().ForEach(item =>
            //    {
            //        if (showDeleted || (item.IsActive == true && item.IsDeleted == false))
            //        {
            //            var dto = new VOperationDTO();

            //            dto.InjectFrom(item);

            //            dtoList.Add(dto);
            //        }
            //    });
            //}

            return dtoList;
        }

        public OperationDTO GetOperationDTO(Guid id)
        {
            Ensure.That(id).IsNot(Guid.Empty);

            var dto = new OperationDTO();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var operation = scope.GetGenericRepository<Operation, Guid>().Get(id);

                dto.InjectFrom(operation);
            }

            return dto;
        }

        public void SaveOperation(OperationDTO dto)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                var operationRepos = scope.GetGenericRepository<Operation, Guid>();
                var operation = new Operation();

                if (dto.OperationID != Guid.Empty)
                {
                    operation = operationRepos.Get(dto.OperationID);
                }
                else
                {
                    operation.OperationID = Guid.NewGuid();
                }

                operation.InjectFrom(new IgnoreProps("OperationID"), dto);

                if (dto.OperationID != Guid.Empty)
                {
                    operationRepos.Update(operation);
                }
                else
                {
                    operationRepos.Add(operation);
                }

                scope.Save();
            }
        }

        public void DeleteOperation(Guid id)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                var operationRepos = scope.GetGenericRepository<Operation, int>();

                //Marking operation as deleted
                operationRepos.FindAll(item => item.OperationID.Equals(id))
                              .ToList()
                              .ForEach(it =>
                              {
                                  it.IsDeleted = true;
                                  it.IsActive = false;
                                  operationRepos.Update(it);
                              });
                scope.Save();
            }
        }

        public void ActivateDeactivateOperation(Guid operationID)
        {
            Ensure.That(operationID).IsNot(Guid.Empty);
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
                {
                    var operationRepos = scope.GetGenericRepository<Operation, Guid>();
                    var operation = operationRepos.Get(operationID);
                    operation.IsActive = !operation.IsActive;
                    operationRepos.Update(operation);
                    scope.Save();
            }
        }

        public bool DoesOperationNameExist(string Name)
        {
            Ensure.That(Name).IsNotNullOrEmpty();

            bool exists = false;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading,
                this.Logger,
                false))
            {
                var repos = scope.GetGenericRepository<Operation, Guid>();

                exists = repos.Exists(it => it.OperationName.Equals(Name));
            }

            return exists;
        }
    }
}
