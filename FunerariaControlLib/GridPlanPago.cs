using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using FunerariaClassLib.BusinessLayer;
using System.Drawing;

namespace FunerariaControlLib
{
    public partial class GridPlanPago : DataGridView
    {
        private DataGridViewCellStyle estiloPendiente;
        private DataGridViewCellStyle estiloCancelado;
        private DataGridViewCellStyle estiloMoroso;
        private DataGridViewCellStyle estiloselected;
        private PlanPago _plan;
                
        public PlanPago Plan
        {
            get { return this._plan; }
            set { this._plan = value; this.ShowPlan(); }
        }

        public Cuota SelectedCuota
        {
            get 
            {
                for (int i = 0; i < this.Plan.nCuotas; i++)
                    if (this.Plan[i].Mes == (ulong)this.CurrentRow.Cells[0].Value)
                        return this.Plan[i];
                return this.Plan[0];
            }
        }

            public void Formatear()
        {
            this.Columns.Clear();
            this.Columns.Add("Mes", "Mes");
            this.Columns.Add("Cantidad", "Cantidad");
            this.Columns.Add("Fecha Limite", "Fecha Limite");
            this.Columns.Add("Fecha de Pago", "Fecha de Pago");
            this.Columns.Add("Estado", "Estado");
            foreach (DataGridViewColumn col in this.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            this.Rows.Clear();
            this.estiloCancelado = new DataGridViewCellStyle();
            this.estiloCancelado.BackColor = Color.LightSteelBlue;
            this.estiloPendiente = new DataGridViewCellStyle();
            this.estiloPendiente.BackColor = Color.White;
            this.estiloMoroso = new DataGridViewCellStyle();
            this.estiloMoroso.ForeColor = Color.LightCoral;
            this.estiloselected = new DataGridViewCellStyle();
            this.estiloselected.Font = new Font("Arial" , 14.0f, FontStyle.Bold);
        }
        
        public GridPlanPago()
        {
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.ReadOnly = true;
            this.MultiSelect = false;
            this.AllowUserToOrderColumns = false;
            this._plan = new PlanPago("0", 0, 0 , "0");
            this.Formatear();            
        }

        public void ShowPlan()
        {
            this.Formatear();
            try
            {
                for (int i = 0; i < this.Plan.nCuotas; i++)
                {
                    this.RowCount++;
                    switch(this.Plan[i].Cancelada)
                    {
                        case EstadoCuota.Cancelada:
                            foreach (DataGridViewCell celda in this.Rows[this.Rows.Count - 1].Cells)
                                celda.Style = estiloCancelado;
                            break;
                        case EstadoCuota.Pendiente:
                            if (this.Plan[i].FechaLimite > DateTime.Now)
                                foreach (DataGridViewCell celda in this.Rows[this.Rows.Count - 1].Cells)
                                    celda.Style = estiloPendiente;
                            else
                                foreach (DataGridViewCell celda in this.Rows[this.Rows.Count - 1].Cells)
                                    celda.Style = estiloMoroso;
                            break;
                    }                    
                    this.Rows[this.Rows.Count-1].Cells[0].Value = this.Plan[i].Mes;
                    this.Rows[this.Rows.Count-1].Cells[1].Value = "$" + this.Plan[i].Cantidad;
                    this.Rows[this.Rows.Count - 1].Cells[2].Value = this.Plan[i].FechaLimite.ToLongDateString();
                    this.Rows[this.Rows.Count-1].Cells[3].Value = (DateTime.Equals(this.Plan[i].FechaPago, DateTime.MinValue) ? "" : this.Plan[i].FechaPago.ToLongDateString());
                    this.Rows[this.Rows.Count-1].Cells[4].Value = this.Plan[i].Cancelada;
                }
            }
            catch (Exception ex)
            {   //no hagas nada 
            }
        }
    }
}
