using System.Collections.Specialized;
using System.Threading;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Entities.DTO.Workflow;
using Bec.TargetFramework.Infrastructure.Collections;
using Bec.TargetFramework.Workflow.Base;
using Bec.TargetFramework.Workflow.Engine;
using Bec.TargetFramework.Workflow.Interfaces;
using Bec.TargetFramework.Workflow.Providers;
using Bec.TargetFramework.Workflow.Scheduler;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEC.TargetFramework.Workflow.Test.IOC;
using Autofac;
using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.Workflow.Test
{
    //Bec.TargetFramework.Entities

    public class ComplexWorkflowTest1
    {
        public ComplexWorkflowTest1()
        {
            
            ExecuteWorkflow();
           // ExecuteWorkflow2();
            //ExecuteWorkflow1();
            //CreateWorkFlowFromTemplate();
        }

        private IContainer m_IocContainer;



        private void CreateWorkFlowFromTemplate()
        {
            var genericData = new ConcurrentDictionary<string, object>();

            genericData["MyNumber"] = 10;

            var jsonString = ServiceStack.Text.JsonSerializer.SerializeToString(genericData);

           Thread.Sleep(15000);

           WorkflowStartup.InitializeIOC();

           var engine = WorkflowStartup.ResolveType<WorkflowEngine>();

           var COLPRegistrationWorkFlow = engine.CreateNewWorkflowFromTemplate(Guid.Parse("060729a1-56c2-489c-9c45-78064c62997a"), 1, genericData,Guid.NewGuid());

        }

        private void ExecuteWorkflow1()
        {
            Thread.Sleep(10000);


            try
            {
                //ContainerBuilder builder = new ContainerBuilder();

                //var registrar = new DependencyRegistrar();

                //registrar.Register(builder, null);

                //m_IocContainer = builder.Build();

                //var genericData = new ConcurrentDictionary<string, object>();

                //genericData["MyNumber"] = 10;

                //var jsonString = ServiceStack.Text.JsonSerializer.SerializeToString(genericData);

                //var service = m_IocContainer.Resolve<IWorkflowProcessService>();

                //Thread.Sleep(30000);
                //// create workflow and start
                //// var dto = service.CreateAndStartWorkflowInstance(Guid.Parse("0307e776-0070-11e4-9f54-dfffa1f5fab4"), 1, jsonString, Guid.NewGuid(), new List<UserAccountOrganisationDTO>());
                //var dto = service.CreateAndStartWorkflowInstance(
                //    Guid.Parse("eece7982-0ce0-11e4-a20c-1f37aebf8b3e"),
                //    1,
                //    new WorkflowDictionaryDTO { WorkflowDictionary = genericData },
                //    Guid.NewGuid(),
                //    new List<UserAccountOrganisationDTO>());
                //// var dto = service.CreateAndStartWorkflowInstance(Guid.Parse("9b25fdb3-6696-43e9-bae3-1e06383f478b"), 1, jsonString, Guid.NewGuid(), new List<UserAccountOrganisationDTO>());

                //// restart
                //var restartDto = service.RestartWorkflowInstance(dto.InstanceDTO.WorkflowInstanceID, dto.InstanceDTO.ParentID);

            }
            catch (System.Exception ex)
            {
                Serilog.Log.Logger.Error(ex, ex.Message, null);
                Console.WriteLine("ExecuteWorkflow Exernal Invites:" + ex.Message);
            }
        }

        private void ExecuteWorkflow2()
        {
            Thread.Sleep(10000);


            try
            {
                //ContainerBuilder builder = new ContainerBuilder();

                //var registrar = new DependencyRegistrar();

                //registrar.Register(builder, null);

                //m_IocContainer = builder.Build();

                //var genericData = new ConcurrentDictionary<string, object>();

                //genericData["MyNumber"] = 10;

                //var jsonString = ServiceStack.Text.JsonSerializer.SerializeToString(genericData);

                //var service = m_IocContainer.Resolve<IWorkflowProcessService>();

                //Thread.Sleep(15000);
                //// create workflow and start
                //// var dto = service.CreateAndStartWorkflowInstance(Guid.Parse("0307e776-0070-11e4-9f54-dfffa1f5fab4"), 1, jsonString, Guid.NewGuid(), new List<UserAccountOrganisationDTO>());
                //var dto = service.CreateAndStartWorkflowInstance(
                //    Guid.Parse("ba038e5c-006c-11e4-8d1e-cfad80eb14ee"),
                //    1,
                //    new WorkflowDictionaryDTO { WorkflowDictionary = genericData },
                //    Guid.NewGuid(),
                //    new List<UserAccountOrganisationDTO>());
                //// var dto = service.CreateAndStartWorkflowInstance(Guid.Parse("9b25fdb3-6696-43e9-bae3-1e06383f478b"), 1, jsonString, Guid.NewGuid(), new List<UserAccountOrganisationDTO>());

                //// restart
                ////var restartDto = service.RestartWorkflowInstance(dto.InstanceDTO.WorkflowInstanceID, dto.InstanceDTO.ParentID);

            }
            catch (System.Exception ex)
            {
                Serilog.Log.Logger.Error(ex, ex.Message, null);
                Console.WriteLine("ExecuteWorkflow Organisation Admin:" + ex.Message);
            }
        }

        private void ExecuteWorkflow()
        {
            Thread.Sleep(10000);


            try
            {
               // ContainerBuilder builder = new ContainerBuilder();

               // var registrar = new DependencyRegistrar();

               // registrar.Register(builder, null);

               // m_IocContainer = builder.Build();

               // var genericData = new ConcurrentDictionary<string, object>(); 

               // genericData["MyNumber"] = 10;

               // var jsonString = ServiceStack.Text.JsonSerializer.SerializeToString(genericData);

               // var service = m_IocContainer.Resolve<IWorkflowProcessService>();

               // Thread.Sleep(15000);
               // // create workflow and start
               //// var dto = service.CreateAndStartWorkflowInstance(Guid.Parse("0307e776-0070-11e4-9f54-dfffa1f5fab4"), 1, jsonString, Guid.NewGuid(), new List<UserAccountOrganisationDTO>());
               // var dto = service.CreateAndStartWorkflowInstance(Guid.Parse("6c38886c-44b9-11e4-9646-43268a25b72c"), 1, new WorkflowDictionaryDTO { WorkflowDictionary = genericData }, Guid.NewGuid(), new List<UserAccountOrganisationDTO>());
               //// var dto = service.CreateAndStartWorkflowInstance(Guid.Parse("9b25fdb3-6696-43e9-bae3-1e06383f478b"), 1, jsonString, Guid.NewGuid(), new List<UserAccountOrganisationDTO>());

               // // restart
                //var restartDto = service.RestartWorkflowInstance(dto.InstanceDTO.WorkflowInstanceID, dto.InstanceDTO.ParentID);

            }
            catch (System.Exception ex)
            {
                Serilog.Log.Logger.Error(ex, ex.Message, null);
                Console.WriteLine("ExecuteWorkflow Registration:" + ex.Message);

            }
          
           // var container = engine.CreateNewWorkflowFromTemplate(Guid.Parse("2bcfca97-7ea9-4335-abf3-f15677953e87"), 1, genericData, Guid.NewGuid());


           //// var container = engine.CreateNewWorkflowInstanceContainerNotStarted(Guid.Parse("a79dd3ca-365d-401a-b553-e9606b7c347b"), 1, Guid.Empty, genericData);
           // string s = "";

            //using (
            //    var scope = new UnitOfWorkScope<TargetFrameworEntities>(UnitOfWorkScopePurpose.Writing, null,
            //        false))
            //{
            //    scope.DbContext.Workflows.ToList().ForEach(item =>
            //    {
            //        var container = WorkflowProvider.CreateNewWorkflowInstanceContainerNotStarted(new NLogLogger(),
            //            item.WorkflowID, item.VersionNumber, Guid.NewGuid(), genericData);
            //    });
            //}



            //var wfScheduler = WorkflowStartup.ResolveType<WorkflowTaskScheduler>();

            //Action<Guid> workflowCreate = (Guid workflowInstanceID) =>
            //{
            //    var engine = WorkflowStartup.ResolveType<WorkflowEngine>();
            //    var container = engine.LoadWorkflowInstanceContainerNotStarted(workflowInstanceID);

            //    var instanceGuid = container.WorkflowInstance.ID;

            //    Console.WriteLine("Instance Session:" + container.WorkflowInstance.InstanceSession.SessionStartedOn);

            //    //// start
            //};

            ////// do synchronous

            //var start = DateTime.Now;
            //using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing))
            //{
            //    var list = scope.DbContext.WorkflowInstances.ToList();
            //}
            //var end = DateTime.Now;

            //Console.WriteLine("Synchronous Takes:" + end.Subtract(start).Milliseconds);


            //start = DateTime.Now;


            //NameValueCollection col = new NameValueCollection();
            //using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing))
            //{
            //    scope.DbContext.WorkflowInstances.AsNoTracking().ToList().ForEach(item =>
            //    {
            //        int taskId = wfScheduler.AddTaskToQueueAndExecute<Guid>(workflowCreate, item.WorkflowInstanceID);

            //        col.Add(item.WorkflowInstanceID.ToString(), taskId.ToString());
            //    });
            //}

            //while (wfScheduler.GetCurrentExecutingQueuedTasks() > 0)
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("Queued Tasks:" + wfScheduler.GetCurrentExecutingQueuedTasks());
            //}

            //end = DateTime.Now;
            //Console.WriteLine("TPL Takes:" + end.Subtract(start).Milliseconds);

            //foreach (string s in col.AllKeys)
            //    Console.WriteLine(col[s]);




            //----------------------------------- Start

           // var container = engine.LoadWorkflowInstanceContainerNotStarted(Guid.Parse("0a7bb966-2901-4eca-bf33-9429ed4413cf"));

           // container.InitialiseContainer(genericData);

          //  var transistion = container.Transistions.First();

          //  container.WorkflowProcessHandler.StartWorkflow();

            // -----------------------------

            ////IWorkflowContainer container2 = provider.Load(Guid.Parse("C81F5E83-6502-4748-AEA7-9107E34FA239"), 1);

            ////container.InitialiseContainerFromInstance()

            ////provider.CreateWorkflowFromTemplate(Guid.Parse("F1A00AB7-1710-4477-B4C8-4CC38FAB2792"), 1);

            //////m_WorkflowComponentQueue.Clear();

            ////if (container.Transistions.Count > 0)
            ////{
            ////    var genericData = new ConcurrentDictionary<string, object>();

            ////    genericData["MyNumber"] = 10;

            ////    // A -> D -> A
            ////    container.InitialiseContainer(genericData);

            ////    var transistion = container.Transistions.First();

            ////    transistion.Initialise(container,genericData);

            ////    // set process handler
            ////    container.WorkflowProcessHandler.SetCurrentTransistion(transistion.ID);

            ////    container.WorkflowProcessHandler.StartTransistionWorkflow();


            ////}



            ////var transistion = container.Transistions.First();

            ////transistion.Initialise(container,genericData);

            ////// set process handler
            ////processHandler.SetCurrentTransistion(transistion.ID);

            ////if (!processHandler.HasTransistionWorkflowCompleted())
            ////{
            ////    processHandler.RestartTransistionWorkflow();
            ////}

            ////}

            //// find start component in hierarchy
            ////var startHierarchyComponent = transistion.TransistionHierarchy.Single(it => it.IsStart && it.ParentComponent == null);

            ////// need to save workflow execution history

            ////// must be an action
            ////var action = startHierarchyComponent.ChildComponent as IWorkflowAction;

            ////// create GenericData and add a number


            ////// execute first action
            ////if (action.PerformExecutions(genericData))
            ////{
            ////    var nextaction = ProceedToNextWorkflowComponent(transistion,action, genericData, null);

            ////    if(nextaction is IWorkflowAction)
            ////    {

            ////    }

            ////    IDictionary<string, object> data = null;

            ////    while(m_WorkflowComponentQueue.Count > 0)
            ////    {
            ////        // dequeue item and process branch
            ////        var component = m_WorkflowComponentQueue.Dequeue();

            ////        // determine if still waiting for other impacting branch to take place
            ////        if (DoWeNeedToWaitForComponent(transistion,component))
            ////        {
            ////            Console.WriteLine("Component " + component.Name + " is paused as needs to wait for other to complete");

            ////            if(!m_WorkflowComponentQueue.Any(it => it.ID.Equals(component.ID)))
            ////                m_WorkflowComponentQueue.Enqueue(component);
            ////        }
            ////        else
            ////        {
            ////            // if any items match this on the queue then dequeue
            ////            m_WorkflowComponentQueue.Where(it => it.ID.Equals(component.ID)).ToList().ForEach(item => m_WorkflowComponentQueue.Dequeue());

            ////            ProcessNextWorkflowComponent(transistion,null, component.Data, component);
            ////        }
            ////    }
            ////}

        }

        //private bool DoWeNeedToWaitForComponent(IWorkflowTransistionComponent transistion, IWorkflowComponent component)
        //{
        //    List<IWorkflowComponent> components = new List<IWorkflowComponent>();

        //    transistion.TransistionComponents.OfType<IWorkflowDecision>().ToList().ForEach(it =>
        //    {
        //        if (it.SuccessComponents.Any(sc => sc.ID.Equals(component.ID))
        //            || it.FailureComponents.Any(sc => sc.ID.Equals(component.ID)))
        //        {
        //            // filter out items component is parent of
        //            if (!transistion.TransistionHierarchy.Any(hc => hc.ChildComponent.ID.Equals(it.ID)
        //                && hc.ParentComponent.ID.Equals(component.ID)))
        //            components.Add(it);
        //        }
        //    });

        //    // check for previous actions that are needed ti cimplete this action

        //    transistion.TransistionHierarchy.ToList().ForEach(it =>
        //    {
        //        if (it.ParentComponent != null && it.ChildComponent != null && it.ChildComponent.ID.Equals(component.ID))
        //            components.Add(it.ParentComponent);
        //    });

        //    // now check whether all these items have executed
        //    bool doWeWait = false;

        //    components.ForEach(it =>
        //    {
        //            if (!transistion.TransistionHistory.Any(si => si.WorkflowComponentID.Equals(it.ID)))
        //            {
                        
        //                if(!doWeWait)
        //                doWeWait = true;
        //            }

        //    });

        //    return doWeWait;
        //}
        //private IDictionary<string, object> ProcessAction(IWorkflowTransistionComponent transistion,IWorkflowAction action,IDictionary<string, object> data)
        //{
        //    transistion.TransistionHistory.Add( new WorkflowTransistionHistoryBase{CreatedOn = DateTime.Now,TransistionID = transistion.ID,WorkflowComponentID = action.ID});
 
        //    if (action.CanExecute())
        //        action.PerformExecutions(data);

        //    // update data
        //    return action.Data;
        //}

        //private IList<IWorkflowComponent> ProcessDecision(IWorkflowTransistionComponent transistion, IWorkflowDecision decision, IDictionary<string, object> data)
        //{
        //    transistion.TransistionHistory.Add(new WorkflowTransistionHistoryBase { CreatedOn = DateTime.Now, TransistionID = transistion.ID, WorkflowComponentID = decision.ID });
        //    return decision.MakeDecision(data);
        //}

        //private IWorkflowComponent ProceedToNextWorkflowComponent(IWorkflowTransistionComponent transistion, IWorkflowComponent parent, IDictionary<string, object> data,IWorkflowComponent child)
        //{
        //    IWorkflowComponent nextAction = null;

        //    // determine next steps, could be parallel
        //    IList<IWorkflowHierarchyComponent> childComponents = null;

        //    if (child == null)
        //        childComponents =
        //            transistion.TransistionHierarchy.Where(
        //                it => it.ParentComponent != null && it.ParentComponent.ID.Equals(parent.ID)).ToList();
        //    else
        //        childComponents = new List<IWorkflowHierarchyComponent>() {new WorkflowHierarchyComponentBase{ChildComponent = child}};

        //    // iterate components and process as needed
        //    childComponents.ToList().ForEach(it =>
        //    {
        //        if (it.ChildComponent is IWorkflowAction)
        //        {
        //            if (DoWeNeedToWaitForComponent(transistion,it.ChildComponent))
        //            {
        //                Console.WriteLine("Component " + it.ChildComponent.Name +
        //                                  " is paused as needs to wait for others to complete");

        //                if (!m_WorkflowComponentQueue.Any(ip => ip.ID.Equals(it.ChildComponent.ID)))
        //                    m_WorkflowComponentQueue.Enqueue(it.ChildComponent);
        //            }
        //            else
        //            {
        //                m_WorkflowComponentQueue.Where(ip => ip.ID.Equals(it.ChildComponent.ID)).ToList().ForEach(item => m_WorkflowComponentQueue.Dequeue());

        //                nextAction = it.ChildComponent as IWorkflowAction;
        //                nextAction.Data = data;
        //                //data = ProcessAction(transistion,it.ChildComponent as IWorkflowAction,data);
        //                //ProcessNextWorkflowComponent(transistion, it.ChildComponent, data, null);
        //            }
        //        }
        //        else if (it.ChildComponent is IWorkflowDecision)
        //        {
        //            ProcessDecision(transistion, it.ChildComponent as IWorkflowDecision, data)
        //                .ToList().ForEach(i => m_WorkflowComponentQueue.Enqueue(i));
        //        }
        //    });
        //    return nextAction;

        //}

       
    }
}
