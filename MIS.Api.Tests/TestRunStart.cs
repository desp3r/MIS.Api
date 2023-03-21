using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using MIS.Data.Contexts;
using System;
using Xunit.Abstractions;
using Xunit.Sdk;

[assembly: Xunit.TestFramework("MIS.Api.Tests.TestRunStart", "MIS.Api.Tests")]

namespace MIS.Api.Tests
{
    public class TestRunStart : XunitTestFramework
    {
        public TestRunStart(IMessageSink messageSink, IConfiguration configuration) : base(messageSink)
        {
            var options = new DbContextOptionsBuilder<MisContext>()
                                .UseSqlServer(configuration.GetConnectionString("TestMisDatabase"));

            var dbContext = new MisContext(options.Options);
            dbContext.Database.Migrate();
        }
    }
}