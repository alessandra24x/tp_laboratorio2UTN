using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
#pragma warning disable CS0660, CS0661
    public class Profesor : Universitario
    {
        #region Atributos

        /// <summary>
        /// Atributos de la clase
        /// </summary>
        private Queue<Universidad.EClases> clasesDelDia;
        static Random random;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        public Profesor() { }

        /// <summary>
        /// Constructor estático de la clase, inicializa el valor del objeto random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor de la clase, incializa el atributo clasesDelDia con el valor de una nueva cola de clases, además llama al método _randomClases()
        /// dos veces para generar dos valores de tipo random. Llama al constructor de la clase base
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Sobreescribe el método definido en la clase base, devolverá un string con las clase del día
        /// </summary>
        /// <returns>string con las clases que toma</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA:");
            foreach (Universidad.EClases clases in this.clasesDelDia)
            {
                sb.AppendLine(clases.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// asigna a la cola de clases del día un enum de la clase Universidad de forma random, este enum contiene las clases posibles que podría dar un profesor
        /// </summary>
        protected void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(Enum.GetValues(typeof(Universidad.EClases)).Length));
        }

        /// <summary>
        /// Método que evalua si profesor es igual a una clase, para esto se debe cumplir que el profesor de esa clase, es decir, que la cola contenga esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>bool true si la clase está contenida en la cola clasesDelDía, bool false caso contrario</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return i.clasesDelDia.Contains(clase);
        }

        /// <summary>
        /// Método que evalua si un profesor es distinto a una clase, para esto llama al método que compara si son iguales (==)
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>bool que devuelva el método public static bool operator ==(Profesor i, Universidad.EClases clase)</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        ///  Método que devolverá todos los datos de quien sea Profesor
        /// </summary>
        /// <returns>string con todos los datos del profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());
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
    }
}
