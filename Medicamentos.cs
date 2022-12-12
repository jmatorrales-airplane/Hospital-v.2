
class Medicamentos
{

    private string nombre { get; set; }
    private string indicaciones { get; set; }
    private List<string> efectos_secundarios { get; set; }
    private int dosis { get; set; }
    private List<string> efectos_adversos { get; set; }
    private double precio { get; set; }

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

    public void mostrarMedicamento()
    {

    }

}
