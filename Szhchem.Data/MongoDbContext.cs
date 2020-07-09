using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Szhchem.Data
{
    public class MongoDbContext
    {
        private IMongoClient Client { get; set; }
        private IMongoDatabase Db { get; set; }
        private Dictionary<string, string> AutoIncrementIdFields { get; set; } = new Dictionary<string, string>();

        private void InitAutoIncrementIdFields()
        {
            /*var col = Db.GetCollection<BsonDocument>("_idCounters");
            var list = col.Find(new BsonDocument() { }).ToList();
            list.ForEach(c => AutoIncrementIdFields
                .Add(c.GetValue("collection").AsString, c.GetValue("idField").AsString));*/
            AutoIncrementIdFields.Add("Molecule", "MolID");
            AutoIncrementIdFields.Add("Substance", "SubstanceID");
            AutoIncrementIdFields.Add("Company", "CompanyIntId");
            AutoIncrementIdFields.Add("DataSource", "DataSourceIntId");
        }

        public MongoDbContext()
        {
            Client = new MongoClient("mongodb://root:Jqy19730101@ftp.minolab.com/?replicaSet=zhihua&slaveOK=true");
            Db = Client.GetDatabase("szhchem");
            InitAutoIncrementIdFields();
        }

        public MongoDbContext(string connectionString, string databaseName)
        {
            Client = new MongoClient(connectionString);
            Db = Client.GetDatabase(databaseName);
            InitAutoIncrementIdFields();
        }

        #region 基础操作

        public IMongoCollection<T> Collection<T>()
        {
            var collectionName = typeof(T).Name;
            return Db.GetCollection<T>(collectionName);
        }

        public IMongoCollection<T> Collection<T>(string collectionName)
        {
            return Db.GetCollection<T>(collectionName);
        }

        public IMongoCollection<BsonDocument> Collection(string collectionName)
        {
            return Db.GetCollection<BsonDocument>(collectionName);
        }

        public long CountCollection<T>()
        {
            string collectionName = typeof(T).Name;
            var col = Db.GetCollection<T>(collectionName);
            return col.CountDocuments(new BsonDocument() { });
        }

        public long CountCollection(string collectionName)
        {
            var col = Db.GetCollection<BsonDocument>(collectionName);
            return col.CountDocuments(new BsonDocument { });
        }

        public long CountCollection<T>(Expression<Func<T, bool>> expression)
        {
            var col = Collection<T>();
            return col.CountDocuments<T>(expression);
        }

        public async Task<long> CountCollectionAsync<T>()
        {
            string collectionName = typeof(T).Name;
            var col = Db.GetCollection<T>(collectionName);
            return await col.CountDocumentsAsync(new BsonDocument() { });
        }

        public async Task<long> CountCollectionAsync(string collectionName)
        {
            var col = Db.GetCollection<BsonDocument>(collectionName);
            return await col.CountDocumentsAsync(new BsonDocument() { });
        }

        public T ReadConfigData<T>()
        {
            string configName = typeof(T).Name;
            var configs = Collection("Config");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", configName);
            var result = configs.Find(filter).FirstOrDefault();
            return BsonSerializer.Deserialize<T>(result);
        }

        public IEnumerable<TOut> GetAggregationResult<TIn, TOut>(BsonDocument[] pipeline)
        {
            var col = Collection<TIn>();
            var result = col.Aggregate<TOut>(pipeline).ToEnumerable();
            return result;
        }

        #endregion

        #region 写数据

        public void InsertOneObject<T>(T obj)
        {
            var col = Collection<T>();
            col.InsertOne(obj);
        }

        public async Task InsertOneObjectAsync<T>(T obj)
        {
            var col = Collection<T>();
            await col.InsertOneAsync(obj);
        }

        public void InsertOneObject<T>(T obj, string collectionName)
        {
            var col = Db.GetCollection<T>(collectionName);
            col.InsertOne(obj);
        }

        public void InsertOneJsonString(string json, string collectionName)
        {
            BsonDocument doc = BsonDocument.Parse(json);
            var col = Db.GetCollection<BsonDocument>(collectionName);
            col.InsertOne(doc);
        }

        public async Task InsertOneJsonStringAsync(string json, string collectionName)
        {
            BsonDocument doc = BsonDocument.Parse(json);
            var col = Db.GetCollection<BsonDocument>(collectionName);
            await col.InsertOneAsync(doc);
        }

        #endregion

        #region 读数据

        public T GetOneById<T>(ObjectId id)
        {
            var col = Collection<T>();
            var query = Builders<T>.Filter.Eq("_id", id);
            return col.Find<T>(query).FirstOrDefault();
        }

        public string GetJsonStringById<T>(ObjectId id)
        {
            string collectionName = typeof(T).Name;
            return GetJsonStringById<T>(id, collectionName);
        }

        public string GetJsonStringById(ObjectId id, string collectionName)
        {
            return GetJsonStringById<BsonDocument>(id, collectionName);
        }

        public string GetJsonStringById<T>(ObjectId id, string collectionName)
        {
            var col = Db.GetCollection<T>(collectionName);
            var query = Builders<T>.Filter.Eq("_id", id);
            return col.Find(query).FirstOrDefault().ToJson();
        }

        public T GetOneByIntId<T>(long id, string collectionName)
        {
            string idFieldName = AutoIncrementIdFields[typeof(T).Name];
            var col = Db.GetCollection<T>(collectionName);
            var query = Builders<T>.Filter.Eq(idFieldName, id);
            return col.Find(query).FirstOrDefault();
        }

        public T GetOneByIntId<T>(long id)
        {
            string collectionName = typeof(T).Name;
            return GetOneByIntId<T>(id, collectionName);
        }

        public async Task<T> GetOneByIntIdAsync<T>(long id, string collectionName)
        {
            string idFieldName = AutoIncrementIdFields[typeof(T).Name];
            var col = Db.GetCollection<T>(collectionName);
            var query = Builders<T>.Filter.Eq(idFieldName, id);
            return await col.Find(query).FirstOrDefaultAsync();
        }

        public async Task<T> GetOneByIntIdAsync<T>(long id)
        {
            string collectionName = typeof(T).Name;
            return await GetOneByIntIdAsync<T>(id, collectionName);
        }

        public string GetJsonStringByIntId<T>(long id, string collectionName)
        {
            string idFieldName = AutoIncrementIdFields[typeof(T).Name];
            var col = Db.GetCollection<T>(collectionName);
            var query = Builders<T>.Filter.Eq(idFieldName, id);
            return col.Find(query).FirstOrDefault().ToJson();
        }

        public string GetJsonStringByIntId<T>(long id)
        {
            string collectionName = typeof(T).Name;
            return GetJsonStringByIntId<T>(id, collectionName);
        }

        public async Task<string> GetJsonStringByIntIdAsync<T>(long id, string collectionName = null)
        {
            string col = string.IsNullOrEmpty(collectionName) ? typeof(T).Name : collectionName;
            return await Task.Factory.StartNew(() => { return GetJsonStringByIntId<T>(id, col); });
        }

        public List<T> GetManyByIdList<T>(IEnumerable<ObjectId> idList, string collectionName = null)
        {
            string colname = string.IsNullOrEmpty(collectionName) ? typeof(T).Name : collectionName;
            var col = Db.GetCollection<T>(colname);
            var query = Builders<T>.Filter.In("_id", idList);
            return col.Find(query).ToList();
        }

        public async Task<List<T>> GetManyByIdListAsync<T>(IEnumerable<ObjectId> idList, string collectionName = null)
        {
            string colname = string.IsNullOrEmpty(collectionName) ? typeof(T).Name : collectionName;
            var col = Db.GetCollection<T>(colname);
            var query = Builders<T>.Filter.In("_id", idList);
            return await col.Find(query).ToListAsync();
        }

        public List<T> GetManyByIntIds<T>(IEnumerable<long> intIdList, string collectionName = null)
        {
            string idFieldName = AutoIncrementIdFields[typeof(T).Name];
            string colname = string.IsNullOrEmpty(collectionName) ? typeof(T).Name : collectionName;
            var col = Db.GetCollection<T>(colname);
            var query = Builders<T>.Filter.In(idFieldName, intIdList);
            return col.Find(query).ToList();
        }

        public async Task<List<T>> GetManyByIntIdsAsync<T>(IEnumerable<long> intIdList, string collectionName = null)
        {
            string idFieldName = AutoIncrementIdFields[typeof(T).Name];
            string colname = string.IsNullOrEmpty(collectionName) ? typeof(T).Name : collectionName;
            var col = Db.GetCollection<T>(colname);
            var query = Builders<T>.Filter.In(idFieldName, intIdList);
            return await col.Find(query).ToListAsync();
        }

        public T GetOneByExpression<T>(Expression<Func<T, bool>> expression, string collectionName = null)
        {
            string colname = string.IsNullOrEmpty(collectionName) ? typeof(T).Name : collectionName;
            var col = Db.GetCollection<T>(colname);
            var query = Builders<T>.Filter.Where(expression);
            return col.Find(query).FirstOrDefault();
        }

        public List<T> GetManyByExpression<T>(Expression<Func<T, bool>> expression, string collectionName = null)
        {
            string colname = string.IsNullOrEmpty(collectionName) ? typeof(T).Name : collectionName;
            var col = Db.GetCollection<T>(colname);
            var query = Builders<T>.Filter.Where(expression);
            return col.Find(query).ToList();
        }

        public async Task<List<T>> GetManyByExpressionAsync<T>(Expression<Func<T, bool>> expression,
            string collectionName = null)
        {
            string colname = string.IsNullOrEmpty(collectionName) ? typeof(T).Name : collectionName;
            var col = Db.GetCollection<T>(colname);
            var query = Builders<T>.Filter.Where(expression);
            return await col.Find(query).ToListAsync();
        }

        public List<T> GetManyByMolID<T>(long molID)
        {
            var col = Collection<T>();
            return col.Find<T>(new BsonDocument("MolID", molID)).ToList();
        }

        #endregion

        #region 删除数据

        public void DeleteOneByIntId<T>(long id)
        {
            var col = Collection<T>();
            var filter = Builders<T>.Filter.Eq(AutoIncrementIdFields[typeof(T).Name], id);
            col.DeleteOne(filter);
        }

        public void DeleteOneByIntId<T>(IClientSessionHandle session, long id)
        {
            var col = Collection<T>();
            var filter = Builders<T>.Filter.Eq(AutoIncrementIdFields[typeof(T).Name], id);
            col.DeleteOne(session, filter);
        }

        public void DeleteManyByObjectIds<T>(List<ObjectId> ids)
        {
            var col = Collection<T>();
            var filter = Builders<T>.Filter.In("_id", ids);
            col.DeleteMany(filter);
        }

        public void DeleteManyByObjectIds<T>(IClientSessionHandle session, List<ObjectId> ids)
        {
            var col = Collection<T>();
            var filter = Builders<T>.Filter.In("_id", ids);
            col.DeleteMany(session, filter);
        }

        #endregion
    }
}