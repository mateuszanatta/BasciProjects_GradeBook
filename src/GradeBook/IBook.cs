namespace GradeBook
{
  public interface IBook
  {
    void AddGrade(double grade);
    Statistics GetStatistics();
    event GradeAddedDelegate GradeAdded;
    string Name { get; set; }
  }
}