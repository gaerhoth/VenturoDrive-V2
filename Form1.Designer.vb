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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VentuDrive))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lvArchivos = New System.Windows.Forms.ListView()
        Me.lvCuentas = New System.Windows.Forms.ListView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CuentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GoogleDriveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExistenteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ObtenerCredencialesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OneDriveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExistenteToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DropBoxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevaToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExistenteToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransferenciaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeleccionarCuentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopiaBBDDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestaurarBBDDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtdirsubir = New System.Windows.Forms.TextBox()
        Me.txtcreardir = New System.Windows.Forms.TextBox()
        Me.SelDir = New System.Windows.Forms.Button()
        Me.Btn_organizar = New System.Windows.Forms.Button()
        Me.btndirfotos = New System.Windows.Forms.Button()
        Me.txtdirfotos = New System.Windows.Forms.TextBox()
        Me.PB = New System.Windows.Forms.ProgressBar()
        Me.lbl_PB = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_uni = New System.Windows.Forms.Button()
        Me.dir_uni = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.CR = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GoogleDriveToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OneDriveToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DropBoxToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnrefres = New System.Windows.Forms.Button()
        Me.PBLIBRE = New System.Windows.Forms.ProgressBar()
        Me.MenuStrip1.SuspendLayout()
        Me.CR.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(243, 455)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(118, 24)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Directorio para subir"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lvArchivos
        '
        Me.lvArchivos.Location = New System.Drawing.Point(243, 105)
        Me.lvArchivos.Margin = New System.Windows.Forms.Padding(2)
        Me.lvArchivos.Name = "lvArchivos"
        Me.lvArchivos.Size = New System.Drawing.Size(572, 346)
        Me.lvArchivos.TabIndex = 1
        Me.lvArchivos.UseCompatibleStateImageBehavior = False
        '
        'lvCuentas
        '
        Me.lvCuentas.FullRowSelect = True
        Me.lvCuentas.Location = New System.Drawing.Point(9, 103)
        Me.lvCuentas.Margin = New System.Windows.Forms.Padding(2)
        Me.lvCuentas.Name = "lvCuentas"
        Me.lvCuentas.Size = New System.Drawing.Size(217, 346)
        Me.lvCuentas.SmallImageList = Me.ImageList1
        Me.lvCuentas.TabIndex = 2
        Me.lvCuentas.UseCompatibleStateImageBehavior = False
        Me.lvCuentas.View = System.Windows.Forms.View.List
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "drive.jpg")
        Me.ImageList1.Images.SetKeyName(1, "Dropbox.png")
        Me.ImageList1.Images.SetKeyName(2, "one.jpg")
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.TransferenciaToolStripMenuItem, Me.AyudaToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(839, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CuentasToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'CuentasToolStripMenuItem
        '
        Me.CuentasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GoogleDriveToolStripMenuItem, Me.OneDriveToolStripMenuItem, Me.DropBoxToolStripMenuItem})
        Me.CuentasToolStripMenuItem.Name = "CuentasToolStripMenuItem"
        Me.CuentasToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.CuentasToolStripMenuItem.Text = "Cuentas"
        '
        'GoogleDriveToolStripMenuItem
        '
        Me.GoogleDriveToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaToolStripMenuItem, Me.ExistenteToolStripMenuItem, Me.ObtenerCredencialesToolStripMenuItem})
        Me.GoogleDriveToolStripMenuItem.Name = "GoogleDriveToolStripMenuItem"
        Me.GoogleDriveToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.GoogleDriveToolStripMenuItem.Text = "Google Drive"
        '
        'NuevaToolStripMenuItem
        '
        Me.NuevaToolStripMenuItem.Name = "NuevaToolStripMenuItem"
        Me.NuevaToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.NuevaToolStripMenuItem.Text = "Nueva"
        '
        'ExistenteToolStripMenuItem
        '
        Me.ExistenteToolStripMenuItem.Name = "ExistenteToolStripMenuItem"
        Me.ExistenteToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.ExistenteToolStripMenuItem.Text = "Existente"
        '
        'ObtenerCredencialesToolStripMenuItem
        '
        Me.ObtenerCredencialesToolStripMenuItem.Name = "ObtenerCredencialesToolStripMenuItem"
        Me.ObtenerCredencialesToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.ObtenerCredencialesToolStripMenuItem.Text = "Obtener Credenciales"
        '
        'OneDriveToolStripMenuItem
        '
        Me.OneDriveToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaToolStripMenuItem1, Me.ExistenteToolStripMenuItem1})
        Me.OneDriveToolStripMenuItem.Name = "OneDriveToolStripMenuItem"
        Me.OneDriveToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.OneDriveToolStripMenuItem.Text = "One Drive"
        '
        'NuevaToolStripMenuItem1
        '
        Me.NuevaToolStripMenuItem1.Name = "NuevaToolStripMenuItem1"
        Me.NuevaToolStripMenuItem1.Size = New System.Drawing.Size(120, 22)
        Me.NuevaToolStripMenuItem1.Text = "Nueva"
        '
        'ExistenteToolStripMenuItem1
        '
        Me.ExistenteToolStripMenuItem1.Name = "ExistenteToolStripMenuItem1"
        Me.ExistenteToolStripMenuItem1.Size = New System.Drawing.Size(120, 22)
        Me.ExistenteToolStripMenuItem1.Text = "Existente"
        '
        'DropBoxToolStripMenuItem
        '
        Me.DropBoxToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaToolStripMenuItem2, Me.ExistenteToolStripMenuItem2})
        Me.DropBoxToolStripMenuItem.Name = "DropBoxToolStripMenuItem"
        Me.DropBoxToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.DropBoxToolStripMenuItem.Text = "DropBox"
        '
        'NuevaToolStripMenuItem2
        '
        Me.NuevaToolStripMenuItem2.Name = "NuevaToolStripMenuItem2"
        Me.NuevaToolStripMenuItem2.Size = New System.Drawing.Size(120, 22)
        Me.NuevaToolStripMenuItem2.Text = "Nueva"
        '
        'ExistenteToolStripMenuItem2
        '
        Me.ExistenteToolStripMenuItem2.Name = "ExistenteToolStripMenuItem2"
        Me.ExistenteToolStripMenuItem2.Size = New System.Drawing.Size(120, 22)
        Me.ExistenteToolStripMenuItem2.Text = "Existente"
        '
        'TransferenciaToolStripMenuItem
        '
        Me.TransferenciaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SeleccionarCuentasToolStripMenuItem})
        Me.TransferenciaToolStripMenuItem.Name = "TransferenciaToolStripMenuItem"
        Me.TransferenciaToolStripMenuItem.Size = New System.Drawing.Size(89, 20)
        Me.TransferenciaToolStripMenuItem.Text = "Transferencia"
        '
        'SeleccionarCuentasToolStripMenuItem
        '
        Me.SeleccionarCuentasToolStripMenuItem.Name = "SeleccionarCuentasToolStripMenuItem"
        Me.SeleccionarCuentasToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SeleccionarCuentasToolStripMenuItem.Text = "Seleccionar Cuentas"
        '
        'AyudaToolStripMenuItem
        '
        Me.AyudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopiaBBDDToolStripMenuItem, Me.RestaurarBBDDToolStripMenuItem})
        Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.AyudaToolStripMenuItem.Text = "Ayuda"
        '
        'CopiaBBDDToolStripMenuItem
        '
        Me.CopiaBBDDToolStripMenuItem.Name = "CopiaBBDDToolStripMenuItem"
        Me.CopiaBBDDToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.CopiaBBDDToolStripMenuItem.Text = "Copia BBDD"
        '
        'RestaurarBBDDToolStripMenuItem
        '
        Me.RestaurarBBDDToolStripMenuItem.Name = "RestaurarBBDDToolStripMenuItem"
        Me.RestaurarBBDDToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.RestaurarBBDDToolStripMenuItem.Text = "Restaurar BBDD"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 86)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Cuentas"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(161, 86)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Archivos"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(243, 483)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(118, 24)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Crear Directorio"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtdirsubir
        '
        Me.txtdirsubir.Location = New System.Drawing.Point(366, 457)
        Me.txtdirsubir.Margin = New System.Windows.Forms.Padding(2)
        Me.txtdirsubir.Name = "txtdirsubir"
        Me.txtdirsubir.Size = New System.Drawing.Size(403, 20)
        Me.txtdirsubir.TabIndex = 7
        '
        'txtcreardir
        '
        Me.txtcreardir.Location = New System.Drawing.Point(366, 486)
        Me.txtcreardir.Margin = New System.Windows.Forms.Padding(2)
        Me.txtcreardir.Name = "txtcreardir"
        Me.txtcreardir.Size = New System.Drawing.Size(403, 20)
        Me.txtcreardir.TabIndex = 8
        '
        'SelDir
        '
        Me.SelDir.Location = New System.Drawing.Point(772, 455)
        Me.SelDir.Margin = New System.Windows.Forms.Padding(2)
        Me.SelDir.Name = "SelDir"
        Me.SelDir.Size = New System.Drawing.Size(26, 24)
        Me.SelDir.TabIndex = 9
        Me.SelDir.Text = "..."
        Me.SelDir.UseVisualStyleBackColor = True
        '
        'Btn_organizar
        '
        Me.Btn_organizar.Location = New System.Drawing.Point(12, 53)
        Me.Btn_organizar.Margin = New System.Windows.Forms.Padding(2)
        Me.Btn_organizar.Name = "Btn_organizar"
        Me.Btn_organizar.Size = New System.Drawing.Size(118, 24)
        Me.Btn_organizar.TabIndex = 10
        Me.Btn_organizar.Text = "Organizar Fotos"
        Me.Btn_organizar.UseVisualStyleBackColor = True
        '
        'btndirfotos
        '
        Me.btndirfotos.Location = New System.Drawing.Point(546, 54)
        Me.btndirfotos.Margin = New System.Windows.Forms.Padding(2)
        Me.btndirfotos.Name = "btndirfotos"
        Me.btndirfotos.Size = New System.Drawing.Size(26, 24)
        Me.btndirfotos.TabIndex = 12
        Me.btndirfotos.Text = "..."
        Me.btndirfotos.UseVisualStyleBackColor = True
        '
        'txtdirfotos
        '
        Me.txtdirfotos.Enabled = False
        Me.txtdirfotos.Location = New System.Drawing.Point(140, 56)
        Me.txtdirfotos.Margin = New System.Windows.Forms.Padding(2)
        Me.txtdirfotos.Name = "txtdirfotos"
        Me.txtdirfotos.Size = New System.Drawing.Size(403, 20)
        Me.txtdirfotos.TabIndex = 11
        '
        'PB
        '
        Me.PB.Location = New System.Drawing.Point(577, 54)
        Me.PB.Name = "PB"
        Me.PB.Size = New System.Drawing.Size(130, 23)
        Me.PB.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PB.TabIndex = 13
        '
        'lbl_PB
        '
        Me.lbl_PB.AutoSize = True
        Me.lbl_PB.Location = New System.Drawing.Point(712, 59)
        Me.lbl_PB.Name = "lbl_PB"
        Me.lbl_PB.Size = New System.Drawing.Size(24, 13)
        Me.lbl_PB.TabIndex = 14
        Me.lbl_PB.Text = "0 %"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Directorio de unificaccion"
        '
        'btn_uni
        '
        Me.btn_uni.Location = New System.Drawing.Point(546, 24)
        Me.btn_uni.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_uni.Name = "btn_uni"
        Me.btn_uni.Size = New System.Drawing.Size(26, 24)
        Me.btn_uni.TabIndex = 18
        Me.btn_uni.Text = "..."
        Me.btn_uni.UseVisualStyleBackColor = True
        '
        'dir_uni
        '
        Me.dir_uni.Enabled = False
        Me.dir_uni.Location = New System.Drawing.Point(140, 26)
        Me.dir_uni.Margin = New System.Windows.Forms.Padding(2)
        Me.dir_uni.Name = "dir_uni"
        Me.dir_uni.Size = New System.Drawing.Size(403, 20)
        Me.dir_uni.TabIndex = 17
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(14, 522)
        Me.Button3.Margin = New System.Windows.Forms.Padding(2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(118, 24)
        Me.Button3.TabIndex = 19
        Me.Button3.Text = "Directorio para subir"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'CR
        '
        Me.CR.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EliminarToolStripMenuItem, Me.EliminarToolStripMenuItem1})
        Me.CR.Name = "CR"
        Me.CR.ShowImageMargin = False
        Me.CR.Size = New System.Drawing.Size(93, 48)
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GoogleDriveToolStripMenuItem1, Me.OneDriveToolStripMenuItem1, Me.DropBoxToolStripMenuItem1})
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.EliminarToolStripMenuItem.Text = "Nueva"
        '
        'GoogleDriveToolStripMenuItem1
        '
        Me.GoogleDriveToolStripMenuItem1.Name = "GoogleDriveToolStripMenuItem1"
        Me.GoogleDriveToolStripMenuItem1.Size = New System.Drawing.Size(142, 22)
        Me.GoogleDriveToolStripMenuItem1.Text = "Google Drive"
        '
        'OneDriveToolStripMenuItem1
        '
        Me.OneDriveToolStripMenuItem1.Name = "OneDriveToolStripMenuItem1"
        Me.OneDriveToolStripMenuItem1.Size = New System.Drawing.Size(142, 22)
        Me.OneDriveToolStripMenuItem1.Text = "One Drive"
        '
        'DropBoxToolStripMenuItem1
        '
        Me.DropBoxToolStripMenuItem1.Name = "DropBoxToolStripMenuItem1"
        Me.DropBoxToolStripMenuItem1.Size = New System.Drawing.Size(142, 22)
        Me.DropBoxToolStripMenuItem1.Text = "DropBox"
        '
        'EliminarToolStripMenuItem1
        '
        Me.EliminarToolStripMenuItem1.Name = "EliminarToolStripMenuItem1"
        Me.EliminarToolStripMenuItem1.Size = New System.Drawing.Size(92, 22)
        Me.EliminarToolStripMenuItem1.Text = "Eliminar"
        '
        'btnrefres
        '
        Me.btnrefres.Location = New System.Drawing.Point(15, 495)
        Me.btnrefres.Margin = New System.Windows.Forms.Padding(2)
        Me.btnrefres.Name = "btnrefres"
        Me.btnrefres.Size = New System.Drawing.Size(118, 24)
        Me.btnrefres.TabIndex = 21
        Me.btnrefres.Text = "Refrescar Cuentas"
        Me.btnrefres.UseVisualStyleBackColor = True
        '
        'PBLIBRE
        '
        Me.PBLIBRE.Location = New System.Drawing.Point(15, 467)
        Me.PBLIBRE.Name = "PBLIBRE"
        Me.PBLIBRE.Size = New System.Drawing.Size(211, 23)
        Me.PBLIBRE.TabIndex = 22
        '
        'VentuDrive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(839, 585)
        Me.Controls.Add(Me.PBLIBRE)
        Me.Controls.Add(Me.btnrefres)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btn_uni)
        Me.Controls.Add(Me.dir_uni)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbl_PB)
        Me.Controls.Add(Me.PB)
        Me.Controls.Add(Me.btndirfotos)
        Me.Controls.Add(Me.txtdirfotos)
        Me.Controls.Add(Me.Btn_organizar)
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
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "VentuDrive"
        Me.Text = "VentuDrive"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.CR.ResumeLayout(False)
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
    Friend WithEvents Btn_organizar As Button
    Friend WithEvents btndirfotos As Button
    Friend WithEvents txtdirfotos As TextBox
    Friend WithEvents PB As ProgressBar
    Friend WithEvents lbl_PB As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btn_uni As Button
    Friend WithEvents dir_uni As TextBox
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Button3 As Button
    Friend WithEvents ObtenerCredencialesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CR As ContextMenuStrip
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnrefres As Button
    Friend WithEvents GoogleDriveToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents OneDriveToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DropBoxToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents PBLIBRE As ProgressBar
    Friend WithEvents AyudaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopiaBBDDToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RestaurarBBDDToolStripMenuItem As ToolStripMenuItem
End Class
