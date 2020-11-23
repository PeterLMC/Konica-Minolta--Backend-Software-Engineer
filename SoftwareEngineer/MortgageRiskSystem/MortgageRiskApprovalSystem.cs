using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;

namespace MortgageRiskSystem
{

    /// <summary>
    ///  Make this code mantenible and extensible.
    ///  The file path parameter is really ugly, please replace it.
    ///  Make defensive programming.
    ///  All the test must pass.
    /// </summary>
    public class MortgageRiskApprovalSystem
    {
        public MortgageRiskApprovalSystem(){}

        public IList<MortgageRequest> GetInvalidRequests(string file)
        {
            List<MortgageRequest> invalidMortgages = new List<MortgageRequest>();
            List<MortgageRequest> mortageRequests = new List<MortgageRequest>();
            string[] lines = File.ReadAllLines(file);
            foreach (string line in lines)
            {
                MortgageRequest mortgageRequest = new MortgageRequest();
                string[] mortgageFields = line.Split(',');
                mortgageRequest.MortageRequestId = int.Parse(mortgageFields[0]);
                mortgageRequest.ClientId = int.Parse(mortgageFields[1]);
                mortgageRequest.Debts = float.Parse(mortgageFields[2], CultureInfo.InvariantCulture);
                mortgageRequest.Email = mortgageFields[3];
                mortgageRequest.GrossMensualSalary = float.Parse(mortgageFields[4], CultureInfo.InvariantCulture);
                mortgageRequest.HomeAppraisal = float.Parse(mortgageFields[5], CultureInfo.InvariantCulture);
                mortgageRequest.Incomes = float.Parse(mortgageFields[6], CultureInfo.InvariantCulture);
                mortgageRequest.Nif = mortgageFields[7];
                mortgageRequest.TelephoneNumber = mortgageFields[8];
                mortgageRequest.AddressNumber = Convert.ToInt32(mortgageFields[9]);
                mortgageRequest.City = mortgageFields[10];
                mortgageRequest.Street = mortgageFields[11];
                mortgageRequest.ZipCode = mortgageFields[12];
                mortgageRequest.State = mortgageFields[13];
                mortageRequests.Add(mortgageRequest);
            }

            foreach (MortgageRequest mortageRequest in mortageRequests) 
            {
                // Normalize state
                mortageRequest.Email = mortageRequest.Email.TrimEnd().Replace("#", "");
                mortageRequest.ZipCode = mortageRequest.ZipCode.TrimEnd().Trim(' ', '!', '"', '·', '$', '%', '&', '/', '(', ')', '=');
                mortageRequest.Street = mortageRequest.Street.Replace("st.", "street").Replace("rd.", "road");
                mortageRequest.City = mortageRequest.City.Replace("Mad.", "Madrid").Replace("Bar.", "Barcelona"); ;            
            }

            MortgageRequest currentRequest;

            List<MortgageRequest> deduplicatedRequests = new List<MortgageRequest>();

            for (int j = 0; j < mortageRequests.Count; j++)
            {
                bool isDuplicatedRequest = false;
                currentRequest = mortageRequests[j];

                for (int i = (j + 1); i < mortageRequests.Count; i++)
                {
                    if (currentRequest.MortageRequestId == mortageRequests[i].MortageRequestId)
                    {
                        isDuplicatedRequest = true;
                    }

                }

                if (isDuplicatedRequest == false)
                    deduplicatedRequests.Add(currentRequest);
            }

            List<int> blackListClientIds = new List<int>();
            blackListClientIds.Add(123);
            blackListClientIds.Add(456);
            blackListClientIds.Add(984);


            foreach (MortgageRequest request in deduplicatedRequests) 
            {
                bool invalidMortgage = false;
                double netSalary = (request.GrossMensualSalary * .25);
                
                if (blackListClientIds.IndexOf(request.ClientId) != -1)
                {
                    invalidMortgage = true;
                }

                if ((request.Incomes == 0) && (request.GrossMensualSalary == 0))
                {
                    invalidMortgage = true;
                }

                if ((request.Debts > (request.Incomes)))
                {
                    invalidMortgage = true;
                }
                
                if ((request.HomeAppraisal / (30 * 12)) > (request.GrossMensualSalary * 0.4)) 
                {
                    invalidMortgage = true;
                }
                

                if (invalidMortgage)
                    invalidMortgages.Add(request);

            }

            return invalidMortgages;
        }
    }
}