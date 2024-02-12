using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsProyect.BussinessEntities
{
    public class AdImage
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Ad")]
        [Required(ErrorMessage ="La referencia a e anuncio es requerida")]
        [Display(Name = "Anuncio")]
        public int IdAd { get; set; }

        [Required(ErrorMessage = "La ruta de la imagen es requerida")]
        [MaxLength(200, ErrorMessage = "El maximo de caracteres es de 4000")]
        [Display(Name = "Imagen")]
        public string Path { get; set; } = string.Empty;

        //fuera de la BD
        [NotMapped]
        public int Top_Aux { get; set; } //propiedad de auxiliar
        public Ad Ad { get; set; } = new Ad();

    }
}
