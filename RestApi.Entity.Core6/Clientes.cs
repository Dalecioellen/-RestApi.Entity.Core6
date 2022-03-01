using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Entity.Core6
{
    [Table (name: "Pessoa_Fisica")]
    public class Clientes
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Nome { get; set; }

        public DateTime Data_Nascimento { get; set; }

        [NotMapped]
        public string Idade { get; set; }

    }
}
