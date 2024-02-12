using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsProyect.BussinessEntities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        //anotaciones de validacion
        [Required(ErrorMessage ="Este campo es obligatorio")]
        [StringLength (50, ErrorMessage = "Maximo de caracteres 50")]
        public string Name { get; set; } = string.Empty; //inicializo qeu es un string de logitud cero

        //OTRAS QUE NO ESTAN EN LA Bd
        [NotMapped]
        public int Top_Aux { get; set; } //controla cuantos registros quiero traer
        public List<Ad> Ads { get; set; } = new List<Ad>(); //esto esta iniicado con algo que significa que es una lista de logitud cero
    }
}
