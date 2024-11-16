using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KurumsalWeb.Models.Model
{
    [Table("Hakkimizda")]
    public class Hakkimizda
    {
        [Key]
        public int HakkimizdaId { get; set; }
        [Required]
        [DisplayName("Açıklama")]
        public string Aciklama { get; set; }

        [DisplayName("Resim")]
        public string ResimURL { get; set; }
    }
}