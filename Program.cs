
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using System; // Import the necessary namespace

namespace ConsoleApp1 // Replace with your actual namespace
{
    class Program
    {
        static void Main(string[] args) // Define the Main method as the entry point
        {
            Console.WriteLine("---------LEER-------------");
            // Assuming SiacContext and Directorio are defined elsewhere:
            using (var context = new SiacContext())
            {
                Console.WriteLine("Directorios:"); // Add a heading for clarity

                foreach (var directorio in context.Directorios.ToList())
                {
                    Console.WriteLine(directorio.Nombre);
                }
            }

            Console.WriteLine("---------CREAR-------------");
            using (var context1 = new SiacContext())
            {
                //Console.WriteLine("Directorios:"); // Add a heading for clarity
                var d = new Directorio();
                d.IdDirectorio = 17;
                d.Nombre = "Musica Metal";
                d.IdPadre = 6;

                context1.Directorios.Add(d);
                context1.SaveChanges();

                foreach (var directoriox in context1.Directorios.ToList())
                {
                    Console.WriteLine(directoriox.Nombre);
                }
            }

            Console.WriteLine("----------ACTUALIZAR-----------");
            using (var context2 = new SiacContext())
            {
                var a = context2.Directorios.Find(16);
                a.Nombre = "Musica sonidero";
                context2.Entry(a).State = EntityState.Modified;
                context2.SaveChanges();
                foreach (var directorioy in context2.Directorios.ToList())
                {
                    Console.WriteLine(directorioy.Nombre);
                }


            }

            Console.WriteLine("----------Eliminar-----------");
            using (var context3 = new SiacContext())
            {
                var e = context3.Directorios.Find(14);
                context3.Remove(e);
                context3.SaveChanges();

                foreach (var directorioe in context3.Directorios.ToList())
                {
                    Console.WriteLine(directorioe.Nombre);
                }


            }
        }
    }
}