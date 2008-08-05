Imports FunerariaClassLib.BusinessLayer

Public Class Gastos_Fijos

    Private Sub Cargar(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.GridGastos1.Gastos = CatalogoGastos.GetGastos("fijo")
        Me.RellenarAnios()
        Me.ComboBox2.SelectedIndex = DateTime.Today.Month - 1
        Me.ComboBox1.SelectedIndex = DateTime.Today.Year - 1970
    End Sub

    Private Sub RellenarAnios()
        Me.ComboBox1.Items.Clear()
        For i As Integer = 1970 To DateTime.Now.Year + 10
            Me.ComboBox1.Items.Add(i)
        Next
        Me.ComboBox1.SelectedItem = Me.ComboBox1.Items(Me.ComboBox1.Items.Count - 1)
    End Sub

    Public Sub SetFecha()
        Try
            Me.GridGastos1.Anio = CInt(Me.ComboBox1.Items(Me.ComboBox1.SelectedIndex))
            Me.GridGastos1.Mes = Me.ComboBox2.SelectedIndex + 1
        Catch ex As ArgumentOutOfRangeException
            'nada
        End Try
    End Sub

    Public Sub combo1(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        SetFecha()
    End Sub

    Public Sub combo2(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        SetFecha()
    End Sub

    Private Sub btnsaldar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsaldar.Click
        Dim ct As Gasto = Me.GridGastos1.SelectedGasto
        If ct.Saldado = False Then
            Dim res As MsgBoxResult = MsgBox("Desea saldar el gasto?", MsgBoxStyle.YesNo)
            If res = MsgBoxResult.Yes Then
                ct.Saldado = True
                CatalogoGastos.EditGasto(ct)
                Me.GridGastos1.Gastos = CatalogoGastos.GetGastos("fijo")
            End If
           
        End If
    End Sub
End Class