using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ajustes_Fragen.Modelos;
using Ajustes_Fragen.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Ajustes_Fragen.Controllers
{
    [Route("ajustes")]
    [ApiController]
    public class AjustesControlador : ControllerBase
    {
        private readonly AjustesServicio ajustesS;

        public AjustesControlador(AjustesServicio Aj)
        {
            ajustesS = Aj;
        }

        [HttpGet]
        public IEnumerable<Ajustes> Get() =>
            ajustesS.Get();

        [HttpGet("{id}")]
        public Ajustes Get(string id)
        {
            var _ajustes = ajustesS.Get(id);

            if (_ajustes == null)
            {
                return null;
            }

            return _ajustes;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Ajustes _ajustes)
        {
            try
            {
                ajustesS.Create(_ajustes);
                return StatusCode(StatusCodes.Status201Created, _ajustes);
            }
            catch (Exception ex)
            { 
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult PUT(string id, [FromBody] Ajustes value)
        {
            var _ajustes = ajustesS.Get(id);

            if (_ajustes == null)
            {
                return NotFound();
            }

            ajustesS.Update(id, value);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var _ajustes = ajustesS.Get(id);

            if (_ajustes == null)
            {
                return NotFound();
            }

            ajustesS.Remove(_ajustes);

            return NoContent();
        }
    }
}
