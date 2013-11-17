using MongoDB.Driver;

namespace SharpStocks.Data
{
    public class SharpStocksContext
    {
        private readonly MongoDatabase _context;

        public SharpStocksContext()
        {
            var client = new MongoClient();
            var server = client.GetServer();
            _context = server.GetDatabase("SharpStocks");

            Companies = new CompanyRepository(this);
        }

        public CompanyRepository Companies { get; private set; }

        public void CreateCollection(string name)
        {
            _context.CreateCollection(name);
        }

        public MongoCollection GetCollection<T>() where T : IEntity
        {
            return _context.GetCollection<T>(typeof(T).ToString());
        }
    }
}
