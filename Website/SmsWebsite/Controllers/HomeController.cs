using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmsWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home";
            ViewBag.Meta = "The Safe Move Scheme makes it easier to reduce risk from property transactions and helps prevent fraud.";
            return View();
        }

        public ActionResult ContactUs()
        {
            ViewBag.Title = "Contact us";
            ViewBag.Meta = "Get in touch with BE Consultancy Ltd.";
            return View();
        }

        public ActionResult ThreatsExplained()
        {
            ViewBag.Title = "Threats Explained";
            ViewBag.Meta = "It has never been a more dangerous time to buy or sell a property as criminals are targeting property transactions to steal large amounts of money from buyers and lenders.";
            return View();
        }

        public ActionResult BuyersAtRisk()
        {
            ViewBag.Title = "Buyers at Risk";
            ViewBag.Meta = "Buyers are at risk from cybercrime as criminals are using highly sophisticated scams to steal buyer’s money.";
            return View();
        }

        public ActionResult ConveyancersAtRisk()
        {
            ViewBag.Title = "Conveyancers At Risk";
            ViewBag.Meta = "Conveyancers are at risk from the threats of cybercrime and new anti money laundering regulations targeting the legal sector and specifically conveyancing.";
            return View();
        }

        public ActionResult HowItWorks()
        {
            ViewBag.Title = "How It Works";
            ViewBag.Meta = "The Safe Buyer product reduces the risk of criminals stealing the money that a buyer puts towards the price of their property purchase.";
            return View();
        }

        public ActionResult SafeBuyerSpecification()
        {
            ViewBag.Title = "Safe Buyer Specification";
            ViewBag.Meta = "Check bank account details securely. Protect Additional buyers and giftors. Comply with the latest AML regulations.";
            return View();
        }

        public ActionResult FreeTrial()
        {
            ViewBag.Title = "Free Safe Buyer Product Trial Until 31st Jan 2016";
            ViewBag.Meta = "Free Safe Buyer Product Trial Until 31st Jan 2016";
            return View();
        }

        public ActionResult SafeMoveSchemeBenefits()
        {
            ViewBag.Title = "Safe Move Scheme Benefits";
            ViewBag.Meta = "The Safe Move Scheme gives lenders and conveyancers a customer outcomes control system to meet FCA and SRA anti-fraud requirements.";
            return View();
        }

        public ActionResult NewAMLSolution()
        {
            ViewBag.Title = "New AML Solution";
            ViewBag.Meta = "Full money flow audit showing money flows through bank accounts for every transaction.";
            return View();
        }

        public ActionResult ConveyancersCompliance()
        {
            ViewBag.Title = "Conveyancer's Compliance";
            ViewBag.Meta = "It is an essential part of your obligations that you assess the risks to your organisation’s information security with the same vigour as you would for any other serious risk.";
            return View();
        }

        public ActionResult LendersCompliance()
        {
            ViewBag.Title = "Lender's Compliance";
            ViewBag.Meta = "The Financial Conduct Authority states: 'You are responsible for making sure your business is not vulnerable to fraud – whether you are exposing it to unscrupulous customers or organised mortgage fraud gangs'.";
            return View();
        }

        public ActionResult ConveyancingFirmRegistration()
        {
            ViewBag.Title = "Conveyancing Firm Registration";
            ViewBag.Meta = "Register your conveyancing firm for the Safe Move Scheme here.";
            return View();
        }

        public ActionResult ForThePublic()
        {
            ViewBag.Title = "For the Public";
            ViewBag.Meta = "The Safe Move Scheme enables you and your conveyancer to carry out checks that reduce the likelihood of fraud occurring and protect you from financial loss.";
            return View();
        }

        public ActionResult AboutUs()
        {
            ViewBag.Title = "About us";
            ViewBag.Meta = "Since 2006 BE Consultancy has been working with conveyancers and lenders providing bespoke risk solutions to help make conveyancing better for them and their customers.";
            return View();
        }
    }
}