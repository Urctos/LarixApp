using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaceas
{
    public interface IWindowPriceCalculatorService
    {
        decimal CalculateWindowPrice(decimal woodPrice, decimal glassPrice, decimal margin);
    }
}
