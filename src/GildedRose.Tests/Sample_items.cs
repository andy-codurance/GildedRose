namespace GildedRose.Tests
{
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
            var app = ProgramFactory.Create(
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
            );
            
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

    public class Item_characteristics
    {
        [Fact]
        public void Quality_and_sellin_decreases_by_1_every_day()
        {
            var item = new Item {Name = default, Quality = 10, SellIn = 10};
            
            var app = ProgramFactory.Create(item);

            app.UpdateQuality();
            
            var actual = new { item.Quality, item.SellIn };

            actual.Should().Be(new { Quality = 9, SellIn = 9 });
        }

        [Fact]
        public void Quality_degrades_twice_as_fast_after_sellin_has_passed()
        {
            var item = new Item {Name = default, Quality = 10, SellIn = 0};

            var app = ProgramFactory.Create(item);
            
            app.UpdateQuality();
            
            item.Quality.Should().Be(8);
        }
        
        [Fact]
        public void Quality_is_never_negative()
        {
            var item = new Item {Name = default, Quality = 0, SellIn = 0};

            var app = ProgramFactory.Create(item);
            
            app.UpdateQuality();
            
            item.Quality.Should().BeGreaterOrEqualTo(0);
        }

        [Fact]
        public void Quality_of_an_item_is_never_greater_than_50()
        {
            var item = new Item {Name = default, Quality = 50, SellIn = 0};

            var app = ProgramFactory.Create(item);
            
            app.UpdateQuality();
            
            item.Quality.Should().BeLessOrEqualTo(50);
        }
    }
}