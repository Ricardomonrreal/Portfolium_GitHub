class Vector
{
    private int[] numeros;
    public void Cargar()
    {
        Console.WriteLine("Cuántos números ingresarás?");
        int cant = int.Parse(Console.ReadLine());
        numeros = new int[cant];
        for (int i = 0; i < numeros.Length; i++)
        {
            Console.Write("Ingrese número: " + (i+1) + ": ");
            numeros[i] = int.Parse(Console.ReadLine());
        }
    }

    public void OrdenarA()
    {
        int num = 0;
        Console.WriteLine();
         for(int i = 0; i < numeros.Length; i++)
         {
                for(int j = 0; j < numeros.Length; j++)
                {
                    if (numeros[i] < numeros[j])
                    {
                        num = numeros [i];
                        numeros [i] = numeros [j];
                        numeros [j] = num;
                    }
                }
         }
    }

    public void OrdenarD()
    {
        int num = 0;
        Console.WriteLine();
        for(int i = 0; i < numeros.Length; i++)
         {
            for(int j = 0; j < numeros.Length; j++)
            {
                if (numeros[i] > numeros[j])
                {
                    num = numeros [i];
                    numeros [i] = numeros [j];
                    numeros [j] = num;
                }
            }
         }
    }

    public void Imprimir()
    {
        Console.WriteLine("¿En qué forma quiere ordenarlo?");
        Console.WriteLine("1 = Ascendente...");
        Console.WriteLine("0 = Descendente...");
        int opt = int.Parse(Console.ReadLine());
        Console.WriteLine();
        switch(opt)
        {
            case 1:
            Console.WriteLine("Números desordenados: ");
            for (int i = 0; i < numeros.Length; i++)
            {
                Console.Write(numeros[i] + " ");
            }
            OrdenarA();
            Console.WriteLine("Números ordenados de manera ascendente");
            for (int i = 0; i < numeros.Length; i++)
            {
                Console.Write(numeros[i] + " ");
            }
            break;

            case 0:
            Console.WriteLine("Números desordenados: ");
            for (int i = 0; i < numeros.Length; i++)
            {
                Console.Write(numeros[i] + " ");
            }
            OrdenarD();
            Console.WriteLine("Números ordenados de manera descendente");
            for (int i = 0; i < numeros.Length; i++)
            {
                Console.Write(numeros[i] + " ");
            }
            break;

            default:
            Console.WriteLine("Opción no válida");
            break;
        }
    }

    static void Main(string[]args)
    {
        Vector objeto = new Vector();
        objeto.Cargar();
        objeto.Imprimir();
    }
}