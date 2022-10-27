using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TekmanPruebaTecnica.Domain.Entities;

[Table("Activities")]
public class Activity
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public ActivityCourse Course { get; set; }
    public ActivityType Type { get; set; }
    public ICollection<Exercice> Exercices { get; set; } = new List<Exercice>();

    //public decimal GetNotaFinalUsuari(int userId)
    //{
    //    decimal nota;

    //    foreach (var notaActivitat in Exercices.Where(n => n.UserId == userId))
    //    {
    //        nota += notaActivitat.Nota;
    //    }

    //    return nota;
    //}

    //public abstract decimal CalcularNota(decimal nota);

    public void AddExercice(string title)
    {
        Exercices.Add(Exercice.Create(title));
    }

    public decimal AnswerQuestion(int questionId, string answer)
    {
        var exercice = Exercices.SingleOrDefault(e => e.Questions.Any(q => q.Id == questionId));

        if (exercice is null)
        {
            throw new Exception("Exercice not found!");
        }

        return exercice.AnswerQuestion(questionId, answer);
    }

    public static Activity Create(string title, ActivityCourse course, ActivityType type)
    {
        return new Activity()
        {
            Title = title,
            Course = course,
            Type = type
        };
    }
}

public enum ActivityCourse
{
    Maths,
    Digital,
    Social
}

public enum ActivityType
{
    Activity,
    Exercice,
    SelfEvaluation,
    Test
}
