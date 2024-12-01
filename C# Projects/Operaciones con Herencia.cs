public class Operacion
{
    protected int Valor1;
    protected int Valor2;
    protected int Resultado;
    public int valor1
    {
        set
        {
            Valor1 = value; //utilizamos variable denro de la propiedad
        }
        get
        {
            return Valor1;
        }
    }
    public int valor2
    {
        set
        {
            Valor2 = value; //utilizamos variable denro de la propiedad
        }
        get
        {
            return Valor2;
        }
    }
    public int resultado
    {
        set //inserta
        {
            Resultado = value; //utilizamos variable denro de la propiedad
        }
        get //devuelve
        {
            return Resultado;
        }
    }
}

public class Suma: Operacion //sintaxis de herencia clase_hijo: clase_padre
{
    public void Operar() //método xd
    {
        resultado = valor1 + valor2;
    }
}
public class Restar: Operacion //sintaxis de herencia clase_hijo: clase_padre
{
    public void Operar() //método xd
    {
        resultado = valor1 - valor2;
    }
}

public class Primo: Operacion
{
     public void Operar()
    {
        if (resultado <= 1) 
        {
            Console.WriteLine(resultado + " no es un número primo.");
        }
        else
        {
            bool esPrimo = true;
            for (int i = 2; i <= Math.Sqrt(resultado); i++) 
            {
                if (resultado % i == 0) 
                {
                    esPrimo = false;
                    break;
                }
            }
            if (esPrimo)
            {
                Console.WriteLine(resultado + " es un número primo.");
            }
            else
            {
                Console.WriteLine(resultado + " no es un número primo.");
            }
        }
    }
}

public class Fibonacci: Operacion
{
    public void GenerarSerie(int tope)
    {
        int a = 0;
        int b = 1;

        Console.Write("0 1 ");

        for (int i = 2; a + b <= tope; i++)
        {
            int temp = a + b;
            Console.Write(temp + " ");
            a = b;
            b = temp;
        }
    }
}

class Prueba
{
    static void Main(string[] args)
    {
        Suma sumobjeto = new Suma();
        Restar resobjeto = new Restar();
        Primo priobjeto = new Primo();

        Console.Write("Ingresa el primer valor de la suma: ");
        sumobjeto.valor1 = int.Parse(Console.ReadLine());
        Console.Write("Ingresa el segundo valor de la suma: ");
        sumobjeto.valor2 = int.Parse(Console.ReadLine());

        Console.Write("Ingresa el primer valor de la resta: ");
        resobjeto.valor1 = int.Parse(Console.ReadLine());
        Console.Write("Ingresa el segundo valor de la resta: ");
        resobjeto.valor2 = int.Parse(Console.ReadLine());

        sumobjeto.Operar();
        resobjeto.Operar();

        Console.WriteLine("Suma: " + sumobjeto.resultado);
        Console.WriteLine("Resta: " + resobjeto.resultado);

        priobjeto.resultado = sumobjeto.resultado;
        priobjeto.Operar();

        Fibonacci fib = new Fibonacci();
        Console.WriteLine("Serie de Fibonacci hasta " + sumobjeto.resultado + ":");
        fib.GenerarSerie(sumobjeto.resultado);
    }
}
//private solo puede ser usado en la misma clase o structura
//protected solo puede ser accedido desde la misma clase o una clase derivada