using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
#pragma warning disable CS0660, CS0661
    public class Alumno : Universitario
    {
        #region Atributos

        /// <summary>
        /// Atributos de la clase
        /// </summary>
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Constructor de la clase, inicializa el valor de claseQueToma y llama al constructor de la clase base
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor de la clase, inicializa el valor de estadoCuenta y llama al constructor anterior (que inicializa el atributo claseQueToma)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Sobreescribe el método definido en la clase base, devolverá un string con la clase que toma
        /// </summary>
        /// <returns>string con la clase que toma</returns>
        protected override string ParticiparEnClase()
        {
            return $"TOMA CLASES DE {this.claseQueToma}";
        }

        /// <summary>
        /// Método que evalua si un alumno es igual a una clase, para esto se debe cumplir que el alumno tome esa clase y su estado de cuenta se distinto de deudor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>bool true si se cumple la igualdad, bool false caso contrario</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a.estadoCuenta != EEstadoCuenta.Deudor && a.claseQueToma == clase)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Método que evalua si un alumno es distinto a una clase, para esto llama al método que compara si son iguales (==)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>bool que devuelva el método public static bool operator ==(Alumno a, Universidad.EClases clase)</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }

        /// <summary>
        ///  Método que devolverá todos los datos de quien sea Alumno
        /// </summary>
        /// <returns>string con todos los datos del alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ALUMNOS:");
            sb.AppendLine(base.MostrarDatos());
            
            if(estadoCuenta.ToString().Contains("AlDia"))
                sb.AppendLine("ESTADO DE CUENTA: Cuota al día");
            else
                sb.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta}");

            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Sobreescribirá el método ToString() llamando al método MostrarDatos() para hacerlo de visibilidad pública
        /// </summary>
        /// <returns> string que devuelva protected override string MostrarDatos()</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Enumerados

        /// <summary>
        /// Enum de la clase
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }

        #endregion
    }
}
