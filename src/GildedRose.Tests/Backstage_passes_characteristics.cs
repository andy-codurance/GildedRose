namespace GildedRose.Tests
{
    using Console;
    using FluentAssertions;
    using Xunit;

    public class Backstage_passes_characteristics
    {
        [Theory]
        [InlineData(11, 13)]
        [InlineData(10, 14)]
        [InlineData(9, 14)]
        [InlineData(5, 15)]
        [InlineData(1, 15)]
        [InlineData(0, 0)]
        public void The_rate_quality_improves_by_increases_closer_to_sellin(int sellIn, int expectedQuality)
        {
            var item = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 12, SellIn = sellIn};
            
            var app = ProgramFactory.Create(item);
            
            app.UpdateQuality();
            
            item.Quality.Should().Be(expectedQuality);
        }
    }
}