using System;
using System.Collections.Generic;

#nullable disable

namespace WebAppMVC1.Models
{
    public partial class Product
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public long? Price { get; set; }
    }
}
