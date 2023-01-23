using La_Mia_Pizzeria_1.CustomValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.ConstrainedExecution;

namespace La_Mia_Pizzeria_1.Models {
    public class Pizza {

        public int Id { get; set; }

        [Required (ErrorMessage ="Questo campo è obbligatorio")]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [Url(ErrorMessage = "Hai inserito un link non valido")]
        [ImageUrlValidation]
        public string Image { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [PriceValidation]
        [StringLength(25)]
        public string Price { get; set; }

        public int CategoriaId { get; set; }
        public CategoriaPizza? Categoria { get; set; }

        public List<Ingrediente>? nIngredienti { get; set; }


        public Pizza() { }

        public Pizza(string title, string description, string image, string price) {

            Title = title;
            Description = description;
            Image = image;
            Price = price;
        }

    }
}

