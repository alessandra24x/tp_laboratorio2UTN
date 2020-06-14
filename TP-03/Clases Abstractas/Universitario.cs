using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
#pragma warning disable CS0660, CS0661, CS0659
    public abstract class Universitario : Persona
    {
        #region Atributos

        /// <summary>
        /// Atributo de la clase
        /// </summary>
        private int legajo;
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        public Universitario()
        {

        }

        /// <summary>
        /// Constructor de la clase, inicializa el valor de legajo y llama al constructor de la clase base
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Define un método abtracto que tendrán que implementar las clases derivadas
        /// </summary>
        /// <returns>string</returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Método que evalua si un universitario es igual a otro, para esto se debe cumplir que sean del mismo tipo y su legajo o dni sean iguales
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>bool true si los universitarios son iguales, bool false en caso contrario</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1.GetType() == pg2.GetType() && (pg1.legajo == pg2.legajo || pg1.Dni == pg2.Dni))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Método que evalua si un universitario es distinto a otro, para esto llama al método que compara si son iguales (==)
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>bool que devuelva el método public static bool operator ==(Universitario pg1, Universitario pg2)</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Método que sobreescribe al método Equals para evaluar si el objeto recibido por parametro es del tipo de la clase (Universitario)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>bool true si recibe un objeto que pueda castear de forma explicita a la clase Universitario, bool false en caso contrario</returns>
        public override bool Equals(object obj)
        {
            return (this == (Universitario)obj);
        }

        /// <summary>
        /// Método virtual que devolverá todos los datos de quien sea Universitario
        /// </summary>
        /// <returns>string con todos los datos del universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"LEGAJO NUMERO: {this.legajo}");
            return sb.ToString();
        }
        #endregion
    }
}
