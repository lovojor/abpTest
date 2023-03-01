using System.Threading.Tasks;

namespace OD.BookStore.Data;

public interface IBookStoreDbSchemaMigrator
{
    Task MigrateAsync();
}
