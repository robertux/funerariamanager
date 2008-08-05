<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Principal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExaminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AdministradoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExaminarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GastosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FijosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VariablesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AgregarGastosFijosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AgregarGastosVariablesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AplicacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.menBloquear = New System.Windows.Forms.ToolStripMenuItem
        Me.menSalir = New System.Windows.Forms.ToolStripMenuItem
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblfecha = New System.Windows.Forms.Label
        Me.lbllogin = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClientesToolStripMenuItem, Me.AdministradoresToolStripMenuItem, Me.GastosToolStripMenuItem, Me.AplicacionToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(790, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ClientesToolStripMenuItem
        '
        Me.ClientesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExaminarToolStripMenuItem})
        Me.ClientesToolStripMenuItem.Name = "ClientesToolStripMenuItem"
        Me.ClientesToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ClientesToolStripMenuItem.Text = "Clientes"
        '
        'ExaminarToolStripMenuItem
        '
        Me.ExaminarToolStripMenuItem.Name = "ExaminarToolStripMenuItem"
        Me.ExaminarToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.ExaminarToolStripMenuItem.Text = "Examinar"
        '
        'AdministradoresToolStripMenuItem
        '
        Me.AdministradoresToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExaminarToolStripMenuItem1})
        Me.AdministradoresToolStripMenuItem.Name = "AdministradoresToolStripMenuItem"
        Me.AdministradoresToolStripMenuItem.Size = New System.Drawing.Size(96, 20)
        Me.AdministradoresToolStripMenuItem.Text = "Administradores"
        '
        'ExaminarToolStripMenuItem1
        '
        Me.ExaminarToolStripMenuItem1.Name = "ExaminarToolStripMenuItem1"
        Me.ExaminarToolStripMenuItem1.Size = New System.Drawing.Size(129, 22)
        Me.ExaminarToolStripMenuItem1.Text = "Examinar"
        '
        'GastosToolStripMenuItem
        '
        Me.GastosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FijosToolStripMenuItem, Me.VariablesToolStripMenuItem, Me.AgregarGastosFijosToolStripMenuItem, Me.AgregarGastosVariablesToolStripMenuItem})
        Me.GastosToolStripMenuItem.Name = "GastosToolStripMenuItem"
        Me.GastosToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.GastosToolStripMenuItem.Text = "Gastos"
        '
        'FijosToolStripMenuItem
        '
        Me.FijosToolStripMenuItem.Name = "FijosToolStripMenuItem"
        Me.FijosToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.FijosToolStripMenuItem.Text = "Fijos "
        '
        'VariablesToolStripMenuItem
        '
        Me.VariablesToolStripMenuItem.Name = "VariablesToolStripMenuItem"
        Me.VariablesToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.VariablesToolStripMenuItem.Text = "Variables"
        '
        'AgregarGastosFijosToolStripMenuItem
        '
        Me.AgregarGastosFijosToolStripMenuItem.Name = "AgregarGastosFijosToolStripMenuItem"
        Me.AgregarGastosFijosToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.AgregarGastosFijosToolStripMenuItem.Text = "Agregar Gastos Fijos"
        '
        'AgregarGastosVariablesToolStripMenuItem
        '
        Me.AgregarGastosVariablesToolStripMenuItem.Name = "AgregarGastosVariablesToolStripMenuItem"
        Me.AgregarGastosVariablesToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.AgregarGastosVariablesToolStripMenuItem.Text = "Agregar Gastos Variables"
        '
        'AplicacionToolStripMenuItem
        '
        Me.AplicacionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.menBloquear, Me.menSalir})
        Me.AplicacionToolStripMenuItem.Name = "AplicacionToolStripMenuItem"
        Me.AplicacionToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.AplicacionToolStripMenuItem.Text = "Aplicacion"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(124, 6)
        '
        'menBloquear
        '
        Me.menBloquear.Name = "menBloquear"
        Me.menBloquear.Size = New System.Drawing.Size(127, 22)
        Me.menBloquear.Text = "Bloquear"
        '
        'menSalir
        '
        Me.menSalir.Name = "menSalir"
        Me.menSalir.Size = New System.Drawing.Size(127, 22)
        Me.menSalir.Text = "Salir"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(54, 103)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(670, 377)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'lblfecha
        '
        Me.lblfecha.AutoSize = True
        Me.lblfecha.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblfecha.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfecha.Location = New System.Drawing.Point(790, 24)
        Me.lblfecha.Name = "lblfecha"
        Me.lblfecha.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblfecha.Size = New System.Drawing.Size(0, 22)
        Me.lblfecha.TabIndex = 2
        '
        'lbllogin
        '
        Me.lbllogin.AutoSize = True
        Me.lbllogin.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbllogin.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllogin.Location = New System.Drawing.Point(0, 24)
        Me.lbllogin.Name = "lbllogin"
        Me.lbllogin.Size = New System.Drawing.Size(0, 22)
        Me.lbllogin.TabIndex = 3
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 564)
        Me.Controls.Add(Me.lbllogin)
        Me.Controls.Add(Me.lblfecha)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Principal"
        Me.Text = "Funeraria San Juan"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ClientesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExaminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdministradoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExaminarToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GastosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FijosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VariablesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents AplicacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menBloquear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AgregarGastosFijosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AgregarGastosVariablesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblfecha As System.Windows.Forms.Label
    Friend WithEvents lbllogin As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator

End Class
