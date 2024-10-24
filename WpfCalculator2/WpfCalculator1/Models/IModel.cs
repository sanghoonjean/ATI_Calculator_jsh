using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCalculator1.Models
{
    public interface IModel
    {
        string GetMemory(MainModel mainmodel);
    }


}
