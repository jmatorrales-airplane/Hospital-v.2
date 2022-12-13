
namespace jmatorrales.hospital
{
    class Hospital
    {
        private Dictionary<string, Paciente> _listaHospital = new Dictionary<string, Paciente>();
        private Dictionary<string, Medicamentos> _listaMedicamentos = new Dictionary<string, Medicamentos>();
        private Dictionary<string, Morgue> _listaDefuncion = new Dictionary<string, Morgue>();

        private List<string> idCuerpos = new List<string>();
        private List<string> camas = new List<string>();
        private Paciente paciente;
        private Medicamentos medicamentos;
        private Morgue morgue;

        private List<string> listaMedicamentos = new List<string>()
            { "aspirina", "rinotizol", "cascahueton", "filecodeina", "surnorteina" };

        private List<string> listaPruebas = new List<string>()
        { "rayosX", "TAC", "medida azucar", "prueba de esfuerzo", "escanner" };


        public void añadirMedicamentoHospital()
        {
            medicamentos = new Medicamentos();
            try
            {
                mostrar("Nombre del medicamento:");
                string nombre = leerString();
                mostrar("Indicaciones:");
                string indicaciones = leerString();
                mostrar("Efectos secundarios:");
                string efSecundarios = leerString();
                mostrar("Dosis:");
                int dosis = leerInt();
                mostrar("Efectos adversos:");
                string efAdversos = leerString();
                mostrar("Precio");
                double precio = leerDouble();

                medicamentos.nuevoMedicamento(nombre, indicaciones, efSecundarios, dosis, efAdversos, precio);
                _listaMedicamentos.Add(nombre, medicamentos);
            }
            catch (IOException ioex)
            {
                Console.WriteLine(ioex.Message);
            }
        }

        public void mostrarMedicamentoHospital()
        {
            try
            {
                mostrar("Indica el nombre del medicamento: ");
                string nombreMedicamento = leerString();
                if (nombreMedicamento != null)
                {
                    Medicamentos med = _listaMedicamentos[nombreMedicamento];
                    mostrar(" ");
                    mostrar($"Nombre:\n {med.nombre}");
                    mostrar($"Indicaciones:\n {med.indicaciones}");
                    mostrar($"Efectos secundarios:  ");
                    for (int i = 0; i < med.efectos_secundarios.Count; i++)
                    {
                        mostrar($"- {med.efectos_secundarios[i]}");
                    }
                    mostrar($"Dosis:\n {med.dosis} ml");
                    mostrar($"Efectos advwersos");
                    for (int i = 0; i < med.efectos_adversos.Count; i++)
                    {
                        mostrar($"- {med.efectos_adversos[i]}");
                    }
                    mostrar($"precio:\n {med.precio}");
                }
            }
            catch (ArgumentException ae) { mostrar(ae.Message); }
            catch (Exception ex) { mostrar(ex.Message); }
        }

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

                _listaHospital.Add(idCama, paciente);
            }
            catch(IOException ioex) 
            {
                Console.WriteLine(ioex.Message);
            }
        }

        public void altaPaciente() 
        {
            try
            {
                mostrar("Indica el numero de cama: ");
                String nCama = Console.ReadLine();
                paciente = _listaHospital[nCama];
                paciente.altaPaciente();
                _listaHospital.Remove(nCama);
                camas.Remove(nCama);
            }
            catch(IOException ioex) { }
            mostrar("Se a eliminado lla ficha del paciente \n ");
        }

        public void defuncionPaciente()
        {
            try
            {
                morgue = new Morgue();

                mostrar("Indica el numero de cama:");
                string nCama = leerString();
                paciente = _listaHospital[nCama];
                mostrar("fecha de defuncion: ");
                DateTime fechaDefuncion = leerDatetime();

                morgue.defuncion(paciente.nombre, paciente.direccion, paciente.dni, paciente.diagnostico,
                    paciente.diasDeIngreso, paciente.pronostico, paciente.medicamentos, paciente.pruebas, fechaDefuncion);

                mostrar("Indica el id de defuncion");
                string idDefuncion = leerString();
                idCuerpos.Add(idDefuncion);
                _listaDefuncion.Add(idDefuncion, morgue);

                paciente.altaPaciente();
                _listaHospital.Remove(nCama);
                camas.Remove(nCama);
                
            }
            catch (IOException ioex)
            {
                Console.WriteLine(ioex.Message);
            }
            
        }

        public void mostrarDefuncionPaciente()
        {
            try
            {
                mostrar("Indica id de defuncion");
                string idDef = leerString();
                if(idDef != null)
                {
                    Morgue morgue = _listaDefuncion[idDef];
                    mostrar(" ");
                    mostrar($"Nombre: {morgue.nombre}");
                    mostrar($"Direccion: {morgue.direccion}");
                    mostrar($"DNI: {morgue.dni}");
                    mostrar("Diagnostico: ");

                    for (int i = 0; i < morgue.diagnostico.Count; i++)
                    {
                        mostrar($"- {morgue.diagnostico[i]}");
                    }

                    mostrar($"Dias de ingreso: {morgue.diasDeIngreso}");
                    mostrar($"Pronostico: {morgue.pronostico}");
                    mostrar("Medicamentos: ");

                    for (int i = 0; i < morgue.medicamentos.Count; i++)
                    {
                        mostrar($"- {morgue.medicamentos[i]}");
                    }

                    mostrar("Pruebas: ");

                    for (int i = 0; i < morgue.pruebas.Count; i++)
                    {
                        mostrar($"- {morgue.pruebas[i]}");
                    }
                    mostrar($"Fecha de defuncion: {morgue.fechaDefuncion}");
                }
                else
                {
                    mostrar("Id no valido");
                }
            }
            catch (ArgumentException ae) { mostrar(ae.Message); }
            catch (Exception ex) { mostrar(ex.Message); }
        }

        public void mostrarPaciente()
        {
            try
            {
                mostrar("Indica el numero de cama: ");
                String nCama = leerString();
                if(nCama != null)
                {
                    Paciente paciente = _listaHospital[nCama];
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
                    paciente = _listaHospital[nCama];
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

        public void anadirMedicamentoPaciente()
        {
            try
            {
                mostrar("Indica el numero de cama: ");
                String nCama = Console.ReadLine();
                if (nCama != null)
                {
                    paciente = _listaHospital[nCama];
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
                    paciente = _listaHospital[nCama];
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
        
        private string leerString()
        {
            string x = Console.ReadLine();

            if(x != null)
            {
                return x;
            }
            else
            {
                mostrar("No puede estar vacio, vuelve a intentarlo:");
                leerString();
            }
            return "Null";            
        }
        
        private int leerInt()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
        
        private double leerDouble()
        {
            return Convert.ToDouble(Console.ReadLine());
        }
        
        private DateTime leerDatetime()
        {
            try
            {
                mostrar("- Indica el dia:");
                int dia = leerInt();
                mostrar("- Indica el mes:");
                int mes = leerInt();
                mostrar("- Indica el año:");
                int ano = leerInt();
                mostrar("- Indica la hora:");
                int hora = leerInt();
                mostrar("Indica los minutos");
                int minutos = leerInt();

                DateTime date = new DateTime(ano, mes, dia, hora, minutos, 0);

                return date;
            }
            catch(ArgumentOutOfRangeException aore) 
            { 
                mostrar("Fecha no valida, vueve a intentarlo.");
                mostrar(aore.Message);
                leerDatetime();
            }

            return default;
        }
    }
}
