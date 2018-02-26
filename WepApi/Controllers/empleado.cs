using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WepApi.Models;

namespace WepApi.Controllers
{
    public class empleado
    {
        private empleadoModel data = new empleadoModel();

        public int id { get; set; }
        public string nombre { get; set; }

        public string apellidos { get; set; }
        
        public List<empleado> obtenerTodosLosempleados()
        {
            return data.obtenerempleados();
        }
    }
}