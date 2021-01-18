using System.ComponentModel.DataAnnotations;

namespace CursosEAD.Domain.Entities
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
