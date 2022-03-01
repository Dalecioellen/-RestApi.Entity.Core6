using System.ComponentModel.DataAnnotations;

namespace RestApi.Entity.Core6.Modelos
{
    public class ClientePostRequest
    {
        [Required, MaxLength(100)]
        public string Nome { get; set; }

        public DateTime Data_Nascimento { get; set; }

    }
}
