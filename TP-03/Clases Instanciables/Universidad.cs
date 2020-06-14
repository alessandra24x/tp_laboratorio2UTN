using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
#pragma warning disable CS0660, CS0661
    public class Universidad
    {
        #region Atributos

        /// <summary>
        /// Atributos de la clase
        /// </summary>
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad Alumnos. Get y Set del atributo alumnos.
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
        /// Propiedad Instructores. Get y Set del atributo profesores.
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Propiedad Jornadas. Get y Set del atributo jornada
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        /// <summary> 
        /// Indexador de la jornada. Get y Set con el indexador que reciba la jornada
        /// </summary>
        /// <param name="i"></param>
        /// <returns>Jornada lista con el indexador recibido</returns>
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de la clase, inicializa las listas de alumnos, profesores y jornada
        /// </summary>
        public Universidad()
        {
            alumnos = new List<Alumno>();
            profesores = new List<Profesor>();
            jornada = new List<Jornada>();
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Método que genera la instancia y la ruta necesaria para llamar al método guardar y que este genere un archivo xml con los datos de la universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>bool true si el método Guardar logra hacer el guardado, bool false caso contrario</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> serializer = new Xml<Universidad>();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml";
            return serializer.Guardar(path, uni);
        }

        /// <summary>
        /// Método que genera la instancia y la ruta necesaria para llamar al método leer y que este lea los datos del archivo xml
        /// </summary>
        /// <returns>Universidad con toda la información del archivo</returns>
        public Universidad Leer()
        {
            Xml<Universidad> deserializer = new Xml<Universidad>();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml";
            deserializer.Leer(path, out Universidad datos);
            return datos;
        }

        /// <summary>
        /// Método que evalua si una universidad es igual a un alumno, para esto se debe cumplir que una universidad contenga a ese alumno
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>bool true si el alumno está contenido en la lista alumnos de la universidad, bool false caso contrario</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            return g.alumnos.Contains(a);
        }

        /// <summary>
        /// Método que evalua si una universidad es igual a un profesor, para esto se debe cumplir que una universidad contenga a ese profesor
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>bool true si el profesor está contenido en la lista profesores de la universidad, bool false caso contrario</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            return g.profesores.Contains(i);
        }

        /// <summary>
        /// Método que evalua si una universidad es igual a una clase, para esto se devolverá al primer profesor que pueda dar esa clase
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>Profesor en caso de encontrar a un profesor que sea igual a la clase, excepcion en caso de no encontrar algún profesor</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor p in u.profesores)
            {
                if(p == clase)
                {
                    return p;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Método que evalua si una universidad es distinta a un alumno, para esto llama al método que compara si son iguales (==)
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>bool que devuelva el método public static bool operator ==(Universidad g, Alumno a)</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Método que evalua si una universidad es distinta a un profesor, para esto llama al método que compara si son iguales (==)
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>bool que devuelva el método public static bool operator ==(Universidad g, Profesor i)</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Método que evalua si una universidad es distinta a una clase, para esto llama al método que compara si son iguales (==)
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>bool que devuelva el método public static Profesor operator ==(Universidad u, EClases clase)</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor p in u.profesores)
            {
                if (p != clase)
                {
                    return p;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Método estático que genera una nueva jornada con la clase, el profesor que la imparte y la lista de alumnos que la toman
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns>Universidad con la lista de jornadas actualizada</returns>
        public static Universidad operator+(Universidad g, EClases clase)
        {
            Jornada nuevaJornada = new Jornada(clase, g == clase);
            foreach (Alumno a in g.alumnos)
            {
                if(a == clase)
                {
                    nuevaJornada.Alumnos.Add(a);
                }
            }
            g.Jornadas.Add(nuevaJornada);
            return g;
        }
         
        /// <summary>
        /// Método que agrega alumnos a la lista de alumnos que contiene la universidad, previa validación para no agregar un mismo alumno mas de una vez
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>Universidad con la lista de alumnos actualizada, excepción en caso que se repita el alumno</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)  
            {
                u.alumnos.Add(a);
                return u;
            }
            throw new AlumnoRepetidoException();
        }

        /// <summary>
        /// Método que agrega profesores a la lista de profesores que contiene la universidad, previa validación para no agregar un mismo profesor mas de una vez
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>Universidad con la lista de profesores actualizada</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesores.Add(i);              
            }
            return u;
        }

        /// <summary>
        ///  Método que devolverá todos los datos de la universidad
        /// </summary>
        /// <returns>string con todos los datos de la universidad</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada jornada in uni.jornada)
            {
                sb.AppendLine(jornada.ToString());
                sb.AppendLine("<------------------------------------->");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Sobreescribirá el método ToString() llamando al método MostrarDatos() para hacerlo de visibilidad pública
        /// </summary>
        /// <returns> string que devuelva private override string MostrarDatos()</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        #endregion

        #region Enumerados

        /// <summary>
        /// Enum de la clase
        /// </summary>
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }
        #endregion
    }
}
