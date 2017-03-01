
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Google.Apis.Drive.v2.Data

Namespace GDrive.Framework
    Public Class GDriveFile
        Friend Sub New(file As File, Optional isTrash As Boolean = False)
            Id = file.Id
            FileName = file.OriginalFilename
            Dim size__1 As Long = -1
            Size = If(file.FileSize IsNot Nothing AndAlso Long.TryParse(file.FileSize, size__1), size__1, -1)
            Title = file.Title
            Description = file.Description
            CreatedDate = file.CreatedDate
            ModifiedDate = If(file.ModifiedDate, file.CreatedDate)
            DownloadUrl = file.DownloadUrl
            ThumbnailUrl = file.ThumbnailLink

            FileType = If(file.MimeType.Equals(FileMimeTypes.FolderMimeType), "folder", If(file.FileExtension, file.MimeType))
            IsTrashed = isTrash
        End Sub

        Public Sub New()
            Id = String.Empty
            FileName = String.Empty
            Size = 0
            Title = String.Empty
            Description = String.Empty
            CreatedDate = String.Empty
            ModifiedDate = String.Empty

            FileType = "folder"
        End Sub

        Public Property FileName() As String
            Get
                Return m_FileName
            End Get
            Private Set
                m_FileName = Value
            End Set
        End Property
        Private m_FileName As String
        Public Property DownloadUrl() As String
            Get
                Return m_DownloadUrl
            End Get
            Private Set
                m_DownloadUrl = Value
            End Set
        End Property
        Private m_DownloadUrl As String
        Public Property ThumbnailUrl() As String
            Get
                Return m_ThumbnailUrl
            End Get
            Private Set
                m_ThumbnailUrl = Value
            End Set
        End Property
        Private m_ThumbnailUrl As String
        Public Property Size() As Long
            Get
                Return m_Size
            End Get
            Private Set
                m_Size = Value
            End Set
        End Property
        Private m_Size As Long
        Public Property Id() As String
            Get
                Return m_Id
            End Get
            Private Set
                m_Id = Value
            End Set
        End Property
        Private m_Id As String
        Public Property Title() As String
            Get
                Return m_Title
            End Get
            Set
                m_Title = Value
            End Set
        End Property
        Private m_Title As String
        Public Property Description() As String
            Get
                Return m_Description
            End Get
            Private Set
                m_Description = Value
            End Set
        End Property
        Private m_Description As String
        Public Property CreatedDate() As String
            Get
                Return m_CreatedDate
            End Get
            Private Set
                m_CreatedDate = Value
            End Set
        End Property
        Private m_CreatedDate As String
        Public Property ModifiedDate() As String
            Get
                Return m_ModifiedDate
            End Get
            Private Set
                m_ModifiedDate = Value
            End Set
        End Property
        Private m_ModifiedDate As String
        Public Property FileType() As String
            Get
                Return m_FileType
            End Get
            Private Set
                m_FileType = Value
            End Set
        End Property
        Private m_FileType As String
        Public Property IsTrashed() As Boolean
            Get
                Return m_IsTrashed
            End Get
            Private Set
                m_IsTrashed = Value
            End Set
        End Property
        Private m_IsTrashed As Boolean
    End Class

    Public Class GDriveFilesResponse
        Friend Sub New(files__1 As IEnumerable(Of GDriveFile), pagetoken As String)
            Files = files__1
            NextPageToken = pagetoken
        End Sub

        Public Property Files() As IEnumerable(Of GDriveFile)
            Get
                Return m_Files
            End Get
            Private Set
                m_Files = Value
            End Set
        End Property
        Private m_Files As IEnumerable(Of GDriveFile)
        Public Property NextPageToken() As String
            Get
                Return m_NextPageToken
            End Get
            Private Set
                m_NextPageToken = Value
            End Set
        End Property
        Private m_NextPageToken As String
    End Class

    Public Enum SortOrder
        TitleAsc
        TitleDesc
        LastModifiedAsc
        LastModifiedDesc
    End Enum
End Namespace


