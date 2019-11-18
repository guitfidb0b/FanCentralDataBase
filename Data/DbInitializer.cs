using System;
using System.Linq;
using FanCentral2.Models;

namespace FanCentral2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDBContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any Customers.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            // Add Products
            var products = new Product[]
            {
                new Product { Description = "Men's Nike Gardner Minshew II Teal Jacksonville Jaguars Game Jersey",
                ImageName = "product-001.jpeg", Price = (decimal)99.99 },
                new Product { Description = "Men's Nike Gardner Minshew II Black Jacksonville Jaguars Game Jersey",
                ImageName = "product-002.jpeg", Price = (decimal)99.99 },
                new Product { Description = "Men's Nike Black Jacksonville Jaguars Custom Team Color Game Jersey", 
                ImageName = "product-003.jpeg", Price = (decimal)149.99 },
                new Product { Description = "Men's Nike Teal Jacksonville Jaguars Custom Alternate Game Jersey", 
                ImageName = "product-004.jpeg", Price = (decimal)149.99 },
                new Product { Description = "Men's Nike Teal Jacksonville Jaguars Vapor Untouchable Elite Custom Jersey", 
                ImageName = "product-005.jpeg", Price = (decimal)369.99 },
                new Product { Description = "Men's Nike Jacksonville Jaguars Tan 2019 Salute to Service Sideline Therma Pullover Hoodie", 
                ImageName = "product-006.jpeg", Price = (decimal)99.99 },
                new Product { Description = "Men's NFL Pro Line by Fanatics Branded Gardner Minshew II Teal Jacksonville Jaguars Authentic Stack Name & Number T-Shirt", 
                ImageName = "product-007.jpeg", Price = (decimal)31.99 },
                new Product { Description = "Men's Gardner Minshew II Teal Jacksonville Jaguars Tri-Blend Player Graphic T-Shirt", 
                ImageName = "product-008.jpeg", Price = (decimal)41.99 },
                new Product { Description = "Women's Nike Gardner Minshew II Black Jacksonville Jaguars Game Jersey", 
                ImageName = "product-009.jpeg", Price = (decimal)99.99 },
                new Product { Description = "Women's Nike Teal Jacksonville Jaguars Custom Alternate Game Jersey", 
                ImageName = "product-010.jpeg", Price = (decimal)149.99 },
                new Product { Description = "Women's Nike Gardner Minshew II Teal Jacksonville Jaguars Game Jersey", 
                ImageName = "product-011.jpeg", Price = (decimal)99.99 },
                new Product { Description = "Women's Gardner Minshew II Teal Jacksonville Jaguars Tri-Blend Player Graphic T-Shirt", 
                ImageName = "product-012.jpeg", Price = (decimal)41.99 },
                new Product { Description = "Women's NFL Pro Line by Fanatics Branded Gardner Minshew II Teal Jacksonville Jaguars Authentic Stack Name & Number V-Neck T-Shirt", 
                ImageName = "product-013.jpeg", Price = (decimal)31.99},
                new Product { Description = "Youth Nike Gardner Minshew II Teal Jacksonville Jaguars Game Jersey", 
                ImageName = "product-014.jpeg", Price = (decimal)74.99},
                new Product { Description = "Youth Nike Gardner Minshew II Black Jacksonville Jaguars Game Jersey", 
                ImageName = "product-015.jpeg", Price = (decimal)74.99},
                new Product { Description = "Youth Gardner Minshew II Teal Jacksonville Jaguars Mainliner Name & Number T-Shirt", 
                ImageName = "product-016.jpeg", Price = (decimal)24.99},
                new Product { Description = "Youth NFL Pro Line by Fanatics Branded Black Jacksonville Jaguars Zone Team Pullover Hoodie", 
                ImageName = "product-017.jpeg", Price = (decimal)44.99},
                new Product { Description = "Youth Heathered Gray Jacksonville Jaguars Long Sleeve T-Shirt & Pants Sleep Set", 
                ImageName = "product-018.jpeg", Price = (decimal)31.99},
                new Product { Description = "Men's G-III Sports by Carl Banks Black/Charcoal Jacksonville Jaguars Extreme Special Team Pullover Hoodie", 
                ImageName = "product-019.jpeg", Price = (decimal)74.99},
                new Product { Description = "Men's Nike Black Jacksonville Jaguars Sideline Performance Full-Zip Hoodie", 
                ImageName = "product-020.jpeg", Price = (decimal)71.99},
                new Product { Description = "Men's Nike Heathered Gray Jacksonville Jaguars Club Fleece Pullover Hoodie", 
                ImageName = "product-021.jpeg", Price = (decimal)74.99},
                new Product { Description = "Men's New Era Gardner Minshew II Black Jacksonville Jaguars Minshew Mania 9TWENTY Adjustable Hat", 
                ImageName = "product-022.jpeg", Price = (decimal)24.99},
                new Product { Description = "Men's New Era Josh Lambo White/Teal Jacksonville Jaguars Design Lab 9FIFTY Snapbacks Hat", 
                ImageName = "product-023.jpeg", Price = (decimal)33.99},
                new Product { Description = "Men's New Era Olive Jacksonville Jaguars 2019 Salute to Service Sideline 39THIRTY Flex Hat", 
                ImageName = "product-024.jpeg", Price = (decimal)35.99},
                new Product { Description = "Men's New Era Heather Gray Jacksonville Jaguars 2019 NFL Crucial Catch 39THIRTY Flex Hat", 
                ImageName = "product-025.jpeg", Price = (decimal)35.99},
                new Product { Description = "Men's New Era Woodland Camo/Black Jacksonville Jaguars Trucker 9FIFTY Snapback Adjustable Hat", 
                ImageName = "product-026.jpeg", Price = (decimal)32.99},
                new Product { Description = "Nike Jacksonville Jaguars Sphere Fan Gloves", 
                ImageName = "product-027.jpeg", Price = (decimal)34.99},
                new Product { Description = "Women's Jacksonville Jaguars Gloves And Scarf Set", 
                ImageName = "product-028.jpeg", Price = (decimal)24.74},
                new Product { Description = "Men's Oakley Jacksonville Jaguars Holbrook Sunglasses", 
                ImageName = "product-029.jpeg", Price = (decimal)176},
                new Product { Description = "Men's Concepts Sport Black Jacksonville Jaguars Infuse Boxer Briefs", 
                ImageName = "product-030.jpeg", Price = (decimal)29.99},
                new Product { Description = "Jacksonville Jaguars IPhone Glitter Case with Confetti Design", 
                ImageName = "product-031.jpeg", Price = (decimal)29.99},
                new Product { Description = "WinCraft Gardner Minshew II Jacksonville Jaguars 3' x 5' Flag", 
                ImageName = "product-032.jpeg", Price = (decimal)39.99},
                new Product { Description = "Riddell Jacksonville Revolution Speed Mini Football Helmet", 
                ImageName = "product-033.jpeg", Price = (decimal)29.99},
                new Product { Description = "Youth Franklin Sports Jacksonville Jaguars Deluxe Uniform Set", 
                ImageName = "product-034.jpeg", Price = (decimal)43.99},
                new Product { Description = "D.J. Chark Jacksonville Jaguars Autographed 11\" x 14\" Catch vs. Kansas City Chiefs Photograph", 
                ImageName = "product-035.jpeg", Price = (decimal)39.99},
                new Product { Description = "D.J. Chark Jacksonville Jaguars Autographed White Panel Football", 
                ImageName = "product-036.jpeg", Price = (decimal)63.99},
                new Product { Description = "Jacksonville Jaguars Black Base Football Logo Display Case with Mirror Back", 
                ImageName = "product-037.jpeg", Price = (decimal)59.99},
                new Product { Description = "Highland Mint Jacksonville Jaguars Silver Game Coins", 
                ImageName = "product-038.jpeg", Price = (decimal)29.99},
                new Product { Description = "Men's NFL Pro Line by Fanatics Branded Black/Gray Jacksonville Jaguars Home & Away Two-Pack Polo Set", 
                ImageName = "product-039.jpeg", Price = (decimal)52.49},
                new Product { Description = "Men's Jacksonville Jaguars Big Logo Scuff Slippers", 
                ImageName = "product-040.jpeg", Price = (decimal)17.24},
                new Product { Description = "Men's NFL Pro Line by Fanatics Branded Black Jacksonville Jaguars Team Pride T-Shirt", 
                ImageName = "product-041.jpeg", Price = (decimal)18.74},
                new Product { Description = "Men's NFL Pro Line by Fanatics Branded Black/Gray Jacksonville Jaguars Square Up T-Shirt Combo Set", 
                ImageName = "product-042.jpeg", Price = (decimal)33.74},
                new Product { Description = "Women's NFL Pro Line by Fanatics Branded Black/Gray Jacksonville Jaguars Square V-Neck T-Shirt & Long Sleeve T-Shirt Combo Set", 
                ImageName = "product-043.jpeg", Price = (decimal)33.74},
                new Product { Description = "Men's Nike Tan Jacksonville Jaguars 2019 Salute to Service Sideline Performance Long Sleeve Shirt", 
                ImageName = "product-044.jpeg", Price = (decimal)39.99},
                new Product { Description = "Men's New Era Black Jacksonville Jaguars 2019 Salute to Service 39THIRTY Flex Hat", 
                ImageName = "product-045.jpeg", Price = (decimal)35.99},
                new Product { Description = "Men's New Era Olive Jacksonville Jaguars 2019 Salute to Service Sideline Cuffed Knit Hat", 
                ImageName = "product-046.jpeg", Price = (decimal)31.99},
                new Product { Description = "Women's Nike Khaki Jacksonville Jaguars 2019 Salute to Service Therma Pullover Hoodie", 
                ImageName = "product-047.jpeg", Price = (decimal)84.99}
            };
            foreach (Product i in products)
            {
                context.Products.Add(i);
            }
            context.SaveChanges();

            // Add Categories

            var categories = new Category[]
            {
                new Category {CategoryName = "Men"},
                new Category {CategoryName = "Women"},
                new Category {CategoryName = "Kids"},
                new Category {CategoryName = "Jerseys"},
                new Category {CategoryName = "Shirts"},
                new Category {CategoryName = "Sweatshirts"},
                new Category {CategoryName = "Hats"},
                new Category {CategoryName = "Accessories"},
                new Category {CategoryName = "Collectibles"},
                new Category {CategoryName = "Home & Office"},
                new Category {CategoryName = "Clearance"},
                new Category {CategoryName = "Salute to Service"},
                new Category {CategoryName = "NFL 100"},
                new Category {CategoryName = "Wear Collection"},
                new Category {CategoryName = "Minshew II"},
                new Category {CategoryName = "Season 25"},
                new Category {CategoryName = "Retired Players"},
                new Category {CategoryName = "Brand"},
                new Category {CategoryName = "Sideline Collection"},
                new Category {CategoryName = "Players"},
                new Category {CategoryName = "Custom"},
                new Category {CategoryName = "All Categories"}
            };

            foreach (Category i in categories)
            {
                context.Categories.Add(i);
            }
            context.SaveChanges();

            // Add ProductCategories

            var productCategories = new ProductCategory[]
            {
                new ProductCategory {ProductID = 1, CategoryID = 1},
                new ProductCategory {ProductID = 1, CategoryID = 4},
                new ProductCategory {ProductID = 1, CategoryID = 15},
                new ProductCategory {ProductID = 1, CategoryID = 20},
                new ProductCategory {ProductID = 2, CategoryID = 1},
                new ProductCategory {ProductID = 2, CategoryID = 4},
                new ProductCategory {ProductID = 2, CategoryID = 15},
                new ProductCategory {ProductID = 2, CategoryID = 20},
                new ProductCategory {ProductID = 3, CategoryID = 1},
                new ProductCategory {ProductID = 3, CategoryID = 4},

                new ProductCategory {ProductID = 3, CategoryID = 21},
                new ProductCategory {ProductID = 4, CategoryID = 1},
                new ProductCategory {ProductID = 4, CategoryID = 4},
                new ProductCategory {ProductID = 4, CategoryID = 21},
                new ProductCategory {ProductID = 5, CategoryID = 1},
                new ProductCategory {ProductID = 5, CategoryID = 4},
                new ProductCategory {ProductID = 5, CategoryID = 21},
                new ProductCategory {ProductID = 6, CategoryID = 1},
                new ProductCategory {ProductID = 6, CategoryID = 6},
                new ProductCategory {ProductID = 6, CategoryID = 12},

                new ProductCategory {ProductID = 7, CategoryID = 1},
                new ProductCategory {ProductID = 7, CategoryID = 5},
                new ProductCategory {ProductID = 7, CategoryID = 15},
                new ProductCategory {ProductID = 8, CategoryID = 1},
                new ProductCategory {ProductID = 8, CategoryID = 5},
                new ProductCategory {ProductID = 8, CategoryID = 15},
                new ProductCategory {ProductID = 9, CategoryID = 2},
                new ProductCategory {ProductID = 9, CategoryID = 4},
                new ProductCategory {ProductID = 9, CategoryID = 15},
                new ProductCategory {ProductID = 9, CategoryID = 20},

                new ProductCategory {ProductID = 10, CategoryID = 2},
                new ProductCategory {ProductID = 10, CategoryID = 4},
                new ProductCategory {ProductID = 10, CategoryID = 21},
                new ProductCategory {ProductID = 11, CategoryID = 2},
                new ProductCategory {ProductID = 11, CategoryID = 4},
                new ProductCategory {ProductID = 11, CategoryID = 15},
                new ProductCategory {ProductID = 11, CategoryID = 20},
                new ProductCategory {ProductID = 12, CategoryID = 2},
                new ProductCategory {ProductID = 12, CategoryID = 5},
                new ProductCategory {ProductID = 12, CategoryID = 15},

                new ProductCategory {ProductID = 13, CategoryID = 2},
                new ProductCategory {ProductID = 13, CategoryID = 5},
                new ProductCategory {ProductID = 13, CategoryID = 15},
                new ProductCategory {ProductID = 14, CategoryID = 3},
                new ProductCategory {ProductID = 14, CategoryID = 4},
                new ProductCategory {ProductID = 14, CategoryID = 15},
                new ProductCategory {ProductID = 15, CategoryID = 3},
                new ProductCategory {ProductID = 15, CategoryID = 4},
                new ProductCategory {ProductID = 15, CategoryID = 15},
                new ProductCategory {ProductID = 16, CategoryID = 3},

                new ProductCategory {ProductID = 16, CategoryID = 5},
                new ProductCategory {ProductID = 16, CategoryID = 15},
                new ProductCategory {ProductID = 16, CategoryID = 20},
                new ProductCategory {ProductID = 17, CategoryID = 3},
                new ProductCategory {ProductID = 17, CategoryID = 6},
                new ProductCategory {ProductID = 18, CategoryID = 3},
                new ProductCategory {ProductID = 18, CategoryID = 5},
                new ProductCategory {ProductID = 18, CategoryID = 10},
                new ProductCategory {ProductID = 19, CategoryID = 1},
                new ProductCategory {ProductID = 19, CategoryID = 6},

                new ProductCategory {ProductID = 20, CategoryID = 1},
                new ProductCategory {ProductID = 20, CategoryID = 6},
                new ProductCategory {ProductID = 20, CategoryID = 18},
                new ProductCategory {ProductID = 21, CategoryID = 1},
                new ProductCategory {ProductID = 21, CategoryID = 6},
                new ProductCategory {ProductID = 21, CategoryID = 18},
                new ProductCategory {ProductID = 22, CategoryID = 1},
                new ProductCategory {ProductID = 22, CategoryID = 7},
                new ProductCategory {ProductID = 22, CategoryID = 15},
                new ProductCategory {ProductID = 22, CategoryID = 18},

                new ProductCategory {ProductID = 23, CategoryID = 1},
                new ProductCategory {ProductID = 23, CategoryID = 7},
                new ProductCategory {ProductID = 23, CategoryID = 18},
                new ProductCategory {ProductID = 24, CategoryID = 1},
                new ProductCategory {ProductID = 24, CategoryID = 7},
                new ProductCategory {ProductID = 24, CategoryID = 12},
                new ProductCategory {ProductID = 24, CategoryID = 18},
                new ProductCategory {ProductID = 25, CategoryID = 2},
                new ProductCategory {ProductID = 25, CategoryID = 7},
                new ProductCategory {ProductID = 25, CategoryID = 18},

                new ProductCategory {ProductID = 26, CategoryID = 1},
                new ProductCategory {ProductID = 26, CategoryID = 7},
                new ProductCategory {ProductID = 26, CategoryID = 18},
                new ProductCategory {ProductID = 27, CategoryID = 8},
                new ProductCategory {ProductID = 27, CategoryID = 18},
                new ProductCategory {ProductID = 28, CategoryID = 8},
                new ProductCategory {ProductID = 28, CategoryID = 18},
                new ProductCategory {ProductID = 29, CategoryID = 1},
                new ProductCategory {ProductID = 29, CategoryID = 8},
                new ProductCategory {ProductID = 30, CategoryID = 1},

                new ProductCategory {ProductID = 30, CategoryID = 8},
                new ProductCategory {ProductID = 31, CategoryID = 2},
                new ProductCategory {ProductID = 31, CategoryID = 8},
                new ProductCategory {ProductID = 31, CategoryID = 11},
                new ProductCategory {ProductID = 32, CategoryID = 9},
                new ProductCategory {ProductID = 32, CategoryID = 10},
                new ProductCategory {ProductID = 32, CategoryID = 15},
                new ProductCategory {ProductID = 32, CategoryID = 20},
                new ProductCategory {ProductID = 33, CategoryID = 9},
                new ProductCategory {ProductID = 33, CategoryID = 10},

                new ProductCategory {ProductID = 34, CategoryID = 9},
                new ProductCategory {ProductID = 34, CategoryID = 3},
                new ProductCategory {ProductID = 35, CategoryID = 9},
                new ProductCategory {ProductID = 35, CategoryID = 10},
                new ProductCategory {ProductID = 35, CategoryID = 20},
                new ProductCategory {ProductID = 36, CategoryID = 9},
                new ProductCategory {ProductID = 36, CategoryID = 10},
                new ProductCategory {ProductID = 36, CategoryID = 20},
                new ProductCategory {ProductID = 37, CategoryID = 9},
                new ProductCategory {ProductID = 37, CategoryID = 10},

                new ProductCategory {ProductID = 37, CategoryID = 20},
                new ProductCategory {ProductID = 38, CategoryID = 9},
                new ProductCategory {ProductID = 38, CategoryID = 10},
                new ProductCategory {ProductID = 39, CategoryID = 1},
                new ProductCategory {ProductID = 39, CategoryID = 11},
                new ProductCategory {ProductID = 40, CategoryID = 1},
                new ProductCategory {ProductID = 40, CategoryID = 11},
                new ProductCategory {ProductID = 41, CategoryID = 1},
                new ProductCategory {ProductID = 41, CategoryID = 5},
                new ProductCategory {ProductID = 41, CategoryID = 11},

                new ProductCategory {ProductID = 42, CategoryID = 1},
                new ProductCategory {ProductID = 42, CategoryID = 5},
                new ProductCategory {ProductID = 42, CategoryID = 11},
                new ProductCategory {ProductID = 43, CategoryID = 2},
                new ProductCategory {ProductID = 43, CategoryID = 5},
                new ProductCategory {ProductID = 43, CategoryID = 11},
                new ProductCategory {ProductID = 44, CategoryID = 1},
                new ProductCategory {ProductID = 44, CategoryID = 12},
                new ProductCategory {ProductID = 45, CategoryID = 1},
                new ProductCategory {ProductID = 45, CategoryID = 7},

                new ProductCategory {ProductID = 45, CategoryID = 12},
                new ProductCategory {ProductID = 45, CategoryID = 18},
                new ProductCategory {ProductID = 46, CategoryID = 1},
                new ProductCategory {ProductID = 46, CategoryID = 7},
                new ProductCategory {ProductID = 46, CategoryID = 12},
                new ProductCategory {ProductID = 47, CategoryID = 2},
                new ProductCategory {ProductID = 47, CategoryID = 6},
                new ProductCategory {ProductID = 47, CategoryID = 12},
                new ProductCategory {ProductID = 1, CategoryID = 22},
                new ProductCategory {ProductID = 2, CategoryID = 22},

                new ProductCategory {ProductID = 3, CategoryID = 22},
                new ProductCategory {ProductID = 4, CategoryID = 22},
                new ProductCategory {ProductID = 5, CategoryID = 22},
                new ProductCategory {ProductID = 6, CategoryID = 22},
                new ProductCategory {ProductID = 7, CategoryID = 22},
                new ProductCategory {ProductID = 8, CategoryID = 22},
                new ProductCategory {ProductID = 9, CategoryID = 22},
                new ProductCategory {ProductID = 10, CategoryID = 22},
                new ProductCategory {ProductID = 11, CategoryID = 22},
                new ProductCategory {ProductID = 12, CategoryID = 22},

                new ProductCategory {ProductID = 13, CategoryID = 22},
                new ProductCategory {ProductID = 14, CategoryID = 22},
                new ProductCategory {ProductID = 15, CategoryID = 22},
                new ProductCategory {ProductID = 16, CategoryID = 22},
                new ProductCategory {ProductID = 17, CategoryID = 22},
                new ProductCategory {ProductID = 18, CategoryID = 22},
                new ProductCategory {ProductID = 19, CategoryID = 22},
                new ProductCategory {ProductID = 20, CategoryID = 22},
                new ProductCategory {ProductID = 21, CategoryID = 22},
                new ProductCategory {ProductID = 22, CategoryID = 22},

                new ProductCategory {ProductID = 23, CategoryID = 22},
                new ProductCategory {ProductID = 24, CategoryID = 22},
                new ProductCategory {ProductID = 25, CategoryID = 22},
                new ProductCategory {ProductID = 26, CategoryID = 22},
                new ProductCategory {ProductID = 27, CategoryID = 22},
                new ProductCategory {ProductID = 28, CategoryID = 22},
                new ProductCategory {ProductID = 29, CategoryID = 22},
                new ProductCategory {ProductID = 30, CategoryID = 22},
                new ProductCategory {ProductID = 31, CategoryID = 22},
                new ProductCategory {ProductID = 32, CategoryID = 22},

                new ProductCategory {ProductID = 33, CategoryID = 22},
                new ProductCategory {ProductID = 34, CategoryID = 22},
                new ProductCategory {ProductID = 35, CategoryID = 22},
                new ProductCategory {ProductID = 36, CategoryID = 22},
                new ProductCategory {ProductID = 37, CategoryID = 22},
                new ProductCategory {ProductID = 38, CategoryID = 22},
                new ProductCategory {ProductID = 39, CategoryID = 22},
                new ProductCategory {ProductID = 40, CategoryID = 22},
                new ProductCategory {ProductID = 41, CategoryID = 22},
                new ProductCategory {ProductID = 42, CategoryID = 22},

                new ProductCategory {ProductID = 43, CategoryID = 22},
                new ProductCategory {ProductID = 44, CategoryID = 22},
                new ProductCategory {ProductID = 45, CategoryID = 22},
                new ProductCategory {ProductID = 46, CategoryID = 22},
                new ProductCategory {ProductID = 47, CategoryID = 22}
            };

            foreach (ProductCategory i in productCategories)
            {
                context.ProductCategories.Add(i);
            }
            context.SaveChanges();

            // Add Address
            var addresses = new Address[]
            {
                new Address { StreetAddress = "123 Main St",    City = "Somewhere",    State = "Someplace",
                    ZipCode = 12345 },
                new Address { StreetAddress = "456 Main St",    City = "Somewhere",    State = "Someplace",
                    ZipCode = 12345 },
            };

            foreach (Address i in addresses)
            {
                context.Addresses.Add(i);
            }
            context.SaveChanges();

            // Add Payment
            var payments = new Payment[]
            {
                new Payment { CardNumber = 12345678912345,     Expiration = DateTime.Parse("2019-09-10"),
                    NameOnCard = "Alexander Carson", Code = 123},
                new Payment { CardNumber = 12345678912345,     Expiration = DateTime.Parse("2019-10-10"),
                    NameOnCard = "Meridith Alonso", Code = 123}
            };

            foreach (Payment i in payments)
            {
                context.Payments.Add(i);
            }
            context.SaveChanges();

            // Add Customer

            var customers = new Customer[]
            {
                new Customer { FirstName = "Carson",   LastName = "Alexander",
                    Email = "carson.alexander@somewhere.com", Password = "Password", 
                    Phone = 8888888, AddressID = 1, PaymentID = 1 },
                new Customer { FirstName = "Meredith", LastName = "Alonso",
                    Email = "meredith.alonso@nowhere.com", Password = "Password",
                    Phone = 9999999, AddressID = 2, PaymentID = 2 }
            };

            foreach (Customer i in customers)
            {
                context.Customers.Add(i);
            }
            context.SaveChanges();

            // Add Order

            var orders = new Order[]
            {
                new Order { OrderDate = DateTime.Parse("2019-09-10"), IsShipped = false,
                ShippingDate = DateTime.Parse("2019-09-10"), CustomerID = 1 },
                new Order { OrderDate = DateTime.Parse("2019-10-10"), IsShipped = false,
                ShippingDate = DateTime.Parse("2019-10-10"), CustomerID = 2 }
            };

            foreach (Order i in orders)
            {
                context.Orders.Add(i);
            }
            context.SaveChanges();

            // Add OrderedProduct

            var orderedProducts = new OrderedProduct[]
            {
                new OrderedProduct { OrderID = 1, ProductID = 1, Quanity = 1 },
                new OrderedProduct { OrderID = 1, ProductID = 2, Quanity = 1 },
                new OrderedProduct { OrderID = 1, ProductID = 3, Quanity = 1 },
                new OrderedProduct { OrderID = 2, ProductID = 4, Quanity = 1 },
                new OrderedProduct { OrderID = 2, ProductID = 5, Quanity = 1 },
                new OrderedProduct { OrderID = 2, ProductID = 6, Quanity = 1 }
            };

            foreach (OrderedProduct o in orderedProducts)
            {
                context.OrderedProducts.Add(o);
            }
            context.SaveChanges();
        }
    }
}