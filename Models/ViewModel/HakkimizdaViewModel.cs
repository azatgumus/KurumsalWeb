using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.ViewModel
{
    public class HakkimizdaViewModel
    {
        public int? HakkimizdaId { get; set; }
        [Required]
        [DisplayName("Açıklama")]
        public string Aciklama { get; set; }
      
        public string ResimURL { get; set; }

        public HttpPostedFileBase Resim { get; set; }


    }
}