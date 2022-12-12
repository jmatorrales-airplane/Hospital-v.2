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
                        "\n5. Añadir medicamento al paciente \n6. Añadir prueba al paciente" +
                        "\n7. Añadir medicamento al hospital \n8. Mostrar medicamento del hopital " +
                        "\n9. Defuncion paciente \n10. Ver paciente defuncion" +
                        "\n11. Ver lista de camas \n0. Salir");

                    int opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1: // registrar paciente
                            hospital.ingresarPaciente();
                            break;

                        case 2: // dar de alta al paciente
                            hospital.altaPaciente();
                            break;

                        case 3: // mostrar datos paciente
                            hospital.mostrarPaciente();
                            break;

                        case 4: // añadir diagnostico al paciente
                            hospital.anadirDiagnostico();
                            break;

                        case 5: // añadir medicamentos al paciente
                            hospital.anadirMedicamentoPaciente();
                            break;

                        case 6: // añadir pruebas al paciente
                            hospital.anadirPrueba();
                            break;

                        case 7: // añadir medicamento hospital
                            hospital.añadirMedicamentoHospital();
                            break;

                        case 8: // mostrar medicamento hospital
                            hospital.mostrarMedicamentoHospital();
                            break;

                        case 9: // defuncion paciente
                            hospital.defuncionPaciente();
                            break;

                        case 10: // mostrar defuncion paciente
                            hospital.mostrarDefuncionPaciente();
                            break;
                        
                        case 11:// ver lista camas
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