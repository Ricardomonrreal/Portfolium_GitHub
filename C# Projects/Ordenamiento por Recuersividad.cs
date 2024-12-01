public class Recursividad
{
    int []vec = {312,614,88,22,54};

    void Ordenar(int[] v, int cantidad)
    {
        if (cantidad > 1)
        {
            for (int i = 0; i < cantidad - 1; i++)
            {
                if (v[i] > v[i + 1])
                {
                    int aux = v[i];
                    v[i] = v[i + 1];
                    v[i + 1] = aux;
                }
            }
            Ordenar (v, cantidad - 1);
        }
    }
    void Procesar()
    {
        Ordenar(vec, vec.Length);
    }
    public void Imprimir()
    {
        for (int i = 0; i < vec.Length; i++)
        {
            Console.Write(vec[i] + ", ");
        }
        Console.WriteLine();
    }
    static void Main(string[] args)
    {
        Recursividad objeto = new Recursividad();
        objeto.Imprimir();
        objeto.Procesar();
        objeto.Imprimir();
    }
}