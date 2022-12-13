
class Morgue: Cuerpo
{
    public List<string> diagnostico = new List<string>();
    public int diasDeIngreso { get; set; }
    public char pronostico { get; set; }
    public List<string> medicamentos = new List<string>();
    public List<string> pruebas = new List<string>();
    public DateTime fechaDefuncion { get; set; }

    public void defuncion(string nombre, string direccion, string dni, List<string> diagnostico,
        int diasDeIngreso, char pronostico, List<string> medicamentos, List<string> pruebas, DateTime fechaDefuncion)
    {
        this.nombre = nombre;
        this.direccion = direccion;
        this.dni = dni;

        for(int i = 0; i < diagnostico.Count; i++)
        {
            this.diagnostico.Add(diagnostico[i]);
        }
        
        this.diasDeIngreso = diasDeIngreso;
        this.pronostico = pronostico;

        for(int i=0; i < medicamentos.Count; i++)
        {
            this.medicamentos.Add(medicamentos[i]);
        }
        for (int i = 0; i < pruebas.Count; i++)
        {
            this.pruebas.Add(pruebas[i]);
        }

        this.fechaDefuncion = fechaDefuncion;
    }
}
