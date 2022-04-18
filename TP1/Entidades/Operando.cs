using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        /// <summary>
        /// Es un constructor por defecto que asigna el numero 0 al atributo numero.
        /// </summary>
        public Operando()
            : this(0)
        { }

        /// <summary>
        /// Es un constructor que asigna un double al atributo numero.
        /// </summary>
        /// <param name="numero"></param>
        public Operando(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Es un constructor que asigna un string al atributo numero a través de la propiedad set.
        /// </summary>
        /// <param name="strNumero"></param>
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }

        /// <summary>
        /// Es un mtodo que valida que el operando sea un numero.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private double ValidarOperando(string strNumero)
        {
            double retorno = 0;

            if (double.TryParse(strNumero, out retorno))
            {
                return retorno;
            }
            else
            {
                return retorno;
            }
        }

        /// <summary>
        /// Es un propiedad set que llama al método ValidarOperando.
        /// </summary>
        public string Numero
        {
            set
            {
                this.numero = ValidarOperando(Convert.ToString(value));
            }
        }

        /// <summary>
        /// Es un metodo que valida sin un string es un numero binario.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        private bool EsBinario(string binario)
        {
            bool retorno = false;
            int cantidadCaracteres = binario.Length;

            foreach (char caracter in binario)
            {
                if (caracter != '1' && caracter != '0')
                {
                    retorno = false;
                    break;
                }
                else
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Es un mtodo que convierte de Binario a Decimal.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public string BinarioDecimal(string binario)
        {
            double decimalConver = 0;
            string resultado = "Valor inválido";

            if (EsBinario(binario))
            {
                int cantidadCaracteres = binario.Length;
                foreach (char caracter in binario)
                {
                    cantidadCaracteres--;
                    if (caracter == '1')
                    {
                        decimalConver += (int)Math.Pow(2, cantidadCaracteres);
                    }
                }
                resultado = decimalConver.ToString();
            }
            return resultado;
        }

        /// <summary>
        /// Es un metodo que convierte de Decimal a Binario recibiendo un double.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(double numero)
        {
            string valorBinario = string.Empty;
            int resultDiv = (int)numero;
            int restoDiv;

            resultDiv = Math.Abs(resultDiv);

            if (resultDiv > 0)
            {
                do
                {
                    restoDiv = resultDiv % 2;
                    resultDiv /= 2;
                    valorBinario = restoDiv.ToString() + valorBinario;
                } while (resultDiv > 0);
            }
            else
            {
                valorBinario = "Valor inválido";
            }

            return valorBinario;
        }

        /// <summary>
        /// Es un metodo que convierte de Decimal a Binario recibiendo un string.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(string numero)
        {
            string valorBinario = string.Empty; 
            int resultDiv;
            int restoDiv;

            if (int.TryParse(numero, out resultDiv))
            {
                if (Math.Abs(resultDiv) > 0)
                {
                    do
                    {
                        restoDiv = resultDiv % 2;
                        resultDiv /= 2;
                        valorBinario = restoDiv.ToString() + valorBinario;
                    } while (resultDiv > 0);
                }
                else
                {
                    valorBinario = "Valor inválido";
                }
            }

            return valorBinario;
        }

        /// <summary>
        /// Es la sobrecarga de operador -.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Es la sobrecarga de operador +.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Es la sobrecarga de operador *.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Es la sobrecarga de operador /.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator /(Operando n1, Operando n2)
        {
            double retorno;

            if (n2.numero == 0)
            {
                retorno = double.MinValue;
            }
            else
            {
                retorno = n1.numero / n2.numero;
            }
            return retorno;
        }

    }
}
