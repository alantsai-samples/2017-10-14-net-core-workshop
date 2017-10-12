using System;
using LegacyApplication.View;

namespace NetCoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NorthwindDal.GetEmployeeFromCountry());
        }
    }
}
