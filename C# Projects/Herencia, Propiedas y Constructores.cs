public class Persona //Clase padre
{
    protected string nombre;
    protected int edad;
    public string Nombre //propiedad
    {
        set{nombre = value;} //hago uso de la variable nombre dentro de la propiedad
        get{return nombre;}
    }
    public int Edad //Propiedad
    {
        set{edad = value;} //hago uso de la variable nombre dentro de la propiedad
        get{return edad;}
    }
    public void Imprimir()
    {
        Console.WriteLine("Nombre: " + Nombre);
        Console.WriteLine("Edad: " + Edad);
    }
}
public class Empleado: Persona //Heredadndo propiedad de la clase Persona
{
    protected float sueldo;
    public float Sueldo //Propiedad
    {
        set{sueldo = value;}
        get{return sueldo;}
    }
    //se hace new y base. para evitar recursividad
    new public void Imprimir() //se hace un new metodo imprimir de la clase hijo
    {
        base.Imprimir(); //con base. estamos llamando al método de la clase padre
        Console.WriteLine("Sueldo: " + Sueldo);
    }
}

public class Estudiante : Persona
{
    protected List<string> materias;
    public Estudiante()
    {
        materias = new List<string>();
    }

    public List<string> Materias
    {
        set { materias = value; }
        get { return materias; }
    }


    new public void Imprimir()
    {
        base.Imprimir();
        Console.WriteLine("Materias:");
        foreach (string materia in Materias)
        {
            Console.WriteLine(" - " + materia);
        }
    }
}

class Programa
{
    static void Main(string[] args)
    {
        Empleado empleado1 = new Empleado();
        Empleado empleado2 = new Empleado();
        Estudiante estudiante1 = new Estudiante();

        empleado1.Edad = 19;
        empleado1.Nombre = "Ricardo";
        empleado1.Sueldo = 1000;
        
        empleado2.Edad = 21;
        empleado2.Nombre = "Daniela";
        empleado2.Sueldo = 1500;    

        estudiante1.Edad = 19;
        estudiante1.Nombre = "Sofia";
        estudiante1.Materias = new List<string>{"Cálculo","POO", "Álgebra"};

        empleado1.Imprimir();
        Console.WriteLine();
        empleado2.Imprimir();
        Console.WriteLine();
        estudiante1.Imprimir();
    }
}