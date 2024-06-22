﻿namespace my_resturant.Models
{
    public class Menulist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public List<Order> Orders { get; set; }
    }
}
