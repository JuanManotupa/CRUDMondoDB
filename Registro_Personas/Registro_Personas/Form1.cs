using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Registro_Personas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string conexion = "mongodb://localhost";
                var mc = new MongoClient(conexion);
                var servidor = mc.GetServer();
                var database = servidor.GetDatabase("Registro_Personas");
                servidor.Connect();
                var colection = database.GetCollection<Persona>("Persona");
                var persona = new Persona {dni = txtDNI.Text, nombre = txtNombre.Text, apellido = txtApellido.Text, edad = txtEdad.Text, correo = txtCorreo.Text};
                colection.Insert(persona);
                MessageBox.Show("Los datos fueron guardados exitosamente"); 

            }catch(Exception error){            
                MessageBox.Show("Ocurrio un error" + error);
            }
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEdad.Text = "";
            txtCorreo.Text = "";

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            Mostrar ventana1 = new Mostrar();
            string conexion = "mongodb://localhost";
            var mc = new MongoClient(conexion);
            var server = mc.GetServer();
            var database = server.GetDatabase("Registro_Personas");
            server.Connect();
            var colection = database.GetCollection<Persona>("Persona");
            ventana1.dgwPersona.DataSource = colection.FindAll().ToList();
            ventana1.Show();
            this.Visible = false;
        }

       }
}
