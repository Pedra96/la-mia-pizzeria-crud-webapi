using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace La_Mia_Pizzeria_1.Models {
    public class CategoriaPizza {
        public int Id { get; set; }
        public string Name { get;set; }

        [JsonIgnore]
        public List<Pizza> Pizzas { get; set; }

        public CategoriaPizza() { }
    }
}
