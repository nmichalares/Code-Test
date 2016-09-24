using System.Collections.Generic;
using System.Linq;
using Inn.Data.Interfaces;
using Inn.Models;
using Inn.Models.Extensions;

namespace Inn.Services
{
    public class Items
    {
        private IItems _items;

        public Items()
        {
            _items = new Data.Items();
        }

        public List<ItemForSale> GetItems()
        {
            return _items.LoadItems().Select(i => new ItemForSale(i.Name, i.SellIn, i.Quality)).ToList();
        }

        public void DailyOperation(ItemForSale item)
        {
            if (item.IsLegendary)
            {
                return;
            }

            item.DecreaseSellIn();

            if (item.CanExpire && item.IsPastSellDate)
            {
                item.ResetItemQuality();
                return;
            }

            if (item.IncreasesIncrementallyBetterTowardsSellIn)
            {
                item.HandleIncrementalQualityIncrease();
            }

            if (item.GetsBetterWithAge)
            {
                item.UpdateIncreasedItemQuality();
            }
            else
            {
                item.UpdateDecreasedItemQuality();
            }
        }
    }
}
