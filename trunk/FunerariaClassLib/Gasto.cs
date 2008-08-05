using System;
using System.Collections.Generic;
using System.Text;

namespace FunerariaClassLib
{
    namespace BusinessLayer
    {
        [Serializable]
        public class Gasto
        {
            private string codigo;
            private string tipo;
            private string concepto;
            private decimal monto;
            private DateTime fecha;
            private Boolean saldado;

            #region Propiedades

            /// <summary>
            /// Devuelve o establece el codigo del gasto
            /// </summary>
            public string Codigo
            {
                get
                { return this.codigo; }
                set
                { this.codigo = (value.Length>5? value.Substring(0, 5): value); }
            }

            /// <summary>
            /// Devuelve o establece el tipo de gasto registrado
            /// </summary>
            public string Tipo
            {
                get
                { return this.tipo; }
                set
                { this.tipo = (value.Length>8? value.Substring(0, 8): value); }
            }

            /// <summary>
            /// Devuelve o establece una descripción acerca del gasto realizado
            /// </summary>
            public string Concepto
            {
                get
                { return this.concepto; }
                set
                { this.concepto = value; }
            }

            /// <summary>
            /// Devuelve o establece el monto del gasto
            /// </summary>
            public decimal Monto
            {
                get
                { return this.monto; }
                set
                { this.monto = Math.Round(Math.Abs(value), 2); }
            }

            /// <summary>
            /// Devuelve o establece la fecha en que fue realizado (se realizara) el gasto
            /// </summary>
            public DateTime Fecha
            {
                get
                { return this.fecha; }
                set
                { this.fecha = value; }
            }

            /// <summary>
            /// Devuelve o establece el estado del gasto (si ya se ha saldado o no)
            /// </summary>
            public Boolean Saldado
            {
                get
                { return this.saldado; }
                set
                { this.saldado = value; }
            }

            #endregion

            #region Metodos

            /// <summary>
            /// Crea una instancia de la clase gastos
            /// </summary>
            /// <param name="cod">El codigo del gasto</param>
            /// <param name="tipo">El tipo del gasto</param>
            /// <param name="concepto">El concepto o descripcion del gasto</param>
            /// <param name="monto">El monto pagado o a pagar en el gasto</param>
            /// <param name="fecha">La fecha en que se pago o se pagara el gasto</param>
            /// <param name="saldado">El estado del gasto</param>
            public Gasto(string cod, string tipo, string concepto, decimal monto, DateTime fecha, Boolean saldado)
            {
                this.Codigo = cod;
                this.Tipo = tipo;
                this.Concepto = concepto;
                this.Monto = monto;
                this.Fecha = fecha;
                this.Saldado = saldado;
            }

            #endregion
        }
    }
}