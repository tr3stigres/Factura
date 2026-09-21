class Program
{
    public static void Main()
    {
        decimal importBase = DemanarBase();
        string tipusIVA = DemanarIVA();
        decimal cuotaFinal = CalculCuota(importBase, tipusIVA);
        MostrarResultat(cuotaFinal);
    }
    
    static decimal DemanarBase()
    {
        decimal importBase = 0;
    
        do
        {
            Console.Write("Introdueix la base: ");
            string? importBaseConsola = Console.ReadLine();
            if (!decimal.TryParse(importBaseConsola, out importBase))
            {
                Console.WriteLine("L'import ha de ser un número decimal");
                continue;
            }
            else if (importBase < 1 || importBase > 10000)
            {
                Console.WriteLine("L'import ha de ser un número decimal entre 1 i 10000");
                continue;
            }
            break;
        } while (true);


        return importBase;

    }

    static string DemanarIVA()
    {

        string tipusIVA = "";
        do
        {
            Console.Write("Quin tipus d'IVA apliquem (GENERAL, REDUCIDO, EXENTO): ");
            string? tipusIVAConsola = Console.ReadLine();
            if (tipusIVAConsola != null)
                tipusIVA = tipusIVAConsola.Trim().ToUpper();
            if (tipusIVA != "GENERAL" && tipusIVA != "REDUCIDO" && tipusIVA != "EXENTO")
            {
                Console.WriteLine("S'ha d'aplicar un dels tres tipus: GENERAL, REDUCIDO o EXENTO");
                continue;
            }
            break;
        } while (true);

        return tipusIVA;

    }

    static decimal CalculCuota(decimal importBase, string tipusIVA)
    {
        int? percentatgeIVA = tipusIVA switch
        {
            "GENERAL" => 21,
            "REDUCIDO" => 10,
            "EXENTO" => 0,
            _ => null
        };
        decimal cuotaBase = (importBase * (decimal)percentatgeIVA) / 100;
        decimal cuotaRedondeig = Math.Round(cuotaBase, 2, MidpointRounding.AwayFromZero);
        return Math.Round(importBase + cuotaRedondeig, 2, MidpointRounding.AwayFromZero);
    }

    static void MostrarResultat(decimal cuotaFinal)
    {
        Console.WriteLine($"El preu a final es de : {cuotaFinal:F2}");
    }

}
