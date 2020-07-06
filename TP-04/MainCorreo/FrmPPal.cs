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

namespace MainCorreo
{
    public partial class FrmPpal : System.Windows.Forms.Form
    {
        /// <summary>
        /// Atributos de la clase
        /// </summary>
        private Correo correo;
        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
        }

        /// <summary>
        /// Actualiza el estado de los paquetes en las listas
        /// </summary>
        private void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();
            foreach (Paquete item in this.correo.Paquetes)
            {
                switch (item.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(item);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(item);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(item);
                        break;
                }
            }
        }

        /// <summary>
        /// Manejador del evento Click en el boton "Agregar"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDireccion.Text) || !(mtxtTrackingID.MaskCompleted))
                    MessageBox.Show("Todos los campos deben contener información", "Llenar Campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    Paquete paquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
                    paquete.InformaEstado += this.paq_InformaEstado;
                    this.correo += paquete;
                    this.ActualizarEstados();
                }
            }
            catch(TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Manejador del evento click en el boton "Mostrar todos".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            if (lstEstadoEntregado.Items.Count > 0 || lstEstadoEnViaje.Items.Count > 0 || lstEstadoIngresado.Items.Count > 0)
                this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
            else
                MessageBox.Show("No hay nada para mostrar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Manejador del evento FormClosing cuando se cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        /// <summary>
        /// Muestra la imformacion de todos los paquetes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                this.rtbMostrar.Clear();
                if (elemento is Correo)
                {
                    this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                }
                else if(elemento is Paquete)
                {
                    this.rtbMostrar.Text = elemento.ToString();
                }
                    elemento.MostrarDatos(elemento).Guardar("salida");
            }
        }

        /// <summary>
        /// Manejador del evento de actualizacion de estado del paquete.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        /// <summary>
        /// Manejador del evento click en la opcion mostrar del menu contextual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
}
