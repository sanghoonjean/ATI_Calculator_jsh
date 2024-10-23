using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCalculator1.Models
{
    public class MainModel
    {
        public string Memory { get; set; } = default!;
        public string DataArray1 { get; set; } = default!;
        public string DataArray2 { get; set; } = default!;
        public string HistoryArray { get; set; } = default!;
        public string Oper1 { get; set; } = default!;
        public double? Oper2 { get; set; } = default!;
    }


}
