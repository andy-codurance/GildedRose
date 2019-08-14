namespace GildedRose.Tests
{
    using Console;
    using FluentAssertions;
    using Xunit;

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