using Ajustes_Fragen.Modelos;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ajustes_Fragen.Servicios
{
    public class AjustesServicio
    {
        private IMongoCollection<Ajustes> _ajustes;

        public AjustesServicio(IAjustesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _ajustes = database.GetCollection<Ajustes>(settings.AjustesCollectionName);
        }

        public List<Ajustes> Get()
        {
            var lista = _ajustes.Find(s => s.Id != null).ToList(); ;
            return lista;
        }

        public Ajustes Get(string id)
        {
            Ajustes document = _ajustes.Find(ajs => ajs.Id == id).FirstOrDefault();
            //Console.WriteLine(document.ToString());
            return document;
            
        }

        public Ajustes Create(Ajustes ajuste)
        {
            _ajustes.InsertOne(ajuste);
            return ajuste;
        }

        public void Update(string id, Ajustes ajus)
        {
            ajus.Id = id;
            _ajustes.ReplaceOne(aj => aj.Id == id, ajus);
        }

        public void Remove(Ajustes ajus) =>
            _ajustes.DeleteOne(aj => aj.Id == ajus.Id);

        public void Remove(string id) => 
            _ajustes.DeleteOne(aj => aj.Id == id);
    }
}
