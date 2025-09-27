using TaskLinq.Models;

namespace TaskLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
             var db = new BikeStores519Context();

            // 1- List all customers' first and last names along with their email addresses.
            var customers = db.Customers
                .Select(c => new { c.FirstName, c.LastName, c.Email });

            // 2- Retrieve all orders processed by a specific staff member (staff_id = 3).
            var ordersByStaff = db.Orders
                .Where(o => o.StaffId == 3);

            // 3- Get all products that belong to a category named "Mountain Bikes".
            var mountainBikes = db.Products
                .Where(p => p.Category.CategoryName == "Mountain Bikes");

            // 4- Count the total number of orders per store.
            var ordersPerStore = db.Orders
                .GroupBy(o => o.StoreId)
                .Select(g => new { StoreId = g.Key, Count = g.Count() });

            // 5- List all orders that have not been shipped yet (shipped_date is null).
            var notShippedOrders = db.Orders
                .Where(o => o.ShippedDate == null);

            // 6- Display each customer’s full name and the number of orders they have placed.
            var customerOrders = db.Customers
                .Select(c => new
                {
                    FullName = c.FirstName + " " + c.LastName,
                    OrdersCount = c.Orders.Count()
                });

            // 7- List all products that have never been ordered.
            var neverOrderedProducts = db.Products
                .Where(p => !p.OrderItems.Any());

            // 8- Display products that have a quantity of less than 5 in any store stock.
            var lowStockProducts = db.Stocks
                .Where(s => s.Quantity < 5)
                .Select(s => s.Product);

            // 9- Retrieve the first product from the products table.
            var firstProduct = db.Products.FirstOrDefault();

            // 10- Retrieve all products from the products table with a certain model year .
            var products2018 = db.Products
                .Where(p => p.ModelYear == 2018);

            // 11- Display each product with the number of times it was ordered.
            var productOrderCounts = db.Products
                .Select(p => new
                {
                    p.ProductName,
                    OrdersCount = p.OrderItems.Count()
                });

            // 12- Count the number of products in a specific category .
            var countCategoryProducts = db.Products
                .Count(p => p.CategoryId == 6);

            // 13- Calculate the average list price of products.
            var avgPrice = db.Products.Average(p => p.ListPrice);

            // 14- Retrieve a specific product from the products table by ID .
            var productById = db.Products.Find(10);

            // 15- List all products that were ordered with a quantity greater than 3 in any order.
            var productsQtyGT3 = db.OrderItems
                .Where(oi => oi.Quantity > 3)
                .Select(oi => oi.Product)
                .Distinct();

            // 16- Display each staff member’s name and how many orders they processed.
            var staffOrders = db.Staffs
                .Select(s => new
                {
                    FullName = s.FirstName + " " + s.LastName,
                    OrdersCount = s.Orders.Count()
                });

            // 17- List active staff members only (active = true) along with their phone numbers.
            var activeStaff = db.Staffs
                .Where(s => s.Active == true)
                .Select(s => new { s.FirstName, s.LastName, s.Phone });

            // 18- List all products with their brand name and category name.
            var productsWithBrandCategory = db.Products
                .Select(p => new
                {
                    p.ProductName,
                    Brand = p.Brand.BrandName,
                    Category = p.Category.CategoryName
                });

            // 19- Retrieve orders that are completed .
            var completedOrders = db.Orders
                .Where(o => o.OrderStatus == 1);

            // 20- List each product with the total quantity sold.
            var totalQtySold = db.OrderItems
                .GroupBy(oi => oi.Product)
                .Select(g => new
                {
                    Product = g.Key.ProductName,
                    TotalSold = g.Sum(x => x.Quantity)
                });

          
            foreach (var item in customers)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} - {item.Email}");
            }
        }
    }
}
