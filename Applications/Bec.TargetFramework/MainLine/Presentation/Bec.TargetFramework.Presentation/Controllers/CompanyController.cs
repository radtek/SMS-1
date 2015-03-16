using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Presentation.Models;
using Bec.TargetFramework.UI.Process.Base;
using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace Bec.TargetFramework.Presentation.Controllers
{
    public class CompanyController : ApplicationControllerBase
    {
        public CompanyController(ILogger logger)
            : base(logger)
        {
        }

        [HttpGet]
        [ActionName("ViewTemporaryCompanies")]
        public ActionResult ViewTemporaryCompanies()
        {
            var res = TempData["AddedCompany"];
            var companiesModel = new GetAllCompaniesVM();

            var allCompanies = GetCompanies();

            companiesModel.VerifiedCompanies = allCompanies.Where(x => x.IsVerified).ToList();
            companiesModel.UnverifiedCompanies = allCompanies.Where(x => !x.IsVerified).ToList();

            if (m_AddedCompanies != null)
                m_AddedCompanies.ForEach(m => companiesModel.UnverifiedCompanies.Add(m));

            return View(companiesModel);
        }

        // represents the newly added companies
        private static List<Company> m_AddedCompanies;

        [HttpPost]
        [ActionName("AddCompany")]
        public ActionResult AddCompanyPost(Company newCompany)
        {
            if (m_AddedCompanies == null)
                m_AddedCompanies = new List<Company>();

            newCompany.RecordCreated = DateTime.Now;
            m_AddedCompanies.Add(newCompany);

            TempData["AddedCompany"] = newCompany.RecordCreated.Ticks;

            return Json(new { returnUrl = newCompany.ReturnUrl });
        }

        [HttpGet]
        [ActionName("AddCompany")]
        public ActionResult AddCompany()
        {
            return PartialView();
        }

        [HttpGet]
        [ActionName("GetTemporaryCompanies")]
        private ActionResult GetTemporaryCompanies()
        {
            var allCompanies = GetCompanies();

            return Json(allCompanies);
        }

        private IList<Company> GetCompanies()
        {
            var generator = new SequentialGenerator<int> { Direction = GeneratorDirection.Ascending, Increment = 1 };
            generator.StartingWith(100);

            var address1 = new List<string>();
            var address2 = new List<string>();
            var townCity = new List<string>();
            var county = new List<string>();
            var postcodes = new List<string>();

            address1.Add("Cloverhill Road");
            address2.Add("Bridge of Don");
            townCity.Add("Aberdeen");
            county.Add("Aberdeen City");
            postcodes.Add("AB23 8SE");

            address1.Add("3 Cemetery Lane");
            address2.Add("");
            townCity.Add("");
            county.Add("London");
            postcodes.Add("SE7 8DU");

            address1.Add("71 By Pass Road");
            address2.Add("Leatherhead");
            townCity.Add("");
            county.Add("Surrey");
            postcodes.Add("KT22 7BX");

            address1.Add("Meridian East");
            address2.Add("");
            townCity.Add("Leicester");
            county.Add("Leicestershire");
            postcodes.Add("LE19");

            address1.Add("5 Main Street");
            address2.Add("Ingoldsby");
            townCity.Add("Grantham");
            county.Add("Lincolnshire");
            postcodes.Add("NG33 4EJ");

            address1.Add("11 Puddledock, London");
            address2.Add("");
            townCity.Add("");
            county.Add("London");
            postcodes.Add("EC4V 3PD");

            address1.Add("28A Wilfred Avenue");
            address2.Add("Rainham");
            townCity.Add("");
            county.Add("Greater London");
            postcodes.Add("RM13 9TX");

            address1.Add("2 Homefield Close");
            address2.Add("Locking");
            townCity.Add("Weston-super-Mare");
            county.Add("North Somerset");
            postcodes.Add("BS24 8EB");

            address1.Add("16 Curlew Close");
            address2.Add("Harmby");
            townCity.Add("");
            county.Add("Leyburn");
            postcodes.Add("DL8 5QF");

            address1.Add("8 Adams Avenue");
            address2.Add("");
            townCity.Add("Stoke-on-Trent");
            county.Add("Stoke-on-Trent");
            postcodes.Add("ST6 5PE");

            address1.Add("21 Fields View");
            address2.Add("");
            townCity.Add("Sudbury");
            county.Add("Suffolk");
            postcodes.Add("CO10 1BJ");

            address1.Add("14 Cranmer Road");
            address2.Add("");
            townCity.Add("");
            county.Add("London");
            postcodes.Add("E7 0JW");

            address1.Add("32 Saint Marys Road");
            address2.Add("");
            townCity.Add("New Romney");
            county.Add("Kent");
            postcodes.Add("TN28 8JG");

            address1.Add("244 Runnymede Avenue");
            address2.Add("");
            townCity.Add("Bournemouth");
            county.Add("Poole");
            postcodes.Add("BH11 9SP");

            address1.Add("21 Union Court");
            address2.Add("");
            townCity.Add("Barnsley");
            county.Add("South Yorkshire");
            postcodes.Add("S70 1JN");

            address1.Add("124 Sinclair Drive");
            address2.Add("");
            townCity.Add("Cowdenbeath");
            county.Add("Fife");
            postcodes.Add("KY4 9RG");

            address1.Add("84 Lees Lane");
            address2.Add("Haworth");
            townCity.Add("Keighley");
            county.Add("West Yorkshire");
            postcodes.Add("BD22 8RA");

            address1.Add("6 Gladstone Road");
            address2.Add("");
            townCity.Add("Broadstairs");
            county.Add("Kent");
            postcodes.Add("CT10 2HZ");

            address1.Add("1 Ensbury Drive");
            address2.Add("");
            townCity.Add("Bangor");
            county.Add("North Down");
            postcodes.Add("BT19 6UF");

            address1.Add("10 Castlerow Drive");
            address2.Add("");
            townCity.Add("Sheffield");
            county.Add("South Yorkshire");
            postcodes.Add("S17 4RB");

            var firstName = new List<string>();
            firstName.Add("Paige");
            firstName.Add("Arturo");
            firstName.Add("Corrina");
            firstName.Add("Julieta");
            firstName.Add("Tesha");
            firstName.Add("Amanda");
            firstName.Add("Dusti");
            firstName.Add("Monique");
            firstName.Add("Nicholas");
            firstName.Add("Chaya");
            firstName.Add("Keeley");
            firstName.Add("Erline");
            firstName.Add("Marla");
            firstName.Add("Jack");
            firstName.Add("Georgina");
            firstName.Add("Lucille");
            firstName.Add("Loida");
            firstName.Add("Nancy");
            firstName.Add("Laura");
            firstName.Add("Kendra");

            var lastName = new List<string>();
            lastName.Add("Texada");
            lastName.Add("Blakney");
            lastName.Add("Christ");
            lastName.Add("Westlake");
            lastName.Add("Linwood");
            lastName.Add("Carlow");
            lastName.Add("Hardaway");
            lastName.Add("Mclennan");
            lastName.Add("Seabolt");
            lastName.Add("Kemplin");
            lastName.Add("Plate");
            lastName.Add("Culp");
            lastName.Add("Said");
            lastName.Add("Diehl");
            lastName.Add("Kuhlman");
            lastName.Add("Phu");
            lastName.Add("Lenz");
            lastName.Add("Hammock");
            lastName.Add("Ebel");
            lastName.Add("Chumbley");

            var emails = new List<string>();
            emails.Add("Paige.Texada@gmail.com");
            emails.Add("Arturo.Blakney@gmail.com");
            emails.Add("Corrina.Christ@gmail.com");
            emails.Add("Julieta.Westlake@gmail.com");
            emails.Add("Tesha.Linwood@gmail.com");
            emails.Add("Amanda.Carlow@gmail.com");
            emails.Add("Dusti.Hardaway@gmail.com");
            emails.Add("Monique.Mclennan@gmail.com");
            emails.Add("Nicholas.Seabolt@gmail.com");
            emails.Add("Chaya.Kemplin@gmail.com");
            emails.Add("Keeley.Plate@gmail.com");
            emails.Add("Erline.Culp@gmail.com");
            emails.Add("Marla.Said@gmail.com");
            emails.Add("Jack.Diehl@gmail.com");
            emails.Add("Georgina.Kuhlman@gmail.com");
            emails.Add("Lucille.Phu@gmail.com");
            emails.Add("Loida.Lenz@gmail.com");
            emails.Add("Nancy.Hammock@gmail.com");
            emails.Add("Laura.Ebel@gmail.com");
            emails.Add("Kendra.Chumbley@gmail.com");

            var isVerified = new List<bool>();
            isVerified.Add(true);
            isVerified.Add(true);
            isVerified.Add(true);
            isVerified.Add(true);
            isVerified.Add(true);
            isVerified.Add(true);
            isVerified.Add(true);
            isVerified.Add(true);
            isVerified.Add(true);
            isVerified.Add(true);
            isVerified.Add(false);
            isVerified.Add(false);
            isVerified.Add(false);
            isVerified.Add(false);
            isVerified.Add(false);
            isVerified.Add(false);
            isVerified.Add(false);
            isVerified.Add(false);
            isVerified.Add(false);
            isVerified.Add(false);

            var isPinCreated = new List<bool>();
            isPinCreated.Add(true);
            isPinCreated.Add(false);
            isPinCreated.Add(true);
            isPinCreated.Add(false);
            isPinCreated.Add(true);
            isPinCreated.Add(false);
            isPinCreated.Add(true);
            isPinCreated.Add(false);
            isPinCreated.Add(true);
            isPinCreated.Add(false);

            var pinCodes = new List<string>();
            pinCodes.Add("1345");
            pinCodes.Add("5154");
            pinCodes.Add("4789");
            pinCodes.Add("9988");
            pinCodes.Add("7536");

            var regulators = new List<string>();
            regulators.Add("SRA");
            regulators.Add("SRA");
            regulators.Add("CLC");
            regulators.Add("SRA");
            regulators.Add("SRA");
            regulators.Add("CLC");
            regulators.Add("CLC");
            regulators.Add("My Regulator");
            regulators.Add("SRA");
            regulators.Add("SRA");
            regulators.Add("SRA");
            regulators.Add("CLC");
            regulators.Add("CLC");
            regulators.Add("CLC");
            regulators.Add("SRA");
            regulators.Add("SRA");
            regulators.Add("Jims Regulator");
            regulators.Add("CLC");
            regulators.Add("SRA");
            regulators.Add("SRA");

            var telephoneNos = new List<string>();
            telephoneNos.Add("02081234567");
            telephoneNos.Add("02084856782");
            telephoneNos.Add("02081114586");
            telephoneNos.Add("02081547852");
            telephoneNos.Add("02081144778");
            telephoneNos.Add("02083458622");
            telephoneNos.Add("02084545465");
            telephoneNos.Add("02081478852");
            telephoneNos.Add("02081479562");
            telephoneNos.Add("02086458123");
            telephoneNos.Add("02089998654");
            telephoneNos.Add("02081117845");
            telephoneNos.Add("02086695632");
            telephoneNos.Add("02081478523");
            telephoneNos.Add("02088800056");
            telephoneNos.Add("02081234588");
            telephoneNos.Add("02081477785");
            telephoneNos.Add("02088005632");
            telephoneNos.Add("02082001478");
            telephoneNos.Add("02082000447");

            var companies = Builder<Company>.CreateListOfSize(20)
                .All()
                   .With(x => x.Name = "Company " + generator.Generate().ToString("000"))
                   .With(x => x.Address1 = address1.RemoveAndGet(0))
                   .With(x => x.Address2 = address2.RemoveAndGet(0))
                   .With(x => x.TownCity = townCity.RemoveAndGet(0))
                   .With(x => x.County = county.RemoveAndGet(0))
                   .With(x => x.PostCode = postcodes.RemoveAndGet(0))
                   .With(x => x.FirstName = firstName.RemoveAndGet(0))
                   .With(x => x.LastName = lastName.RemoveAndGet(0))
                   .With(x => x.Tel = telephoneNos.RemoveAndGet(0))
                   .With(x => x.RecordCreated = GetRandomDate())
                   .With(x => x.Email = emails.RemoveAndGet(0))
                   .With(x => x.IsVerified = isVerified.RemoveAndGet(0))
                   .With(x => x.Regulator = regulators.RemoveAndGet(0))
                   .With(x => x.OtherRegulator = string.Empty)
                   .With(x => x.IsPinCreated = x.IsVerified ? isPinCreated.RemoveAndGet(0) : false)
                   .With(x => x.PinCode = x.IsPinCreated ? pinCodes.RemoveAndGet(0) : "")
                   .With(x => x.PinCreated = x.IsPinCreated ? GetRandomDate() : (DateTime?)null)
                .Build();

            return companies;
        }

        private DateTime GetRandomDate()
        {
            return GetRandomDate(DateTime.Now.AddDays(-7), DateTime.Now.AddDays(-1));
        }

        private Random m_RandomTest = new Random();

        private DateTime GetRandomDate(DateTime startDate, DateTime endDate)
        {
            TimeSpan timeSpan = endDate - startDate;
            TimeSpan newSpan = new TimeSpan(0, m_RandomTest.Next(0, (int)timeSpan.TotalMinutes), 0);
            return startDate + newSpan;
        }

        
    }
}