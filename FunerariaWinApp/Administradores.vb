Imports FunerariaClassLib.BusinessLayer
Imports System.Configuration
Imports CrypterClassLib
Imports MySql.Data.MySqlClient

Public Class Administradores

    Private Sub Cargar(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try
            Me.GridAdmins1.Admins = CatalogoAdmin.GetAdmins()
        Catch ex As MySqlException
            MessageBox.Show(String.Format("Error en el acceso a la base de datos: {0}", ex.Message))
            Me.Close()
        End Try
    End Sub

    Private Sub btnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        Try
            Nuevoadministrador.ShowDialog(Me)
        Catch ex As MySqlException
            MessageBox.Show(String.Format("Error en el acceso a la base de datos: {0}", ex.Message))
            Me.Close()
        End Try
    End Sub

    Private Sub btncerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncerrar.Click
        Me.Close()
    End Sub

    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        If (MsgBox("Desea eliminar al administrador seleccionado", MsgBoxStyle.YesNo, "Confirmacón") = MsgBoxResult.Yes) Then
            Try
                CatalogoAdmin.DelAdmin(Me.GridAdmins1.SelectedAdmin)
                Me.GridAdmins1.Admins = CatalogoAdmin.GetAdmins
            Catch ex As MySqlException
                MessageBox.Show(String.Format("Error en el acceso a la base de datos: {0}", ex.Message))
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub GridChange(ByVal sender As Object, ByVal e As EventArgs) Handles GridAdmins1.SelectionChanged
        If (Me.GridAdmins1.SelectedAdmin.Codigo = Encriptador.Desencriptar(ConfigurationManager.AppSettings.Get("LoguedUser"), "#IrrJ#")) Then
            Me.btneliminar.Enabled = False
        Else
            Me.btneliminar.Enabled = True
        End If
    End Sub
End Class