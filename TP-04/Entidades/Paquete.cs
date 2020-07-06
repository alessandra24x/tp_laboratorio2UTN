using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Atributos 

        /// <summary>
        /// Atributos de la clase
        /// </summary>
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public delegate void DelegadoEstado(object sender, EventArgs e);

        public event DelegadoEstado InformaEstado;

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad DireccionEntrega. Get y Set del string direccionEntrega
        /// </summary>
        public string DireccionEntrega
        {
            get => this.direccionEntrega;
            set => this.direccionEntrega = value;
        }

        /// <summary>
        /// Propiedad Estado. Get y Set del enum estado
        /// </summary>
        public EEstado Estado
        {
            get => this.estado;
            set => this.estado = value;
        }

        /// <summary>
        /// Propiedad TrackingID. Get y Set del string trackingID
        /// </summary>
        public string TrackingID
        {
            get => this.trackingID;
            set => this.trackingID = value;
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
            this.estado = EEstado.Ingresado;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Simula el ciclo de vida de un paquete que cambia su estado cada 4 segundos y guarda esa información en la base de datos
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.estado++;
                this.InformaEstado(this, new EventArgs());
            }
            PaqueteDAO.Insertar(this);
        }

        /// <summary>
        /// Devuelve los datos de un paquete
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        /// <summary>
        /// Verifica si un paquete ya esta en la lista
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>true si esta en la lista, false caso contrario</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.trackingID == p2.trackingID;
        }

        /// <summary>
        /// Verifica si un paquete no esta en la lista
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>true si no está en la lista, false caso contrario</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Devuelve los datos de un paquete
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>cadena de string con los datos de un paquete</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", this.TrackingID, this.DireccionEntrega);
        }
        #endregion

        #region Enumerados

        /// <summary>
        /// Enum de la clase
        /// </summary>
        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }

        #endregion
    }
}
