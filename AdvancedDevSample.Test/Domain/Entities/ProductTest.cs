using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Exceptions;

namespace AdvancedDevSample.Test.Domain.Entities
{
    public class ProductTest
    {
        [Fact]
        public void ChangePrice_Should_Update_Price_When_Product_Is_Active()
        {
                //Arrange : je prepare un produit valide
                var product = new Product();
                product.ChangePrice(10); //valeur initiale

                //Act : exécute une action
                product.ChangePrice(20);

                // Assert: verification
                Assert.Equal(20, product.Price);

        }

        /*[Fact]
        public void ChangePrice_Should_Throw_Exception_When_Product_Is_Inactive()
        {
            var product = new Product();
            product.ChangePrice(10);

            typeof(Product).GetProperty(nameof(Product.IsActive))!.SetValue(product, false);

            var exception = Assert.Throws<DomainException>(() => product.ChangePrice(20));

            Assert.Equal("Impossible demodifier un produit inactif", exception.Message);

        }*/

        /*[Fact]
        public void ApplyDiscount_Should_Decrease_Price()
        {
            //Arrange
            var product = new Product();
            product.ApplyDiscount(10);

            //Assert
            Assert.Equal(70, product.Price);
        }*/

        [Fact]
        public void ApplyDiscount_Should_Throw_When_Resulting_Price_Is_Invalid()
        {
            //Arrange
            var product = new Product();
            product.ChangePrice(20);

            //Act & Assert
            Assert.Throws<DomainException>(() => product.ApplyDiscount(30));

        }

    }
}
