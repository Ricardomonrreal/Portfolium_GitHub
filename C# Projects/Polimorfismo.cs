public class Inmueble
{
    protected string tipoInmueble;
    protected double precio;

    public void vender()
    {
        Console.WriteLine(tipoInmueble + " VENDIDA por el precio de: " + precio); //polimorfismo
        //uso de un método en diferentes contextos
    }
}

public class Casa: Inmueble
{
    public Casa (string tipo, double prec)
    {
        this.tipoInmueble = tipo;
        this.precio = prec;
    }
}

public class Departamento:Inmueble
{
    public Departamento(string tipo, double prec)
    {
        this.tipoInmueble = tipo;
        this.precio = prec;
    }
}

public class Terreno:Inmueble
{
    public Terreno(string tipo, double prec)
    {
        this.tipoInmueble = tipo;
        this.precio = prec;
    }
}

class Programa
{
    static void Main(string[] args)
    {
        Casa casa = new Casa("Casita", 45);
        casa.vender();
        Departamento departamento = new Departamento("Villas Otoch", 98);
        departamento.vender();
        Terreno terreno = new Terreno("Rancho", 10);
        terreno.vender();
    }
}