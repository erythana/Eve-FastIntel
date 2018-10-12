Namespace My
	' Für MyApplication sind folgende Ereignisse verfügbar:
	' Startup: Wird beim Starten der Anwendung noch vor dem Erstellen des Startformulars ausgelöst.
	' Shutdown: Wird nach dem Schließen aller Anwendungsformulare ausgelöst.  Dieses Ereignis wird nicht ausgelöst, wenn die Anwendung mit einem Fehler beendet wird.
	' UnhandledException: Wird bei einem Ausnahmefehler ausgelöst.
	' StartupNextInstance: Wird beim Starten einer Einzelinstanzanwendung ausgelöst, wenn die Anwendung bereits aktiv ist. 
	' NetworkAvailabilityChanged: Wird beim Herstellen oder Trennen der Netzwerkverbindung ausgelöst.
	Partial Friend Class MyApplication
		Private Sub MyApplication_StartupNextInstance(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance

			If TypeOf Me.MainForm Is Form1 Then
				Dim s As String = ""
				If e.CommandLine.Count > 0 Then
					s = e.CommandLine.Item(0).ToString()
				End If
				DirectCast(Me.MainForm, Form1).ProcessCallback(s)
			End If
		End Sub
	End Class
End Namespace

