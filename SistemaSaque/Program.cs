using System;
using SistemaSaque.Entities;
using SistemaSaque.Entities.Exceptions;
using System.Globalization;

namespace SistemaSaque
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter account data: ");
                Console.Write("Number: ");
                int n = int.Parse(Console.ReadLine());
                Console.Write("Holder: ");
                string holder = Console.ReadLine();
                Console.Write("Initial balance($): ");
                double balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Withdraw limit($): ");
                double limit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Account acc = new Account(n, holder, balance, limit);

                Console.WriteLine();
                Console.Write("Enter amount for withdraw: ");
                double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                acc.WithDraw(amount);

                Console.Write("New Balance: ");
                Console.WriteLine(acc.Balance.ToString("F2", CultureInfo.InvariantCulture));

            }
            catch(DomainException e)
            {
                Console.WriteLine("Withdraw error: " + e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Format error: " + e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }
        }
    }
}
