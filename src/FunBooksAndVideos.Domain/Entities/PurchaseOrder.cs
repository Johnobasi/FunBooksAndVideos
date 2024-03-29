﻿using FunBooksAndVideos.Domain.Models;

namespace FunBooksAndVideos.Domain.Entities
{
    public class PurchaseOrder
    {
        public Guid Id { get; set; }
        public double TotalPrice { get; set; }
        public Guid CustomerId { get; set; }
        public List<ItemLine> ItemLines { get; set; }
    }
}
