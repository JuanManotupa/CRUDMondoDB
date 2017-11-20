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
using MongoDB.Driver.Builders;

namespace Registro_Personas
{
    public partial class Mostrar : Form
    {
        public Mostrar()
        {
            InitializeComponent();
        }

        private void Mostrar_Load(object sender, EventArgs e)
        {

        }

        private void dgwPersona_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

  

        private void bnEliminar_Click(object sender, EventArgs e)
        {
            int opcion = 0;
            try
            {
                string conexion = "mongodb://localhost";
                var mc = new MongoClient(conexion);
                var server = mc.GetServer();
                var database = server.GetDatabase("Registro_Personas");
                server.Connect();

                var colection = database.GetCollection<Persona>("Persona");
                ObjectId id = ObjectId.Parse(txtId.Text);
                var query = Query<Persona>.EQ(peronsa => peronsa.id, id);
                colection.Remove(query);
                opcion = 1;
                MessageBox.Show("Se elimino el registro");

            }
            catch (Exception error)
            {
                MessageBox.Show("Ocurrio un error" + error);
            }
            txtId.Text = "";
            if (opcion == 1)
            {
                string conexion = "mongodb://localhost";
                var mc = new MongoClient(conexion);
                var server = mc.GetServer();
                var database = server.GetDatabase("Registro_Personas");
                server.Connect();

                var colection = database.GetCollection<Persona>("Persona");
                dgwPersona.DataSource = null;

                dgwPersona.DataSource = colection.FindAll().ToList();

            }
        }

       
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int opcion = 0;
            try
            {
                string conexion = "mongodb://localhost";
                var mc = new MongoClient(conexion);
                var server = mc.GetServer();
                var database = server.GetDatabase("Registro_Personas");
                server.Connect();

                var colection = database.GetCollection<Persona>("Persona");
                ObjectId id = ObjectId.Parse(txtId1.Text);
                var query = Query<Persona>.EQ(x => x.id, id);
                var persona = colection.FindOne(query);
                persona.dni = txtDNI.Text;
                persona.nombre = txtNombre.Text;
                persona.apellido = txtApellido.Text;
                persona.edad = txtEdad.Text;
                persona.correo = txtCorreo.Text;
                colection.Save(persona);
                opcion = 1;
                MessageBox.Show("Se actualizo el registro");

            }
            catch (Exception error)
            {
                MessageBox.Show("Ocurrio un error" + error);
            }
            txtId.Text = "";
            if (opcion == 1)
            {
                string conexion = "mongodb://localhost";
                var mc = new MongoClient(conexion);
                var server = mc.GetServer();
                var database = server.GetDatabase("Registro_Personas");
                server.Connect();

                var colection = database.GetCollection<Persona>("Persona");
                dgwPersona.DataSource = null;

                dgwPersona.DataSource = colection.FindAll().ToList();

            }
        }

        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            paEliminar.Visible = true;
            paActualizar.Visible = false;
        }

        private void actualizarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            paEliminar.Visible = false;
            paActualizar.Visible = true;
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 ob = new Form1();
            ob.Visible = true;
            Visible = false;
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int opcion = 0;
            try
            {
                string conexion = "mongodb://localhost";
                var mc = new MongoClient(conexion);
                var server = mc.GetServer();
                var database = server.GetDatabase("Registro_Personas");
                server.Connect();

                var colection = database.GetCollection<Persona>("Persona");
                ObjectId id = ObjectId.Parse(txtId1.Text);
                var query = Query<Persona>.EQ(x => x.id, id);
                var persona = colection.FindOne(query);
                opcion = 1;
                
                dgwPersona.DataSource = null;

                dgwPersona.DataSource = colection.FindOne();
                MessageBox.Show("Se encontro el registro");

            }
            catch (Exception error)
            {
                MessageBox.Show("Ocurrio un error" + error);
            }
            txtId.Text = "";
                        

            
        }
    }
}
