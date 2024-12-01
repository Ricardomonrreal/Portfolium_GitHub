class Cliente
{
    private string nombre;
    private int monto;
    public Cliente(string nom)
    {
        nombre = nom;
        monto = 0;
    }
    public void Depositar(int m)
    {
        monto = monto + m;
    }
    public void Extraer(int m)
    {
        monto = monto - m;
    }
    public int RetornarMonto()
    {
        return monto;
    }
    public void Imprimir()
    {
        Console.WriteLine(nombre + " Tiene depositado " + monto);
    }
}
class Banco
{
    private Cliente cliente1;
    public void BancoCliente()
    {
        Console.Write("Ingrese su nombre: ");
        string nom = Console.ReadLine();
        cliente1 = new Cliente(nom); //se ingresa nom y se usa el constructor, monto se declara como 0 en el constructor
    }
    public void OperarD()
    {
        Console.Write("Ingrese el monto deseado: ");
        int m = int.Parse(Console.ReadLine());
        cliente1.Depositar(m);
    }
    public void OperarE()
    {
        Console.Write("Ingrese el monto deseado: ");
        int m = int.Parse(Console.ReadLine());
        if (m > cliente1.RetornarMonto())
        {
            Console.WriteLine("Saldo insuficiente");
        }
        else
        {
            cliente1.Extraer(m);
        }
    }
    public void DepositosTotales()
    {
        cliente1.Imprimir();
    }
    static void Main(string[] args)
    {
        Banco objeto = new Banco();
        objeto.BancoCliente();
        Console.Clear();
        int opt = 0;

        while (opt != 4)
        {
            Console.WriteLine("-------------Menú-------------");
            Console.WriteLine("1. Depositar");
            Console.WriteLine("2. Extraer");
            Console.WriteLine("3. Imprimir saldo");
            Console.WriteLine("4. Salir...");
            Console.Write("Opción: ");
            opt = int.Parse(Console.ReadLine());
            switch (opt)
            {
                case 1:
                    objeto.OperarD();
                    Console.WriteLine();
                    break;
                case 2:
                    objeto.OperarE();
                    Console.WriteLine();
                    break;
                case 3:
                    objeto.DepositosTotales();
                    Console.WriteLine();
                    break;
                case 4:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }
        }
    }
}