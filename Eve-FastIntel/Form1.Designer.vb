<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
	Inherits System.Windows.Forms.Form

	'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

	'Wird vom Windows Form-Designer benötigt.
	Private components As System.ComponentModel.IContainer

	'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
	'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
	'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
		Me.Button1 = New System.Windows.Forms.Button()
		Me.Button2 = New System.Windows.Forms.Button()
		Me.timerRefresh = New System.Windows.Forms.Timer(Me.components)
		Me.timerSystemCheck = New System.Windows.Forms.Timer(Me.components)
		Me.lblCharname = New System.Windows.Forms.Label()
		Me.lblCorporation = New System.Windows.Forms.Label()
		Me.picCharacter = New System.Windows.Forms.PictureBox()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.lblOnline = New System.Windows.Forms.Label()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.lblSecurity = New System.Windows.Forms.Label()
		Me.lblPod = New System.Windows.Forms.Label()
		Me.lblShip = New System.Windows.Forms.Label()
		Me.lblLocation = New System.Windows.Forms.Label()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.lblOnlineCount = New System.Windows.Forms.Label()
		Me.lblPlayers = New System.Windows.Forms.Label()
		Me.GeckoWebBrowser1 = New Gecko.GeckoWebBrowser()
		Me.GeckoWebBrowser2 = New Gecko.GeckoWebBrowser()
		CType(Me.picCharacter, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox1.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		Me.GroupBox3.SuspendLayout()
		Me.SuspendLayout()
		'
		'Button1
		'
		Me.Button1.BackColor = System.Drawing.Color.Transparent
		Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
		Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.Button1.ForeColor = System.Drawing.Color.Transparent
		Me.Button1.Location = New System.Drawing.Point(846, 12)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(42, 42)
		Me.Button1.TabIndex = 1
		Me.Button1.UseVisualStyleBackColor = False
		'
		'Button2
		'
		Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
		Me.Button2.Location = New System.Drawing.Point(12, 23)
		Me.Button2.Name = "Button2"
		Me.Button2.Size = New System.Drawing.Size(270, 52)
		Me.Button2.TabIndex = 2
		Me.Button2.UseVisualStyleBackColor = True
		'
		'timerRefresh
		'
		Me.timerRefresh.Interval = 900000
		'
		'timerSystemCheck
		'
		Me.timerSystemCheck.Interval = 2000
		'
		'lblCharname
		'
		Me.lblCharname.AutoSize = True
		Me.lblCharname.Location = New System.Drawing.Point(6, 18)
		Me.lblCharname.Name = "lblCharname"
		Me.lblCharname.Size = New System.Drawing.Size(0, 13)
		Me.lblCharname.TabIndex = 3
		'
		'lblCorporation
		'
		Me.lblCorporation.AutoSize = True
		Me.lblCorporation.Location = New System.Drawing.Point(6, 37)
		Me.lblCorporation.Name = "lblCorporation"
		Me.lblCorporation.Size = New System.Drawing.Size(0, 13)
		Me.lblCorporation.TabIndex = 4
		'
		'picCharacter
		'
		Me.picCharacter.Location = New System.Drawing.Point(285, 5)
		Me.picCharacter.Name = "picCharacter"
		Me.picCharacter.Size = New System.Drawing.Size(84, 84)
		Me.picCharacter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.picCharacter.TabIndex = 5
		Me.picCharacter.TabStop = False
		'
		'GroupBox1
		'
		Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
		Me.GroupBox1.Controls.Add(Me.lblOnline)
		Me.GroupBox1.Controls.Add(Me.lblCharname)
		Me.GroupBox1.Controls.Add(Me.lblCorporation)
		Me.GroupBox1.Location = New System.Drawing.Point(375, 5)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(156, 78)
		Me.GroupBox1.TabIndex = 6
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "Character Info"
		'
		'lblOnline
		'
		Me.lblOnline.AutoSize = True
		Me.lblOnline.Location = New System.Drawing.Point(6, 57)
		Me.lblOnline.Name = "lblOnline"
		Me.lblOnline.Size = New System.Drawing.Size(0, 13)
		Me.lblOnline.TabIndex = 5
		'
		'GroupBox2
		'
		Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
		Me.GroupBox2.Controls.Add(Me.lblSecurity)
		Me.GroupBox2.Controls.Add(Me.lblPod)
		Me.GroupBox2.Controls.Add(Me.lblShip)
		Me.GroupBox2.Controls.Add(Me.lblLocation)
		Me.GroupBox2.Location = New System.Drawing.Point(537, 5)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(156, 78)
		Me.GroupBox2.TabIndex = 7
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "Activity"
		'
		'lblSecurity
		'
		Me.lblSecurity.AutoSize = True
		Me.lblSecurity.Location = New System.Drawing.Point(111, 37)
		Me.lblSecurity.Name = "lblSecurity"
		Me.lblSecurity.Size = New System.Drawing.Size(0, 13)
		Me.lblSecurity.TabIndex = 6
		'
		'lblPod
		'
		Me.lblPod.AutoSize = True
		Me.lblPod.Location = New System.Drawing.Point(6, 57)
		Me.lblPod.Name = "lblPod"
		Me.lblPod.Size = New System.Drawing.Size(0, 13)
		Me.lblPod.TabIndex = 5
		'
		'lblShip
		'
		Me.lblShip.AutoSize = True
		Me.lblShip.Location = New System.Drawing.Point(6, 18)
		Me.lblShip.Name = "lblShip"
		Me.lblShip.Size = New System.Drawing.Size(0, 13)
		Me.lblShip.TabIndex = 3
		'
		'lblLocation
		'
		Me.lblLocation.AutoSize = True
		Me.lblLocation.Location = New System.Drawing.Point(6, 37)
		Me.lblLocation.Name = "lblLocation"
		Me.lblLocation.Size = New System.Drawing.Size(0, 13)
		Me.lblLocation.TabIndex = 4
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.lblOnlineCount)
		Me.GroupBox3.Controls.Add(Me.lblPlayers)
		Me.GroupBox3.Location = New System.Drawing.Point(699, 5)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(141, 78)
		Me.GroupBox3.TabIndex = 8
		Me.GroupBox3.TabStop = False
		Me.GroupBox3.Text = "Server Info"
		'
		'lblOnlineCount
		'
		Me.lblOnlineCount.AutoSize = True
		Me.lblOnlineCount.Location = New System.Drawing.Point(6, 18)
		Me.lblOnlineCount.Name = "lblOnlineCount"
		Me.lblOnlineCount.Size = New System.Drawing.Size(80, 13)
		Me.lblOnlineCount.TabIndex = 7
		Me.lblOnlineCount.Text = "Online Players: "
		'
		'lblPlayers
		'
		Me.lblPlayers.AutoSize = True
		Me.lblPlayers.Location = New System.Drawing.Point(87, 18)
		Me.lblPlayers.Name = "lblPlayers"
		Me.lblPlayers.Size = New System.Drawing.Size(0, 13)
		Me.lblPlayers.TabIndex = 6
		'
		'GeckoWebBrowser1
		'
		Me.GeckoWebBrowser1.FrameEventsPropagateToMainWindow = False
		Me.GeckoWebBrowser1.Location = New System.Drawing.Point(12, 95)
		Me.GeckoWebBrowser1.Name = "GeckoWebBrowser1"
		Me.GeckoWebBrowser1.Size = New System.Drawing.Size(876, 481)
		Me.GeckoWebBrowser1.TabIndex = 9
		Me.GeckoWebBrowser1.UseHttpActivityObserver = False
		'
		'GeckoWebBrowser2
		'
		Me.GeckoWebBrowser2.FrameEventsPropagateToMainWindow = False
		Me.GeckoWebBrowser2.Location = New System.Drawing.Point(12, 582)
		Me.GeckoWebBrowser2.Name = "GeckoWebBrowser2"
		Me.GeckoWebBrowser2.Size = New System.Drawing.Size(876, 481)
		Me.GeckoWebBrowser2.TabIndex = 10
		Me.GeckoWebBrowser2.UseHttpActivityObserver = False
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.LightSteelBlue
		Me.ClientSize = New System.Drawing.Size(900, 1080)
		Me.Controls.Add(Me.GeckoWebBrowser2)
		Me.Controls.Add(Me.GeckoWebBrowser1)
		Me.Controls.Add(Me.GroupBox3)
		Me.Controls.Add(Me.GroupBox2)
		Me.Controls.Add(Me.picCharacter)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.Button2)
		Me.Controls.Add(Me.Button1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "Form1"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "EvE - Fast-Intel Tool"
		CType(Me.picCharacter, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox2.PerformLayout()
		Me.GroupBox3.ResumeLayout(False)
		Me.GroupBox3.PerformLayout()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents Button1 As Button
	Friend WithEvents Button2 As Button
	Friend WithEvents timerRefresh As Timer
	Friend WithEvents timerSystemCheck As Timer
	Friend WithEvents lblCharname As Label
	Friend WithEvents lblCorporation As Label
	Friend WithEvents picCharacter As PictureBox
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents lblOnline As Label
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents lblPod As Label
	Friend WithEvents lblShip As Label
	Friend WithEvents lblLocation As Label
	Friend WithEvents GroupBox3 As GroupBox
	Friend WithEvents lblPlayers As Label
	Friend WithEvents lblOnlineCount As Label
	Friend WithEvents lblSecurity As Label
	Friend WithEvents GeckoWebBrowser1 As Gecko.GeckoWebBrowser
	Friend WithEvents GeckoWebBrowser2 As Gecko.GeckoWebBrowser
End Class
