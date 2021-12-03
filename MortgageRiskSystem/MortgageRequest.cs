using System;
using System.Collections.Generic;
using System.Text;

namespace MortgageRiskSystem
{
    public class MortgageRequest
    {
        public int MortageRequestId { get; set; }
        public string City { get; set; }
        public int AddressNumber { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public float HomeAppraisal { get; set; }
        public string Nif { get; set; }
        public string TelephoneNumber { get; set; }
        public double GrossMensualSalary { get; set; }
        public double Incomes { get; set; }
        public double Debts { get; set; }
        public int ClientId { get; set; }
    }
}
