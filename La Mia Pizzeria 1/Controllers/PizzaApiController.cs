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
        public IActionResult Get() {
        using PizzeriaContext db= new PizzeriaContext();
            List<Pizza> list = db.Pizze.Include(x=>x.nIngredienti).Include(x=>x.Categoria).ToList();

            return Ok(list);

        }
    }
}
