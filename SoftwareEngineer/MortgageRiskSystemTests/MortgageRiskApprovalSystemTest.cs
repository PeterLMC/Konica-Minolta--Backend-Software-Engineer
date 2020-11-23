using Microsoft.VisualStudio.TestTools.UnitTesting;
using MortgageRiskSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MortgageRiskSystemTests
{
    [TestClass]
    public class MortgageRiskApprovalSystemTest
    {

        private MortgageRiskApprovalSystem mortageSystem;

        [TestInitialize]
        public void InitMethod()
        {
            mortageSystem = new MortgageRiskApprovalSystem();
        }

        [TestMethod]
        public void When_a_mortgage_is_readed_from_a_file_line_all_state_is_properly_set()
        {
            string fileName = "TestFiles/When_a_mortgage_is_readed_from_a_file_line_all_state_is_properly_assigned.txt";
            IList<MortgageRequest> resquests = mortageSystem.GetInvalidRequests(fileName);
            MortgageRequest expectedMortgage = new MortgageRequest()
            {
                MortageRequestId = 271234,
                ClientId = 1,
                Debts = 50.20f,
                Email = "konica@konicaminolta.es",
                GrossMensualSalary = 0.00f,
                HomeAppraisal = 280000.00f,
                Incomes = 0.00f,
                Nif = "94590756J",
                TelephoneNumber = "652215505",
                AddressNumber = 123,
                City = "Madrid",
                Street = "street micenas",
                ZipCode = "28232",
                State = "Madrid"
            };

            // Check only one mortgage request.
            Assert.IsTrue(resquests.Count == 1);

            // Check not a null request.
            MortgageRequest request = resquests.FirstOrDefault();
            Assert.IsNotNull(request);

            // Check each field mapping is properly done.

            Assert.AreEqual(request.MortageRequestId, expectedMortgage.MortageRequestId);
            Assert.AreEqual(request.ClientId, expectedMortgage.ClientId);
            Assert.AreEqual(request.Debts, expectedMortgage.Debts);
            Assert.AreEqual(request.Email, expectedMortgage.Email);
            Assert.AreEqual(request.GrossMensualSalary, expectedMortgage.GrossMensualSalary);
            Assert.AreEqual(request.HomeAppraisal, expectedMortgage.HomeAppraisal);
            Assert.AreEqual(request.Incomes, expectedMortgage.Incomes);
            Assert.AreEqual(request.Nif, expectedMortgage.Nif);
            Assert.AreEqual(request.TelephoneNumber, expectedMortgage.TelephoneNumber);
            Assert.AreEqual(request.AddressNumber, expectedMortgage.AddressNumber);
            Assert.AreEqual(request.City, expectedMortgage.City);
            Assert.AreEqual(request.Street, expectedMortgage.Street);
            Assert.AreEqual(request.ZipCode, expectedMortgage.ZipCode);
            Assert.AreEqual(request.State, expectedMortgage.State);
        }

        [TestMethod]
        public void mortgages_that_are_valid_are_not_returned()
        {
            int numberOfRequestInvalid = mortageSystem
                .GetInvalidRequests("TestFiles/Mortages_with_data_are_ok_not_returned.txt")
                .Count;

            Assert.AreEqual(0, numberOfRequestInvalid, "Number of request invalird");
        }

        [TestMethod]
        public void Mortage_invalid_characters_in_the_email_are_removed()
        {
            MortgageRequest request = mortageSystem
                .GetInvalidRequests("TestFiles/Mortage_with_invalid_characters_in_the_email_are_removed.txt")
                .FirstOrDefault();

            Assert.AreEqual("konica@konicaminolta.es", request.Email, "The email has not contain # elements");
        }

        [TestMethod]
        public void Mortage_with_invalid_characters_in_the_zipCode_are_removed()
        {
            MortgageRequest request = mortageSystem.GetInvalidRequests("TestFiles/Mortage_with_invalid_characters_in_the_zipCode_are_removed.txt").FirstOrDefault();
            
            Assert.AreEqual("28232", request.ZipCode, "The zipcode has contain not valid character");
        }

        [TestMethod]
        public void Mortgage_the_abbreviation_of_street_is_replaced()
        {
            MortgageRequest request = mortageSystem.GetInvalidRequests("TestFiles/The_abbreviation_of_street_are_removed.txt").FirstOrDefault();

            Assert.AreEqual("street micenas", request.Street, "Street does not contain its abbreviature");
        }

        [TestMethod]
        public void The_abbreviation_of_City_are_replaced()
        {
            MortgageRequest request = mortageSystem.GetInvalidRequests("TestFiles/The_abbreviation_of_City_are_removed.txt").FirstOrDefault();

            Assert.AreEqual("Madrid", request.City, "The city has contain not valid character");
        }

        [TestMethod]
        public void Duplicated_Mortgages_are_not_taken_into_account()
        {
            List<MortgageRequest> requests = mortageSystem.GetInvalidRequests("TestFiles/Repeat_mortgages_with_same_id_are_eliminated.txt").ToList();
            
            Assert.AreEqual(1, requests.Count);
        }

        [TestMethod]
        public void A_Mortgage_is_always_invalid_when_the_client_is_in_the_blacklist()
        {
            List<MortgageRequest> requests = mortageSystem.GetInvalidRequests("TestFiles/When_the_client_is_blacklisted_the_mortgage_is_invalid.txt").ToList();

            Assert.AreEqual(1, requests.Count);
        }

        [TestMethod]
        public void Mortage_is_invalid_when_debts_are_greater_than_incomes()
        {
            MortgageRequest request = mortageSystem.GetInvalidRequests("TestFiles/Mortage_cannot_have_more_debts_than_income.txt").FirstOrDefault();

            Assert.IsTrue(request.Debts > request.Incomes);
        }

        [TestMethod]
        public void Mortage_is_invalid_if_Home_Appraisal_is_more_than_gross_mensual_salary()
        {
            string filePath = "TestFiles/Mortage_is_invalid_if_Home_Appraisal_is_more_than_gross_mensual_salary.txt";
            MortgageRequest request = mortageSystem
                .GetInvalidRequests(filePath)
                .FirstOrDefault();

            Assert.IsTrue(request.HomeAppraisal > request.GrossMensualSalary);
        }

        [TestMethod]
        public void A_mortage_is_invalid_with_no_income_and__no_gross_mensual_salary()
        {
            List<MortgageRequest> requests = mortageSystem.GetInvalidRequests("TestFiles/Mortage_is_invalid_with_zero_income_and_gross_mensual_salary.txt").ToList();

            Assert.AreEqual(1, requests.Count);
        }
    }
}


