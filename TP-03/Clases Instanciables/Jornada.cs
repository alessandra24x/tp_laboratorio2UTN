using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
#pragma warning disable CS0660, CS0661
    public class Jornada
    {
        #region Atributos

        /// <summary>
        /// Atributos de la clase
        /// </summary>
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad Alumnos. Get y Set del atributo alumnos;
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Propiedad Clase. Get y Set del atributo clase.
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Propiedad Instructor. Get y Set del atributo instructor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        #endregion

        /// <summary>
        /// Constructor de la clase, inicialia el atributo alumnos con el valor de una nueva lista de alumnos
        /// </summary>
        #region Constructores
        public Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor de la clase, inicializa los atributos clase e instructor y llama al constructor que no recibe parametros
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) :this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Método que genera la instancia y la ruta necesaria para llamar al método guardar y que este genere un archivo de texto con los datos de la jornada
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>bool true si el método Guardar logra hacer el guardado, bool false caso contrario</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Texto.txt";
            return texto.Guardar(path, jornada.ToString());
        }

        /// <summary>
        /// Método que genera la instancia y la ruta necesaria para llamar al método leer y que este lea los datos del archivo de texto
        /// </summary>
        /// <returns>string con toda la información del archivo</returns>
        public string Leer()
        {
            Texto texto = new Texto();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Texto.txt";
            texto.Leer(path, out string datos);
            return datos;
        }

        /// <summary>
        /// Método que evalua si una jornada es igual a un alumno, para esto se debe cumplir que una jornada contenga a ese alumno
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>bool true si el alumno está contenido en la lista alumnos de la jornada, bool false caso contrario</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return j.alumnos.Contains(a);
        }

        /// <summary>
        /// Método que evalua si una jornada es distinta a un alumno, para esto llama al método que compara si son iguales (==)
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>bool que devuelva el método public static bool operator ==(Jornada j, Alumno a)</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Método que agrega alumnos a la lista de alumnos que contiene la jornada, previa validación para no agregar un mismo alumno mas de una vez
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>Jornada con la lista actualiza, excepción en caso que se repita el alumno</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
                return j;
            }
            throw new AlumnoRepetidoException();
        }

        /// <summary>
        /// Método que sobreescribe el método ToString() con los datos de la jornada
        /// </summary>
        /// <returns>string con todos los datos de la jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CLASE DE {this.clase.ToString()} POR: {this.instructor.ToString()}");
            foreach (Alumno a in this.alumnos)
            {
                sb.Append(a.ToString());
            }
            return sb.ToString();
        }
        #endregion
    }
}
