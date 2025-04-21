using CountYourWords.Services;

namespace CountYourWords.Tests
{
    public class SorterTests
    {
        [Fact]
        public void SortWithComparator_ShouldSortStringsAlphabetically_CustomOrder()
        {
            // Arrange
            var input = new List<string> { "banana", "apple", "grape" };
            var expectedOrder = new List<string> { "apple", "banana", "grape" };

            // Act
            var result = Sorter<string>.SortWithComparator(input);

            // Assert
            Assert.Equal(expectedOrder, result);
        }

        [Fact]
        public void SortWithComparator_ShouldHandleAlreadySortedList()
        {
            // Arrange
            var input = new List<string> { "apple", "banana", "grape" };

            // Act
            var result = Sorter<string>.SortWithComparator(input);

            // Assert
            Assert.Equal(input, result);
        }

        [Fact]
        public void SortWithComparator_ShouldHandleEmptyList()
        {
            // Arrange
            var input = new List<string>();

            // Act
            var result = Sorter<string>.SortWithComparator(input);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void SortWithComparator_ShouldHandleSingleItemList()
        {
            // Arrange
            var input = new List<string> { "onlyone" };

            // Act
            var result = Sorter<string>.SortWithComparator(input);

            // Assert
            Assert.Single(result);
            Assert.Equal("onlyone", result[0]);
        }
    }
}