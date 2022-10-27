using System.ComponentModel.DataAnnotations.Schema;

namespace TekmanPruebaTecnica.Domain.Entities;

[Table("NumericQuestions")]
public class NumericQuestion : Question
{
    public decimal CorrectAnswer { get; set; }

    public override decimal Answer(string answer)
    {
        if (!decimal.TryParse(answer, out decimal decimalAnswer))
        {
            throw new Exception("Is not numeric answer!");
        }

        return CorrectAnswer == decimalAnswer ? 1 : 0;
    }

    public static NumericQuestion Create(string title, decimal correctAnswer)
    {
        return new NumericQuestion()
        {
            Title = title,
            CorrectAnswer = correctAnswer
        };
    }
}
