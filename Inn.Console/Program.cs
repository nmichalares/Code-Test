using System.Collections.Generic;
using Inn.Console.Models;
using static Inn.Console.Helpers.ItemHelper;

namespace Inn.Console
{
    public class Program
    {
        public IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("Another Day at the Inn.");

            var program = new Program()
            {
                Items = new List<Item>
                {
                    new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                    new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                    new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                    new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                    new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
                    new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
                }
            };

            program.DailyOperation();
        }

        public void DailyOperation()
        {
            foreach (var item in Items)
            {
                if (ItemIsLegendary(item))
                {
                    continue;
                }

                DecreaseSellIn(item);

                if (ItemExpires(item) && ItemPastSellDate(item))
                {
                    ResetItemQuality(item);
                    continue;
                }

                if (ItemIncreasesIncrmentallyBetterTowardsSellIn(item))
                {
                    HandleIncrementalQualityIncrease(item);
                }

                if (ItemGetsBetterWithAge(item))
                {
                    UpdateIncreadedItemQuality(item);
                }
                else
                {
                    UpdateDecreasedItemQuality(item);
                    continue;
                }
            }
        }
    }
}
