DELETE FROM public."ClassificationType";
DELETE
FROM public."ClassificationTypeCategory";


-- Account
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (1,'AccountTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (2,'AccountSubTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (3,'AccountCategoryID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (4,'AccountSubCategoryID');

INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Main','',1,true,false);


-- Address
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (10,'AddressTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (11,'AddressCategoryID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (12,'AddressSubTypeID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (4973,'Home','',10,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (4974,'Work','',10,true,false);


-- Artefact
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (30,'ArtefactTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (31,'ArtefactSubTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (32,'ArtefactCategoryID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (33,'ArtefactSubCategoryID');

INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Base','',30,true,false);

INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Module Related','',30,true,false);


-- Attachment
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (40,'AttachmentTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (41,'AttachmentSubTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (42,'AttachmentCategoryID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (43,'AttachmentSubCategoryID');

INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Attachment','',40,true,false);


-- Bucket
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (50,'BucketTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (51,'BucketSubTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (52,'BucketCategoryID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (53,'BucketSubCategoryID');



-- Deduction
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (70,'DeductionTypeID');


INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Sales Tax','Value Added Tax',70,true,false);

INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Card Processing Fee','Card Processing Fee',70,true,false);

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (71,'DeductionSubTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (72,'DeductionCategoryID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (73,'DeductionSubCategoryID');


-- InterfacePanel
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (90,'InterfacePanelTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (91,'InterfacePanelSubTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (92,'InterfacePanelCategoryID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (93,'InterfacePanelSubCategoryID');







-- SpecificationAttribute
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (140,'SpecificationAttributeTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (141,'SpecificationAttributeSubTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (142,'SpecificationAttributeCategoryID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (143,'SpecificationAttributeSubCategoryID');
-- State
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (150,'StateType');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (151,'StateSubTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (152,'StateCategoryID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (153,'StateSubCategoryID');

INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Global','',150,true,false);

INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Default Organisation','',150,true,false);

  INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('CenterTopMenu','',150,true,false);

-- Workflow
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (160,'WorkflowTypeID');

INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Startup','',160,true,false);

INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Non-Startup','',160,true,false);


INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (161,'WorkflowSubTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (162,'WorkflowCategoryID');
INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('UserSpecific','',162,true,false);

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (163,'WorkflowSubCategoryID');

INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Global','',160,true,false);

INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Default Organisation','',160,true,false);

-- Mime Type
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (1000,'MimeTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (1001,'TaxCategoryID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (1002,'CountryTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (1003,'AccountClassificationTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (1004,'CustomerTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (1005,'BusinessTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (1006,'IndustryTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (1007,'GenderTypeID');


INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (3769, E'Male', E'Male', 1007, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (3770, E'Female', E'Female', 1007, NULL, True, False);


INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (1008,'EducationTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (1009,'TransactionTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (1010,'OrganisationRelationshipRoleTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (1011,'ProductRelationshipTypeID');

INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Default','',1011,true,false);




INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (1012,'OrganisationUnitTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (1013,'AttributeValueTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (1014,'SpecificationAttributeTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (1015,'TransactionLevelComponentSubTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (1016,'FieldTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (1017,'StatusTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (1018,'TeamTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (1019,'TeamSubTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (1020,'UserJobTypeID');



--WorflowInstanceStatusID
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (2049,'WorkflowInstanceStatusID');

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (2628, E'New', E'New', 2049, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (2629, E'InProgress', E'In Progress', 2049, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (2630, E'Complete', E'Complete', 2049, True, False);




---salutationType ---
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (8502,'SalutationTypeID');


  INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Mr','',8502,true,false);

   INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Mrs','',8502,true,false);


   INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Miss','',8502,true,false);


   INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Dr','',8502,true,false);


   INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Rev','',8502,true,false);


   INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Prof.','',8502,true,false);

  ---Regulator  ---
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (8503,'RegulatorID');


  INSERT INTO
  public."ClassificationType"("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (5016, 'SRA','',8503,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (5017, 'CLC','',8503,true,false);


   INSERT INTO
  public."ClassificationType"("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (5018, 'CILEx','',8503,true,false);






  INSERT INTO public."ClassificationTypeCategory" ("ClassificationTypeCategoryID", "Name", "IsActive", "IsDeleted")
VALUES (2052, E'SecurityQuestions', True, False);

INSERT INTO public."ClassificationType" ( "Name", "Description", "ClassificationTypeCategoryID","IsActive", "IsDeleted")
VALUES ( E'What is your favourite animal?', NULL, 2052, True, False);

INSERT INTO public."ClassificationType" ("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (E'In what city did you meet your spouse / significant other?', NULL, 2052, True, False);

INSERT INTO public."ClassificationType" ("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (E'What was your first school called?', NULL, 2052, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (801741, E'What is your favourite book?', NULL, 2052, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (801742, E'What is the name of your favourite childhood teacher?', NULL, 2052, NULL, True, False);



INSERT INTO public."ClassificationTypeCategory" ("ClassificationTypeCategoryID", "Name", "IsActive", "IsDeleted")
VALUES (2077, E'SecurityQuestions2', True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (801739, E'What was the name of your favourite childhood toy?', NULL, 2077, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (801744, E'What was your favourite place to visit as a child?', NULL, 2077, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (801745, E'Who was your childhood hero?', NULL, 2077, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (801746, E'What is your memorable place?', NULL, 2077, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (801747, E'What was the first concert you attended?', NULL, 2077, NULL, True, False);


INSERT INTO public."ClassificationTypeCategory" ("ClassificationTypeCategoryID", "Name", "IsActive", "IsDeleted")
VALUES (2055, E'PhoneTypeID', True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (3762, E'Home', E'Home', 2055, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (3761, E'Work', E'Work', 2055, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (3760, E'Mobile', E'Mobile', 2055, NULL, True, False);

INSERT INTO public."ClassificationTypeCategory" ("ClassificationTypeCategoryID", "Name", "IsActive", "IsDeleted")
VALUES (2056, E'BankAccountOpenedTypeID', True, False);


INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (3765, E'More than 5 years', E'More than 5 years', 2056, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (3764, E'Less than 5 years', E'Less than 5 years', 2056, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (3763, E'Less than 2 years', E'Less than 2 years', 2056, NULL, True, False);

INSERT INTO public."ClassificationTypeCategory" ("ClassificationTypeCategoryID", "Name", "IsActive", "IsDeleted")
VALUES (2057, E'PreferredContactTypeID', True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (3766, E'Email', E'Email', 2057, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (3767, E'Phone', E'Phone', 2057, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (3768, E'Post', E'Post', 2057, NULL, True, False);

INSERT INTO public."ClassificationTypeCategory" ("ClassificationTypeCategoryID", "Name", "IsActive", "IsDeleted")
VALUES (2058, E'InsuranceTypeID', True, False);

INSERT INTO public."ClassificationTypeCategory" ("ClassificationTypeCategoryID", "Name", "IsActive", "IsDeleted")
VALUES (2059, E'InviteTypeID', True, False);

INSERT INTO public."ClassificationTypeCategory" ("ClassificationTypeCategoryID", "Name", "IsActive", "IsDeleted")
VALUES (2060, E'InviteStatusTypeID', True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (3771, E'Search', E'Search', 2059, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (3772, E'Registration', E'Registration', 2059, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (3773, E'Preapproved', E'Preapproved', 2059, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (3774, E'Reassign', E'Reassign', 2059, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (3775, E'Accept', E'Accept', 2060, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (3776, E'Reject', E'Reject', 2060, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (3777, E'Reassign', E'Reassign', 2060, NULL, True, False);

INSERT INTO public."ClassificationTypeCategory" ("ClassificationTypeCategoryID", "Name", "IsActive", "IsDeleted")
VALUES (2061, E'InviteRejectReasonTypeID', True, False);


INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (3778, E'The address is wrong', NULL, 2061, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (3779, E'Incorrect law firm', NULL, 2061, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (3780, E'Another user at law firm', NULL, 2061, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (3781, E'Wrong branch of law firm', NULL, 2061, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (3783, E'Not out client', NULL, 2061, NULL, True, False);

INSERT INTO public."ClassificationTypeCategory" ("ClassificationTypeCategoryID", "Name", "IsActive", "IsDeleted")
VALUES (2062, E'TermsAndConditionsTypeID', True, False);

----FieldType-----
INSERT INTO public."ClassificationTypeCategory" ("ClassificationTypeCategoryID", "Name", "IsActive", "IsDeleted")
VALUES (1700, E'FieldTypeID', True, False);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (1701,'Label','',1700,true,false);


INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (1702,'TextBox','',1700,true,false);


INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (1703,'CheckBox','',1700,true,false);


INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (1704,'RadioGroup','',1700,true,false);


  INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (1705,'ComboBox','',1700,true,false);

 INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (1706,'LinkButton','',1700,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (1707,'Hyperlink','',1700,true,false);

     INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (1708,'ImageButton','',1700,true,false);

  ---IconAlignmentTypeID----
INSERT INTO public."ClassificationTypeCategory" ("ClassificationTypeCategoryID", "Name", "IsActive", "IsDeleted")
VALUES (180, E'IconAlignmentTypeID', True, False);


  INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (1801,'Left','',180,true,false);

    INSERT INTO  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (1802,'Right','',180,true,false);


    ---ValidationTypeID----
INSERT INTO public."ClassificationTypeCategory" ("ClassificationTypeCategoryID", "Name", "IsActive", "IsDeleted")
VALUES (190, E'ValidationTypeID', True, False);


  INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (1901,'RequiredFieldValidation','',190,true,false);


  ---Branch/user rejection reason
INSERT INTO public."ClassificationTypeCategory" ("ClassificationTypeCategoryID", "Name", "IsActive", "IsDeleted")
VALUES (200, E'BranchRejectionReason', True, False);

INSERT INTO public."ClassificationTypeCategory" ("ClassificationTypeCategoryID", "Name", "IsActive", "IsDeleted")
VALUES (210, E'UserRejectionReason', False, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (201, E'Not a branch at this firm', E'Not a branch at this firm', 200, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (202, E'Other', E'Other', 200, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (211, E'Not Known at this firm', E'Not Known at this firm', 210, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (212, E'Left Company', E'Left Company', 210, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (213, E'Non Conveyancing Role', E'Non Conveyancing Role', 210, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (214, E'Other', E'Other', 210, NULL, True, False);


INSERT INTO public."ClassificationTypeCategory" ("ClassificationTypeCategoryID", "Name", "IsActive", "IsDeleted")
VALUES (5000004, E'NumberOfYears', True, False);

INSERT INTO public."ClassificationTypeCategory" ("ClassificationTypeCategoryID", "Name", "IsActive", "IsDeleted")
VALUES (5000005, E'NumberOfMonths', True, False);

/* Data for the 'public.ClassificationType' table  (Records 1 - 7) */

INSERT INTO public."ClassificationType" ( "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES ( E'0 year', E'0', 5000004, NULL, True, False);

INSERT INTO public."ClassificationType" ( "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES ( E'1 year', E'1', 5000004, NULL, True, False);

INSERT INTO public."ClassificationType" ( "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES ( E'2 years', E'2', 5000004, NULL, True, False);

INSERT INTO public."ClassificationType" ("Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES ( E'3 or more years', E'3', 5000004, NULL, True, False);

INSERT INTO public."ClassificationType" ( "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES ( E'0 month', E'0', 5000005, NULL, True, False);

INSERT INTO public."ClassificationType" ( "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES ( E'1 month', E'1', 5000005, NULL, True, False);

INSERT INTO public."ClassificationType" ("Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES ( E'2 months', E'2', 5000005, NULL, True, False);

INSERT INTO public."ClassificationType" ( "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES ( E'3 months', E'3', 5000005, NULL, True, False);

INSERT INTO public."ClassificationType" ( "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES ( E'4 months', E'4', 5000005, NULL, True, False);

INSERT INTO public."ClassificationType" ( "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES ( E'5 months', E'5', 5000005, NULL, True, False);

INSERT INTO public."ClassificationType" ( "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES ( E'6 months', E'6', 5000005, NULL, True, False);

INSERT INTO public."ClassificationType" ( "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES ( E'7 months', E'7', 5000005, NULL, True, False);

INSERT INTO public."ClassificationType" ( "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES ( E'8 months', E'8', 5000005, NULL, True, False);

INSERT INTO public."ClassificationType" ( "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES ( E'9 months', E'9', 5000005, NULL, True, False);

INSERT INTO public."ClassificationType" ( "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES ( E'10 months', E'10', 5000005, NULL, True, False);

INSERT INTO public."ClassificationType" ( "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (E'11 months', E'11', 5000005, NULL, True, False);

---Branch Regulator

INSERT INTO public."ClassificationTypeCategory" ("ClassificationTypeCategoryID", "Name", "IsActive", "IsDeleted")
VALUES (2078, E'BranchRegulatorID', True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (801748, E'SRA', NULL, 2078, NULL, True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (801749, E'CLC', NULL, 2078, NULL, True, False);


