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
using ServiceStack.Text;

namespace Bec.TargetFramework.Business.Logic
{
    using Bec.TargetFramework.Aop.Aspects;
    using Bec.TargetFramework.Business.Infrastructure.Interfaces;
    using Bec.TargetFramework.Entities;
    using EnsureThat;

    [Trace(TraceExceptionsOnly = true)]
    public class GroupLogic : LogicBase, IGroupLogic
    {
        public GroupLogic(ILogger logger, ICacheProvider cacheProvider) : base(logger, cacheProvider)
        {
        }
    
        public List<VGroupDTO> GetAllGroupDTO(bool showDeleted)
        {
            var dtoList = new List<VGroupDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                scope.DbContext.VGroups.ToList().ForEach(item =>
                {
                    if(showDeleted || (item.IsActive == true && item.IsDeleted == false))
                    {
                        var dto = new VGroupDTO();

                        dto.InjectFrom(item);

                        dtoList.Add(dto);
                    }
                });
            }

            return dtoList;
        }

        public GroupDTO GetGroupDTO(Guid id)
        {
            Ensure.That(id).IsNot(Guid.Empty);

            var dto = new GroupDTO();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var Group = scope.GetGenericRepository<Group, Guid>().Get(id);

                dto.InjectFrom<NullableInjection>(Group);
            }

            return dto;
        }

        public void SaveGroup(GroupDTO dto, List<GroupRoleDTO> roles)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                var GroupRepos = scope.GetGenericRepository<Group, Guid>();
                var Group = new Group();

                if (dto.GroupID != Guid.Empty)
                {
                    Group =
                        scope.DbContext
                             .Groups
                             .SingleOrDefault(item => item.GroupID.Equals(dto.GroupID));
                }
                else
                {
                    Group.GroupID = Guid.NewGuid();
                    Group.IsActive = true;
                }

                Group.InjectFrom<NullableInjection>(new IgnoreProps("GroupID"), dto);

                if (dto.GroupID != Guid.Empty)
                {
                    GroupRepos.Update(Group);
                }
                else
                {
                    GroupRepos.Add(Group);
                }

                if (roles == null || roles.Count == 0 && !dto.GroupID.Equals(Guid.Empty))
                {
                    var roleRepos = scope.GetGenericRepository<GroupRole, int>();

                    // get all for urrent role and delete
                    roleRepos.FindAll(item => item.GroupID.Equals(Group.GroupID))
                             .ToList()
                             .ForEach(ite =>
                             {
                                 roleRepos.Delete(ite);
                             });
                }

                if (roles != null)
                {
                    var roleRepos = scope.GetGenericRepository<GroupRole, int>();

                    // get all for urrent role and delete
                    roleRepos.FindAll(item => item.GroupID.Equals(Group.GroupID))
                             .ToList()
                             .ForEach(ite =>
                             {
                                 roleRepos.Delete(ite);
                             });

                    if (roles.Count > 0)
                    {
                        // all items
                        List<GroupRole> list = new List<GroupRole>();
                        roles.ForEach(item =>
                        {
                            list.Add(new GroupRole { GroupID = Group.GroupID, RoleID = Guid.Parse(item.RoleValue) });
                        });

                        roleRepos.Add(list);
                    }
                }

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }

        public List<GroupRoleDTO> GetRoleItems(Guid groupID)
        {
            var list = new List<GroupRoleDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var roleClaims =
                    scope.DbContext.GroupRoles.Where(item => item.GroupID.Equals(groupID)).ToList();

                scope.DbContext.Roles.ToList().ForEach(item =>
                {
                    bool exists = false;

                    if (roleClaims.Count > 0)
                    {
                        exists = roleClaims.Any(rc => rc.RoleID.Equals(item.RoleID));
                    }

                    if (!exists)
                    {
                        GroupRoleDTO li = new GroupRoleDTO
                        {
                            RoleName = item.RoleName,
                            RoleValue = item.RoleID.ToString()
                        };

                        list.Add(li);
                    }
                });
            }

            return list.OrderBy(item => item.RoleName).ToList();
        }

        public List<GroupDTO> GetAllGroups()
        {
            var list = new List<GroupDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var repos = scope.GetGenericRepositoryNoTracking<Group, Guid>();

                repos.GetAll().ToList().ForEach(it =>
                {
                    var template = new GroupDTO();

                    template.InjectFrom(it);

                    list.Add(template);
                });
            }

            return list.OrderBy(item => item.GroupName).ToList();
        }

        public List<GroupRoleDTO> GetRoleItemsForGroupId(Guid groupID)
        {
            var list = new List<GroupRoleDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var claimSources = scope.DbContext.VClaimSources.ToList();

                var roleClaims =
                    scope.DbContext.GroupRoles.Where(item => item.GroupID.Equals(groupID)).ToList();

                roleClaims.ForEach(item =>
                {
                    var sItem =
                        scope.DbContext.Roles.SingleOrDefault(rt => rt.RoleID == item.RoleID);

                    GroupRoleDTO li = new GroupRoleDTO
                    {
                        RoleName = sItem.RoleName,
                        RoleValue = item.RoleID.ToString()
                    };

                    list.Add(li);
                });
            }

            return list.OrderBy(item => item.RoleName).ToList();
        }

        public bool DoesGroupNameExist(string Name)
        {
            Ensure.That(Name).IsNotNullOrEmpty();

            bool exists = false;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading,
                this.Logger,
                false))
            {
                var repos = scope.GetGenericRepository<Group, Guid>();

                exists = repos.Exists(it => it.GroupName.Equals(Name));
            }

            return exists;
        }

        //Marking group template and associated roles as deleted when a group template is deleted
        public void DeleteGroup(Guid groupID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                var grpRepos = scope.GetGenericRepository<Group, int>();

                var grpRoleRepos = scope.GetGenericRepository<GroupRole, Guid>();
                //Marking roles for group template as deleted
                grpRoleRepos.FindAll(item => item.GroupID.Equals(groupID))
                            .ToList()
                            .ForEach(it =>
                            {
                                it.IsDeleted = true;
                                it.IsActive = false;
                                grpRoleRepos.Update(it);
                            });
                //Marking group template as deleted
                grpRepos.FindAll(item => item.GroupID.Equals(groupID))
                        .ToList()
                        .ForEach(it =>
                        {
                            it.IsDeleted = true;
                            it.IsActive = false;
                            grpRepos.Update(it);
                        });
                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }

        public void ActivateDeactivateGroup(Guid groupID)
        {
            Ensure.That(groupID).IsNot(Guid.Empty);
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var GroupRepos = scope.GetGenericRepository<Group, Guid>();
                var Group = GroupRepos.Get(groupID);
                var active = Group.IsActive;
                var GroupRoleRepos = scope.GetGenericRepository<GroupRole, Guid>();
                //Marking roles for Group as inactive
                GroupRoleRepos.FindAll(item => item.GroupID.Equals(groupID)).ToList()
                    .ForEach(it =>
                    {
                        it.IsActive = !active;
                        GroupRoleRepos.Update(it);
                    });
                //Marking group template as inactive
                GroupRepos.FindAll(item => item.GroupID.Equals(groupID)).ToList()
                    .ForEach(it =>
                    {
                        it.IsActive = !active;
                        GroupRepos.Update(it);
                    });
                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }
    }
}
