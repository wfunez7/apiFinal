using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WepApi;
using WepApi.Controllers;
using System.Data.SqlClient;
using System.Data;
using Npgsql;
using NpgsqlTypes;



namespace WepApi.Models
{
    public class empleadoModel
    {

        static string server;
        static string bd;
        static string usuario;
        static string pasword;


        conexion con = new conexion(new NpgsqlConnection("Server =localhost; Port = 5432; Database =configuracion; User ID  = postgres; Password = yahaira40"));

        public class Config
        {
            public string bd;
            public string usuario;
            public string pasword;
            public  string server;
        }


        public Config GetConfig(int indexDatabase) 
        {
            DataTable x = con.get_consulta(string .Format("SELECT id_servidor,d_nombre, puerto, usuario,contraseña, name_host FROM servidores INNER JOIN nombrebd ON id_servidores = id_servidores where id_bd = {0}",indexDatabase));

            Config currConfig = new Config();
            
            currConfig.bd = (string)x.Rows[0][1];
            currConfig.usuario = (string)x.Rows[0][3];
            currConfig.pasword = (string)x.Rows[0][4];
            currConfig.server = (string)x.Rows[0][5];

            return currConfig;
            
        }
       
        public List<empleado> obtenerempleados()
        {
            Config currConfig =  GetConfig(1);

           
            List<empleado> empleados = new List<empleado>();

            DataTable datos2 = con.get_consulta("SELECT concat('SELECT ', RTRIM(cp.d_campos), ' FROM ', RTRIM(t.nombre_tabla), ' ', RTRIM(cd.d_condicion)) FROM tabla t inner join campos cp on  t.id_tabla = cp.id_tabla inner join select_condiciones cd on t.id_tabla = cd.id WHERE t.id_tabla = 1");
            string x = "Server =" + currConfig.server.Trim() + ";Port = 5432; Database =" + currConfig.bd.Trim() + "; User ID  = " + currConfig.usuario.Trim() + "; Password = " + currConfig.pasword.Trim();

            
            conexion conX = new conexion(new NpgsqlConnection(x));

            string i = datos2.Rows[0][0].ToString();

            DataTable datos = conX.get_consulta(i);
            
            foreach (DataRow f in datos.Rows)
            {

               empleado currempleado = new empleado();
                currempleado.id = (int)f.ItemArray[0];
                currempleado.nombre = (string)f.ItemArray[1];
                currempleado.apellidos = (string)f.ItemArray[2];

                empleados.Add(currempleado);

            }

            return empleados;

        }

    }
}