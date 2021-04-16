using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Domain.Reponses.Category
{
    public class DeleteCategoryRes
    {
        public int CategoryId { get; set; }
        public string Message { get; set; }
        public bool Success => CategoryId > 0;
    }
}
