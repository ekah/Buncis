using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Data.Models
{
    public class Category
    {
        public virtual int CategoryId { get; set; }
        public virtual string CategoryName { get; set; }
        public virtual string CategoryDescription { get; set; }

    }
}
