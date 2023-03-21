using Microsoft.EntityFrameworkCore;
using MIS.Data.Contexts;
using Xunit.Abstractions;
using Xunit.Sdk;

[assembly: TestFramework("MIS.IntegrationTests.TestRunStart", "MIS.IntegrationTests")]

namespace MIS.IntegrationTests
{
    internal class TestRunStart : XunitTestFramework
    {
        protected const string DB_CONNECTION = "Server=localhost,14331;Database=Master;User Id=sa;Password=P@ssword123";

        public TestRunStart(IMessageSink messageSink) : base(messageSink)
        {
            DbContextOptionsBuilder<MisContext> options = new DbContextOptionsBuilder<MisContext>()
                                .UseSqlServer(DB_CONNECTION);
            MisContext dbContext = new MisContext(options.Options);

            dbContext.Database.Migrate();
        }
    }
}
