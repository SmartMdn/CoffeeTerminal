﻿namespace CoffeeTerminal.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public bool IsAvailable { get; set; }
        public int Count { get; set; }
    }
}