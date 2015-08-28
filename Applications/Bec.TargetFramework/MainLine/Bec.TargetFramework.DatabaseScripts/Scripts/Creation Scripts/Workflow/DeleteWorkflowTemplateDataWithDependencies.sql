/*Script to delete all the WorkflowInstance related t*/

DO $$
BEGIN
DELETE FROM "WorkflowInstanceExecutionDataItem";
DELETE FROM "WorkflowInstanceExecutionStatusEvent";
DELETE FROM "WorkflowInstanceExecutionTrace";
DELETE FROM "WorkflowInstanceExecution";
DELETE FROM "WorkflowInstanceSession";
DELETE FROM "WorkflowInstance";
END $$;

/*Script to delete all the Workflow related template data and also the dependency data.
This might not delete data in WorkflowTemplate and Workflow as the Instance related data might be referrenced to Workflow table.
Comment the last 2 lines if instance has been created*/

DO $$
Declare
WorkflowTemplateID UUID;
WorkflowTemplateVersionNumber integer;
WorkflowID UUID;
WorkflowVersionNumber integer;

BEGIN
WorkflowTemplateID := '08796e7c-2ea9-408e-9b25-291d68e2beab';
WorkflowTemplateVersionNumber := 1;
WorkflowID := 'ac31097e-44b6-11e4-98de-af854757c9ad';
WorkflowVersionNumber := 1;

	delete from "WorkflowTreeStructureAction" wtsat
	where wtsat."WorkflowTreeStructureID" in (select "WorkflowTreeStructureID" from "WorkflowTreeStructure"  where
	"WorkflowID" = WorkflowID and "WorkflowVersionNumber" = WorkflowVersionNumber);

    delete from public."WorkflowTreeStructure" wf where wf."WorkflowID" = WorkflowID and wf."WorkflowVersionNumber" = WorkflowVersionNumber;

    delete from public."WorkflowTransistionWorkflowDecision" wf where wf."WorkflowID" = WorkflowID and wf."WorkflowVersionNumber" = WorkflowVersionNumber;

    delete from public."WorkflowTransistionWorkflowAction" wf where wf."WorkflowID" = WorkflowID and wf."WorkflowVersionNumber" = WorkflowVersionNumber;

	delete from public."WorkflowTransistionHierarchy" wf where wf."WorkflowID" = WorkflowID and wf."WorkflowVersionNumber" = WorkflowVersionNumber;

   delete from public."WorkflowHierarchy" wf where wf."WorkflowID" = WorkflowID and wf."WorkflowVersionNumber" = WorkflowVersionNumber;

   delete from public."WorkflowTransistion" wf where wf."WorkflowID" = WorkflowID and wf."WorkflowVersionNumber" = WorkflowVersionNumber;

   delete from public."WorkflowActionParameter" wf where wf."WorkflowID" = WorkflowID and wf."WorkflowVersionNumber" = WorkflowVersionNumber;

   delete from public."WorkflowDecisionParameter" wf where wf."WorkflowID" = WorkflowID and wf."WorkflowVersionNumber" = WorkflowVersionNumber;

   delete from public."WorkflowMainParameter" wf where wf."WorkflowID" = WorkflowID and wf."WorkflowVersionNumber" = WorkflowVersionNumber;

   delete from public."WorkflowParameter" wf where wf."WorkflowID" = WorkflowID and wf."WorkflowVersionNumber" = WorkflowVersionNumber;

   delete from public."WorkflowClaim" wf where wf."WorkflowID" = WorkflowID and wf."WorkflowVersionNumber" = WorkflowVersionNumber;

    delete from public."WorkflowDecisionSuccess" wf where wf."WorkflowID" = WorkflowID and wf."WorkflowVersionNumber" = WorkflowVersionNumber;

    delete from public."WorkflowDecisionFailure" wf where wf."WorkflowID" = WorkflowID and wf."WorkflowVersionNumber" = WorkflowVersionNumber;

    delete from public."WorkflowDecision" wf where wf."WorkflowID" = WorkflowID and wf."WorkflowVersionNumber" = WorkflowVersionNumber;

    delete from public."WorkflowAction" wf where wf."WorkflowID" = WorkflowID and wf."WorkflowVersionNumber" = WorkflowVersionNumber;

    delete from public."WorkflowObjectType" wf where wf."WorkflowID" = WorkflowID and wf."WorkflowVersionNumber" = WorkflowVersionNumber;

	delete from public."Workflow" wf where wf."WorkflowID" = WorkflowID and wf."WorkflowVersionNumber" = WorkflowVersionNumber;


	-- clearing template tables
	delete from "WorkflowTreeStructureActionTemplate" wtsat
	where wtsat."WorkflowTreeStructureTemplateID" in (select "WorkflowTreeStructureTemplateID" from "WorkflowTreeStructureTemplate"  where
	"WorkflowTemplateID" = WorkflowTemplateID and "WorkflowTemplateVersionNumber" = WorkflowTemplateVersionNumber);

     delete from public."WorkflowTreeStructureTemplate" wf where wf."WorkflowTemplateID" = WorkflowTemplateID and wf."WorkflowTemplateVersionNumber" = WorkflowTemplateVersionNumber;

    delete from public."WorkflowTransistionWorkflowDecisionTemplate" wf where wf."WorkflowTemplateID" = WorkflowTemplateID and wf."WorkflowTemplateVersionNumber" = WorkflowTemplateVersionNumber;

    delete from public."WorkflowTransistionWorkflowActionTemplate" wf where wf."WorkflowTemplateID" = WorkflowTemplateID and wf."WorkflowTemplateVersionNumber" = WorkflowTemplateVersionNumber;

    delete from public."WorkflowTransistionHierarchyTemplate" wf where wf."WorkflowTemplateID" = WorkflowTemplateID and wf."WorkflowTemplateVersionNumber" = WorkflowTemplateVersionNumber;

    delete from public."WorkflowHierarchyTemplate" wf where wf."WorkflowTemplateID" = WorkflowTemplateID and wf."WorkflowTemplateVersionNumber" = WorkflowTemplateVersionNumber;

    delete from public."WorkflowTransistionTemplate" wf where wf."WorkflowTemplateID" = WorkflowTemplateID and wf."WorkflowTemplateVersionNumber" = WorkflowTemplateVersionNumber;

   delete from public."WorkflowActionParameterTemplate" wf where wf."WorkflowTemplateID" = WorkflowTemplateID and wf."WorkflowTemplateVersionNumber" = WorkflowTemplateVersionNumber;

   delete from public."WorkflowDecisionParameterTemplate" wf where wf."WorkflowTemplateID" = WorkflowTemplateID and wf."WorkflowTemplateVersionNumber" = WorkflowTemplateVersionNumber;

   delete from public."WorkflowParameterTemplate" wf where wf."WorkflowTemplateID" = WorkflowTemplateID and wf."WorkflowTemplateVersionNumber" = WorkflowTemplateVersionNumber;

	delete from public."WorkflowClaimTemplate" wf where wf."WorkflowTemplateID" = WorkflowTemplateID and wf."WorkflowTemplateVersionNumber" = WorkflowTemplateVersionNumber;

    delete from public."WorkflowDecisionSuccessTemplate" wf where wf."WorkflowTemplateID" = WorkflowTemplateID and wf."WorkflowTemplateVersionNumber" = WorkflowTemplateVersionNumber;

    delete from public."WorkflowDecisionFailureTemplate" wf where wf."WorkflowTemplateID" = WorkflowTemplateID and wf."WorkflowTemplateVersionNumber" = WorkflowTemplateVersionNumber;

    delete from public."WorkflowDecisionTemplate" wf where wf."WorkflowTemplateID" = WorkflowTemplateID and wf."WorkflowTemplateVersionNumber" = WorkflowTemplateVersionNumber;

    delete from public."WorkflowActionTemplate" wf where wf."WorkflowTemplateID" = WorkflowTemplateID and wf."WorkflowTemplateVersionNumber" = WorkflowTemplateVersionNumber;


    delete from public."WorkflowObjectTypeTemplate" wf where wf."WorkflowTemplateID" = WorkflowTemplateID and wf."WorkflowTemplateVersionNumber" = WorkflowTemplateVersionNumber;

	delete from public."WorkflowTemplate" wf where wf."WorkflowTemplateID" = WorkflowTemplateID and wf."WorkflowTemplateVersionNumber" = WorkflowTemplateVersionNumber;




    END $$;