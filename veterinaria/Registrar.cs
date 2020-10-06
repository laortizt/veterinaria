using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using veterinaria.Models;

namespace veterinaria
{
    public partial class Registrar : Form
    {
        public Registrar()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            veterinariaEntities db = new veterinariaEntities();
            animal newAnimal = new animal();
            newAnimal.nombre = txtNombre.Text;
            newAnimal.edad = Convert.ToInt32(txtEdad.Text);
            newAnimal.especie = txtEspecie.Text;
            newAnimal.peso = txtPeso.Text;

            db.animal.Add(newAnimal);
            db.SaveChanges();
            
            MessageBox.Show("Procesado con Éxito");
            txtNombre.Text = "";
            txtEdad.Text = "";
            txtEspecie.Text  = "";
            txtPeso.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu objMenu = new Menu ();
            objMenu.Show();
            this.Hide();
        }
    }
}
