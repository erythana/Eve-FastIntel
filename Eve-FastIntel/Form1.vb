Imports Microsoft.Extensions.Options
Imports ESI.NET
Imports ESI.NET.Enumerations
Imports ESI.NET.Models.SSO

Public Class Form1
	Public client As EsiClient
	Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs)

	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Me.Close()

	End Sub

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		Dim url As String = client.SSO.CreateAuthenticationUrl()
		Process.Start(url)
	End Sub

	Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Dim config As IOptions(Of EsiConfig) = Options.Create(New EsiConfig() With {
		.EsiUrl = "https://esi.tech.ccp.is/",
		.DataSource = DataSource.Tranquility,
		.ClientId = "abc",
		.SecretKey = "abc",
		.CallbackUrl = "eveauth-fastintel://callback",
		.UserAgent = "EVE-FastIntel"
	})

		client = New EsiClient(config)



		'Dim token As SsoToken = client.SSO.GetToken(GrantType.AuthorizationCode, )
		'Dim auth_char As AuthorizedCharacterData = client.SSO.Verify(token)
	End Sub

	Public Sub ProcessCallback(ByVal s)
		MsgBox(s)
	End Sub


End Class
