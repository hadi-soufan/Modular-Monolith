using System.Data.Common;
using Evently.Module.Events.Application.Abstractions.Data;
using Npgsql;

namespace Evently.Module.Events.Infrastructure.Data;
internal sealed class DbConnectionFactory(NpgsqlDataSource dataSource) : IDbConnectionFactory
{
    public async ValueTask<DbConnection> OpenConnectionAsync()
    {
        return await dataSource.OpenConnectionAsync();
    }
}
