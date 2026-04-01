using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Enums;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Domain;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("╔════════════════════════════════════════════════╗");
            Console.WriteLine("║               PRINCIPIOS SOLID                 ║");
            Console.WriteLine("║        Sistema CleanTeeth  - ENTREGAR          ║");
            Console.WriteLine("╚════════════════════════════════════════════════╝\n");
        

            /// ssssssss
            // 1. Crear oficina
            var address = Address.Create("Av. Principal", "Quito", "17001");

            var office = new DentalOffice("CleanTeeth Central", address);

            Console.WriteLine($"Dirección: {office.Address.Street}, {office.Address.City}, {office.Address.ZipCode}");
            Console.WriteLine($"Oficina creada: {office.Name} - ID: {office.Id}");

            // 2. Crear dentista
            var dentista1 = new Dentist("Dr. Gómez", "dr.gomez@clinica.com", "0991234567");
            Console.WriteLine($"Dentista: {dentista1.Name} - ID: {dentista1.Id}");
            Console.WriteLine($"Teléfono dentista: {dentista1.PhoneNumber.Value}");

            // 3. Crear pacientes
            var paciente1 = new Patient("Juan Pérez", "juan.perez@email.com", "0987654321");
            var paciente2 = new Patient("Ana Ríos", "ana.rios@email.com", "0971112233");

            Console.WriteLine($"\nPaciente 1: {paciente1.Name} - ID: {paciente1.Id}");
            Console.WriteLine($"Email: {paciente1.Email.Value}");
            Console.WriteLine($"Teléfono: {paciente1.PhoneNumber.Value}");

            Console.WriteLine($"\nPaciente 2: {paciente2.Name} - ID: {paciente2.Id}");
            Console.WriteLine($"Email: {paciente2.Email.Value}");
            Console.WriteLine($"Teléfono: {paciente2.PhoneNumber.Value}");

            // 4. Fecha futura
            var ahora = DateTime.UtcNow;

            // 5. Intervalos
            var intervalo1 = new TimeInterval(ahora.AddHours(1), ahora.AddHours(2));
            var intervalo2 = new TimeInterval(ahora.AddHours(3), ahora.AddHours(4));

            Console.WriteLine("\nIntervalos creados:");
            Console.WriteLine($"Cita 1: {intervalo1.Start} - {intervalo1.End} ({intervalo1.DurationInMinutes} min)");
            Console.WriteLine($"Cita 2: {intervalo2.Start} - {intervalo2.End} ({intervalo2.DurationInMinutes} min)");

            // 6. Crear citas
            var cita1 = new Appointment(paciente1.Id, dentista1.Id, office.Id, intervalo1);
            var cita2 = new Appointment(paciente2.Id, dentista1.Id, office.Id, intervalo2);

            Console.WriteLine("\nCitas creadas correctamente");

            // 7. Validar duración tratamiento
            Console.WriteLine("\nValidando duración de tratamiento...");
            cita1.ValidateTreatmentDuration(AppointmentType.Treatment);
            Console.WriteLine("Duración válida para tratamiento");

            // 8. Cambiar estados
            Console.WriteLine("\nCambiando estados...");
            cita1.Complete();
            Console.WriteLine("Cita 1 completada");

            cita2.Cancel();
            Console.WriteLine("Cita 2 cancelada");

            // 9. Resultados finales
            Console.WriteLine("\n=== RESULTADOS FINALES ===");
            Console.WriteLine($"Cita 1 → Estado: {cita1.Status}");
            Console.WriteLine($"Cita 2 → Estado: {cita2.Status}");

            Console.WriteLine("\nC O M P L E T O");

            // 10. PRUEBA DE ERROR CONTROLADO 
            Console.WriteLine("\n=== PRUEBA DE ERROR ===");
            try
            {
                var intervaloError = new TimeInterval(ahora.AddMinutes(-30), ahora.AddHours(1));
                var citaError = new Appointment(paciente1.Id, dentista1.Id, office.Id, intervaloError);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error capturado correctamente:");
                Console.WriteLine(ex.Message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nERROR GENERAL:");
            Console.WriteLine(ex.Message);
        }

        Console.ReadLine();
    }
}

