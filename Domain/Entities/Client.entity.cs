using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
  [Table("client")]
  public class Client
  {
    [Key]
    [Column("uuid")]
    public string Id { get; set; }
    [Column("mail")]
    [Required]
    public string Email { get; set; }
    [Column("password")]
    [Required]
    public string Password { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("phone")]
    public string Phonenumber { get; set; }
  }
}