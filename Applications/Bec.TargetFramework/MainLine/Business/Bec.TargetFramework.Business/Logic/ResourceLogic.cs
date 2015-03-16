using System;
using System.Collections.Generic;
using System.Linq;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using EnsureThat;
using Bec.TargetFramework.Entities.Injections;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
using NHibernate.Linq;
using Omu.ValueInjecter;

namespace Bec.TargetFramework.Business.Logic
{
    using Bec.TargetFramework.Aop.Aspects;
    using Bec.TargetFramework.Business.Infrastructure.Interfaces;
    using Bec.TargetFramework.Entities;


    [Trace(TraceExceptionsOnly = true)]
    public class ResourceLogic : LogicBase, IResourceLogic
    {
        public ResourceLogic(ILogger logger, ICacheProvider cacheProvider) : base(logger, cacheProvider)
        {
        }

        public ResourceDTO CreateAndInitializeDTO()
        {
            var dto = new ResourceDTO();
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                scope.GetGenericRepository<Operation, Guid>().GetAll().ToList().ForEach(item =>
                {
                    var oDto = new OperationDTO();
                    oDto.InjectFrom(item);
                    dto.Operations.Add(oDto);
                });
            }

            return dto;
        }

        public List<VResourceDTO> GetAllResourceDTO(bool showDeleted)
        {
            var dtoList = new List<VResourceDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                scope.DbContext.VResources.ToList().ForEach(item =>
                {
                    if (showDeleted || (item.IsActive == true && item.IsDeleted == false))
                    {
                        var dto = new VResourceDTO();

                        dto.InjectFrom(item);

                        dtoList.Add(dto);
                    }
                });
            }

            return dtoList;
        }

        public ResourceDTO GetResourceDTO(Guid id)
        {
            Ensure.That(id).IsNot(Guid.Empty);

            var dto = new ResourceDTO();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var resource = scope.DbContext.Resources.Include("Operations").Single(item => item.ResourceID.Equals(id));

                dto.InjectFrom(resource);

                // add ops
                scope.GetGenericRepository<Operation, Guid>().GetAll().ToList().ForEach(item =>
                {
                    var oDto = new OperationDTO();
                    oDto.InjectFrom(item);
                    dto.Operations.Add(oDto);
                });

                // add selected ops
                dto.SelectedOperations = String.Join(",", resource.Operations.Select(item => item.OperationID.ToString()).ToArray());
            }

            return dto;
        }
        public void SaveResource(ResourceDTO dto, string[] selectedOperations)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                var ResourceRepos = scope.GetGenericRepository<Resource, Guid>();
                var resource = new Resource();

                if (dto.ResourceID != Guid.Empty)
                {
                    resource = ResourceRepos.Get(dto.ResourceID);
                }
                else
                {
                    resource.ResourceID = Guid.NewGuid();
                }

                resource.InjectFrom(new IgnoreProps("ResourceID"), dto);

                if (dto.ResourceID != Guid.Empty)
                {
                    ResourceRepos.Update(resource);
                }
                else
                {
                    ResourceRepos.Add(resource);
                }

                if (selectedOperations != null && selectedOperations.Length > 0)
                {
                    List<Guid> selectedOperationsList = new List<Guid>();
                    selectedOperations.ForEach(s =>
                    {
                         selectedOperationsList.Add(Guid.Parse(s));
                    });
                    this.RebuildOperationResource(selectedOperationsList, resource);
                }

                scope.Save();
            }
        }

        public void RebuildOperationResource(List<Guid> operationIds, Resource resource)
        {
            //Ensure.That(operationIds);

            //using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            //{
            //    var ros = scope.DbContext.Resources.Include("ResourceOperations").SingleOrDefault(item => item.ResourceID.Equals(resource.ResourceID));

            //    if (ros == null)
            //        ros = new Resource();

            //    if (ros.ResourceOperations == null)
            //        ros.ResourceOperations = new List<ResourceOperation>();

            //    operationIds.Where(it => !ros.ResourceOperations.Any(ro => ro.OperationID.Equals(it))).ToList().ForEach(item =>
            //    {
            //        //Guid opId = Guid.Parse(item);
            //        ros.ResourceOperations.Add(new ResourceOperation { OperationID = item, ResourceID = resource.ResourceID });
            //    });

            //    while (ros.ResourceOperations.Any(si => !operationIds.Any(ip => ip.Equals(si.OperationID))))
            //    {
            //        var ro = ros.ResourceOperations.First(si => !operationIds.Any(ip => ip.Equals(si.OperationID)));

            //        ros.ResourceOperations.Remove(ro);
            //    }


            //    scope.Save();
            //}
        }
        //public void SaveResource(ResourceDTO dto, string[] selectedOperations)
        //{
        //    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
        //    {
        //        var ResourceRepos = scope.GetGenericRepository<Resource, Guid>();
        //        var resource = new Resource();

        //        if (dto.ResourceID != Guid.Empty)
        //        {
        //            resource = ResourceRepos.Get(dto.ResourceID);
        //        }
        //        else
        //        {
        //            resource.ResourceID = Guid.NewGuid();
        //        }

        //        resource.InjectFrom(new IgnoreProps("ResourceID"), dto);

        //        if (dto.ResourceID != Guid.Empty)
        //        {
        //            ResourceRepos.Update(resource);
        //        }
        //        else
        //        {
        //            ResourceRepos.Add(resource);
        //        }

        //        if (selectedOperations != null && selectedOperations.Length > 0)
        //        {
        //            this.RebuildOperationResource(new List<string>(selectedOperations), resource);
        //        }

        //        scope.Save();
        //    }
        //}

        //public void RebuildOperationResource(List<string> operationIds, Resource resource)
        //{
        //    Ensure.That(operationIds);

        //    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
        //    {
        //        var ros = scope.DbContext.Resources.Include("ResourceOperations").SingleOrDefault(item => item.ResourceID.Equals(resource.ResourceID));

        //        if (ros == null)
        //            ros = new Resource();

        //        if (ros.ResourceOperations == null)
        //            ros.ResourceOperations = new List<ResourceOperation>();

        //        operationIds.Where(it => !ros.ResourceOperations.Any(ro => ro.OperationID.Equals(Guid.Parse(it)))).ToList().ForEach(item =>
        //        {
        //            Guid opId = Guid.Parse(item);
        //            ros.ResourceOperations.Add(new ResourceOperation { OperationID = opId, ResourceID = resource.ResourceID });
        //        });

        //        while(ros.ResourceOperations.Any(si => !operationIds.Any(ip => ip.Equals(si.OperationID.ToString()))))
        //        {
        //            var ro = ros.ResourceOperations.First(si => !operationIds.Any(ip => ip.Equals(si.OperationID.ToString())));

        //            ros.ResourceOperations.Remove(ro);
        //        }


        //        scope.Save();
        //    }
        //}

        //Marking resource and associated operations as deleted when resource deleted
        public void DeleteResource(Guid resourceID)
        {
            //using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            //{
            //    var resourceRepos = scope.GetGenericRepository<Resource, int>();

            //    var resourceOperationRepos = scope.GetGenericRepository<ResourceOperation, Guid>();
            //    //Marking operations for resource as deleted
            //    resourceOperationRepos.FindAll(item => item.ResourceID.Equals(resourceID))
            //                          .ToList()
            //                          .ForEach(it =>
            //                          {
            //                              it.IsDeleted = true;
            //                              it.IsActive = false;
            //                              resourceOperationRepos.Update(it);
            //                          });
            //    //Marking group template as deleted
            //    resourceRepos.FindAll(item => item.ResourceID.Equals(resourceID))
            //                 .ToList()
            //                 .ForEach(it =>
            //                 {
            //                     it.IsDeleted = true;
            //                     it.IsActive = false;
            //                     resourceRepos.Update(it);
            //                 });
            //    scope.Save();
            //}
        }



        public bool DoesResourceNameExist(string Name)
        {
            Ensure.That(Name).IsNotNullOrEmpty();

            bool exists = false;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading,
                this.Logger,
                false))
            {
                var repos = scope.GetGenericRepository<Resource, Guid>();

                exists = repos.Exists(it => it.ResourceName.Equals(Name));
            }

            return exists;
        }


        public void ActivateDeactivateResource(Guid resourceID)
        {
            //Ensure.NotNull(resourceID);
            //using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            //{
            //    var resourceRepos = scope.GetGenericRepository<Resource, Guid>();
            //    var resource = resourceRepos.Get(resourceID);
            //    var active = resource.IsActive;
            //    var resourceOperationRepos = scope.GetGenericRepository<ResourceOperation, Guid>();
            //    //Marking operations for resource as inactive
            //    resourceOperationRepos.FindAll(item => item.ResourceID.Equals(resourceID)).ToList()
            //        .ForEach(it =>
            //        {
            //            it.IsActive = !active;
            //            resourceOperationRepos.Update(it);
            //        });
            //    //Marking group template as deleted
            //    resourceRepos.FindAll(item => item.ResourceID.Equals(resourceID)).ToList()
            //        .ForEach(it =>
            //        {  
            //            it.IsActive = !active;
            //            resourceRepos.Update(it);
            //        });
            //    scope.Save();
            //}
        }
    }
}
