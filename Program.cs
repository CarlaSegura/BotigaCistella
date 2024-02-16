namespace BotigaCistella;

class Program
{
    //Fet
    static void Main(string[] args)
    {
        DemanarVenCompr();
    }

    //Fet
    static void DemanarVenCompr()
    {
        Console.WriteLine("Vols entrar com a venedor o com a comprador? ");
        string venCompr = Console.ReadLine();
        Console.Clear();
        MenuVenCompr(venCompr);
    }

    //Fet
    static void MenuVenCompr(string venCompr)
    {
        string[] producte = new string[1];
        double[] preu = new double[1];
        int nEspais = 0;
        int nProductes = 0;

        if (venCompr.ToLower().Equals("comprador"))
        {
            MenuComprador(nProductes);
        }
        else if(venCompr.ToLower().Equals("venedor"))
        {
            MenuVenedor(producte, preu, nEspais, nProductes);
        }
        else
        {
            Console.WriteLine("Has de posar o Comprador o Venedor");
            DemanarVenCompr();
        }
    }


    static void MenuVenedor(string[] producteBotiga, double[] preuBotiga, int nEspais, int nProductes)
    {
        Console.WriteLine("1. Afegir producte");
        Console.WriteLine("2. Ampliar botiga");
        Console.WriteLine("3. Modificar Preu");
        Console.WriteLine("4. Modificar Producte");
        Console.WriteLine("5. Ordenar Producte");
        Console.WriteLine("6. Ordenar Preus");
        Console.WriteLine("7. Mostrar Botiga");

        int numMenu =  Convert.ToInt32(Console.ReadLine());
        Console.Clear();

        switch (numMenu)
        {
            case 1:
                Console.WriteLine("Afegeix un producte: ");
                string producteString = Console.ReadLine();

                Console.WriteLine("Afegeix el preu: ");
                double preuDouble = Convert.ToDouble(Console.ReadLine());
                Console.Clear();
                AfegirProducte(producteBotiga, preuBotiga, ref nEspais, ref nProductes, preuDouble, producteString);
                break;

            case 2:
                AmpliarTenda(ref producteBotiga, ref preuBotiga);
                break;

            case 3:
                Console.WriteLine("A quin producte vols modificar-li el preu?");
                string producteModificar = (Console.ReadLine());
                Console.WriteLine($"Fica el preu que vols posar-li a {producteModificar}: ");
                double preuModificar = Convert.ToDouble(Console.ReadLine());
                Console.Clear();
                ModificarPreu(producteBotiga, preuBotiga, producteModificar, preuModificar);
                break;

            case 4:
                Console.WriteLine("A quin producte vols modificar-li el nom?");
                string producteModificarAntic = (Console.ReadLine());
                Console.WriteLine($"Fica el nom que vols posar-li: ");
                string producteModificarNou = Console.ReadLine();
                Console.Clear();
                ModificarProducte(producteBotiga, producteModificarAntic, producteModificarNou);
                break;

            case 5:
                OrdenarProducte(producteBotiga, preuBotiga, nProductes);
                break;

            case 6:
                OrdenarPreus(producteBotiga, preuBotiga, nProductes);
                break;

            case 7:
                Console.WriteLine("On vols mostrar la botiga?");
                Console.WriteLine("1. Consola");
                string onMostrar = Console.ReadLine();
                Console.Clear();

                if (onMostrar.ToLower().Equals("consola"))
                {
                    BotigaToString(producteBotiga, preuBotiga, nProductes);
                }
                else
                {
                    Console.WriteLine("Has de posar consola, ja que encara no estan disponibles les de mes opcions");
                    Console.Clear();
                    MenuVenedor(producteBotiga, preuBotiga, nEspais, nProductes);
                }
                break;

            default:
                Console.WriteLine("Has de ficar un numero del 1 al 7");
                Console.Clear();
                DemanarVenCompr();
                break;
        }
    }
    static void MenuComprador(int nProductes)
    {
        string[] productesCistella = new string[0];
        int[] quantitatProductes = new int[0];

        Console.WriteLine("1. Comprar Producte");
        Console.WriteLine("2. Ordernar Cistella");
        Console.WriteLine("3. Mostra Cistella");
        int numMenu = Convert.ToInt32(Console.ReadLine());
        Console.Clear();

        switch (numMenu)
        {
            case 1:
                Console.WriteLine("Afegeix un producte que vols comprar: ");
                string producteString = Console.ReadLine();

                Console.WriteLine("Afegeix la quantitat que vols: ");
                int quantitat = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                ComprarProducte(productesCistella, quantitatProductes, producteString, quantitat);
                break;

            case 2:

                OrdernarCistella(productesCistella, quantitatProductes, nProductes);
                break;

            case 3:
                Console.WriteLine("On vols mostrar la cistella?");
                Console.WriteLine("1. Consola");
                string onMostrar = Console.ReadLine();
                Console.Clear();

                if (onMostrar.ToLower().Equals("consola"))
                {
                    CistellaToString(productesCistella, quantitatProductes, nProductes);
                }
                else
                {
                    Console.WriteLine("Has de posar consola, ja que encara no estan disponibles les de mes opcions");
                    Console.Clear();
                    MenuComprador(nProductes);
                }

                break;

            default:
                Console.WriteLine("Has de ficar un numero del 1 al 7");
                Console.Clear();
                DemanarVenCompr();
                break;
        }
    }

    //Fet
    static void AfegirProducte(string[] producte, double[] preu, ref int nEspais, ref int nProductes, double preuDouble, string producteString)
    {

        if (nProductes == nEspais)
        {
            AmpliarTenda(ref producte, ref preu);
        }
        else
        {
            producte[nProductes] = producteString;
            preu[nProductes] = preuDouble;
            nProductes++;
        }
    }

    //Fet
    static void AmpliarTenda(ref string[] producte, ref double[] preu)
    {
        Console.WriteLine("Quants espais ho vols ampliar?");
        int espaisAmpliar = Convert.ToInt32(Console.ReadLine());

        string[] auxString = new string[producte.Length+ espaisAmpliar];
        double[] auxDouble = new double[producte.Length + espaisAmpliar];

        for (int i = 0; i < producte.Length; i++)
        {
            auxString[i] = producte[i];
        }
        producte = auxString;

        for (int i = 0; i < preu.Length; i++)
        {
            auxDouble[i] = preu[i];
        }
        preu = auxDouble;

    }

    //Fet
    static void ModificarPreu(string[] producte, double[] preu, string producteModificar, double preuModificar)
    {
        string productesArray=" ";
        int cont = 0;

        while (!producteModificar.Equals(productesArray))
        {
            productesArray=producte[cont];
            cont++;
        }

        preu[cont] = preuModificar;
    }

    //Fet
    static void ModificarProducte(string[] producte, string producteModificarAntic, string producteModificarNou)
    {
        string productesArray = " ";
        int cont = 0;

        while (!producteModificarAntic.Equals(productesArray))
        {
            productesArray = producte[cont];
            cont++;
        }

        producte[cont] = producteModificarNou;
    }

    //Fet
    static void OrdenarProducte(string[] producte, double[] preu, int nProductes)
    {
        for (int numVolta = 0; numVolta < nProductes - 1; numVolta++)
        {
            for (int i = 0; i < nProductes - 1; i++)
            {
                if (producte[i].CompareTo(producte[i + 1]) == 1)
                {
                    string auxString = producte[i];
                    producte[i] = producte[i + 1];
                    producte[i + 1] = auxString;

                    double auxInt = preu[i];
                    preu[i] = preu[i + 1];
                    preu[i + 1] = auxInt;
                }
            }
        }
    }

    //Fet
    static void OrdenarPreus(string[] producte, double[] preu, int nProductes)
    {
        for (int numVolta = 0; numVolta < nProductes - 1; numVolta++)
        {
            for (int i = 0; i < nProductes - 1; i++)
            {
                if (preu[i]>preu[i + 1])
                {
                    double auxInt = preu[i];
                    preu[i] = preu[i + 1];
                    preu[i + 1] = auxInt;

                    string auxString = producte[i];
                    producte[i] = producte[i + 1];
                    producte[i + 1] = auxString;
                }
            }
        }
    }

    //Fet
    static void MostrarBotiga(string totJunt)
    {
        Console.WriteLine(totJunt);
    }

    //Fet
    static void BotigaToString(string[] producte, double[] preu, int nProductes)
    {
        string totJunt = " ";
        for (int cont = nProductes; cont > 0; cont--)
        {
            totJunt = producte[cont] + preu[cont].ToString() + "\n";
        }
        MostrarBotiga(totJunt);
    }

    /*------------------------CISTELLA--------------------------*/
    static void ComprarProducte(string[] producteCistella, int[] quantitatProductes, string producteString, int quantitat)
    {

    }

    //Fet
    static void OrdernarCistella(string[] producte, int[] quantitatProductes, int nProductes)
    {
        for (int numVolta = 0; numVolta < nProductes - 1; numVolta++)
        {
            for (int i = 0; i < nProductes - 1; i++)
            {
                if (producte[i].CompareTo(producte[i + 1])==1)
                {
                    string auxString = producte[i];
                    producte[i] = producte[i + 1];
                    producte[i + 1] = auxString;

                    int auxInt= quantitatProductes[i];
                    quantitatProductes[i] = quantitatProductes[i + 1];
                    quantitatProductes[i + 1] = auxInt;
                }
            }
        }
    }

    //Fet
    static void MostraCistella(string totJunt)
    {
        Console.WriteLine(totJunt);
    }

    //Fet
    static void CistellaToString(string[] producte, int[] quantitatProductes, int nProductes)
    {
        string totJunt = " ";
        for (int cont=nProductes;cont>0;cont--)
        {
            totJunt = producte[cont] + quantitatProductes[cont].ToString()+"\n";
        }
        MostraCistella(totJunt);
    }

    //Fet
    static void Final()
    {
        Console.WriteLine("Vols TORNAR al menu o TANCAR el programa: ");
        string final = Console.ReadLine();
        Console.Clear();

        if (final.ToLower().Equals("tornar"))
        {
            DemanarVenCompr();
        }
        else if (final.ToLower().Equals("tancar"))
        {

        }
        else
        {
            Console.WriteLine("ERROR. Has de posar tancar o tornar");
            Final();
        }
    }
}

