using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;


 namespace WepApi
{
    class conexion
    {
        private DbCommand command;
        private DbConnection conection;
        private IDataReader read;


        public conexion (DbConnection con)
            {
            this.conection= con;
            }

        public void open()
        {
            try
                {
                this.conection.Open();
                //Console.WriteLine("Exito");
                
           }
            catch{Console.WriteLine("ocurrio error");}
        }
       public void close()
       {
        this.conection.Close();
           }

     public DataTable get_consulta (string Consulta)
          {
               this.open();
            
               DataTable Resultado= new DataTable();

               command = conection.CreateCommand();
               command.Connection = conection;
               command.CommandText=Consulta;
               read= command.ExecuteReader();
               Resultado.Load(read);
               read.Close();

            this.close();

            return Resultado;

           }
    }
    }
    
