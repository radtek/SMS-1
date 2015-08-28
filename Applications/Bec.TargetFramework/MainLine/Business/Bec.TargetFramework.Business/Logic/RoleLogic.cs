using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
//Bec.TargetFramework.Entities
using Bec.TargetFramework.Infrastructure.Log;
//using Fabrik.Common;
using Omu.ValueInjecter;
using Bec.TargetFramework.Entities.Injections;
using Bec.TargetFramework.Infrastructure.Caching;
using ServiceStack.Text;

namespace Bec.TargetFramework.Business.Logic
{
    using Bec.TargetFramework.Aop.Aspects;
    using Bec.TargetFramework.Business.Infrastructure.Interfaces;
    using Bec.TargetFramework.Entities;
    using EnsureThat;

    [Trace(TraceExceptionsOnly = true)]
    public class RoleLogic : LogicBase, IRoleLogic
    {
        public RoleLogic(ILogger logger, ICacheProvider cacheProvider)
            : base(logger, cacheProvider)
        {
        }
        public List<VRoleDTO> GetAllRoleDTO(bool showDeleted)
        {
            var dtoList = new List<VRoleDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                scope.DbContext.VRoles.ToList().ForEach(item =>
                {
                    if (showDeleted ||(item.IsActive == true && item.IsDeleted == false))
                    {
                        var dto = new VRoleDTO();

                        dto.InjectFrom(item);

                        dtoList.Add(dto);
                    }
                });
            }

            return dtoList;
        }

        public RoleDTO GetRoleDTO(Guid id)
        {
            Ensure.That(id).IsNot(Guid.Empty);

            var dto = new RoleDTO();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var Role = scope.GetGenericRepository<Role, Guid>().Get(id);

                dto.InjectFrom(Role);
            }

            return dto;
        }

        public void SaveRole(RoleDTO dto,List<RoleClaimDescriptionDTO> claims)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var RoleRepos = scope.GetGenericRepository<Role, Guid>();
                var Role = new Role();

                if (dto.RoleID != Guid.Empty)
                {
                    Role = scope.DbContext.Roles.SingleOrDefault(item => item.RoleID.Equals(dto.RoleID));
                }
                else
                {
                    Role.RoleID = Guid.NewGuid();
                    Role.IsActive = true;
                }

                Role.InjectFrom(new IgnoreProps("RoleID"), dto);

                if (dto.RoleID != Guid.Empty)
                    RoleRepos.Update(Role);
                else
                    RoleRepos.Add(Role);


                if (claims == null || claims.Count == 0 && !dto.RoleID.Equals(Guid.Empty))
                {
                    var roleClaimRepos = scope.GetGenericRepository<RoleClaim, int>();

                    // get all for urrent role and delete
                    roleClaimRepos.FindAll(item => item.RoleID.Equals(Role.RoleID))
                        .ToList().ForEach(ite =>
                        {
                            roleClaimRepos.Delete(ite);
                        });
                    
                }

                if (claims != null)
                {
                    var roleClaimRepos = scope.GetGenericRepository<RoleClaim, int>();

                    // delete aLL EXISTNG
                    if (!dto.RoleID.Equals(Guid.Empty))
                        roleClaimRepos.FindAll(item => item.RoleID.Equals(Role.RoleID))
                        .ToList().ForEach(ite =>
                        {
                            roleClaimRepos.Delete(ite);
                        });

                    if (claims.Count > 0)
                    {
                        // all items
                        List<RoleClaim> list = new List<RoleClaim>();
                        claims.ForEach(item =>
                        {
                            string[] vals = item.RoleClaimValue.Split('|');

                            var rc = new RoleClaim
                            {
                                RoleID = Role.RoleID
                            };

                            if (vals[2].Trim().Equals("Resource"))
                            {
                                rc.ResourceID = Guid.Parse(vals[0].Trim());
                                rc.OperationID = Guid.Parse(vals[1].Trim());
                            }
                            else
                            {
                                rc.StateID = Guid.Parse(vals[0].Trim());
                                rc.StateItemID = Guid.Parse(vals[1].Trim());
                            }

                            list.Add(rc);
                        });

                        roleClaimRepos.Add(list);
                    }
                }

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }



        public List<RoleDTO> GetAllRoles()
        {
            var list = new List<RoleDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var repos = scope.GetGenericRepositoryNoTracking<Role, Guid>();

                repos.GetAll().ToList().ForEach(it =>
                {
                    var template = new RoleDTO();

                    template.InjectFrom(it);

                    list.Add(template);
                });
            }

            return list.OrderBy(it => it.RoleName).ToList();
        }

        public List<RoleClaimDescriptionDTO> GetRoleClaimSourceItems(Guid roleID)
        {
            var list = new List<RoleClaimDescriptionDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var roleClaims =
                    scope.DbContext.RoleClaims.Where(item => item.RoleID.Equals(roleID)).ToList();

                scope.DbContext.VClaimSources.ToList().ForEach(item =>
                {
                    bool exists = false;
                    if (item.ClaimType.Equals("Resource"))
                    {
                        exists = roleClaims.Any(si => si.ResourceID.HasValue && si.ResourceID.Equals(item.ClaimID) &&
                                                      si.OperationID.HasValue && si.OperationID.Equals(item.ClaimSubID));
                    }
                    else if (item.ClaimType.Equals("State"))
                    {
                        exists = roleClaims.Any(si => si.StateID.HasValue && si.StateID.Equals(item.ClaimID) &&
                                                      si.StateItemID.HasValue && si.StateItemID.Equals(item.ClaimSubID));
                    }

                    if (!exists)
                    {
                        RoleClaimDescriptionDTO li = new RoleClaimDescriptionDTO
                        {
                            RoleClaimName = item.ClaimType + " | " + item.ClaimName + " | " + item.ClaimSubName,
                            RoleClaimValue =
                                item.ClaimID + " | " + item.ClaimSubID + "| " + item.ClaimType + " | " +
                                item.ClaimSubType
                        };

                        if (
                            list.Where(
                                c =>
                                    c.RoleClaimName.Equals(li.RoleClaimName) &&
                                    c.RoleClaimValue.Equals(li.RoleClaimValue)).ToList().Count == 0)
                            list.Add(li);
                    }

                });
            }

            return list.OrderBy(item => item.RoleClaimName).ToList();
        }

        public List<RoleClaimDescriptionDTO> GetClaimSourceItemsForRoleId(Guid roleId)
        {
            var list = new List<RoleClaimDescriptionDTO>();

                using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
                {
                    var claimSources = scope.DbContext.VClaimSources.ToList();

                    var roleClaims =
                        scope.DbContext.RoleClaims.Where(item => item.RoleID.Equals(roleId)).ToList();

                  roleClaims.ForEach(item =>
                    {
                if (item.ResourceID.HasValue)
                {
                    var sItem = claimSources.Single(si => si.ClaimType.Equals("Resource") && si.ClaimID == item.ResourceID.Value && si.ClaimSubID.HasValue && si.ClaimSubID.Value == item.OperationID.Value);
                    RoleClaimDescriptionDTO li = new RoleClaimDescriptionDTO
                    {
                        RoleClaimName = sItem.ClaimType + "| " + sItem.ClaimName + " | " + sItem.ClaimSubName,
                        RoleClaimValue = sItem.ClaimID + "|" + sItem.ClaimSubID + "|" + sItem.ClaimType + "|" + sItem.ClaimSubType
                    };
                    if (list.Where(c => c.RoleClaimName.Equals(li.RoleClaimName) && c.RoleClaimValue.Equals(li.RoleClaimValue)).ToList().Count == 0)
                        list.Add(li);
                }
                else if (item.StateID.HasValue)
                {
                    var sItem = claimSources.Single(si => si.ClaimType.Equals("State") && si.ClaimID.Equals(item.StateID.Value) && si.ClaimSubID.HasValue &&
                                                   si.ClaimSubID.Value  == item.StateItemID.Value);

                    RoleClaimDescriptionDTO li = new RoleClaimDescriptionDTO
                    {
                        RoleClaimName = sItem.ClaimType + "| " + sItem.ClaimName + " | " + sItem.ClaimSubName,
                        RoleClaimValue = sItem.ClaimID + "|" + sItem.ClaimSubID + "|" + sItem.ClaimType + "|" + sItem.ClaimSubType
                    };

                    if (list.Where(c => c.RoleClaimName.Equals(li.RoleClaimName) && c.RoleClaimValue.Equals(li.RoleClaimValue)).ToList().Count == 0)
                        list.Add(li);
                }
                    });
                }

                return list.OrderBy(item => item.RoleClaimName).ToList();
            }

        //Marking role template and associated claims as deleted when a role template is deleted
        public void DeleteRole(Guid RoleID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                    var roleRepos = scope.GetGenericRepository<Role, int>();

                    var roleClaimRepos = scope.GetGenericRepository<RoleClaim, int>();
                    //Marking claims for role template as deleted
                    roleClaimRepos.FindAll(item => item.RoleID.Equals(RoleID)).ToList()
                        .ForEach(it =>
                        {
                            it.IsDeleted = true;
                            it.IsActive = false;
                            roleClaimRepos.Update(it);
                        });
                    //Marking role template as deleted
                    roleRepos.FindAll(item => item.RoleID.Equals(RoleID)).ToList()
                        .ForEach(it =>
                        {
                            it.IsDeleted = true;
                            it.IsActive = false;
                            roleRepos.Update(it);
                        });
                    if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
                }                
            }
        

        public void ActivateDeactivateRole(Guid roleID)
        {
            Ensure.That(roleID).IsNot(Guid.Empty);
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var roleRepos = scope.GetGenericRepository<Role, Guid>();
                var role = roleRepos.Get(roleID);
                var active = role.IsActive;
                var roleClaimRepos = scope.GetGenericRepository<RoleClaim, Guid>();
                //Marking claims for role as inactive
                roleClaimRepos.FindAll(item => item.RoleID.Equals(roleID)).ToList()
                    .ForEach(it =>
                    {
                        it.IsActive = !active;
                        roleClaimRepos.Update(it);
                    });
                //Marking role template as inactive
                roleRepos.FindAll(item => item.RoleID.Equals(roleID)).ToList()
                    .ForEach(it =>
                    {
                        it.IsActive = !active;
                        roleRepos.Update(it);
                    });
                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }

        public bool DoesRoleNameExist(string Name)
        {
            Ensure.That(Name).IsNotNullOrEmpty();

            bool exists = false;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading,
                            this.Logger,
                            false))
            {
                var repos = scope.GetGenericRepository<Role, Guid>();

                exists = repos.Exists(it => it.RoleName.Equals(Name));
            }

            return exists;
        }
    }
}
