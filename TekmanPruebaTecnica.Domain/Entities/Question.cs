using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TekmanPruebaTecnica.Domain.Entities;

[Table("Questions")]
public abstract class Question
{
    [Key]
    public int Id { get; set; }
    public int ExerciceId { get; set; }
    public string Title { get; set; } = null!;

    public Exercice? Exercice { get; set; }

    public abstract decimal Answer(string answer);
}
