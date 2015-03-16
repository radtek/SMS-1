using System;
using System.Collections.Generic;
using System.Linq;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;

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
    //Bec.TargetFramework.Entities
   

    [Trace(TraceExceptionsOnly = true)]
    public class OrganisationUserStateTemplateLogic : LogicBase, IOrganisationUserStateTemplateLogic
    {
        public OrganisationUserStateTemplateLogic(ILogger logger, ICacheProvider provider) : base(logger,provider)
        {
        }

        public List<OrganisationUserStateTemplateDTO> GetAllOrganisationUserStateTemplateDTO()
        {
            var dtoList = new List<OrganisationUserStateTemplateDTO>();

            //using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            //{
            //    scope.DbContext.OrganisationUserStateTemplates.Where(vs => vs.IsDeleted == false).ToList().ForEach(item =>
            //    {
            //        var dto = new OrganisationUserStateTemplateDTO();

            //        dto.InjectFrom(item);

            //        dtoList.Add(dto);
            //    });
            //}

            return dtoList;
        }

        public OrganisationUserStateTemplateDTO GetOrganisationUserStateTemplateDTO(Guid id)
        {
            Ensure.That(id).IsNot(Guid.Empty);

            var dto = new OrganisationUserStateTemplateDTO();

            //using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            //{
            //    var roleTemplate = scope.GetGenericRepository<OrganisationUserStateTemplate, Guid>().Get(id);

            //    dto.InjectFrom(roleTemplate);
            //}

            return dto;
        }

        public void SaveOrganisationUserStateTemplate(OrganisationUserStateTemplateDTO dto)
        {
            //using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            //{
            //    var visibilityStateRepos = scope.GetGenericRepository<OrganisationUserStateTemplate, Guid>();
            //    var OrganisationUserStateTemplate = new OrganisationUserStateTemplate();

            //    if (dto.OrganisationUserStateTemplateId != Guid.Empty)
            //    {
            //        OrganisationUserStateTemplate =
            //            scope.DbContext
            //                 .OrganisationUserStateTemplates
            //                 .SingleOrDefault(item => item.OrganisationUserStateTemplateId.Equals(dto.OrganisationUserStateTemplateId));
            //        dto.IsDisabled = OrganisationUserStateTemplate.IsDisabled;
            //        dto.IsDeleted = OrganisationUserStateTemplate.IsDeleted;
            //        dto.IsActive = OrganisationUserStateTemplate.IsActive;
            //    }
            //    else
            //    {
            //        OrganisationUserStateTemplate.OrganisationUserStateTemplateId = Guid.NewGuid();
            //        dto.IsActive = true;
            //        dto.IsDeleted = false;
            //        dto.IsDisabled = false;
            //    }

            //    OrganisationUserStateTemplate.InjectFrom(new IgnoreProps("OrganisationUserStateTemplateId"), dto);

            //    if (dto.OrganisationUserStateTemplateId != Guid.Empty)
            //    {
            //        visibilityStateRepos.Update(OrganisationUserStateTemplate);
            //    }
            //    else
            //    {
            //        visibilityStateRepos.Add(OrganisationUserStateTemplate);
            //    }
            //    var visibilityClaimRepos = scope.GetGenericRepository<VisibilityStateVisibilityScheme, int>();

            //    //if (claims != null)
            //    //{

            //    //    // delete aLL EXISTNG
            //    //    if (!dto.OrganisationUserStateTemplateId.Equals(Guid.Empty))
            //    //    {
            //    //        visibilityClaimRepos.FindAll(item => item.OrganisationUserStateTemplateId.Equals(dto.OrganisationUserStateTemplateId))
            //    //         .ToList().ForEach(ite =>
            //    //         {
                //             visibilityClaimRepos.Delete(ite);
                //         });
                //    }
                //}
                //if (claims.Count > 0)
                //{
                //    // all items
                //    List<VisibilityStateVisibilityScheme> list = new List<VisibilityStateVisibilityScheme>();
                //    claims.ForEach(item =>
                //    {

                //        var rc = new VisibilityStateVisibilityScheme
                //        {
                //            VisibilityStateVisibilitySchemeId = System.Guid.NewGuid(),                            
                //            VisibilitySchemeTemplateId=item.VisibilitySchemeTemplateId
                //        };

                //        list.Add(rc);
                //    });

                //    visibilityClaimRepos.Add(list);

                //}
             //   scope.Save();
            //}
        }

        public List<OrganisationUserStateTemplateDTO> GetAllOrganisationUserStateTemplate()
        {
            var list = new List<OrganisationUserStateTemplateDTO>();

            //using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            //{
            //    var repos = scope.GetGenericRepositoryNoTracking<OrganisationUserStateTemplate, Guid>();

            //    repos.GetAll().ForEach(it =>
            //    {
            //        var template = new OrganisationUserStateTemplateDTO();

            //        template.InjectFrom(it);

            //        list.Add(template);
            //    });
            //}

            return list.OrderBy(it => it.OrganisationUserStateTemplateName).ToList();
        }

        public void DeleteOrganisationUserStateTemplate(Guid OrganisationUserStateTemplateId)
        {
            //using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            //{
            //    var col = scope.DbContext.OrganisationUserStateTemplates.Where(item => item.OrganisationUserStateTemplateId.Equals(OrganisationUserStateTemplateId)).ToList();
            //    var visibilityStateRepos = scope.GetGenericRepository<OrganisationUserStateTemplate, Guid>();
            //    var OrganisationUserStateTemplate =
            //        scope.DbContext
            //             .OrganisationUserStateTemplates
            //             .SingleOrDefault(item => item.OrganisationUserStateTemplateId.Equals(OrganisationUserStateTemplateId));
            //    OrganisationUserStateTemplate.IsDeleted = true;
            //    visibilityStateRepos.Update(OrganisationUserStateTemplate);
            //    //scope.DbContext.VisibilitySchemeTemplates.RemoveRange(col);

            //    scope.Save();
            //}
        }

        public bool DoesOrganisationUserStateTemplateNameExist(Guid OrganisationUserStateTemplateId, string OrganisationUserStateTemplateName)
        {
            Ensure.That(OrganisationUserStateTemplateName).IsNotNullOrEmpty();

            bool exists = false;

            //using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading,
            //    this.Logger,
            //    false))
            //{
            //    var repos = scope.GetGenericRepository<OrganisationUserStateTemplate, Guid>();

            //    exists = repos.Exists(it => it.OrganisationUserStateTemplateName.Equals(OrganisationUserStateTemplateName) && it.OrganisationUserStateTemplateId != OrganisationUserStateTemplateId);
            //}

            return exists;
        }

        public bool DoesOrganisationUserStateTemplateNameExist(string OrganisationUserStateTemplateName)
        {
            Ensure.That(OrganisationUserStateTemplateName).IsNotNullOrEmpty();

            bool exists = false;

            //using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading,
            //    this.Logger,
            //    false))
            //{
            //    var repos = scope.GetGenericRepository<OrganisationUserStateTemplate, Guid>();

            //    exists = repos.Exists(it => it.OrganisationUserStateTemplateName.Equals(OrganisationUserStateTemplateName));
            //}

            return exists;
        }
    }
}
