using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Fiap.Api.Donation2.Models;

namespace Fiap.Api.Donation1.Models
{

    [Table("Produto")]
    public class ProdutoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdutoId { get; set; }

        public string Nome { get; set; }

        public bool Disponivel { get; set; }

        public string Descricao { get; set; }

        public string SugestaoTroca { get; set; }

        public double Valor { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public DateTime DataExpiracao { get; set; }


        //FOREIGN KEY
        public int UsuarioId { get; set; }
        //NAVIGATION PROPERTY
        [ForeignKey(nameof(UsuarioId))]
        public UsuarioModel Usuario { get; set; }

        //FOREIGN KEY
        public int CategoriaId { get; set; }
        //NAVIGATION PROPERTY
        [ForeignKey(nameof(CategoriaId))]
        public CategoriaModel Categoria { get; set; }

    }
}