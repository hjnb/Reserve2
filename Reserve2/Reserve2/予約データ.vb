Imports System.Data.OleDb

Public Class 予約データ

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
    Private Sub 予約データ_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '位置
        Me.Left = 10
        Me.Top = 50

        '印刷ラジオボタン初期設定
        initPrintState()

        '予約データグリッドビュー初期設定
        initDgvReserve()

        '年月ボックスに現在年月設定
        ymBox.setADStr(Today.ToString("yyyy/MM/01"))
    End Sub

    ''' <summary>
    ''' 予約データグリッドビュー初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDgvReserve()
        Util.EnableDoubleBuffering(dgvReserve)

        With dgvReserve
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
            .RowHeadersWidth = 35
            .RowTemplate.Height = 22
            .RowTemplate.HeaderCell = New dgvRowHeaderCell() '行ヘッダの三角マークを非表示に
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .ShowCellToolTips = True
            .EnableHeadersVisualStyles = False
            '.Font = New Font("ＭＳ Ｐゴシック", 10)
            .ReadOnly = True
        End With
    End Sub

    ''' <summary>
    ''' 予約データ表示
    ''' </summary>
    ''' <param name="ym">年月(yyyy/MM)</param>
    ''' <remarks></remarks>
    Private Sub displayDgvReserve(ym As String)
        '内容クリア
        dgvReserve.Columns.Clear()

        'データ取得
        Dim cnn As New ADODB.Connection
        cnn.Open(TopForm.DB_Reserve)
        Dim rs As New ADODB.Recordset
        Dim sql As String = "SELECT Ymd, WeekDay(Ymd) as [Day], Apm, Syu, Nam, Kana, Sex, Birth, Int((Format(NOW(),'YYYYMMDD')-Format(Birth, 'YYYYMMDD'))/10000) as Age, Ind, Memo1, Futan, Kjn1, Kjn2, Kjn3, Kjn4, Kjn5, Kjn6, Kig1, Kig2, Kig3, Kig4, Kig5, Kig6, Sei1, Sei2, Sei3, Sei4, Tok1, Tok2, Tok3, Tok4, Tok5, Tok6, Tok7, Tok8, Tok9, Gan1, Gan2, Sanken, LumbarXP FROM RsvD WHERE Ymd LIKE '%" & ym & "%' ORDER BY Ymd ASC, Apm ASC, Kana ASC"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter()
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, rs, "Reserve")
        Dim dt As DataTable = ds.Tables("Reserve")
        cnn.Close()

        '表示
        dgvReserve.DataSource = dt
        dgvReserve.ClearSelection()

        '幅設定等
        With dgvReserve
            '非表示
            For Each colName As String In {"Kjn1", "Kjn2", "Kjn3", "Kjn4", "Kjn5", "Kjn6", "Kig1", "Kig2", "Kig3", "Kig4", "Kig5", "Kig6", "Sei1", "Sei2", "Sei3", "Sei4", "Tok1", "Tok2", "Tok3", "Tok4", "Tok5", "Tok6", "Tok7", "Tok8", "Tok9", "Gan1", "Gan2", "Sanken", "LumbarXp"}
                .Columns(colName).Visible = False
            Next

            With .Columns("Ymd")
                .HeaderText = "予約日"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 70
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Day")
                .HeaderText = "曜"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 30
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Apm")
                .HeaderText = "AmPm"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 50
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Syu")
                .HeaderText = "種別"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 40
                .Frozen = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Nam")
                .HeaderText = "氏名"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 90
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Kana")
                .HeaderText = "カナ"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 80
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Sex")
                .HeaderText = "性別"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 35
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Birth")
                .HeaderText = "生年月日"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 70
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Age")
                .HeaderText = "年齢"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 40
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Ind")
                .HeaderText = "企業名"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 130
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Memo1")
                .HeaderText = "メモ1"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 80
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Futan")
                .HeaderText = "窓口負担"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 80
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
        End With

        '本日日付の行までスクロール
        Dim todayDate As String = DateTime.Today.ToString("yyyy/MM/dd")
        Dim rowsCount As Integer = dgvReserve.Rows.Count
        For i = 0 To rowsCount - 2
            If Util.checkDBNullValue(dgvReserve("Ymd", i).Value) >= todayDate Then
                dgvReserve.FirstDisplayedScrollingRowIndex = i
                Exit For
            End If
        Next
    End Sub

    ''' <summary>
    ''' Diagnose検診企業リスト表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub displayDiagnoseList()
        referenceListBox.Items.Clear()

        Dim cnn As New ADODB.Connection
        cnn.Open(TopForm.DB_Diagnose)
        Dim rs As New ADODB.Recordset
        Dim sql As String = "SELECT Ind FROM IndM ORDER BY Kana"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        While Not rs.EOF
            referenceListBox.Items.Add(Util.checkDBNullValue(rs.Fields("Ind").Value))
            rs.MoveNext()
        End While
        rs.Close()
        cnn.Close()
    End Sub

    ''' <summary>
    ''' 生活習慣病企業リスト表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub displayHealthList()
        referenceListBox.Items.Clear()

        Dim cnn As New ADODB.Connection
        cnn.Open(TopForm.DB_Health3)
        Dim rs As New ADODB.Recordset
        Dim sql As String = "SELECT Ind FROM IndM ORDER BY Kana"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        While Not rs.EOF
            referenceListBox.Items.Add(Util.checkDBNullValue(rs.Fields("Ind").Value))
            rs.MoveNext()
        End While
        rs.Close()
        cnn.Close()
    End Sub

    ''' <summary>
    ''' 産健センター扱い企業リスト表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub displaySankenCenterList()
        referenceListBox.Items.Clear()

        Dim cnn As New ADODB.Connection
        cnn.Open(TopForm.DB_Reserve)
        Dim rs As New ADODB.Recordset
        Dim sql As String = "SELECT distinct Ind FROM RsvD WHERE Sanken='*' ORDER BY Ind"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        While Not rs.EOF
            referenceListBox.Items.Add(Util.checkDBNullValue(rs.Fields("Ind").Value))
            rs.MoveNext()
        End While
        rs.Close()
        cnn.Close()
    End Sub

    ''' <summary>
    ''' 画面左テキストボックスの入力内容クリア
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub inputClear()
        syuBox.Text = ""
        indBox.Text = ""
        namBox.Text = ""
        kanaBox.Text = ""
        sexBox.Text = ""
        memo1Box.Text = ""
        apmBox.Text = ""
        birthBox.clearText()
        reserveYmdBox.clearText()
    End Sub

    ''' <summary>
    ''' 画面右の各タブの入力エリアのクリア
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub tabPageInputClear()
        '個人タブ
        personalBlood.Checked = False
        personalElectro.Checked = False
        personalChestXP.Checked = False
        personalUltrasonic.Checked = False
        personalStomachBa.Checked = False
        personalStomachCamera.Checked = False
        personalNone.Checked = False
        personalWindowPay.Text = ""
        personalLumbarXP.Checked = False

        '企業タブ
        companyBlood.Checked = False
        companyElectro.Checked = False
        companyChestXP.Checked = False
        companyUltrasonic.Checked = False
        companyStomachBa.Checked = False
        companyStomachCamera.Checked = False
        companyNone.Checked = False
        companyWindowPay.Text = ""
        companyLumbarXP.Checked = False

        '生活タブ
        lifeStyleStomachBa.Checked = False
        lifeStyleStomachCamera.Checked = False
        lifeStyleNone.Checked = False
        lifeStyleWindowPay.Text = ""
        lifeStyleLumbarXP.Checked = False

        '特定タブ
        insuranceTypeBox.Text = ""
        biochemistryBox.Text = ""
        bloodSugarBox.Text = ""
        anemiaBox.Text = ""
        couponTicketBox.Checked = False
        cardiacBox.Text = ""
        gastricCancerRiskBox.Text = ""
        diabetesBox.Text = ""
        prostateCancerBox.Text = ""
        specificWindowPay.Text = ""

        'がんタブ
        gastricCancerBox.Checked = False
        colorectalCancerBox.Checked = False
        cancerWindowPay.Text = ""

        '参照タブ
        If diagnoseButton.Checked = True Then
            healthButton.Checked = True
            diagnoseButton.Checked = True
        Else
            diagnoseButton.Checked = True
        End If
    End Sub

    ''' <summary>
    ''' 印刷ラジオボタン初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initPrintState()
        Dim state As String = Util.getIniString("System", "Printer", TopForm.iniFilePath)
        If state = "Y" Then
            rbtnPrint.Checked = True
        Else
            rbtnPreview.Checked = True
        End If
    End Sub

    Private Sub rbtnPreview_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbtnPreview.CheckedChanged
        If rbtnPreview.Checked = True Then
            Util.putIniString("System", "Printer", "N", TopForm.iniFilePath)
        End If
    End Sub

    Private Sub rbtnPrint_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbtnPrint.CheckedChanged
        If rbtnPrint.Checked = True Then
            Util.putIniString("System", "Printer", "Y", TopForm.iniFilePath)
        End If
    End Sub

    ''' <summary>
    ''' CellMouseClickイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvReserve_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvReserve.CellMouseClick
        If e.RowIndex >= 0 Then
            Dim syu As String = Util.checkDBNullValue(dgvReserve("Syu", e.RowIndex).Value)
            Dim ind As String = Util.checkDBNullValue(dgvReserve("Ind", e.RowIndex).Value)
            Dim nam As String = Util.checkDBNullValue(dgvReserve("Nam", e.RowIndex).Value)
            Dim kana As String = Util.checkDBNullValue(dgvReserve("Kana", e.RowIndex).Value)
            Dim sex As String = Util.checkDBNullValue(dgvReserve("Sex", e.RowIndex).Value)
            Dim birth As String = Util.checkDBNullValue(dgvReserve("Birth", e.RowIndex).Value)
            Dim reserveYmd As String = Util.checkDBNullValue(dgvReserve("Ymd", e.RowIndex).Value)
            Dim apm As String = Util.checkDBNullValue(dgvReserve("Apm", e.RowIndex).Value)
            Dim memo1 As String = Util.checkDBNullValue(dgvReserve("Memo1", e.RowIndex).Value)
            Dim futan As String = Util.checkDBNullValue(dgvReserve("Futan", e.RowIndex).Value)
            Dim lumbarXP As String = Util.checkDBNullValue(dgvReserve("LumbarXP", e.RowIndex).Value)

            '各テキストボックスへ反映
            syuBox.Text = syu
            indBox.Text = ind
            namBox.Text = nam
            kanaBox.Text = kana
            sexBox.Text = sex
            memo1Box.Text = memo1
            apmBox.Text = apm
            birthBox.setADStr(birth)
            reserveYmdBox.setADStr(reserveYmd)

            '参照タブ部分
            If syu = "生活" Then
                healthButton.Checked = True
                For i As Integer = 0 To referenceListBox.Items.Count - 1
                    Dim itemName As String = referenceListBox.Items(i)
                    If itemName = ind Then
                        referenceListBox.SelectedIndex = i
                        Exit For
                    End If
                Next
            ElseIf syu = "企業" Then
                Dim selectFlg As Boolean = False
                diagnoseButton.Checked = True
                For i As Integer = 0 To referenceListBox.Items.Count - 1
                    Dim itemName As String = referenceListBox.Items(i)
                    If itemName = ind Then
                        referenceListBox.SelectedIndex = i
                        selectFlg = True
                        Exit For
                    End If
                Next
                If selectFlg = False Then
                    sankenCenterButton.Checked = True
                    For i As Integer = 0 To referenceListBox.Items.Count - 1
                        Dim itemName As String = referenceListBox.Items(i)
                        If itemName = ind Then
                            referenceListBox.SelectedIndex = i
                            Exit For
                        End If
                    Next
                End If
            End If

            'タブ切り替え
            If syu = "個人" Then
                reserveTabControl.SelectedTab = personalTabPage
            ElseIf syu = "企業" Then
                reserveTabControl.SelectedTab = companyTabPage
            ElseIf syu = "生活" Then
                reserveTabControl.SelectedTab = lifeStyleTabPage
            ElseIf syu = "特定" Then
                reserveTabControl.SelectedTab = specificTabPage
            ElseIf syu = "がん" Then
                reserveTabControl.SelectedTab = cancerTabPage
            End If

            '該当のタブのチェックボックス、ラジオボタンなどへの反映
            '
            '
            '
            '











        End If
    End Sub

    ''' <summary>
    ''' CellFormattingイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvReserve_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvReserve.CellFormatting
        If e.RowIndex >= 0 Then
            If dgvReserve.Columns(e.ColumnIndex).Name = "Ymd" Then
                '予約日の表示設定,グループ化
                If e.RowIndex > 0 AndAlso dgvReserve(e.ColumnIndex, e.RowIndex - 1).Value = e.Value Then
                    e.Value = ""
                    e.FormattingApplied = True
                Else
                    e.Value = Integer.Parse(e.Value.Substring(e.Value.ToString.Length - 2, 2)).ToString()
                    e.FormattingApplied = True
                End If
            ElseIf dgvReserve.Columns(e.ColumnIndex).Name = "Day" Then
                '曜日の表示設定, グループ化
                If e.RowIndex > 0 AndAlso (dgvReserve("Ymd", e.RowIndex - 1).Value = dgvReserve("Ymd", e.RowIndex).Value) AndAlso dgvReserve(e.ColumnIndex, e.RowIndex - 1).Value = e.Value Then
                    e.Value = ""
                    e.FormattingApplied = True
                Else
                    If e.Value = 1 Then
                        e.Value = "日"
                    ElseIf e.Value = 2 Then
                        e.Value = "月"
                    ElseIf e.Value = 3 Then
                        e.Value = "火"
                    ElseIf e.Value = 4 Then
                        e.Value = "水"
                    ElseIf e.Value = 5 Then
                        e.Value = "木"
                    ElseIf e.Value = 6 Then
                        e.Value = "金"
                    ElseIf e.Value = 7 Then
                        e.Value = "土"
                    End If
                    e.FormattingApplied = True
                End If
            ElseIf dgvReserve.Columns(e.ColumnIndex).Name = "Apm" Then
                '時間のグループ化
                If e.RowIndex > 0 AndAlso (dgvReserve("Ymd", e.RowIndex - 1).Value = dgvReserve("Ymd", e.RowIndex).Value) AndAlso dgvReserve("day", e.RowIndex).Value = dgvReserve("day", e.RowIndex - 1).Value AndAlso dgvReserve(e.ColumnIndex, e.RowIndex - 1).Value = e.Value Then
                    e.Value = ""
                    e.FormattingApplied = True
                End If
            ElseIf dgvReserve.Columns(e.ColumnIndex).Name = "Birth" Then
                '生年月日の和暦表示
                e.Value = Util.convADStrToWarekiStr(Util.checkDBNullValue(dgvReserve("Birth", e.RowIndex).Value))
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
    Private Sub dgvReserve_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvReserve.CellPainting
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
    ''' 年月ボックス値変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ymBox_YmdTextChange(sender As Object, e As System.EventArgs) Handles ymBox.YmdTextChange
        Dim ym As String = ymBox.getADStr4Ym()
        displayDgvReserve(ym)
    End Sub

    ''' <summary>
    ''' 入力クリアボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnInputClear_Click(sender As System.Object, e As System.EventArgs) Handles btnInputClear.Click
        inputClear()
        tabPageInputClear()
    End Sub

    ''' <summary>
    ''' 選択解除ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSelectClear_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectClear.Click
        dgvReserve.ClearSelection()
        inputClear()
        tabPageInputClear()
    End Sub

    ''' <summary>
    ''' 参照タブ：ラジオボタン値変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub syuRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles diagnoseButton.CheckedChanged, healthButton.CheckedChanged, sankenCenterButton.CheckedChanged
        Dim name As String = DirectCast(sender, RadioButton).Name
        Dim checked As Boolean = DirectCast(sender, RadioButton).Checked

        If name = "diagnoseButton" AndAlso checked Then
            personListBox.Items.Clear()
            displayDiagnoseList()
        ElseIf name = "healthButton" AndAlso checked Then
            personListBox.Items.Clear()
            displayHealthList()
        ElseIf name = "sankenCenterButton" AndAlso checked Then
            personListBox.Items.Clear()
            displaySankenCenterList()
        End If
    End Sub
End Class