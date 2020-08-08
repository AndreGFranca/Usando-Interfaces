using System;
using System.Globalization;
using UsandoInterfaces.Entities;
using UsandoInterfaces.Services;

namespace UsandoInterfaces {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Enter contract data");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyy): ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",CultureInfo.InvariantCulture);
            Console.Write("Contract value: ");
            double contractValue = double.Parse(Console.ReadLine());
            Console.Write("Enter number of installments: ");
            int installments = int.Parse(Console.ReadLine());

            Contract contract = new Contract(number, date, contractValue);
            ProcessService processService = new ProcessService(contract, new PayPal());
            
            Console.WriteLine("Installments: ");
            foreach (var a in processService.Total(installments)) {
                Console.WriteLine(a);
            }


        }
    }
}
