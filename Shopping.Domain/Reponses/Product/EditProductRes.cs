using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Domain.Reponses.Product
{
    public class EditProductRes
    {
        public Product Product { get; set; }
        public string Message { get; set; }
        public bool Success => Product != null;
    }
}
