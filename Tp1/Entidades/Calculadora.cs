using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Valida el operador recibido por parametro
        /// </summary>
        /// <param name="operador">string recibido a validar</param>
        /// <returns>Devuelve el string con el operador validado</returns>
        private static string ValidarOperador(string operador)
        {
            switch (operador)
            {
                case "-":
                    return "-";
                case "*":
                    return "*";
                case "/":
                    return "/";
                default:
                    return "+";
            }
        }
        /// <summary>
        /// Realiza la operación indicada según el operador recibido
        /// </summary>
        /// <param name="num1">numero del primer operando</param>
        /// <param name="num2">numero del segundo operando</param>
        /// <param name="operador">operador que delimitara que operacion será realizada</param>
        /// <returns></returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            switch(ValidarOperador(operador))
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    return num1 / num2;
                default:
                    return 0;
            }
        }
    }
}
