using Inn.Console.Models;

namespace Inn.Console.Helpers
{
    public static class ItemHelper
    {
        private static readonly int MAX_QUALITY = 50;
        private static readonly int MIN_QUALITY = 0;

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
            item.Quality = MIN_QUALITY;
        }

        public static void DecreaseSellIn(Item item)
        {
            item.SellIn--;
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

            AssureItemQualityMinMax(item);
        }

        public static void UpdateIncreadedItemQuality(Item item)
        {
            AddItemQuality(item);
            if (ItemPastSellDate(item))
            {
                AddItemQuality(item);
            }

            AssureItemQualityMinMax(item);
        }


        private static void AssureItemQualityMinMax(Item item)
        {
            if(item.Quality > MAX_QUALITY)
            {
                item.Quality = MAX_QUALITY;
            }

            if (item.Quality < MIN_QUALITY)
            {
                item.Quality = MIN_QUALITY;
            }
        }

        private static void SubtractItemQuality(Item item)
        {
            item.Quality--;
            if (ItemIsConjured(item))
            {
                item.Quality--;
            }
        }

        private static void AddItemQuality(Item item)
        {
            item.Quality++;
        }
    }
}
