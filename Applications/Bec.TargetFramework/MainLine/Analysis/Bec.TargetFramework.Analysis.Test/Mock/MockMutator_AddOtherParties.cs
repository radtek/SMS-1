using Bec.TargetFramework.Analysis.Interfaces;
using System;
using System.Collections.Generic;

namespace Bec.TargetFramework.Analysis.Test
{
    public class MockMutator_AddOtherParties : IMutator
    {
        public SearchDetail Mutate(SearchDetail input)
        {
            // update the buyer
            var buyer = input.Parties[0];
            buyer.Detail.PreviousNames.Add(new NameDetail());
            buyer.Detail.PreviousNames[0] = new NameDetail();
            buyer.Detail.PreviousNames[0].FirstName = "John";
            buyer.Detail.PreviousNames[0].MiddleName = "Dodgy";
            buyer.Detail.PreviousNames[0].LastName = "Smith";
            buyer.Detail.PreviousNames.Add(new NameDetail());
            buyer.Detail.PreviousNames[1].FirstName = "Not";
            buyer.Detail.PreviousNames[1].MiddleName= "Me";
            buyer.Detail.PreviousNames[1].LastName = "Again";
            buyer.Detail.SMSActorCode = "Actor001";

            // update the broker
            var broker = input.Parties[1];
            broker.Detail.SMSActorCode = "Actor002";

            // update the buyers conveyancer
            var buyerConveyancer= input.Parties[2];
            buyerConveyancer.Detail.SMSActorCode = "Actor003";

            // Add the seller, for now mock this data
            var party = new PartyContainerDetail();
            party.Detail = new PartyDetail();
            party.Detail.PartyType = PartyTypeEnum.SELL;
            party.Detail.PartyTypeSpecified = true;
            party.Detail.PartyCode = "SELL-001";
            party.Detail.Name = new NameDetail();
            party.Detail.Name.FirstName = "Todd";
            party.Detail.Name.LastName = "Jones";
            party.Detail.DateOfBirth = new DateTime(1967, 1, 12);
            party.Detail.DateOfBirthSpecified = true;
            party.Detail.Address = new AddressDetail();
            party.Detail.Address.BuildingName = "654";
            party.Detail.Address.Line1 = "Sheep lane";
            party.Detail.Address.TownCity = "Bexley";
            party.Detail.Address.PostCode = "BE178UP";
            party.Detail.Address.County = "Kent";
            party.Detail.Address.CountryCode = "GBR";
            party.Detail.Address.IsAnInternationalAddress = false;
            party.Detail.Address.IsAnInternationalAddressSpecified = true;
            party.Detail.SMSActorCode = "Actor789";
            party.Detail.EmailAddress = "t.jones@gmail.com";
            party.Detail.TelephoneNumbers = new List<string>() {"02045687426"};
            input.Parties.Add(party);

            // Add the seller conveyancer, for now mock this data
            party = new PartyContainerDetail();
            party.Detail = new PartyDetail();
            party.Detail.PartyType = PartyTypeEnum.SCU;
            party.Detail.PartyTypeSpecified = true;
            party.Detail.PartyCode = "SCU-001";
            party.Detail.Name = new NameDetail();
            party.Detail.Name.FirstName = "June";
            party.Detail.Name.LastName = "Bicknell";
            party.Detail.DateOfBirth = new DateTime(1982, 12, 14);
            party.Detail.DateOfBirthSpecified = true;
            party.Detail.SMSActorCode = "Actor654";
            party.Detail.EmailAddress = "bicknellj123@gmail.com";
            party.Detail.TelephoneNumbers = new List<string>() { "08002304568" };
            party.Organisation = new OrganisationDetail();
            party.Organisation.Name = "Conveyancing2U";
            party.Organisation.Address = new AddressDetail();
            party.Organisation.Address.BuildingName = "566";
            party.Organisation.Address.Line1 = "Travis Way";
            party.Organisation.Address.TownCity = "Bromley";
            party.Organisation.Address.PostCode = "BR18UP";
            party.Organisation.Address.County = "Kent";
            party.Organisation.Address.CountryCode = "GBR";
            party.Organisation.Address.IsAnInternationalAddress = false;
            party.Organisation.Address.IsAnInternationalAddressSpecified = true;
            input.Parties.Add(party);

            // Add the estate agent user, for now mock this data
            party = new PartyContainerDetail();
            party.Detail = new PartyDetail();
            party.Detail.PartyType = PartyTypeEnum.EAU;
            party.Detail.PartyTypeSpecified = true;
            party.Detail.PartyCode = "EAU-001";
            party.Detail.Name = new NameDetail();
            party.Detail.Name.FirstName = "Tim";
            party.Detail.Name.LastName = "Sutcliff";
            party.Detail.DateOfBirth = new DateTime(1965, 05, 11);
            party.Detail.DateOfBirthSpecified = true;
            party.Detail.SMSActorCode = "Actor415";
            party.Detail.EmailAddress = "t.sutcliff@SavillesProperty.com";
            party.Detail.TelephoneNumbers = new List<string>() { "02087456325" };
            party.Organisation = new OrganisationDetail();
            party.Organisation.Name = "Savilles property services";
            party.Organisation.Address = new AddressDetail();
            party.Organisation.Address.BuildingName = "24";
            party.Organisation.Address.Line1 = "The mount";
            party.Organisation.Address.TownCity = "Bromley";
            party.Organisation.Address.PostCode = "BR27GH";
            party.Organisation.Address.County = "Kent";
            party.Organisation.Address.CountryCode = "GBR";
            party.Organisation.Address.IsAnInternationalAddress = false;
            party.Organisation.Address.IsAnInternationalAddressSpecified = true;
            input.Parties.Add(party);

            foreach (var thisParty in input.Parties)
            {
                thisParty.LastUpdated = new DateTime(2015, 2, 4);
                thisParty.LastUpdatedSpecified = true;
            }

            return input;
        }
    }
}
