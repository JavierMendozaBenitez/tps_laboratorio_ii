using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Metodo que inicializa el form.
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carga el form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperador.Items.Add("");
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("*");
            cmbOperador.Items.Add("/");

            Limpiar();
        }

        /// <summary>
        /// Evento del botón limpiar que llama al método Limpiar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Es el metodo que limpia los textBox, selecciona el indice 0 del comboBox y deja en blanco el Label.
        /// </summary>
        public void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.SelectedIndex = 0;
            lblResultado.Text = "";
        }

        /// <summary>
        /// Es la Lista donde se guardan las operaciones realizadas.
        /// </summary>
        List<string> listaOperaciones = new List<string>();

        /// <summary>
        /// Es el Evento del botón Operar que realiza la operación solicitada mostrandolo por el listBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {

            string resultado;
            string operacionHecha;

            if (cmbOperador.Text == "")
            {
                operacionHecha = txtNumero1.Text + " " + "+" + " " + txtNumero2.Text + " = " + (Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text.ToString()));
            }
            else
            {
                operacionHecha = txtNumero1.Text + " " + cmbOperador.Text + " " + txtNumero2.Text + " = " + (Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text.ToString()));
            }

            resultado = (Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text.ToString())).ToString();

            listaOperaciones.Add(operacionHecha);
            lstOperaciones.DataSource = null;
            lstOperaciones.DataSource = listaOperaciones;

            lblResultado.Text = resultado;
        }

        /// <summary>
        /// Es el metodo estático que recibe dos números, el operador y luego llama al método Operar de la clase Calculadora.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(String numero1, String numero2, string operador)
        {
            char c;

            double resultado;

            char.TryParse(operador, out c);

            Operando op1 = new Operando(numero1);
            Operando op2 = new Operando(numero2);

            resultado = Calculadora.Operar(op1, op2, c);

            return resultado;
        }

        /// <summary>
        /// Es el Evento del botón Cerrar que cierra la calculadora.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento del botón Convertir a Binario que toma el último resultado de una operación y lo convierte a Binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string resultado;
            string resultadoBinario;

            resultado = (Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text.ToString())).ToString();

            Operando opBin1 = new Operando();


            resultadoBinario = opBin1.DecimalBinario(double.Parse(resultado));
            listaOperaciones.Add(resultadoBinario);
            lstOperaciones.DataSource = null;

            lstOperaciones.DataSource = listaOperaciones;

            lblResultado.Text = resultadoBinario;
        }

        /// <summary>
        /// Es el Evento de botón Convertir a Decimal que toma el ultimo resultado y si es binario lo convierte a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando opDec1 = new Operando();


            string resultadoDecimal;
            string ultimo = listaOperaciones.Last();


            resultadoDecimal = opDec1.BinarioDecimal(ultimo);

            listaOperaciones.Add(resultadoDecimal);
            lstOperaciones.DataSource = null;

            lstOperaciones.DataSource = listaOperaciones;

            lblResultado.Text = resultadoDecimal;
        }

        /// <summary>
        /// Es el Evento que al estar cerrandose el form muestra un cartel preguntando se está seguro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de querer salir?", "Salir", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
