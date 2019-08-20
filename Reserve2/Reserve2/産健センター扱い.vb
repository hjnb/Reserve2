Imports System.Data.OleDb

Public Class 産健センター扱い

    '産健データ初期状態保持用
    Private preData As New List(Of SankenData)

    Private Class SankenData
        Private sankenName As String

        Private sankenFlg As Boolean

        Public Sub New(ByVal sankenName As String, ByVal sankenFlg As Boolean)
            Me.sankenName = sankenName
            Me.sankenFlg = sankenFlg
        End Sub

        Public Function getSankenName() As String
            Return sankenName
        End Function

        Public Function getSankenFlg() As Boolean
            Return sankenFlg
        End Function

    End Class

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
    Private Sub 産健センター扱い_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '位置
        Me.Left = 800
        Me.Top = 50

        'データグリッドビュー初期設定
        initDgvSanken()

        '産健リスト表示
        displaySankenList()
    End Sub

    ''' <summary>
    ''' データグリッドビュー初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDgvSanken()
        Util.EnableDoubleBuffering(dgvSanken)

        With dgvSanken
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
            .ReadOnly = False
            .ImeMode = Windows.Forms.ImeMode.Hiragana
        End With
    End Sub

    ''' <summary>
    ''' 産健リスト表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub displaySankenList()
        '内容クリア
        dgvSanken.Columns.Clear()

        'データ取得
        Dim cnn As New ADODB.Connection
        cnn.Open(TopForm.DB_Reserve)
        Dim rs As New ADODB.Recordset
        Dim sql As String = "SELECT distinct Ind, Sanken FROM RsvD ORDER BY Ind ASC"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter()
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, rs, "San")
        Dim dt As DataTable = ds.Tables("San")
        cnn.Close()

        '列追加
        dt.Columns.Add("Check", GetType(Boolean))
        For Each row As DataRow In dt.Rows
            Dim sanken As String = Util.checkDBNullValue(row("Sanken"))
            If sanken = "*" Then
                row("Check") = True
            Else
                row("Check") = False
            End If
        Next

        '表示
        dgvSanken.DataSource = dt
        dgvSanken.ClearSelection()

        '幅設定等
        With dgvSanken
            .Columns("Sanken").Visible = False
            With .Columns("Ind")
                .HeaderText = "企業名"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 170
                .ReadOnly = True
            End With
            With .Columns("Check")
                .HeaderText = "該当"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 40
                .ReadOnly = False
            End With
        End With

        '重複表示の制御処理
        Dim rowsCount As Integer = dgvSanken.Rows.Count
        For i = 0 To rowsCount - 1
            If i <> 0 AndAlso dgvSanken(0, i).Value = dgvSanken(0, i - 1).Value Then
                dgvSanken.Rows.RemoveAt(i - 1)
                rowsCount -= 1
                i -= 1
            End If
            If i = rowsCount - 1 Then
                Exit For
            End If
        Next

        '初期状態を保持
        preData.Clear()
        For i = 0 To dgvSanken.Rows.Count - 1
            Dim ind As String = Util.checkDBNullValue(dgvSanken("Ind", i).Value)
            Dim sankenFlg As Boolean = dgvSanken("Check", i).Value
            preData.Add(New SankenData(ind, sankenFlg))
        Next

    End Sub

    ''' <summary>
    ''' CellPaintingイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvSanken_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvSanken.CellPainting
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
    ''' 登録ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRegist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegist.Click
        Dim updateIndexList As New List(Of Integer)
        Dim nowData As New List(Of SankenData)
        Dim rowsCount As Integer = dgvSanken.Rows.Count
        For i = 0 To rowsCount - 1
            Dim ind As String = Util.checkDBNullValue(dgvSanken("Ind", i).Value)
            Dim sankenFlg As Boolean = dgvSanken("Check", i).Value
            nowData.Add(New SankenData(ind, sankenFlg))
            If nowData(i).getSankenName = preData(i).getSankenName AndAlso nowData(i).getSankenFlg <> preData(i).getSankenFlg Then
                '初期状態と比較し異なる場合は対象のインデックスをリストに追加
                updateIndexList.Add(i)
            End If
        Next

        If updateIndexList.Count = 0 Then
            MsgBox("変更がありません")
        Else
            '更新処理
            updateSankenData(nowData, updateIndexList)
            MsgBox(updateIndexList.Count & "件、変更しました")

            '再表示
            displaySankenList()
        End If
    End Sub

    ''' <summary>
    ''' 更新処理
    ''' </summary>
    ''' <param name="nowSankenDataList">現在のデータリスト</param>
    ''' <param name="updateIndexList">更新対象のインデックスリスト</param>
    ''' <remarks></remarks>
    Private Sub updateSankenData(ByVal nowSankenDataList As List(Of SankenData), ByVal updateIndexList As List(Of Integer))
        Dim cnn As New ADODB.Connection
        Dim cmd As New ADODB.Command
        cnn.Open(TopForm.DB_Reserve)
        cmd.ActiveConnection = cnn
        For Each i As Integer In updateIndexList
            Dim ind As String = nowSankenDataList(i).getSankenName
            Dim sanken As String = If(nowSankenDataList(i).getSankenFlg, "*", "")
            cmd.CommandText = "Update RsvD SET Sanken='" & sanken & "' WHERE Ind='" & ind & "'"
            cmd.Execute()
        Next
        cnn.Close()
    End Sub

End Class