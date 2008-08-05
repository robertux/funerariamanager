Imports FunerariaClassLib.BusinessLayer
Imports MySql.Data.MySqlClient

Public Class Agregar_Gastos_Variables
    Private gv As Gasto

    Private Sub btnagregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnagregar.Click
        If txtconcepto.Text = "" Or txtdinero.Text = "" Or Me.txtdinero.Text = "0" Then
            MsgBox("Debe llenar todos los campos")
        Else
            Try
                Dim ahora As Date = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))
                Me.gv = New Gasto("", "variable", txtconcepto.Text, txtdinero.Text, ahora, False)
                CatalogoGastos.AddGasto(gv)
                Me.Close()
            Catch ex As MySqlException
                MessageBox.Show(String.Format("Error en el acceso a la base de datos: {0}", ex.Message))
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub

    Private Sub Agregar_Gastos_Variables_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            Gastos_Variables.GridGastos1.Gastos = CatalogoGastos.GetGastos("Variable")
        Catch ex As MySqlException
            MessageBox.Show(String.Format("Error en el acceso a la base de datos: {0}", ex.Message))
        End Try
    End Sub

    Private Sub Agregar_Gastos_Variables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtconcepto.Text = ""
        Me.txtdinero.Text = ""
    End Sub
End Class