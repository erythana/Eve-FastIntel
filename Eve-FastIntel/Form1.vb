Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Text
Imports Newtonsoft.Json


Public Class Form1
	'Client-ID of EVE-FastIntel
	Public client_id As String = "f04e3224872b4cc5a85747411c09127c"
	Public challenge As String = ""
	Public verifier As String = ""
	Public access_token As String = ""
	Public refresh_token As String = ""

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Me.Close()

	End Sub

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		Process.Start("https://login.eveonline.com/v2/oauth/authorize?response_type=code&redirect_uri=eveauth-fastintel://callback&client_id=" & client_id & "&scope=esi-location.read_location.v1&code_challenge=" & challenge & "&code_challenge_method=S256&state=uniqueshit")
	End Sub

	Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		CreatePKCE()


	End Sub

	Private Sub CreatePKCE()
		Dim buffer = New Byte(32) {}
		Dim rng = New RNGCryptoServiceProvider()
		rng.GetBytes(buffer)
		verifier = Convert.ToBase64String(buffer).Replace("=", "").Replace("+", "-").Replace("/", "_")

		Dim sha = New SHA256Managed()
		sha.ComputeHash(Encoding.UTF8.GetBytes(verifier))
		challenge = Convert.ToBase64String(sha.Hash).Replace("=", "").Replace("+", "-").Replace("/", "_")
	End Sub

	Public Sub ProcessCallback(ByVal auth As String)

		Dim uri As Uri = New Uri(auth)
		Dim authorizationcode As String = System.Web.HttpUtility.ParseQueryString(uri.Query).Get("code")

		Try
			Dim request As WebRequest = WebRequest.Create("https://login.eveonline.com/v2/oauth/token")
			request.Method = "POST"
			Dim postdata As String = "grant_type=authorization_code" & "&code=" & authorizationcode & "&client_id=" & client_id & "&code_verifier=" & verifier
			Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postdata)
			request.ContentType = "application/x-www-form-urlencoded"
			request.ContentLength = byteArray.Length
			Dim datastream As IO.Stream = request.GetRequestStream
			datastream.Write(byteArray, 0, byteArray.Length)
			datastream.Close()
			Dim response As WebResponse = request.GetResponse
			If Not response Is Nothing Then
				Dim pagecontent As String = New StreamReader(response.GetResponseStream()).ReadToEnd
				Dim jsonresult As JSON_result = JsonConvert.DeserializeObject(Of JSON_result)(pagecontent)
				access_token = jsonresult.access_token
				refresh_token = jsonresult.refresh_token
			Else
				access_token = ""
				refresh_token = ""
				CreatePKCE()
				timerRefresh.Enabled = False
			End If

		Catch ex As WebException
			Dim pagecontent = New StreamReader(ex.Response.GetResponseStream()).ReadToEnd
			MsgBox(pagecontent)
		End Try
		timerRefresh.Enabled = True

		Dim character As Integer = GetCharacterID()

	End Sub

	Private Sub GetRefreshToken()
		Try
			Dim request As WebRequest = WebRequest.Create("https://login.eveonline.com/v2/oauth/token")
			request.Method = "POST"
			Dim postdata As String = "grant_type=refresh_token" & "&refresh_token=" & refresh_token
			Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postdata)
			request.ContentType = "application/x-www-form-urlencoded"
			request.ContentLength = byteArray.Length
			Dim datastream As IO.Stream = request.GetRequestStream
			datastream.Write(byteArray, 0, byteArray.Length)
			datastream.Close()
			Dim response As WebResponse = request.GetResponse
			If Not response Is Nothing Then
				Dim pagecontent As String = New StreamReader(response.GetResponseStream()).ReadToEnd
				Dim jsonresult As JSON_result = JsonConvert.DeserializeObject(Of JSON_result)(pagecontent)
				access_token = jsonresult.access_token
				refresh_token = jsonresult.refresh_token
			Else
				access_token = ""
				refresh_token = ""
				CreatePKCE()
				timerRefresh.Enabled = False
			End If

		Catch ex As WebException
			Dim pagecontent = New StreamReader(ex.Response.GetResponseStream()).ReadToEnd
			MsgBox(pagecontent)
		End Try

	End Sub

	Private Sub timerRefresh_Tick(sender As Object, e As EventArgs) Handles timerRefresh.Tick
		GetRefreshToken()

	End Sub

	Private Function GetCharacterID()
		Try
			Dim client As WebClient = New WebClient
			client.Headers("Authorization") = "Bearer " & access_token
			Dim result As String = client.DownloadString("https://esi.tech.ccp.is/verify/")
			Dim jsoninfo As JSON_charinfo = JsonConvert.DeserializeObject(Of JSON_charinfo)(result)

			Return jsoninfo.CharacterID
		Catch ex As Exception

		End Try
		Return Nothing

	End Function

	Private Function GetCharacterLocation()
		'Todo

	End Function

End Class

Public Class JSON_result
	Public Property access_token As String
	Public Property expires_in As Integer
	Public Property token_type As String
	Public Property refresh_token As String
End Class

Public Class JSON_charinfo
	Public Property CharacterID As String
	Public Property CharacterName As String
	Public Property ExpiresOn As String
	Public Property Scopes As String
	Public Property TokenType As String
	Public Property CharacterOwnerHash As String
End Class
