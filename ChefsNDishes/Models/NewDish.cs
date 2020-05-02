using System.Collections.Generic;

namespace ChefsNDishes.Models
{
    public class NewDish
    {
        public Dish Dish { get; set; }
        public List<Chef> Chefs { get; set; }
    }
}