namespace BotigaCistella;

class Program
{
    static void Main(string[] args)
    {
        DemanarVenCompr();
    }
    static void DemanarVenCompr()
    {
        Console.WriteLine("Vols entrar com a venedor o com a comprador? ");
        string venCompr = Console.ReadLine();
        MenuVenCompr(venCompr);
    }
    static void MenuVenCompr(string venCompr)
    {
        if (venCompr.ToLower().Equals("comprador"))
        {
            MenuComprador();
        }
        else if(venCompr.ToLower().Equals("venedor"))
        {
            MenuVenedor();
        }
        else
        {
            DemanarVenCompr();
        }
    }
    static void MenuComprador()
    {
        string[] producte = new string[1];
        double[] preu = new double[1];
        int nEspais = 0;
        int nProductes = 0;

        Console.WriteLine("1. Afegir producte");
        Console.WriteLine("2. Ampliar botiga");
        Console.WriteLine("3. Modificar Preu");
        Console.WriteLine("4. Modificar Producte");
        Console.WriteLine("5. Ordenar Producte");
        Console.WriteLine("6. Ordenar Preus");
        Console.WriteLine("7. Mostrar Botiga");

        int numMenu =  Convert.ToInt32(Console.ReadLine());

        switch (numMenu)
        {
            case 1:
                AfegirProducte(producte, preu, ref nEspais, ref nProductes);
                break;

            case 2:
                AmpliarTenda(producte, preu);
                break;

            case 3:
                ModificarPreu(producte, preu);
                break;

            case 4:
                ModificarProducte(producte, preu);
                break;

            case 5:
                OrdenarProducte(producte, preu);
                break;

            case 6:
                MostrarBotiga(producte, preu);
                break;

            case 7:
                OrdenarProducte(producte, preu);
                break;
        }
    }
    static void MenuVenedor()
    {

    }

    static void AfegirProducte(string[] producte, double[] preu, ref int nEspais, ref int nProductes)
    {
        Console.WriteLine("Afegeix un producte: ");
        string producteString = Console.ReadLine();

        Console.WriteLine("Afegeix el preu: ");
        double preuDouble = Convert.ToDouble(Console.ReadLine());

        if (nProductes == nEspais)
        {
            AmpliarTenda(producte, preu);
        }
        else
        {
            producte[nProductes] = producteString;
            preu[nProductes] = preuDouble;
            nProductes++;
        }
    }
    static void AmpliarTenda(string[] producte, double[] preu)
    {
        Console.WriteLine("Quants espais ho vols ampliar?");
        int espaisAmpliar = Convert.ToInt32(Console.ReadLine());

        //Acabar (Crear nou array)
    }
    static void ModificarPreu(string[] producte, double[] preu)
    {
        Console.WriteLine("A quin producte vols modificar-li el preu?");
        string producteModificar = (Console.ReadLine());
        string productesArray=" ";
        int cont = 0;

        while (!producteModificar.Equals(productesArray))
        {
            productesArray=producte[cont];
            cont++;
        }

        Console.WriteLine($"Fica el preu que vols posar-li a {productesArray}: ");
        double preuModificar = Convert.ToDouble(Console.ReadLine());

        preu[cont] = preuModificar;
    }
    static void ModificarProducte(string[] producte, double[] preu)
    {
        Console.WriteLine("A quin producte vols modificar-li el nom?");
        double producteModificar = Convert.ToDouble(Console.ReadLine());
    }
    static void OrdenarProducte(string[] producte, double[] preu)
    {

    }
    static void OrdenarPreus(string[] producte, double[] preu)
    {

    }
    static void MostrarBotiga(string[] producte, double[] preu)
    {
        //Simplement mostrar botigatostring en un Console.Writeline
    }
    static void BotigaToString(string[] producte, double[] preu)
    {
        //Posar tot bonic en un string amb /n etc
    }
}

