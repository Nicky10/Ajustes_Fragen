using Ajustes_Fragen.Modelos;
using Ajustes_Fragen.Servicios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Ajustes_Fragen.Controladores
{
    public class AjustesControlador
    {
        private readonly AjustesServicio _ajustesServicio;

        public AjustesControlador(AjustesServicio bookService)
        {
            _ajustesServicio = bookService;
        }

        [HttpGet]
        public List<Ajustes> Get() =>
            _ajustesServicio.Get();

        [HttpGet("{id:length(24)}", Name = "GetAjustes")]
        public Ajustes Get(string id)
        {
            Ajustes ajuste = _ajustesServicio.Get(id);

            if (ajuste == null)
            {
                return null;
            }

            else return ajuste;
        }

        [HttpPost]
        public String Create(Ajustes ajustes)
        {
            _ajustesServicio.Create(ajustes);

            return ("Ajuste con id" + new { id = ajustes.Id.ToString() } + " Añadido");
        }

        [HttpPut("{id:length(24)}")]
        public String Update(string id, Ajustes ajustes)
        {
            var book = _ajustesServicio.Get(id);

            if (book == null)
            {
                return ("Ajuste con id" + new { id = ajustes.Id.ToString() } + " no encontrado");
            }

            _ajustesServicio.Update(id, ajustes);

            return ("Ajuste con id" + new { id = ajustes.Id.ToString() } + " actualizado");
        }

        [HttpDelete("{id:length(24)}")]
        public String Delete(string id)
        {
            var ajuste = _ajustesServicio.Get(id);

            if (ajuste == null)
            {
                return ("Ajuste con id" + new { id = ajuste.Id.ToString() } + " no encontrado");
            }

            _ajustesServicio.Remove(ajuste.Id);

            return ("Ajuste con id" + new { id = ajuste.Id.ToString() } + " borrado");
        }
    }
}
