using System;
using System.Collections.Generic;
using System.Text;
using OD.BookStore.Localization;
using Volo.Abp.Application.Services;

namespace OD.BookStore;

/* Inherit your application services from this class.
 */
public abstract class BookStoreAppService : ApplicationService
{
    protected BookStoreAppService()
    {
        LocalizationResource = typeof(BookStoreResource);
    }
}
