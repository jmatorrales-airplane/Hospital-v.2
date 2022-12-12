
namespace jmatorrales.hospital
{
    class Hospital
    {
        private Dictionary<string, Paciente> listaHospital = new Dictionary<string, Paciente>();
        private List<string> camas = new List<string>();
        private Paciente paciente;

        private List<string> listaMedicamentos = new List<string>()
            { "aspirina", "rinotizol", "cascahueton", "filecodeina", "surnorteina" };

        private List<string> listaPruebas = new List<string>()
        { "rayosX", "TAC", "medida azucar", "prueba de esfuerzo", "escanner" };

        public void ingresarPaciente()
        {
            paciente = new Paciente();
            try
            {
                mostrar("Numero de cama a asignar:");
                string idCama = Console.ReadLine();
                mostrar("\nNombre del paciente:");
                string nombre = Console.ReadLine();
                Console.WriteLine("\nDireccion del paciente:");
                string direccion = Console.ReadLine();
                Console.WriteLine("\nDNI del paciente:");
                string dni = Console.ReadLine();
                Console.WriteLine("\nDiagnostico:");
                string diagnostico = Console.ReadLine();
                Console.WriteLine("\nDias de ingreso:");
                int diasDeIngreso = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\nPronostico del paciente:  (G/M/L)");
                char pronostico = Console.ReadLine()[0];
                Console.WriteLine("\nMedicacion del paciente:");
                string medicacion = seleccionarMedicamento();
                Console.WriteLine("\nPruebas realizadas:");
                string pruebas = seleccionarPrueba();

                camas.Add(idCama);
                paciente.ingreso(nombre, direccion, dni, diagnostico, diasDeIngreso, pronostico, medicacion, pruebas);

                listaHospital.Add(idCama, paciente);
            }
            catch(IOException ioex) { }
        }

        public void altaPaciente() 
        {
            try
            {
                mostrar("Indica el numero de cama: ");
                String nCama = Console.ReadLine();
                paciente = listaHospital[nCama];
                paciente.altaPaciente();
                listaHospital.Remove(nCama);
                camas.Remove(nCama);
            }
            catch(IOException ioex) { }
            mostrar("Se a eliminado lla ficha del paciente \n ");
        }

        public void mostrarPaciente()
        {
            try
            {
                mostrar("Indica el numero de cama: ");
                String nCama = Console.ReadLine();
                if(nCama != null)
                {
                    Paciente paciente = listaHospital[nCama];
                    mostrar(" ");
                    mostrar($"Nombre: {paciente.nombre}");
                    mostrar($"Direccion: {paciente.direccion}");
                    mostrar($"DNI: {paciente.dni}");
                    mostrar("Diagnostico: ");

                    for (int i = 0; i < paciente.diagnostico.Count; i++)
                    {
                        mostrar($"- {paciente.diagnostico[i]}");
                    }

                    mostrar($"Dias de ingreso: {paciente.diasDeIngreso}");
                    mostrar($"Pronostico: {paciente.pronostico}");
                    mostrar("Medicamentos: ");

                    for (int i = 0; i < paciente.medicamentos.Count; i++)
                    {
                        mostrar($"- {paciente.medicamentos[i]}");
                    }

                    mostrar("Pruebas: ");

                    for (int i = 0; i < paciente.pruebas.Count; i++)
                    {
                        mostrar($"- {paciente.pruebas[i]}");
                    }
                }
                else
                {
                    mostrar("Numero de cama no valido");
                }
            }
            catch(ArgumentException ae){ mostrar(ae.Message); }
            catch(Exception ex) { mostrar(ex.Message); }            
        }

        public void anadirDiagnostico()
        {
            try
            {
                mostrar("Indica el numero de cama: ");
                String nCama = Console.ReadLine();
                if (nCama != null)
                {
                    paciente = listaHospital[nCama];
                    mostrar("Nuevo diagnostico: ");
                    string nuevoDiagnostico = Console.ReadLine();
                    paciente.diagnostico.Add(nuevoDiagnostico);
                }
                else
                {
                    mostrar("Numero de cama no valido");
                }
            }
            catch (ArgumentException ae) { mostrar(ae.Message); }
        }

        public void anadirMedicamento()
        {
            try
            {
                mostrar("Indica el numero de cama: ");
                String nCama = Console.ReadLine();
                if (nCama != null)
                {
                    paciente = listaHospital[nCama];
                    string nuevoMedicamento = seleccionarMedicamento();
                    paciente.medicamentos.Add(nuevoMedicamento);
                }
                else
                {
                    mostrar("Numero de cama no valido");
                }
            }
            catch (ArgumentException aex) { mostrar(aex.Message); }
        }

        public void anadirPrueba()
        {
            try
            {
                mostrar("Indica el numero de cama: ");
                String nCama = Console.ReadLine();
                if (nCama != null)
                {
                    paciente = listaHospital[nCama];
                    string nuevaPrueba = seleccionarPrueba();
                    paciente.pruebas.Add(nuevaPrueba);
                }
                else
                {
                    mostrar("Numero de cama no valido");
                }
            }
            catch (ArgumentException aex) { mostrar(aex.Message); }
        }

        public void verCamas()
        {
            if(camas.Count > 0)
            {
                foreach (string cama in camas)
                {
                    Console.WriteLine(cama);
                }
            }
            else
            {
                Console.WriteLine("No hay camas asignadas");
            }
        }

        private string seleccionarMedicamento()
        {
            int n = 1;
            mostrar("Indica el medicamento utilizado");
            foreach(string medicamento in listaMedicamentos)
            {
                Console.Write($"{n}. {medicamento} ");
                n++;
            }
            Console.WriteLine(" ");
            try
            {
                int opcion = Convert.ToInt32(Console.ReadLine());

                if(opcion > 0) return listaMedicamentos[opcion - 1];
                else
                {
                    mostrar("Opcion no valida, vuelva a intentarlo");
                    seleccionarMedicamento();
                }
            }catch(Exception ex) {}
            return null;
        }

        private string seleccionarPrueba()
        {
            int n = 1;
            mostrar("Indica la prueba realizada");
            foreach (string prueba in listaPruebas)
            {
                Console.Write($"{n}. {prueba} ");
                n++;
            }
            Console.WriteLine(" ");
            try
            {
                int opcion = Convert.ToInt32(Console.ReadLine());

                if (opcion > 0) return listaPruebas[opcion - 1];
                else
                {
                    mostrar("Opcion no valida, vuelva a intentarlo");
                    seleccionarPrueba();
                }
            }
            catch (Exception ex) { }
            return null;
        }

        private void mostrar(string txt)
        {
            Console.WriteLine(txt);
        }
    }
}
