using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shopping.Domain.Requests.Product
{
    public class EditProductReq
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
