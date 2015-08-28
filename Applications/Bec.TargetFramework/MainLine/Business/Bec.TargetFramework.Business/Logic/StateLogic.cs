using System;
using System.Collections.Generic;
using System.Linq;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Data.Repositories;
//Bec.TargetFramework.Entities
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
    public class StateLogic : LogicBase, IStateLogic
    {
        public StateLogic(ILogger logger, ICacheProvider cacheProvider) : base(logger, cacheProvider)
        {
        }

        public List<StateDTO> GetAllStateDTO(bool showDeleted)
        {
            var dtoList = new List<StateDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading,this.Logger))
            {
                scope.DbContext.States.ToList().ForEach(item =>
                {
                    if (showDeleted || (item.IsActive == true && item.IsDeleted == false))
                    {
                        var dto = new StateDTO();

                        dto.InjectFrom(item);

                        dtoList.Add(dto);
                    }
                });
            }

            return dtoList;
        }

        public StateDTO GetStateDTO(Guid id)
        {
            Ensure.That(id).IsNot(Guid.Empty);

            var dto = new StateDTO();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var State = scope.GetGenericRepository<State, Guid>().Get(id);

                dto.InjectFrom(State);
            }

            return dto;
        }

        public void SaveState(StateDTO dto)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                var StateRepos = scope.GetGenericRepository<State, Guid>();
                var State = new State();

                if (dto.StateID != Guid.Empty)
                {
                    State = StateRepos.Get(dto.StateID);
                }
                else
                {
                    State.StateID = Guid.NewGuid();
                }

                State.InjectFrom(new IgnoreProps("StateID"), dto);

                if (dto.StateID != Guid.Empty)
                {
                    StateRepos.Update(State);
                }
                else
                {
                    StateRepos.Add(State);
                }

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }

        public List<StateItemSlimDTO> GetParentStateItems(Guid stateId, string currentName)
        {
            var list = new List<StateItemSlimDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var stateItemRespository = scope.GetGenericRepository<VState, Guid>();

                var stateItems = stateItemRespository.FindAll(item => !item.StateName.Equals(currentName) && item.StateID.Equals(stateId) && !item.ParentStateItemID.HasValue);

                stateItems.ToList().ForEach(sta =>
                {
                    var dto = new StateItemSlimDTO();
                    dto.InjectFrom(sta);

                    if (sta.ParentStateItemID.HasValue)
                    {
                        dto.ParentStateItemID = sta.ParentStateItemID.ToString();
                    }
                    list.Add(dto);
                });
            }

            return list;
        }

        public
        List<StateItemSlimDTO> GetStateItemSlimDTOsForStateID(Guid stateId)
        {
            var list = new List<StateItemSlimDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var stateItemRespository = scope.GetGenericRepository<VState, Guid>();

                var stateItems = stateItemRespository.FindAll(item => item.StateID.Equals(stateId));

                stateItems.ToList().ForEach(sta =>
                {
                    var dto = new StateItemSlimDTO();
                    dto.InjectFrom(sta);
                    if (sta.ParentStateItemID.HasValue)
                    {
                        dto.ParentStateItemID = sta.ParentStateItemID.ToString();
                    }
                    list.Add(dto);
                });

                // now add second level
                var newList = new List<StateItemSlimDTO>();

                list.ForEach(item =>
                {
                    var pstateItems =
                        stateItemRespository.FindAll(
                            it => it.ParentStateItemID.HasValue && it.ParentStateItemID.Value.Equals(item.StateItemID))
                                            .ToList();

                    newList.Add(item);

                    pstateItems.ForEach(psi =>
                    {
                        var dto = new StateItemSlimDTO();
                        dto.InjectFrom(psi);
                        if (psi.ParentStateItemID.HasValue)
                        {
                            dto.ParentStateItemID = psi.ParentStateItemID.ToString();
                        }
                        newList.Add(dto);
                    });
                });

                list = newList;
            }

            return list.OrderBy(item => item.StateItemName).ToList();
        }

        public StateItemSlimDTO GetStateItemSlimDTO(Guid stateItemId)
        {
            var sitem = new StateItemSlimDTO();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var stateItemRespository = scope.GetGenericRepository<StateItem, Guid>();

                var item = stateItemRespository.Get(stateItemId);

                sitem.InjectFrom(item);

                if (item.ParentStateItemID.HasValue)
                {
                    sitem.ParentStateItemID = item.ParentStateItemID.ToString();
                }

                sitem.ParentStateID = item.StateID;
            }

            return sitem;
        }

        public List<StateItemDTO> GetStateItemTreeDTOForStateID(Guid stateItemId)
        {

            Ensure.That(stateItemId).IsNot(Guid.Empty);
           
            var list = new List<StateItemDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var stateItemRespository = scope.GetCustomRepository<VStateRepository>();

                // load entire backload of vstates
                var stateItems = stateItemRespository.GetAll().ToList();

                stateItems.Where(item => item.StateID.Equals(stateItemId) && !item.ParentStateItemID.HasValue).ToList().ForEach(sta =>
                {
                    var dto = new StateItemDTO();
                    dto.InjectFrom(sta);

                    var children = new List<StateItemDTO>();

                    stateItems.Where(item => !sta.StateItemID.Equals(Guid.Empty) && item.ParentStateItemID.Equals(sta.StateItemID)).ToList().ForEach(item =>
                    {
                        var to = new StateItemDTO();

                        to.InjectFrom(item);

                        //stateItems.Where(it => !item.StateItemID.Equals(Guid.Empty) && it.ParentStateItemID.Equals(item.StateItemID)).ToList()
                        //    .ForEach(sli =>
                        //    {
                        //        var slit = new StateItemDTO();
                        //        slit.InjectFrom(sli);
                        //        if (sli.ParentStateItemID.HasValue)
                        //            slit.ParentStateItemID = sli.ParentStateItemID.Value.ToString();
                        //        to.Children.Add(slit);
                        //    });

                        //if(ClaimsHelper.UserHasClaim(to.StateItemName, to.StateName))
                        children.Add(to);
                    });

                    dto.Children = children;

                    //if (ClaimsHelper.UserHasClaim(dto.StateItemName, dto.StateName))
                    list.Add(dto);
                });
            }

            return list;
        }

        public void SaveStateItem(StateItemSlimDTO dto)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                var StateRepos = scope.GetGenericRepository<StateItem, Guid>();
                var stateItem = new StateItem();

                if (dto.StateItemID != Guid.Empty)
                {
                    stateItem = StateRepos.Get(dto.StateItemID);
                }
                else
                {
                    stateItem.StateItemID = Guid.NewGuid();
                }

                stateItem.InjectFrom(new IgnoreProps("StateItemID","StateID","ParentStateItemID"), dto);

                stateItem.StateID = dto.StateID;

                if (!string.IsNullOrEmpty(dto.ParentStateItemID) && Guid.Parse(dto.ParentStateItemID) != Guid.Empty)
                {
                    stateItem.ParentStateItemID = Guid.Parse(dto.ParentStateItemID);
                }

                if (dto.StateItemID != Guid.Empty)
                {
                    StateRepos.Update(stateItem);
                }
                else
                {
                    StateRepos.Add(stateItem);
                }

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }

        public void DeleteStateItem(Guid stateItemID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                var rtRepos = scope.GetGenericRepository<RoleClaim, int>();

                var siRepos = scope.GetGenericRepository<StateItem, Guid>();

                rtRepos.FindAll(item => item.StateItemID.HasValue && item.StateItemID.Value.Equals(stateItemID))
                       .ToList()
                       .ForEach(it =>
                       {
                           it.IsDeleted = true;
                           it.IsActive = false;
                           rtRepos.Update(it);
                       });

                siRepos.FindAll(item => item.ParentStateItemID.HasValue && item.ParentStateItemID.Value.Equals(stateItemID))
                       .ToList()
                       .ForEach(it =>
                       {
                           it.IsDeleted = true;
                           it.IsActive = false;
                           siRepos.Update(it);
                       });

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }

        public void DeleteState(Guid stateID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                var stateRepos = scope.GetGenericRepository<State, int>();

                var stateItemRepos = scope.GetGenericRepository<StateItem, int>();

                stateRepos.FindAll(item => item.StateID.Equals(stateID))
                          .ToList()
                          .ForEach(it =>
                          {
                              it.IsDeleted = true;
                              it.IsActive = false;
                              stateRepos.Update(it);
                          });

                stateItemRepos.FindAll(item => item.StateID.Equals(stateID))
                              .ToList()
                              .ForEach(it =>
                              {
                                  this.DeleteStateItem(it.StateItemID);
                              });

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }

        public void ActivateDeactivateState(Guid stateID)
        {
            Ensure.That(stateID).IsNot(Guid.Empty);
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var stateRepos = scope.GetGenericRepository<State, Guid>();
                var state = stateRepos.Get(stateID);
                var active = state.IsActive;
                var stateItemRepos = scope.GetGenericRepository<StateItem, Guid>();
                //Marking operations for state as inactive
                stateItemRepos.FindAll(item => item.StateID.Equals(stateID)).ToList()
                    .ForEach(it =>
                    {
                        it.IsActive = !active;
                        stateItemRepos.Update(it);
                    });
                //Marking group template as deleted
                stateRepos.FindAll(item => item.StateID.Equals(stateID)).ToList()
                    .ForEach(it =>
                    {
                        it.IsActive = !active;
                        stateRepos.Update(it);
                    });
                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }

        public bool DoesStateNameExist(string Name)
        {
            Ensure.That(Name).IsNotNullOrEmpty();

            bool exists = false;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading,
                this.Logger,
                false))
            {
                var repos = scope.GetGenericRepository<State, Guid>();

                exists = repos.Exists(it => it.StateName.Equals(Name));
            }

            return exists;
        }

        public bool DoesStateItemNameExist(string Name)
        {
            Ensure.That(Name).IsNotNull();

            bool exists = false;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading,
                this.Logger,
                false))
            {
                var repos = scope.GetGenericRepository<StateItem, Guid>();

                exists = repos.Exists(it => it.StateItemName.Equals(Name));
            }

            return exists;
        }
    }
}
