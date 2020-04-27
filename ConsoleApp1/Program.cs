using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Order
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public decimal Discount { get; private set; }
        public decimal TotalPriceWithoutDiscount { get; private set; }
        public decimal TotalPrice { get; private set; }
        public int PlaceId { get; private set; }

        private Place _place;
        public Place Place
        {
            get
            {
                return _place;
            }
            set
            {
                _place = value;
                PlaceId = value.Id;
            }
        }

        public IReadOnlyCollection<OrderItem> OrderItems { get; set; }

        private Order()
        {
            Id = 0;
            Name = string.Empty;
            TotalPriceWithoutDiscount = 0;
            TotalPrice = 0;
            Discount = 0;
            PlaceId = 0;
            _place = new Place(0, string.Empty);
            Place = new Place(0, string.Empty);
            OrderItems = new List<OrderItem>();
        }

        public Order(int id, string name, int placeId, string placeName)
        {
            Id = id;
            Name = name;
            TotalPriceWithoutDiscount = 0;
            TotalPrice = 0;
            Discount = 0;
            PlaceId = placeId;
            _place = new Place(0, string.Empty);
            Place = new Place(placeId, placeName);
            OrderItems = new List<OrderItem>();
        }

        public void AddItems(int id, string name, decimal price)
        {
            var item = new OrderItem(id, name, price, Id, this);
            ((List<OrderItem>)OrderItems).Add(item);
        }

        public void RemoveItem(int id)
        {
            ((List<OrderItem>)OrderItems).Remove(OrderItems.First(i => i.Id == id));
        }

        public void CalculateDiscount()
        {
            var numberOfItems = ((List<OrderItem>)OrderItems).Count;
            if (numberOfItems > 2)
            {
                Discount = 10;
            }
            if (numberOfItems > 4)
            {
                Discount = 20;
            }
        }

        public void CalculateTotalPrice()
        {
            TotalPriceWithoutDiscount = OrderItems.Sum(item => item.Price);
            TotalPrice = TotalPriceWithoutDiscount - Discount;
        }
    }

    class OrderItem
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public decimal Price { get; private set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

        private OrderItem()
        {
            Id = 0;
            Name = string.Empty;
            OrderId = 0;
            Order = new Order(0, string.Empty, 0, string.Empty);
            Price = 0;
        }

        public OrderItem(int id, string name, decimal price, int orderId, Order order)
        {
            Id = id;
            Name = name;
            OrderId = orderId;
            Order = order;
            Price = price;
        }
    }

    class Place
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Place(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    class OrderContextWrite : DbContext
    {
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderItem>? OrderItems { get; set; }
        public DbSet<Place>? Places { get; set; }

        public OrderContextWrite(DbContextOptions<OrderContextWrite> options)
            : base(options)
        {
        }
    }

    class OrderContextRead : DbContext
    {
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderItem>? OrderItems { get; set; }
        public DbSet<Place>? Places { get; set; }

        public OrderContextRead(DbContextOptions<OrderContextRead> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Order>()
        //        .HasMany(o => o.OrderItems)
        //        .WithOne();

        //    modelBuilder.Entity<OrderItem>()
        //        .HasOne(oi => oi.Order)
        //        .WithMany(o => o.OrderItems)
        //        .HasForeignKey(oi => oi.OrderId);
        //}
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region Initial create.
            //var o1 = new Order(1, "order1", 1, "place1");
            //o1.AddItems(1, "i1", 10);
            //o1.AddItems(2, "i2", 20);
            //o1.AddItems(3, "i3", 30);
            //o1.CalculateDiscount();
            //o1.CalculateTotalPrice();
            //AddEditDelete(o1);
            #endregion

            #region Add order items.
            //var options = new DbContextOptionsBuilder<OrderContextRead>()
            //    .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OrderDb;Integrated Security=True")
            //    .Options;
            //var orderContextRead = new OrderContextRead(options);
            //var o1 = orderContextRead.Orders
            //    .AsNoTracking()
            //    .Include(order => order.OrderItems)
            //    .Include(order => order.Place)
            //    .First(order => order.Id == 1);
            //o1.Name = "n1";
            //o1.Place = new Place(1, "kol");
            //o1.OrderItems.ElementAt(0).Name = "xyz";
            //o1.AddItems(4, "i4", 40);
            //o1.AddItems(5, "i5", 50);
            //o1.CalculateDiscount();
            //o1.CalculateTotalPrice();
            //AddEditDelete(o1);
            #endregion

            #region Remove order items.
            //var options = new DbContextOptionsBuilder<OrderContextRead>()
            //    .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OrderDb;Integrated Security=True")
            //    .Options;
            //var orderContextRead = new OrderContextRead(options);
            //var o1 = orderContextRead.Orders
            //    .AsNoTracking()
            //    .Include(order => order.OrderItems)
            //    .Include(order => order.Place)
            //    .First(order => order.Id == 1);
            //o1.RemoveItem(2);
            //o1.CalculateDiscount();
            //o1.CalculateTotalPrice();
            //AddEditDelete(o1);
            #endregion

            #region Work with place.
            //var options = new DbContextOptionsBuilder<OrderContextRead>()
            //    .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OrderDb;Integrated Security=True")
            //    .Options;
            //var orderContextRead = new OrderContextRead(options);
            //var o1 = orderContextRead.Orders
            //    .AsNoTracking()
            //    .Include(order => order.OrderItems)
            //    .Include(order => order.Place)
            //    .First(order => order.Id == 1);
            //o1.Place = new Place(1, "k1");
            //AddEditDelete(o1);
            #endregion

            #region Delete.
            //var options = new DbContextOptionsBuilder<OrderContextRead>()
            //    .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OrderDb;Integrated Security=True")
            //    .Options;
            //var orderContextRead = new OrderContextRead(options);
            //var o1 = orderContextRead.Orders
            //    .AsNoTracking()
            //    .Include(order => order.OrderItems)
            //    .Include(order => order.Place)
            //    .First(order => order.Id == 1);
            ////for (int i = 0; i < o1.OrderItems.Count; i++)
            ////{
            ////    o1.RemoveItem(o1.OrderItems.ElementAt(i).Id);
            ////}
            ////AddEditDelete(o1);
            //foreach (var item in o1.OrderItems)
            //{
            //    orderContextRead.Entry(item).State = EntityState.Deleted;
            //}
            //orderContextRead.Entry(o1).State = EntityState.Deleted;
            //orderContextRead.SaveChanges();
            #endregion
        }

        private static void AddEditDelete(Order order)
        {
            var options = new DbContextOptionsBuilder<OrderContextWrite>()
                .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OrderDb;Integrated Security=True")
                .Options;
            var orderContextWrite = new OrderContextWrite(options);

            var existingOrder = orderContextWrite.Orders
                .AsNoTracking()
                .Include(o => o.OrderItems)
                .Include(o => o.Place)
                .FirstOrDefault(o => o.Id == order.Id);

            if (existingOrder == null)
            {
                orderContextWrite.Orders!.Add(order);
                if (orderContextWrite.Places.FirstOrDefault(p => p.Id == order.Place.Id) != null)
                {
                    orderContextWrite.Entry(order.Place).CurrentValues.SetValues(order.Place);
                    orderContextWrite.Entry(order.Place).State = EntityState.Modified;
                }
            }
            else
            {
                orderContextWrite.Entry(existingOrder).CurrentValues.SetValues(order);
                orderContextWrite.Entry(existingOrder).State = EntityState.Modified;
                if (orderContextWrite.Places.FirstOrDefault(p => p.Id == order.Place.Id) != null)
                {
                    orderContextWrite.Entry(existingOrder.Place).CurrentValues.SetValues(order.Place);
                    orderContextWrite.Entry(existingOrder.Place).State = EntityState.Modified;
                }
                else
                {
                    orderContextWrite.Places!.Add(order.Place);
                }
                foreach (var item in order.OrderItems)
                {
                    var existingOrderItem = existingOrder.OrderItems.FirstOrDefault(oi => oi.Id == item.Id);
                    if (existingOrderItem != null)
                    {
                        orderContextWrite.Entry(existingOrderItem).CurrentValues.SetValues(item);
                        orderContextWrite.Entry(existingOrderItem).State = EntityState.Modified;
                    }
                    else
                    {
                        orderContextWrite.Entry(item).State = EntityState.Added;
                    }
                }
                foreach (var item in existingOrder.OrderItems)
                {
                    if (!order.OrderItems.Any(oi => oi.Id == item.Id))
                    {
                        orderContextWrite.Remove(item);
                    }
                }
            }

            orderContextWrite.SaveChanges();
        }
    }
}
