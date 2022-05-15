using NUnit.Framework;
using Xunit;
using Kart.WebStore.Services.Services;
using System;
using Kart.WebStore.Domain;


namespace KartWebStoreTest
{
    public class Tests : BaseTest
    {
        private readonly IServiceProvider _serviceProvider;
        public Tests()
        {
       
        }
       

        [Test]
        [Fact]
        public void TestUserFetch()
        {
            var emailId = "vinokar20@gmail.com";
           
            IUserService userService = (IUserService)serviceProvider.GetService(typeof(IUserService));
            
            if (userService != null)
            {
                var user = userService.GetAsync(emailId).Result;
                Assert.True(user?.Email.Equals(emailId));
            }
            else
            {
                Assert.Fail();  
            }
            
        }

       [Test]
       [Fact]

       public void TestProductCreateAndValidate()
        {
            Guid Id = Guid.NewGuid();
            var product = new Product()
            {
                Id = Id,
                Brand = Kart.WebStore.Domain.Util.Brand.Adidas,
                Description = "Test Product Creation",
                DiscountPercent = 12,
                ImageUrl = "p1.jpg",
                Name = "Navy Shirt",
                NewCollection = false,
                Price = 50,
                ProductType = Kart.WebStore.Domain.Util.ProductType.Shirts
            };
            IProductServices productServices = (IProductServices)serviceProvider.GetService(typeof(IProductServices));

            if (productServices != null)
            {

                productServices.CreateProductAsync(product);
                var productAfterSvae = productServices.GetProductAsync(Id);
            }
        }
    }
}