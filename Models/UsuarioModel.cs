using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Api.Donation2.Models
{
    [Table("Usuario")]
    public class UsuarioModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string NomeUsuario { get; set; }
        
        [Required]
        [MaxLength(80)]
        public string EmailUsuario { get; set; }
        
        [Required]
        public string Senha { get; set; }
        
        [Required]
        public string Regra { get; set; }
    }
}
