Imports FunerariaClassLib.BusinessLayer
Imports FunerariaClassLib.DataLayer

Public Class Nuevoadministrador
    Private adm As Admin

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtadministrador.Text = "" Or txtcontrasenia.Text = "" Or txtccontrasenia.Text = "" Then
            MsgBox("Debe llenar todos los campos")
        Else
            If txtcontrasenia.Text <> txtccontrasenia.Text Then
                MsgBox("Contraseña inválida")
            Else
                Dim datos As New AccesoDatos()
                Me.adm = New Admin(datos.GenerarCodigoAdmin(), txtadministrador.Text, txtcontrasenia.Text)
                CatalogoAdmin.AddAdmin(adm)
                Me.Close()
            End If
        End If
    End Sub

    Private Sub Nuevoadministrador_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Administradores.GridAdmins1.Admins = CatalogoAdmin.GetAdmins()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Nuevoadministrador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class