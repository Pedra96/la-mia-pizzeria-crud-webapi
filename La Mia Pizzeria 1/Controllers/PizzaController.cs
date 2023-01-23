using La_Mia_Pizzeria_1.Database;
using La_Mia_Pizzeria_1.Models;
using La_Mia_Pizzeria_1.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.SqlServer.Server;
using System.Reflection.Metadata.Ecma335;

namespace La_Mia_Pizzeria_1.Controllers {
    //[Authorize]
    public class PizzaController : Controller {

        public IActionResult Index() {
            using PizzeriaContext db = new PizzeriaContext();
            List<Pizza> listaDellePizze = db.Pizze.ToList();

            return View("Index", listaDellePizze);
        }
        public IActionResult Details(int id) {
            using PizzeriaContext db = new PizzeriaContext();
            //un altro modo per associale il titolo della categoria quando si richiama il database
            var PizzaTrovata = db.Pizze.Where(x => x.Id == id).Include(PizzaTrovata => PizzaTrovata.Categoria).Include(PizzaTrovata=>PizzaTrovata.nIngredienti).FirstOrDefault();
            return View(PizzaTrovata);
            /*List<Pizza> listaDellePizze = db.Pizze.ToList();
            foreach (Pizza pizza in listaDellePizze) {
                if (pizza.Id == id) {
                    var categoria = db.CategoriePizze.Where(x => x.Id == pizza.CategoriaId).FirstOrDefault();
                    pizza.Categoria= categoria;
                    return View(pizza);
                }
            }

            return NotFound("Il post con l'id cercato non esiste!");*/ 
        }

        [HttpGet]
        public IActionResult NuovaPizza() {
            using PizzeriaContext db = new();
            List<CategoriaPizza> CategoriaFromDb = db.CategoriePizze.ToList();
            PizzaCategoriaView ModelForView = new();
            List<Ingrediente> IngredientiFromDb= db.ingredientis.ToList();

            //creare una lista di SelectListItem e tradurci all'interno tutti i nostri ingredienti dal db
            ModelForView.Pizza = new();
            ModelForView.Categorie = CategoriaFromDb;
            ModelForView.ListaIngredienti = ConvertItem.ConvertListIngridients();
            return View("NuovaPizza", ModelForView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NuovaPizza(PizzaCategoriaView formdata) {
            using PizzeriaContext db = new PizzeriaContext();
            if (!ModelState.IsValid) {
                List<CategoriaPizza> categorie = db.CategoriePizze.ToList();
                formdata.ListaIngredienti = ConvertItem.ConvertListIngridients();
                formdata.Categorie = categorie;
                return View("NuovaPizza", formdata);
            }
            if (formdata.IngredientiUtenteScelti != null) {
                formdata.Pizza.nIngredienti = new();
                foreach (var ingredienteid in formdata.IngredientiUtenteScelti) {
                    int x=int.Parse(ingredienteid);
                    var ingrediente = db.ingredientis.Where(y => y.Id == x).FirstOrDefault();
                    formdata.Pizza.nIngredienti.Add(ingrediente);
                }
            }
            db.Pizze.Add(formdata.Pizza);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ModificaPizza(int id) {
            using PizzeriaContext db = new();
            var pizzaUpdate = db.Pizze.Where(x => x.Id == id).Include(pizzaUpdate=>pizzaUpdate.nIngredienti).FirstOrDefault();
            if (pizzaUpdate == null) {
                return NotFound("Pizza non presente");
            } else {
                List<CategoriaPizza> CategoriaFromDb = db.CategoriePizze.ToList();
                PizzaCategoriaView ModelForView = new();
                ModelForView.Pizza = pizzaUpdate;
                ModelForView.Categorie = CategoriaFromDb;
                List<Ingrediente> listaIngredientiDb=db.ingredientis.ToList();
                List<SelectListItem> IngredientiUtente= new List<SelectListItem>();
                foreach (var ingrediente in listaIngredientiDb) {
                    bool IngredientePresente = pizzaUpdate.nIngredienti.Any(x => x.Id == ingrediente.Id);
                    SelectListItem IngredienteSingolo = new SelectListItem() { Text = ingrediente.Name, Value = ingrediente.Id.ToString(), Selected = IngredientePresente };
                    IngredientiUtente.Add(IngredienteSingolo);
                }
                ModelForView.ListaIngredienti = IngredientiUtente;

                return View("ModificaPizza", ModelForView);
            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModificaPizza(PizzaCategoriaView formdata) {
            if (!ModelState.IsValid) {
                return View("ModificaPizza", formdata);
            }
            using PizzeriaContext db = new PizzeriaContext();
            Pizza? ModificaPizza = db.Pizze.Where(x => x.Id == formdata.Pizza.Id).Include(ModificaPizza=>ModificaPizza.nIngredienti)
                .FirstOrDefault();
            if (ModificaPizza != null) {
                ModificaPizza.nIngredienti.Clear();
                ModificaPizza.Title = formdata.Pizza.Title;
                ModificaPizza.Price = formdata.Pizza.Price;
                ModificaPizza.Description = formdata.Pizza.Description;
                ModificaPizza.Image = formdata.Pizza.Image;
                ModificaPizza.CategoriaId = formdata.Pizza.CategoriaId;

                if (formdata.IngredientiUtenteScelti != null) {
                    ModificaPizza.nIngredienti = new();
                    foreach (var ingredienteid in formdata.IngredientiUtenteScelti) {
                        int x = int.Parse(ingredienteid);
                        var ingrediente = db.ingredientis.Where(y => y.Id == x).FirstOrDefault();
                        ModificaPizza.nIngredienti.Add(ingrediente);
                    }
                }

                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult EliminaPizza(int id) {
            using PizzeriaContext db = new PizzeriaContext();
            Pizza? EliminaPizza = db.Pizze.Where(x => x.Id == id).FirstOrDefault();
            if (EliminaPizza != null) {
                db.Remove(EliminaPizza);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
