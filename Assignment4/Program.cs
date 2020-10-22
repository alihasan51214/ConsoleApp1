using System;

namespace Assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataService = new DataService();
            foreach (var elem in dataService.GetOrders())
            {
                Console.WriteLine(elem);
            }
        }
    }
}