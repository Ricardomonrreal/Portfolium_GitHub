//Recibir una palabra, convertir a ASCII, almacenarla en un vector, matriz, lista
//dependiendo al código ascii, agregar números random (checar rango de ascii), revolver palabra con otros números random
//la palabra más los caracteres debe ser de 50, en total
//Mostrar original y la revuelta (ya traducida) (crear constructor)

//Decodificar la sopa con los códigos que ya tenemos, separar por letra, número y caracter IsLetter
//una vez separado todo de la palabra original, buscarla
//ingresar una palabra, verificar si la palabra está dentro de la lista de palabras


using System;
using System.Collections.Generic;

//1. Ingresar palabra
public class Palabra_origen
{
    protected string palabra;
    public string Palabra
    {
        get { return palabra; }
        set { palabra = value; }
    }
    public Palabra_origen()  // Constructor
    {
        palabra = "";  
    }
    public void ImprimirPalabra()
    {
        Console.WriteLine("Palabra: " + palabra);
    }
}

//2. 
//Clase para convertir palabra a ASCII y mezclar con números random
public class ConversorMezclador: Palabra_origen
{
    private Random random = new Random();
    protected int[] array_Final = new int[50]; //array de 50 elementos
    protected int[] asciipalabra;
    protected char[] palabrachar;
    private List<int> indices = new List<int>();
    int indicerandom;

    public int[] ConvertirASCIIPalabra()
    {
        palabrachar = Palabra.ToCharArray(); //convertir palabra a char
        asciipalabra = new int[palabrachar.Length];
        for (int i = 0; i < palabrachar.Length; i++)
        {
            asciipalabra[i] = (int)palabrachar[i];
        }
        return asciipalabra;
    }
    public void InicializarIndices()
    {
        for (int i = 0; i < 50; i++)
        {
            indices.Add(i);
        }
    }
    public void MezclarElementos()
    {
        InicializarIndices();

        //rellenar 50 elementos a array_Final
        for (int i = 0; i < array_Final.Length; i++)
        {
            array_Final[i] = random.Next(33, 256);
        }
        
        ConvertirASCIIPalabra();
        for (int i = 0; i < asciipalabra.Length; i++)
        {
            indicerandom = random.Next(0, indices.Count); //de 0 al número de indices disponibles
            array_Final[indices[indicerandom]] = asciipalabra[i]; //seleccionamos un índice del array_Final y lo reemplazamos por el valor ASCII
            indices.RemoveAt(indicerandom); //se quita el índice ya usado
        }  
    }
}

//Clase para decodificar la palabra mezclada entre el array de números random
public class Decodificador: ConversorMezclador
{
    protected char[] stringArray;
    public void ConvertirASCIIArray()
    {
        stringArray = new char[array_Final.Length];

        for (int i = 0; i < array_Final.Length; i++)
        {
            stringArray[i] = Convert.ToChar(array_Final[i]);
        }

        Console.WriteLine("Array mezclado:");
        foreach (char valor in stringArray)
        {
            Console.Write(valor + " ");
        }
        Console.WriteLine();
    }
}

public class Clasificador: Decodificador
{
    protected List<int> letras = new List<int>();
    protected List<int> numeros = new List<int>();
    protected List<int> caracteres = new List<int>();
    
    // Punto 5: Lista de palabras
    private List<string> listaPalabras = new List<string>
    {
        "abrazo", "agua", "alba", "albahaca", "alborada", "alegria", "alfeizar", "algarabia", 
        "alheli", "alma", "almohada", "amanecer", "amapola", "amar", "amigo", "amistad", 
        "amor", "añoranza", "armonia", "aurora", "azahar", "azul", "belleza", "beso", 
        "burbuja", "caleidoscopio", "caricia", "cariño", "chocolate", "cielo", "corazon", 
        "crepusculo", "cristal", "deseo", "dios", "dulzura", "empatia", "esperanza", 
        "estrella", "familia", "fantasia", "fe", "felicidad", "gracias", "hallazgo", 
        "hijo", "humanidad", "humildad", "ilusion", "jazmin", "justicia", "lagrima", 
        "lapislazuli", "lealtad", "libelula", "libertad", "lluvia", "luciernaga", "luna", 
        "luz", "madre", "magia", "manera", "mandarina", "mar", "mariposa", "melancolia", 
        "mujer", "murcielago", "musica", "naturaleza", "nostalgia", "ojala", "palabra", 
        "pasion", "paz", "perdon", "primavera", "respeto", "rocio", "sabiduria", "salud", 
        "sentimiento", "serenidad", "silencio", "oa", "sol", "soledad", 
        "solidaridad", "sonrisa", "soñar", "sublime", "sueño", "susurro", "ternura", 
        "tolerancia", "universo", "utopia", "verdad", "vida"
    };

    public void ClasificarElementos()
    {
        foreach (int c in array_Final)
        {
            if ((c >= 65 && c <= 90) || (c >= 97 && c <= 122))
            {
                letras.Add(c);
            }
            else if (c >= 48 && c <= 57)
            {
                numeros.Add(c);
            }
            else
            {
                caracteres.Add(c);
            }
        }
        //3 listas listas, todas en valores ASCII, pero clasificadas por letra, número y caracter
        Console.WriteLine();
        Console.Write("Letras: "); 
        foreach (int letra in letras)
        {
            Console.Write(Convert.ToChar(letra) + " ");
        }
        Console.WriteLine();

        Console.Write("Números: ");
        foreach (int numero in numeros)
        {
            Console.Write(Convert.ToChar(numero) + " ");
        }
        Console.WriteLine();

        Console.Write("Caracteres: ");
        foreach (int caracter in caracteres)
        {
            Console.Write(Convert.ToChar(caracter) + " ");
        }
        Console.WriteLine();
    }

    public bool VerificarPalabraEnLista()
    {
        Dictionary<char, int> frecuenciaPalabra = Frecuencialetra(Palabra);

        foreach (string palabraEnLista in listaPalabras)
        {
            Dictionary<char, int> frecuenciaPalabraEnLista = Frecuencialetra(palabraEnLista);

            if (DiccionariosIguales(frecuenciaPalabra, frecuenciaPalabraEnLista))
            {
                Console.WriteLine("La palabra " + Palabra + " puede formar la palabra " + palabraEnLista + " en la lista.");
                return true;
            }
        }

        Console.WriteLine("La palabra " + Palabra + " no puede formar ninguna palabra en la lista.");
        return false;
    }

    private Dictionary<char, int> Frecuencialetra(string palabra)
    {
        Dictionary<char, int> frecuenciaLetras = new Dictionary<char, int>();

        foreach (char letra in palabra)
        {
            if (frecuenciaLetras.ContainsKey(letra))
                frecuenciaLetras[letra]++;
            else
                frecuenciaLetras[letra] = 1;
        }

        return frecuenciaLetras;
    }
    private bool DiccionariosIguales(Dictionary<char, int> dic1, Dictionary<char, int> dic2)
    {
        if (dic1.Count != dic2.Count)
            return false;

        foreach (var kvp in dic1)
        {
            if (!dic2.ContainsKey(kvp.Key) || dic2[kvp.Key] != kvp.Value)
                return false;
        }

        return true;
    }
}

class Programa
{
    static void Main(string[] args)
    {
        Clasificador clasificador = new Clasificador();
        clasificador.Palabra = "aaruor";
        clasificador.ImprimirPalabra();
        clasificador.MezclarElementos();
        clasificador.ConvertirASCIIArray();
        clasificador.ClasificarElementos();
        clasificador.VerificarPalabraEnLista();
    }
}