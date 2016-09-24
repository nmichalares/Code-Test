using System.Collections.Generic;
using Inn.Models;

namespace Inn.Data.Interfaces
{
    public interface IItems
    {
        List<Item> LoadItems();
    }
}