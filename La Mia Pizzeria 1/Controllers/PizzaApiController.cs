using La_Mia_Pizzeria_1.Database;
using La_Mia_Pizzeria_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace La_Mia_Pizzeria_1.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaApiController : ControllerBase {
        [HttpGet]
        public IActionResult Get(string? search) {
        using PizzeriaContext db= new PizzeriaContext();
            List<Pizza> list = new();
            if(search == null|| search=="") {
                list = db.Pizze.Include(x => x.nIngredienti).Include(x => x.Categoria).ToList();
                return Ok(list);
            } else {
                search = search.ToLower();
                list =db.Pizze
                    .Where(x=>x.Title.ToLower().Contains(search))
                    .Include(x => x.nIngredienti)
                    .Include(x => x.Categoria)
                    .ToList();
                return Ok(list);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {

            using PizzeriaContext db = new PizzeriaContext();

            Pizza pizza= db.Pizze.Where(x=>x.Id== id).FirstOrDefault();

            if(pizza == null) {

                return NotFound("La pizza con questo id non è stata trovata");

            }

            return Ok(pizza);
        }
    }
}
