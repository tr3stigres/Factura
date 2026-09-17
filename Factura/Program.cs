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
        Console.Write("Introdueix la base: ");
        string? importBaseConsola = Console.ReadLine();
        decimal importBase = 0;

        if (importBaseConsola != null)
        {
            
            if (!decimal.TryParse(importBaseConsola, out importBase))
            {
                Console.WriteLine("L'import ha de ser un número decimal");
                return;
            }

            if (importBase < 0 || importBase > 10000)
            {
                Console.WriteLine("L'import ha de ser entre 1 i 10000");
                return;
            }            
        }
        else
        {
            Console.WriteLine("Error desconegut");
            return;
        }

        //IVA
        Console.Write("Quin tipus d'IVA apliquem (GENERAL, REDUCIDO, EXENTO): ");
        string? tipusIVAConsola = Console.ReadLine();
        int? percentatgeIVA = null;

        if (tipusIVAConsola != null)
        {
            percentatgeIVA = tipusIVAConsola.Trim().ToUpper() switch
            {
                "GENERAL" => 21,
                "REDUCIDO" => 10,
                "EXENTO" => 0,
                _ => null
            };

            if (percentatgeIVA == null)
            {
                Console.WriteLine("S'ha d'aplicar un dels tres tipus: GENERAL, REDUCIDO o EXENTO");
                return;
            }
        }
        else
        {
            Console.WriteLine("Error desconegut");
            return;
        }



        //càlcul cuota
        decimal cuotaBase = (importBase * (decimal)percentatgeIVA) / 100;

        //redondeig a dos decimals
        decimal cuotaRedondeig = Math.Round(cuotaBase, 2, MidpointRounding.AwayFromZero);

        //mostrar cuota
        decimal cuotaFinal = Math.Round(importBase + cuotaRedondeig, 2, MidpointRounding.AwayFromZero);
        var cultura = CultureInfo.GetCultureInfo("es-ES");
        Console.WriteLine($"El preu a final es de : {cuotaFinal}", cultura);

    }
}
