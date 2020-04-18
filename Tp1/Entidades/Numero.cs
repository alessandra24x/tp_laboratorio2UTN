using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Inicializa el numero en 0
        /// </summary>
        public Numero() : this(0) { }

        /// <summary>
        /// inicializa el numero llamando al constructor que devuelve el numero como string
        /// </summary>
        /// <param name="numero">atributo numero</param>
        public Numero(double numero) : this(numero.ToString()) { }

        /// <summary>
        /// Setea el valor numero con el string recibido por parametro
        /// </summary>
        /// <param name="strNumero"> numero como string</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Valida que el numero recibido sea un numero valido.
        /// </summary>
        /// <param name="strNumero">numero como string</param>
        /// <returns>Devuelve el numero si es válido, sino devuelve 0</returns>
        public static double ValidarNumero(string strNumero)
        {
            if (double.TryParse(strNumero, out double numero)) {
                return numero;
            }
            return 0;
        }

        /// <summary>
        /// Setea el numero previamente validado
        /// </summary>
        private string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Recibe un numero binario y lo devuelve como numero decimal
        /// </summary>
        /// <param name="n">numero binario</param>
        /// <returns>string del numero convertido a decimal, sino mensaje de error</returns>
        public static string BinarioDecimal(string n)
        {
            Regex rgx = new Regex(@"\b[01]+\b");
            if (rgx.IsMatch(n))
                return Convert.ToInt32(n, 2).ToString();
            else
                return "Valor inválido";
        }

        /// <summary>
        /// Recibe un numero decimal y lo devuelve como numero binario
        /// </summary>
        /// <param name="n">numero decimal</param>
        /// <returns>string del numero convertido a binario, sino mensaje de error</returns>
        public static string DecimalBinario(string n)
        {
            if (int.TryParse(n, out int dec) && dec >= 0)
            {
                return Convert.ToString(dec, 2);
            }
            else
                return "Valor inválido";
        }

        /// <summary>
        /// Convierte numero en formato double en decimal y se lo pasa al método DecimalBinario
        /// </summary>
        /// <param name="n">numero decimal</param>
        /// <returns>Devuelve el resultado del método DecimalBinario</returns>
        public static string DecimalBinario(double n)
        {
            Convert.ToString(n);
            return DecimalBinario(n);
        }

        /// <summary>
        /// Sobrecarga el operador + para permitir la suma de dos objetos de tipo numero
        /// </summary>
        /// <param name="n1">Objeto de tipo numero</param>
        /// <param name="n2">Objeto de tipo numero</param>
        /// <returns>Devuelve la suma entre los numeros que contienen los objetos</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Sobrecarga el operador - para permitir la resta de dos objetos de tipo numero
        /// </summary>
        /// <param name="n1">Objeto de tipo numero</param>
        /// <param name="n2">Objeto de tipo numero</param>
        /// <returns>Devuelve la resta entre los numeros que contienen los objetos</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga el operador * para permitir la multiplicacion de dos objetos de tipo numero
        /// </summary>
        /// <param name="n1">Objeto de tipo numero</param>
        /// <param name="n2">Objeto de tipo numero</param>
        /// <returns>Devuelve la mutiplicacion entre los numeros que contienen los objetos</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga el operador / para permitir la division de dos objetos de tipo numero
        /// </summary>
        /// <param name="n1">Objeto de tipo numero</param>
        /// <param name="n2">Objeto de tipo numero</param>
        /// <returns>Devuelve division entre los numeros que contienen los objetos</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
                return double.MinValue;
            else
                return n1.numero / n2.numero;
        }
    }
}
