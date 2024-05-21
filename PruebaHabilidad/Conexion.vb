Public Class Conexion
    ''**--- se obtiene la cadena de conexion 
    Public CadenaConexion As String = My.Settings.ConnectionString
    Public ConexionExitosa As Boolean = False

    ''**--- Al cargar verifica si existen variables guardadas dentro de la aplicaicion 
    ''**--- En caso de que si existan los establece en los textbox
    Private Sub Conexion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtServidor.Text = My.Settings.Servidor
        txtPuerto.Text = My.Settings.Puerto
        txtBaseDatos.Text = My.Settings.BaseDatos
        txtUser.Text = My.Settings.User
        txtPassword.Text = My.Settings.password
        txtEmpresa.Text = My.Settings.Empresa
        rtbCadena.Text = My.Settings.ConnectionString
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ''**--- Si la conexion a la base de datos fue exitosa establecemos los datos 
        ''**--- a guardar dentro de la aplicacion 
        If ConexionExitosa Then
            My.Settings.ConnectionString = CadenaConexion
            My.Settings.Empresa = txtEmpresa.Text

            My.Settings.Servidor = txtServidor.Text
            My.Settings.Puerto = txtPuerto.Text
            My.Settings.BaseDatos = txtBaseDatos.Text
            My.Settings.User = txtUser.Text
            My.Settings.password = txtPassword.Text

            MessageBox.Show("Datos Guardados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)


            Me.Close()

        Else
            MessageBox.Show("Verifica la conexion para continuar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnProbar_Click(sender As Object, e As EventArgs) Handles btnProbar.Click
        ''**--- Metodo para verificar  que si exista conexion a la base de datos
        VerificaConexion()
    End Sub

    ''**--- Genera la cadena de conexion que se utilizar para pribar la conexion
    ''**--- y la establece en el richTextBox
    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        CadenaConexion = "Data Source=TCP:" + txtServidor.Text + ", " + txtPuerto.Text + "; " &
            "Initial Catalog = " + txtBaseDatos.Text + "; " &
            "Persist Security Info = True; " &
            "User ID=" + txtUser.Text + "; " &
            "Password=" + txtPassword.Text + ""

        rtbCadena.Text = CadenaConexion
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Me.Close()
    End Sub

    ''**--- Metodo que nos permite verificar que si exista conexion a la base de datos
    Private Sub VerificaConexion()
        Try
            If CadenaConexion <> "" Then

                Dim cnn As General = New General


                ''**-- En caso de que la cadena de conexion sea correcta 
                ''***-- cambiara la variable de conexion extosa a true y se hablita el boton de guardar
                If cnn.VerificaConexion(CadenaConexion) = "Ok." Then

                    '' MsgBox("SI")
                    MessageBox.Show(cnn.VerificaConexion(CadenaConexion))

                    ConexionExitosa = True
                    btnGuardar.Enabled = True

                    ''**--- En caso contrario deshabilitara el boton de guardar y 
                    ''**--- la variable conexionExitosa quedara en false
                Else
                    ''MsgBox("NO")
                    MessageBox.Show(cnn.VerificaConexion(CadenaConexion))
                    btnGuardar.Enabled = False
                    ConexionExitosa = False

                End If


            Else
                MessageBox.Show("Genera la cadena de conexion", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            ' MessageBox.Show("Conexion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
            MessageBox.Show("Error- " & ex.ToString)
        End Try
    End Sub




End Class