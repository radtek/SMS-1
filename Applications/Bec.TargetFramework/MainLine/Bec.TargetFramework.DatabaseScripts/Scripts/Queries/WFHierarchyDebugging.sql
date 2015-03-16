select
COALESCE(act1."WorkflowActionTemplateID",act111."WorkflowDecisionTemplateID") as "ParentID",
COALESCE(act1."Name",act111."Name") as "Parent",
COALESCE(act."WorkflowActionTemplateID",act11."WorkflowDecisionTemplateID") as "ChildID",
COALESCE(act."Name",act11."Name") as "Child",

 act."Name" ,
  act1."Name" ,
   act11."Name" ,
    act111."Name" ,*


 from "WorkflowHierarchyTemplate" wht

left outer join "WorkflowActionTemplate" act on act."WorkflowActionTemplateID" = wht."ChildComponentID"
left outer join "WorkflowActionTemplate" act1 on act1."WorkflowActionTemplateID" = wht."ParentComponentID"
left outer join "WorkflowDecisionTemplate" act11 on act11."WorkflowDecisionTemplateID" = wht."ChildComponentID"
left outer join "WorkflowDecisionTemplate" act111 on act111."WorkflowDecisionTemplateID" = wht."ParentComponentID"

where COALESCE(act."Name",act11."Name") is null