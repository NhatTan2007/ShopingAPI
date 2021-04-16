using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Domain.Requests.Category
{
    public class EditCategoryReq
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
