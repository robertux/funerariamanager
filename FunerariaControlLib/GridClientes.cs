using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FunerariaClassLib.BusinessLayer;
using FunerariaClassLib.DataLayer;
using System.Drawing;

namespace FunerariaControlLib
{
    public class GridClientes: DataGridView
    {
        DataGridViewCellStyle estiloMoroso;
        DataGridViewCellStyle estiloAtiempo;
        DataGridViewCellStyle estiloPendiente;
        private List<Cliente> _clientes;

        public List<Cliente> Clientes
        {
            get { return this._clientes; }
            set { this._clientes = value; this.ShowClientes(); this.Sort(this.Columns[0], System.ComponentModel.ListSortDirection.Ascending); }
        }

        public Cliente SelectedClient
        {
            get 
            {
                foreach (Cliente cl in this.Clientes)
                    if (string.Equals(cl.Codigo, (this.SelectedRows.Count>0? (string)this.SelectedRows[0].Cells[0].Value:(string)this.CurrentRow.Cells[0].Value)))
                        return cl;
                return this.Clientes[0];
            }
        }

        public GridClientes()
        {
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.ReadOnly = true;
            this.MultiSelect = false;
            this._clientes = new List<Cliente>();
            this.Formatear();
        }

        protected void Formatear()
        {
            this.Columns.Clear();
            this.Columns.Add("Codigo", "Codigo");
            this.Columns.Add("Apellidos", "Apellidos");
            this.Columns.Add("Nombres", "Nombres");
            this.Columns.Add("Direccion", "Dirección");
            this.Columns.Add("Telefono", "Teléfono");
            this.Columns.Add("Estado", "Estado");
            this.Columns.Add("Servicio", "Servicio");
            foreach (DataGridViewColumn col in this.Columns)
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.Rows.Clear();
            this.estiloMoroso = new DataGridViewCellStyle();
            this.estiloMoroso.ForeColor = Color.LightCoral;
            this.estiloAtiempo = new DataGridViewCellStyle();
            this.estiloAtiempo.BackColor = Color.LightSteelBlue;
            this.estiloPendiente = new DataGridViewCellStyle();
            this.estiloPendiente.ForeColor = Color.Gray;
        }

        public void ShowClientes()
        {
            this.Formatear();
            for(int i=0; i<this._clientes.Count; i++)
            {
                this.RowCount++;
                switch (this.Clientes[i].GetEstado())
                {
                    case "Moroso":
                        foreach (DataGridViewCell celda in this.Rows[this.Rows.Count - 1].Cells)
                            celda.Style = this.estiloMoroso;
                        break;
                    case "A Tiempo":
                        foreach (DataGridViewCell celda in this.Rows[this.Rows.Count - 1].Cells)
                            celda.Style = this.estiloAtiempo;
                        break;
                    case "Inactivo":
                        foreach (DataGridViewCell celda in this.Rows[this.Rows.Count - 1].Cells)
                            celda.Style = this.estiloPendiente;
                        break;
                }
                this.Rows[this.Rows.Count-1].Cells[0].Value = this.Clientes[i].Codigo;
                this.Rows[this.Rows.Count - 1].Cells[1].Value = this.Clientes[i].Apellidos;
                this.Rows[this.Rows.Count - 1].Cells[2].Value = this.Clientes[i].Nombres;
                this.Rows[this.Rows.Count - 1].Cells[3].Value = this.Clientes[i].Direccion;
                this.Rows[this.Rows.Count - 1].Cells[4].Value = this.Clientes[i].Telefono;
                this.Rows[this.Rows.Count - 1].Cells[5].Value = this.Clientes[i].GetEstado();
                this.Rows[this.Rows.Count - 1].Cells[6].Value = this.Clientes[i].Serv.Nombre;
            }
        }

        public void SelectCliente(string codCliente, int startindex)
        {
            try
            {
                for (int i = startindex + 1; i < this.Rows.Count ; i++)
                {
                    if (((string)this.Rows[i].Cells[0].Value).Contains(codCliente))
                    {
                        this.SetSelectedRowCore(i, true);
                        this.CurrentCell = this.Rows[i].Cells[0];
                        return;
                    }
                }
            }
            catch (Exception ex)
            { /* no hagas nada */ }
        }
    }
}
