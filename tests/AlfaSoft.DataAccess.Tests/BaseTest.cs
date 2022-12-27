using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq.AutoMock;
using Moq;
using Xunit;
using AlfaSoft.Contacts.DataAccess.Context;

namespace AlfaSoft.Contacts.DataAccess.Tests
{
	public class BaseTest
	{
        protected readonly AutoMocker mock;
        protected DbContextOptions<MariaDbContext> options;

        public BaseTest()
        {
            mock=new AutoMocker();
            options = new DbContextOptionsBuilder<MariaDbContext>()
                .UseInMemoryDatabase(databaseName: "db")
                .Options;
        }

    }
    
   
}