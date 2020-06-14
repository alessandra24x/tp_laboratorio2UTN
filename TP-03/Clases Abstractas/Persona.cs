using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        #region Atributos
        /// <summary>
        /// Atributos de la clase
        /// </summary>
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad Nombre. Get y Set del atributo nombre previa validación.
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if (this.ValidarNombreApellido(value).Length > 0)
                    this.nombre = value;
            }
        }

        /// <summary>
        /// Propiedad Apellido. Get y Set del atributo apellido previa validación.
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                if (this.ValidarNombreApellido(value).Length > 0)
                    this.apellido = value;
            }
        }

        /// <summary>
        /// Propiedad Nacionalidad. Get y Set del atributo nacionalidad.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Propiedad Dni. Get y Set del atributo dni como int previa validación.
        /// </summary>
        public int Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad StringToDni. Set del atributo dni como string previa validación.
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de la clase.
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor de la clase, inicializa los valores de nombre, apellido, nacionalidad
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor de la clase, inicializa el valor de dni y llama al constructor que recibe nombre, apellido y nacionalidad
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.dni = dni;
        }

        /// <summary>
        /// Constructor de la clase, inicializa el valor de StringToDni y llama al constructor que recibe nombre, apellido y nacionalidad
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Método que valida si un dni se encuentra en un rango de valores determinado para considerarse un dni válido
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>int que representa al dni recibido por parametro</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (!((nacionalidad == ENacionalidad.Argentino && dato > 0 && dato <= 89999999) ||
                (nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999)))
            {
                throw new NacionalidadInvalidaException();
            }
            return dato;
        }

        /// <summary>
        /// Método que valida si un dni se encuentra en un rango y tipo válido
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>int que devuelva el método ValidarDni(nacionalidad, dni);</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;

            if (!int.TryParse(dato, out dni) || dni < 1 || dni > 99999999)
            {
                throw new DniInvalidoException();
            }

            return this.ValidarDni(nacionalidad, dni);
        }

        /// <summary>
        /// Método que valida si el nombre y el apellido no están vacios o están dentro de un rango de carácteres válidos (letras)
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>string recibido por parametro o un string vacio si no pasa la validación</returns>
        private string ValidarNombreApellido(string dato)
        {
            if (string.IsNullOrEmpty(dato) || dato.All(char.IsLetter))
            {
                return dato;
            }
            return string.Empty;
        }

        /// <summary>
        /// Método que sobreescribe el método ToString() con los datos de la Persona
        /// </summary>
        /// <returns>string con todos los datos de la persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"NOMBRE COMPLETO: {this.apellido}, {this.nombre}");
            sb.AppendLine($"NACIONALIDAD: {this.nacionalidad}");
            return sb.ToString();
        }

        #endregion

        #region Enumerados

        /// <summary>
        /// Enum de la clase
        /// </summary>
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        #endregion
    }
}

