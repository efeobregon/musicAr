using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform_app_poke
{
    //esta es la clase de la ventana principal
    public partial class frmPokemons : Form
    {
        //Genero un atributo (porque esta dentro de una clase) para manipular luego los datos de la DB
        private List<Pokemon> listaPokemon;

        public frmPokemons()
        {
            InitializeComponent();
        }

        private void frmPokemons_Load(object sender, EventArgs e)
        {
            //invoco clases para acceder a mis datos
            PokemonNegocio negocio = new PokemonNegocio();
            //le indico donde esta el origen de datos
            //listar() va a la DB y me devuelve una lista de datos
            //DataSource recibe un origen de datos y lo modela en la tabla
            //Guardo en listaPokemon lo recibido de la DB y luego manipulo como necesito
            listaPokemon = negocio.listar();
            //Carga la data en la DataGridView,
            //toma todas las propiedades del objeto Pokemon y las despliega en la grilla
            dgvPokemons.DataSource = listaPokemon;
            //Si no quiero ver la columna Url en el DGV entonces
            dgvPokemons.Columns["UrlImagen"].Visible = false;
            //Carga la imagen del primer Pokemon en el PictureBox
            cargarImagen(listaPokemon[0].UrlImagen);

        }

        private void dgvPokemons_SelectionChanged(object sender, EventArgs e)
        {
            //Cuando cambie la seleccion en la grilla quiero que cambie la imagen del Pokemon
            //"Dame el objeto enlazado en la fila actual de la grilla", devuelve un object...
            //Como sabemos que ese object es tipo Pokemon, entonces lo transformamos en Pokemon (casteo explicito)
            //Lo guardamos en una variable Pokemon seleccionado
            Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagen);
        }

        //Hago un metodo privado para capturar excepcion al cargar una imagen
        //Al hacerlo le agrego un try catch a la funcion en lugar de tener que hacerlo cada vez que
        //quiero cargar una imagen
        private void cargarImagen(string imagen)
        {
            try
            {
                pbxPokemon.Load(imagen);
            }
            catch (Exception ex)
            {
                //Le doy una imagen para que cargue si no hay imagen, o mejor dicho si falla el try
                pbxPokemon.Load("https://upload.wikimedia.org/wikipedia/commons/d/d1/Image_not_available.png");
            }

        }
    }
}
