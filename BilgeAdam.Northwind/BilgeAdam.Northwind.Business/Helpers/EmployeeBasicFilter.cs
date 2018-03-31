using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.Northwind.Business.Helpers
{
    public class EmployeeBasicFilter
    {
        public string GenderText
        {
            get
            {
                return IsMale ? "M" : "F";
            }
        }

        public string MarrialStatusText
        {
            get
            {
                var result = string.Empty;
                if (IsSingle)
                {
                    result = "S";
                }
                else
                {
                    result = "M";
                }
                return result;
            }
        }
        public bool IsMale { get; set; }
        public bool IsSingle { get; set; }
    }
}
