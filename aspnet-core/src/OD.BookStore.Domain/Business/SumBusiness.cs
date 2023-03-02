using Microsoft.Extensions.Options;
using OD.BookStore.IBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace OD.BookStore.Business
{
    public class SumBusiness : DomainService, ISumBusiness
    {
        private readonly IOptionsSnapshot<BookConfiguration> Configuration;
        public SumBusiness(IOptionsSnapshot<BookConfiguration> optionsSnapshot)
        {
            Configuration = optionsSnapshot;
        }

        public async Task<int> SumTwoNumbers(List<int> numbers)
        {
            await Task.Delay(100);
            return numbers.Sum(x => x);
        }
    }
}
  