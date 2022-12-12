
class Medicamentos
{

    public string nombre { get; set; }
    public string indicaciones { get; set; }
    public List<string> efectos_secundarios { get; set; }
    public int dosis { get; set; }
    public List<string> efectos_adversos { get; set; }
    public double precio { get; set; }

    public void nuevoMedicamento(string nombre, string indicaciones, string efSecundario,
        int dosis, string efAdversos, double precio)
    {
        this.nombre = nombre;
        this.indicaciones= indicaciones;
        efectos_secundarios.Add(efSecundario);
        this.dosis= dosis;
        efectos_adversos.Add(efAdversos);
        this.precio = precio;
    }
}
