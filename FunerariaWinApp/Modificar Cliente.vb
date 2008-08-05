Imports FunerariaClassLib.BusinessLayer
Imports FunerariaClassLib.DataLayer
Public Class Modificar_Cliente
    Private modcliente As Cliente
    Private Sub Modificar_Cliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.modcliente = Clientes.GridClientes1.SelectedClient
        Me.txtnombres.Text = Me.modcliente.Nombres
        Me.txtapellidos.Text = Me.modcliente.Apellidos
        Me.txtdireccion.Text = Me.modcliente.Direccion
        Me.txttelefono.Text = Me.modcliente.Telefono

    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtcuotas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtmensualidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txttotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.txtnombres.Text = "" Or Me.txttelefono.Text = "" Or Me.txtdireccion.Text = "" Or Me.txtapellidos.Text = "" Then
            MsgBox("Debe llenar todos los campos")
        Else
            Me.modcliente.Nombres = Me.txtnombres.Text
            Me.modcliente.Apellidos = Me.txtapellidos.Text
            Me.modcliente.Direccion = Me.txtdireccion.Text
            Me.modcliente.Telefono = Me.txttelefono.Text
            CatalogoClientes.EditCliente(modcliente)
            Clientes.GridClientes1.Clientes = CatalogoClientes.GetClientes
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class