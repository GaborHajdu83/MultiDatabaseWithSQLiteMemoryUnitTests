using CompanyEmployess.DAL;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;

namespace CompanyEmployess.Test.DbSQLiteFactory
{
    public class SQLiteFactory : IDisposable
    {
        private SqliteConnection _connection;

        public SQLiteFactory()
        {
            SqliteConnectionStringBuilder builder = new SqliteConnectionStringBuilder()
            { 
                DataSource = ":memory:",
                Cache = SqliteCacheMode.Shared
            };

            _connection = new SqliteConnection(builder.ConnectionString);
            _connection.Open();
        }

        public RepositoryContext CreateRepositoryContext()
        {
            DbContextOptions<RepositoryContext> options =
                new DbContextOptionsBuilder<RepositoryContext>().UseSqlite(_connection).Options;

            RepositoryContext context = new RepositoryContext(options);
            var script = context.Database.GenerateCreateScript();
            script = script.Replace("newsequentialid()", "lower(hex(randomblob(16)))");
            script = script.Replace("uniqueidentifier ", "TEXT");
            script = script.Replace("nvarchar(MAX) ", "TEXT");

            if (context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.ExecuteSqlRaw(script);
            }

            return context;
        }

        public ExternalClientContext CreateExternalClientContext()
        {
            DbContextOptions<ExternalClientContext> options =
                new DbContextOptionsBuilder<ExternalClientContext>().UseSqlite(_connection).Options;

            ExternalClientContext context = new ExternalClientContext(options);
            var script = context.Database.GenerateCreateScript();
            script = script.Replace("newsequentialid()", "lower(hex(randomblob(16)))");
            script = script.Replace("uniqueidentifier ", "TEXT");
            script = script.Replace("nvarchar(MAX) ", "TEXT");

            if (context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.ExecuteSqlRaw(script);
            }

            return context;
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
