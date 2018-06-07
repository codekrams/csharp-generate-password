using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCode
{
    class GenerateCode
    {
        static void Main(string[] args)
        {


            long ziffernfolge = generateCode(08, "15");
            Console.WriteLine("Ziffernfolge: " + ziffernfolge);

            string kennung = getLand(ziffernfolge);
            Console.WriteLine("Länderkennung: " + kennung);

            Console.ReadKey();

        }

        private static string getLand(long ziffernfolge)
        {
            long ergebnis;
            long zeichendrei;
            long zeichenzwei;
            long zeicheneins;
 

            ergebnis = (ziffernfolge-(ziffernfolge % 2300)) / 2300;
            ergebnis = (ergebnis - (ergebnis % 54)) /54;
            zeichendrei = ergebnis % 91;
            ergebnis = (ergebnis - (ergebnis % 91))/91;
            zeichenzwei = ergebnis % 91;
            zeicheneins = ergebnis / 91;

            string kennung = Convert.ToChar(zeicheneins).ToString() + Convert.ToChar(zeichenzwei).ToString() + Convert.ToChar(zeichendrei).ToString();

            return kennung;

        }

        private static long generateCode(int kdnr, string datum) {
            long ziffernfolge;
            string kennung=getHerkunft(kdnr);
            string jahr=getKWJahr(datum);
            string kw = jahr.Substring(0, 2);
            string jahrkonkret= jahr.Substring(2);

            ziffernfolge = (((Convert.ToInt64(kennung[0]) * 91 + Convert.ToInt64(kennung[1]))*91 + Convert.ToInt64(kennung[2])) * 54 + Convert.ToInt64(kw)) * 2300 + Convert.ToInt64(jahrkonkret);

            return ziffernfolge;
        }

        private static string getHerkunft(int kdnr) {
            return "GER";
        }

        private static string getKWJahr(string datum)
        {
            return "392011";
        }

    }
}
