class Dado
{
    private int valor;
    public int Valor //la variable valor se le asigna las propiedas de get y set
    {
        get //devuelve
        {
            return valor;
        }
        private set //establece
        {
            valor = value;
        }
    }
    private static Random aleatorio;
    public Dado() //constructor
    {
        aleatorio = new Random();
    }
    public void Tirar()
    {
        valor = aleatorio.Next(1,7);
    }
    public void Imprimir()
    {
        Console.WriteLine("El valor del dado es: " + valor);
    }
}

class JuegodeDados
{
    //declaramos 3 variables del tipo Dado
    private Dado dado1, dado2, dado3;
    public JuegodeDados() //es un constructor de la clase
    {
        dado1 = new Dado();
        dado2 = new Dado();
        dado3 = new Dado();
    }
    public void Jugar()
    {
        dado1.Tirar();
        dado1.Imprimir();
        dado2.Tirar();
        dado2.Imprimir();
        dado3.Tirar();
        dado3.Imprimir();

        int valor1 = dado1.Valor; //llamo a la propiedad "Valor", con v mayúscula, no a la variable valor.
        int valor2 = dado2.Valor;
        int valor3 = dado3.Valor;

        if (valor1 == valor2 && valor1 == valor3)
        {
            Console.WriteLine("Ganaste!");
        }
        else
        {
            Console.WriteLine("Perdiste ha...");
        }

        char cvalor1 = (char)valor1;
        char cvalor2 = (char)valor2;
        char cvalor3 = (char)valor3;

        Console.WriteLine("Valores: " + cvalor1 + " " + cvalor2 + " " + cvalor3);
    }
    static void Main(string[] args)
    {
        JuegodeDados objeto = new JuegodeDados();
        objeto.Jugar();
    }
}