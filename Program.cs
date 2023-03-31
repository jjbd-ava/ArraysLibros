using System;

namespace Libros
{
    class Program
    {
        static void Main(string[] args)
        {
            Libro l1 = new Libro("El nombre del viento", "Patrick Rothfuss", 150);
            Libro l2 = new Libro("La larga marcha", "Stephen King", 120);
            Libro l3 = new Libro("Aftermath","Chuck Wendig",300);
            Libro l4 = new Libro("Matar es fácil","Agatha Christie",500);
            Libro l5 = new Libro("¿Sueñan los androides con ovejas eléctricas?","Philip K. Dick",50);
            Libro l6 = new Libro("It", "Stephen King", 800);
            Libro [] libreria = new Libro[100];
            libreria[0] = l1;
            libreria[1] = l2;
            libreria[2] = l3;
            libreria[3] = l4;
            libreria[4] = l5;
            char seleccion = 'a';
            while (seleccion != '0')
            {
                Console.WriteLine("=================\n¿Qué desea hacer?\n1.- Buscar por título\n2.- Buscar por autor\n3.- Buscar por número de paginas\n4.- Ver toda la librería\n5.- Ver estantería por número\n6.- Añadir un libro en una estantería\n7.- Vaciar una estantería\n8.- Donar varios libros\n0.- Salir\n=================");
                seleccion = Console.ReadLine()[0];
                switch (seleccion)
                {
                    case '1':
                        BuscarTitulo(libreria);
                        break;
                    case '2':
                        BuscarAutor(libreria);
                        break;
                    case '3':
                        BuscarPaginas(libreria);
                        break;
                    case '4':
                        VerLibreria(libreria);
                        break;
                    case '5':
                        VerEstanteria(libreria);
                        break;
                    case '6':
                        NuevoLibro(libreria);
                        break;
                    case '7':
                        QuitarLibro(libreria);
                        break;
                    case '8':
                        DonarLibros(libreria);
                        break;
                    case '0':
                        break;
                    default:
                        Console.WriteLine("Lo siento, eso no parece una opción válida.");
                        break;
                }
            }
        }

        private static int PrimerHueco(Libro[] libreria)
        {
            int libre = 0;
            int i = 0;
            bool encontrado = false;
            while(!encontrado && i < libreria.Length)
            {
                if (libreria[i] == null)
                {
                    encontrado = true;
                    libre = i;
                } else i++;
            }
            return libre;
        }

        private static int ContarHuecos(Libro[] libreria)
        {
            int huecos = 0;
            for(int i = 0; i<libreria.Length; i++)
            {
                if (libreria[i] == null) huecos++;
            }
            return huecos;
        }

        private static void DonarLibros(Libro[] libreria)
        {
            Console.WriteLine("¿Cuántos libros quieres donar?");
            int cantidad;
            while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0 || cantidad > (libreria.Length))
            {
                Console.WriteLine($"Introduce un valor válido. Entre 1 y {libreria.Length}");
            }
            if(cantidad>ContarHuecos(libreria) || ContarHuecos(libreria) <= 0)
            {
                Console.WriteLine("No hay huecos suficientes.");
            }
            else
            {
                string tit;
                string aut;
                int npa;
                for(int i = 0; i < cantidad; i++)
                {
                    Console.WriteLine("¿Cual es el título del libro?");
                    tit = Console.ReadLine();
                    Console.WriteLine("¿Cual es el autor?");
                    aut = Console.ReadLine();
                    Console.WriteLine("¿Cuantas páginas tiene?");
                    while (!int.TryParse(Console.ReadLine(), out npa))
                    {
                        Console.WriteLine("Entrada errónea. ¿Cuanta páginas tiene?");
                    }
                    libreria[PrimerHueco(libreria)] = new Libro(tit, aut, npa);
                }
            }
            
           
        }

        private static void QuitarLibro(Libro[] libreria)
        {
            Console.WriteLine("¿Qué estantería quieres vaciar?");
            int busqueda;
            while(!int.TryParse(Console.ReadLine(),out busqueda) || busqueda < 0 || busqueda > (libreria.Length - 1))
            {
                Console.WriteLine("Elige una estantería válida.");
            }
            if (libreria[busqueda] == null) Console.WriteLine("Parece que esa estantería ya está vaciada.");
            else
            {
                libreria[busqueda] = null;
                Console.WriteLine($"Estantería {busqueda} vaciada.");
            }
                
        }

        private static bool ComprobarHueco(Libro[] libreria)
        {
            bool hueco = false;
            int i = 0;
            while(!hueco && i < libreria.Length)
            {
                if (libreria[i] == null) hueco = true;
                else i++;
            }
            return hueco;
        }

        private static void NuevoLibro(Libro[] libreria)
        {
            if (ComprobarHueco(libreria))
            {
                Console.WriteLine("¿Cual es el título del libro?");
                string tit = Console.ReadLine();
                Console.WriteLine("¿Cual es el autor?");
                string aut = Console.ReadLine();
                Console.WriteLine("¿Cuantas páginas tiene?");
                int npa;
                while (!int.TryParse(Console.ReadLine(), out npa))
                {
                    Console.WriteLine("Entrada errónea. ¿Cuanta páginas tiene?");
                }
                Console.WriteLine("¿En que estantería quieres meterlo?");
                int busqueda = 0;
                while (!int.TryParse(Console.ReadLine(), out busqueda) || busqueda < 0 || busqueda > (libreria.Length - 1))
                {
                    Console.WriteLine("No parece ser una estantería válida.");
                }
                if (libreria[busqueda] != null) Console.WriteLine("Parece que está ocupada.");
                else
                {
                    libreria[busqueda] = new Libro(tit, aut, npa);
                    Console.WriteLine($"Añadido el libro: {libreria[busqueda]} a la estantería {busqueda}.");
                }
            }
            else Console.WriteLine("Parece que no hay hueco.");
               
        }

        private static void VerEstanteria(Libro[] libreria)
        {
            Console.WriteLine($"¿Qué estantería quieres ver? (0-{libreria.Length - 1})");
            int busqueda;
            while(!int.TryParse(Console.ReadLine(), out busqueda) || busqueda<0 || busqueda>(libreria.Length -1))
            {
                Console.WriteLine($"Elige una estantería válida. (0-{libreria.Length - 1})");
            }
            if (libreria[busqueda] != null)
            {
                Console.WriteLine($"La estantería {busqueda} contiene: {libreria[busqueda]}");
            }
            else Console.WriteLine($"Parece que la estantería {busqueda} está vacía.");
        }

        private static void VerLibreria(Libro[] libreria)
        {
            Console.WriteLine("Nuestra librería contiene:\nEstantería | Libro (Título - Autor - Nº páginas) \n--------------------------------------------------------------------------------------");
            for (int i=0; i<libreria.Length; i++)
            {
                if (libreria[i]!=null) Console.WriteLine($"     {i}     | {libreria[i]}.");
            }
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        private static void BuscarPaginas(Libro[] libreria)
        {
            Console.WriteLine("=================\n¿Cómo quieres buscar?\n1.- Libros de más de X páginas\n2.- Libros de menos de X páginas\n3.- Libros con un número exacto de páginas\n==================");
            char eleccion = Console.ReadLine()[0];
            while(eleccion!='1' && eleccion!='2' && eleccion != '3')
            {
                Console.WriteLine("Elige una opción válida.");
                eleccion = Console.ReadLine()[0];
            }
            Console.WriteLine("¿Cuántas páginas?");
            int busqueda;
            while(!int.TryParse(Console.ReadLine(),out busqueda))
            {
                Console.WriteLine("Número introducido erróneo. ¿Cúantas páginas?");
            }
            bool encontrado = false;
            switch (eleccion)
            {
                case '1':
                    for(int i=0; i<libreria.Length; i++)
                    {
                        if (libreria[i] != null && libreria[i].NumPaginas > busqueda)
                        {
                            Console.WriteLine($"{libreria[i]} páginas.");
                            encontrado = true;
                        }
                    }
                    if (!encontrado) Console.WriteLine($"No hay ningún libro con más de {busqueda} páginas.");
                    break;
                case '2':
                    for (int i = 0; i < libreria.Length; i++)
                    {
                        if (libreria[i] != null && libreria[i].NumPaginas < busqueda)
                        {
                            Console.WriteLine($"{libreria[i]} páginas.");
                            encontrado = true;
                        }
                    }
                    if (!encontrado) Console.WriteLine($"No hay ningún libro con menos de {busqueda} páginas.");
                    break;
                case '3':
                    for (int i = 0; i < libreria.Length; i++)
                    {
                        if (libreria[i] != null && libreria[i].NumPaginas == busqueda)
                        {
                            Console.WriteLine($"{libreria[i]} páginas.");
                            encontrado = true;
                        }
                    }
                    if (!encontrado) Console.WriteLine($"No hay ningún libro con {busqueda} páginas.");
                    break;
                default:
                    break;
            }
        }

        private static void BuscarAutor(Libro[] libreria)
        {
            Console.WriteLine("Introduzca el autor o parte de su nombre.");
            string busqueda = Console.ReadLine();
            bool encontrado = false;
            for (int i = 0; i<libreria.Length; i++)
            {
                if (libreria[i] != null && libreria[i].Autor == busqueda)
                {
                    encontrado = true;
                    Console.WriteLine($"Tenemos el libro {libreria[i]} en la estantería {i}");
                }
                else
                {
                    if (libreria[i] != null && libreria[i].Autor.Contains(busqueda))
                    {
                        encontrado = true;
                        Console.WriteLine($"Tenemos un libro de un autor parecido: {libreria[i]} en la estantería {i}");
                    }
                }
                
            }
            if (!encontrado) Console.WriteLine($"No he encontrado ningún autor con '{busqueda}' en nuestra librería.");
        }

        private static void BuscarTitulo(Libro[] libreria)
        {
            Console.WriteLine("Introduzca el título o parte de él.");
            string busqueda = Console.ReadLine();
            bool encontrado = false;
            for (int i = 0; i < libreria.Length; i++)
            {
                if (libreria[i]!=null && libreria[i].Titulo == busqueda) //TODO buscar el
                {
                    encontrado = true;
                    Console.WriteLine($"Tenemos el libro {libreria[i]} en la estantería {i}");
                }
                else
                {
                    if (libreria[i] != null && libreria[i].Titulo.Contains(busqueda))
                    {
                        encontrado = true;
                        Console.WriteLine($"Tenemos un libro con un título parecido: {libreria[i]} en la estantería {i}");
                    }
                }

            }
            if (!encontrado) Console.WriteLine($"No he encontrado ningún libro con '{busqueda}' en el título en nuestra librería.");
        }
    }
}
