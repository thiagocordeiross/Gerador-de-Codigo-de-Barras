using System;
using System.Collections.Generic;
using System.Linq;

namespace Gerador.EAN
{
    public static class EAN13
    {
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);
        public static string LimparEspacos(this string valor) => valor.IsNullOrEmpty() || valor.Length <= 0 ? valor : valor.Trim();

        public static string GerarCodigoBarras(string pais, string empresa, string codigo)
        {
            var numArray1 = new int[12]
            {
                1,
                3,
                1,
                3,
                1,
                3,
                1,
                3,
                1,
                3,
                1,
                3
            };
            var numArray2 = new int[12];
            var str = pais + empresa + codigo;
            for (var index = 0; index < str.Length; ++index)
                numArray2[index] = numArray1[index] * ((int)Convert.ToInt16(str[index]) - 48);
            var num1 = ((IEnumerable<int>)numArray2).Sum();
            var num2 = (num1 % 10 == 0 || num1 <= 10 ? (num1 >= 10 ? num1 / 10 : 1) : num1 / 10 + 1) * 10 - num1;
            return str + (object)num2;
        }

        public static bool Validar(string valor)
        {
            try
            {
                var str1 = valor.LimparEspacos();
                var ch = str1[str1.Length - 1];
                var num1 = int.Parse(ch.ToString());
                var str2 = str1.Substring(0, str1.Length - 1);
                var str3 = "3131313131313".Substring("3131313131313".Length - str2.Length, str2.Length);
                var num2 = 0;
                for (var index = 0; index <= str2.Length - 1; ++index)
                {
                    ch = str2[index];
                    var num3 = int.Parse(ch.ToString());
                    ch = str3[index];
                    var num4 = int.Parse(ch.ToString());
                    var num5 = num3 * num4;
                    num2 += num5;
                }
                var num6 = 10 - num2 % 10;
                return num1 == (num6 == 10 ? 0 : num6);
            }
            catch (Exception)
            {
                return false;
            }
        }

    }

}
