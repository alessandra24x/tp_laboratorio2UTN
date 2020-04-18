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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Reset();
        }

        private void Limpiar()
        {
            txtNumero1.Text = "";
            comboBoxOperador.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultadoOperacion = Operar(txtNumero1.Text, txtNumero2.Text, comboBoxOperador.Text);
            lblResultado.Text = resultadoOperacion.ToString();
            Reset();
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            return Calculadora.Operar(num1, num2, operador);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
            ValidarBotones();
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
            ValidarBotones();
        }

        private void ValidarBotones()
        {
            btnConvertirADecimal.Enabled = !btnConvertirADecimal.Enabled;
            if(btnConvertirADecimal.Enabled)
            {
                btnConvertirADecimal.Enabled = false;
            } else
            {
                btnConvertirADecimal.Enabled = true;
            }
            btnConvertirABinario.Enabled = !btnConvertirABinario.Enabled;
        }

        private void Reset()
        {
            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = false;
        }
    }
}
