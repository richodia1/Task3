using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Price
    {
        public string Currency { get; set; }
        public float NumericFloat { get; set; }
        public int NumericInteger { get; set; }
    }
}
