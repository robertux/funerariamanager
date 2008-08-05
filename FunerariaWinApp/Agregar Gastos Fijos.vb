Imports FunerariaClassLib.BusinessLayer
Imports MySql.Data.MySqlClient

Public Class Agregar_Gastos_Fijos
    Private gf As Gasto
   

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnagregar.Click
        If txtconcepto.Text = "" Or txtdinero.Text = "" Or txtmeses.Text = "" Or Me.txtmeses.Text = "0" Or Me.txtdinero.Text = "0" Then
            MsgBox("Debe llenar todos los campos")
        Else
            Try
                Dim nmeses As Integer = Int32.Parse(Me.txtmeses.Text)
                Dim ahora As Date = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))
                For i As Integer = 0 To nmeses - 1
                    Me.gf = New Gasto("", "fijo", txtconcepto.Text, Decimal.Parse(txtdinero.Text), ahora, False)
                    CatalogoGastos.AddGasto(gf)
                    ahora = ahora.AddMonths(1)
                Next
                Me.Close()
            Catch ex As MySqlException
                MessageBox.Show(String.Format("Error en el acceso a la base de datos: {0}", ex.Message))
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Agregar_Gastos_Fijos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtconcepto.Text = ""
        Me.txtdinero.Text = ""
        Me.txtmeses.Text = ""
    End Sub
End Class