using System.ComponentModel.DataAnnotations.Schema;

namespace TekmanPruebaTecnica.Domain.Entities;

[Table("StringQuestions")]
public class StringQuestion: Question
{
    public string CorrectAnswer { get; set; } = null!;

    public override decimal Answer(string answer)
    {
        return CorrectAnswer == answer ? 1 : 0;
    }

    public static StringQuestion Create(string title, string correctAnswer)
    {
        return new StringQuestion()
        {
            Title = title,
            CorrectAnswer = correctAnswer
        };
    }
}
