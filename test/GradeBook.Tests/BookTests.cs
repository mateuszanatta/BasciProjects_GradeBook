using System;
using Xunit;

namespace GradeBook.Tests
{
  public class BookTests
  {
    [Fact]
    public void BookCalculatesAnAverageGrade()
    {
      //Arrange
      var book = new InMemoryBook("");
      book.AddGrade(89.1);
      book.AddGrade(90.5);
      book.AddGrade(77.3);
      //Act
      var statistics = book.GetStatistics();

      //Assert
      Assert.Equal(85.6, statistics.GradeAverage(), 1);
      Assert.Equal(90.5, statistics.HighestGrade(), 1);
      Assert.Equal(77.3, statistics.LowestGrade(), 1);
      Assert.Equal('B', statistics.LetterAverageGrade());
    }

    [Fact]
    public void AddGradeGreaterThan100ReturnsException()
    {
      // Arrange
      var book = new InMemoryBook("Mateus");

      // Act
      void act() => book.AddGrade(105);

      // Assert
      ArgumentException exception = Assert.Throws<ArgumentException>(act);
      Assert.Equal("Invalid grade", exception.Message);
    }

    [Fact]
    public void AddLetterGradeReturnsException()
    {
      // Arrange
      var book = new InMemoryBook("Mateus");

      // Act
      void act() => book.AddGrade('G');

      // Assert
      ArgumentException exception = Assert.Throws<ArgumentException>(act);
      Assert.Equal("Invalid Letter Grade", exception.Message);
    }
  }
}
