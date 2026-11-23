using Controllers;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Services;
using UI;

using var dbContext = new ProductInventoryContext();
dbContext.Database.Migrate();

// * in memory
// IProductInventoryService service = new ProductInventoryService();

// * in database
// IProductInventoryService service = new ProductDb();

// * db - sqlite
IProductInventoryService service = new ProductDbService(dbContext);

ProductController controller = new(service);
Menu menu = new(controller);

menu.Run();
