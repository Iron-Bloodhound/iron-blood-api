namespace ironblood.Domain.Tests;
using ironblood.Domain;
using ironblood.Domain.Catalog;

[TestClass]
public class ItemTests
{

    [TestMethod]
    public void Can_Create_New_Item()
    {
        // Arrange
        var item = new Item("Name", "Description", "Brand", 10.00m);

        // Act (empty)

        // Assert
        Assert.AreEqual("Name", item.Name);
        Assert.AreEqual("Description", item.Description);
        Assert.AreEqual("Brand", item.Brand);
        Assert.AreEqual(10.00m, item.Price);
    }
}