
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace GDrive.Framework
    Friend Class FileMimeTypes
        Friend Shared FolderMimeType As String = "application/vnd.google-apps.folder"

        'Tagged Image File Format (.TIFF)
        'Scalable Vector Graphics (.SVG)
        'PostScript (.EPS, .PS)
        'TrueType (.TTF)
        'XML Paper Specification (.XPS)
        Private dictionary As IDictionary(Of String, String) = New Dictionary(Of String, String)() From {
            {"pdf", "application/pdf"},
            {"txt", "text/plain"},
            {"doc", "application/doc"},
            {"docx", "application/docx"},
            {"xls", "application/xls"},
            {"xlsx", "application/xlsx"},
            {"ppt", "application/ppt"},
            {"pptx", "application/pptx"}
        }

        Default Friend ReadOnly Property Item(extension As String) As String
            Get
                Return If(dictionary.ContainsKey(extension), dictionary(extension), Nothing)
            End Get
        End Property
    End Class
End Namespace


