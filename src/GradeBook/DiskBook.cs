using System;
using System.IO;

namespace GradeBook
{
  public class DiskBook : Book
  {
    public DiskBook(string name) : base(name)
    {
      Name = name;
    }

    public override event GradeAddedDelegate GradeAdded;

    public override void AddGrade(double grade)
    {
      using (StreamWriter writeBook = File.AppendText($"{Name}Book.txt"))
      {
        writeBook.WriteLine(grade);
        GradeAdded?.Invoke(this, new EventArgs());
      }

    }

    public override Statistics GetStatistics()
    {
      var statistics = new Statistics();

      using (var reader = File.OpenText($"{Name}Book.txt"))
      {
        var line = reader.ReadLine();
        while (line != null)
        {
          var number = double.Parse(line);
          statistics.Add(number);
          line = reader.ReadLine();
        }
      }

      return statistics;
    }
  }
}