using System;

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {


      Console.WriteLine($"Type in the Student name:");
      string name = Console.ReadLine();

      Book book = new InMemoryBook(name);

      book.GradeAdded += OnGradeAdded;
      EnterGrades(name, book);

      var stats = book.GetStatistics();

      Console.WriteLine($"Student {book.Name}");
      Console.WriteLine($"The average grade is {stats.GradeAverage():N2}");
      Console.WriteLine($"The highest grade is {stats.HighestGrade():N2}");
      Console.WriteLine($"The lowest grade is {stats.LowestGrade():N2}");
      Console.WriteLine($"The lowest grade is {stats.LetterAverageGrade():N2}");
    }

    private static void EnterGrades(string name, IBook book)
    {
      string grade;
      int keepAdding;
      do
      {
        Console.WriteLine($"Type in the Student grade:");
        grade = Console.ReadLine();

        try
        {
          book.AddGrade(double.Parse(grade));
        }
        catch (ArgumentException ex)
        {
          Console.WriteLine(ex.Message);
        }
        catch (FormatException ex)
        {
          Console.WriteLine(ex.Message);
        }

        Console.WriteLine($"Type 1 to continue including grades to {name} or 0 to finish and see the statistics!");

        keepAdding = int.Parse(Console.ReadLine());
      } while (keepAdding == 1);
    }

    static void OnGradeAdded(object sender, EventArgs e)
    {
      Console.WriteLine("A grade was added");
    }
  }
}
