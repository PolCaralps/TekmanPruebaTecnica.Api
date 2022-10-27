using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TekmanPruebaTecnica.Domain.Entities;

[Table("UserNotes")]
public class UserNote
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public int QuestionId { get; set; }
    public int AnswerNumber { get; set; }
    public string Answer { get; set; } = null!;
    public decimal Note { get; set; }

    public Question? Question { get; set; }

    public void Update(string answer, decimal note) 
    { 
        Answer = answer;
        Note = note;
        AnswerNumber++;
    }

    public static UserNote Create(int userId, int questionId, string answer, decimal note)
    {
        return new UserNote()
        {
            UserId = userId,
            QuestionId = questionId,
            Answer = answer,
            Note = note,
            AnswerNumber = 1
        };
    }
}
