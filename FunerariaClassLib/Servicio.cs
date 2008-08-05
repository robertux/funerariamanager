using System;
using System.Collections.Generic;
using System.Text;

namespace FunerariaClassLib
{
    namespace BusinessLayer
    {
        [Serializable]
        public class Servicio
        {
            private string codigo;
            private string nombre;
            private string descripcion;

            #region Propiedades

            /// <summary>
            /// Devuelve o establece el codigo del servicio
            /// </summary>
            public string Codigo
            {
                get
                { return this.codigo; }
                set
                { this.codigo = (value.Length>5?value.Substring(0, 5):value); }
            }

            /// <summary>
            /// Devuelve o establece el nombre del servicio
            /// </summary>
            public string Nombre
            {
                get
                { return this.nombre; }
                set
                { this.nombre = (value.Length>20? value.Substring(0, 20): value); }
            }

            /// <summary>
            /// Devuelve o establece la descripcion del servicio
            /// </summary>
            public string Descripcion
            {
                get
                { return this.descripcion; }
                set
                { this.descripcion = value; }
            }

            #endregion

            #region Metodos

            /// <summary>
            /// Crea una instancia de la clase Servicio
            /// </summary>
            /// <param name="cod">El codigo del servicio</param>
            /// <param name="nom">El nombre del servicio</param>
            /// <param name="desc">La descripcion del servicio</param>
            public Servicio(string cod, string nom, string desc)
            {
                this.Codigo = cod;
                this.Nombre = nom;
                this.Descripcion = desc;
            }

            #endregion
        }
    }
}