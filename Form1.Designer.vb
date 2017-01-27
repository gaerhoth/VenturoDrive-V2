<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VentuDrive
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lvArchivos = New System.Windows.Forms.ListView()
        Me.lvCuentas = New System.Windows.Forms.ListView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CuentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GoogleDriveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExistenteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OneDriveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExistenteToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DropBoxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevaToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExistenteToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransferenciaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtdirsubir = New System.Windows.Forms.TextBox()
        Me.txtcreardir = New System.Windows.Forms.TextBox()
        Me.SelDir = New System.Windows.Forms.Button()
        Me.SeleccionarCuentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(215, 492)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(157, 29)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Directorio para subir"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lvArchivos
        '
        Me.lvArchivos.Location = New System.Drawing.Point(215, 61)
        Me.lvArchivos.Name = "lvArchivos"
        Me.lvArchivos.Size = New System.Drawing.Size(761, 425)
        Me.lvArchivos.TabIndex = 1
        Me.lvArchivos.UseCompatibleStateImageBehavior = False
        '
        'lvCuentas
        '
        Me.lvCuentas.Location = New System.Drawing.Point(12, 61)
        Me.lvCuentas.Name = "lvCuentas"
        Me.lvCuentas.Size = New System.Drawing.Size(197, 425)
        Me.lvCuentas.TabIndex = 2
        Me.lvCuentas.UseCompatibleStateImageBehavior = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.TransferenciaToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(988, 28)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CuentasToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(71, 24)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'CuentasToolStripMenuItem
        '
        Me.CuentasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GoogleDriveToolStripMenuItem, Me.OneDriveToolStripMenuItem, Me.DropBoxToolStripMenuItem})
        Me.CuentasToolStripMenuItem.Name = "CuentasToolStripMenuItem"
        Me.CuentasToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.CuentasToolStripMenuItem.Text = "Cuentas"
        '
        'GoogleDriveToolStripMenuItem
        '
        Me.GoogleDriveToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaToolStripMenuItem, Me.ExistenteToolStripMenuItem})
        Me.GoogleDriveToolStripMenuItem.Name = "GoogleDriveToolStripMenuItem"
        Me.GoogleDriveToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.GoogleDriveToolStripMenuItem.Text = "Google Drive"
        '
        'NuevaToolStripMenuItem
        '
        Me.NuevaToolStripMenuItem.Name = "NuevaToolStripMenuItem"
        Me.NuevaToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.NuevaToolStripMenuItem.Text = "Nueva"
        '
        'ExistenteToolStripMenuItem
        '
        Me.ExistenteToolStripMenuItem.Name = "ExistenteToolStripMenuItem"
        Me.ExistenteToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.ExistenteToolStripMenuItem.Text = "Existente"
        '
        'OneDriveToolStripMenuItem
        '
        Me.OneDriveToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaToolStripMenuItem1, Me.ExistenteToolStripMenuItem1})
        Me.OneDriveToolStripMenuItem.Name = "OneDriveToolStripMenuItem"
        Me.OneDriveToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.OneDriveToolStripMenuItem.Text = "One Drive"
        '
        'NuevaToolStripMenuItem1
        '
        Me.NuevaToolStripMenuItem1.Name = "NuevaToolStripMenuItem1"
        Me.NuevaToolStripMenuItem1.Size = New System.Drawing.Size(181, 26)
        Me.NuevaToolStripMenuItem1.Text = "Nueva"
        '
        'ExistenteToolStripMenuItem1
        '
        Me.ExistenteToolStripMenuItem1.Name = "ExistenteToolStripMenuItem1"
        Me.ExistenteToolStripMenuItem1.Size = New System.Drawing.Size(181, 26)
        Me.ExistenteToolStripMenuItem1.Text = "Existente"
        '
        'DropBoxToolStripMenuItem
        '
        Me.DropBoxToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaToolStripMenuItem2, Me.ExistenteToolStripMenuItem2})
        Me.DropBoxToolStripMenuItem.Name = "DropBoxToolStripMenuItem"
        Me.DropBoxToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.DropBoxToolStripMenuItem.Text = "DropBox"
        '
        'NuevaToolStripMenuItem2
        '
        Me.NuevaToolStripMenuItem2.Name = "NuevaToolStripMenuItem2"
        Me.NuevaToolStripMenuItem2.Size = New System.Drawing.Size(181, 26)
        Me.NuevaToolStripMenuItem2.Text = "Nueva"
        '
        'ExistenteToolStripMenuItem2
        '
        Me.ExistenteToolStripMenuItem2.Name = "ExistenteToolStripMenuItem2"
        Me.ExistenteToolStripMenuItem2.Size = New System.Drawing.Size(181, 26)
        Me.ExistenteToolStripMenuItem2.Text = "Existente"
        '
        'TransferenciaToolStripMenuItem
        '
        Me.TransferenciaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SeleccionarCuentasToolStripMenuItem})
        Me.TransferenciaToolStripMenuItem.Name = "TransferenciaToolStripMenuItem"
        Me.TransferenciaToolStripMenuItem.Size = New System.Drawing.Size(108, 24)
        Me.TransferenciaToolStripMenuItem.Text = "Transferencia"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(50, 24)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Cuentas"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(215, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Archivos"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(215, 527)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(157, 29)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Crear Directorio"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtdirsubir
        '
        Me.txtdirsubir.Location = New System.Drawing.Point(378, 495)
        Me.txtdirsubir.Name = "txtdirsubir"
        Me.txtdirsubir.Size = New System.Drawing.Size(536, 22)
        Me.txtdirsubir.TabIndex = 7
        '
        'txtcreardir
        '
        Me.txtcreardir.Location = New System.Drawing.Point(378, 530)
        Me.txtcreardir.Name = "txtcreardir"
        Me.txtcreardir.Size = New System.Drawing.Size(536, 22)
        Me.txtcreardir.TabIndex = 8
        '
        'SelDir
        '
        Me.SelDir.Location = New System.Drawing.Point(920, 492)
        Me.SelDir.Name = "SelDir"
        Me.SelDir.Size = New System.Drawing.Size(35, 29)
        Me.SelDir.TabIndex = 9
        Me.SelDir.Text = "..."
        Me.SelDir.UseVisualStyleBackColor = True
        '
        'SeleccionarCuentasToolStripMenuItem
        '
        Me.SeleccionarCuentasToolStripMenuItem.Name = "SeleccionarCuentasToolStripMenuItem"
        Me.SeleccionarCuentasToolStripMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.SeleccionarCuentasToolStripMenuItem.Text = "Seleccionar Cuentas"
        '
        'VentuDrive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(988, 590)
        Me.Controls.Add(Me.SelDir)
        Me.Controls.Add(Me.txtcreardir)
        Me.Controls.Add(Me.txtdirsubir)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lvCuentas)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.lvArchivos)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "VentuDrive"
        Me.Text = "VentuDrive"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents lvArchivos As ListView
    Friend WithEvents lvCuentas As ListView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TransferenciaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CuentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GoogleDriveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NuevaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExistenteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OneDriveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NuevaToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ExistenteToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DropBoxToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NuevaToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ExistenteToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents SeleccionarCuentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtdirsubir As TextBox
    Friend WithEvents txtcreardir As TextBox
    Friend WithEvents SelDir As Button
End Class
