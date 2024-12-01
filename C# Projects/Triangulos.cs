// práctica 1 Viernes 16/08/24

class Triangulo
{
    private float a, b, c; //declarar como privados por mientras, para que sea únicamente de está clase
    public void Inicializar()
    {
        Console.WriteLine("Ingresa primer lado: ");
        a = float.Parse(Console.ReadLine());
        Console.WriteLine("Ingresa segundo lado: ");
        b = float.Parse(Console.ReadLine());
        Console.WriteLine("Ingresa tercer lado: ");
        c = float.Parse(Console.ReadLine());
    }
    public void Lados()
    {
        if(a==b && a==c)
        {
            Console.WriteLine("Es un triángulo equilatero");
        }
        else if(a==b || a==c || b==c)
        {
            Console.WriteLine("Es un triángulo isósceles");
        }
        else
        {
            Console.WriteLine("Es un triángulo escaleno");
        }
    }
    
    static void Main(string[]args)
    {
        Triangulo practica = new Triangulo();
        practica.Inicializar();
        practica.Lados();
    }
}