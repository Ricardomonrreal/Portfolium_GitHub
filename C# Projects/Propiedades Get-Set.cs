class Cliente
{
    private string nombre;
    private int monto;
    public string Nombre //declaración de la propiedad set y get con sus atributos correspondientes
    {
        set{nombre = value;}
        get{return nombre;}
    }
    public int Monto
    {
        set{monto = value;}
        get{return monto;}
    }
    public Cliente(string nom) //constructor
    {   
        nombre = nom;
        monto = 0;
    }
    public void Depositar(int m)
    {
        monto = Monto + m;
    }
    public void Extraer(int m)
    {
        monto = Monto - m;
    }
    public void Imprimir()
    {
        Console.WriteLine(Nombre + " tiene depositado la suma de: " + Monto); //se usan las propiedades get y set de Nombre y Monto
    }
}
class Banco
{
    private Cliente cliente1, cliente2, cliente3;
    public Banco()
    {
        cliente1 = new Cliente("Ale"); //se ingresa nom y se usa el constructor, monto se declara como 0 en el constructor
        cliente2 = new Cliente("Brere");
        cliente3 = new Cliente("Jose");
    }
    public void Operar()
    {
        cliente1.Depositar(2);
        cliente2.Depositar(1);
        cliente3.Depositar(3);
        cliente1.Extraer(1);
    }
    public void DepositosTotales()
    {
        cliente1.Imprimir();
        cliente2.Imprimir();
        cliente3.Imprimir();
        int montototal = cliente1.Monto + cliente2.Monto + cliente3.Monto; //se usan las propiedades get y set de Monto
        Console.WriteLine("Monto total " + montototal);
    }
    static void Main(string[] args)
    {
        Banco objeto = new Banco();
        objeto.Operar();
        objeto.DepositosTotales();
    }
}