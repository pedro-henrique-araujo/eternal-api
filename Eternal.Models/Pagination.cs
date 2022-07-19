using System;
using System.Collections.Generic;
using System.Text;

namespace Eternal.Models
{
    public class Pagination<T>
    {
        public int NumberOfPages { get; set; }

        public List<T>? Records { get; set; }
    }
}
