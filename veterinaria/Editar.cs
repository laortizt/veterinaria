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
    public partial class Editar : Form
    {
        private int id;
        public Editar(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void Editar_Load(object sender, EventArgs e)
        {
            veterinariaEntities db = new veterinariaEntities();
            animal objAnimal = db.animal.Find(id);
            txtNombre.Text = objAnimal.nombre;
            txtEdad.Text = Convert.ToString(objAnimal.edad);
            txtEspecie.Text = objAnimal.especie;
            txtPeso.Text = Convert.ToString(objAnimal.peso);
            labelOcultoId.Text = Convert.ToString(objAnimal.id);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            veterinariaEntities db = new veterinariaEntities();
            int idForm = int.Parse(labelOcultoId.Text);
            animal objAnimal = db.animal.Find(idForm);

            objAnimal.nombre = txtNombre.Text;
            objAnimal.edad = Convert.ToInt32(txtEdad.Text);
            objAnimal.especie = txtEspecie.Text;
            objAnimal.peso = txtPeso.Text;

            db.Entry(objAnimal).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            Menu objMenu = new Menu();
            objMenu.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu objMenu = new Menu();
            objMenu.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
