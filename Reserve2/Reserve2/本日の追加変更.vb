Imports System.Data.OleDb

Public Class 本日の追加変更

    '曜日配列
    Private dayArray As String() = {"日", "月", "火", "水", "木", "金", "土"}

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
    Private Sub 本日の追加変更_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        '位置
        Me.Left = 800
        Me.Top = 50

        '本日以前のデータ削除
        deleteOldData()

        'データグリッドビュー初期設定
        initDgvToday()

        'データ表示
        displayDgvToday()
    End Sub

    ''' <summary>
    ''' データグリッドビュー初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDgvToday()
        Util.EnableDoubleBuffering(dgvToday)

        With dgvToday
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False '行削除禁止
            .BorderStyle = BorderStyle.FixedSingle
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeight = 25
            .RowHeadersWidth = 25
            .RowTemplate.Height = 20
            .RowTemplate.HeaderCell = New dgvRowHeaderCell() '行ヘッダの三角マークを非表示に
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .ShowCellToolTips = True
            .EnableHeadersVisualStyles = False
            .Font = New Font("ＭＳ Ｐゴシック", 8)
            .ReadOnly = True
        End With
    End Sub

    ''' <summary>
    ''' データ表示
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub displayDgvToday()
        '内容クリア
        dgvToday.Columns.Clear()

        'データ取得
        Dim nowYmd As String = Today.ToString("yyyy/MM/dd") '本日日付
        Dim cnn As New ADODB.Connection
        cnn.Open(TopForm.DB_Reserve)
        Dim rs As New ADODB.Recordset
        Dim sql As String = "SELECT AddDate, Ymd, WeekDay(Ymd) as [Day], Apm, Syu, Nam, Kana, Sex, Birth, Int((Format(NOW(),'YYYYMMDD')-Format(Birth, 'YYYYMMDD'))/10000) as Age, Ind, Memo1, Futan, Type FROM Change WHERE AddDate = '" & nowYmd & "' ORDER BY Ymd ASC, Apm ASC, Kana ASC"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter()
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, rs, "Reserve")
        Dim dt As DataTable = ds.Tables("Reserve")

        'RsvDに追加変更行のデータがあるかチェック、ない場合は表示しない
        sql = "SELECT Ymd, Apm, Syu, Nam, Kana, Sex, Birth, Ind, Memo1, Futan FROM RsvD"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        For Each row As DataRow In dt.Rows
            Dim type As String = Util.checkDBNullValue(row("Type"))
            If type = "A" Then
                Dim ymd As String = Util.checkDBNullValue(row("Ymd"))
                Dim apm As String = Util.checkDBNullValue(row("Apm"))
                Dim nam As String = Util.checkDBNullValue(row("Nam"))
                Dim kana As String = Util.checkDBNullValue(row("kana"))
                Dim sex As String = Util.checkDBNullValue(row("Sex"))
                Dim birth As String = Util.checkDBNullValue(row("Birth"))
                Dim ind As String = Util.checkDBNullValue(row("Ind"))
                Dim memo1 As String = Util.checkDBNullValue(row("Memo1"))
                Dim futan As String = Util.checkDBNullValue(row("Futan"))

                Dim filter As String = "Ymd = '" & ymd & "' and Apm = '" & apm & "' and Nam = '" & nam & "' and Kana = '" & kana & "' and Sex = '" & sex & "' and Birth = '" & birth & "' and Ind = '" & ind & "' and Memo1 = '" & memo1 & "'"
                rs.Filter = filter
                If rs.EOF Then
                    row.Delete()
                End If
            End If
        Next
        cnn.Close()

        '表示
        dgvToday.DataSource = dt
        dgvToday.ClearSelection()

        '幅設定等
        With dgvToday
            '非表示
            .Columns("AddDate").Visible = False
            .Columns("Type").Visible = False

            With .Columns("Ymd")
                .HeaderText = "予約日"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 70
            End With
            With .Columns("Day")
                .HeaderText = "曜"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 25
            End With
            With .Columns("Apm")
                .HeaderText = "AmPm"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 40
            End With
            With .Columns("Syu")
                .HeaderText = "種別"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 35
            End With
            With .Columns("Nam")
                .HeaderText = "氏名"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 70
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Kana")
                .HeaderText = "カナ"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 70
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Sex")
                .HeaderText = "性別"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 30
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Birth")
                .HeaderText = "生年月日"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 65
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Age")
                .HeaderText = "年齢"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 35
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Ind")
                .HeaderText = "企業名"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 100
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Memo1")
                .HeaderText = "メモ1"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 150
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Futan")
                .HeaderText = "窓口負担"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 80
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            If dgvToday.Rows.Count > 12 Then
                .Size = New Size(584, 284)
            Else
                .Size = New Size(567, 284)
            End If
        End With

        '行の色付け
        paintCellColor()

    End Sub

    ''' <summary>
    ''' 本日以前のデータ削除
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub deleteOldData()
        Dim cnn As New ADODB.Connection
        Dim cmd As New ADODB.Command
        cnn.Open(TopForm.DB_Reserve)
        cmd.ActiveConnection = cnn
        cmd.CommandText = "delete from Change where AddDate < '" & Today.ToString("yyyy/MM/dd") & "'"
        cmd.Execute()
        cnn.Close()
    End Sub

    ''' <summary>
    ''' 更新ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        '再表示
        displayDgvToday()
    End Sub

    ''' <summary>
    ''' CellFormattingイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvToday_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvToday.CellFormatting
        If e.RowIndex >= 0 Then
            If dgvToday.Columns(e.ColumnIndex).Name = "Birth" Then
                '生年月日を和暦に
                e.Value = Util.convADStrToWarekiStr(e.Value)
                e.FormattingApplied = True
            ElseIf dgvToday.Columns(e.ColumnIndex).Name = "Day" Then
                '曜日の表示設定
                e.Value = dayArray(CInt(e.Value) - 1)
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
    Private Sub dgvToday_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvToday.CellPainting
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
    End Sub

    ''' <summary>
    ''' 列ヘッダーダブルクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvToday_ColumnHeaderMouseDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvToday.ColumnHeaderMouseDoubleClick
        Dim targetColumn As DataGridViewColumn = dgvToday.Columns(e.ColumnIndex) '選択列
        dgvToday.Sort(targetColumn, System.ComponentModel.ListSortDirection.Ascending) '昇順でソート
        dgvToday.ClearSelection()
        paintCellColor()
    End Sub

    ''' <summary>
    ''' 行の色付け
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub paintCellColor()
        For Each row As DataGridViewRow In dgvToday.Rows
            Dim type As String = Util.checkDBNullValue(row.Cells("Type").Value)
            If type = "D" Then '削除行
                row.DefaultCellStyle.BackColor = Color.Azure
                row.DefaultCellStyle.ForeColor = Color.Black
                row.DefaultCellStyle.SelectionBackColor = Color.Azure
                row.DefaultCellStyle.SelectionForeColor = Color.Black
            End If
        Next
    End Sub
End Class