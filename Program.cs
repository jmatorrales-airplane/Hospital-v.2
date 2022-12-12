/***
 * 
 * @author Jordi Matorrales
 * 
 */

namespace jmatorrales.hospital
{
    class principal
    {
        public static void Main(string[] args)
        {
            Hospital hospital = new Hospital();

            try
            {
                bool b = true;

                while(b)
                {
                    Console.WriteLine("1. Registrar paciente \n2. Dar de alta a paciente " +
                        "\n3. Mostrar datos paciente \n4. Añadir diagnostico" +
                        "\n5. Añadir medicamento \n6. Añadir prueba" +
                        "\n7. Ver lista de camas \n0. Salir");

                    int opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1: // registrar
                            hospital.ingresarPaciente();
                            break;

                        case 2: // dar de alta
                            hospital.altaPaciente();
                            break;

                        case 3: // mostrar datos paciente
                            hospital.mostrarPaciente();
                            break;

                        case 4: // añadir diagnostico
                            hospital.anadirDiagnostico();
                            break;

                        case 5: // añadir medicamentos
                            hospital.anadirMedicamento();
                            break;

                        case 6: // añadir pruebas
                            hospital.anadirPrueba();
                            break; 
                        
                        case 7:// ver lista camas
                            hospital.verCamas();
                            break;

                        case 0: // salir
                            b = false;
                            break;
                        
                        default:
                            Console.WriteLine("Numero no valido");
                            break;
                    }
                    Console.WriteLine(" ");
                }
            }
            catch(Exception ex) { }
            
        }
    }
}