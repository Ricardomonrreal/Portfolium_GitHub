/*

•Ricardo Monrreal
•Naomi Elena Ramirez Rendon

*/


using System;
using System.Collections.Generic;

//Clase padre que hereda a Profe y Alumno los datos necesarios para agregarlos
public class Persona
{
    private string nombre;
    private string apellidos;
    private int edad;
    public Persona()
    {
        nombre = "";
        apellidos = "";
        edad = 0;
    }
    public Persona(string nombre, string apellidos, int edad)
    {
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.edad = edad;
    }
    public string Nombre
    {
        set { nombre = value; }
        get { return nombre; }
    }
    public string Apellidos
    {
        set { apellidos = value; }
        get { return apellidos; }
    }
    public int Edad
    {
        set { edad = value; }
        get { return edad; }
    }
}

//Clase Profesor que hereda de Persona
public class Profesor : Persona
{
    private int matriculaProfe;
    public Profesor() : base()
    {
        matriculaProfe = 0;
    }
    public Profesor(string nombre, string apellidos, int edad) : base(nombre, apellidos, edad)
    {
        matriculaProfe = 0;
    }
    public int MatriculaProfe
    {
        set { matriculaProfe = value; }
        get { return matriculaProfe; }
    }
    public void setIdProfesor(int MatriculaProfe)
    {
        this.matriculaProfe = MatriculaProfe;
    }
    public void DatosProfe()
    {
        Console.WriteLine("Datos Profesor. \n Profesor de nombre: " + Nombre + " " + Apellidos + " con Id: " + matriculaProfe);
    }
}

public class Alumno : Persona
{
    protected int matriculaAlumno;
    public List<Calificaciones> calificaciones;
    public Alumno() : base()
    {
        matriculaAlumno = 0;
        calificaciones = new List<Calificaciones>();
    }
    public Alumno(string nombre, string apellidos, int edad) : base(nombre, apellidos, edad)
    {
        matriculaAlumno = 0;
        calificaciones = new List<Calificaciones>();
    }
    public int MatriculaAlumno
    {
        set { matriculaAlumno = value; }
        get { return matriculaAlumno; }
    }
    public void AgregarCalificacion(string idMateria, string nombreMateria, double calificacion)
    {
        calificaciones.Add(new Calificaciones(idMateria, nombreMateria, calificacion));
    }
    public void DatosAlumno()
    {
        Console.WriteLine("Datos Alumno. \n Alumno de nombre: " + Nombre + " " + Apellidos + " con Matricula: " + matriculaAlumno);
        Console.WriteLine("Calificaciones:");
        foreach (Calificaciones calificacion in calificaciones)
        {
            Console.WriteLine($" - ({calificacion.IdMateria} {calificacion.NombreMateria}): {calificacion.Calificacion}");
        }
    }
}

public class Calificaciones
{
    public string idMateria { get; set; }   
    public string NombreMateria { get; set; }
    public double calificacion { get; set; }

    public Calificaciones(string idMateria, string nombreMateria, double calificacion)
    {
        IdMateria = idMateria;
        NombreMateria = nombreMateria;
        Calificacion = calificacion;    
    }
    public string IdMateria
    {
        set { idMateria = value; }
        get { return idMateria; }
    }
    public double Calificacion
    {
        set { calificacion = value; }
        get { return calificacion; }
    }
}

public class Materias
{
    public string nombreMateria { get; set; }
    public string idMateria { get; set; }
    public Profesor asignarProfe { get; set; }
    public List<Alumno> AlumnosInscritos { get; set; }

    public Materias(string idMateria, string nombreMateria)
    {
        this.idMateria = idMateria;
        this.nombreMateria = nombreMateria;
        AlumnosInscritos = new List<Alumno>();
    }

    public void DatosMateria()
    {
        Console.WriteLine($"Materia: {nombreMateria} (ID: {idMateria})");   
        Console.WriteLine($"Profesor: {(asignarProfe != null ? asignarProfe.Nombre + " " + asignarProfe.Apellidos : "Sin asignar")}");
        Console.WriteLine("Alumnos Inscritos:");
        foreach (var alumno in AlumnosInscritos)
        {
            Console.WriteLine($" - {alumno.Nombre} {alumno.Apellidos}");
        }
    }
}



class Programa
{
    static List<Profesor> profesores = new List<Profesor>();
    static List<Alumno> alumnos = new List<Alumno>();
    static List<Materias> materias = new List<Materias>();
    static List<int> matriculasprofes = new List<int>();

    static void Main(string[] args)
    {
        bool salir = false;

        while (!salir)
        {

            Console.WriteLine();
            Console.WriteLine("----  S I S T E M A  ----  E S C O L A R  ----");
            Console.WriteLine();
            Console.WriteLine("1. Agregar");
            Console.WriteLine("2. Asignar");
            Console.WriteLine("3. Listar");
            Console.WriteLine("4. Salir");
            Console.WriteLine();
            Console.Write("Selecciona una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    string subopcion;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("------------------MENÚ AGREGAR------------------");
                    
                        Console.WriteLine();
                        Console.WriteLine("1. Agregar Materia");
                        Console.WriteLine("2. Agregar Profesor");
                        Console.WriteLine("3. Agregar Alumno");
                        Console.WriteLine("4. Regresar");
                        Console.WriteLine();
                        Console.Write("Selecciona una opción: ");
                        subopcion = Console.ReadLine();

                        switch (subopcion)
                        {
                            case "1":
                                Console.Write("ID Materia: ");
                                string idMateria = Console.ReadLine();
                                if (materias.Any(m => m.idMateria == idMateria))
                                {
                                    Console.WriteLine("La materia con este ID ya existe.");
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.Write("Nombre Materia: ");
                                    string nombreMateria = Console.ReadLine();
                                    materias.Add(new Materias(idMateria, nombreMateria));
                                    Console.WriteLine("Materia agregada.");
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                }
                                break;

                            case "2":
                                Console.Write("Nombre: ");
                                string nombreProfe = Console.ReadLine();
                                Console.Write("Apellidos: ");
                                string apellidosProfe = Console.ReadLine();
                                Console.Write("Edad: ");
                                int edadProfe = int.Parse(Console.ReadLine());
                                Console.Write("Matrícula: ");
                                int matriculaProfe = int.Parse(Console.ReadLine());
                                if (matriculasprofes.Contains(matriculaProfe))
                                {
                                    Console.WriteLine("La matrícula ya existe.");
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                    break;
                                }
                                else
                                {
                                    var profesor = new Profesor(nombreProfe, apellidosProfe, edadProfe) { MatriculaProfe = matriculaProfe };
                                    profesores.Add(profesor);
                                    matriculasprofes.Add(matriculaProfe);
                                    Console.WriteLine("Profesor agregado.");
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                }
                                break;

                            case "3":
                                Console.Write("Nombre: ");
                                string nombreAlumno = Console.ReadLine();
                                Console.Write("Apellidos: ");
                                string apellidosAlumno = Console.ReadLine();
                                Console.Write("Edad: ");
                                int edadAlumno = int.Parse(Console.ReadLine());
                                Console.Write("Matrícula: ");
                                int matriculaAlumno = int.Parse(Console.ReadLine());
                                if (alumnos.Any(a => a.MatriculaAlumno == matriculaAlumno))
                                {
                                    Console.WriteLine("La matrícula del alumno ya existe.");
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                }
                                else
                                {
                                    var alumno = new Alumno(nombreAlumno, apellidosAlumno, edadAlumno) { MatriculaAlumno = matriculaAlumno };
                                    alumnos.Add(alumno);
                                    Console.WriteLine("Alumno agregado.");
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                }
                                break;

                            case "4":
                                Console.WriteLine("Regresando al menú principal.");
                                Thread.Sleep(2000);
                                Console.Clear();
                                break;

                            default:
                                Console.WriteLine("Opción no válida en el submenú");
                                break;
                        }
                    } while (subopcion != "4");
                    break;

                case "2":
                    string opcion2;
                    do
                    {                    
                    Console.WriteLine("------------------MENÚ ASIGNAR------------------");
                    Console.WriteLine();

                    Console.WriteLine("1. Asignar Profe a Materia");
                    Console.WriteLine("2. Asignar Alumno a materia");
                    Console.WriteLine("3. Asignar calificaciones a alumno por materia");
                    Console.WriteLine("4. Regresar");
                    Console.WriteLine();
                    Console.Write("Selecciona una opción: ");
                    opcion2 = Console.ReadLine();

                    switch (opcion2)
                    {
                        case "1":
                            Console.WriteLine("Has seleccionado: Profe a Materia");
                            Console.Write("Matricula Profesor: ");
                            int matriculaProfe = int.Parse(Console.ReadLine());
                            Profesor profesor = profesores.Find(p => p.MatriculaProfe == matriculaProfe);
                            if (profesor == null)
                            {
                                Console.WriteLine("La matrícula del profesor no existe.");
                                break;
                            }
                            Console.WriteLine();

                            Console.Write("ID materia: ");
                            string idMateria = Console.ReadLine();
                            Materias materia = materias.Find(m => m.idMateria == idMateria);
                            if (materia != null)
                            {
                                Console.WriteLine($"La materia {materia.nombreMateria} (ID: {materia.idMateria}) se encuentra en la lista.");
                            }
                            else
                            {
                                Console.WriteLine($"La materia con ID {idMateria} NO se encuentra en la lista.");
                                break;
                            }

                            materia.asignarProfe = profesor;
                            Console.WriteLine($"Profesor {profesor.Nombre} {profesor.Apellidos} asignado a la materia {materia.nombreMateria}.");
                            Thread.Sleep(5000);
                            Console.Clear();
                            break;
                        case "2":
                            Console.WriteLine("Has seleccionado: Alumno a Materia");
                            Console.Write("Matricula Alumno: ");
                            int matriculaAlumno = int.Parse(Console.ReadLine());
                            Alumno alumno = alumnos.Find(p => p.MatriculaAlumno == matriculaAlumno);
                            if (alumno == null)
                            {
                                Console.WriteLine("La matrícula del alumno no existe.");
                                break;
                            }
                            Console.WriteLine();

                            Console.Write("ID materia: ");
                            string idMateriaALUMNO = Console.ReadLine();
                            Materias materiaALUMNO = materias.Find(m => m.idMateria == idMateriaALUMNO);
                            if (materiaALUMNO == null)
                            {
                                Console.WriteLine($"La materia {idMateriaALUMNO} NO se encuentra en la lista.");
                                break;
                            }

                            if (!materiaALUMNO.AlumnosInscritos.Contains(alumno))
                            {
                                materiaALUMNO.AlumnosInscritos.Add(alumno);
                                Console.WriteLine($"Alumno {alumno.Nombre} {alumno.Apellidos} inscrito en la materia {materiaALUMNO.nombreMateria}.");
                            }
                            else
                            {
                                Console.WriteLine($"El alumno {alumno.Nombre} {alumno.Apellidos} ya está inscrito en la materia {materiaALUMNO.nombreMateria}.");
                            }

                            Console.WriteLine();
                            Thread.Sleep(5000);
                            Console.Clear();
                            break;
                        case "3":
                            Console.WriteLine("Has seleccionado: Calificaciones");

                            Console.Write("Ingresa la matricula del Alumno: ");
                            int matriculaAlumno_C = int.Parse(Console.ReadLine());
                            Alumno alumno_C = alumnos.Find(c => c.MatriculaAlumno == matriculaAlumno_C);
                            if (alumno_C == null)
                            {
                                Console.WriteLine("La matrícula del alumno no existe.");
                                break;
                            }
                            Console.WriteLine();

                            Console.WriteLine("Materias inscritas:");
                            List<Materias> materiasInscritas = materias.Where(m => m.AlumnosInscritos.Contains(alumno_C)).ToList();
                            for (int i = 0; i < materiasInscritas.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {materiasInscritas[i].nombreMateria} (ID: {materiasInscritas[i].idMateria})");
                                Console.WriteLine();
                            }

                            Console.WriteLine("Selecciona el número de la materia: ");
                            int Materia_Se = int.Parse(Console.ReadLine());

                            if (Materia_Se > materiasInscritas.Count)
                            {
                                Console.WriteLine("Selección invalida");
                                break;
                            }

                            Materias materiaSeleccionada = materiasInscritas[Materia_Se - 1];

                            
                            Console.Write($"Ingresa la calificación para {materiaSeleccionada.nombreMateria}: ");
                            double calificacion = double.Parse(Console.ReadLine());

                            if (calificacion < 0 || calificacion > 10)
                            {
                                Console.WriteLine("La calificación debe estar entre 0 y 10.");
                                break;
                            }

                            
                            alumno_C.AgregarCalificacion(materiaSeleccionada.idMateria, materiaSeleccionada.nombreMateria, calificacion);
                            Console.WriteLine($"Calificación de {calificacion} asignada a {materiaSeleccionada.nombreMateria} para el alumno {alumno_C.Nombre} {alumno_C.Apellidos}.");
                            Console.WriteLine();

                            Console.WriteLine();

                            Thread.Sleep(5000);
                            Console.Clear();
                            break;

                        case "4":
                            Console.WriteLine("Regresando al menú principal.");
                            Thread.Sleep(2000);
                            Console.Clear();
                             break;

                        default:
                            Console.WriteLine("Opción no válida en el submenú");
                            break;

                        }
                    } while (opcion2 != "4");
                    break;

                case "3":
                    string opcion3;
                    do
                    {
                    Console.WriteLine("------------------MENÚ LISTAR------------------");

                    Console.WriteLine();
                    Console.WriteLine("1. Listar Materia");
                    Console.WriteLine("2. Listar Profesor");
                    Console.WriteLine("3. Listar Alumno");
                    Console.WriteLine("4. Regresar");
                    Console.WriteLine();
                    Console.Write("Selecciona una opción: ");
                    opcion3 = Console.ReadLine();

                    switch (opcion3)
                    {
                        case "1":
                            Console.WriteLine("Has seleccionado: Listar Materia");
                            foreach (var materia in materias)
                            {
                                materia.DatosMateria();
                                Console.WriteLine();
                                Thread.Sleep(2000);

                            }
                            break;
                        case "2":
                            Console.WriteLine("Has seleccionado: Listar Profesor");
                            foreach (var profe in profesores)
                            {
                                profe.DatosProfe();
                                Console.WriteLine();
                                Thread.Sleep(2000);
                            }
                            break;
                        case "3":
                            Console.WriteLine("Has seleccionado: Listar Alumno");
                            foreach (var alumno in alumnos)
                            {
                                alumno.DatosAlumno();
                                Console.WriteLine();
                                Thread.Sleep(2000);
                            }
                            break;


                        case "4":
                            Console.WriteLine("Regresando al menú principal.");
                            Thread.Sleep(2000);
                            Console.Clear();
                            break;

                        default:
                            Console.WriteLine("Opción no válida en el submenú");
                            break;
                        }
                    } while (opcion3 != "4");
                    break;

                case "4":
                    Console.WriteLine("Saliendo");
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}