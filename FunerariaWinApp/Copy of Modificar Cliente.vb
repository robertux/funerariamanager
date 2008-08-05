Imports FunerariaClassLib.BusinessLayer
Imports FunerariaClassLib.DataLayer
Public Class Modificar_Cliente
    Private modcliente As Cliente
    Private Sub Modificar_Cliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.modcliente = Clientes.GridClientes1.SelectedClient
        Me.TextBox1.Text = Me.modcliente.Nombres

    End Sub
End Class