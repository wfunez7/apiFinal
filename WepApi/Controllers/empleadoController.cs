using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WepApi.Controllers
{
    public class empleadoController : ApiController
    {
        empleado Currempleado = new empleado();
        public List<empleado> Get()
        {
            return Currempleado.obtenerTodosLosempleados();
        }
    }

}
