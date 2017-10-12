using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NQuery;

namespace LegacyApplication.View
{
    public static class NorthwindDal
    {
        public static string GetEmployeeFromCountry(string filterCountry = "UK")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml("northwind.xml");

            var dataContext = new DataContext();
            dataContext.AddTablesAndRelations(dataSet);

            var sql = @"
                SELECT  e.FirstName + ' ' + e.LastName
                FROM    Employees e
                WHERE   e.Country = '" + filterCountry + "'";

            var query = new Query(sql, dataContext);
            var results = query.ExecuteDataTable();
            var values = results.Rows.Cast<DataRow>().Select(r => (string)r[0]);
            var result = string.Join(Environment.NewLine, values);

            return result;
        }
    }
}
