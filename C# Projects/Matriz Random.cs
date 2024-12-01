class Constructor
{
    Random r = new Random();
    private int[,] numeros;
    public Constructor()
    {
        numeros = new int[5,5];
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                numeros[i,j] = r.Next(1,100);
            }
        }
    }
    public void Imprimir()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write("[" + numeros[i,j] + "]" + "\t");
            }
            Console.WriteLine();
        }
    }
    static void Main(string[] args)
    {
        Constructor objeto = new Constructor();
        objeto.Imprimir();
    }
}