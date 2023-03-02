using Microsoft.AspNetCore.Mvc;
using OD.BookStore.IAppServices;
using OD.BookStore.IBusiness;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace OD.BookStore.AppServices
{
    public class SumAppService : ApplicationService, ISumAppService
    {
        private readonly ISumBusiness ISumBusiness;

        public SumAppService(ISumBusiness iSumBusiness)
        {
            ISumBusiness = iSumBusiness;
        }

        [SwaggerOperation(Summary = "Suma la lista de numeros", Description = "Para probar configuracion Azure y KeyVault")]
        public async Task<int> SumNumbers(List<int> nums)
        {
            return await ISumBusiness.SumTwoNumbers(nums);
        }
    }
}
