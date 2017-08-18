using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria.Database
{
    public class Pizza
    {
        [Key]
        public String PizzaId { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Photo { get; set; }
        public ICollection<Ingredients> Ingredient { get; set; }
        public ICollection<Comment> Coment { get; set; }

        public Pizza()
        {
            Ingredient = new LinkedList<Ingredients>();
            Coment = new LinkedList<Comment>();
        }
    }
}
