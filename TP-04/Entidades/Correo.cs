using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos

        /// <summary>
        /// Atributos de la clase
        /// </summary>
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad Paquetes. Get y Set de la lista de paquetes
        /// </summary>
        public List<Paquete> Paquetes { get => paquetes; set => paquetes = value; }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        public Correo()
        {
            mockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Agrega un paquete a la lista de paquetes e inicia un nuevo subproceso (hilo)
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns>devuelve el correo con todos los paquetes agregados y el subproceso corriendo</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete item in c.Paquetes)
            {
                if (item == p)
                {
                    throw new TrackingIdRepetidoException("El paquete ya esta en la lista.");
                }
            }
            c.paquetes.Add(p);
            Thread thread = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(thread);
            thread.Start();
            return c;
        }

        /// <summary>
        /// Finaliza todos los subprocesos activos
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread thread in this.mockPaquetes)
            {
                if (thread != null && thread.IsAlive)
                    thread.Abort();
            }
        }

        /// <summary>
        /// Muestra los datos de un paquete
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns>cadena de string con los datos de un paquete</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Paquete item in this.paquetes)
            {
                sb.AppendFormat("{0} para {1} ({2})\n", item.TrackingID, item.DireccionEntrega, item.Estado.ToString());
            }
            return sb.ToString();
        }

        #endregion

    }
}
