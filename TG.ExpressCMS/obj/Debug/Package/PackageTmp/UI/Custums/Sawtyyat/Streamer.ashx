<%@ WebHandler Language="VB" Class="Streamer" %>

'Streaming MP3 Sample
'Ben Yanis, http://www.barnyardbbs.com
'Creative Commons 


Imports System
Imports System.Web

Public Class Streamer : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        'You could easily make this dymanic
        'For example, you could pass parameters in the the querystring        
        Dim FileName As String = context.Server.MapPath("StreamSample.mp3")

        'Set the content type, we're gonna send mp3 data
        context.Response.ContentType = "audio/mpeg"
        
        'Name the stream
        context.Response.AppendHeader("icy-name", "Your Name Here")
        'Give your url
        context.Response.AppendHeader("icy-url", "www.yoursite.com")
        'Note: I often read the ID3's from the file directly.  I use some code written by Kevin Pisarsky (www.pisarsky.com)
        'I left it out of this version for simplicity.
        
        
        'At this point, you might wonder why we don't just use the WriteFile or TransmitFile method...
        
        'These will *work*, however, they also will send the Content-Length HTTP header.  This makes it work
        'more like a download, and less like a stream.
        
        'Although you are using a file as your source, this
        'is a real "stream" of data.  This is important, as Windows Media Player cannot save a stream, but
        'it can easily save a download.  If you want to prevent easy saving and downloading, the streaming
        'method is required.  If you don't care, you probably don't need this script anyway.
        
        
        'Don't buffer the output; send it as it goes
        context.Response.Buffer = False
            
        Const ChunkSize As Integer = 10000
        Dim iStream As System.IO.Stream = Nothing
        Dim Buffer(ChunkSize) As Byte
        Dim CurrentLength As Integer
        Dim DataToRead As Long

        Try

            'Open the file.
            iStream = New System.IO.FileStream(FileName, System.IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)

            'Total bytes to read
            DataToRead = iStream.Length

            'Read the bytes, send chunks at a time
            While DataToRead > 0

                'Verify that the client is connected.
                If context.Response.IsClientConnected Then

                    'Read the data in Buffer
                    CurrentLength = iStream.Read(Buffer, 0, ChunkSize)

                    'Write the data to the current output stream.
                    context.Response.OutputStream.Write(Buffer, 0, CurrentLength)
                    
                    'We're not buffering output; if we were, we would flush here.

                    ReDim Buffer(ChunkSize) ' Clear the Buffer
                    DataToRead = DataToRead - CurrentLength

                Else

                    'Prevent infinite loop if user disconnects
                    DataToRead = -1

                End If

            End While

        Catch ex As Exception

            'Log your errors, if you're keeping score

        Finally

            If IsNothing(iStream) = False Then
                'Close the file stream
                iStream.Close()
            End If

        End Try
        
    End Sub
    
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class