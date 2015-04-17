﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class CompanyHouseConverter
    {

        public static CompanyHouseDTO ToDto(this Bec.TargetFramework.Data.CompanyHouse source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static CompanyHouseDTO ToDtoWithRelated(this Bec.TargetFramework.Data.CompanyHouse source, int level)
        {
            if (source == null)
              return null;

            var target = new CompanyHouseDTO();

            // Properties
            target.Companyname = source.Companyname;
            target.Companynumber = source.Companynumber;
            target.Regaddresscareof = source.Regaddresscareof;
            target.Regaddresspobox = source.Regaddresspobox;
            target.Regaddressaddressline1 = source.Regaddressaddressline1;
            target.Regaddressaddressline2 = source.Regaddressaddressline2;
            target.Regaddressposttown = source.Regaddressposttown;
            target.Regaddresscounty = source.Regaddresscounty;
            target.Regaddresscountry = source.Regaddresscountry;
            target.Regaddresspostcode = source.Regaddresspostcode;
            target.Companycategory = source.Companycategory;
            target.Companystatus = source.Companystatus;
            target.Countryoforigin = source.Countryoforigin;
            target.Dissolutiondate = source.Dissolutiondate;
            target.Incorporationdate = source.Incorporationdate;
            target.Accountsaccountrefday = source.Accountsaccountrefday;
            target.Accountsaccountrefmonth = source.Accountsaccountrefmonth;
            target.Accountsnextduedate = source.Accountsnextduedate;
            target.Accountslastmadeupdate = source.Accountslastmadeupdate;
            target.Accountsaccountcategory = source.Accountsaccountcategory;
            target.Returnsnextduedate = source.Returnsnextduedate;
            target.Returnslastmadeupdate = source.Returnslastmadeupdate;
            target.Mortgagesnummortcharges = source.Mortgagesnummortcharges;
            target.Mortgagesnummortoutstanding = source.Mortgagesnummortoutstanding;
            target.Mortgagesnummortpartsatisfied = source.Mortgagesnummortpartsatisfied;
            target.Mortgagesnummortsatisfied = source.Mortgagesnummortsatisfied;
            target.Siccodesictext1 = source.Siccodesictext1;
            target.Siccodesictext2 = source.Siccodesictext2;
            target.Siccodesictext3 = source.Siccodesictext3;
            target.Siccodesictext4 = source.Siccodesictext4;
            target.Limitedpartnershipsnumgenpartners = source.Limitedpartnershipsnumgenpartners;
            target.Limitedpartnershipsnumlimpartners = source.Limitedpartnershipsnumlimpartners;
            target.Uri = source.Uri;
            target.Previousname1condate = source.Previousname1condate;
            target.Previousname1companyname = source.Previousname1companyname;
            target.Previousname2condate = source.Previousname2condate;
            target.Previousname2companyname = source.Previousname2companyname;
            target.Previousname3condate = source.Previousname3condate;
            target.Previousname3companyname = source.Previousname3companyname;
            target.Previousname4condate = source.Previousname4condate;
            target.Previousname4companyname = source.Previousname4companyname;
            target.Previousname5condate = source.Previousname5condate;
            target.Previousname5companyname = source.Previousname5companyname;
            target.Previousname6condate = source.Previousname6condate;
            target.Previousname6companyname = source.Previousname6companyname;
            target.Previousname7condate = source.Previousname7condate;
            target.Previousname7companyname = source.Previousname7companyname;
            target.Previousname8condate = source.Previousname8condate;
            target.Previousname8companyname = source.Previousname8companyname;
            target.Previousname9condate = source.Previousname9condate;
            target.Previousname9companyname = source.Previousname9companyname;
            target.Previousname10condate = source.Previousname10condate;
            target.Previousname10companyname = source.Previousname10companyname;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.CompanyHouse ToEntity(this CompanyHouseDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.CompanyHouse();

            // Properties
            target.Companyname = source.Companyname;
            target.Companynumber = source.Companynumber;
            target.Regaddresscareof = source.Regaddresscareof;
            target.Regaddresspobox = source.Regaddresspobox;
            target.Regaddressaddressline1 = source.Regaddressaddressline1;
            target.Regaddressaddressline2 = source.Regaddressaddressline2;
            target.Regaddressposttown = source.Regaddressposttown;
            target.Regaddresscounty = source.Regaddresscounty;
            target.Regaddresscountry = source.Regaddresscountry;
            target.Regaddresspostcode = source.Regaddresspostcode;
            target.Companycategory = source.Companycategory;
            target.Companystatus = source.Companystatus;
            target.Countryoforigin = source.Countryoforigin;
            target.Dissolutiondate = source.Dissolutiondate;
            target.Incorporationdate = source.Incorporationdate;
            target.Accountsaccountrefday = source.Accountsaccountrefday;
            target.Accountsaccountrefmonth = source.Accountsaccountrefmonth;
            target.Accountsnextduedate = source.Accountsnextduedate;
            target.Accountslastmadeupdate = source.Accountslastmadeupdate;
            target.Accountsaccountcategory = source.Accountsaccountcategory;
            target.Returnsnextduedate = source.Returnsnextduedate;
            target.Returnslastmadeupdate = source.Returnslastmadeupdate;
            target.Mortgagesnummortcharges = source.Mortgagesnummortcharges;
            target.Mortgagesnummortoutstanding = source.Mortgagesnummortoutstanding;
            target.Mortgagesnummortpartsatisfied = source.Mortgagesnummortpartsatisfied;
            target.Mortgagesnummortsatisfied = source.Mortgagesnummortsatisfied;
            target.Siccodesictext1 = source.Siccodesictext1;
            target.Siccodesictext2 = source.Siccodesictext2;
            target.Siccodesictext3 = source.Siccodesictext3;
            target.Siccodesictext4 = source.Siccodesictext4;
            target.Limitedpartnershipsnumgenpartners = source.Limitedpartnershipsnumgenpartners;
            target.Limitedpartnershipsnumlimpartners = source.Limitedpartnershipsnumlimpartners;
            target.Uri = source.Uri;
            target.Previousname1condate = source.Previousname1condate;
            target.Previousname1companyname = source.Previousname1companyname;
            target.Previousname2condate = source.Previousname2condate;
            target.Previousname2companyname = source.Previousname2companyname;
            target.Previousname3condate = source.Previousname3condate;
            target.Previousname3companyname = source.Previousname3companyname;
            target.Previousname4condate = source.Previousname4condate;
            target.Previousname4companyname = source.Previousname4companyname;
            target.Previousname5condate = source.Previousname5condate;
            target.Previousname5companyname = source.Previousname5companyname;
            target.Previousname6condate = source.Previousname6condate;
            target.Previousname6companyname = source.Previousname6companyname;
            target.Previousname7condate = source.Previousname7condate;
            target.Previousname7companyname = source.Previousname7companyname;
            target.Previousname8condate = source.Previousname8condate;
            target.Previousname8companyname = source.Previousname8companyname;
            target.Previousname9condate = source.Previousname9condate;
            target.Previousname9companyname = source.Previousname9companyname;
            target.Previousname10condate = source.Previousname10condate;
            target.Previousname10companyname = source.Previousname10companyname;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<CompanyHouseDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.CompanyHouse> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<CompanyHouseDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.CompanyHouse> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.CompanyHouse> ToEntities(this IEnumerable<CompanyHouseDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.CompanyHouse source, CompanyHouseDTO target);

        static partial void OnEntityCreating(CompanyHouseDTO source, Bec.TargetFramework.Data.CompanyHouse target);

    }

}
