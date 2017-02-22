<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CG
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CG))
        Me.NombreC = New System.Windows.Forms.TextBox()
        Me.ClientID = New System.Windows.Forms.TextBox()
        Me.ClientSecret = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btngrabar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'NombreC
        '
        Me.NombreC.Location = New System.Drawing.Point(12, 23)
        Me.NombreC.Name = "NombreC"
        Me.NombreC.Size = New System.Drawing.Size(429, 20)
        Me.NombreC.TabIndex = 0
        '
        'ClientID
        '
        Me.ClientID.Location = New System.Drawing.Point(12, 62)
        Me.ClientID.Name = "ClientID"
        Me.ClientID.Size = New System.Drawing.Size(429, 20)
        Me.ClientID.TabIndex = 1
        '
        'ClientSecret
        '
        Me.ClientSecret.Location = New System.Drawing.Point(12, 101)
        Me.ClientSecret.Name = "ClientSecret"
        Me.ClientSecret.Size = New System.Drawing.Size(429, 20)
        Me.ClientSecret.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Nombre Cuenta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Client ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Client Secret"
        '
        'btngrabar
        '
        Me.btngrabar.Location = New System.Drawing.Point(182, 127)
        Me.btngrabar.Name = "btngrabar"
        Me.btngrabar.Size = New System.Drawing.Size(75, 23)
        Me.btngrabar.TabIndex = 6
        Me.btngrabar.Text = "Grabar"
        Me.btngrabar.UseVisualStyleBackColor = True
        '
        'CG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 160)
        Me.Controls.Add(Me.btngrabar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ClientSecret)
        Me.Controls.Add(Me.ClientID)
        Me.Controls.Add(Me.NombreC)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CG"
        Me.Text = "Google Drive"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents NombreC As TextBox
    Friend WithEvents ClientID As TextBox
    Friend WithEvents ClientSecret As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btngrabar As Button
End Class
