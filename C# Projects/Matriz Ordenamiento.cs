class MatrizAoD
{
    private int[,] matriz;
    int filas = 0;
    int columnas = 0;

    public void CargarMatriz()
    {
        Console.Write("¿Cuántas filas quieres que tenga? ");
        filas = int.Parse(Console.ReadLine());
        Console.Write("¿Cuántas columnas quieres que tenga? ");
        columnas = int.Parse(Console.ReadLine());
        matriz = new int[filas, columnas];
        
        Console.WriteLine("Matriz: ");
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                Console.Write("Ingrese número para la posición (" + (i + 1) + "," + (j + 1) + "): ");
                matriz[i, j] = int.Parse(Console.ReadLine());
            }
        }
        Console.WriteLine();
    }

    public void MetodoBurbujaA()
    {
        for (int i = 0; i < filas; i++) //El ciclo (i,j) funciona como (for = i)
        {
            for (int j = 0; j < columnas; j++)
            {
                for (int k = 0; k < filas; k++) //El ciclo (k,l), funciona como (for = j)
                {
                    for (int l = 0; l < columnas; l++)
                    {
                        if (matriz[k, l] > matriz[i, j])
                        {
                            int aux = matriz[k, l];
                            matriz[k, l] = matriz[i, j];
                            matriz[i, j] = aux;
                        }
                    }
                }
            }
        }
    }

    public void MetodoBurbujaD()
    {
        for (int i = 0; i < filas; i++) //El ciclo (i,j) funciona como (for = i)
        {
            for (int j = 0; j < columnas; j++)
            {
                for (int k = 0; k < filas; k++) //El ciclo (k,l), funciona como (for = j)
                {
                    for (int l = 0; l < columnas; l++)
                    {
                        if (matriz[k, l] < matriz[i, j])
                        {
                            int aux = matriz[k, l];
                            matriz[k, l] = matriz[i, j];
                            matriz[i, j] = aux;
                        }
                    }
                }
            }
        }
    }

    public void Ordenar()
    {
        Console.WriteLine("¿Quieres ordenar la matriz de forma ascendente (1) o descendente (2)? ");
        int aod = int.Parse(Console.ReadLine());

        switch(aod)
        {
            case 1:
                MetodoBurbujaA();
                Console.WriteLine("Matriz ordenada en forma ascendente:");
                break;
            case 2:
                MetodoBurbujaD();
                Console.WriteLine("Matriz ordenada en forma descendente:");
                break;
            default:
                Console.WriteLine("Opción no válida");
                return;
        }

        ImprimirMatriz();
    }

    public void ImprimirMatriz()
    {
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                Console.Write(matriz[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static void Main(string[] args)
    {
        MatrizAoD objeto = new MatrizAoD();
        objeto.CargarMatriz();
        objeto.Ordenar();
    }
}
