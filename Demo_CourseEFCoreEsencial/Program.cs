// See https://aka.ms/new-console-template for more information

using Demo_CourseEFCoreEsencial.DbContexts;
using Demo_CourseEFCoreEsencial.Models;
using Microsoft.EntityFrameworkCore;

var db = new MoviesDbContext();
ShowMenu(db);
Console.ReadLine();

static void ShowMenu(MoviesDbContext db)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine();
    Console.WriteLine("Seleccione la opción deseada");

    Console.WriteLine("1.- Consultar las películas");

    Console.WriteLine("2.- Crear película");
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Gray;

    var option = Console.ReadLine();

    if (option =="1")
    {
        Show(db);
    }
    else
    {
        Create(db);
    }

}

static void Show(MoviesDbContext db)
{
    var all = db.Movies.ToListAsync().Result;
    if (all!=null)
    {
        foreach (var movie in all)
        {
            Console.WriteLine(movie.Name);
        }
    }

    ShowMenu(db);
}

static void Create(MoviesDbContext db)
{
    Console.WriteLine("Escriba el nombre de la película:");
    var name = Console.ReadLine();
    Console.WriteLine("Escriba el año de estreno:");
    var year = Console.ReadLine();

    var newMovie = new Movie();
    newMovie.Name = name;
    newMovie.Year = int.Parse(year);


    db.Movies.Add(newMovie);//Aca empieza a trackear los cambios, en este caso he agregado algo

    var result = db.SaveChanges();//Aca recien aplico los cambios trackeados

    Console.WriteLine(result);

    ShowMenu(db);
}