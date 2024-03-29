﻿using FunBooksAndVideos.Domain.Entities;
using FunBooksAndVideos.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ShippingSlip> ShippingSlips { get; set; }
    }
}
