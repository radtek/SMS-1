--Select * from public.uuid_generate_v1();

-- delete scripts for FrontEnd

DELETE FROM public."InterfacePanelValidation" ;

DELETE FROM  public."InterfacePanelFieldDetailValidation" ;

DELETE FROM   public."InterfacePanelFieldDetail" ;

DELETE FROM public."InterfacePanel" ;

DELETE FROM public."InterfacePanelClaim" ;

DELETE FROM public."InterfacePanelFDOrganisationTypeUserType" ;

DELETE FROM   public."InterfacePanelFDValidationOrganisationTypeUserType" ;

DELETE FROM public."InterfacePanelFieldDetailOrganisationType";

DELETE FROM  public."InterfacePanelFieldDetailValidationOrganisationType" ;

DELETE FROM  public."InterfacePanelOrganisationType" ;

DELETE FROM public."InterfacePanelOrganisationTypeUserType" ;

DELETE FROM  public."InterfacePanelRole" ;

DELETE FROM  public."InterfacePanelSetting" ;

DELETE FROM   public."InterfacePanelValidationOrganisationType" ;

DELETE FROM public."InterfacePanelValidationOrganisationTypeUserType" ;

Delete from "FieldDetail";

--Delete from "InterfacePanelFieldDetailTemplate";

--Delete from "InterfacePanelFieldDetailValidationTemplate";

--Delete from "InterfacePanelValidationTemplate";

--Delete from "InterfacePanelTemplate";

--Delete from "FieldDetailTemplate";

--promote scripts for FrontEnd


--Parent IP
perform public."fn_PromoteInterfacePanelTemplate" ('04401532-2488-11e4-817a-d7c07e984cd7',1);
perform public."fn_PromoteInterfacePanelTemplate" ('29c9159e-2391-11e4-953b-874efbbdf816',1);
perform public."fn_PromoteInterfacePanelTemplate" ('3288ba52-2488-11e4-b670-fb3a5a55fe0f',1);
perform public."fn_PromoteInterfacePanelTemplate" ('3e9c3fae-26b2-11e4-9a24-b32951fa39f8',1);
perform public."fn_PromoteInterfacePanelTemplate" ('5cc14b72-2393-11e4-8e99-1773c703c71a',1);
perform public."fn_PromoteInterfacePanelTemplate" ('759a0024-2237-11e4-b86b-db81260b98c5',1);
perform public."fn_PromoteInterfacePanelTemplate" ('7f6b9150-2235-11e4-87a7-674ef85109a7',1);
perform public."fn_PromoteInterfacePanelTemplate" ('8fc171da-23d1-11e4-80f8-d30fc8c965a8',1);
perform public."fn_PromoteInterfacePanelTemplate" ('9fdcece8-2232-11e4-bf45-ab038058bfc9',1);
perform public."fn_PromoteInterfacePanelTemplate" ('a1637288-2392-11e4-a556-cb3839eec9ed',1);
perform public."fn_PromoteInterfacePanelTemplate" ('a2d81918-2232-11e4-b774-3b0341b43a3e',1);
perform public."fn_PromoteInterfacePanelTemplate" ('a6298fd6-23b1-11e4-862d-3f42f647fe18',1);
perform public."fn_PromoteInterfacePanelTemplate" ('a76467f8-2236-11e4-a090-2b2b425d524b',1);
perform public."fn_PromoteInterfacePanelTemplate" ('a81fa4f4-2390-11e4-b07e-2300506dc125',1);
perform public."fn_PromoteInterfacePanelTemplate" ('bb6db744-2232-11e4-b842-773e72f7c1eb',1);
perform public."fn_PromoteInterfacePanelTemplate" ('cedd61ae-2236-11e4-b7d7-73e6f5407cab',1);
perform public."fn_PromoteInterfacePanelTemplate" ('d4a49390-2232-11e4-9add-2f7a2a2ee654',1);
perform public."fn_PromoteInterfacePanelTemplate" ('e3b38f24-248c-11e4-a7ed-dbf7306b6c1d',1);
perform public."fn_PromoteInterfacePanelTemplate" ('0a0ad3b2-3450-11e4-8983-b327ad169744',1);
perform public."fn_PromoteInterfacePanelTemplate" ('98b2d736-3a59-11e4-af52-3345c5dc7cc3',1);
perform public."fn_PromoteInterfacePanelTemplate" ('b82e3666-3a5c-11e4-845c-0fa0fcd6ea34',1);
perform public."fn_PromoteInterfacePanelTemplate" ('b0a98160-47b9-11e4-b69c-33bda23a3ae7',1);



--Child IP
perform public."fn_PromoteInterfacePanelTemplate" ('02d28498-2391-11e4-a59c-67464c577986',1);
perform public."fn_PromoteInterfacePanelTemplate" ('06c1cfaa-238c-11e4-8ed2-37d9c23496d6',1);
perform public."fn_PromoteInterfacePanelTemplate" ('1835a336-2393-11e4-baba-93eb4d1c6be6',1);
perform public."fn_PromoteInterfacePanelTemplate" ('3ae9bf2a-2488-11e4-8ee1-2f469d9c920f',1);
perform public."fn_PromoteInterfacePanelTemplate" ('420a5d74-238d-11e4-8817-7382b99f1aad',1);
perform public."fn_PromoteInterfacePanelTemplate" ('4546da8e-2488-11e4-a1d7-7fd56ca787b9',1);
perform public."fn_PromoteInterfacePanelTemplate" ('4b760c88-2391-11e4-aec8-9bea036ad5a3',1);
perform public."fn_PromoteInterfacePanelTemplate" ('4ee1a43e-248d-11e4-a34c-63508806289d',1);
perform public."fn_PromoteInterfacePanelTemplate" ('5e3e342a-2392-11e4-ad58-3fab4d0f9210',1);
perform public."fn_PromoteInterfacePanelTemplate" ('6c3e9ede-2392-11e4-af9d-9f3708cb4b3e',1);
perform public."fn_PromoteInterfacePanelTemplate" ('6dc6239c-23b2-11e4-9535-bb262a1a05f5',1);
perform public."fn_PromoteInterfacePanelTemplate" ('6f4478a2-238c-11e4-ad79-5310f044949a',1);
perform public."fn_PromoteInterfacePanelTemplate" ('75aa60a2-238d-11e4-89a0-f77e02c89a47',1);
perform public."fn_PromoteInterfacePanelTemplate" ('82795852-2391-11e4-97a5-53fa218b5318',1);
perform public."fn_PromoteInterfacePanelTemplate" ('8c894ee8-2390-11e4-8d91-9fcf5019eafd',1);
perform public."fn_PromoteInterfacePanelTemplate" ('93cd51ae-2232-11e4-81e3-43c7c96b4bad',1);
perform public."fn_PromoteInterfacePanelTemplate" ('96d3c7d4-2232-11e4-a25c-4be0f8e22925',1);
perform public."fn_PromoteInterfacePanelTemplate" ('99450b5e-2232-11e4-aa4d-7f9f51bc2f7f',1);
perform public."fn_PromoteInterfacePanelTemplate" ('9d0a2d82-2232-11e4-9be4-e392814ea911',1);
perform public."fn_PromoteInterfacePanelTemplate" ('a0a086de-238c-11e4-9c20-b3974ad0a7de',1);
perform public."fn_PromoteInterfacePanelTemplate" ('ab0c73ba-2393-11e4-a2f7-378f82a1476d',1);
perform public."fn_PromoteInterfacePanelTemplate" ('b299a4c0-238b-11e4-bc2c-631e59d9b8c4',1);
perform public."fn_PromoteInterfacePanelTemplate" ('b447bc3a-2390-11e4-8dc1-07b1b34177be',1);
perform public."fn_PromoteInterfacePanelTemplate" ('e9518b1a-2393-11e4-93af-47ec99dc63ef',1);
perform public."fn_PromoteInterfacePanelTemplate" ('f4143372-23b1-11e4-b867-7777db91cbfc',1);
perform public."fn_PromoteInterfacePanelTemplate" ('904495b2-4878-11e4-86b7-7b05b54dee9c',1);
perform public."fn_PromoteInterfacePanelTemplate" ('5d014074-4878-11e4-8a7b-5f664f075a9f',1);
perform public."fn_PromoteInterfacePanelTemplate" ('0201e42c-47f5-11e4-bf56-f7b72de32dfe',1);
perform public."fn_PromoteInterfacePanelTemplate" ('58a83c72-47c3-11e4-b842-a382b0b84eb9',1);
perform public."fn_PromoteInterfacePanelTemplate" ('5a096634-47bb-11e4-9034-9754a544bb20',1);
perform public."fn_PromoteInterfacePanelTemplate" ('9047425c-47bb-11e4-8f34-372708deb2c1',1);
perform public."fn_PromoteInterfacePanelTemplate" ('974067d4-47c3-11e4-a413-878d2332f1d8',1);
perform public."fn_PromoteInterfacePanelTemplate" ('f1ac1c68-47c3-11e4-9cd7-dfbd5144664c',1);
perform public."fn_PromoteInterfacePanelTemplate" ('fe6c1f1a-47ba-11e4-b16b-83185efa7136',1);
perform public."fn_PromoteInterfacePanelTemplate" ('2e5f1204-223b-11e4-b7f6-0fd1c38100bb',1);
perform public."fn_PromoteInterfacePanelTemplate" ('9f13d6bc-2239-11e4-9a33-0f7c434da157',1);
perform public."fn_PromoteInterfacePanelTemplate" ('ee6f7b7e-48bf-11e4-b935-cb43a2845fba',1);
perform public."fn_PromoteInterfacePanelTemplate" ('3274e0f2-48c0-11e4-ba88-a3a20b7ea166',1);
