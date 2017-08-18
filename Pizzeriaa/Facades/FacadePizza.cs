using Pizzeria.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pizzeria.Enums;
namespace Pizzeria.Facades
{
    public class FacadePizza
    {
        public PizzeriaContext Context { set; private get; }

        public Errors Insert(String name, String photo) {
            Pizza pizza = new Pizza() { Name = name, Photo = photo };
            try
            {
                Context.Pizzas.Add(pizza);
                Context.SaveChanges();
                return Errors.NO_ERROR;
            } catch(Exception e)
            {
                return Errors.INSERTION_ERROR;
            }
        }
        public Pizza GetPizza(String name)
        {
            Pizza pizza = Context.Pizzas
                    .Where(p => p.Name == name)
                    .FirstOrDefault();
            return pizza;
        }



        public Errors Update()
        {
            return Errors.INSERTION_ERROR;
        }
        public Errors Delete(String PizzaId)
        {
            var pizza = Context.Pizzas.Find( PizzaId);
            Context.Pizzas.Remove(pizza);
            return Errors.INSERTION_ERROR;
        }

        public Errors AddComment(String PizzaId,String UserID,String Text) {
            var pizza = Context.Pizzas.Find(PizzaId);
            User user = Context.Users.Find(UserID);
            pizza.Coment.Add(new Comment {Date= DateTime.Now,Text=Text,User=user });
            //Context.Pizzas.Update(pizza);
            //Context.SaveChanges();
            return Errors.NO_ERROR;
        }

        public Errors AddIngredient(String PizzaId,String Name,decimal Price ) {
            var pizza = Context.Pizzas.Find(PizzaId);
            pizza.Ingredient.Add(new Ingredients {Name=Name,Price=Price });
            Context.Update(pizza);
            Context.SaveChanges();
            return Errors.NO_ERROR;
        }
        
    }
}
