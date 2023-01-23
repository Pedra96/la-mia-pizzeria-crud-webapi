using La_Mia_Pizzeria_1.Database;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace La_Mia_Pizzeria_1.Utils {
    public static class ConvertItem {
        public static List<SelectListItem> ConvertListIngridients() {
            using PizzeriaContext db = new PizzeriaContext();
            List<SelectListItem> listItem = new();
            foreach (var item in db.ingredientis) {
                SelectListItem opzioneItem = new SelectListItem() { Text = item.Name, Value = item.Id.ToString() };
                listItem.Add(opzioneItem);
            }
            return listItem;
        }

    }
}
