using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    public static void Main()
    {
        Iniciar();
    }
    
    static void Iniciar()
    {

        //base

        bool repetirPregunta = true;
        decimal importBase = 0;
        while (repetirPregunta)
        {
            Console.Write("Introdueix la base: ");
            string? importBaseConsola = Console.ReadLine();
            if (!decimal.TryParse(importBaseConsola, out importBase))
            {
                Console.WriteLine("L'import ha de ser un número decimal");
            } else if (importBase < 1 || importBase > 10000)
            {
                Console.WriteLine("L'import ha de ser un número decimal entre 1 i 10000");
            } else
            {
                repetirPregunta = false;
            }
        }

        //IVA
        repetirPregunta = true;
        string tipusIVA = "";
        int? percentatgeIVA = null;
        while (repetirPregunta)
        {
            Console.Write("Quin tipus d'IVA apliquem (GENERAL, REDUCIDO, EXENTO): ");
            string? tipusIVAConsola = Console.ReadLine();
            if (tipusIVAConsola!= null)
                tipusIVA = tipusIVAConsola.Trim().ToUpper();
            if (tipusIVA != "GENERAL" && tipusIVA != "REDUCIDO" && tipusIVA != "EXENTO")
            {
                Console.WriteLine("S'ha d'aplicar un dels tres tipus: GENERAL, REDUCIDO o EXENTO");
            }
            else
            {
                repetirPregunta = false;
            }
        }

        percentatgeIVA = tipusIVA switch
        {
            "GENERAL" => 21,
            "REDUCIDO" => 10,
            "EXENTO" => 0,
            _ => null
        };

        //càlcul cuota
        decimal cuotaBase = (importBase * (decimal)percentatgeIVA) / 100;

        //redondeig a dos decimals
        decimal cuotaRedondeig = Math.Round(cuotaBase, 2, MidpointRounding.AwayFromZero);

        //mostrar cuota
        decimal cuotaFinal = Math.Round(importBase + cuotaRedondeig, 2, MidpointRounding.AwayFromZero);
        var cultura = CultureInfo.GetCultureInfo("es-ES");
        Console.WriteLine($"El preu a final es de : {cuotaFinal:F2}", cultura);

    }
}
