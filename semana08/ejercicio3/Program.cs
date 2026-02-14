using System;

namespace AuditorioCongreso
{
    class Program
    {
        static int TOTAL_ASIENTOS = 100;
        static int asientosOcupados = 0;

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                MostrarMenu();
                opcion = LeerEntero("Seleccione una opción: ");

                Console.Clear(); // LIMPIA LA CONSOLA DESPUÉS DE ELEGIR

                switch (opcion)
                {
                    case 1:
                        RegistrarPersonas(1);
                        break;

                    case 2:
                        RegistrarPersonas(2);
                        break;

                    case 3:
                        MostrarAsientosDisponibles();
                        break;

                    case 4:
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                if (opcion != 4)
                {
                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (opcion != 4);
        }

        static void MostrarMenu()
        {
            Console.WriteLine("===== SISTEMA DE ASIGNACIÓN DE ASIENTOS =====");
            Console.WriteLine("1. Registrar asistentes por Atención 1");
            Console.WriteLine("2. Registrar asistentes por Atención 2");
            Console.WriteLine("3. Ver cantidad de asientos disponibles");
            Console.WriteLine("4. Salir");
            Console.WriteLine("============================================");
        }

        static void RegistrarPersonas(int atencion)
        {
            if (asientosOcupados >= TOTAL_ASIENTOS)
            {
                Console.WriteLine("No hay asientos disponibles.");
                return;
            }

            Console.WriteLine($"ATENCIÓN {atencion}");
            Console.WriteLine("1. Ingresar una persona");
            Console.WriteLine("2. Ingresar un grupo");

            int opcion = LeerEntero("Seleccione una opción: ");
            Console.Clear();

            int cantidad = 0;

            if (opcion == 1)
            {
                cantidad = 1;
            }
            else if (opcion == 2)
            {
                cantidad = LeerEntero("Ingrese cantidad de personas (máximo 50): ");

                if (cantidad <= 0 || cantidad > 50)
                {
                    Console.WriteLine("Cantidad inválida. Máximo permitido: 50.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Opción inválida.");
                return;
            }

            if (asientosOcupados + cantidad > TOTAL_ASIENTOS)
            {
                Console.WriteLine("No hay suficientes asientos disponibles.");
                return;
            }

            int asientoInicial = asientosOcupados + 1;
            asientosOcupados += cantidad;
            int asientoFinal = asientosOcupados;

            Console.WriteLine($"Registro exitoso por Atención {atencion}");
            Console.WriteLine($"Asientos asignados: {asientoInicial} al {asientoFinal}");
        }

        static void MostrarAsientosDisponibles()
        {
            Console.WriteLine($"Asientos disponibles: {TOTAL_ASIENTOS - asientosOcupados}");
            Console.WriteLine($"Asientos ocupados: {asientosOcupados}");
        }

        static int LeerEntero(string mensaje)
        {
            int valor;
            Console.Write(mensaje);

            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.Write("Entrada inválida. Intente nuevamente: ");
            }

            return valor;
        }
    }
}
