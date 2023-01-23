using System.Text.Json.Serialization;

namespace La_Mia_Pizzeria_1.Models {
    public class Ingrediente {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public List<Pizza>? Pizzas { get; set; }

        public Ingrediente() { }
    }
}
