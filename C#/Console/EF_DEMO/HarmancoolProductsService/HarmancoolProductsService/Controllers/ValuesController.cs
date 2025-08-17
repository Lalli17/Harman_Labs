using HarmancoolProductsService.Models.Data;
using HarmancoolProductsService.Models.Domain;
using HarmancoolProductsService.Models.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace HarmancoolProductsService.Controllers
{
    //api indicates the end point
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
       // private HarmanCoolProductsDbContext db = null;// new Models.Data.HarmanCoolProductsDbContext();
                                               //DIP


        private ICoolProductsService service=null; //reference variable

        //public ValuesController(HarmanCoolProductsDbContext db)
        //{
        //    this.db = db;   //no need to do the new object creation rather can use the constructor like this
        //}
        //its not outsourced

        public ValuesController(ICoolProductsService service)
        {
            this.service = service;
        }
        //IOC CANnot create an interface but creates the concrete of an interface





        //private object _mapper;

        // add action methoda - endpoints - map action methods with http methods
        //GET-PUT-POST-DELETE-PATCH



        //return all products 
        //GET www.harman.com/api/Values
        //GET localhost:7104/api/Values
        [HttpGet] //executes the get method 
        [EnableQuery]
        public IQueryable<Product> GetProducts() //action method since its in controller
        {
            //get all products from model/backend/ data layer nd return

           //using (HarmanCoolProductsDbContext db = new Models.Data.HarmanCoolProductsDbContext())
            
               // return db.Products.AsQueryable();
            //clients can query the database

            return service.GetProductsAsync().AsQueryable();
        }


        //insert new product data
        //no change in the uri for get and the post
        //POST localhost:7104//api//Values
        [HttpPost]
        //[Route("insert")] not needed since uri shdnt contain any words and for post default route will work
        [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult PostProduct(Product product)
        {
            //validate the input
            if (ModelState.IsValid==false)
            {
                return BadRequest("Invalid Input");
            }
            //save data
            //db.Products.Add(product);
            //db.SaveChanges();
            service.SaveProductAsync(product);


            //return http status code 201 + location + data
            return Created($"api/Values/{product.Id}",product);

        }
        //get by id

        //localhost:7104/api/Values/123

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        

        public IActionResult GetProductById(int id)
        {
           // using (HarmanCoolProductsDbContext db = new Models.Data.HarmanCoolProductsDbContext())
            {
               // var productToSearch = db.Products.Find(id);
                var productToSearch=service.GetProductById(id);
                
                if (productToSearch != null)
                    return Ok(productToSearch);//200 status with data
                else
                    return NotFound();//404
            }
        }

        //lab 1: get product by name

        //localhost:7104/api/Values/123 has the same as before and thereis an error

        [HttpGet]
        [Route("name/{name:alpha}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetProductByName(string name)
        {
           // using (HarmanCoolProductsDbContext db = new Models.Data.HarmanCoolProductsDbContext())
            {
                //var productToSearch = db.Products.Where(p => p.Name == name).FirstOrDefault();

                var productToSearch = service.GetProductByName(name);

                if (productToSearch != null)
                    return Ok(productToSearch);//200 status with data
                else
                    return NotFound();//404

            }

        }


        //lab2: get products by country
        //uri is the same as the name uri 
        //just by specifing the datatype u cannot differentiate the uri
        [HttpGet]
        [Route("country/{country:alpha}")]//by using the country/ we can differentiate the uri country is the constant and shd have the same name 
        [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetProductByCountry(string country)
        {
            //using (HarmanCoolProductsDbContext db = new Models.Data.HarmanCoolProductsDbContext())
            {
                //  var productToSearch = db.Products.Where(p => p.Country == country).ToList();
                var productToSearch = service.GetProductByCountryAsync(country);
                if (productToSearch != null || productToSearch.length > 0)
                    return Ok(productToSearch);//200 status with data
                else
                    return NotFound();//404

            }

        }

        //lab 3: get products by brand
        //[HttpGet]
        //[Route("brand/{brand:alpha}")]
        //public IActionResult GetProductByBrand(string brand)
        //{
        //    using (HarmanCoolProductsDbContext db = new Models.Data.HarmanCoolProductsDbContext())
        //    {
        //        var products = db.Products.Where(p => p.Brand == brand).ToList();
        //        if (products != null && products.Count > 0)
        //            return Ok(products);
        //        else
        //            return NotFound();
        //    }
        //}

        //lab 4: get cheapest product
        //[HttpGet]
        //[Route("cheapest")]
        //public IActionResult GetCheapestProduct()
        //{
        //    using (HarmanCoolProductsDbContext db = new Models.Data.HarmanCoolProductsDbContext())
        //    {
        //        var cheapest = db.Products.OrderBy(p => p.Price).FirstOrDefault();
        //        if (cheapest != null)
        //            return Ok(cheapest);
        //        else
        //            return NotFound();
        //    }
        //}

        //lab 5: get costliest product
        //[HttpGet]
        //[Route("costliest")]
        //public IActionResult GetCostliestProduct()
        //{
        //    using (HarmanCoolProductsDbContext db = new Models.Data.HarmanCoolProductsDbContext())
        //    {
        //        var costliest = db.Products.OrderByDescending(p => p.Price).FirstOrDefault();
        //        if (costliest != null)
        //            return Ok(costliest);
        //        else
        //            return NotFound();
        //    }
        //}

        //lab 6: get products in stock
        //[HttpGet]
        //[Route("instock")]
        //public IActionResult GetProductsInStock()
        //{
        //    using (HarmanCoolProductsDbContext db = new Models.Data.HarmanCoolProductsDbContext())
        //    {
        //        var products = db.Products.Where(p => p.InStock == true).ToList();
        //        if (products != null && products.Count > 0)
        //            return Ok(products);
        //        else
        //            return NotFound();
        //    }
        //}

        //lab 7: get products between price range (1000 - 5000)
        //[HttpGet]
        //[Route("pricerange/{min:int}/{max:int}")]
        //public IActionResult GetProductsByPriceRange(int min, int max)
        //{
        //    using (HarmanCoolProductsDbContext db = new Models.Data.HarmanCoolProductsDbContext())
        //    {
        //        var products = db.Products.Where(p => p.Price >= min && p.Price <= max).ToList();
        //        if (products != null && products.Count > 0)
        //            return Ok(products);
        //        else
        //            return NotFound();
        //    }
        //}

        //lab 8: get products by category
        //[HttpGet]
        //[Route("category/{category:alpha}")]
        //public IActionResult GetProductsByCategory(string category)
        //{
        //    using (HarmanCoolProductsDbContext db = new Models.Data.HarmanCoolProductsDbContext())
        //    {
        //        var products = db.Products.Where(p => p.Category == category).ToList();
        //        if (products != null && products.Count > 0)
        //            return Ok(products);
        //        else
        //            return NotFound();
        //    }
        //}

        //delete Endpoint
        //uri: .../api/Values/123
        //map the uri
        // [Route("{id}")] //can be clubbed with http method only
        //[HttpDelete]
       
        
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
       

        //map the http action 
        public IActionResult DeleteProduct(int id)
        {
            //var productToDel = db.Products.Find(id);
            var productToDel = service.GetProductById(id);
            if (productToDel == null)
            { 
                return NotFound("Product not found");
            }

            //db.Products.Remove(productToDel);
            //db.SaveChanges();
            service.SoftDeleteProduct(id);

            return Ok();
        }

        //edit product 
        //design the uri
        //map the route
        //map the http action
        //implement the action method
        //[HttpPut("{id:int}")]
        //public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        //{
        //    var productInDb = db.Products.Find(id);
        //    if (productInDb == null)
        //    {
        //        return NotFound("Product not found");
        //    }
        //    productInDb.Name = updatedProduct.Name;
        //    productInDb.Price = updatedProduct.Price;
        //    productInDb.Category = updatedProduct.Category;
        //    productInDb.Brand = updatedProduct.Brand;
        //    productInDb.Country = updatedProduct.Country;
        //    productInDb.InStock = updatedProduct.InStock;

        //    db.SaveChanges();

        //    return Ok("Product updated successfully");
        //}

        //use automappers for updations since many fields may exist

        //[HttpPost]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            //var productInDb = db.Products.Find(id);
            //if (productInDb == null)
            //    return BadRequest("Product not found");
            //these 3 lines will make sure the products.update is not working so when using that comment this
            //if state modified code is needed then comment the products.update()

            // productInDb.Name = product.Name;
            // productInDb.Price = product.Price;
            // productInDb.Category = product.Category;
            // productInDb.Brand = product.Brand;
            // productInDb.Country = product.Country;
            // productInDb.InStock = product.InStock;

            // Map all fields automatically (except Id)

            //use AutoMapper to convert one object into another object

            // _mapper.Map(updatedProduct, productInDb);
            try
            {
               // db.Products.Entry(product).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
               //even after changing the state it may not work since the tracking may be differentiated
                
                // db.Products.Update(product);
                //db.SaveChanges();
                service.EditProduct(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }





    }
}
