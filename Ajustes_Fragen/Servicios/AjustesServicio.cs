using Ajustes_Fragen.Modelos;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ajustes_Fragen.Servicios
{
    public class AjustesServicio
    {
        private readonly IMongoCollection<Ajustes> _ajuste;

        public AjustesServicio(IAjustesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _ajuste = database.GetCollection<Ajustes>(settings.AjustesCollectionName);
        }

        public List<Ajustes> Get() =>
            _ajuste.Find(book => true).ToList();

        public Ajustes Get(string id) =>
            _ajuste.Find<Ajustes>(book => book.Id == id).FirstOrDefault();

        public Ajustes Create(Ajustes ajuste)
        {
            _ajuste.InsertOne(ajuste);
            return ajuste;
        }

        public void Update(string id, Ajustes bookIn) =>
            _ajuste.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(Ajustes bookIn) =>
            _ajuste.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) => 
            _ajuste.DeleteOne(book => book.Id == id);
    }
}
