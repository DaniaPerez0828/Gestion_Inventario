using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Inventario
{
    public class Inventario
    {
        private List<Producto> productos = new List<Producto>();

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
            Console.WriteLine("Producto agregado correctamente");
        }

        public IEnumerable<Producto> FiltrarProductosPorPrecio(decimal precioMinimo)
        {
            return productos.Where(p => p.Precio > precioMinimo).OrderBy(p => p.Precio);
        }

        public void ActualizarPrecio(string nombre, decimal nuevoPrecio)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                producto.Precio = nuevoPrecio;
                Console.WriteLine("Precio actualizado correctamente.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public void EliminarProducto(string nombre)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                productos.Remove(producto);
                Console.WriteLine("Producto eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public void ContarYAgruparProductos()
        {
            var conteo = new
            {
                MenoresDe100 = productos.Count(p => p.Precio < 100),
                Entre100y500 = productos.Count(p => p.Precio >= 100 && p.Precio <= 500),
                MayoresDe500 = productos.Count(p => p.Precio > 500)
            };

            Console.WriteLine($"Menores de 100: {conteo.MenoresDe100}");
            Console.WriteLine($"Entre 100 y 500: {conteo.Entre100y500}");
            Console.WriteLine($"Mayores de 500: {conteo.MayoresDe500}");
        }

        public void GenerarReporte()
        {
            int totalProductos = productos.Count;
            decimal precioPromedio = productos.Any() ? productos.Average(p => p.Precio) : 0;
            var productoMasCaro = productos.OrderByDescending(p => p.Precio).FirstOrDefault();
            var productoMasBarato = productos.OrderBy(p => p.Precio).FirstOrDefault();

            Console.WriteLine($"Número total de productos: {totalProductos}");
            Console.WriteLine($"Precio promedio: {precioPromedio:C}");
            Console.WriteLine($"Producto más caro: {productoMasCaro?.Nombre} - {productoMasCaro?.Precio:C}");
            Console.WriteLine($"Producto más barato: {productoMasBarato?.Nombre} - {productoMasBarato?.Precio:C}");
        }

        public void MostrarProductos()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos en el inventario.");
                return;
            }

            foreach (var producto in productos)
            {
                producto.MostrarInformacion();
            }
        }
    }
}
