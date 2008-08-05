using System;
using System.Collections.Generic;
using System.Text;

namespace FunerariaClassLib
{
    namespace BusinessLayer
    {
        [Serializable]
        public class PlanPago
        {
            private string codigo;
            private List<Cuota> cuotas;
            private string cliente;

            #region Propiedades

            /// <summary>
            /// Devuelve o establece el codigo del plan de pago
            /// </summary>
            public string Codigo
            {
                get
                { return this.codigo; }
                set
                { this.codigo = (value.Length>5? value.Substring(0, 5): value); }
            }

            /// <summary>
            /// Devuelve el numero de cuotas que posee el plan de pago
            /// </summary>
            public long nCuotas
            {
                get
                { return (long)this.cuotas.Count; }
            }

            /// <summary>
            /// Devuelve o establece una cuota específica del arreglo
            /// </summary>
            /// <param name="cual">El subindice de la cuota</param>
            /// <returns></returns>
            public Cuota this[int cual]
            {
                get
                { return this.cuotas[cual]; }
                set
                { this.cuotas[cual] = value; }
            }

            /// <summary>
            /// Devuelve o establece el codigo del cliente del plan
            /// </summary>
            public string Cliente
            {
                get
                { return this.cliente; }
                set
                { this.cliente = (value.Length>5? value.Substring(0, 5): value); }
            }

            /// <summary>
            /// Devuelve verdadero si existen cuotas pendientes en el plan de pago
            /// </summary>
            public bool HayPendientes
            {
                get
                {
                    foreach (Cuota c in this.cuotas)
                        if (c.Cancelada == EstadoCuota.Pendiente)
                            return true;
                    return false;
                }
            }

            /// <summary>
            /// Devuelve verdadero si existen cuotas pendientes en el plan de pago y ademas estan atrasadas
            /// </summary>
            public bool HayAtrasadas
            {
                get
                {
                    foreach (Cuota c in this.cuotas)
                        if ((c.Cancelada == EstadoCuota.Pendiente) && (c.FechaLimite < DateTime.Today))
                            return true;
                    return false;
                }
            }

            /// <summary>
            /// Devuelve la primera cuota pendiente que existe en el plan de pago, si no hay cuotas pendientes, devuelve la primera cuota del plan
            /// </summary>
            public Cuota Pendiente
            {
                get
                {
                    foreach (Cuota c in this.cuotas)
                        if (c.Cancelada == EstadoCuota.Pendiente)
                            return c;
                    return this[0];
                }
            }

            #endregion

            #region Metodos

            /// <summary>
            /// Crea una instancia de la clase Plan de Pago
            /// </summary>
            /// <param name="cod">El codigo del plan de pago</param>
            /// <param name="ncuotas">El numero de cuotas del plan de pago</param>
            /// <param name="client">El codigo del cliente del plan</param>
            public PlanPago(string cod, long ncuotas, decimal total_pagar, string client)
            {
                this.Codigo = cod;
                this.cuotas = new List<Cuota>((int)ncuotas);
                this.Cliente = client;
                foreach (Cuota ct in this.cuotas)
                    ct.Cantidad = total_pagar / ncuotas;
            }

            /// <summary>
            /// Crea una instancia de la clase Plan de Pago
            /// </summary>
            /// <param name="cod">El codigo del plan</param>
            /// <param name="cuot">La lista de cuotas del plan</param>
            /// <param name="client">El codigo del cliente del plan</param>
            public PlanPago(string cod, List<Cuota> cuot, string client)
            {
                this.Codigo = cod;
                this.cuotas = cuot;
                this.Cliente = client;
            }

            /// <summary>
            /// Devuelve el total a pagar en este plan de pago
            /// </summary>
            /// <returns></returns>
            public decimal TotalPagar()
            {
                decimal total = 0;
                foreach (Cuota c in this.cuotas)
                    total += c.Cantidad;
                return total;
            }
            #endregion

        }
    }
}
