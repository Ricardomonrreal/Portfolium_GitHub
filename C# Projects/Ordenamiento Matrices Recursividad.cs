public class Recursividad
{
    int [,] matriz;
    int filas, columnas = 0;   

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
    void Ordenar(int[,] matriz, int totalElementos)
    {
        if (totalElementos <= 1)
            return;

        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas - 1; j++)
            {
                if (matriz[i, j] > matriz[i, j + 1])
                {
                    int aux = matriz[i, j];
                    matriz[i, j] = matriz[i, j + 1];
                    matriz[i, j + 1] = aux;
                }
            }

            // Comparar el último elemento de la fila actual con el primer elemento de la siguiente fila
            if (i < filas - 1 && matriz[i, columnas - 1] > matriz[i + 1, 0])
            {
                int aux = matriz[i, columnas - 1];
                matriz[i, columnas - 1] = matriz[i + 1, 0];
                matriz[i + 1, 0] = aux;
            }
        }
        Ordenar(matriz, totalElementos - 1); //Llamamos recursividad
    }
    void Procesar()
    {
        Ordenar(matriz, filas * columnas);
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
        Recursividad objeto = new Recursividad();
        objeto.CargarMatriz();
        Console.WriteLine("Matriz original: ");
        objeto.ImprimirMatriz();
        Console.WriteLine();
        objeto.Procesar();
        Console.WriteLine("Matriz ordenada: ");
        objeto.ImprimirMatriz();
    }
}