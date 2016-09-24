using System.Collections.Generic;
using Inn.Models;
using Inn.Services;

namespace Inn.Console
{
    public class Program
    {
        public IList<ItemForSale> ItemsForSale;
        public Items ItemsService;

        static void Main(string[] args)
        {
            var items = new Items();

            System.Console.WriteLine("Another Day at the Inn.");

            var program = new Program()
            {
                ItemsForSale = items.GetItems(),
                ItemsService = items
            };

            program.DailyOperation();
        }

        public void DailyOperation()
        {
            foreach (var item in ItemsForSale)
            {
                ItemsService.DailyOperation(item);
            }
        }
    }
}
