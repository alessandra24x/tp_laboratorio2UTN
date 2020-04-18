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

        public Numero() : this(0) { }

        public Numero(double numero) : this(numero.ToString()) { }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        public static double ValidarNumero(string strNumero)
        {
            if (double.TryParse(strNumero, out double numero)) {
                return numero;
            }
            return 0;
        }

        private string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }

        public static string BinarioDecimal(string n)
        {
            Regex rgx = new Regex(@"\b[01]+\b");
            if (rgx.IsMatch(n))
                return Convert.ToInt32(n, 2).ToString();
            else
                return "Valor inválido";
        }

        public static string DecimalBinario(string n)
        {
            if (int.TryParse(n, out int dec) && dec >= 0)
            {
                return Convert.ToString(dec, 2);
            }
            else
                return "Valor inválido";
        }

        public static string DecimalBinario(double n)
        {
            Convert.ToString(n);
            return DecimalBinario(n);
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
                return double.MinValue;
            else
                return n1.numero / n2.numero;
        }


    }
}
