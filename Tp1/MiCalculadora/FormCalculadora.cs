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
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            comboBoxOperador.SelectedIndex = 0;
        }

        /// <summary>
        /// Llama a los métodos Limpiar() y Reset()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Reset();
        }

        /// <summary>
        /// Limpia los textbox, combobox y el label del resulado
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "";
            comboBoxOperador.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
        }

        /// <summary>
        /// Llama al método operar y muestra el resultado en el label encargado para esto, finalmente llama al método Reset()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultadoOperacion = Operar(txtNumero1.Text, txtNumero2.Text, comboBoxOperador.Text);
            lblResultado.Text = resultadoOperacion.ToString();
            Reset();
        }

        /// <summary>
        /// Llama al método Operar definido en la biblioteca de clases para permitir realizar la operación correspondiente según los parametros enviados
        /// </summary>
        /// <param name="numero1">primer numero</param>
        /// <param name="numero2">segundo numero</param>
        /// <param name="operador">operador</param>
        /// <returns>Devuelve el resultado de la operacion indicada</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            return Calculadora.Operar(num1, num2, operador);
        }

        /// <summary>
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Llama al método DecimalBinario definido en la biblioteca de clases para permitir hacer la conversión del resultado en binario y mostrarla en el label, finalmente llama al método ValidarBotones()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
            ValidarBotones();
        }

        /// <summary>
        /// Llama al método BinarioDecimal definido en la biblioteca de clases para permitir hacer la conversión del resultado en decimal y mostrarla en el label, finalmente llama al método ValidarBotones()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
            ValidarBotones();
        }

        /// <summary>
        /// Valida el estado de los botones para permitir su uso únicamente cuando sea necesario
        /// </summary>
        private void ValidarBotones()
        {
            btnConvertirADecimal.Enabled = !btnConvertirADecimal.Enabled;
            btnConvertirABinario.Enabled = !btnConvertirABinario.Enabled;
        }

        /// <summary>
        /// Devuelve el estado de los botones al estado inicial (permite converir en binario, no así en decimal)
        /// </summary>
        private void Reset()
        {
            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = false;
        }
    }
}
