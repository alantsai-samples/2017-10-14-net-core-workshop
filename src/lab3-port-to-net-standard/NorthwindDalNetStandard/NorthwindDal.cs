using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApplication.View
{
    public static class NorthwindDal
    {
        public static string GetEmployeeFromCountry(string filterCountry = "UK")
        {
            var sb = new StringBuilder();
            DataSet dataSet = new DataSet();
            dataSet.ReadXml("northwind.xml");

            DataTable employeeTable = dataSet.Tables["Employees"];

            foreach (DataRow row in employeeTable.Rows)
            {
                var firstName = Convert.ToString(row["FirstName"]);
                var lastName = Convert.ToString(row["LastName"]);
                var country = Convert.ToString(row["Country"]);

                if (country.ToLower() != filterCountry.ToLower())
                {
                    continue;
                }

                sb.AppendLine($"{firstName} {lastName}");
            }

            return sb.ToString();
        }
    }
}
