Imports System.Data.OleDb

Public Class 検索

    ''' <summary>
    ''' 行ヘッダーのカレントセルを表す三角マークを非表示に設定する為のクラス。
    ''' </summary>
    ''' <remarks></remarks>
    Public Class dgvRowHeaderCell

        'DataGridViewRowHeaderCell を継承
        Inherits DataGridViewRowHeaderCell

        'DataGridViewHeaderCell.Paint をオーバーライドして行ヘッダーを描画
        Protected Overrides Sub Paint(ByVal graphics As Graphics, ByVal clipBounds As Rectangle, _
           ByVal cellBounds As Rectangle, ByVal rowIndex As Integer, ByVal cellState As DataGridViewElementStates, _
           ByVal value As Object, ByVal formattedValue As Object, ByVal errorText As String, _
           ByVal cellStyle As DataGridViewCellStyle, ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, _
           ByVal paintParts As DataGridViewPaintParts)
            '標準セルの描画からセル内容の背景だけ除いた物を描画(-5)
            MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, _
                     formattedValue, errorText, cellStyle, advancedBorderStyle, _
                     Not DataGridViewPaintParts.ContentBackground)
        End Sub

    End Class

    ''' <summary>
    ''' loadイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 検索_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '位置
        Me.Left = 800
        Me.Top = 50

        '日付ラベル設定
        setFromToDateLabel()

        'データグリッドビュー初期設定
        initDgvSearch()
    End Sub

    ''' <summary>
    ''' 日付ラベル設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setFromToDateLabel()
        Dim fromDate As String = ""
        Dim toDate As String = ""

        '最古の予約日を取得
        Dim cnn As New ADODB.Connection
        cnn.Open(TopForm.DB_Reserve)
        Dim rs As New ADODB.Recordset
        Dim sql As String = "SELECT TOP 1 Ymd FROM RsvD ORDER BY Ymd"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            fromDate = Util.checkDBNullValue(rs.Fields("Ymd").Value)
        End If
        fromDateLabel.Text = fromDate
        rs.Close()

        '最新の予約日を取得
        sql = "SELECT TOP 1 Ymd FROM RsvD ORDER BY Ymd DESC"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            toDate = Util.checkDBNullValue(rs.Fields("Ymd").Value)
        End If
        toDateLabel.Text = toDate

        rs.Close()
        cnn.Close()
    End Sub

    ''' <summary>
    ''' データグリッドビュー初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDgvSearch()
        Util.EnableDoubleBuffering(dgvSearch)

        With dgvSearch
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False '行削除禁止
            .BorderStyle = BorderStyle.FixedSingle
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
            .DefaultCellStyle.ForeColor = Color.Black
            .DefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.Control)
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .RowHeadersWidth = 36
            .RowTemplate.Height = 21
            .RowTemplate.HeaderCell = New dgvRowHeaderCell() '行ヘッダの三角マークを非表示に
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .ShowCellToolTips = True
            .EnableHeadersVisualStyles = False
            '.Font = New Font("ＭＳ Ｐゴシック", 10)
            .ReadOnly = True
        End With
    End Sub

    ''' <summary>
    ''' 検索結果表示
    ''' </summary>
    ''' <param name="searchText">検索文字列</param>
    ''' <remarks></remarks>
    Private Sub displayDgvSearch(searchText As String)
        '内容クリア
        dgvSearch.Columns.Clear()

        'データ取得
        Dim cnn As New ADODB.Connection
        cnn.Open(TopForm.DB_Reserve)
        Dim rs As New ADODB.Recordset
        Dim sql As String = "SELECT Nam, Kana, Birth, Tok1, Futan, Ymd, Syu FROM RsvD WHERE Kana LIKE '%" & searchText & "%' ORDER BY Ymd DESC, Kana ASC"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter()
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, rs, "Search")
        Dim dt As DataTable = ds.Tables("Search")
        cnn.Close()

        '表示
        dgvSearch.DataSource = dt
        dgvSearch.ClearSelection()

        '幅設定等
        With dgvSearch
            With .Columns("Nam")
                .HeaderText = "氏名"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 80
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Kana")
                .HeaderText = "カナ"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 80
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Birth")
                .HeaderText = "生年月日"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 70
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Tok1")
                .HeaderText = "保険"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 40
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Futan")
                .HeaderText = "窓口負担"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Width = 80
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Ymd")
                .HeaderText = "予約日"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 70
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Syu")
                .HeaderText = "種別"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 40
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
        End With
    End Sub

    ''' <summary>
    ''' CellFormattingイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvSearch_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvSearch.CellFormatting
        If e.RowIndex >= 0 Then
            '予約日と生年月日を和暦表示に変換
            If dgvSearch.Columns(e.ColumnIndex).Name = "Ymd" OrElse dgvSearch.Columns(e.ColumnIndex).Name = "Birth" Then
                e.Value = Util.convADStrToWarekiStr(Util.checkDBNullValue(dgvSearch(e.ColumnIndex, e.RowIndex).Value))
                e.FormattingApplied = True
            End If
        End If
    End Sub

    ''' <summary>
    ''' CellPaintingイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvSearch_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvSearch.CellPainting
        '行ヘッダーかどうか調べる
        If e.ColumnIndex < 0 AndAlso e.RowIndex >= 0 Then
            'セルを描画する
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All)

            '行番号を描画する範囲を決定する
            'e.AdvancedBorderStyleやe.CellStyle.Paddingは無視しています
            Dim indexRect As Rectangle = e.CellBounds
            indexRect.Inflate(-2, -2)
            '行番号を描画する
            TextRenderer.DrawText(e.Graphics, _
                (e.RowIndex + 1).ToString(), _
                e.CellStyle.Font, _
                indexRect, _
                e.CellStyle.ForeColor, _
                TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
            '描画が完了したことを知らせる
            e.Handled = True
        End If
        '選択したセルに枠を付ける
        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 AndAlso (e.PaintParts And DataGridViewPaintParts.Background) = DataGridViewPaintParts.Background Then
            e.Graphics.FillRectangle(New SolidBrush(e.CellStyle.BackColor), e.CellBounds)

            If (e.PaintParts And DataGridViewPaintParts.SelectionBackground) = DataGridViewPaintParts.SelectionBackground AndAlso (e.State And DataGridViewElementStates.Selected) = DataGridViewElementStates.Selected Then
                e.Graphics.DrawRectangle(New Pen(Color.Black, 2I), e.CellBounds.X + 1I, e.CellBounds.Y + 1I, e.CellBounds.Width - 3I, e.CellBounds.Height - 3I)
            End If

            Dim pParts As DataGridViewPaintParts = e.PaintParts And Not DataGridViewPaintParts.Background
            e.Paint(e.ClipBounds, pParts)
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' 検索ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        Dim searchStr As String = searchTextBox.Text
        If searchStr = "" Then
            MsgBox("検索文字列を入力してください", MsgBoxStyle.Exclamation)
            searchTextBox.Focus()
        Else
            displayDgvSearch(searchStr)
        End If
    End Sub

    ''' <summary>
    ''' 検索テキストボックスkeyDown
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub searchTextBox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles searchTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.Focus()
        End If
    End Sub
End Class