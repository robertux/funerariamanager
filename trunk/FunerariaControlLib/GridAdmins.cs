using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FunerariaClassLib.BusinessLayer;

namespace FunerariaControlLib
{
    public class GridAdmins: DataGridView
    {
        private List<Admin> _admins;

        public List<Admin> Admins
        {
            get { return this._admins; }
            set { this._admins = value; this.ShowAdmins(); }
        }

        public Admin SelectedAdmin
        {
            get 
            { 
                foreach(Admin adm in this.Admins)
                    if(string.Equals(adm.Codigo,(string)this.CurrentRow.Cells[0].Value))
                        return adm;
                return this.Admins[0];
            }
        }

        protected void Formatear()
        {
            this.Columns.Clear();
            this.Columns.Add("Codigo", "Código");
            this.Columns.Add("Id", "Id");
            foreach (DataGridViewColumn col in this.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            this.Rows.Clear();
        }

        public GridAdmins()
        {
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.ReadOnly = true;
            this._admins = new List<Admin>();
            this.AllowUserToOrderColumns = false;
            
            this.Formatear();
        }

        public void ShowAdmins()
        {
            this.Formatear();
            for (int i = 0; i < this.Admins.Count; i++)
            {
                this.RowCount++;
                this.Rows[this.Rows.Count - 1].Cells[0].Value = this.Admins[i].Codigo;
                this.Rows[this.Rows.Count-1].Cells[1].Value = this.Admins[i].Id;
            }
        }

    }
}
