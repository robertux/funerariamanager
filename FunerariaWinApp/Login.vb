Imports FunerariaClassLib.BusinessLayer
Imports System.Configuration
Imports CrypterClassLib

Public Class Login

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim cod As String = CatalogoAdmin.ExisteAdmin(Me.TextBox1.Text, Me.TextBox2.Text)
        If (cod <> "") Then
            ConfigurationManager.AppSettings.Set("LoguedUser", Encriptador.Encriptar(cod, "#IrrJ#"))
            Principal.lbllogin.Text = "Administrador Logueado:  " + Me.TextBox1.Text
            Me.Dispose()

        Else
            Me.TextBox1.Text = ""
            Me.TextBox2.Text = ""
            Me.Label3.Visible = True
        End If
    End Sub
    Private Sub Tecla1(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextBox1.KeyDown
        Me.Label3.Visible = False
    End Sub
    Private Sub Tecla2(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextBox2.KeyDown
        Me.Label3.Visible = False
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        End
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class