using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ajustes_Fragen.Modelos
{
    public class Ajustes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdUsuario { get; set; }

        public String colorFondo { get; set; }
        public String tamanoLetra { get; set; }
        public bool sonidoON { get; set; }
    }
}
