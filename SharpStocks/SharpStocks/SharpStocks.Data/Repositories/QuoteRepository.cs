using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace SharpStocks.Data
{
    public class QuoteRepository
    {
        private readonly MongoCollection _collection;

        public QuoteRepository(MongoDatabase context)
        {
            _collection = context.GetCollection<Quote>(typeof(Quote).ToString());
        }

    }
}