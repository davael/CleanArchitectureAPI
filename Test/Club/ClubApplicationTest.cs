using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Club
{
    [TestClass]
    public class ClubApplicationTest
    {
        private static WebApplicationFactory<Program>? _factory= null;
        private static IServiceScopeFactory? _scopeFactory= null;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _factory = new CustomWebApplicationFactory();
            _scopeFactory= _factory.Services.GetService<IServiceScopeFactory>();
        }
    }
}
