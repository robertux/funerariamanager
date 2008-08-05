Imports System.Configuration
Imports MySql.Data.MySqlClient

Public Class Principal
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.lblfecha.Text = DateTime.Today.ToLongDateString
            If (ConfigurationManager.AppSettings("estado") <> "login") Then
                Login.ShowDialog()
            End If
        Catch ex As MySqlException
            MessageBox.Show(String.Format("Error en el acceso a la base de datos: {0}", ex.Message))

        Catch ex As Exception
            MessageBox.Show(String.Format("Error en la aplicación: {0}", ex.Message))

        End Try
    End Sub

    Private Sub Form1_Unload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        ConfigurationManager.AppSettings.Set("estado", "logout")
    End Sub

    Private Sub ExaminarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExaminarToolStripMenuItem.Click
        Try
            Clientes.ShowDialog(Me)
        Catch ex As MySqlException
            MessageBox.Show(String.Format("Error en el acceso a la base de datos: {0}", ex.Message))

        Catch ex As Exception
            MessageBox.Show(String.Format("Error en la aplicación: {0}", ex.Message))

        End Try
    End Sub

    Private Sub ExaminarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExaminarToolStripMenuItem1.Click
        Try
            Administradores.ShowDialog(Me)
        Catch ex As MySqlException
            MessageBox.Show(String.Format("Error en el acceso a la base de datos: {0}", ex.Message))

        Catch ex As Exception
            MessageBox.Show(String.Format("Error en la aplicación: {0}", ex.Message))

        End Try
    End Sub

    Private Sub FijosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FijosToolStripMenuItem.Click
        Try
            Gastos_Fijos.ShowDialog(Me)
        Catch ex As MySqlException
            MessageBox.Show(String.Format("Error en el acceso a la base de datos: {0}", ex.Message))

        Catch ex As Exception
            MessageBox.Show(String.Format("Error en la aplicación: {0}", ex.Message))

        End Try
    End Sub

    Private Sub VariablesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VariablesToolStripMenuItem.Click
        Try
            Gastos_Variables.ShowDialog(Me)
        Catch ex As MySqlException
            MessageBox.Show(String.Format("Error en el acceso a la base de datos: {0}", ex.Message))

        Catch ex As Exception
            MessageBox.Show(String.Format("Error en la aplicación: {0}", ex.Message))

        End Try

    End Sub

    Private Sub menBloquear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menBloquear.Click
        Try
            ConfigurationManager.AppSettings.Set("LoguedUser", "")
            Login.ShowDialog()
        Catch ex As MySqlException
            MessageBox.Show(String.Format("Error en el acceso a la base de datos: {0}", ex.Message))

        Catch ex As Exception
            MessageBox.Show(String.Format("Error en la aplicación: {0}", ex.Message))

        End Try
    End Sub

    Private Sub menSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menSalir.Click
        ConfigurationManager.AppSettings.Set("LoguedUser", "")
        Me.Close()
    End Sub

    Private Sub AgregarGastosFijosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgregarGastosFijosToolStripMenuItem.Click
        Try
            Agregar_Gastos_Fijos.ShowDialog(Me)
        Catch ex As MySqlException
            MessageBox.Show(String.Format("Error en el acceso a la base de datos: {0}", ex.Message))

        Catch ex As Exception
            MessageBox.Show(String.Format("Error en la aplicación: {0}", ex.Message))

        End Try
    End Sub

    Private Sub AgregarGastosVariablesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgregarGastosVariablesToolStripMenuItem.Click
        Try
            Agregar_Gastos_Variables.ShowDialog(Me)
        Catch ex As MySqlException
            MessageBox.Show(String.Format("Error en el acceso a la base de datos: {0}", ex.Message))

        Catch ex As Exception
            MessageBox.Show(String.Format("Error en la aplicación: {0}", ex.Message))

        End Try
    End Sub

    Private Sub menuRecuperar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim dlgAbrir As New OpenFileDialog()
        'dlgAbrir.Title = "Seleccione el archivo de respaldo"
        'dlgAbrir.DefaultExt = "*.sql"
        'dlgAbrir.Filter = "Archivos de respaldo (*.sql)|*.sql|Todos los archivos (*.*)|*.*"
        'Dim ruta As String = Application.StartupPath
        'dlgAbrir.InitialDirectory = ruta
        'dlgAbrir.ShowDialog(Me)
        'If (dlgAbrir.CheckFileExists) Then
        '    Dim nom As String = dlgAbrir.FileName
        '    Dim res As Integer = Microsoft.VisualBasic.Interaction.Shell(ruta & "\mysql --host=localhost --user=" & ConfigurationManager.AppSettings("usuario") & "--password=" & ConfigurationManager.AppSettings("clave") & " < " & nom, AppWinStyle.Hide, True)
        '    If (res = 0) Then

        '    End If
        'End If
    End Sub

    Private Sub menuRespaldar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim dlgGuardar As New SaveFileDialog()
        'dlgGuardar.Title = "Seleccione el nombre y la ruta del archivo de respaldo"
        'dlgGuardar.DefaultExt = "*.sql"
        'dlgGuardar.Filter = "Archivos de respaldo (*.sql)|*.sql|Todos los archivos (*.*)|*.*"
        'Dim ruta As String = Application.StartupPath
        'dlgGuardar.InitialDirectory = ruta
        'dlgGuardar.ShowDialog(Me)
        'Dim nom As String = dlgGuardar.FileName
        '    Dim res As Integer = Microsoft.VisualBasic.Interaction.Shell(ruta & "\mysql --host=localhost --user=" & ConfigurationManager.AppSettings("usuario") & "--password=" & ConfigurationManager.AppSettings("clave") & " < " & nom, AppWinStyle.Hide, True)
        '    If (res = 0) Then

        '    End If
    End Sub
End Class
