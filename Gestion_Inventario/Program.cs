using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Inventario
{
    public class Program
    {
        static void Main(string[] args)
        {
            Inventario inventario = new Inventario();
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("=== Gestión de Inventario ===");
                Console.WriteLine("1. Agregar Producto");
                Console.WriteLine("2. Filtrar Productos por Precio");
                Console.WriteLine("3. Actualizar Precio de Producto");
                Console.WriteLine("4. Eliminar Producto");
                Console.WriteLine("5. Contar y Agrupar Productos");
                Console.WriteLine("6. Generar Reporte");
                Console.WriteLine("7. Ver Productos");
                Console.WriteLine("8. Salir");
                Console.Write("Elige una opción: ");

                // Validar opción de menú
                while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 8)
                {
                    Console.WriteLine("Por favor, ingrese una opción válida (1-8):");
                }

                switch (opcion)
                {
                    case 1:
                        AgregarProducto(inventario);
                        break;
                    case 2:
                        FiltrarProductos(inventario);
                        break;
                    case 3:
                        ActualizarPrecio(inventario);
                        break;
                    case 4:
                        EliminarProducto(inventario);
                        break;
                    case 5:
                        inventario.ContarYAgruparProductos();
                        break;
                    case 6:
                        inventario.GenerarReporte();
                        break;
                    case 7:
                        inventario.MostrarProductos();
                        break;
                    case 8:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                }

                if (opcion != 8)
                {
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 8);
        }

        static void AgregarProducto(Inventario inventario)
        {
            Console.Write("Ingrese el nombre del producto: ");
            string nombre = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("El nombre del producto no puede estar vacío.");
                Console.Write("Ingrese el nombre del producto: ");
                nombre = Console.ReadLine();
            }

            Console.Write("Ingrese el precio del producto: ");
            decimal precio;
            while (!decimal.TryParse(Console.ReadLine(), out precio) || precio <= 0)
            {
                Console.WriteLine("Por favor, ingrese un precio válido (mayor que 0):");
            }

            inventario.AgregarProducto(new Producto(nombre, precio));
        }

        static void FiltrarProductos(Inventario inventario)
        {
            Console.Write("Ingrese el precio mínimo para filtrar: ");
            decimal precioMinimo;
            while (!decimal.TryParse(Console.ReadLine(), out precioMinimo) || precioMinimo < 0)
            {
                Console.WriteLine("Por favor, ingrese un precio válido (mayor o igual a 0):");
            }

            var productosFiltrados = inventario.FiltrarProductosPorPrecio(precioMinimo);
            Console.WriteLine("Productos filtrados:");
            foreach (var producto in productosFiltrados)
            {
                producto.MostrarInformacion();
            }
        }

        static void ActualizarPrecio(Inventario inventario)
        {
            Console.Write("Ingrese el nombre del producto a actualizar: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el nuevo precio: ");
            decimal nuevoPrecio;
            while (!decimal.TryParse(Console.ReadLine(), out nuevoPrecio) || nuevoPrecio <= 0)
            {
                Console.WriteLine("Por favor, ingrese un precio válido (mayor que 0):");
            }

            inventario.ActualizarPrecio(nombre, nuevoPrecio);
        }

        static void EliminarProducto(Inventario inventario)
        {
            Console.Write("Ingrese el nombre del producto a eliminar: ");
            string nombre = Console.ReadLine();
            inventario.EliminarProducto(nombre);
        }
    }
}
