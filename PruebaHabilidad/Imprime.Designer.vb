<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Imprime
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lbClave = New System.Windows.Forms.Label()
        Me.lbNombre = New System.Windows.Forms.Label()
        Me.lbFecha = New System.Windows.Forms.Label()
        Me.lblClave = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.LabelEmpresa = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lbNumeroPagina = New System.Windows.Forms.Label()
        Me.LabelPagina = New System.Windows.Forms.Label()
        Me.lblEdad = New System.Windows.Forms.Label()
        Me.lblEdadActual = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbClave
        '
        Me.lbClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbClave.Location = New System.Drawing.Point(104, 157)
        Me.lbClave.Name = "lbClave"
        Me.lbClave.Size = New System.Drawing.Size(264, 20)
        Me.lbClave.TabIndex = 36
        Me.lbClave.Text = "-"
        '
        'lbNombre
        '
        Me.lbNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNombre.Location = New System.Drawing.Point(108, 203)
        Me.lbNombre.Name = "lbNombre"
        Me.lbNombre.Size = New System.Drawing.Size(450, 20)
        Me.lbNombre.TabIndex = 35
        Me.lbNombre.Text = "0"
        '
        'lbFecha
        '
        Me.lbFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFecha.Location = New System.Drawing.Point(210, 246)
        Me.lbFecha.Name = "lbFecha"
        Me.lbFecha.Size = New System.Drawing.Size(174, 20)
        Me.lbFecha.TabIndex = 34
        Me.lbFecha.Text = "0"
        '
        'lblClave
        '
        Me.lblClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClave.Location = New System.Drawing.Point(27, 157)
        Me.lblClave.Name = "lblClave"
        Me.lblClave.Size = New System.Drawing.Size(63, 20)
        Me.lblClave.TabIndex = 33
        Me.lblClave.Text = "Clave"
        '
        'lblNombre
        '
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(25, 203)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(79, 20)
        Me.lblNombre.TabIndex = 32
        Me.lblNombre.Text = "Nombre"
        '
        'lblFecha
        '
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(27, 246)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(161, 20)
        Me.lblFecha.TabIndex = 31
        Me.lblFecha.Text = "Fecha de nacimiento:"
        '
        'LabelEmpresa
        '
        Me.LabelEmpresa.AutoSize = True
        Me.LabelEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelEmpresa.Location = New System.Drawing.Point(351, 53)
        Me.LabelEmpresa.Name = "LabelEmpresa"
        Me.LabelEmpresa.Size = New System.Drawing.Size(207, 33)
        Me.LabelEmpresa.TabIndex = 28
        Me.LabelEmpresa.Text = "ABRHILSOFT"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PruebaHabilidad.My.Resources.Resources._1
        Me.PictureBox1.Location = New System.Drawing.Point(31, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(137, 116)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 27
        Me.PictureBox1.TabStop = False
        '
        'lbNumeroPagina
        '
        Me.lbNumeroPagina.AutoSize = True
        Me.lbNumeroPagina.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNumeroPagina.Location = New System.Drawing.Point(741, 527)
        Me.lbNumeroPagina.Name = "lbNumeroPagina"
        Me.lbNumeroPagina.Size = New System.Drawing.Size(18, 20)
        Me.lbNumeroPagina.TabIndex = 51
        Me.lbNumeroPagina.Text = "0"
        '
        'LabelPagina
        '
        Me.LabelPagina.AutoSize = True
        Me.LabelPagina.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPagina.Location = New System.Drawing.Point(681, 527)
        Me.LabelPagina.Name = "LabelPagina"
        Me.LabelPagina.Size = New System.Drawing.Size(54, 20)
        Me.LabelPagina.TabIndex = 50
        Me.LabelPagina.Text = "Pág. #"
        '
        'lblEdad
        '
        Me.lblEdad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEdad.Location = New System.Drawing.Point(572, 246)
        Me.lblEdad.Name = "lblEdad"
        Me.lblEdad.Size = New System.Drawing.Size(221, 20)
        Me.lblEdad.TabIndex = 53
        Me.lblEdad.Text = "-"
        '
        'lblEdadActual
        '
        Me.lblEdadActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEdadActual.Location = New System.Drawing.Point(456, 246)
        Me.lblEdadActual.Name = "lblEdadActual"
        Me.lblEdadActual.Size = New System.Drawing.Size(102, 20)
        Me.lblEdadActual.TabIndex = 52
        Me.lblEdadActual.Text = "Edad actual:"
        '
        'Imprime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(764, 558)
        Me.Controls.Add(Me.lblEdad)
        Me.Controls.Add(Me.lblEdadActual)
        Me.Controls.Add(Me.lbNumeroPagina)
        Me.Controls.Add(Me.LabelPagina)
        Me.Controls.Add(Me.lbClave)
        Me.Controls.Add(Me.lbNombre)
        Me.Controls.Add(Me.lbFecha)
        Me.Controls.Add(Me.lblClave)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.LabelEmpresa)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Imprime"
        Me.Text = "Imprime"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbClave As Label
    Friend WithEvents lbNombre As Label
    Friend WithEvents lbFecha As Label
    Friend WithEvents lblClave As Label
    Friend WithEvents lblNombre As Label
    Friend WithEvents lblFecha As Label
    Friend WithEvents LabelEmpresa As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lbNumeroPagina As Label
    Friend WithEvents LabelPagina As Label
    Friend WithEvents lblEdad As Label
    Friend WithEvents lblEdadActual As Label
End Class
