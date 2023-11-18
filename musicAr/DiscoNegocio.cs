using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.SqlTypes;

namespace musicAr
{
    internal class DiscoNegocio
    {
        public List<Disco> listar()
        {
            List<Disco> lista = new List<Disco>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Titulo, FechaLanzamiento as Lanzamiento, CantidadCanciones, UrlImagenTapa, E.Descripcion Estilo, T.Descripcion Edicion From DISCOS D, ESTILOS E, TIPOSEDICION T Where E.Id = D.Id And D.Id = T.Id\r\n";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Titulo = (string)lector["Titulo"];
                    aux.CantidadCanciones = lector.GetInt32(2);
                    aux.FechaLanzamiento = lector.GetDateTime(1);
                    aux.UrlImagenTapa = (string)lector["UrlImagenTapa"];
                    aux.Estilo = new Elemento();
                    aux.Estilo.Descripcion = (string)lector["Estilo"];
                    aux.TipoEdicion = new Elemento();
                    aux.TipoEdicion.Descripcion = (string)lector["Edicion"];

                    lista.Add(aux);
                }
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                //permite que no crashee la app, sino que tire el error
                throw ex;
            }
        }
    }
}
