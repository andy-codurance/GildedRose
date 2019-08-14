namespace GildedRose.Tests
{
    using Console;
    using FluentAssertions;
    using Xunit;

    public class Aged_Brie_characteristics
    {
        [Fact]
        public void Quality_increase_by_1_as_sellin_decreases_by_1()
        {
            var item = new Item {Name = "Aged Brie", Quality = 10, SellIn = 10};

            var app = ProgramFactory.Create(item);
            
            app.UpdateQuality();
            
            var actual = new {item.Quality, item.SellIn};
            actual.Should().Be(new {Quality = 11, SellIn = 9});
        }
    }
}