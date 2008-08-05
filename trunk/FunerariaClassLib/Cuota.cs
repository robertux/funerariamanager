using System;
using System.Collections.Generic;
using System.Text;

namespace FunerariaClassLib
{
    namespace BusinessLayer
    {
        public enum EstadoCuota
        { Pendiente=0, Cancelada=1 }

        [Serializable]
        public class Cuota
        {
            private string codigo;
            private ulong mes;
            private decimal cantidad;
            private DateTime fechalimite;
            private DateTime fechapago;
            EstadoCuota cancelada;

            #region Propiedades

            /// <summary>
            /// Devuelve o establece el codigo de la cuota
            /// </summary>
            public string Codigo
            {
                get { return this.codigo; }
                set { this.codigo = (value.Length>5? value.Substring(0,5): value); }
            }

            /// <summary>
            /// Devuelve o establece el mes al que corresponde esta cuota
            /// </summary>
            public ulong Mes
            {
                get
                { return this.mes; }
                set
                { this.mes = value; }
            }

            /// <summary>
            /// Devuelve o establece el monto a pagar en esta cuota
            /// </summary>
            public decimal Cantidad
            {
                get
                { return this.cantidad; }
                set
                { this.cantidad = Math.Round(Math.Abs(value),2); }
            }

            /// <summary>
            /// Devuelve o establece la fecha limite de pago de esta cuota
            /// </summary>
            public DateTime FechaLimite
            {
                get
                { return this.fechalimite; }
                set
                { this.fechalimite = value; }
            }

            /// <summary>
            /// Devuelve o establece la fecha en que se pagó(si es que esta saldada) o la fecha en que se va a pagar la cuota
            /// </summary>
            public DateTime FechaPago
            {
                get
                { return this.fechapago; }
                set
                { this.fechapago = value; }
            }

            /// <summary>
            /// Devuelve o establece el estado de la cuota
            /// </summary>
            public EstadoCuota Cancelada
            {
                get
                { return this.cancelada; }
                set
                { this.cancelada = value; }
            }

            #endregion

            #region Metodos

            /// <summary>
            /// Crea una instancia de la clase cuota
            /// </summary>
            /// <param name="cod">El codigo de la cuota</param>
            /// <param name="ms">El mes al que representa la cuota</param>
            /// <param name="cant">La cantidad o monto a pagar en la cuota</param>
            /// <param name="fechalim">La fecha limite de pago de la cuota</param>
            /// <param name="fechap">La fecha en que ha sido pagada o se pagara la cuota</param>
            /// <param name="can">Valor entero que representa el estado de la cuota</param>
            public Cuota(string cod, uint ms, decimal cant, DateTime fechalim, DateTime fechap, EstadoCuota can)
            {
                this.Codigo = cod;
                this.Mes = ms;
                this.Cantidad = cant;
                this.FechaLimite = fechalim;
                this.FechaPago = fechap;
                this.Cancelada = can;
            }

            #endregion
        }
    }
}
