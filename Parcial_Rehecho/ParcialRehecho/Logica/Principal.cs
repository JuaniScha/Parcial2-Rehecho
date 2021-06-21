using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{    
    public sealed class Principal
    {
        public List<Envio> Envios { get; set; }
        public List<Persona> Clientes { get; set; }
        public List<Repartidor> Repartidores { get; set; }

        public Persona ObtenerClientePorDNI(int dni)
        {
            return Clientes.Find(x => x.DNI == dni);
        }

        public Envio ObtenerEnvioPorID(string id)
        {
            return Envios.Find(x => x.NroEnvio == id);
        }

        private readonly static Principal _instance = new Principal();

        private Principal()
        {
            if (Envios == null)
                Envios = new List<Envio>();

            if (Clientes == null)
                Clientes = new List<Persona>();

            if (Repartidores == null)
                Repartidores = new List<Repartidor>();
        }

        public static Principal Instancia
        {
            get { return _instance; }
        }

        public Resultado CargarNuevoEnvio(Envio envio)
        {
            Persona destinatario = envio.Destinatario;
            if (destinatario == null)
                return new Resultado(false, "Destinatario no existente");
            if (destinatario.TelefonoContacto == 0)
                return new Resultado(false, "No existe teléfono de contacto");

            Envios.Add(envio);
            return new Resultado(envio.NroEnvio, true);
        }

        public Resultado ActualizarEnvio(string nroEnvio, int estadoNuevo)
        {
            Envio envio = ObtenerEnvioPorID(nroEnvio);
            if (envio == null)
                return new Resultado(false, "Envío no encontrado");

            if (estadoNuevo < 0 || estadoNuevo > 3)
                return new Resultado(false, "Nuevo estado inválido");

            if (envio.ActualizarEstado(estadoNuevo))
                return new Resultado(nroEnvio, true);

            return new Resultado(false, "Nuevo estado inválido");
        }

        public Resultado AsignarRepartidorEnvio(string nroEnvio)
        {
            Envio envio = ObtenerEnvioPorID(nroEnvio);
            if (envio == null)
                return new Resultado(false, "Envío no encontrado");

            double valor = 0;
            Repartidor repartidorCercano = null;

            foreach (Repartidor item in Repartidores)
            {
                if (item == Repartidores[0])
                {
                    repartidorCercano = item;
                    valor = envio.ObtenerDistanciaEntrePuntos(item);
                }
                else
                {
                    if (valor > envio.ObtenerDistanciaEntrePuntos(item))
                    {
                        repartidorCercano = item;
                        valor = envio.ObtenerDistanciaEntrePuntos(item);
                    }
                }
            }

            if (repartidorCercano == null)
                return new Resultado(false, "Fallo en asignación");

            envio.Repartidor = repartidorCercano;
            return new Resultado(nroEnvio, true);
        }

        public List<RepartidorLista> ObtenerListaEntreFechas(DateTime desde, DateTime hasta)
        {
            List<RepartidorLista> lista = new List<RepartidorLista>();

            foreach (Envio item in Envios)
            {
                Repartidor repartidor = item.Repartidor;
                if(item.Estado == Envio.Estados.Entregado)
                {
                    if (item.FechaEstimada >= desde || item.FechaEstimada <= hasta)
                    {
                        RepartidorLista repartidorLista = lista.Find(x => x.NombreApellido == repartidor.NombreApellido);
                        if (repartidorLista != null)
                        {
                            repartidorLista.EnviosRealizados++;
                            repartidorLista.TotalGanadoComisiones += repartidor.PorcentajeComision;
                        }
                        else
                        {
                            RepartidorLista nuevo = new RepartidorLista() { NombreApellido = repartidor.NombreApellido, EnviosRealizados = 1, TotalGanadoComisiones = repartidor.PorcentajeComision };
                            lista.Add(nuevo);
                        }
                    }
                }
            }

            return lista;
        }
    }
}
