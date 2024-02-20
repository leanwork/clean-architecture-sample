using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Tests
{
    public class ShoppingCart_Tests
    {
        [Fact]
        public void Should_Add_Item()
        {
            // arrange
            var shoppingCart = new ShoppingCart();

            // act
            shoppingCart.AddItem(new ShoppingCartItem
            {
                Sku = "0001",
                Name = "XPTO",
                UnitPrice = 100M,
                Quantity = 1
            });

            // assert
            Assert.True(shoppingCart.Items.Count() > 0);
        }
    }
}