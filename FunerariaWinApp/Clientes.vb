Imports FunerariaClassLib.BusinessLayer
Imports MySql.Data.MySqlClient

Public Class Clientes

    Private Sub Selec(ByVal sender As Object, ByVal e As EventArgs) Handles GridClientes1.SelectionChanged
        Try
            Me.GridPagos.Plan = CatalogoPlanesPago.GetPlan(Me.GridClientes1.SelectedClient.Codigo)
            If Not (Me.GridPagos.Plan Is Nothing) Then
                Me.Label7.Text = Me.GridPagos.Plan.nCuotas.ToString
                Me.Label8.Text = "$" + Me.GridPagos.Plan.TotalPagar().ToString
                If (Me.GridPagos.Plan.HayPendientes) Then
                    Me.btnsaldar.Enabled = True
                Else
                    Me.btnsaldar.Enabled = False
                End If
            End If
        Catch ex As MySqlException
            MessageBox.Show(String.Format("Error en el acceso a la base de datos: {0}", ex.Message))
            Me.Close()
        End Try
    End Sub

    Private Sub Cargar(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try
            Dim tempclientes As List(Of Cliente) = CatalogoClientes.GetClientes()
            For Each cl As Cliente In tempclientes
                Dim estadoactual As UInt32 = cl.Estado
                cl.SetEstado()
                If (estadoactual <> cl.Estado) Then
                    CatalogoClientes.EditCliente(cl)
                End If
            Next
            Me.GridClientes1.Clientes = CatalogoClientes.GetClientes()
            Me.lbltclientes.Text = "Total de Clientes:  " + Me.GridClientes1.Clientes.Count.ToString
        Catch ex As MySqlException
            MessageBox.Show(String.Format("Error en el acceso a la base de datos: {0}", ex.Message))
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        Try
            Nuevo_Cliente.ShowDialog(Me)
        Catch ex As MySqlException
            MessageBox.Show(String.Format("Error en el acceso a la base de datos: {0}", ex.Message))
            Me.Close()
        End Try
    End Sub
    Private Sub Tecla(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextBox1.KeyUp
        Dim index As Integer = -1
        Try
            If (e.KeyCode = Keys.Enter) Then
                index = Me.GridClientes1.SelectedRows(0).Index
            End If
            Me.GridClientes1.SelectCliente(Me.TextBox1.Text, index)
        Catch ex As MySqlException
            MessageBox.Show(String.Format("Error en el acceso a la base de datos: {0}", ex.Message))
            Me.Close()
        End Try
    End Sub

    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        If (MsgBox("Desea eliminar al cliente seleccionado", MsgBoxStyle.YesNo, "Confirmacón") = MsgBoxResult.Yes) Then
            Try
                For i As Integer = 0 To Me.GridClientes1.SelectedClient.Plan.nCuotas - 1
                    CatalogoCuotas.DelCuota(Me.GridClientes1.SelectedClient.Plan, i)
                Next
                CatalogoPlanesPago.DelPlan(Me.GridClientes1.SelectedClient.Plan)
                CatalogoClientes.DelCliente(Me.GridClientes1.SelectedClient)
                Me.GridClientes1.Clientes = CatalogoClientes.GetClientes
                Me.lbltclientes.Text = "Total de Clientes:  " + Me.GridClientes1.Clientes.Count.ToString
            Catch ex As MySqlException
                MessageBox.Show(String.Format("Error en el acceso a la base de datos: {0}", ex.Message))
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificar.Click
        Try
            Modificar_Cliente.ShowDialog(Me)
        Catch ex As MySqlException
            MessageBox.Show(String.Format("Error en el acceso a la base de datos: {0}", ex.Message))
            Me.Close()
        End Try
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub btnsaldar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsaldar.Click
        If (Me.GridPagos.Plan.HayPendientes) Then
            Try
                Dim ct As Cuota = Me.GridPagos.Plan.Pendiente
                ct.Cancelada = EstadoCuota.Cancelada
                CatalogoCuotas.Saldar(ct, Me.GridClientes1.SelectedClient.Plan)
                MessageBox.Show(String.Format("La cuota seleccionada del mes {0} ha sido cancelada con {1}", ct.Mes, ct.Cantidad))
                Me.GridPagos.Plan = CatalogoPlanesPago.GetPlan(Me.GridClientes1.SelectedClient.Codigo)
                Me.GridClientes1.SelectedClient.Plan = Me.GridPagos.Plan
                Dim est As UInteger = Me.GridClientes1.SelectedClient.Estado
                Me.GridClientes1.SelectedClient.SetEstado()
                If (est <> Me.GridClientes1.SelectedClient.Estado) Then
                    CatalogoClientes.EditCliente(Me.GridClientes1.SelectedClient)
                    Dim selectedCode As String = Me.GridClientes1.SelectedClient.Codigo
                    'Dim col As Integer
                    'Try
                    '    col = Me.GridClientes1.SortedColumn.Index
                    'Catch ex As NullReferenceException
                    '    col = 0
                    'End Try
                    'Dim ord As SortOrder = Me.GridClientes1.SortOrder
                    Me.GridClientes1.Clientes = CatalogoClientes.GetClientes()
                    'If (Me.GridClientes1.SortedColumn.Index <> col) Then
                    '    If (Me.GridClientes1.SortOrder = ord) Then
                    '        Me.GridClientes1.Sort(Me.GridClientes1.Columns(col), ord)
                    '    End If
                    '    Me.GridClientes1.Sort(Me.GridClientes1.Columns(col), ord)
                    'End If
                    Me.GridClientes1.SelectCliente(selectedCode, -1)
                End If
                If Not (Me.GridPagos.Plan.HayPendientes) Then
                    Me.btnsaldar.Enabled = False
                End If
            Catch ex As MySqlException
                MessageBox.Show(String.Format("Error en el acceso a la base de datos: {0}", ex.Message))
                Me.Close()
            End Try
        End If
    End Sub


End Class