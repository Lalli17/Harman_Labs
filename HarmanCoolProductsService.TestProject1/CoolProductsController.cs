using HarmanCoolProductsService.Models.Entities;

namespace HarmanCoolProductsService.TestProject1
{
    
    class MockCoolProductsService : ICoolProductsService
    {
        public Task<Product> GetProductByIdAsync(int id)
        {

        }
    }
    
    
    
    [TestClass]
    public sealed class CoolProductsController
    {
        [TestMethod]
        public void GetProductByIDTest_WithExistingID_ShouldReturnOKResult()
        {
            CoolProductsController target = ;
        }

        [TestMethod]
        public void GetProductByIDTest_WithExistingID_ShouldReturnProduct()
        {

        }
    }
}
