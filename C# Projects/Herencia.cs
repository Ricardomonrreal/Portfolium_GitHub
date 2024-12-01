public class A
{
    public A()
    {
        Console.WriteLine("Constructor de la clase A");
    }
}

public class B: A
{
    public B()
    {
        Console.WriteLine("Constructor de la clase B");
    }
}

public class C: B
{
    public C()
    {
        Console.WriteLine("Constructor de la clase C");
    }
}

class Programa
{
    static void Main(string[] args)
    {
        C objetoc = new C();
    }
}