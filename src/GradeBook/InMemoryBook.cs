using System;
using System.Linq;
using System.Collections.Generic;

namespace GradeBook
{
  public delegate void GradeAddedDelegate(object sender, EventArgs args);
  public class InMemoryBook : Book
  {
    private List<double> grades;
    public override event GradeAddedDelegate GradeAdded;

    public InMemoryBook(string name) : base(name)
    {
      Name = name;
      grades = new List<double>();
    }
    public override Statistics GetStatistics()
    {
      var statistics = new Statistics();

      foreach (double grade in grades)
        statistics.Add(grade);

      return statistics;
    }
    public override void AddGrade(double grade)
    {
      if (grade >= 0 && grade <= 100)
      {
        grades.Add(grade);
        if (GradeAdded != null)
        {
          GradeAdded(this, new EventArgs());
        }
      }
      else
      {
        throw new ArgumentException($"Invalid {nameof(grade)}");
      }

    }

    public void AddGrade(char letter)
    {
      switch (letter)
      {
        case 'A': AddGrade(90); break;
        case 'B': AddGrade(80); break;
        case 'C': AddGrade(70); break;
        case 'F': AddGrade(60); break;
        default:
          throw new ArgumentException("Invalid Letter Grade");
      }
    }
  }
}