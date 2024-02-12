using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsProyect.BussinessEntities
{
    public class Ad
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Category")]
        [Required(ErrorMessage ="Agregue la Categoria")]
        [Display(Name = "Categoria")] //para que le aparezca a el usuario como Categoria en español
        public int IdCategory { get; set; }

        [Required(ErrorMessage = "Agregue la Title")]
        [MaxLength(200, ErrorMessage ="El maximo de caracteres es de 200")]
        [Display(Name = "Titulo")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Agregue la descripcion")]
        [MaxLength(200, ErrorMessage = "El maximo de caracteres es de 200")]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Agregue el Precio")]
        [Display(Name = "Precio")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Agregue la fecha")]
        [Display(Name = "Fecha de Registro")]
        public DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "Agregue el estado")]
        [MaxLength(20, ErrorMessage = "El maximo de caracteres es de 20")]
        [Display(Name = "Estado")]
        public string State { get; set; } = string.Empty;

        //propiedades fuera de los campos de la tabla de la BD

        [NotMapped]
        public int Top_Aux { get; set; } //propiedad de auxiliar
        public Category Category { get; set; } = new Category(); //propiedad de navegacion
        public List<AdImage> AdImages { get; set; } = new List<AdImage>();//propiedad de navegacion

    }
}
