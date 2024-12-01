public class A
{
    public A(int a) //Imprime el último valor, osea 5, aunque se imprime primero
    {
        Console.WriteLine(a);
    }
}

public class B:A
{
    public B(int b): base (b/2) //base manda a la clase padre 10/2, lo que es 5, clase padre= A
    {
        Console.WriteLine(b);
    }
}

public class C:B
{
    public C(int c): base(c/2) //base manda a la clase padre 20/2, lo que es 10, clase padre= B
    {
        Console.WriteLine(c);
    }
}

class Programa
{
    static void Main(string[] args)
    {
        C objetoc = new C(20);
    }
}