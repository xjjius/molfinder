using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata;
using Microsoft.Extensions.Options;
using molfinder.Models;
using MongoDB.Bson;
using Szhchem.Chemistry;
using Szhchem.Data;

namespace molfinder.Services
{
    public class DataService : IDataService
    {
        private readonly MongoDbContext _mongo;

        public DataService(IOptions<DataOption> options)
        {
            string connectionString = options.Value.ConnectionString;
            string databaseName = options.Value.DatabaseName;
            _mongo = new MongoDbContext(connectionString, databaseName);
        }

        public Company GetCompanyByCompanyId(int companyId)
        {
            var ret = _mongo.GetOneByIntId<Company>(companyId);
            return ret;
        }

        public Molecule GetOneMoleculeByMolId(long molID)
        {
            return _mongo.GetOneByIntId<Molecule>(molID);
        }

        public IEnumerable<MoleculeDataSource> GetMoleculeDataSources(long molID)
        {
            var match = new BsonDocument("$match", new BsonDocument("MolID", molID));
            var join = new BsonDocument()
                .Add("from", "Company")
                .Add("localField", "CompanyIntId")
                .Add("foreignField", "CompanyIntId")
                .Add("as", "Company");
            var lookup = new BsonDocument("$lookup", join);
            var unwind = new BsonDocument("$unwind", "$Company");
            var fieldsToBeAdded = new BsonDocument()
                .Add("CompanyInformation", "$Company.CompanyInformation")
                .Add("DataSources", "$Company.DataSources");
            var addFields = new BsonDocument("$addFields", fieldsToBeAdded);
            /*var fields = new BsonDocument()
                .Add("Company", 0)
                .Add("NameIDs", 0)
                .Add("RegNoIDs", 0)
                .Add("SubstanceDetails", 0)
                .Add("ReferenceIDs", 0)
                .Add("Prices", 0);
            var project = new BsonDocument("$project", fields);*/

            var pipeline = new[] {match, lookup, unwind, addFields};
            var rawData = _mongo.GetAggregationResult<Substance, MoleculeDataSource>(pipeline);
            var result = new List<MoleculeDataSource>();
            foreach (var data in rawData)
            {
                var item = new MoleculeDataSource
                {
                    Id = data.Id,
                    SubstanceID = data.SubstanceID,
                    MolID = data.MolID,
                    CompanyIntId = data.CompanyIntId,
                    DataSourceIntId = data.DataSourceIntId,
                    ExtID = data.ExtID,
                    ExtUrl = data.ExtUrl,
                    DisplayOrder = data.DisplayOrder,
                    UserRating = data.UserRating,
                    TimeCreated = data.TimeCreated,
                    CompanyInformation = data.CompanyInformation,
                    DataSources = data.DataSources.FindAll(d => d.DataSourceIntId == data.DataSourceIntId)
                };
                item.DataSourceType = item.DataSources[0].DataSourceType;
                result.Add(item);
            }

            return result;
        }

        public IEnumerable<SubstanceSupplier> GetSuppliersInfo(IEnumerable<long> substanceIDs)
        {
            var i = new BsonDocument("$in", new BsonArray(substanceIDs));
            var match = new BsonDocument("$match", new BsonDocument("SubstanceID", i));
            var join = new BsonDocument()
                .Add("from", "Company")
                .Add("localField", "CompanyIntId")
                .Add("foreignField", "CompanyIntId")
                .Add("as", "Company");
            var lookup = new BsonDocument("$lookup", join);
            var unwind = new BsonDocument("$unwind", "$Company");
            var fields = new BsonDocument()
                .Add("_id", 0)
                .Add("SubstanceID", 1)
                .Add("ExtID", 1)
                .Add("ExtUrl", 1)
                .Add("Company", 1);
            var project = new BsonDocument("$project", fields);

            var pipeline = new[] {match, lookup, unwind, project};
            return _mongo.GetAggregationResult<Substance, SubstanceSupplier>(pipeline);
        }

        public IEnumerable<PropertyGroup> GetMoleculeProperty(long molID)
        {
            var result = new List<PropertyGroup>();
            var list = _mongo.GetManyByMolID<Property>(molID);
            var groupByCategory = list.GroupBy(l => l.PropertyCategory);
            foreach (var categoryGroup in groupByCategory)
            {
                var p = new PropertyGroup();
                p.PropertyCategory = categoryGroup.Key;

                var groupByType = categoryGroup.GroupBy(g => g.PropertyCode);
                foreach (var typeGroup in groupByType)
                {
                    p.Properties.Add(new PropertyTypeGroup
                    {
                        PropertyCode = typeGroup.Key,
                        Properties = typeGroup.ToList()
                    });
                }

                result.Add(p);
            }

            return result;
        }

        public IEnumerable<MolNameGroup> GetMolNamesByMolID(long molID)
        {
            var result = new List<MolNameGroup>();
            // Title 也算同义词的一种，合并之
            var names = _mongo.GetManyByMolID<MolName>(molID)
                .Select(n =>
                {
                    if (n.NameType == 1)
                        n.NameType = 13;
                    return n;
                }).Distinct(new MolNameComparer());

            /*var names = _mongo.GetManyByMolID<MolName>(molID)
                .Peek(n =>
                {
                    if (n.NameType == 1)
                        n.NameType = 13;
                }).Distinct(new MolNameComparer());*/

            names.GroupBy(n => n.NameType).ToList()
                .ForEach(n =>
                {
                    result.Add(new MolNameGroup()
                    {
                        NameType = n.Key,
                        MolNames = n.ToList()
                    });
                });
            return result;
        }

        public IEnumerable<MolRegNoGroup> GetMolRegNoByMolID(long molID)
        {
            var result = new List<MolRegNoGroup>();
            var regNos = _mongo.GetManyByMolID<MolRegNo>(molID);
            regNos.GroupBy(r => r.RegType).ToList()
                .ForEach(r =>
                {
                    result.Add(new MolRegNoGroup()
                    {
                        RegType = r.Key,
                        MolRegNos = r.ToList()
                    });
                });
            return result;
        }
    }
}