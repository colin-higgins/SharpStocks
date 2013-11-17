using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace SharpStocks.Data
{
    public class CompanyRepository
    {
        private readonly MongoCollection _collection;

        public CompanyRepository(SharpStocksContext context)
        {
            _collection = context.GetCollection<Company>();
        }

        public void Save(Company entity)
        {
            entity.Symbol = entity.Symbol.ToUpper();
            _collection.Save(entity);
        }

        public void Verify(Company entity)
        {
            entity.Verified = true;
            _collection.Save(entity);
        }

        public Company FindCompanyBySymbol(string symbol)
        {
            symbol = symbol.ToUpper();
            return _collection.AsQueryable<Company>()
                .FirstOrDefault(c => c.Symbol.Equals(symbol));
        }

        public IEnumerable<Company> GetCompaniesBySymbols(string[] symbols)
        {
            var companies = from c in _collection.AsQueryable<Company>()
                            where symbols.Contains(c.Symbol)
                            select c;

            return companies;
        }

        public IEnumerable<Company> GetCompanies(Company entity)
        {
            var companies = _collection.AsQueryable<Company>();

            if (entity.Id != null)
                return companies.Where(c => entity.Id.Equals(c.Id));

            if (entity.Symbol != null)
                companies = companies.Where(c => c.Symbol.Contains(entity.Symbol));
            if (entity.StockExchange != null)
                companies = companies.Where(c => c.StockExchange.Contains(entity.StockExchange));

            //companies = companies.Where(c => c.Sector.HasFlag(entity.Sector));

            return companies;
        }
    }
}