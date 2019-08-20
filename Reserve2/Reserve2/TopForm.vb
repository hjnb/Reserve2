Public Class TopForm

    'データベースのパス
    Public dbFilePath As String = My.Application.Info.DirectoryPath & "\Reserve.mdb"
    Public DB_Reserve As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbFilePath

    'エクセルのパス
    Public excelFilePass As String = My.Application.Info.DirectoryPath & "\Reserve.xls"

    '.iniファイルのパス
    Public iniFilePath As String = My.Application.Info.DirectoryPath & "\Reserve.ini"

    '画像パス
    'Public imageFilePath As String = My.Application.Info.DirectoryPath & "\Reserve.PNG"

    'Diagnoseのデータベースパス
    Public dbDiagnoseFilePath As String = Util.getIniString("System", "DiagnoseDir", iniFilePath) & "\Diagnose.mdb"
    Public DB_Diagnose As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbDiagnoseFilePath

    'Health3のデータベースパス
    Public dbHealth3FilePath As String = Util.getIniString("System", "HealthDir", iniFilePath) & "\Health3.mdb"
    Public DB_Health3 As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbHealth3FilePath

    Private reserveForm As 予約データ
    Private searchForm As 検索
    Private sankenForm As 産健センター扱い

    ''' <summary>
    ''' loadイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TopForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'データベース、エクセル、構成ファイルの存在チェック
        If Not System.IO.File.Exists(iniFilePath) Then
            MsgBox("構成ファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        If Not System.IO.File.Exists(dbFilePath) Then
            MsgBox(dbFilePath & "ファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If
        If Not System.IO.File.Exists(dbDiagnoseFilePath) Then
            MsgBox(dbDiagnoseFilePath & "ファイルが存在しません。" & Environment.NewLine & "iniファイルのDiagnoseDirに適切なパスを設定して下さい。")
            Me.Close()
            Exit Sub
        End If
        If Not System.IO.File.Exists(dbHealth3FilePath) Then
            MsgBox(dbHealth3FilePath & "ファイルが存在しません。" & Environment.NewLine & "iniファイルのHealthDirに適切なパスを設定して下さい。")
            Me.Close()
            Exit Sub
        End If

        If Not System.IO.File.Exists(excelFilePass) Then
            MsgBox("エクセルファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If


        Me.WindowState = FormWindowState.Maximized
    End Sub

    ''' <summary>
    ''' 予約データメニュークリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 予約データToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 予約データToolStripMenuItem.Click
        If IsNothing(reserveForm) OrElse reserveForm.IsDisposed Then
            reserveForm = New 予約データ()
            reserveForm.Owner = Me
            reserveForm.Show()
        End If
    End Sub

    ''' <summary>
    ''' 産健センター扱いメニュークリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 産健センター扱いToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 産健センター扱いToolStripMenuItem.Click
        If IsNothing(sankenForm) OrElse sankenForm.IsDisposed Then
            sankenForm = New 産健センター扱い()
            sankenForm.Owner = Me
            sankenForm.Show()
        End If
    End Sub

    ''' <summary>
    ''' 検索メニュークリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 検索ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 検索ToolStripMenuItem.Click
        If IsNothing(searchForm) OrElse searchForm.IsDisposed Then
            searchForm = New 検索()
            searchForm.Owner = Me
            searchForm.Show()
        End If
    End Sub

    ''' <summary>
    ''' 終了メニュークリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 終了ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class
