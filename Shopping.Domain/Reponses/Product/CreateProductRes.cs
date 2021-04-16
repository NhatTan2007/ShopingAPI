using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Domain.Reponses.Product
{
    public class CreateProductRes
    {
        public string ProductId { get; set; }
        public string Message { get; set; }
        public bool Success => !String.IsNullOrEmpty(ProductId);
    }
}
