namespace Logica
{
    public class Repartidor : Persona
    {
        public double PorcentajeComision { get; set; }
        //La comision es por envio, no por repartidor (depende del costo del envio)
        public double ComisionGanada { get; set; }
    }
}