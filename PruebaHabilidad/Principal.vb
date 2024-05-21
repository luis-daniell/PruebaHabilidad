Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class Registro


    Dim AdaptadorReporte As OleDb.OleDbDataAdapter

    ''**--- Obtiene la cadena de conexion del formulario
    Public cnn As SqlConnection = New SqlConnection(My.Settings.ConnectionString)





    ''**--- TABULACIONES ENTRE CAMPOS con enter


    Private Sub mkPr_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles mkPr.KeyPress
        If Asc(e.KeyChar) = 13 Then 'el 13 es la tecla enter
            SendKeys.Send("{Tab}")
        End If
    End Sub


    Private Sub txtApellidoP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtApellidoP.KeyPress
        If Asc(e.KeyChar) = 13 Then 'el 13 es la tecla enter
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If Asc(e.KeyChar) = 13 Then 'el 13 es la tecla enter
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub mkFechaNac_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then 'el 13 es la tecla enter
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub txtApellidoM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtApellidoM.KeyPress
        If Asc(e.KeyChar) = 13 Then 'el 13 es la tecla enter
            SendKeys.Send("{Tab}")
        End If
    End Sub

    ''**--- Fin de tabulaciones en campo



    Private Sub mkPr_Enter(sender As Object, e As EventArgs) Handles mkPr.Enter
        ''**--- Establece el PromptChar cuando se posiciona en este masktextbox
        mkPr.PromptChar = "_"
        mkPr.Text = mkPr.Text.TrimStart()
    End Sub

    Private Sub mkPr_Leave(sender As Object, e As EventArgs) Handles mkPr.Leave
        ''**--- mueve el valor a la derecha 
        mkPr.Text = mkPr.Text.PadLeft(mkPr.Mask.Length)
        ''**--- los caracteres restantes los coloca como cero
        mkPr.PromptChar = "0"

        ''**--- Metodo que determina si el registro con la clave ingresada existe o no
        VerificaExistencia()
    End Sub








    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click


        Try

            ''**--- validamos los datos ingresados, en caso de que sean incorrectos no se podra avanzar
            If Not ValidaDatos() Then
                Return
            End If

            ''**--- Se instancia la clase General para utilizar sus metodos
            Dim GuardaRegistro As General = New General

            ''**--- Se obtiene la fecha de nacimiento ingresada por el usuario para guardarla en la base de datos
            Dim FechaNacimiento As String = Format(CDate(dtpFechaNac.Value), "yyyyMMdd")

            ''**--- Enviamos los parametros al metodo para registrar los datos con el store procedure que se creo
            ''**--- En este caso el tipo de accion es un INSERT
            Dim Resultado As String = GuardaRegistro.GuardaInformacion(mkPr.MaskedTextProvider.ToDisplayString(), txtApellidoP.Text, txtApellidoM.Text, txtNombre.Text, FechaNacimiento, "INSERT")

            ''**--- Muestra informacion de que el dato ha sido guardado
            If Resultado = "OK." Then
                MessageBox.Show("Dato guardado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Error!, no se pudo registrar el dato  " + Resultado, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If


            ''**--- Se limpian los campos para tenerlos listo para una nueva inserccion
            Limpiar()

        Catch ex As Exception
            MessageBox.Show("error al guardar la persona " & ex.Message)

        End Try


    End Sub


    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try

            ''**--- validamos los datos ingresados, en caso de que sean incorrectos no se podra avanzar
            If Not ValidaDatos() Then
                Return
            End If


            ''**--- Se instancia la clase para utilizar su metodo de registro
            Dim ActualizaReg As General = New General
            ''**--- Se obtiene la fecha en formato string
            Dim FechaNacimiento As String = Format(CDate(dtpFechaNac.Value), "yyyyMMdd")

            ''**--- Enviamos los parametros al metodo para registrar los datos con el store procedure que se creo
            ''**--- En este caso el tipo de accion es un UPDATED
            Dim Resultado As String = ActualizaReg.GuardaInformacion(mkPr.MaskedTextProvider.ToDisplayString(), txtApellidoP.Text, txtApellidoM.Text, txtNombre.Text, FechaNacimiento, "UPDATE")

            ''**--- Dependiendo de cual sea la respuesta nos mostrara el mensaje
            If Resultado = "OK." Then
                MessageBox.Show("Dato actualizado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Error!, no se pudo registrar el dato  " + Resultado, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If


            ''**--- Se limpian los datos para una nueva inserccion
            Limpiar()

        Catch ex As Exception
            MessageBox.Show("error al guardar la persona " & ex.Message)

        End Try


    End Sub



    ''**--- Metodo que se utliza para calcular la edad de la persona conforme se cambie de año

    Private Sub dtpFechaNac_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaNac.ValueChanged
        Dim FechaNacimiento As String = Format(CDate(dtpFechaNac.Value), "yyyy")
        Dim FechaHoy As String = Format(Now, "yyyy")

        Dim Edad As Integer = FechaHoy - FechaNacimiento
        ''**--- Se establece el texto en el label 
        lblEdad.Text = "Tiene " + Edad.ToString + " años de edad."

    End Sub










    ''**--- Metodo que limpia los campos 
    Private Sub Limpiar()
        'Me.mkPr.Mask = "99999999"
        ''**--- Establece el campo como vacio
        mkPr.Text = ""
        ''**--- Establece el PromptChar
        mkPr.PromptChar = "_"


        btnActualizar.Visible = False
        btnGuardar.Visible = True

        txtApellidoP.Text = ""
        txtApellidoM.Text = ""
        txtNombre.Text = ""
        dtpFechaNac.Value = Format(Now, "dd/MM/yyyy")


    End Sub


    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        ''**--- Metodo que carga los datos en el datagridview
        CargaDatos()
    End Sub





    Private Sub CargaDatos()
        Try

            ''**--- Limpia el datagridview en caso de que tenga registros 
            DataGridView1.Rows.Clear()

            ''**--- Establece el numero de columnas a utilizar
            DataGridView1.ColumnHeadersVisible = True
            DataGridView1.ColumnCount = 5

            ''**--- Define los nombres de las columnas
            DataGridView1.Columns(0).Name = "Id"
            DataGridView1.Columns(1).Name = "Nombre"
            DataGridView1.Columns(2).Name = "Apellido Paterno"
            DataGridView1.Columns(3).Name = "Apellido Materno"
            DataGridView1.Columns(4).Name = "Fecha de nacimiento"

            ''**--- Define el tamaño de las columnas
            DataGridView1.Columns(0).Width = 100
            DataGridView1.Columns(1).Width = 150
            DataGridView1.Columns(2).Width = 120
            DataGridView1.Columns(3).Width = 120
            DataGridView1.Columns(4).Width = 100

            ''**--- Define el tamaño de fuente de cada columna
            DataGridView1.Columns(0).DefaultCellStyle.Font = New Font("Segoe UI ", 11.0!, FontStyle.Regular)
            DataGridView1.Columns(1).DefaultCellStyle.Font = New Font("Segoe UI ", 11.0!, FontStyle.Regular)
            DataGridView1.Columns(2).DefaultCellStyle.Font = New Font("Segoe UI ", 11.0!, FontStyle.Regular)
            DataGridView1.Columns(3).DefaultCellStyle.Font = New Font("Segoe UI ", 11.0!, FontStyle.Regular)
            DataGridView1.Columns(4).DefaultCellStyle.Font = New Font("Segoe UI ", 11.0!, FontStyle.Regular)

            ''**--- Establece el formato para la fecha 
            DataGridView1.Columns(4).DefaultCellStyle.Format = "dd/MM/yyyy"


            DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Arial Narrow,", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte), FontStyle.Regular)

            ''**--- Define que columnas estaran visible para el usuario 
            DataGridView1.Columns(0).Visible = True '
            DataGridView1.Columns(1).Visible = True '
            DataGridView1.Columns(2).Visible = True '
            DataGridView1.Columns(3).Visible = True '
            DataGridView1.Columns(4).Visible = True '


            ''**--- Define si la columna es editable o no 
            Me.DataGridView1.Columns(0).ReadOnly = True
            Me.DataGridView1.Columns(1).ReadOnly = True
            Me.DataGridView1.Columns(2).ReadOnly = True
            Me.DataGridView1.Columns(3).ReadOnly = True
            Me.DataGridView1.Columns(4).ReadOnly = True

            ''**--- Se instancia la clase para obtener los registros
            Dim ObtenerRegistros As General = New General
            ''**--- Se realiza la consulta para obtener los registros
            Dim dtQuery As DataTable = ObtenerRegistros.SQLTable("select * from pr_Persona")

            ''**--- En caso de que existan registros va a limpiar el DataGridView
            If DataGridView1.Rows.Count > 0 Then
                DataGridView1.Rows.Clear()
            End If

            ''**--- En caso de que exitan datos los va a mostrar
            If dtQuery.Rows.Count > 0 Then

                ''**--- Iterando y agregando los registros al DataGridView
                For i As Integer = 0 To dtQuery.Rows.Count - 1
                    DataGridView1.Rows.Add(dtQuery.Rows(i)("per_id"), dtQuery.Rows(i)("per_nombre"), dtQuery.Rows(i)("per_apellidoPaterno"), dtQuery.Rows(i)("per_apellidoMaterno"), dtQuery.Rows(i)("per_fechaNacimiento"))
                Next

            Else
                DataGridView1.Rows.Clear()
            End If


        Catch ex As Exception
            MessageBox.Show("Error en al cargar datos " & ex.Message)
        End Try
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage


        ''**--- Definimos los tipos de letras a utilizar en el reporte
        Dim FuenteTitulo As New Font("Microsoft Sans Serif", 22)
        Dim FuenteSubtitulo As New Font("Microsoft Sans Serif", 16)
        Dim FuenteNegrita As New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        Dim FuenteDetalles As New Font("Microsoft Sans Serif", 12)

        ''**--- Si deseamos poner un contador de páginas
        ''**--- Esta parte siempre va a salir en todas las paginas
        Imprime.lbNumeroPagina.Text = CInt(Imprime.lbNumeroPagina.Text) + 1
        e.Graphics.DrawString(Imprime.LabelPagina.Text, FuenteDetalles, Brushes.Black, Imprime.LabelPagina.Left, e.MarginBounds.Bottom)
        e.Graphics.DrawString(Imprime.lbNumeroPagina.Text, FuenteDetalles, Brushes.Black, Imprime.lbNumeroPagina.Left, e.MarginBounds.Bottom)



        If CInt(Imprime.lbNumeroPagina.Text) <= 1 Then
            ''**--- Imprimimos el encabezado junto con el logo y los datosde la persona
            e.Graphics.DrawString(Imprime.LabelEmpresa.Text, FuenteTitulo, Brushes.Black, Imprime.LabelEmpresa.Left, Imprime.LabelEmpresa.Top)
            Dim newImage As Image = Imprime.PictureBox1.Image : e.Graphics.DrawImage(newImage, Imprime.PictureBox1.Left, Imprime.PictureBox1.Top, Imprime.PictureBox1.Width, Imprime.PictureBox1.Height)

            e.Graphics.DrawString(Imprime.lblFecha.Text, FuenteNegrita, Brushes.Black, Imprime.lblFecha.Left, Imprime.lblFecha.Top)
            e.Graphics.DrawString(Imprime.lbFecha.Text, FuenteDetalles, Brushes.Black, Imprime.lbFecha.Left, Imprime.lbFecha.Top)

            e.Graphics.DrawString(Imprime.lblNombre.Text, FuenteNegrita, Brushes.Black, Imprime.lblNombre.Left, Imprime.lblNombre.Top)
            e.Graphics.DrawString(Imprime.lbNombre.Text, FuenteDetalles, Brushes.Black, Imprime.lbNombre.Left, Imprime.lbNombre.Top)

            e.Graphics.DrawString(Imprime.lblClave.Text, FuenteNegrita, Brushes.Black, Imprime.lblClave.Left, Imprime.lblClave.Top)
            e.Graphics.DrawString(Imprime.lbClave.Text, FuenteDetalles, Brushes.Black, Imprime.lbClave.Left, Imprime.lbClave.Top)

            e.Graphics.DrawString(Imprime.lblEdadActual.Text, FuenteNegrita, Brushes.Black, Imprime.lblEdadActual.Left, Imprime.lblEdadActual.Top)
            e.Graphics.DrawString(Imprime.lblEdad.Text, FuenteDetalles, Brushes.Black, Imprime.lblEdad.Left, Imprime.lblEdad.Top)

        End If




    End Sub

    Private Sub LlenarConsulta()

        ''**--- Se obtiene la clave del registro seleccionado 
        Dim Clave As String = DataGridView1.CurrentRow.Cells(0).Value.ToString()

        ''**--- Se instancia la clase para usar su metod 
        Dim ObtenerReg As General = New General

        ''**--- Se hace la consulta para obtener los datos del registro 
        Dim dtQuery As DataTable = ObtenerReg.SQLTable("select per_id, per_nombre, per_apellidoPaterno, per_apellidoMaterno, per_fechaNacimiento FROM pr_Persona where per_id = '" & Clave & "' ")


        ''**--- Se calcula la edad 
        Dim FechaNacimiento As String = Format(CDate(dtQuery.Rows(0)("per_fechaNacimiento")), "yyyy")
        Dim fechaHoy As String = Format(Now, "yyyy")
        Dim Edad As Integer = fechaHoy - FechaNacimiento


        ''**--- Si existe el registro establecera lso datos en el form Imprime 
        If dtQuery.Rows.Count > 0 Then

            Imprime.lbNombre.Text = dtQuery.Rows(0)("per_nombre") + " " + dtQuery.Rows(0)("per_apellidoPaterno") + " " + dtQuery.Rows(0)("per_apellidoMaterno")
            Imprime.lbClave.Text = dtQuery.Rows(0)("per_id")
            Imprime.lbFecha.Text = dtQuery.Rows(0)("per_fechaNacimiento")
            Imprime.lblEdad.Text = Edad.ToString + " años de edad "

        Else
            DataGridView1.Rows.Clear()
        End If


    End Sub

    ''**--- Metodo del boton que manda a imprimir a la impresora 
    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        ''**--- Verifica que existan datos en el datagrid
        If Not DataGridView1.Rows.Count > 0 Then
            MessageBox.Show("No se han cargado los datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Imprime.lbNumeroPagina.Text = "0"

        ''**--- llena los datos en el form 
        LlenarConsulta()

        PrintDialog1.Document = PrintDocument1

        ''**--- Manda a imprimir y te deja elegir la impresora
        If PrintDialog1.ShowDialog = DialogResult.OK Then
            PrintDocument1.Print()
            MessageBox.Show("Se ha mando a imprimir el documento", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        ''**--- Imprime en la impresora por defecto
        ''**--- PrintDocument1.Print()


    End Sub

    ''**--- Metodo que visualiza el reporte a imprimir 
    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click

        ''**--- Verifica que existan datos en el datagrid
        If Not DataGridView1.Rows.Count > 0 Then
            MessageBox.Show("No se han cargado los datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Imprime.lbNumeroPagina.Text = "0"

        ''**--- llena los datos en el formulario
        LlenarConsulta()

        PrintDialog1.Document = PrintDocument1


        ''**--- Te deja ver un preview del reporte antes de imprimir
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.WindowState = FormWindowState.Maximized
        PrintPreviewDialog1.ShowDialog()


    End Sub

    Private Sub ConexionABaseDeDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConexionABaseDeDatosToolStripMenuItem.Click

    End Sub

    Private Sub ConexionABaseDeDatosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ConexionABaseDeDatosToolStripMenuItem1.Click
        ''**--- Abre la ventana para establecer la conexion a la base de datos
        Conexion.ShowDialog()
    End Sub

    Private Sub Registro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''**--- Si no existe un registro previo de la cadena de conexion abrira la ventana para realizar la conexion 
        If My.Settings.ConnectionString = "" Then
            MessageBox.Show("Configura la cadena de conexion antes de continuar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Conexion.ShowDialog()
            Me.Close()

        End If
    End Sub





    Private Sub VerificaExistencia()


        Try
            ''**--- Se obtiene la clave de la persona
            Dim Clave As String = mkPr.MaskedTextProvider.ToDisplayString()

            ''**--- Se instancia la clase y se obtiene los datos de la persona 
            Dim ObtenerReg As General = New General
            Dim dtQuery As DataTable = ObtenerReg.SQLTable("select per_id, per_nombre, per_apellidoPaterno, per_apellidoMaterno, per_fechaNacimiento FROM pr_Persona where per_id = '" & Clave & "' ")

            ''**--- En caso de que existe el registro los rellenara automaticamente con 
            ''**--- los datos de la base de datos
            If dtQuery.Rows.Count > 0 Then
                btnActualizar.Visible = True
                btnGuardar.Visible = False

                txtApellidoP.Text = dtQuery.Rows(0)("per_apellidoPaterno")
                txtApellidoM.Text = dtQuery.Rows(0)("per_apellidoMaterno")
                txtNombre.Text = dtQuery.Rows(0)("per_nombre")
                dtpFechaNac.Value = dtQuery.Rows(0)("per_fechaNacimiento")

                ''**--- En caso contrario establecera los valores por defecto
            Else
                btnActualizar.Visible = False
                btnGuardar.Visible = True

                txtApellidoP.Text = ""
                txtApellidoM.Text = ""
                txtNombre.Text = ""
                dtpFechaNac.Value = Format(Now, "dd/MM/yyyy")

            End If



        Catch ex As Exception
            MessageBox.Show("Error en al cargar datos " & ex.Message)
        End Try


    End Sub


    ''**--- Metodo que valida cada uno de los campos 
    Private Function ValidaDatos() As Boolean


        Dim FechaNacimiento As String = Format(CDate(dtpFechaNac.Value), "yyyy")
        Dim fechaHoy As String = Format(Now, "yyyy")


        Dim Edad As Integer = fechaHoy - FechaNacimiento


        ''MsgBox(mkPr.Text.Length)
        ''MsgBox(mkPr.Text.Trim)


        If mkPr.Text.Trim = "" Then
            MessageBox.Show("Se necesita registrar la clave de la persona", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            mkPr.Focus()
            Return False

        ElseIf (CInt(Int(mkPr.Text.Trim) = 0)) Or (CInt(Int(mkPr.Text.Trim) > 99999999)) Then
            MessageBox.Show("La clave es incorrecta, verificala nuevamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            mkPr.Focus()
            Return False

        ElseIf Not mkPr.Text.Length = 8 Then
            MessageBox.Show("Se necesita registrar los 8 digitos de la clave", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            mkPr.Focus()
            Return False

        ElseIf txtNombre.Text.Trim() = "" Then
                MessageBox.Show("Ingresa el nombre de la persona ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtNombre.Focus()
                Return False

            ElseIf txtApellidoP.Text.Trim() = "" Then
                MessageBox.Show("Ingresa el apellido paterno", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtApellidoP.Focus()
                Return False

            ElseIf txtApellidoM.Text.Trim() = "" Then
                MessageBox.Show("Ingresa el apellido materno", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtApellidoM.Focus()
                Return False

            ElseIf Edad < 18 Then
                MessageBox.Show("La persona debe ser mayor de edad ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpFechaNac.Focus()
            Return False


        End If

        Return True

    End Function

End Class
