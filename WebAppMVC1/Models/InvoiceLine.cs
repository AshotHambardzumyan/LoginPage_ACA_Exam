using System;
using System.Collections.Generic;

#nullable disable

namespace WebAppMVC1.Models
{
    public partial class InvoiceLine
    {
        public string InvoiceLineId { get; set; }
        public string InvoiceId { get; set; }
        public string ProductId { get; set; }
        public long? Quantity { get; set; }
    }
}
