using Bec.TargetFramework.Infrastructure.Extensions;

namespace Bec.TargetFramework.Entities.Enums
{
    public enum AccountTypeIDEnum : int
    {
        [StringValue("Main")]
        Main = 4972
    }
    public enum AddressTypeIDEnum : int
    {
        [StringValue("Home")]
        Home = 4973,
        [StringValue("Work")]
        Work = 4974
    }
    public enum ArtefactTypeIDEnum : int
    {
        [StringValue("Base")]
        Base = 4975,
        [StringValue("Module Related")]
        Module_Related = 4976
    }
    public enum AttachmentTypeIDEnum : int
    {
        [StringValue("Attachment")]
        Attachment = 4977
    }
    public enum ContactTypeIDEnum : int
    {
        [StringValue("Personal")]
        Personal = 4978,
        [StringValue("Company")]
        Company = 4979
    }
    public enum DeductionTypeIDEnum : int
    {
        [StringValue("Sales Tax")]
        Sales_Tax = 4980,
        [StringValue("Card Processing Fee")]
        Card_Processing_Fee = 4981
    }
    public enum GroupTypeIDEnum : int
    {
        [StringValue("Global")]
        Global = 4982,
        [StringValue("Default Organisation")]
        Default_Organisation = 4983
    }
    public enum InterfacePanelTypeIDEnum : int
    {
        [StringValue("Global")]
        Global = 4984,
        [StringValue("Organisation Type")]
        Organisation_Type = 4985,
        [StringValue("User Type")]
        User_Type = 4986
    }
    public enum NotificationConstructTypeIDEnum : int
    {
        [StringValue("Alert")]
        Alert = 4994,
        [StringValue("Task")]
        Task = 4995
    }
    public enum NotificationStatusIDEnum : int
    {
        [StringValue("New")]
        New = 4987,
        [StringValue("Sent")]
        Sent = 4988
    }
    public enum NotificationExportFormatIDEnum : int
    {
        [StringValue("HTML")]
        HTML = 4989,
        [StringValue("HTML5")]
        HTML5 = 4990,
        [StringValue("PDF")]
        PDF = 4991
    }
    public enum NotificationDeliveryMethodIDEnum : int
    {
        [StringValue("Email")]
        Email = 4992,
        [StringValue("System")]
        System = 4993
    }
    public enum ResourceTypeIDEnum : int
    {
        [StringValue("OrganisationID")]
        OrganisationID = 4996,
        [StringValue("Security")]
        Security = 4997,
        [StringValue("Module")]
        Module = 4998,
        [StringValue("Organisation")]
        Organisation = 120,
        [StringValue("Workflow")]
        Workflow = 122,
        [StringValue("Notification")]
        Notification = 123
    }
    public enum RoleTypeIDEnum : int
    {
        [StringValue("Global")]
        Global = 4999,
        [StringValue("Default Organisation")]
        Default_Organisation = 5000
    }
    public enum StateTypeEnum : int
    {
        [StringValue("Global")]
        Global = 5001,
        [StringValue("Default Organisation")]
        Default_Organisation = 5002,
        [StringValue("CenterTopMenu")]
        CenterTopMenu = 5003
    }
    public enum WorkflowTypeIDEnum : int
    {
        [StringValue("Startup")]
        Startup = 5004,
        [StringValue("Non-Startup")]
        NonStartup = 5005,
        [StringValue("Global")]
        Global = 5007,
        [StringValue("Default Organisation")]
        Default_Organisation = 5008
    }
    public enum WorkflowCategoryIDEnum : int
    {
        [StringValue("UserSpecific")]
        UserSpecific = 5006
    }
    public enum GenderTypeIDEnum : int
    {
        [StringValue("Male")]
        Male = 3769,
        [StringValue("Female")]
        Female = 3770
    }
    public enum ProductRelationshipTypeIDEnum : int
    {
        [StringValue("Default")]
        Default = 5009
    }
    public enum WorkflowInstanceStatusIDEnum : int
    {
        [StringValue("New")]
        New = 2628,
        [StringValue("InProgress")]
        InProgress = 2629,
        [StringValue("Complete")]
        Complete = 2630
    }

    public enum RegulatorIDEnum : int
    {
        [StringValue("SRA")]
        SRA = 5016,
        [StringValue("CLC")]
        CLC = 5017,
        [StringValue("CILEx")]
        CILEx = 5018
    }
    public enum SecurityQuestionsEnum : int
    {
        [StringValue("What is your favourite animal?")]
        What_is_your_favourite_animal = 5019,
        [StringValue("In what city did you meet your spouse / significant other?")]
        In_what_city_did_you_meet_your_spouse_significant_other = 5020,
        [StringValue("What was your first school called?")]
        What_was_your_first_school_called = 5021,
        [StringValue("What is your favourite book?")]
        What_is_your_favourite_book = 801741,
        [StringValue("What is the name of your favourite childhood teacher?")]
        What_is_the_name_of_your_favourite_childhood_teacher = 801742
    }
    public enum PhoneTypeIDEnum : int
    {
        [StringValue("Home")]
        Home = 3762,
        [StringValue("Work")]
        Work = 3761,
        [StringValue("Mobile")]
        Mobile = 3760
    }
    public enum BankAccountOpenedTypeIDEnum : int
    {
        [StringValue("More than 5 years")]
        More_than_5_years = 3765,
        [StringValue("Less than 5 years")]
        Less_than_5_years = 3764,
        [StringValue("Less than 2 years")]
        Less_than_2_years = 3763
    }
    public enum PreferredContactTypeIDEnum : int
    {
        [StringValue("Email")]
        Email = 3766,
        [StringValue("Phone")]
        Phone = 3767,
        [StringValue("Post")]
        Post = 3768
    }
    public enum InviteTypeIDEnum : int
    {
        [StringValue("Search")]
        Search = 3771,
        [StringValue("Registration")]
        Registration = 3772,
        [StringValue("Preapproved")]
        Preapproved = 3773,
        [StringValue("Reassign")]
        Reassign = 3774
    }
    public enum InviteStatusTypeIDEnum : int
    {
        [StringValue("Accept")]
        Accept = 3775,
        [StringValue("Reject")]
        Reject = 3776,
        [StringValue("Reassign")]
        Reassign = 3777
    }
    public enum InviteRejectReasonTypeIDEnum : int
    {
        [StringValue("The address is wrong")]
        The_address_is_wrong = 3778,
        [StringValue("Incorrect law firm")]
        Incorrect_law_firm = 3779,
        [StringValue("Another user at law firm")]
        Another_user_at_law_firm = 3780,
        [StringValue("Wrong branch of law firm")]
        Wrong_branch_of_law_firm = 3781,
        [StringValue("Not out client")]
        Not_out_client = 3783
    }
    public enum FieldTypeIDEnum : int
    {
        [StringValue("Label")]
        Label = 1701,
        [StringValue("TextBox")]
        TextBox = 1702,
        [StringValue("CheckBox")]
        CheckBox = 1703,
        [StringValue("RadioGroup")]
        RadioGroup = 1704,
        [StringValue("ComboBox")]
        ComboBox = 1705,
        [StringValue("LinkButton")]
        LinkButton = 1706,
        [StringValue("Hyperlink")]
        Hyperlink = 1707,
        [StringValue("ImageButton")]
        ImageButton = 1708
    }
    public enum IconAlignmentTypeIDEnum : int
    {
        [StringValue("Left")]
        Left = 1801,
        [StringValue("Right")]
        Right = 1802
    }
    public enum ValidationTypeIDEnum : int
    {
        [StringValue("RequiredFieldValidation")]
        RequiredFieldValidation = 1901
    }
    public enum NationalityTypeIDEnum : int
    {
        [StringValue("Afghan")]
        Afghan = 5023,
        [StringValue("Albanian")]
        Albanian = 5024,
        [StringValue("Algerian")]
        Algerian = 5025,
        [StringValue("American")]
        American = 5026,
        [StringValue("Andorran")]
        Andorran = 5027,
        [StringValue("Angolan")]
        Angolan = 5028,
        [StringValue("Antiguans")]
        Antiguans = 5029,
        [StringValue("Argentinean")]
        Argentinean = 5030,
        [StringValue("Armenian")]
        Armenian = 5031,
        [StringValue("Australian")]
        Australian = 5032,
        [StringValue("Austrian")]
        Austrian = 5033,
        [StringValue("Azerbaijani")]
        Azerbaijani = 5034,
        [StringValue("Bahamian")]
        Bahamian = 5035,
        [StringValue("Bahraini")]
        Bahraini = 5036,
        [StringValue("Bangladeshi")]
        Bangladeshi = 5037,
        [StringValue("Barbadian")]
        Barbadian = 5038,
        [StringValue("Barbudans")]
        Barbudans = 5039,
        [StringValue("Batswana")]
        Batswana = 5040,
        [StringValue("Belarusian")]
        Belarusian = 5041,
        [StringValue("Belgian")]
        Belgian = 5042,
        [StringValue("Belizean")]
        Belizean = 5043,
        [StringValue("Beninese")]
        Beninese = 5044,
        [StringValue("Bhutanese")]
        Bhutanese = 5045,
        [StringValue("Bolivian")]
        Bolivian = 5046,
        [StringValue("Bosnian")]
        Bosnian = 5047,
        [StringValue("Brazilian")]
        Brazilian = 5048,
        [StringValue("British")]
        British = 5049,
        [StringValue("Bruneian")]
        Bruneian = 5050,
        [StringValue("Bulgarian")]
        Bulgarian = 5051,
        [StringValue("Burkinabe")]
        Burkinabe = 5052,
        [StringValue("Burmese")]
        Burmese = 5053,
        [StringValue("Burundian")]
        Burundian = 5054,
        [StringValue("Cambodian")]
        Cambodian = 5055,
        [StringValue("Cameroonian")]
        Cameroonian = 5056,
        [StringValue("Canadian")]
        Canadian = 5057,
        [StringValue("Cape Verdean")]
        Cape_Verdean = 5058,
        [StringValue("Central African")]
        Central_African = 5059,
        [StringValue("Chadian")]
        Chadian = 5060,
        [StringValue("Chilean")]
        Chilean = 5061,
        [StringValue("Chinese")]
        Chinese = 5062,
        [StringValue("Colombian")]
        Colombian = 5063,
        [StringValue("Comoran")]
        Comoran = 5064,
        [StringValue("Congolese")]
        Congolese = 5065,
        [StringValue("Costa Rican")]
        Costa_Rican = 5066,
        [StringValue("Croatian")]
        Croatian = 5067,
        [StringValue("Cuban")]
        Cuban = 5068,
        [StringValue("Cypriot")]
        Cypriot = 5069,
        [StringValue("Czech")]
        Czech = 5070,
        [StringValue("Danish")]
        Danish = 5071,
        [StringValue("Djibouti")]
        Djibouti = 5072,
        [StringValue("Dominican")]
        Dominican = 5073,
        [StringValue("Dutch")]
        Dutch = 5074,
        [StringValue("East Timorese")]
        East_Timorese = 5075,
        [StringValue("Ecuadorean")]
        Ecuadorean = 5076,
        [StringValue("Egyptian")]
        Egyptian = 5077,
        [StringValue("Emirian")]
        Emirian = 5078,
        [StringValue("Equatorial Guinean")]
        Equatorial_Guinean = 5079,
        [StringValue("Eritrean")]
        Eritrean = 5080,
        [StringValue("Estonian")]
        Estonian = 5081,
        [StringValue("Ethiopian")]
        Ethiopian = 5082,
        [StringValue("Fijian")]
        Fijian = 5083,
        [StringValue("Filipino")]
        Filipino = 5084,
        [StringValue("Finnish")]
        Finnish = 5085,
        [StringValue("French")]
        French = 5086,
        [StringValue("Gabonese")]
        Gabonese = 5087,
        [StringValue("Gambian")]
        Gambian = 5088,
        [StringValue("Georgian")]
        Georgian = 5089,
        [StringValue("German")]
        German = 5090,
        [StringValue("Ghanaian")]
        Ghanaian = 5091,
        [StringValue("Greek")]
        Greek = 5092,
        [StringValue("Grenadian")]
        Grenadian = 5093,
        [StringValue("Guatemalan")]
        Guatemalan = 5094,
        [StringValue("Guinea-Bissauan")]
        GuineaBissauan = 5095,
        [StringValue("Guinean")]
        Guinean = 5096,
        [StringValue("Guyanese")]
        Guyanese = 5097,
        [StringValue("Haitian")]
        Haitian = 5098,
        [StringValue("Herzegovinian")]
        Herzegovinian = 5099,
        [StringValue("Honduran")]
        Honduran = 5100,
        [StringValue("Hungarian")]
        Hungarian = 5101,
        [StringValue("I-Kiribati")]
        IKiribati = 5102,
        [StringValue("Icelander")]
        Icelander = 5103,
        [StringValue("Indian")]
        Indian = 5104,
        [StringValue("Indonesian")]
        Indonesian = 5105,
        [StringValue("Iranian")]
        Iranian = 5106,
        [StringValue("Iraqi")]
        Iraqi = 5107,
        [StringValue("Irish")]
        Irish = 5108,
        [StringValue("Israeli")]
        Israeli = 5109,
        [StringValue("Italian")]
        Italian = 5110,
        [StringValue("Ivorian")]
        Ivorian = 5111,
        [StringValue("Jamaican")]
        Jamaican = 5112,
        [StringValue("Japanese")]
        Japanese = 5113,
        [StringValue("Jordanian")]
        Jordanian = 5114,
        [StringValue("Kazakhstani")]
        Kazakhstani = 5115,
        [StringValue("Kenyan")]
        Kenyan = 5116,
        [StringValue("Kittian and Nevisian")]
        Kittian_and_Nevisian = 5117,
        [StringValue("Kuwaiti")]
        Kuwaiti = 5118,
        [StringValue("Kyrgyz")]
        Kyrgyz = 5119,
        [StringValue("Laotian")]
        Laotian = 5120,
        [StringValue("Latvian")]
        Latvian = 5121,
        [StringValue("Lebanese")]
        Lebanese = 5122,
        [StringValue("Liberian")]
        Liberian = 5123,
        [StringValue("Libyan")]
        Libyan = 5124,
        [StringValue("Liechtensteiner")]
        Liechtensteiner = 5125,
        [StringValue("Lithuanian")]
        Lithuanian = 5126,
        [StringValue("Luxembourger")]
        Luxembourger = 5127,
        [StringValue("Macedonian")]
        Macedonian = 5128,
        [StringValue("Malagasy")]
        Malagasy = 5129,
        [StringValue("Malawian")]
        Malawian = 5130,
        [StringValue("Malaysian")]
        Malaysian = 5131,
        [StringValue("Maldivan")]
        Maldivan = 5132,
        [StringValue("Malian")]
        Malian = 5133,
        [StringValue("Maltese")]
        Maltese = 5134,
        [StringValue("Marshallese")]
        Marshallese = 5135,
        [StringValue("Mauritanian")]
        Mauritanian = 5136,
        [StringValue("Mauritian")]
        Mauritian = 5137,
        [StringValue("Mexican")]
        Mexican = 5138,
        [StringValue("Micronesian")]
        Micronesian = 5139,
        [StringValue("Moldovan")]
        Moldovan = 5140,
        [StringValue("Monacan")]
        Monacan = 5141,
        [StringValue("Mongolian")]
        Mongolian = 5142,
        [StringValue("Moroccan")]
        Moroccan = 5143,
        [StringValue("Mosotho")]
        Mosotho = 5144,
        [StringValue("Motswana")]
        Motswana = 5145,
        [StringValue("Mozambican")]
        Mozambican = 5146,
        [StringValue("Namibian")]
        Namibian = 5147,
        [StringValue("Nauruan")]
        Nauruan = 5148,
        [StringValue("Nepalese")]
        Nepalese = 5149,
        [StringValue("New Zealander")]
        New_Zealander = 5150,
        [StringValue("Nicaraguan")]
        Nicaraguan = 5151,
        [StringValue("Nigerian")]
        Nigerian = 5152,
        [StringValue("Nigerien")]
        Nigerien = 5153,
        [StringValue("North Korean")]
        North_Korean = 5154,
        [StringValue("Northern Irish")]
        Northern_Irish = 5155,
        [StringValue("Norwegian")]
        Norwegian = 5156,
        [StringValue("Omani")]
        Omani = 5157,
        [StringValue("Pakistani")]
        Pakistani = 5158,
        [StringValue("Palauan")]
        Palauan = 5159,
        [StringValue("Panamanian")]
        Panamanian = 5160,
        [StringValue("Papua New Guinean")]
        Papua_New_Guinean = 5161,
        [StringValue("Paraguayan")]
        Paraguayan = 5162,
        [StringValue("Peruvian")]
        Peruvian = 5163,
        [StringValue("Polish")]
        Polish = 5164,
        [StringValue("Portuguese")]
        Portuguese = 5165,
        [StringValue("Qatari")]
        Qatari = 5166,
        [StringValue("Romanian")]
        Romanian = 5167,
        [StringValue("Russian")]
        Russian = 5168,
        [StringValue("Rwandan")]
        Rwandan = 5169,
        [StringValue("Saint Lucian")]
        Saint_Lucian = 5170,
        [StringValue("Salvadoran")]
        Salvadoran = 5171,
        [StringValue("Samoan")]
        Samoan = 5172,
        [StringValue("San Marinese")]
        San_Marinese = 5173,
        [StringValue("Sao Tomean")]
        Sao_Tomean = 5174,
        [StringValue("Saudi")]
        Saudi = 5175,
        [StringValue("Scottish")]
        Scottish = 5176,
        [StringValue("Senegalese")]
        Senegalese = 5177,
        [StringValue("Serbian")]
        Serbian = 5178,
        [StringValue("Seychellois")]
        Seychellois = 5179,
        [StringValue("Sierra Leonean")]
        Sierra_Leonean = 5180,
        [StringValue("Singaporean")]
        Singaporean = 5181,
        [StringValue("Slovakian")]
        Slovakian = 5182,
        [StringValue("Slovenian")]
        Slovenian = 5183,
        [StringValue("Solomon Islander")]
        Solomon_Islander = 5184,
        [StringValue("Somali")]
        Somali = 5185,
        [StringValue("South African")]
        South_African = 5186,
        [StringValue("South Korean")]
        South_Korean = 5187,
        [StringValue("Spanish")]
        Spanish = 5188,
        [StringValue("Sri Lankan")]
        Sri_Lankan = 5189,
        [StringValue("Sudanese")]
        Sudanese = 5190,
        [StringValue("Surinamer")]
        Surinamer = 5191,
        [StringValue("Swazi")]
        Swazi = 5192,
        [StringValue("Swedish")]
        Swedish = 5193,
        [StringValue("Swiss")]
        Swiss = 5194,
        [StringValue("Syrian")]
        Syrian = 5195,
        [StringValue("Taiwanese")]
        Taiwanese = 5196,
        [StringValue("Tajik")]
        Tajik = 5197,
        [StringValue("Tanzanian")]
        Tanzanian = 5198,
        [StringValue("Thai")]
        Thai = 5199,
        [StringValue("Togolese")]
        Togolese = 5200,
        [StringValue("Tongan")]
        Tongan = 5201,
        [StringValue("Trinidadian or Tobagonian")]
        Trinidadian_or_Tobagonian = 5202,
        [StringValue("Tunisian")]
        Tunisian = 5203,
        [StringValue("Turkish")]
        Turkish = 5204,
        [StringValue("Tuvaluan")]
        Tuvaluan = 5205,
        [StringValue("Ugandan")]
        Ugandan = 5206,
        [StringValue("Ukrainian")]
        Ukrainian = 5207,
        [StringValue("Uruguayan")]
        Uruguayan = 5208,
        [StringValue("Uzbekistani")]
        Uzbekistani = 5209,
        [StringValue("Venezuelan")]
        Venezuelan = 5210,
        [StringValue("Vietnamese")]
        Vietnamese = 5211,
        [StringValue("Welsh")]
        Welsh = 5212,
        [StringValue("Yemenite")]
        Yemenite = 5213,
        [StringValue("Zambian")]
        Zambian = 5214,
        [StringValue("Zimbabwean")]
        Zimbabwean = 5215
    }
    public enum MonthIDEnum : int
    {
        [StringValue("Jan")]
        Jan = 5219,
        [StringValue("Feb")]
        Feb = 5220,
        [StringValue("Mar")]
        Mar = 5221,
        [StringValue("Apr")]
        Apr = 5222,
        [StringValue("May")]
        May = 5223,
        [StringValue("Jun")]
        Jun = 5224,
        [StringValue("Jul")]
        Jul = 5225,
        [StringValue("Aug")]
        Aug = 5226,
        [StringValue("Sep")]
        Sep = 5227,
        [StringValue("Oct")]
        Oct = 5228,
        [StringValue("Nov")]
        Nov = 5229,
        [StringValue("Dec")]
        Dec = 5230
    }

    public enum ActorTypeIDEnum : int
    {
        [StringValue("STS")]
        STS = 810001
    }
    public enum RejectReasonTypeIDEnum : int
    {
        [StringValue("The address is wrong")]
        The_address_is_wrong = 814000,
        [StringValue("The law firm is wrong")]
        The_law_firm_is_wrong = 814001,
        [StringValue("I am not purchasing a property")]
        I_am_not_purchasing_a_property = 814002,
        [StringValue("I am not selling a property")]
        I_am_not_selling_a_property = 814003,
        [StringValue("Other")]
        Other = 814004
    }
    public enum PropertyTenureIDEnum : int
    {
        [StringValue("Freehold")]
        Freehold = 817000,
        [StringValue("Leasehold")]
        Leasehold = 817001
    }
    public enum DepositFromTypeIDEnum : int
    {
        [StringValue("Gift")]
        Gift = 818000,
        [StringValue("Saving")]
        Saving = 818001,
        [StringValue("Loan")]
        Loan = 818002,
        [StringValue("Proceed from Sale")]
        Proceed_from_Sale = 818003
    }
    public enum TelephoneTypeIDEnum : int
    {
        [StringValue("Home")]
        Home = 5216,
        [StringValue("Work")]
        Work = 5217,
        [StringValue("Mobile")]
        Mobile = 5218
    }
    public enum BranchRejectionReasonEnum : int
    {
        [StringValue("Not a branch at this firm")]
        Not_a_branch_at_this_firm = 201,
        [StringValue("Other")]
        Other = 202
    }
    public enum UserRejectionReasonEnum : int
    {
        [StringValue("Left Company")]
        Left_Company = 212,
        [StringValue("Not Known at this firm")]
        Not_Known_at_this_firm = 211,
        [StringValue("Non Conveyancing Role")]
        Non_Conveyancing_Role = 213,
        [StringValue("Other")]
        Other = 214
    }
    public enum SellingUnderAuthorityTypeIDEnum : int
    {
        [StringValue("Probate")]
        Probate = 871101,
        [StringValue("Power of Attorney")]
        Power_of_Attorney = 871102,
        [StringValue("Court Protection order")]
        Court_Protection_order = 871103,
        [StringValue("Registered Proprietor")]
        Registered_Proprietor = 871104
    }

    public enum NotificationGroupTypeIDEnum : int
    {
        [StringValue("General")]
        General = 670100,
        [StringValue("TermsConditions")]
        TermsConditions = 670101
    }
    public enum NotificationGroupCategoryIDEnum : int
    {
        [StringValue("General")]
        General = 670200
    }
    public enum ErrorCodeTypeIDEnum : int
    {
        [StringValue("FirstData Gateway")]
        FirstData_Gateway = 1000001,
        [StringValue("FirstData Card Issuer")]
        FirstData_Card_Issuer = 1000002,
        [StringValue("LREnquiryByPropertyDescription")]
        LREnquiryByPropertyDescription = 1000003,
        [StringValue("LRRegisterExtractService")]
        LRRegisterExtractService = 1000004,
        [StringValue("LROfficialCopyTitleKnown")]
        LROfficialCopyTitleKnown = 1000005,
        [StringValue("LROfficialSearchWholeWithPriority")]
        LROfficialSearchWholeWithPriority = 1000006,
        [StringValue("LROfficialSearchPartWithPriority")]
        LROfficialSearchPartWithPriority = 1000007
    }
    public enum ErrorCodeCategoryIDEnum : int
    {
        [StringValue("FirstData")]
        FirstData = 1001001,
        [StringValue("LandRegistry")]
        LandRegistry = 1001002
    }
    public enum TransactionGatewayIDEnum : int
    {
        [StringValue("FirstData Merchant Gateway")]
        FirstData_Merchant_Gateway = 110000
    }
    public enum ProductTaskTypeIDEnum : int
    {
        [StringValue("Experian")]
        Experian = 2000000,
        [StringValue("Land Registry")]
        Land_Registry = 2000001
    }
    public enum SecurityQuestions2Enum : int
    {
        [StringValue("What was the name of your favourite childhood toy?")]
        What_was_the_name_of_your_favourite_childhood_toy = 801739,
        [StringValue("Who was your childhood hero?")]
        Who_was_your_childhood_hero = 801745,
        [StringValue("What is your memorable place?")]
        What_is_your_memorable_place = 801746,
        [StringValue("What was the first concert you attended?")]
        What_was_the_first_concert_you_attended = 801747,
        [StringValue("What was your favourite place to visit as a child?")]
        What_was_your_favourite_place_to_visit_as_a_child = 801744
    }
    public enum ServiceInterfaceTypeIDEnum : int
    {
        [StringValue("Land Registry")]
        Land_Registry = 2200001
    }
    public enum ServiceDefinitionTypeIDEnum : int
    {
        [StringValue("Land Registry Service")]
        Land_Registry_Service = 2200002
    }
    public enum BranchRegulatorIDEnum : int
    {
        [StringValue("SRA")]
        SRA = 801748,
        [StringValue("CLC")]
        CLC = 801749
    }
    public enum LRPropertyTenureTypeIDEnum : int
    {
        [StringValue("Freehold")]
        Freehold = 2100001,
        [StringValue("Other")]
        Other = 2100002,
        [StringValue("Leasehold")]
        Leasehold = 2100003,
        [StringValue("Commonhold")]
        Commonhold = 2100004,
        [StringValue("Feuhold")]
        Feuhold = 2100005,
        [StringValue("Mixed")]
        Mixed = 2100006,
        [StringValue("Unknown")]
        Unknown = 2100007,
        [StringValue("Unavailable")]
        Unavailable = 2100008,
        [StringValue("Caution Against First Registration")]
        Caution_Against_First_Registration = 2100009,
        [StringValue("Rent Charge")]
        Rent_Charge = 2100010,
        [StringValue("Franchise")]
        Franchise = 2100011,
        [StringValue("Profit A Prendre In Gross")]
        Profit_A_Prendre_In_Gross = 2100012,
        [StringValue("Manor")]
        Manor = 2100013
    }
    public enum ProductTypeIDEnum : int
    {
        [StringValue("Supplier Product")]
        Supplier_Product = 5022
    }
    public enum SubscriptionStatusIDEnum : int
    {
        [StringValue("Future")]
        Future = 800100,
        [StringValue("In Trial")]
        In_Trial = 800101,
        [StringValue("Active")]
        Active = 800102,
        [StringValue("Non Renewing")]
        Non_Renewing = 800103,
        [StringValue("Cancelled")]
        Cancelled = 800104
    }
    public enum CancelReasonIDEnum : int
    {
        [StringValue("Not Paid")]
        Not_Paid = 800200,
        [StringValue("No Card")]
        No_Card = 800201,
        [StringValue("Fraud Review Failed")]
        Fraud_Review_Failed = 800202
    }
    public enum PaymentMethodIDEnum : int
    {
        [StringValue("Card")]
        Card = 8500,
        [StringValue("BACS")]
        BACS = 8501,
        [StringValue("Direct Debit")]
        Direct_Debit = 8502
    }
    public enum TransactionTypeIDEnum : int
    {
        [StringValue("Charge")]
        Charge = 800300,
        [StringValue("Payment")]
        Payment = 800301,
        [StringValue("Refund")]
        Refund = 800302,
        [StringValue("Payment Authorisation")]
        Payment_Authorisation = 800303,
        [StringValue("Adjustment")]
        Adjustment = 800304,
        [StringValue("Info")]
        Info = 800305,
        [StringValue("Credit")]
        Credit = 800306
    }
    public enum TransactionChargeTypeIDEnum : int
    {
        [StringValue("One Time")]
        One_Time = 800400,
        [StringValue("Delay Capture")]
        Delay_Capture = 800401,
        [StringValue("Initial")]
        Initial = 800402,
        [StringValue("Metered")]
        Metered = 800403,
        [StringValue("Quantity Based Component")]
        Quantity_Based_Component = 800404,
        [StringValue("On Off Component")]
        On_Off_Component = 800405,
        [StringValue("Tax")]
        Tax = 800406
    }
    public enum PeriodUnitIDEnum : int
    {
        [StringValue("Week")]
        Week = 800500,
        [StringValue("Month")]
        Month = 800501,
        [StringValue("Year")]
        Year = 800502
    }
    public enum PlanStatusIDEnum : int
    {
        [StringValue("Active")]
        Active = 800600,
        [StringValue("Archived")]
        Archived = 800601,
        [StringValue("Deleted")]
        Deleted = 800602
    }
    public enum DiscountTypeIDEnum : int
    {
        [StringValue("Fixed Amount")]
        Fixed_Amount = 800800,
        [StringValue("Percentage")]
        Percentage = 800801,
        [StringValue("Offer Quantity")]
        Offer_Quantity = 800802
    }
    public enum DurationTypeIDEnum : int
    {
        [StringValue("One Time")]
        One_Time = 800700,
        [StringValue("Forever")]
        Forever = 800701,
        [StringValue("Limited Period")]
        Limited_Period = 800702
    }
    public enum DiscountStatusIDEnum : int
    {
        [StringValue("Active")]
        Active = 800900,
        [StringValue("Expired")]
        Expired = 800901,
        [StringValue("Archived")]
        Archived = 800902
    }
    public enum DiscountAppliedOnIDEnum : int
    {
        [StringValue("Invoice Amount")]
        Invoice_Amount = 801000,
        [StringValue("Specified Items Total")]
        Specified_Items_Total = 801001,
        [StringValue("Each Specified Item")]
        Each_Specified_Item = 801002,
        [StringValue("Each Unit of Specified Item")]
        Each_Unit_of_Specified_Item = 801003
    }
    public enum BillingChargeTypeIDEnum : int
    {
        [StringValue("Direct Debit")]
        Direct_Debit = 801100,
        [StringValue("BACS")]
        BACS = 801101
    }
    public enum LedgerAccountTypeIDEnum : int
    {
        [StringValue("Deposit")]
        Deposit = 801200,
        [StringValue("Sales")]
        Sales = 801201,
        [StringValue("Purchasing")]
        Purchasing = 801202,
        [StringValue("Merchant")]
        Merchant = 801203
    }
    public enum PaymentMethodTypeIDEnum : int
    {
        [StringValue("Credit Card")]
        Credit_Card = 8000,
        [StringValue("Debit Card")]
        Debit_Card = 8001
    }
    public enum PaymentCardTypeIDEnum : int
    {
        [StringValue("Visa Credit")]
        Visa_Credit = 9000,
        [StringValue("Visa Debit")]
        Visa_Debit = 9001,
        [StringValue("Visa Business")]
        Visa_Business = 9002,
        [StringValue("Visa UK Electron")]
        Visa_UK_Electron = 9003,
        [StringValue("MasterCard Credit")]
        MasterCard_Credit = 9004,
        [StringValue("MasterCard Debit")]
        MasterCard_Debit = 9005,
        [StringValue("Maestro")]
        Maestro = 9006,
        [StringValue("MasterCard Business")]
        MasterCard_Business = 9007,
        [StringValue("Diners")]
        Diners = 9008,
        [StringValue("American Express")]
        American_Express = 9009,
        [StringValue("Other")]
        Other = 9020
    }
    public enum BusMessageTypeIDEnum : int
    {
        [StringValue("Atomic")]
        Atomic = 801300,
        [StringValue("Scheduled")]
        Scheduled = 801301
    }
    public enum BusMessageStatusIDEnum : int
    {
        [StringValue("Completed")]
        Completed = 801400,
        [StringValue("Failed")]
        Failed = 801401,
        [StringValue("Received")]
        Received = 801402,
        [StringValue("Sent")]
        Sent = 801403
    }
    public enum InvoiceTypeIDEnum : int
    {
        [StringValue("Scheduled")]
        Scheduled = 801500,
        [StringValue("Manual")]
        Manual = 801501,
        [StringValue("Online")]
        Online = 801502
    }
    public enum InvoiceLineItemTypeIDEnum : int
    {
        [StringValue("Product")]
        Product = 801600,
        [StringValue("Plan Subscription")]
        Plan_Subscription = 801601,
        [StringValue("Credit Note")]
        Credit_Note = 801602,
        [StringValue("Debit Note")]
        Debit_Note = 801603
    }
    public enum InvoiceAccountingStatusIDEnum : int
    {
        [StringValue("Paid Late")]
        Paid_Late = 801700,
        [StringValue("Arrears (BACS Only)")]
        Arrears_BACS_Only = 801701,
        [StringValue("DD Returned")]
        DD_Returned = 801702,
        [StringValue("Credit Note")]
        Credit_Note = 801703,
        [StringValue("Written Off")]
        Written_Off = 801704,
        [StringValue("Paid")]
        Paid = 801705,
        [StringValue("Pending")]
        Pending = 801706,
        [StringValue("Invoice Withdrawn")]
        Invoice_Withdrawn = 801707
    }

    public enum RejectionTypeIDEnum : int
    {
        [StringValue("No match to regulator")]
        No_match_to_regulator = 5231,
        [StringValue("Failed to validate callback")]
        Failed_to_validate_callback = 5232,
        [StringValue("Decline to participate")]
        Decline_to_participate = 5243
    }

    public enum TenureTypeIDEnum : int
    {
        [StringValue("Freehold")]
        Freehold = 5233,
        [StringValue("Leasehold")]
        Leasehold = 5234
    }

    public enum OrganisationRecommendationSource
    {
        [StringValue("Bold Legal Group")]
        Bold_Legal_Group = 801949,
        [StringValue("Conveyancing Data Services")]
        Conveyancing_Data_Services = 801969,
        [StringValue("Search Acumen")]
        Search_Acumen = 801979,
        [StringValue("None of the above")]
        Other = 802000
    }

    public enum ActivityType
    {
        [StringValue("Transaction")]
        SmsTransaction = 803001,
        [StringValue("Bank Account")]
        BankAccount = 803002
    }

    public enum FieldUpdateParentType
    {
        SmsTransaction = 0,
        Contact = 1,
        Address = 2
    }
}