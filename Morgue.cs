
class Morgue: Cuerpo
{
    public List<string> diagnostico = new List<string>();
    public int diasDeIngreso { get; set; }
    public char pronostico { get; set; }
    public List<string> medicamentos = new List<string>();
    public List<string> pruebas = new List<string>();
    public string fechaDefuncion { get; set; }

    public void defuncion(string nombre, string direccion, string dni, List<string> diagnostico,
        int diasDeIngreso, char pronostico, List<string> medicacion, List<string> pruebas, string fechaDefuncion)
    {
        this.nombre = nombre;
        this.direccion = direccion;
        this.dni = dni;

        for(int i = 0; diagnostico.Count > 0; i++)
        {
            this.diagnostico.Add(diagnostico[i]);
        }

        
        this.diasDeIngreso = diasDeIngreso;
        this.pronostico = pronostico;

        for(int i=0; medicamentos.Count> 0; i++)
        {
            medicamentos.Add(medicacion[i]);
        }
        for (int i = 0; pruebas.Count > 0; i++)
        {
            medicamentos.Add(pruebas[i]);
        }

        this.fechaDefuncion = fechaDefuncion;
    }
}
