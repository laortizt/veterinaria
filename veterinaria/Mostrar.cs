using MySqlX.XDevAPI.Relational;
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
    public partial class Mostrar : Form
    {
        public Mostrar()
        {
            InitializeComponent();
        }

        private void Mostrar_Load(object sender, EventArgs e)
        {
            veterinariaEntities db = new veterinariaEntities();

            var datos = from dato in db.animal
                        select dato;

            dataGridView1.DataSource = datos.ToList();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            veterinariaEntities db = new veterinariaEntities();
            animal anim = db.animal.Find(id);
            db.animal.Remove(anim);
            db.SaveChanges();
            refrescar();
        }

        private void refrescar()
        {
            veterinariaEntities db = new veterinariaEntities();
            var datos = from dato in db.animal
                        select dato;
            dataGridView1.DataSource = datos.ToList();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            Editar objEditar = new Editar(id);
            objEditar.Show();
            this.Hide();
        }

        private void btnMenu2_Click(object sender, EventArgs e)
        {
            Menu objMenu = new Menu();
            objMenu.Show();
            this.Hide();
        }
    }           
}   
