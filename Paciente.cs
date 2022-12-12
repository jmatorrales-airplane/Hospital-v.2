
namespace jmatorrales.hospital
{
    class Paciente : Persona
    {

        public List<string> diagnostico = new List<string>();
        public int diasDeIngreso { get; set; }
        public char pronostico { get; set; }
        public List<string> medicamentos = new List<string>();
        public List<string> pruebas = new List<string>();
        private bool esPaciente { get; set; }

        public void altaPaciente()
        {
            if(esPaciente)
            {
                nombre = null;
                direccion = null;
                dni = null;
                diagnostico.Clear();
                diasDeIngreso= 0;
                pronostico = '\0';
                medicamentos.Clear();
                pruebas.Clear();
                esPaciente= false;
            }
            else
            {
                Console.WriteLine("No hay registro del paciente en el hospital");
            }
        }

        public void ingreso(string nombre, string direccion, string dni, string diagnostico, int diasDeIngreso, char pronostico, string medicacion, string pruebas)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.dni = dni;
            this.diagnostico.Add(diagnostico);
            this.diasDeIngreso = diasDeIngreso;
            this.pronostico = pronostico;
            medicamentos.Add(medicacion);
            this.pruebas.Add(pruebas);
            esPaciente = true;
        }
    }
}
