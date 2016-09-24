using System.Collections.Generic;
using Inn.Models;
using Inn.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inn.Console.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        IList<ItemForSale> TestItems;
        [TestInitialize()]
        public void TestInit()
        {
            TestItems = new List<ItemForSale>();
        }

        [TestMethod()]
        public void SulfurasDoesntGetMessedWithTest()
        {
            TestItems.Add(new ItemForSale("Sulfuras, Hand of Ragnaros", 0, 80));

            var program = new Program()
            {
                ItemsForSale = TestItems, ItemsService = new Items()
            };

            program.DailyOperation();

            Assert.AreEqual(0, TestItems[0].SellIn);
            Assert.AreEqual(80, TestItems[0].Quality);
        }

        [TestMethod()]
        public void AgedBrieIncreasesTest()
        {
            TestItems.Add(new ItemForSale("Aged Brie", 2, 0));

            var program = new Program()
            {
                ItemsForSale = TestItems, ItemsService = new Items()
            };

            program.DailyOperation();

            Assert.AreEqual(1, TestItems[0].Quality);
            Assert.AreEqual(1, TestItems[0].SellIn);
        }

        [TestMethod()]
        public void AgedBrieDoubleIncreasesAfterSellInTest()
        {
            TestItems.Add(new ItemForSale("Aged Brie", 0, 0));

            var program = new Program()
            {
                ItemsForSale = TestItems, ItemsService = new Items()
            };

            program.DailyOperation();

            Assert.AreEqual(2, TestItems[0].Quality);
        }

        [TestMethod()]
        public void BackStagePassIncreasesTest()
        {
            TestItems.Add(new ItemForSale("Backstage passes to a TAFKAL80ETC concert", 15, 20));

            var program = new Program()
            {
                ItemsForSale = TestItems, ItemsService = new Items()
            };

            program.DailyOperation();

            Assert.AreEqual(21, TestItems[0].Quality);
        }

        [TestMethod()]
        public void BackStagePassTenOrLessDaysIncreasesTest()
        {
            TestItems.Add(new ItemForSale("Backstage passes to a TAFKAL80ETC concert", 10, 20));

            var program = new Program()
            {
                ItemsForSale = TestItems, ItemsService = new Items()
            };

            program.DailyOperation();

            Assert.AreEqual(22, TestItems[0].Quality);
        }

        [TestMethod()]
        public void BackStagePassFiveOrLessDaysIncreasesTest()
        {
            TestItems.Add(new ItemForSale("Backstage passes to a TAFKAL80ETC concert", 5, 20));

            var program = new Program()
            {
                ItemsForSale = TestItems, ItemsService = new Items()
            };

            program.DailyOperation();

            Assert.AreEqual(23, TestItems[0].Quality);
        }

        [TestMethod()]
        public void BackStagePassZeroOrLessDaysResetsTest()
        {
            TestItems.Add(new ItemForSale("Backstage passes to a TAFKAL80ETC concert", 0, 20));

            var program = new Program()
            {
                ItemsForSale = TestItems, ItemsService = new Items()
            };

            program.DailyOperation();

            Assert.AreEqual(0, TestItems[0].Quality);
        }

        [TestMethod()]
        public void AgedBrieAndBackStagePassDoesntExceedFiftyQualityTest()
        {
            TestItems.Add(new ItemForSale("Aged Brie", 2, 50));
            TestItems.Add(new ItemForSale("Backstage passes to a TAFKAL80ETC concert", 15, 50));

            var program = new Program()
            {
                ItemsForSale = TestItems, ItemsService = new Items()
            };

            program.DailyOperation();

            Assert.AreEqual(50, TestItems[0].Quality);
            Assert.AreEqual(50, TestItems[1].Quality);
        }

        [TestMethod()]
        public void NormalItemDecreasesTest()
        {
            TestItems.Add(new ItemForSale("Elixir of the Mongoose", 5, 7));

            var program = new Program()
            {
                ItemsForSale = TestItems, ItemsService = new Items()
            };

            program.DailyOperation();

            Assert.AreEqual(6, TestItems[0].Quality);
        }

        [TestMethod()]
        public void NormalItemDecreasesDoubleAfterSellInTest()
        {
            TestItems.Add(new ItemForSale("Elixir of the Mongoose", 0, 7));

            var program = new Program()
            {
                ItemsForSale = TestItems, ItemsService = new Items()
            };

            program.DailyOperation();

            Assert.AreEqual(5, TestItems[0].Quality);
        }

        [TestMethod()]
        public void ItemQualityNeverNegativeTest()
        {
            TestItems.Add(new ItemForSale("Elixir of the Mongoose", 0, 0));
            TestItems.Add(new ItemForSale("Elixir of the Mongoose", 0, -5));
           
            var program = new Program()
            {
                ItemsForSale = TestItems, ItemsService = new Items()
            };

            program.DailyOperation();

            Assert.IsTrue(TestItems[0].Quality >= 0);
            Assert.IsTrue(TestItems[1].Quality >= 0);
        }

        [TestMethod()]
        public void ItemQualityNeverAboveFiftyTest()
        {
            TestItems.Add(new ItemForSale("Elixir of the Mongoose", 0, 75));
            TestItems.Add(new ItemForSale("Aged Brie", 0, 75));

            var program = new Program()
            {
                ItemsForSale = TestItems, ItemsService = new Items()
            };

            program.DailyOperation();

            Assert.IsTrue(TestItems[0].Quality <= 50);
            Assert.IsTrue(TestItems[1].Quality <= 50);
        }


        [TestMethod]
        public void ConjuredItemsDecreaseTwiceAsFast()
        {
            TestItems.Add(new ItemForSale("Conjured Mana Cake", 3, 6));

            var program = new Program()
            {
                ItemsForSale = TestItems, ItemsService = new Items()
            };

            program.DailyOperation();

            Assert.AreEqual(4, TestItems[0].Quality);
        }

        [TestMethod]
        public void ConjuredItemsDecreaseTwiceAsFastAfterSellIn()
        {
            TestItems.Add(new ItemForSale("Conjured Mana Cake", 0, 6));

            var program = new Program()
            {
                ItemsForSale = TestItems, ItemsService = new Items()
            };

            program.DailyOperation();

            Assert.AreEqual(2, TestItems[0].Quality);
        }
    }
}