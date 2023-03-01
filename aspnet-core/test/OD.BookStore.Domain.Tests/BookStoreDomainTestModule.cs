using OD.BookStore.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace OD.BookStore;

[DependsOn(
    typeof(BookStoreEntityFrameworkCoreTestModule)
    )]
public class BookStoreDomainTestModule : AbpModule
{

}
