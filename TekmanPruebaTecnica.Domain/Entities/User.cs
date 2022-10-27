using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TekmanPruebaTecnica.Domain.Entities;

[Table("Users")]
public class User
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public ICollection<UserNote> Notes { get; set; } = new List<UserNote>();
}
