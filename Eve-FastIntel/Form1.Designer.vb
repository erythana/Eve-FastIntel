<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
	Inherits System.Windows.Forms.Form

	'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

	'Wird vom Windows Form-Designer benötigt.
	Private components As System.ComponentModel.IContainer

	'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
	'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
	'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
		Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.Button2 = New System.Windows.Forms.Button()
		Me.timerRefresh = New System.Windows.Forms.Timer(Me.components)
		Me.timerSystemCheck = New System.Windows.Forms.Timer(Me.components)
		Me.SuspendLayout()
		'
		'WebBrowser1
		'
		Me.WebBrowser1.Location = New System.Drawing.Point(12, 76)
		Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
		Me.WebBrowser1.Name = "WebBrowser1"
		Me.WebBrowser1.Size = New System.Drawing.Size(864, 947)
		Me.WebBrowser1.TabIndex = 0
		'
		'Button1
		'
		Me.Button1.BackColor = System.Drawing.Color.Transparent
		Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
		Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.Button1.ForeColor = System.Drawing.Color.Transparent
		Me.Button1.Location = New System.Drawing.Point(838, 3)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(47, 52)
		Me.Button1.TabIndex = 1
		Me.Button1.UseVisualStyleBackColor = False
		'
		'Button2
		'
		Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
		Me.Button2.Location = New System.Drawing.Point(12, 3)
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
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(888, 1044)
		Me.Controls.Add(Me.Button2)
		Me.Controls.Add(Me.Button1)
		Me.Controls.Add(Me.WebBrowser1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "Form1"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "EvE - Fast-Intel Tool"
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents WebBrowser1 As WebBrowser
	Friend WithEvents Button1 As Button
	Friend WithEvents Button2 As Button
	Friend WithEvents timerRefresh As Timer
	Friend WithEvents timerSystemCheck As Timer
End Class
