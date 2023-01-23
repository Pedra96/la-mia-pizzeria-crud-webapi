using Microsoft.AspNetCore.Mvc.Rendering;

namespace La_Mia_Pizzeria_1.Models {
    public class PizzaCategoriaView {
        //la pizza vuota che il mio form dovrà compilare
        public Pizza Pizza { get; set; }

        //Questa lista di categorie servirà per la select
        public List<CategoriaPizza>? Categorie { get; set; }
        //Questa  lista di ingredienti ci servirà nel form per permettere
        //all' utente di selezionare vari ingredienti
        public List<SelectListItem>? ListaIngredienti { get; set;}
        //Predisponiamo il nostro modello per la vista modifica e nuova pizza con questa nuova lista
        //per ricevere gli id degl ingredienti che l'utente ha selezionato.La lista ritornerà in stringa perchè
        //le value passate ad ogni opzione queste dovevano essere string.
        public List<string>? IngredientiUtenteScelti { get; set; }
    }
}
