namespace GildedRose.Tests
{
    using System.Collections.Generic;
    using System.Text;
    using Console;
    using FluentAssertions;
    using Xunit;
    using static System.Environment;

    public class Sample_items
    {
        private string GoldMaster = "+5 Dexterity Vest: quality is 19, sell in 9 days" + NewLine +
                                    "Aged Brie: quality is 1, sell in 1 days" + NewLine +
                                    "Elixir of the Mongoose: quality is 6, sell in 4 days" + NewLine +
                                    "Sulfuras, Hand of Ragnaros: quality is 80, sell in 0 days" + NewLine +
                                    "Backstage passes to a TAFKAL80ETC concert: quality is 21, sell in 14 days" + NewLine +
                                    "Conjured Mana Cake: quality is 5, sell in 2 days" + NewLine;

        [Fact]
        public void Match_gold_master()
        {
            var app = new Program
            {
                Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                }
            };
            app.UpdateQuality();

            var output = Print(app);

            output.Should().Be(GoldMaster);
        }

        private static string Print(Program app)
        {
            var output = new StringBuilder();
            foreach (var item in app.Items)
            {
                output.AppendLine($"{item.Name}: quality is {item.Quality}, sell in {item.SellIn} days");
            }
            return output.ToString();
        }
    }

    public class Normal_item
    {
        [Fact]
        public void Quality_and_sellin_decreases_by_1_every_day()
        {
            var item = new Item {Name = default, Quality = 10, SellIn = 10};
            
            var app = new Program
            {
                Items = new[]
                {
                    item
                }
            };
            
            app.UpdateQuality();
            
            var actual = new { item.Quality, item.SellIn };

            actual.Should().Be(new { Quality = 9, SellIn = 9 });
        }
    }
}