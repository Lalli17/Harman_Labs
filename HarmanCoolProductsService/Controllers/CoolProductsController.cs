using HarmanCoolProductsService.Models.Domain;
using HarmanCoolProductsService.Models.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace HarmanCoolProductsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoolProductsController : ControllerBase
    {

        //private HarmansCoolProductsDbContext db = null;// = new Models.Data.HarmansCoolProductsDbContext(); //DIP

        private ICoolProductsService service = null;
        private ILogger<CoolProductsController> logger = null;

        //public CoolProductsController(HarmansCoolProductsDbContext db)
        //{
        //    this.db = db;
        //}

        public CoolProductsController(ICoolProductsService service, ILogger<CoolProductsController> logger)
        {
            this.service = service;
           // this.logger = logger;
        }

        // add action methods - endpoints -  map action methods with HTTP Methods - GET-POST-PUT-DELETE-PATCH
        // 

        // return all products

        [HttpGet]
        [Route("time")]
        [ResponseCache(Duration = 60)]
        public string GetTime()
        {
            return DateTime.Now.ToString();
        }





        // GET www.harman.com/api/
        //  // GET localhost:234234/api/CoolProducts
        [HttpGet]

        [EnableQuery] // for OData

        //[ResponseCache(Duration = 60)]
        public IQueryable<Product> GetProducts() // Action Method
        {
            // get products from model/backend/data layer and return
            //using (HarmansCoolProductsDbContext db = new Models.Data.HarmansCoolProductsDbContext())
            //{
            //return db.Products.AsQueryable();
            return service.GetProductsAsync().Result.AsQueryable();
            //}
        }
        // GET .../api/coorproducts/async
        [HttpGet]
        [Route("async")]
        //[EnableQuery]
        //[EnableCors("AllowAll")]
        public async Task<List<Product>> GetProductsAsync() // Action Method
        {
            // get products from model/backend/data layer and return
            //using (HarmansCoolProductsDbContext db = new Models.Data.HarmansCoolProductsDbContext())
            //{
            //return db.Products.AsQueryable();
            return await service.GetProductsAsync();
            //}
        }

        // get product by id
        //localhost:234234/api/CoolProducts/123
        [HttpGet]
        [Route("{id:int}")]
        //[ProducesResponseType(typeof(Product))]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProdcutByIdAsync(int id)
        {
            //using (HarmansCoolProductsDbContext db = new Models.Data.HarmansCoolProductsDbContext())
            {
                //var prodductToSearch = db.Products.Find(id);
                var productToSearch = await service.GetProductByIdAsync(id);
                if (productToSearch != null)
                    return Ok(productToSearch); // 200 with data
                else
                    return NotFound(); // 404
            }
        }


        //Lab 1: get product by name
        //localhost:234234/api/CoolProducts/name/smartwatch
        [HttpGet]
        [Route("name/{name:alpha}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProductByNameAsync(string name)
        {
            //using (HarmansCoolProductsDbContext db = new Models.Data.HarmansCoolProductsDbContext())
            {
                //var prodductToSearch = db.Products.Where(p => p.Name == name).FirstOrDefault();

                // log the action
                logger.LogInformation($"Searching Product is :{name}");

                var prodductToSearch = await service.GetProductByNameAsync(name);
                if (prodductToSearch != null)
                    return Ok(prodductToSearch); // 200 with data
                else
                    return NotFound(); // 404
            }
        }


        //Lab 2: get products by country

        //localhost:234234/api/CoolProducts/country/india
        [HttpGet]
        [Route("country/{country:alpha}")]
        [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProductByCountryAsync(string country)
        {
            //using (HarmansCoolProductsDbContext db = new Models.Data.HarmansCoolProductsDbContext())
            {
                //var prodductToSearch = db.Products.Where(p => p.Country == country).ToList();
                var prodductToSearch = await service.GetProductsByCountryAsync(country);
                if (prodductToSearch.Count > 0)
                    return Ok(prodductToSearch); // 200 with data
                else
                    return NotFound(); // 404
            }
        }

        // 2:45PM
        //Lab 3: get products by brand
        //Lab 4: get cheapest product
        //Lab 5: get costliest product
        //Lab 6: get products in stock
        //Lab 7: get products bewteen price range (1000 - 5000)
        //Lab 8: get products by category


        // insert new product data
        // POST localhost:234234/api/CoolProducts
        [HttpPost]
        //[Route("insert")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostProductAsync(Product product)
        {
            // Validate the input
            if (ModelState.IsValid == false)
            {
                return BadRequest("Invalid Input"); // 400
            }

            // save data
            //db.Products.Add(product);
            await service.SaveProductAsync(product);
            //db.SaveChanges();

            // return http status code 201 + location + data
            return Created($"api/coolproducts/{product.Id}", product);

        }

        // purpose: delete a resource
        // design uri: .../api/coolproducts/123
        // map the route
        [Route("{id:int}")]
        // map the http action
        //[HttpDelete("{id}")]
        [HttpDelete]
        // implement the action method
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            //var productToDel = db.Products.Find(id);
            var productToDel = await service.GetProductByIdAsync(id);
            if (productToDel == null)
            {
                return NotFound("Product not found");
            }
            //db.Products.Remove(productToDel);
            //db.SaveChanges();
            await service.SoftDeleteProductAsync(productToDel.Id);
            return Ok();

        }

        // purpose: edit product
        // design the uri: PUT .../api/coolproducts/id

        // map the route

        // map the http action
        [HttpPut("{id:int}")]
        // [HttpPatch] research and implement
        // implement the action method
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EditProductAsync(int id, [FromBody] Product product)
        {
            //var productToEdit = db.Products.Find(id);
            //if (productToEdit == null)
            //    return BadRequest("Product not found");

            //productToEdit.Name = product.Name;
            //productToEdit.Price = product.Price;
            //productToEdit.Catagory = product.Catagory;
            //productToEdit.Brand = product.Brand;
            //productToEdit.Country = product.Country;
            //productToEdit.Instock = product.Instock;

            // Research: use Automapper to convert one object into another object
            try
            {
                //db.Products.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                //db.Products.Update(product);
                //db.SaveChanges();
                await service.UpdateProductAsync(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

    }




}
