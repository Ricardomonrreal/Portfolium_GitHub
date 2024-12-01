class Aleatorio
{
    private int valor;
    private static Random aleatorio = new Random();  
   
    public void Generar()
    {
        valor = aleatorio.Next(1, 256);  
    }
   
    public void Imprimir()
    {
        Console.WriteLine("El valor random es: " + valor);
    }
   
    public int RetornarValor()
    {
        return valor; 
    }
}

class Comparar
{
    private Aleatorio random1, random2, random3, random4, random5, random6;
   
    private char carac1, carac2, carac3, carac4, carac5, carac6;
    private int ascii1, ascii2, ascii3, ascii4, ascii5, ascii6;

    public Comparar()
    {
        random1 = new Aleatorio();
        random2 = new Aleatorio();
        random3 = new Aleatorio();
        random4 = new Aleatorio();
        random5 = new Aleatorio();
        random6 = new Aleatorio();
    }

    public void Cargar()
    {
        Console.WriteLine("Ingrese el caracter 1: ");
        carac1 = char.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el caracter 2: ");
        carac2 = char.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el caracter 3: ");
        carac3 = char.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el caracter 4: ");
        carac4 = char.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el caracter 5: ");
        carac5 = char.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el caracter 6: ");
        carac6 = char.Parse(Console.ReadLine());
    }
    public void Convertir()
    {
        ascii1 = (int)carac1;
        ascii2 = (int)carac2;
        ascii3 = (int)carac3;
        ascii4 = (int)carac4;
        ascii5 = (int)carac5;
        ascii6 = (int)carac6;
    }
    public void CompararCaracteres()
    {
        Console.WriteLine($"Buscando coincidencia para el caracter '{carac1}' con ASCII {ascii1}");
        do
        {
            random1.Generar();
            random1.Imprimir(); 
        } while (ascii1 != random1.RetornarValor());
        Console.WriteLine($"Coincidencia encontrada para el caracter 1: {carac1}\n");

    
        Console.WriteLine($"Buscando coincidencia para el caracter '{carac2}' con ASCII {ascii2}");
        do
        {
            random2.Generar();
            random2.Imprimir(); 
        } while (ascii2 != random2.RetornarValor());
        Console.WriteLine($"Coincidencia encontrada para el caracter 2: {carac2}\n");

        Console.WriteLine($"Buscando coincidencia para el caracter '{carac3}' con ASCII {ascii3}");
        do
        {
            random3.Generar();
            random3.Imprimir(); 
        } while (ascii3 != random3.RetornarValor());
        Console.WriteLine($"Coincidencia encontrada para el caracter 3: {carac3}\n");

        Console.WriteLine($"Buscando coincidencia para el caracter '{carac4}' con ASCII {ascii4}");
        do
        {
            random4.Generar();
            random4.Imprimir(); 
        } while (ascii4 != random4.RetornarValor());
        Console.WriteLine($"Coincidencia encontrada para el caracter 4: {carac4}\n");

        Console.WriteLine($"Buscando coincidencia para el caracter '{carac5}' con ASCII {ascii5}");
        do
        {
            random5.Generar();
            random5.Imprimir();  
        } while (ascii5 != random5.RetornarValor());
        Console.WriteLine($"Coincidencia encontrada para el caracter 5: {carac5}\n");

        Console.WriteLine($"Buscando coincidencia para el caracter '{carac6}' con ASCII {ascii6}");
        do
        {
            random6.Generar();
            random6.Imprimir(); 
        } while (ascii6 != random6.RetornarValor());
        Console.WriteLine($"Coincidencia encontrada para el caracter 6: {carac6}\n");
    }
    static void Main(string[] args)
    {
        Comparar comparar = new Comparar(); 
        comparar.Cargar();
        comparar.Convertir();
        comparar.CompararCaracteres();
    }
}