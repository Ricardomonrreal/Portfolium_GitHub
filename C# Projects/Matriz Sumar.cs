class Matriz
{
    private int[,] numeros;
    private int[,] numeros2;
    private int[,] resultado;

    public void Cargar()
    {
        int filas = 0, columnas = 0;
        Console.Write("Ingrese número de filas: ");
        filas = int.Parse(Console.ReadLine());
        Console.Write("Ingrese número de columnas: ");
        columnas = int.Parse(Console.ReadLine());

        numeros = new int [filas,columnas];
        numeros2 = new int [filas,columnas];
        resultado = new int [filas,columnas];
        Console.WriteLine("Primera Matriz: ");
        CargarMatriz(numeros);
        Console.WriteLine("Segunda Matriz: ");
        CargarMatriz(numeros2);
    }

    public void CargarMatriz(int [,] matriz)
    {
        for (int i = 0; i < matriz.GetLength(0); i++) //primero filas
        {
            for (int j = 0; j < matriz.GetLength(1); j++) //segundo columnas
            {
                Console.Write("Ingrese " + (i+1,j+1) + ": ");
                matriz[i,j] = int.Parse(Console.ReadLine());
            }
        }
    }
    public void SumarMatriz()
    {
        for (int i = 0; i < resultado.GetLength(0); i++)
        {
            for (int j = 0; j < resultado.GetLength(1); j++)
            {
                resultado [i,j] = numeros[i,j] + numeros2[i,j];
            }
            Console.WriteLine();
        }
    }
    public void Imprimir()
    {
        Console.WriteLine("Matriz Sumada");
        for (int i = 0; i < resultado.GetLength(0); i++)
        {
            for (int j = 0; j < resultado.GetLength(1); j++)
            {   
                Console.Write("[" + resultado[i,j] + "]\t");
            }
            Console.WriteLine("");
        }
    }

    static void Main(string[]args)
    {
        Matriz objeto = new Matriz();
        objeto.Cargar();
        objeto.SumarMatriz();
        objeto.Imprimir();
    }
}