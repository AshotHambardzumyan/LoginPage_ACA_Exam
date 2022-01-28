using System;
using System.Collections.Generic;

#nullable disable

namespace WebAppMVC1.Models
{
    public partial class Invoice
    {
        public string InvoiceId { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public string PaidDate { get; set; }
    }
}
