﻿using Microsoft.EntityFrameworkCore;

namespace CustomerOrderApp.Model
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
    }
}
