using OD.BookStore.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace OD.BookStore.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BookStoreController : AbpControllerBase
{
    protected BookStoreController()
    {
        LocalizationResource = typeof(BookStoreResource);
    }
}
