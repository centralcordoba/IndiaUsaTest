using Microsoft.VisualStudio.TestTools.UnitTesting;
using webAppTest;
using webAppTest.Controllers;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;

namespace UnitTestProject
{
    [TestClass]
    public class TestProducts
    {
        [TestMethod]
        public void TestUpdateNameProducts()
        {
            Products products = new Products();
            products.Name = "Tesla 2020";
            products.IdProduct = 1;
            products.Description = " More accesories";            
            var controller = new ProductsController();
            var response = controller.PutProducts(1, products);
            var responseGet = controller.GetProducts(1);
            responseGet = JsonConvert.DeserializeObject<Products>(responseGet.ToString());
            Assert.AreEqual(responseGet.Name, products.Name);

        }

        public void TestUpdateQuantityProducts()
        {
            //Obtain Quantity
            var controller = new ProductsController();
            var responseGetFirst = controller.GetProducts(1);
            responseGetFirst = JsonConvert.DeserializeObject<Products>(responseGetFirst.ToString());

            // New Qauntity
            Products products = new Products();
            products.IdProduct = 10;
            products.Quantity = 50 + responseGetFirst.Quantity.Value;

            // Obtain new quantity
            var responseGetSecond = controller.GetProducts(1);
            responseGetSecond = JsonConvert.DeserializeObject<Products>(responseGetSecond.ToString());
            
            
            Assert.AreEqual(responseGetSecond.Quantity, products.Quantity);

        }
    }
}
