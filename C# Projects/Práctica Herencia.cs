public class Persona
{
    protected int dni;
    protected string nombre, apellido, fecha_nacimiento, direccion, ciudad_procedencia;
    public int DNI //propiedad
    {
        set{dni = value;} //hago uso de la variable nombre dentro de la propiedad
        get{return dni;}
    }
    public string Nombre //propiedad
    {
        set{nombre = value;} //hago uso de la variable nombre dentro de la propiedad
        get{return nombre;}
    }
    public string Apellido //propiedad
    {
        set{apellido = value;} //hago uso de la variable nombre dentro de la propiedad
        get{return apellido;}
    }
    public string Fecha_nacimiento //propiedad
    {
        set{fecha_nacimiento = value;} //hago uso de la variable nombre dentro de la propiedad
        get{return fecha_nacimiento;}
    }
    public string Direccion //propiedad
    {
        set{direccion = value;} //hago uso de la variable nombre dentro de la propiedad
        get{return direccion;}
    }
    public string Ciudad_procedencia //propiedad
    {
        set{ciudad_procedencia = value;} //hago uso de la variable nombre dentro de la propiedad
        get{return ciudad_procedencia;}
    }
    public void ImprimirPersona()
    {
        Console.WriteLine("DNI: " + DNI);
        Console.WriteLine("Nombre: " + Nombre);
        Console.WriteLine("Apellido: " + Apellido);
        Console.WriteLine("Fecha de nacimiento: " + Fecha_nacimiento);
        Console.WriteLine("Dirección: " + Direccion);
        Console.WriteLine("Ciudad de procedencia: " + Ciudad_procedencia);
    }
}

public class Paciente: Persona
{
    protected int n_historial;
    protected string sexo, grupo_sangre;
    protected List<string> medicamentos_alergia;
    public int N_historial //propiedad
    {
        set{n_historial = value;} //hago uso de la variable nombre dentro de la propiedad
        get{return n_historial;}
    }
    public string Sexo //propiedad
    {
        set{sexo = value;} //hago uso de la variable nombre dentro de la propiedad
        get{return sexo;}
    }
    public string Grupo_sangre //propiedad
    {
        set{grupo_sangre = value;} //hago uso de la variable nombre dentro de la propiedad
        get{return grupo_sangre;}
    }
    public List<string> Medicamentos
    {
        set {medicamentos_alergia = value;}
        get {return medicamentos_alergia;}
    }
    new public void ImprimirPaciente()
    {
        base.ImprimirPersona();
        Console.WriteLine("Número de historial: " + N_historial);
        Console.WriteLine("Sexo: " + Sexo);
        Console.WriteLine("Grupo de sangre: " + Grupo_sangre);
        Console.WriteLine("Medicamentos que el paciente es alérgico:");
        foreach (string medicamento in Medicamentos)
        {
            Console.WriteLine(" - " + medicamento);
        }
    }
}

public class Empleado: Persona
{
    protected int codigo_empleado, num_horas_extra, horas_laboradas;
    protected string fecha_ingreso, area, cargo;
    public int Codigo_empleado //propiedad
    {
        set{codigo_empleado = value;} //hago uso de la variable nombre dentro de la propiedad
        get{return codigo_empleado;}
    }
    public int Horas_laboradas
    {
        set{horas_laboradas = value;}
        get{return horas_laboradas;}
    }
    public int Num_horas_extra //propiedad
    {
        set{num_horas_extra = value;} //hago uso de la variable nombre dentro de la propiedad
        get{return num_horas_extra;}
    }
    public string Fecha_ingreso //propiedad
    {
        set{fecha_ingreso = value;} //hago uso de la variable nombre dentro de la propiedad
        get{return fecha_ingreso;}
    }
    public string Area //propiedad
    {
        set{area = value;} //hago uso de la variable nombre dentro de la propiedad
        get{return area;}
    }
    public string Cargo
    {
        set{cargo = value;}
        get{return cargo;}
    }
    new public void ImprimirEmpleado()
    {
        base.ImprimirPersona();
        Console.WriteLine("Código de empleado: " + Codigo_empleado);
        Console.WriteLine("Horas laboradas: " + Horas_laboradas);
        Console.WriteLine("Número de horas extra: " + Num_horas_extra);
        Console.WriteLine("Fecha de ingreso: " + Fecha_ingreso);
        Console.WriteLine("Área: " + Area);
        Console.WriteLine("Cargo: " + Cargo);
    }
}
public class EmpleadoPlanilla: Empleado
{
    protected int salario_mensual, porcentaje_adicional;
    public int Salario_mensual //propiedad
    {
        set{salario_mensual = value;} //hago uso de la variable nombre dentro de la propiedad
        get{return salario_mensual;}
    }
    public int Porcentaje_adicional //propiedad
    {
        set{porcentaje_adicional = value;} //hago uso de la variable nombre dentro de la propiedad
        get{return porcentaje_adicional;}
    }
    new public void ImprimirEmpleadoPlanilla()
    {
        base.ImprimirPersona();
        Console.WriteLine("Salario Mensual: " + Salario_mensual);
        Console.WriteLine("Porcentaje Adicional por hora extra: " + Porcentaje_adicional);
    }
}
public class EmpleadoEventual: Empleado
{
    protected int honorarios, num_horas_total;
    protected string fecha_termino;
    public int Honorarios //propiedad
    {
        set{honorarios = value;} //hago uso de la variable nombre dentro de la propiedad
        get{return honorarios;}
    }
    public int Num_horas_totales //propiedad
    {
        get{return Horas_laboradas + Num_horas_extra;}
    }
    public string Fecha_termino
    {
        set{fecha_termino = value;}
        get{return fecha_termino;}
    }
    new public void ImprimirEmpleadoEventual()
    {
        base.ImprimirEmpleado();
        Console.WriteLine("Honorarios por hora: " + Honorarios);
        Console.WriteLine("Número de horas totales: " + Num_horas_totales);
        Console.WriteLine("Fecha de término de contrato" + Fecha_termino);
    }
}
public class Medico: Empleado
{
    protected int num_consultorio;
    protected string especialidad, servicio;
    public string Especialidad
    {
        set{especialidad = value;}
        get{return especialidad;}
    }
    public string Servicio
    {
        set{servicio = value;}
        get{return servicio;}
    }
    public int Num_consultorio
    {
        set{num_consultorio = value;}
        get{return num_consultorio;}
    }
    new public void ImprimirMedico()
    {
        base.ImprimirEmpleado();
        Console.WriteLine("Especialidad: " + Especialidad);
        Console.WriteLine("Servicio: " + Servicio);
        Console.WriteLine("Número de consultorio: " + Num_consultorio);
    }
}
public class CitaMedica
{
    private string fecha;
    private string hora;
    private Paciente paciente;
    private Medico medico;
    public string Fecha
    {
        set {fecha = value;}
        get {return fecha;}
    }

    public string Hora
    {
        set {hora = value;}
        get {return hora;}
    }

    public Paciente Paciente
    {
        set {paciente = value;}
        get {return paciente;}
    }

    public Medico Medico
    {
        set {medico = value;}
        get {return medico;}
    }

    public void ImprimirCita()
    {
        Console.WriteLine("Fecha de la cita: " + Fecha);
        Console.WriteLine("Hora de la cita: " + Hora);
        Console.WriteLine("Paciente: " + Paciente.Nombre + " " + Paciente.Apellido);
        Console.WriteLine("Médico: " + Medico.Nombre + " " + Medico.Apellido);
    }
}

class Programa
{
    static void Main(string[] args)
    {
        List<Medico> medicos = new List<Medico>();
        List<Paciente> pacientes = new List<Paciente>();
        List<CitaMedica> citas = new List<CitaMedica>();

        Empleado empleado1 = new Empleado();
        empleado1.DNI = 00001;
        empleado1.Nombre = "Antonio";
        empleado1.Apellido = "Cortázar";
        empleado1.Fecha_nacimiento = "12/02/2005";
        empleado1.Direccion = "Las Lajas";
        empleado1.Ciudad_procedencia = "Cancún";
        empleado1.Codigo_empleado = 1;
        empleado1.Num_horas_extra = 8;
        empleado1.Horas_laboradas = 40;
        empleado1.Fecha_ingreso = "14/10/2024";
        empleado1.Area = "Cirugía";
        empleado1.Cargo = "Enfermero";
        empleado1.ImprimirEmpleado();
        Console.WriteLine();

        Empleado empleado2 = new Empleado();
        empleado2.DNI = 00002;
        empleado2.Nombre = "Ricardo";
        empleado2.Apellido = "Monrreal";
        empleado2.Fecha_nacimiento = "17/05/2005";
        empleado2.Direccion = "Reg. 219";
        empleado2.Ciudad_procedencia = "Cancún";
        empleado2.Codigo_empleado = 2;
        empleado2.Num_horas_extra = 8;
        empleado2.Horas_laboradas = 40;
        empleado2.Fecha_ingreso = "14/10/2024";
        empleado2.Area = "Cirugía";
        empleado2.Cargo = "Asistente";
        empleado2.ImprimirEmpleado();  
        Console.WriteLine();

        Medico medico1 = new Medico();
        medico1.DNI = 00003;
        medico1.Nombre = "Daniela";
        medico1.Apellido = "Fernández";
        medico1.Fecha_nacimiento = "26/11/2002";
        medico1.Direccion = "Col. Centro";
        medico1.Ciudad_procedencia = "Cancún";
        medico1.Codigo_empleado = 3;
        medico1.Num_horas_extra = 8;
        medico1.Horas_laboradas = 40;
        medico1.Fecha_ingreso = "14/10/2024";
        medico1.Area = "Cirugía";
        medico1.Cargo = "Médica";        
        medico1.Especialidad = "Cirujano";
        medico1.Servicio = "Cirugía";
        medico1.Num_consultorio = 1;
        medico1.ImprimirMedico();
        medicos.Add(medico1);
        Console.WriteLine();

        Medico medico2 = new Medico();
        medico2.DNI = 00004;
        medico2.Nombre = "Silvana";
        medico2.Apellido = "Ramayo";
        medico2.Fecha_nacimiento = "31/08/2005";
        medico2.Direccion = "Av. Talleres";
        medico2.Ciudad_procedencia = "Cancún";
        medico2.Codigo_empleado = 4;
        medico2.Num_horas_extra = 8;
        medico2.Horas_laboradas = 40;
        medico2.Fecha_ingreso = "14/10/2024";
        medico2.Area = "Pediatria";
        medico2.Cargo = "Médica Oftalmóloga";        
        medico2.Especialidad = "Oftalmología Pediátrica";
        medico2.Servicio = "Oftalmología";
        medico2.Num_consultorio = 2;
        medico2.ImprimirMedico();
        medicos.Add(medico2);
        Console.WriteLine();

        Paciente paciente1 = new Paciente();
        paciente1.DNI = 00005;
        paciente1.Nombre = "Gabriela";
        paciente1.Apellido = "Uicab";
        paciente1.Fecha_nacimiento = "01/05/2005";
        paciente1.Direccion = "Av. Leona";
        paciente1.Ciudad_procedencia = "Cancún";
        paciente1.N_historial = 01;
        paciente1.Sexo = "Femenino";
        paciente1.Grupo_sangre = "O+";
        paciente1.Medicamentos = new List<string>{"Amoxicilina", "Carbamazepina"};
        paciente1.ImprimirPaciente();
        pacientes.Add(paciente1);
        Console.WriteLine();

        Paciente paciente2 = new Paciente();
        paciente2.DNI = 00006;
        paciente2.Nombre = "Diego";
        paciente2.Apellido = "Ramírez";
        paciente2.Fecha_nacimiento = "01/10/2005";
        paciente2.Direccion = "Paseos del Mar";
        paciente2.Ciudad_procedencia = "Cancún";
        paciente2.N_historial = 02;
        paciente2.Sexo = "Masculino";
        paciente2.Grupo_sangre = "B+";
        paciente2.Medicamentos = new List<string>{"Amoxicilina", "Fenitoína", "Penicilina"};
        paciente2.ImprimirPaciente();
        pacientes.Add(paciente2);
        Console.WriteLine();

        //Registrar los datos de una cita médica.
        CitaMedica cita1 = new CitaMedica();
        cita1.Fecha = "16/10/2024";
        cita1.Hora = "10:00 AM";
        cita1.Paciente = paciente1;
        cita1.Medico = medico1;
        cita1.ImprimirCita();
        citas.Add(cita1);
        Console.WriteLine();

        CitaMedica cita2 = new CitaMedica();
        cita2.Fecha = "18/11/2024";
        cita2.Hora = "11:00 AM";
        cita2.Paciente = paciente2;
        cita2.Medico = medico1;
        cita2.ImprimirCita();
        citas.Add(cita2);
        Console.WriteLine();

        //Listar los datos de los médicos ordenados en forma descendente por la especialidad. 
        var medicosOrdenados = medicos.OrderByDescending(m => m.Especialidad);
        Console.WriteLine("Médicos ordenados por especialidad (descendente):");
        foreach (var medico in medicosOrdenados)
        {
            Console.WriteLine($"Código de médico: {medico.Codigo_empleado}, Consultorio: {medico.Num_consultorio}, Especialidad: {medico.Especialidad}, Nombre: {medico.Nombre}, Apellido: {medico.Apellido}");
        }

        //Listar los datos (nombres y apellidos) de los pacientes atendidos por un médico determinado (ingresando su código).
        Console.Write("Ingrese el código del médico: ");
        int code = int.Parse(Console.ReadLine());
        Console.WriteLine("Lista de pacientes atendidos: ");
        foreach (var cita in citas)
        {
            if (cita.Medico.Codigo_empleado == code)
            {
                Console.WriteLine($"- {cita.Paciente.Nombre} {cita.Paciente.Apellido}");
            }
        }
        Console.WriteLine();
    }
}

//clase principal para guardar una palabra, puede tener signos, caracteres, mayus o minus
//crear dos clases, un decodificador, que elementos conforman la palabra, si es mayus, minus, si es numero o caracter o letra
//la otra clase es un inversor, solo enfocado a letras, y si hay mayus en la palabra, invertirla a minus, y viceversa