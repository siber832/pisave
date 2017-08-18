using System;
using Xunit;
using PizzeriaTest;
using Pizzeria.Facades;
using Pizzeria.Enums;
using Pizzeria.Database;
using Microsoft.EntityFrameworkCore;

namespace PizzeriaTest
{
    public class PizzaTests
    {

        private FacadePizza Facade;
        private FacadeUsers Facadeuser;
        private DbContextOptions<PizzeriaContext> options;
       
        public PizzaTests()
        {
            options = new DbContextOptionsBuilder<PizzeriaContext>()
                 .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                 .Options;
        }

        [Fact]
        public void InsertPizzaNoError()
        {
            Facade = new FacadePizza() { Context = new PizzeriaContext(options) };
            Errors err = Facade.Insert("Loguin", "Path");
            Assert.Equal(Errors.NO_ERROR, err);
        }
        [Fact]
        public void AddIngredient() {
           
            Facade = new FacadePizza() { Context = new PizzeriaContext(options) };
            Facade.Insert("name","photo");  
        }
        [Fact]
        public void AddComment()
        {
          
            Facade = new FacadePizza() { Context = new PizzeriaContext(options) };
            Facadeuser = new FacadeUsers() { Context = new PizzeriaContext(options) };
            Errors err = Facadeuser.Insert("Loguin", "Password", "Name", "Surname", "Email");
            User user = Facadeuser.GetUser("Loguin");
            Assert.Equal(user.Loguin, "Loguin");
            Facade.Insert("name","photo");
            Pizza pizza = Facade.GetPizza("name");
            Assert.Equal(pizza.Name, "name");
            Facade.AddComment(pizza.PizzaId, user.Id, "blablabñlablabla");
            
        }
    }
}
