using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.Types;

namespace FunerariaClassLib
{
    namespace BusinessLayer
    {
        [Serializable]
        public class Cliente
        {
            private string codigo;
            private string nombres;
            private string apellidos;
            private string direccion;
            private string telefono;
            private uint estado;
            private PlanPago plan;
            private Servicio serv;

            #region Propiedades

            /// <summary>
            /// Devuelve o establece el codigo del cliente
            /// </summary>
            public string Codigo
            {
                get
                { return this.codigo; }
                set
                { this.codigo = (value.Length>5? value.Substring(0, 5): value); }
            }

            /// <summary>
            /// Devuelve o establece los nombres del cliente
            /// </summary>
            public string Nombres
            {
                get
                { return this.nombres; }
                set
                { this.nombres = (value.Length>45 ?value.Substring(0, 45):value); }
            }

            /// <summary>
            /// Devuelve o establece los apellidos del cliente
            /// </summary>
            public string Apellidos
            {
                get
                { return this.apellidos; }
                set
                { this.apellidos = (value.Length>45? value.Substring(0,45): value); }
            }

            /// <summary>
            /// Devuelve o establece la direccion del cliente
            /// </summary>
            public string Direccion
            {
                get
                { return this.direccion; }
                set
                { this.direccion = value; }
            }

            /// <summary>
            /// Devuelve o establece el telefono del cliente
            /// </summary>
            public string Telefono
            {
                get
                { return this.telefono; }
                set
                { this.telefono = (value.Length>8? value.Substring(0,8): value); }
            }

            /// <summary>
            /// Devuelve o establece el estado del cliente(0: moroso, 1: a tiempo, 2: inactivo)
            /// </summary>
            public uint Estado
            {
                get
                { return this.estado; }
                set
                { this.estado = ((value >= 0 || value <= 2) ? value : 0); }
            }

            /// <summary>
            /// Devuelve o establece el plan de pago del cliente
            /// </summary>
            public PlanPago Plan
            {
                get
                { return this.plan; }
                set
                { this.plan = value; }
            }

            /// <summary>
            /// Devuelve o establece el tipo de servicio del cliente
            /// </summary>
            public Servicio Serv
            {
                get
                { return this.serv; }
                set
                { this.serv = value; }
            }


            #endregion

            #region Metodos

            /// <summary>
            /// Crea una instancia de la clase cliente
            /// </summary>
            /// <param name="cod">El codigo del cliente</param>
            /// <param name="apel">Los apellidos del cliente</param>
            /// <param name="nombr">Los nombres del cliente</param>
            /// <param name="direc">La direccion del cliente</param>
            /// <param name="tel">El telefono del cliente</param>
            /// <param name="est">El estado del cliente</param>
            /// <param name="pl">El codigo del plan de pago del cliente</param>
            /// <param name="serv">El servicio del cliente</param>
            public Cliente(string cod, string apel, string nombr, string direc, string tel, uint est, PlanPago pl, Servicio serv)
            {
                this.Codigo = cod;
                this.Apellidos = apel;
                this.Nombres = nombr;
                this.Direccion = direc;
                this.Telefono = tel;
                this.Estado = est;
                this.Plan = pl;
                this.Serv = serv;
            }

            public string GetEstado()
            {
                switch (this.Estado)
                {
                    case 0: return "Moroso";
                    case 1: return "A Tiempo"; 
                    case 2: return "Inactivo"; 
                    default: return "No especificado"; 
                }
            }

            public void SetEstado()
            {
                if (!this.Plan.HayPendientes)
                    this.Estado = (uint)2;
                else
                    if (this.Plan.HayAtrasadas)
                        this.Estado = (uint)0;
                    else
                        this.Estado = (uint)1;
            }

            #endregion
        }
    }
}
