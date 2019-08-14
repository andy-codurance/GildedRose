namespace GildedRose.Tests
{
    using Console;
    using FluentAssertions;
    using Xunit;

    public class Sulfuras_characteristics
    {
        [Fact]
        public void Quality_and_sellin_never_changes()
        {
            var item = new Item {Name = "Sulfuras, Hand of Ragnaros", Quality = 80, SellIn = 0};

            var app = ProgramFactory.Create(item);
            
            app.UpdateQuality();
            
            var actual = new {item.Quality, item.SellIn};
            actual.Should().Be(new {Quality = 80, SellIn = 0});
        }
    }
}