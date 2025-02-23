using ClubRecreativo.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace ClubRecreativo.Test
{
    public class TestBase : IDisposable
    {
        protected readonly ClubRecreativoContext _context;

        public TestBase()
        {
            var options = new DbContextOptionsBuilder<ClubRecreativoContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new ClubRecreativoContext(options);
            _context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
