using Pizzeria.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria.Database
{
    public class Ingredients
    {
        [Key]
        public String IngredientId { set; get; }
        [Required]
        public String Name { set; get; }
        [Required]
        public decimal Price { set; get; }
    }
}
