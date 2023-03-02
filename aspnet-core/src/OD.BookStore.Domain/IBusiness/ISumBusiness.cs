using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OD.BookStore.IBusiness
{
    public interface ISumBusiness
    {
        Task<int> SumTwoNumbers(List<int> numbers);
    }
}
