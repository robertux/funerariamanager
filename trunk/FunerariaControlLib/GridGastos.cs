using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FunerariaClassLib.BusinessLayer;
using System.Drawing;

namespace FunerariaControlLib
{
    public class GridGastos : DataGridView
    {
        private List<Gasto> gastos;
        private int anio;
        private int mes;
        private DataGridViewCellStyle estiloSaldado;

        public List<Gasto> Gastos
        {
            get { return this.gastos; }
            set { this.gastos = value; this.ShowGastos(); }
        }

        public Gasto SelectedGasto
        {
            get 
            {
                foreach (Gasto gt in this.Gastos)
                    if (gt.Monto.ToString() == this.CurrentRow.Cells[1].Value.ToString().Trim('$') && gt.Fecha.ToLongDateString() == (string)this.CurrentRow.Cells[2].Value)
                        return gt;
                return this.Gastos[0];
            }
        }

        public int Anio
        {
            get { return this.anio; }
            set { this.anio = value; this.ShowGastos(); }
        }

        public int Mes
        {
            get { return this.mes; }
            set { this.mes = value; this.ShowGastos(); }
        }

        protected void Formatear()
        {
            this.Columns.Clear();
            this.Columns.Add("Concepto", "Concepto");
            this.Columns.Add("Monto", "Monto");
            this.Columns.Add("Fecha", "Fecha");
            this.Columns.Add("Estado", "Estado");
            foreach (DataGridViewColumn col in this.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            this.estiloSaldado.BackColor = Color.LightSteelBlue;
            this.Rows.Clear();
        }

        public GridGastos()
        {
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.ReadOnly = true;
            this.AllowUserToOrderColumns = false;
            this.gastos = new List<Gasto>();
            this.estiloSaldado = new DataGridViewCellStyle();
            this.Formatear();
        }

        public void ShowGastos()
        {
            this.Formatear();
            for (int i = 0; i < this.Gastos.Count; i++)
            {
                if (this.Gastos[i].Fecha.Year == this.Anio && this.Gastos[i].Fecha.Month == this.Mes)
                {
                    this.RowCount++;
                    if (this.Gastos[i].Saldado)
                        foreach (DataGridViewCell celda in this.Rows[this.Rows.Count - 1].Cells)
                            celda.Style = estiloSaldado;
                    this.Rows[this.Rows.Count-1].Cells[0].Value = this.Gastos[i].Concepto;
                    this.Rows[this.Rows.Count-1].Cells[1].Value = "$" + this.Gastos[i].Monto;
                    this.Rows[this.Rows.Count - 1].Cells[2].Value = this.Gastos[i].Fecha.ToLongDateString();
                    this.Rows[this.Rows.Count-1].Cells[3].Value = (this.Gastos[i].Saldado ? "Saldado" : "Pendiente");
                }
            }
        }

    }
}