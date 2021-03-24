using System;
using System.ComponentModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;

namespace GradeBook.Tests
{
  public class TypeTests
  {

    [Fact]

    public void StringsBehavesLiekValuesTypes()
    {
      string name = "Mateus";
      var upper = MakeUpperCase(name);

      Assert.Equal("Mateus", name);
      Assert.Equal("MATEUS", upper);
    }

    private string MakeUpperCase(string name)
    {
      return name.ToUpper();
    }

    [Fact]
    public void ValueTypeAlsoPassByValue()
    {
      // Arrange
      int x;

      // Act
      x = GetInt();
      SetInt(ref x);

      // Assert
      Assert.Equal(42, x);
    }

    [Fact]
    public void CSharpCanPassByReference()
    {
      // Arrange
      InMemoryBook book1 = GetBook("Book1");

      // Act
      GetBookSetNameByRef(ref book1, "New Name");

      // Assert
      Assert.Equal("New Name", book1.Name);
    }

    [Fact]
    public void CSharpIsPassedByValue()
    {
      // Arrange
      InMemoryBook book1 = GetBook("Book1");

      // Act
      GetBookSetName(book1, "New Name");

      // Assert
      Assert.Equal("Book1", book1.Name);
    }

    [Fact]
    public void CanSetNameFromReference()
    {
      // Arrange
      InMemoryBook book1 = GetBook("Book1");

      // Act
      SetName(book1, "New Name");

      // Assert
      Assert.Equal("New Name", book1.Name);
    }

    [Fact]
    public void GetBookReturnsDifferentObjects()
    {
      // Arrange
      InMemoryBook book1;
      InMemoryBook book2;

      // Act
      book1 = GetBook("Book1");
      book2 = GetBook("Book2");

      // Assert
      Assert.Equal("Book1", book1.Name);
      Assert.Equal("Book2", book2.Name);
      Assert.NotSame(book1, book2);
    }

    [Fact]
    public void TwoVariablesReferenceSameObject()
    {
      // Arrange
      InMemoryBook book1;
      InMemoryBook book2;

      // Act
      book1 = GetBook("Book1");
      book2 = book1;

      // Assert
      Assert.Same(book1, book2);

    }
    private int GetInt()
    {
      return 3;
    }

    static void SetName(InMemoryBook book, string name)
    {
      book.Name = name;
    }

    private void SetInt(ref int z)
    {
      z = 42;
    }

    void GetBookSetNameByRef(ref InMemoryBook book, string name)
    {
      book = new InMemoryBook(name);
    }
    void GetBookSetName(InMemoryBook book, string name)
    {
      book = new InMemoryBook(name);
    }

    static InMemoryBook GetBook(string name)
    {
      return new InMemoryBook(name);
    }
  }
}
