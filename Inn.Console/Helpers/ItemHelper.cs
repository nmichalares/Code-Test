using Inn.Console.Models;

namespace Inn.Console.Helpers
{
    public class ItemHelper
    {
        public static bool ItemIsLegendary(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        public static bool ItemExpires(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        public static bool ItemIncreasesIncrmentallyBetterTowardsSellIn(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        public static bool ItemPastSellDate(Item item)
        {
            return item.SellIn < 0;
        }

        public static bool ItemIsConjured(Item item)
        {
            return item.Name.Contains("Conjured");
        }

        public static bool ItemGetsBetterWithAge(Item item)
        {
            return item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        public static void ResetItemQuality(Item item)
        {
            item.Quality = item.Quality - item.Quality;
        }
        
        public static void DecreaseSellIn(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }

        public static void HandleIncrementalQualityIncrease(Item item)
        {
            if (item.SellIn < 10)
            {
                AddItemQuality(item);
            }
            if (item.SellIn < 5)
            {
                AddItemQuality(item);
            }
        }

        public static void UpdateDecreasedItemQuality(Item item)
        {
            SubtractItemQuality(item);
            if (ItemPastSellDate(item))
            {
                SubtractItemQuality(item);
            }
        }

        public static void UpdateIncreadedItemQuality(Item item)
        {
            AddItemQuality(item);
            if (ItemPastSellDate(item))
            {
                AddItemQuality(item);
            }
        }


        private static bool ItemIsLessThanMaxQuality(Item item)
        {
            return item.Quality < 50;
        }

        private static bool ItemIsGreaterThanMinQuality(Item item)
        {
            return item.Quality > 0;
        }

        private static void SubtractItemQuality(Item item)
        {
            if (ItemIsGreaterThanMinQuality(item))
            {
                item.Quality--;
                if (ItemIsConjured(item) && ItemIsGreaterThanMinQuality(item))
                {
                    item.Quality--;
                }
            }
        }

        private static void AddItemQuality(Item item)
        {
            if (ItemIsLessThanMaxQuality(item))
            {
                item.Quality++;
            }
        }
    }
}
