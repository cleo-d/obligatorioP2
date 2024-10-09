﻿using Clases;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sistema s = Sistema.Instancia();
            // Desplegar un menú en consola que permita:
            //      • Listado de todos los clientes.
            //      • Dado un nombre de categoría listar todos los artículos de esa categoría.
            //      • Alta de artículo.
            //      • Dadas dos fechas, listar las publicaciones entre esas fechas. Mostrar Id, nombre estado y fecha de
            //        publicación

            mostrarMenu();




            string opcion = "";

            while (opcion != "0")
            {
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        //Mostrar Lista de clientes
                        try
                        {
                            List<Cliente> clientesAux = s.getClientes();

                            foreach (Cliente c in clientesAux)
                            {
                                Console.WriteLine($"-----------------------------------");
                                Console.WriteLine($"|Nombre Completo: {c.Nombre} {c.Apellido}");
                                Console.WriteLine($"|Email: {c.Email}");
                                Console.WriteLine($"|Saldo: {c.Saldo}");
                                Console.WriteLine($"-----------------------------------");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Error: {e.Message}");
                        }

                        mostrarMenu();
                        break;
                    case "2":
                        Console.WriteLine("Indique una categoria");
                        string inputCategoria = Console.ReadLine();

                        //Listar productos segun categoria
                        try
                        {
                            validarVacio( inputCategoria );
                            List<Articulo> articulosPorCategoria = s.GetArticulosPorCategoria(inputCategoria);
                            if (articulosPorCategoria.Count > 0)
                            {
                                foreach (Articulo a in articulosPorCategoria)
                                {
                                    Console.WriteLine($"-------------------------");
                                    Console.WriteLine($"|Nombre: {a.Nombre}");
                                    Console.WriteLine($"|Categoria: {a.Categoria}");
                                    Console.WriteLine($"|Precio: {a.Precio}");
                                    Console.WriteLine($"-------------------------");
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Error: {e.Message}");
                        }
                        mostrarMenu();
                        break;

                    case "3":
                        //Crear Articulo nuevo
                        Console.WriteLine("Ingrese un nombre para el Articulo");
                        string inputNomArt = Console.ReadLine();
                        Console.WriteLine("Ingrese una Categoria para el Articulo");
                        string inputCatArt = Console.ReadLine();
                        Console.WriteLine("Ingrese un Precio para el Articulo");
                        double inputPrecioArt = double.Parse(Console.ReadLine());

                        try
                        {
                            validarVacio(inputNomArt);
                            validarVacio(inputCatArt);
                            //En la clase articulo se valida las reglas de negocio para la cracion de Articulos
                            s.altaArticulo(inputNomArt, inputCatArt, inputPrecioArt);
                            Console.WriteLine($"Articulo ingresado correctamente! \n" +
                                              $"Nombre: {inputNomArt}, Categoria: {inputCatArt}, Precio: {inputPrecioArt}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        mostrarMenu();
                        break;

                    case "4":
                        //Listar publicaciones segun rango de fechas
                        Console.WriteLine("Ingrese una fecha de inicio con formato AAAA-MM-DD");
                        DateTime inputFecha1 = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese una fecha de finalizacion con formato AAAA-MM-DD");
                        DateTime inputFecha2 = DateTime.Parse(Console.ReadLine()); ;

                    Console.WriteLine(inputFecha1.ToString(),  inputFecha2.ToString());

                        try
                        {
                            List<Publicacion> publicacionesAux = s.PublicacionesEntreFechas(inputFecha1, inputFecha2);
                            foreach (Publicacion p in publicacionesAux)
                            {
                                Console.WriteLine($"Id: {p.Id} Nombre: {p.Nombre} Estado: {p.Estado}");
                            }
                        }
                        catch (Exception e)
                        {
                           Console.WriteLine(e.Message);
                        }
                        mostrarMenu();
                        break;

                case "0":
                    Console.WriteLine("Saliendo del sistema");
                    break;

                    default:
                        Console.WriteLine("Por favor ingrese una opcion del menu");
                        break;
                }


            }
            Console.ReadKey();
            //End

        }

        private static void validarPrecio(double inputPrecioArt)
        {
            throw new NotImplementedException();
        }

        private static void validarVacio(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                throw new Exception("El dato no puede ser vacio");
            }
        }

        private static void mostrarMenu()
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("*********************************************");
                Console.WriteLine("-------Seleccione otra opcion del menu-------");
                Console.WriteLine("1-Mostrar listado de clientes");
                Console.WriteLine("2-Listar productos segun categoria");
                Console.WriteLine("3-Dar de alta a un articulo");
                Console.WriteLine("4-Listar publicaciones segun rango de fechas");
                Console.WriteLine();
                Console.WriteLine("0-Salir");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("*********************************************");
            }
    }
}
