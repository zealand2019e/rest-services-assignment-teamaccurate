using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Model
{
    public class FilterItem
    {
        public double LowQuantity { get; set; }
        public double HighQuantity { get; set; }

        public FilterItem(double low, double high)
        {
            low = LowQuantity;
            high = HighQuantity;
        }

        public FilterItem()
        {

        }


    }
}
