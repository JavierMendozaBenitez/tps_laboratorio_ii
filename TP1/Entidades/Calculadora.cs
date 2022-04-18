using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Es un metodo estático que realiza la operación matematica requerida.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double res = 0;

            switch (Calculadora.ValidarOperador(operador))
            {
                case '+':
                    res = num1 + num2;
                    break;
                case '-':
                    res = num1 - num2;
                    break;
                case '*':
                    res = num1 * num2;
                    break;
                case '/':
                    res = num1 / num2;
                    break;
                default:
                    break;
            }
            return res;
        }

        /// <summary>
        /// Es un metodo estático que valida el operador recibido
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static char ValidarOperador(char operador)
        {
            char retorno;

            switch (operador)
            {
                case '+':
                    retorno = '+';
                    break;
                case '-':
                    retorno = '-';
                    break;
                case '*':
                    retorno = '*';
                    break;
                case '/':
                    retorno = '/';
                    break;
                default:
                    retorno = '+';
                    break;
            }
            return retorno;
        }
    }
}
