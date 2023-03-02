using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OD.BookStore.IAppServices
{
    public interface ISumAppService
    {
        Task<int> SumNumbers(List<int> nums);
    }
}
