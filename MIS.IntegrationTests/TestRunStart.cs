using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MIS.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var options = new DbContextOptionsBuilder<MisContext>()
                                .UseSqlServer(DB_CONNECTION);
            var dbContext = new MisContext(options.Options);
            dbContext.Database.Migrate();
        }
    }
}
