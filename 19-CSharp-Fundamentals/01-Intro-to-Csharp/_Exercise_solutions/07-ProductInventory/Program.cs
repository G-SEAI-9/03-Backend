using Controllers;
using Services;
using UI;

// * in memory
IProductInventoryService service = new ProductInventoryService();

// * in database
// IProductInventoryService service = new ProductDb();

ProductController controller = new(service);
Menu menu = new(controller);

menu.Run();
