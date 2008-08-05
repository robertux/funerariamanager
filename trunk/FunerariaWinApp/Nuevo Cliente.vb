Imports FunerariaClassLib.BusinessLayer
Imports FunerariaClassLib.DataLayer

Public Class Nuevo_Cliente
    Private ncliente As Cliente

    Private Sub cargar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtapellidos.Text = ""
        Me.txtcuotas.Text = ""
        Me.txtdireccion.Text = ""
        Me.txttelefono.Text = ""
        Me.txttotal.Text = ""
        Me.txtnombres.Text = ""
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtnombres.Text = "" Or txtapellidos.Text = "" Or txttelefono.Text = "" Or txtdireccion.Text = "" Or txtcuotas.Text = "" Or txttotal.Text = "" Or Me.txtcuotas.Text = "0" Or Me.txttotal.Text = "0" Then
            MsgBox("Debe llenar todos los campos")
        Else
            Dim datos As New AccesoDatos()
            Dim mostrar As String
            Dim mensualidad As Decimal = txttotal.Text / txtcuotas.Text
            Dim ahora As DateTime = DateTime.Today.AddMonths(1)
            mostrar = datos.GenerarCodigoCliente(txtapellidos.Text, txtnombres.Text)
            Dim cuotas As New List(Of Cuota)
            For i As Integer = 1 To Int32.Parse(txtcuotas.Text)
                cuotas.Add(New Cuota("", i, mensualidad, ahora, DateTime.MinValue, EstadoCuota.Pendiente))
                ahora = ahora.AddMonths(1)
            Next
            Dim plan As New PlanPago("", cuotas, mostrar)
            Me.ncliente = New Cliente(mostrar, txtapellidos.Text, txtnombres.Text, txtdireccion.Text, txttelefono.Text, 1, plan, Me.cmbServicios1.SelectedServ)
            CatalogoClientes.AddCliente(ncliente)
            MsgBox("Su Código y su mensualidad serán: " + mostrar + "   " + "$" + Math.Round(mensualidad, 2).ToString)
            Me.Close()
        End If
    End Sub
    Private Sub form_closed(ByVal sender As System.Object, ByVal c As FormClosedEventArgs) Handles Me.FormClosed
        Clientes.GridClientes1.Clientes = CatalogoClientes.GetClientes()
        Clientes.lbltclientes.Text = "Total de Clientes:  " + Clientes.GridClientes1.Clientes.Count.ToString
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class