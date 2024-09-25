using System;
using SalonDeBelleza;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SalonDeBellezaV5
{
    public partial class Form1 : Form
    {
        List<Turnero> lista = new List<Turnero>();
        public Form1()
        {
            InitializeComponent();
            

            lblSalida.Text = "";

            CargarCombos();

        }
         
        public void CargarCombos()
        {

            //configuarar los combosbox, asignandole dias y horarios
            //ADD se encarga de agregar un elemento a la lista de elementos del combo box 
            //ITEMS obtiene un objeto que representa la coleccion de los elementos del combo box

            cbxDias.Items.Add("Lunes");
            cbxDias.Items.Add("Miercoles");
            cbxDias.Items.Add("Viernes");

            cbxTurnos.Items.Add("Mañana");
            cbxTurnos.Items.Add("Tarde");

            cbxServicio.Items.Add("Manicura");
            cbxServicio.Items.Add("Pestañas");

            cbxHorarios.Items.Add("09:00 hs");
            cbxHorarios.Items.Add("10:00 hs");
            cbxHorarios.Items.Add("17:00 hs");
            cbxHorarios.Items.Add("18:00 hs");
            cbxHorarios.Items.Add("19:00 hs");


        }


       

        private void btAceptar_Click(object sender, EventArgs e)
        {

            bool aceptar = true;

            string dia = cbxDias.SelectedItem.ToString();
            string turno = cbxTurnos.SelectedItem.ToString();
            string horario = cbxHorarios.SelectedItem.ToString();

            while (aceptar)
            {

                if (dia != null && turno != null && horario != null)
                {
                    string mensaje = "se agendo su turno correctamente";
                    MessageBox.Show(mensaje);
                    lblResultado.Text = $"RESERVADO: El {dia} en el turno de la {turno} a las {horario}";
                    aceptar = false;
                    
                } 

                cbxDias.Text = "";
                cbxHorarios.Text = "";
                cbxTurnos.Text = "";
                cbxServicio.Text = "";
            }



            Turnero nuevoTurno = new Turnero(txtNombre.Text, dia, horario);
            lista.Add(nuevoTurno);
            MessageBox.Show("se guardo el registro correctamente");
           

            

            lblSalida.Text = ArmarSalida();

            LimpiaTxt();

        }

        private string ArmarSalida()
        {
            string salida = "";
            foreach (var turno in lista)
            {
                salida += $"{turno.Nombre} tiene el turno el {turno.Dia} a las {turno.Horario}\r\n";
            }

            return salida;
        }

        private void LimpiaTxt()
        {
            txtNombre.Text = " ";
            txtTelefono.Text = " ";
            txtNombre.Focus();
        }

        private void cbxTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cbxServicio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
