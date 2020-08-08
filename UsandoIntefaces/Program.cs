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
            int months = int.Parse(Console.ReadLine());

            Contract contract = new Contract(number, date, contractValue);


            ProcessService processService = new ProcessService(new PayPal());
            processService.ProcessContract(contract, months);
            
            Console.WriteLine("Installments: ");
            foreach (var a in contract.Installments) {
                Console.WriteLine(a);
            }


        }
    }
}
