using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TekmanPruebaTecnica.Domain.Entities;

[Table("Exercices")]
public class Exercice
{
    [Key]
    public int Id { get; set; }
    public int ActivityId { get; set; }
    public string Title { get; set; } = null!;

    public Activity? Activity { get; set; }
    public ICollection<Question> Questions { get; set; } = new List<Question>();

    public void AddNumericQuestion(string title, decimal correctAnswer)
    {
        Questions.Add(NumericQuestion.Create(title, correctAnswer));
    }

    public void AddStringQuestion(string title, string correctAnswer)
    {
        Questions.Add(StringQuestion.Create(title, correctAnswer));
    }

    public decimal AnswerQuestion(int questionId, string answer)
    {
        var question = Questions.SingleOrDefault(q => q.Id == questionId);

        if (question is null)
        {
            throw new Exception("Question not found!");
        }

        return question.Answer(answer);
    }

    public static Exercice Create(string title)
    {
        return new Exercice()
        {
            Title = title,
        };
    }
}
