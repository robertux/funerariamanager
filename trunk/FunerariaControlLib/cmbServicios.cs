using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using FunerariaClassLib.BusinessLayer;
using MySql.Data.MySqlClient;


namespace FunerariaControlLib
{
    public partial class cmbServicios : ComboBox
    {
        private List<Servicio> _servicios;
    
        public List<Servicio> Servicios
        {
            get { return this._servicios; }
            set { this._servicios = value; }
        }

        public void UpdateList()
        {
            this._servicios = CatalogoServicios.GetServicios();
            this.Items.Clear();
            foreach (Servicio srv in this._servicios)
                this.Items.Add(srv.Nombre);
            this.Text = this.Servicios[0].Nombre;
        }

        public string SelectedSrvCode
        {
            get { return this.Servicios[this.SelectedIndex].Codigo; }
        }

        public Servicio SelectedServ
        {
            get { return this.Servicios[this.SelectedIndex]; }
        }

        public cmbServicios()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.UpdateList();   
        }
    }
}
