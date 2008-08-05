using System;
using System.Collections.Generic;
using System.Text;

namespace FunerariaClassLib
{
    namespace BusinessLayer
    {
        [Serializable]
        public class Admin
        {
            private string codigo;
            private string id;
            private string clave;

            #region Propiedades

            /// <summary>
            /// Devuelve o establece el codigo del administrador
            /// </summary>
            public string Codigo
            {
                get
                { return this.codigo; }
                set
                { this.codigo = value; }
            }

            /// <summary>
            /// Devuelve o establece el identificador del administrador
            /// </summary>
            public string Id
            {
                get
                { return this.id; }
                set
                { this.id = (value.Length>15? value.Substring(0, 15): value); }
            }

            /// <summary>
            /// Devuelve o establece la clave de acceso del administrador
            /// </summary>
            public string Clave
            {
                get
                { return this.clave; }
                set
                { this.clave = (value.Length>10? value.Substring(0, 10): value); }
            }

            #endregion

            #region Metodos

            /// <summary>
            /// Crea una instancia de la clase Administradores
            /// </summary>
            /// <param name="id">El identificador del administrador</param>
            /// <param name="clave">La clave de acceso del administrador</param>
            public Admin(string cod, string id, string clave)
            {
                this.Codigo = cod;
                this.Id = id;
                this.Clave = clave;
            }

            #endregion
        }
    }
}