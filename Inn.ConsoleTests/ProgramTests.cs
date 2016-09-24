using System.Collections.Generic;
using Inn.Console.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inn.Console.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        IList<Item> TestItems;
        [TestInitialize()]
        public void TestInit()
        {
            TestItems = new List<Item>();
        }

        [TestMethod()]
        public void SulfurasDoesntGetMessedWithTest()
        {
            TestItems.Add(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 });

            var program = new Program()
            {
                Items = TestItems
            };

            program.DailyOperation();

            Assert.AreEqual(0, TestItems[0].SellIn);
            Assert.AreEqual(80, TestItems[0].Quality);
        }

        [TestMethod()]
        public void AgedBrieIncreasesTest()
        {
            TestItems.Add(new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 });

            var program = new Program()
            {
                Items = TestItems
            };

            program.DailyOperation();

            Assert.AreEqual(1, TestItems[0].Quality);
            Assert.AreEqual(1, TestItems[0].SellIn);
        }

        [TestMethod()]
        public void AgedBrieDoubleIncreasesAfterSellInTest()
        {
            TestItems.Add(new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 });

            var program = new Program()
            {
                Items = TestItems
            };

            program.DailyOperation();

            Assert.AreEqual(2, TestItems[0].Quality);
        }

        [TestMethod()]
        public void BackStagePassIncreasesTest()
        {
            TestItems.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 });

            var program = new Program()
            {
                Items = TestItems
            };

            program.DailyOperation();

            Assert.AreEqual(21, TestItems[0].Quality);
        }

        [TestMethod()]
        public void BackStagePassTenOrLessDaysIncreasesTest()
        {
            TestItems.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 });

            var program = new Program()
            {
                Items = TestItems
            };

            program.DailyOperation();

            Assert.AreEqual(22, TestItems[0].Quality);
        }

        [TestMethod()]
        public void BackStagePassFiveOrLessDaysIncreasesTest()
        {
            TestItems.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 });

            var program = new Program()
            {
                Items = TestItems
            };

            program.DailyOperation();

            Assert.AreEqual(23, TestItems[0].Quality);
        }

        [TestMethod()]
        public void BackStagePassZeroOrLessDaysResetsTest()
        {
            TestItems.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 });

            var program = new Program()
            {
                Items = TestItems
            };

            program.DailyOperation();

            Assert.AreEqual(0, TestItems[0].Quality);
        }

        [TestMethod()]
        public void AgedBrieAndBackStagePassDoesntExceedFiftyQualityTest()
        {
            TestItems.Add(new Item { Name = "Aged Brie", SellIn = 2, Quality = 50 });
            TestItems.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 50 });

            var program = new Program()
            {
                Items = TestItems
            };

            program.DailyOperation();

            Assert.AreEqual(50, TestItems[0].Quality);
            Assert.AreEqual(50, TestItems[1].Quality);
        }

        [TestMethod()]
        public void NormalItemDecreasesTest()
        {
            TestItems.Add(new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 });

            var program = new Program()
            {
                Items = TestItems
            };

            program.DailyOperation();

            Assert.AreEqual(6, TestItems[0].Quality);
        }

        [TestMethod()]
        public void NormalItemDecreasesDoubleAfterSellInTest()
        {
            TestItems.Add(new Item { Name = "Elixir of the Mongoose", SellIn = 0, Quality = 7 });

            var program = new Program()
            {
                Items = TestItems
            };

            program.DailyOperation();

            Assert.AreEqual(5, TestItems[0].Quality);
        }

        [TestMethod]
        public void ConjuredItemsDecreaseTwiceAsFast()
        {
            TestItems.Add(new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 });

            var program = new Program()
            {
                Items = TestItems
            };

            program.DailyOperation();

            Assert.AreEqual(4, TestItems[0].Quality);
        }

        [TestMethod]
        public void ConjuredItemsDecreaseTwiceAsFastAfterSellIn()
        {
            TestItems.Add(new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 6 });

            var program = new Program()
            {
                Items = TestItems
            };

            program.DailyOperation();

            Assert.AreEqual(2, TestItems[0].Quality);
        }
    }
}