﻿Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Text
Imports Newtonsoft.Json
Imports Gecko
Imports System.ComponentModel

Public Class Form1

	'Make Borderless Window moveable
	Const WM_NCHITTEST As Integer = &H84
	Const HTCLIENT As Integer = &H1
	Const HTCAPTION As Integer = &H2
	Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
		Select Case m.Msg
			Case WM_NCHITTEST
				MyBase.WndProc(m)
				If m.Result = HTCLIENT Then m.Result = HTCAPTION
			Case Else
				MyBase.WndProc(m)
		End Select
	End Sub

	'Client-ID of EVE-FastIntel
	Public client_id As String = "f04e3224872b4cc5a85747411c09127c"
	Public challenge As String = ""
	Public character_id As Integer
	Public failcount As Integer = 0

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Me.Close()
	End Sub

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		Process.Start("https://login.eveonline.com/v2/oauth/authorize?response_type=code&redirect_uri=eveauth-fastintel://callback&client_id=" & client_id & "&scope=esi-location.read_location.v1%20esi-location.read_ship_type.v1%20esi-location.read_online.v1%20esi-clones.read_implants.v1&code_challenge=" & challenge & "&code_challenge_method=S256&state=uniqueshit")
	End Sub

	Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		YASL.Initialize()
		challenge = YASL.codechallenge
	End Sub

	Public Sub ProcessCallback(ByVal auth As String)

		Dim uri As Uri = New Uri(auth)
		Dim authorizationcode As String = System.Web.HttpUtility.ParseQueryString(uri.Query).Get("code")

		YASL.Settings("https://login.eveonline.com/v2/oauth/token", client_id, authorizationcode, "login.eveonline.com")

		'long intervall first so the characterid is resolved
		RefreshLongIntervall()
		RefreshShortIntervall()

		'request on login
		Dim objCharacterInfo As JSON_charinfo = GetCharacterData(character_id)
		Dim characterName As String = objCharacterInfo.name
		Dim corporationID As Integer = objCharacterInfo.corporation_id
		Dim objCorporationInfo As JSON_corpinfo = GetCorporationInfo(corporationID)
		Dim corporationName As String = objCorporationInfo.name

		'Fill static Data
		lblCharname.Text = characterName
		lblCorporation.Text = corporationName
		picCharacter.Image = New Bitmap(RequestPortrait(character_id))

		Gecko.Xpcom.Initialize()
		GeckoWebBrowser1.Visible = True
		GeckoWebBrowser2.Visible = True
		Button3.Visible = True
		btnLayout.Visible = True
		SplitContainer1.Visible = True
		picCharacter.Visible = True

		Dim timerShortInt = New System.Timers.Timer(2000)
		AddHandler timerShortInt.Elapsed, AddressOf RefreshShortIntervall
		timerShortInt.AutoReset = True
		timerShortInt.Enabled = True

		Dim timerLongInt = New System.Timers.Timer(30000)
		AddHandler timerLongInt.Elapsed, AddressOf RefreshLongIntervall
		timerLongInt.AutoReset = True
		timerLongInt.Enabled = True
	End Sub

	Private Sub RefreshShortIntervall()
		'will get refreshed every 2 seconds
		Try
			Dim objLocationID As JSON_Location = GetLocationID(character_id)
			If objLocationID Is Nothing Then
				failcount += 1
				Exit Sub
			End If
			Dim locationID As Integer = objLocationID.solar_system_id
			Dim objSystemInfo As json_SystemInfo = GetSystemInformation(locationID)
			If objSystemInfo Is Nothing Then
				failcount += 1
				Exit Sub
			End If

			Dim systemname As String = objSystemInfo.name
			Dim syssecurity As Single = objSystemInfo.security_status

			If Not lblLocation.Text = systemname Then
				GeckoWebBrowser1.Navigate("https://zkillboard.com/system/" & locationID & "#killlist")
				GeckoWebBrowser2.Navigate("http://anoik.is/systems/" & systemname)
				lblLocation.Invoke(Sub() lblLocation.Text = systemname)
			End If

			Dim objShipType As JSON_shipType = GetShipInformation(character_id)
			If objShipType Is Nothing Then
				failcount += 1
				Exit Sub
			End If
			Dim ship_type_id As Integer = objShipType.ship_type_id

			Dim objItemType As JSON_typeid = GetItem(ship_type_id)
			If objItemType Is Nothing Then
				failcount += 1
				Exit Sub
			End If
			Dim ship_type_name As String = objItemType.name

			lblShip.Invoke(Sub() lblShip.Text = ship_type_name)

			lblSecurity.Invoke(Sub() lblSecurity.Text = CCP_Round_syssec(syssecurity))
			Select Case lblSecurity.Text
				Case "1.0"
					lblSecurity.Invoke(Sub() lblSecurity.ForeColor = System.Drawing.ColorTranslator.FromHtml("#2FEFEF"))
					lblSysArea.Invoke(Sub() lblSysArea.Text = "HighSec")
				Case "0.9"
					lblSecurity.Invoke(Sub() lblSecurity.ForeColor = System.Drawing.ColorTranslator.FromHtml("#48F0C0"))
					lblSysArea.Invoke(Sub() lblSysArea.Text = "HighSec")
				Case "0.8"
					lblSecurity.Invoke(Sub() lblSecurity.ForeColor = System.Drawing.ColorTranslator.FromHtml("#00EF47"))
					lblSysArea.Invoke(Sub() lblSysArea.Text = "HighSec")
				Case "0.7"
					lblSecurity.Invoke(Sub() lblSecurity.ForeColor = System.Drawing.ColorTranslator.FromHtml("#00F000"))
					lblSysArea.Invoke(Sub() lblSysArea.Text = "HighSec")
				Case "0.6"
					lblSecurity.Invoke(Sub() lblSecurity.ForeColor = System.Drawing.ColorTranslator.FromHtml("#8FEF2F"))
					lblSysArea.Invoke(Sub() lblSysArea.Text = "HighSec")
				Case "0.5"
					lblSecurity.Invoke(Sub() lblSecurity.ForeColor = System.Drawing.ColorTranslator.FromHtml("#EFEF00"))
					lblSysArea.Invoke(Sub() lblSysArea.Text = "HighSec")
				Case "0.4"
					lblSecurity.Invoke(Sub() lblSecurity.ForeColor = System.Drawing.ColorTranslator.FromHtml("#D77700"))
					lblSysArea.Invoke(Sub() lblSysArea.Text = "LowSec")
				Case "0.3"
					lblSecurity.Invoke(Sub() lblSecurity.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F06000"))
					lblSysArea.Invoke(Sub() lblSysArea.Text = "LowSec")
				Case "0.2"
					lblSecurity.Invoke(Sub() lblSecurity.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F04800"))
					lblSysArea.Invoke(Sub() lblSysArea.Text = "LowSec")
				Case "0.1"
					lblSecurity.Invoke(Sub() lblSecurity.ForeColor = System.Drawing.ColorTranslator.FromHtml("#D73000"))
					lblSysArea.Invoke(Sub() lblSysArea.Text = "LowSec")
				Case "-1.0"
					lblSecurity.Invoke(Sub() lblSecurity.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F00000"))
					lblSysArea.Invoke(Sub() lblSysArea.Text = "Wormhole")
				Case Else
					lblSecurity.Invoke(Sub() lblSecurity.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F00000"))
					lblSysArea.Invoke(Sub() lblSysArea.Text = "NullSec")
			End Select

		Catch ex As Exception
			failcount += 1
			If failcount = 6 Then
				MsgBox("Error getting data from server. Quitting... " & vbNewLine & ex.Message)
				Me.Close()
			End If
		End Try

	End Sub

	Private Function CCP_Round_syssec(ByVal syssec As Single) As String
		'if syssec is slighly above 0 we need to make it a 0.10 (with formating so return value is the same)
		If syssec > 0 And syssec < 0.05 Then
			Return FormatNumber(Math.Round(Math.Ceiling(0.05 * 10) / 10, 2), 1).Replace(",", ".")
		Else
			Return FormatNumber(Math.Round(syssec, 2), 1).Replace(",", ".")
		End If
	End Function

	Private Sub RefreshLongIntervall()
		Try
			'will get refreshed every 30 seconds
			Dim objLoggedInChar As JSON_loggedinchar = GetLoggedInChar()
			If objLoggedInChar Is Nothing Then
				failcount += 1
				Exit Sub
			End If
			character_id = objLoggedInChar.CharacterID

			Dim objServerstatus As JSON_Status = GetServerStatus()
			If objServerstatus Is Nothing Then
				failcount += 1
				Exit Sub
			End If
			Dim playercount As Integer = objServerstatus.players

			Dim objIsOnline As JSON_isOnline = GetIsOnline(character_id)
			If objIsOnline Is Nothing Then
				failcount += 1
				Exit Sub
			End If
			Dim isOnline As Boolean = objIsOnline.online

			Dim objImplants As Integer() = GetImplants(character_id)

			If objImplants.Length > 0 Then
				lblPod.Invoke(Sub() lblPod.ForeColor = Color.Red)
				lblPod.Invoke(Sub() lblPod.Text = "POD NOT EMPTY!")
			Else
				lblPod.Invoke(Sub() lblPod.Text = "No implants active")
			End If

			If isOnline = True Then
				lblOnline.Invoke(Sub() lblOnline.Text = "Currently ingame")
			Else
				lblOnline.Invoke(Sub() lblOnline.Text = "Currently logged out")
			End If
			Me.lblPlayers.Invoke(Sub() Me.lblPlayers.Text = playercount)
		Catch ex As Exception

		End Try
		failcount = 0
	End Sub

	Private Function RequestPortrait(ByVal ID) As System.IO.MemoryStream
		Dim webClient As New System.Net.WebClient
		Dim ImageInBytes() As Byte = webClient.DownloadData("http://image.eveonline.com/Character/" & ID & "_128.jpg")
		Dim ImageStream As New System.IO.MemoryStream(ImageInBytes)
		Return ImageStream
	End Function


	Private Function GetLoggedInChar() As JSON_loggedinchar
		Try
			Dim client As WebClient = New WebClient
			client.Headers("Authorization") = "Bearer " & YASL.access_token
			Dim result As String = client.DownloadString("https://esi.tech.ccp.is/verify/")
			Dim jsoninfo As JSON_loggedinchar = JsonConvert.DeserializeObject(Of JSON_loggedinchar)(result)

			Return jsoninfo
		Catch ex As Exception

		End Try
		Return Nothing

	End Function

	Private Function GetLocationID(ByVal characterid) As JSON_Location
		Try
			Dim client As WebClient = New WebClient
			client.Headers("Authorization") = "Bearer " & YASL.access_token
			Dim result As String = client.DownloadString("https://esi.evetech.net/latest/characters/" & characterid & "/location/?datasource=tranquility")
			Dim jsoninfo As JSON_Location = JsonConvert.DeserializeObject(Of JSON_Location)(result)

			Return jsoninfo
		Catch ex As Exception

		End Try
		Return Nothing

	End Function

	Private Function GetSystemInformation(ByVal SystemID) As json_SystemInfo
		Try
			Dim client As WebClient = New WebClient
			Dim result As String = client.DownloadString("https://esi.evetech.net/latest/universe/systems/" & SystemID & "/?datasource=tranquility&language=en-us")
			Dim jsoninfo As json_SystemInfo = JsonConvert.DeserializeObject(Of json_SystemInfo)(result)

			Return jsoninfo
		Catch ex As Exception

		End Try
		Return Nothing
	End Function

	Private Function GetIsOnline(ByVal characterid) As JSON_isOnline
		Try
			Dim client As WebClient = New WebClient
			client.Headers("Authorization") = "Bearer " & YASL.access_token
			Dim result As String = client.DownloadString("https://esi.evetech.net/latest/characters/" & characterid & "/online/?datasource=tranquility")
			Dim jsoninfo As JSON_isOnline = JsonConvert.DeserializeObject(Of JSON_isOnline)(result)

			Return jsoninfo
		Catch ex As Exception

		End Try
		Return Nothing

	End Function

	Private Function GetShipInformation(ByVal characterid) As JSON_shipType
		Try
			Dim client As WebClient = New WebClient
			client.Headers("Authorization") = "Bearer " & YASL.access_token
			Dim result As String = client.DownloadString("https://esi.evetech.net/latest/characters/" & characterid & "/ship/?datasource=tranquility")
			Dim jsoninfo As JSON_shipType = JsonConvert.DeserializeObject(Of JSON_shipType)(result)

			Return jsoninfo
		Catch ex As Exception

		End Try
		Return Nothing

	End Function

	Private Function GetImplants(ByVal characterid) As Integer()
		Try
			Dim client As WebClient = New WebClient
			client.Headers("Authorization") = "Bearer " & YASL.access_token
			Dim result As String = client.DownloadString("https://esi.evetech.net/latest/characters/" & characterid & "/implants/?datasource=tranquility")
			Dim jsoninfo As Integer() = JsonConvert.DeserializeObject(Of Integer())(result)

			Return jsoninfo
		Catch ex As Exception

		End Try
		Return Nothing

	End Function


	Private Function GetCharacterData(ByVal characterid) As JSON_charinfo
		Try
			Dim client As WebClient = New WebClient
			Dim result As String = client.DownloadString("https://esi.evetech.net/latest/characters/" & characterid & "/?datasource=tranquility")

			Dim jsoninfo As JSON_charinfo = JsonConvert.DeserializeObject(Of JSON_charinfo)(result)

			Return jsoninfo
		Catch ex As Exception

		End Try
		Return Nothing
	End Function

	Private Function GetItem(ByVal itemid) As JSON_typeid
		Try
			Dim client As WebClient = New WebClient
			Dim result As String = client.DownloadString("https://esi.evetech.net/latest/universe/types/" & itemid & "/?datasource=tranquility&language=en-us")

			Dim jsoninfo As JSON_typeid = JsonConvert.DeserializeObject(Of JSON_typeid)(result)

			Return jsoninfo
		Catch ex As Exception

		End Try
		Return Nothing
	End Function

	Private Function GetServerStatus()
		Try
			Dim client As WebClient = New WebClient
			Dim result As String = client.DownloadString("https://esi.evetech.net/latest/status/?datasource=tranquility")

			Dim jsoninfo As JSON_Status = JsonConvert.DeserializeObject(Of JSON_Status)(result)

			Return jsoninfo
		Catch ex As Exception

		End Try
		Return Nothing
	End Function



	Private Function GetCorporationInfo(ByVal corporationid)
		Try
			Dim client As WebClient = New WebClient
			Dim result As String = client.DownloadString("https://esi.evetech.net/latest/corporations/" & corporationid & "/?datasource=tranquility")

			Dim jsoninfo As JSON_corpinfo = JsonConvert.DeserializeObject(Of JSON_corpinfo)(result)

			Return jsoninfo
		Catch ex As Exception

		End Try
		Return Nothing
	End Function

	Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
		chkForeground.Checked = My.Settings.setting_foreground
		If My.Settings.setting_vertical = True Then
			btnLayout.Text = "Horizontal"
			SplitContainer1.Orientation = Orientation.Vertical
			SplitContainer1.SplitterDistance = SplitContainer1.Width / 2
		End If
	End Sub

	Private Sub chkForeground_CheckedChanged(sender As Object, e As EventArgs) Handles chkForeground.CheckedChanged
		If chkForeground.Checked = True Then
			My.Settings.setting_foreground = True
			Form1.ActiveForm.TopMost = True
		Else
			My.Settings.setting_foreground = False
			Form1.ActiveForm.TopMost = False
		End If
	End Sub

	Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
		GeckoWebBrowser1.Dispose()
		GeckoWebBrowser2.Dispose()
	End Sub

	Private Sub SplitContainer1_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel1.Paint

	End Sub

	Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
		If SplitContainer1.Orientation = Orientation.Horizontal Then
			SplitContainer1.SplitterDistance = SplitContainer1.Height / 2
		Else
			SplitContainer1.SplitterDistance = SplitContainer1.Width / 2
		End If
	End Sub

	Private Sub btnLayout_Click(sender As Object, e As EventArgs) Handles btnLayout.Click
		If SplitContainer1.Orientation = Orientation.Horizontal Then
			btnLayout.Text = "Horizontal"
			SplitContainer1.Orientation = Orientation.Vertical
			SplitContainer1.SplitterDistance = SplitContainer1.Width / 2
			My.Settings.setting_vertical = True
		Else
			btnLayout.Text = "Vertical"
			SplitContainer1.Orientation = Orientation.Horizontal
			SplitContainer1.SplitterDistance = SplitContainer1.Height / 2
			My.Settings.setting_vertical = False
		End If

	End Sub
End Class


Public Class JSON_loggedinchar
	Public Property CharacterID As String
	Public Property CharacterName As String
	Public Property ExpiresOn As String
	Public Property Scopes As String
	Public Property TokenType As String
	Public Property CharacterOwnerHash As String
End Class

Public Class JSON_charinfo
	Public Property alliance_id As Integer
	Public Property ancestry_id As Integer
	Public Property birthday As DateTime
	Public Property bloodline_id As Integer
	Public Property corporation_id As Integer
	Public Property description As String
	Public Property faction_id As Integer
	Public Property gender As String
	Public Property name As String
	Public Property race_id As Integer
	Public Property security_status As Single
End Class

Public Class JSON_corpinfo
	Public Property alliance_id As Integer
	Public Property ceo_id As Integer
	Public Property creator_id As Integer
	Public Property date_founded As DateTime
	Public Property description As String
	Public Property faction_id As Integer
	Public Property home_station_id As Integer
	Public Property member_count As Integer
	Public Property name As String
	Public Property shares As Integer
	Public Property tax_rate As Single
	Public Property ticket As String
	Public Property url As String
End Class

Public Class JSON_Status
	Public Property players As Integer
	Public Property server_version As String
	Public Property start_time As String
	Public Property vip As Boolean
End Class

Public Class JSON_Location
	Public Property solar_system_id As Integer
	Public Property station_id As Integer
	Public Property structure_id As Single
End Class

Public Class JSON_isOnline
	Public Property last_login As String
	Public Property last_logout As String
	Public Property logins As Integer
	Public Property online As Boolean
End Class

Public Class JSON_shipType
	Public Property ship_item_id As Int64
	Public Property ship_name As String
	Public Property ship_type_id As Integer
End Class

Public Class JSON_implants
	Public Property implants As Integer()
End Class

'Next three blocks for SystemInfo
Public Class Planet
	Public Property planet_id As Integer
	Public Property moons As Integer()
End Class
Public Class Position
	Public Property x As Single
	Public Property y As Single
	Public Property z As Single
End Class
Public Class json_SystemInfo
	Public Property constellation_id As Integer
	Public Property name As String
	Public Property planets As Planet()
	Public Property position As Position
	Public Property security_class As String
	Public Property security_status As Single
	Public Property star_id As Integer
	Public Property stargates As Integer()
	Public Property stations As Integer()
	Public Property system_id As Integer
End Class

'Next three blocks for Items
Public Class JSON_typeid
	Public Property capacity As Single
	Public Property description As String
	Public Property dogma_attributes As DogmaAttribute()
	Public Property dogma_effects As DogmaEffect()
	Public Property graphic_id As Integer
	Public Property group_id As Integer
	Public Property icon_id As Integer
	Public Property market_group_id As Integer
	Public Property mass As Single
	Public Property name As String
	Public Property packaged_volume As Single
	Public Property portion_size As Integer
	Public Property published As Boolean
	Public Property radius As Single
	Public Property type_id As Integer
	Public Property volume As Single
End Class
Public Class DogmaAttribute
	Public Property attribute_id As Integer
	Public Property value As Single
End Class
Public Class DogmaEffect
	Public Property effect_id As Integer
	Public Property is_default As Boolean
End Class

