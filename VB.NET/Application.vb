Imports System.IO
Imports System.Collections
Imports System.Globalization
Imports System.Windows.Forms
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization

'
'
'	Sources are under Licence LGPL
'
'	Made by Delfosse Jérôme for test purposee. dje@perso.be
'	18/02/11


Public Class Application

	Function getSHA1Hash(ByVal strToHash As String) As String
	    Dim sha1Obj As New Security.Cryptography.SHA1CryptoServiceProvider
	    Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)
	
	    bytesToHash = sha1Obj.ComputeHash(bytesToHash)
	
	    Dim strResult As String = ""
	
	    For Each b As Byte In bytesToHash
	        strResult += b.ToString("x2")
	    Next
	
	    Return strResult
	End Function

' ***********************************************************************************************************
' ***********************************************************************************************************
	Public Shared Sub Main()
		dim app as Application=new Application()
		dim a,b,c,d,e,f as integer
		Dim fileOutput As FileStream
		Dim binaryOutput As BinaryWriter
		Dim fileName As String = "VBNET.txt"
		Dim strbla As String = "CeciestText"
		Dim strToHash As String = "CeciestTextBBBBBB"
		Dim sha1Obj As New Security.Cryptography.SHA1CryptoServiceProvider
	    Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)
	    
		d=65
		e=65
		f=65

		dim oldDate as DateTime  = DateTime.Now

		Try
            fileOutput = New FileStream(fileName,FileMode.Create, FileAccess.Write)
            'fileOutput.SetLength(26^3*(strToHash.Length()+22))
            binaryOutput = New BinaryWriter(fileOutput)

			for a=65 to 90
				for b=65 to 90
					for c=65 to 90
					for d=65 to 90
					for e=65 to 90
	'				for f=65 to 90
					strToHash=strbla+chr(a)+chr(b)+chr(c)+chr(d)+chr(e)+chr(f)
					bytesToHash = System.Text.Encoding.ASCII.GetBytes(strToHash)
					bytesToHash = sha1Obj.ComputeHash(bytesToHash)
					strToHash=strToHash+" "
					'Console.WriteLine(BitConverter.ToString(System.Text.Encoding.ASCII.GetBytes(strToHash)))
					'Console.WriteLine(strToHash)
					binaryOutput.Write(System.Text.Encoding.ASCII.GetBytes(strToHash))
					binaryOutput.Write(bytesToHash)
					binaryOutput.Write(ControlChars.Cr)
					
	'				next f
					next e
					next d
					next c
				next b
			next a
               
			' close FileStream
			If (fileOutput Is Nothing) <> False Then
			 fileOutput.Close()
			End If
			
			' close BinaryWriter
			If (binaryOutput Is Nothing) <> False Then
			 binaryOutput.Close()
			End If
            Console.WriteLine("File Created")
		Catch fileException As IOException
			Console.WriteLine("Cannot write to file")
		End Try
		
		dim newDate as DateTime  = DateTime.Now
		dim ts as TimeSpan = newDate - oldDate
		System.Console.WriteLine("Time: "+ts.ToString)

	End Sub
	
End Class

