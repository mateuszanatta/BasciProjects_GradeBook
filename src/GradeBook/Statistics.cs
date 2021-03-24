using System;
using System.Linq;
using System.Collections.Generic;

namespace GradeBook
{
  public class Statistics
  {
    private List<double> grades { get; set; }

    public Statistics()
    {
      grades = new List<double>();
    }

    public void Add(double grade)
    {
      grades.Add(grade);
    }

    public double HighestGrade()
    {
      return grades.Max();
    }

    public double LowestGrade()
    {
      return grades.Min();
    }

    public double GradeAverage()
    {
      return grades.Average();
    }

    public char LetterAverageGrade()
    {
      return GradeAverage() switch
      {
        var d when d >= 90 => 'A',
        var d when d >= 80 => 'B',
        var d when d >= 70 => 'C',
        var d when d >= 60 => 'D',
        _ => 'F',
      };
    }
  }
}