Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices

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
    ''' フォームのKeyDownイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 予約データ_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.SelectNextControl(Me.ActiveControl, Not e.Shift, True, True, True)
        End If
    End Sub

    ''' <summary>
    ''' loadイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 予約データ_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        '位置
        Me.Left = 10
        Me.Top = 50

        '印刷ラジオボタン初期設定
        initPrintState()

        '予約データグリッドビュー初期設定
        initDgvReserve()

        '年月ボックスに現在年月設定
        ymBox.setADStr(Today.ToString("yyyy/MM/01"))
        ymBox.setFocus(4)
        ymBox.setFocusedTextBoxNum(2)

        '参照タブを表示
        reserveTabControl.SelectedTab = referenceTabPage
        diagnoseButton.Checked = True

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
            .MultiSelect = True
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
                .Width = 50
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
                If dgvReserve.Rows.Count > 10 Then
                    .Width = 150
                Else
                    .Width = 167
                End If
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

        syuBox.Focus()
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
        checkECG.Checked = False

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
            '個人タブ
            '血液
            Dim kjn1 As Integer = dgvReserve("Kjn1", e.RowIndex).Value
            personalBlood.Checked = If(kjn1 = 1, True, False)
            '心電図
            Dim kjn2 As Integer = dgvReserve("Kjn2", e.RowIndex).Value
            personalElectro.Checked = If(kjn2 = 1, True, False)
            '胸部Ｘ線
            Dim kjn3 As Integer = dgvReserve("Kjn3", e.RowIndex).Value
            personalChestXP.Checked = If(kjn3 = 1, True, False)
            '超音波
            Dim kjn4 As Integer = dgvReserve("Kjn4", e.RowIndex).Value
            personalUltrasonic.Checked = If(kjn4 = 1, True, False)
            '胃バリウム
            Dim kjn5 As Integer = dgvReserve("Kjn5", e.RowIndex).Value
            personalStomachBa.Checked = If(kjn5 = 1, True, False)
            '胃カメラ
            Dim kjn6 As Integer = dgvReserve("Kjn6", e.RowIndex).Value
            personalStomachCamera.Checked = If(kjn6 = 1, True, False)
            '窓口負担
            personalWindowPay.Text = If(futan <> 0 AndAlso syu = "個人", futan, "")
            '腰椎ＸＰ
            personalLumbarXP.Checked = If(lumbarXP = 1 AndAlso syu = "個人", True, False)

            '企業タブ
            Dim kig1 As Integer = dgvReserve("Kig1", e.RowIndex).Value
            companyBlood.Checked = If(kig1 = 1, True, False)
            '心電図
            Dim kig2 As Integer = dgvReserve("Kig2", e.RowIndex).Value
            companyElectro.Checked = If(kig2 = 1, True, False)
            '胸部Ｘ線
            Dim kig3 As Integer = dgvReserve("Kig3", e.RowIndex).Value
            companyChestXP.Checked = If(kig3 = 1, True, False)
            '超音波
            Dim kig4 As Integer = dgvReserve("Kig4", e.RowIndex).Value
            companyUltrasonic.Checked = If(kig4 = 1, True, False)
            '胃バリウム
            Dim kig5 As Integer = dgvReserve("Kig5", e.RowIndex).Value
            companyStomachBa.Checked = If(kig5 = 1, True, False)
            '胃カメラ
            Dim kig6 As Integer = dgvReserve("Kig6", e.RowIndex).Value
            companyStomachCamera.Checked = If(kig6 = 1, True, False)
            '窓口負担
            companyWindowPay.Text = If(futan <> 0 AndAlso syu = "企業", futan, "")
            '腰椎ＸＰ
            companyLumbarXP.Checked = If(lumbarXP = 1 AndAlso syu = "企業", True, False)

            '生活タブ
            '胃バリウム
            Dim sei3 As Integer = dgvReserve("Sei3", e.RowIndex).Value
            lifeStyleStomachBa.Checked = If(sei3 = 1, True, False)
            '胃カメラ
            Dim sei4 As Integer = dgvReserve("Sei4", e.RowIndex).Value
            lifeStyleStomachCamera.Checked = If(sei4 = 1, True, False)
            '窓口負担
            lifeStyleWindowPay.Text = If(futan <> 0 AndAlso syu = "生活", futan, "")
            '腰椎XP
            lifeStyleLumbarXP.Checked = If(lumbarXP = 1 AndAlso syu = "生活", True, False)

            '特定タブ
            '種別
            Dim tok1 As String = Util.checkDBNullValue(dgvReserve("Tok1", e.RowIndex).Value)
            insuranceTypeBox.Text = tok1
            '生化学
            Dim tok2 As String = Util.checkDBNullValue(dgvReserve("Tok2", e.RowIndex).Value)
            biochemistryBox.Text = tok2
            '血糖
            Dim tok3 As String = Util.checkDBNullValue(dgvReserve("Tok3", e.RowIndex).Value)
            bloodSugarBox.Text = tok3
            '貧血
            Dim tok4 As String = Util.checkDBNullValue(dgvReserve("Tok4", e.RowIndex).Value)
            anemiaBox.Text = tok4
            '心機能
            Dim tok5 As String = Util.checkDBNullValue(dgvReserve("Tok5", e.RowIndex).Value)
            cardiacBox.Text = tok5
            '胃がんリスク
            Dim tok6 As String = Util.checkDBNullValue(dgvReserve("Tok6", e.RowIndex).Value)
            gastricCancerRiskBox.Text = tok6
            '糖尿病性腎症
            Dim tok7 As String = Util.checkDBNullValue(dgvReserve("Tok7", e.RowIndex).Value)
            diabetesBox.Text = tok7
            '前立腺がん
            Dim tok8 As String = Util.checkDBNullValue(dgvReserve("Tok8", e.RowIndex).Value)
            prostateCancerBox.Text = tok8
            '無料クーポン券
            Dim tok9 As Integer = dgvReserve("Tok9", e.RowIndex).Value
            couponTicketBox.Checked = If(tok9 = 1, True, False)
            '窓口負担
            specificWindowPay.Text = If(futan <> 0 AndAlso syu = "特定", futan, "")
            '心電図
            checkECG.Checked = If(kig2 = 1, True, False)

            'がんタブ
            '胃がん
            Dim gan1 As Integer = dgvReserve("Gan1", e.RowIndex).Value
            gastricCancerBox.Checked = If(gan1 = 1, True, False)
            '大腸がん
            Dim gan2 As Integer = dgvReserve("Gan2", e.RowIndex).Value
            colorectalCancerBox.Checked = If(gan2 = 1, True, False)
            '窓口負担
            cancerWindowPay.Text = If(futan <> 0 AndAlso syu = "がん", futan, "")
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
    ''' 列ヘッダーダブルクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvReserve_ColumnHeaderMouseDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvReserve.ColumnHeaderMouseDoubleClick
        Dim targetColumn As DataGridViewColumn = dgvReserve.Columns(e.ColumnIndex) '選択列
        dgvReserve.Sort(targetColumn, System.ComponentModel.ListSortDirection.Ascending) '昇順でソート
    End Sub

    ''' <summary>
    ''' 年月ボックス値変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ymBox_YmdTextChange(sender As Object, e As System.EventArgs) Handles ymBox.YmdTextChange
        Dim ym As String = ymBox.getADYmStr()
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
        reserveTabControl.SelectedTab = referenceTabPage
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

    ''' <summary>
    ''' 参照タブ：企業名リスト選択値変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub referenceListBox_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles referenceListBox.SelectedValueChanged
        'リストのクリア
        personListBox.Items.Clear()

        '選択された企業名
        Dim ind As String = referenceListBox.SelectedItem

        'DBの選択
        Dim cnn As New ADODB.Connection
        Dim dbConnectionPath As String
        Dim sql As String
        If diagnoseButton.Checked = True Then
            '健診
            dbConnectionPath = TopForm.DB_Diagnose
            sql = "SELECT Nam, Kana FROM UsrM WHERE Ind='" & ind & " 'ORDER BY Kana"
        ElseIf healthButton.Checked = True Then
            '生活習慣病
            dbConnectionPath = TopForm.DB_Health3
            sql = "SELECT Nam, Kana FROM UsrM WHERE Ind='" & ind & "' ORDER BY Kana"
        Else
            '産健ｾﾝﾀｰ
            dbConnectionPath = TopForm.DB_Reserve
            sql = "SELECT distinct Nam, Kana FROM RsvD WHERE Ind='" & ind & "' ORDER BY Kana"
        End If

        'データ取得
        cnn.Open(dbConnectionPath)
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        While Not rs.EOF
            Dim nam As String = Util.checkDBNullValue(rs.Fields("Nam").Value)
            personListBox.Items.Add(nam)
            rs.MoveNext()
        End While
        rs.Close()
        cnn.Close()
    End Sub

    ''' <summary>
    ''' 参照タブ：氏名リスト値変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub personListBox_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles personListBox.SelectedValueChanged
        '入力エリアのクリア
        inputClear()

        '選択された企業名
        Dim selectedInd As String = referenceListBox.SelectedItem

        '選択された名前
        Dim selectedName As String = personListBox.SelectedItem


        'DBの選択
        Dim cnn As New ADODB.Connection
        Dim dbConnectionPath As String
        Dim sql As String
        If diagnoseButton.Checked = True Then
            '健診
            dbConnectionPath = TopForm.DB_Diagnose
            sql = "SELECT Nam, Kana, Birth, Sex, Ind FROM UsrM WHERE Ind='" & selectedInd & "' AND Nam='" & selectedName & "'"
            If selectedInd = "個人健診" Then
                syuBox.Text = "個人"
            ElseIf selectedInd = "特定健診" Then
                syuBox.Text = "特定"
            ElseIf selectedInd = "がん検診" Then
                syuBox.Text = "がん"
            Else
                syuBox.Text = "企業"
            End If
        ElseIf healthButton.Checked = True Then
            '生活習慣病
            dbConnectionPath = TopForm.DB_Health3
            sql = "SELECT Nam, Kana, Birth, Sex, Ind FROM UsrM WHERE Ind='" & selectedInd & "' AND Nam='" & selectedName & "'"
            syuBox.Text = "生活"
        Else
            '産健ｾﾝﾀｰ
            dbConnectionPath = TopForm.DB_Reserve
            sql = "SELECT Nam, Kana, Birth, Sex, Ind FROM RsvD WHERE Ind='" & selectedInd & "' AND Nam='" & selectedName & "'"
            syuBox.Text = "企業"
        End If

        'データ取得、各テキストボックスへ反映
        cnn.Open(dbConnectionPath)
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Dim ind As String = Util.checkDBNullValue(rs.Fields("Ind").Value)
            Dim nam As String = Util.checkDBNullValue(rs.Fields("Nam").Value)
            Dim kana As String = Util.checkDBNullValue(rs.Fields("Kana").Value)
            Dim sex As String = Util.checkDBNullValue(rs.Fields("Sex").Value)
            Dim birth As String = Util.checkDBNullValue(rs.Fields("Birth").Value)

            indBox.Text = ind
            namBox.Text = nam
            kanaBox.Text = kana
            If sex = "男" OrElse sex = "女" Then
                sexBox.Text = sex
            ElseIf sex = 1 Then
                sexBox.Text = "男"
            ElseIf sex = 2 Then
                sexBox.Text = "女"
            End If
            '生活習慣病データの生年月日のみ和暦なので
            If healthButton.Checked Then
                birthBox.setWarekiStr(birth)
            Else
                birthBox.setADStr(birth)
            End If
        End If
        rs.Close()
        cnn.Close()
    End Sub

    ''' <summary>
    ''' 種別ボックス値変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub syuBox_TextChanged(sender As Object, e As System.EventArgs) Handles syuBox.TextChanged
        Dim selectedValue As String = syuBox.Text
        If selectedValue = "個人" Then
            reserveTabControl.SelectedTab = personalTabPage
        ElseIf selectedValue = "企業" Then
            reserveTabControl.SelectedTab = companyTabPage
        ElseIf selectedValue = "生活" Then
            reserveTabControl.SelectedTab = lifeStyleTabPage
        ElseIf selectedValue = "がん" Then
            reserveTabControl.SelectedTab = cancerTabPage
        ElseIf selectedValue = "特定" Then
            reserveTabControl.SelectedTab = specificTabPage
        End If
    End Sub

    ''' <summary>
    ''' 腰椎XPチェックボックス値変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LumbarXP_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles personalLumbarXP.CheckedChanged, companyLumbarXP.CheckedChanged, lifeStyleLumbarXP.CheckedChanged
        Dim xpChk As CheckBox = DirectCast(sender, CheckBox)
        If xpChk.Checked Then
            Dim inputText As String = memo1Box.Text '入力済みテキスト
            If inputText.IndexOf("腰椎XP") < 0 Then
                If inputText = "" Then
                    memo1Box.Text = "腰椎XP"
                Else
                    memo1Box.Text = inputText & "、腰椎XP"
                End If
            End If
        Else
            memo1Box.Text = memo1Box.Text.Replace("腰椎XP", "")
        End If
    End Sub

    ''' <summary>
    ''' 特定タブ：保険種別ボックス値変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub insuranceTypeBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles insuranceTypeBox.SelectedIndexChanged
        '生年月日と現在日付から年齢計算
        Dim age As Integer = Util.calcAge(birthBox.getADStr(), Today.ToString("yyyy/MM/dd"))

        '60歳以上ならば心電図にチェック
        If age >= 60 Then
            checkECG.Checked = True
        Else
            checkECG.Checked = False
        End If

        If insuranceTypeBox.Text = "国保" Then
            biochemistryBox.Text = "○"
            bloodSugarBox.Text = "○"
            anemiaBox.Text = "○"
        ElseIf insuranceTypeBox.Text = "社・家" OrElse insuranceTypeBox.Text = "共済" Then
            biochemistryBox.Text = "○"
            bloodSugarBox.Text = "○"
            anemiaBox.Text = "×"
        End If
    End Sub

    ''' <summary>
    ''' 生活タブ：窓口負担表示ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnLifeStyle_Click(sender As System.Object, e As System.EventArgs) Handles btnLifeStyle.Click
        If lifeStyleStomachBa.Checked = True Then
            lifeStyleWindowPay.Text = "7038"
        Else
            lifeStyleWindowPay.Text = "3750"
        End If
    End Sub

    ''' <summary>
    ''' 特定タブ：窓口負担表示ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnTok_Click(sender As System.Object, e As System.EventArgs) Handles btnTok.Click
        Dim totalPay As Integer = 0

        If insuranceTypeBox.Text = "社・家" Then
            totalPay = totalPay + 1160
        End If

        If cardiacBox.Text = "○" AndAlso couponTicketBox.Checked <> True Then
            totalPay = totalPay + 1550
        End If

        If gastricCancerRiskBox.Text = "○" AndAlso couponTicketBox.Checked <> True Then
            totalPay = totalPay + 3600
        End If

        If diabetesBox.Text = "○" AndAlso couponTicketBox.Checked <> True Then
            totalPay = totalPay + 1400
        End If

        If prostateCancerBox.Text = "○" AndAlso couponTicketBox.Checked <> True Then
            totalPay = totalPay + 1550
        End If

        specificWindowPay.Text = totalPay
    End Sub

    ''' <summary>
    ''' がんタブ：窓口負担表示ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnGan_Click(sender As System.Object, e As System.EventArgs) Handles btnGan.Click
        Dim totalPay As Integer = 0
        Dim age As Integer = 0

        '入力生年月日から年齢取得
        Dim birth As String = birthBox.getADStr()
        age = Util.calcAge(birth, Today.ToString("yyyy/MM/dd"))

        If gastricCancerBox.Checked = True AndAlso age < 70 Then
            totalPay = totalPay + 1000
        End If

        If colorectalCancerBox.Checked = True AndAlso age < 70 Then
            totalPay = totalPay + 1000
        End If

        cancerWindowPay.Text = totalPay
    End Sub

    ''' <summary>
    ''' 登録ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRegist_Click(sender As System.Object, e As System.EventArgs) Handles btnRegist.Click
        '入力内容
        Dim syu As String = syuBox.Text '種別
        Dim ind As String = indBox.Text '企業名
        Dim nam As String = namBox.Text '氏名
        Dim kana As String = kanaBox.Text 'カナ
        Dim sex As String = sexBox.Text '性別
        Dim birth As String = birthBox.getADStr() '生年月日
        Dim reserveYmd As String = reserveYmdBox.getADStr() '予約日
        Dim apm As String = apmBox.Text 'AmPm
        Dim memo1 As String = memo1Box.Text 'メモ１
        '使用していないので空
        Dim ymd2 As String = ""
        Dim send As String = ""
        Dim memo2 As String = ""

        '必須項目チェック(種別、企業名、氏名、カナ、性別、生年月日、予約日)
        If syu = "" Then
            MsgBox("種別が未入力です", MsgBoxStyle.Exclamation)
            syuBox.Focus()
            Return
        ElseIf ind = "" Then
            MsgBox("企業名が未入力です", MsgBoxStyle.Exclamation)
            indBox.Focus()
            Return
        ElseIf nam = "" Then
            MsgBox("氏名が未入力です", MsgBoxStyle.Exclamation)
            namBox.Focus()
            Return
        ElseIf kana = "" Then
            MsgBox("カナが未入力です", MsgBoxStyle.Exclamation)
            kanaBox.Focus()
            Return
        ElseIf sex = "" Then
            MsgBox("性別が未入力です", MsgBoxStyle.Exclamation)
            sexBox.Focus()
            Return
        ElseIf birth = "" Then
            MsgBox("生年月日が未入力です", MsgBoxStyle.Exclamation)
            birthBox.Focus()
            Return
        ElseIf reserveYmd = "" Then
            MsgBox("予約日が未入力です", MsgBoxStyle.Exclamation)
            reserveYmdBox.Focus()
            Return
        End If

        '各タブ部分の入力内容
        Dim kjn(5) As Integer
        Dim kig(5) As Integer
        Dim sei(3) As Integer
        Dim tok(7) As String
        Dim tok9 As Integer = 0
        Dim gan(1) As Integer
        Dim sanken As String = ""
        Dim windowPay As Integer = 0
        Dim lumbarXP As Integer = 0
        If syu = "個人" Then
            kjn(0) = If(personalBlood.Checked, 1, 0)
            kjn(1) = If(personalElectro.Checked, 1, 0)
            kjn(2) = If(personalChestXP.Checked, 1, 0)
            kjn(3) = If(personalUltrasonic.Checked, 1, 0)
            kjn(4) = If(personalStomachBa.Checked, 1, 0)
            kjn(5) = If(personalStomachCamera.Checked, 1, 0)
            lumbarXP = If(personalLumbarXP.Checked, 1, 0)
            windowPay = If(personalWindowPay.Text = "", 0, Integer.Parse(personalWindowPay.Text))
        ElseIf syu = "企業" Then
            kig(0) = If(companyBlood.Checked, 1, 0)
            kig(1) = If(companyElectro.Checked, 1, 0)
            kig(2) = If(companyChestXP.Checked, 1, 0)
            kig(3) = If(companyUltrasonic.Checked, 1, 0)
            kig(4) = If(companyStomachBa.Checked, 1, 0)
            kig(5) = If(companyStomachCamera.Checked, 1, 0)
            lumbarXP = If(companyLumbarXP.Checked, 1, 0)
            windowPay = If(companyWindowPay.Text = "", 0, Integer.Parse(companyWindowPay.Text))
        ElseIf syu = "生活" Then
            sei(2) = If(lifeStyleStomachBa.Checked, 1, 0)
            lumbarXP = If(lifeStyleLumbarXP.Checked, 1, 0)
            windowPay = If(lifeStyleWindowPay.Text = "", 0, Integer.Parse(lifeStyleWindowPay.Text))
        ElseIf syu = "特定" Then
            tok(0) = insuranceTypeBox.Text
            tok(1) = biochemistryBox.Text
            tok(2) = bloodSugarBox.Text
            tok(3) = anemiaBox.Text
            tok(4) = cardiacBox.Text
            tok(5) = gastricCancerRiskBox.Text
            tok(6) = diabetesBox.Text
            tok(7) = prostateCancerBox.Text
            tok9 = If(couponTicketBox.Checked, 1, 0)
            windowPay = If(specificWindowPay.Text = "", 0, Integer.Parse(specificWindowPay.Text))
            '心電図
            kig(1) = If(checkECG.Checked, 1, 0)
        ElseIf syu = "がん" Then
            gan(0) = If(gastricCancerBox.Checked, 1, 0)
            gan(1) = If(colorectalCancerBox.Checked, 1, 0)
            windowPay = If(cancerWindowPay.Text = "", 0, Integer.Parse(cancerWindowPay.Text))
        End If

        '登録
        Dim newFlg As Boolean = False
        Dim cnn As New ADODB.Connection
        cnn.Open(TopForm.DB_Reserve)
        Dim rs As New ADODB.Recordset
        Dim sql As String = "select top 1 * from RsvD where Syu = '" & syu & "' and Ind = '" & ind & "' and Ymd='" & reserveYmd & "' and Nam='" & nam & "' and Kana = '" & kana & "' and Birth='" & birth & "'"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount <= 0 Then
            rs.AddNew()
            newFlg = True
        End If
        rs.Fields("Ymd").Value = reserveYmd
        rs.Fields("Apm").Value = apm
        rs.Fields("Syu").Value = syu
        rs.Fields("Nam").Value = nam
        rs.Fields("Kana").Value = kana
        rs.Fields("Sex").Value = sex
        rs.Fields("Birth").Value = birth
        rs.Fields("Ind").Value = ind
        rs.Fields("Ymd2").Value = ymd2
        rs.Fields("Send").Value = send
        rs.Fields("Memo1").Value = memo1
        rs.Fields("Memo2").Value = memo2
        For i As Integer = 1 To 6
            rs.Fields("Kjn" & i).Value = kjn(i - 1)
            rs.Fields("Kig" & i).Value = kig(i - 1)
        Next
        For i As Integer = 1 To 4
            rs.Fields("Sei" & i).Value = sei(i - 1)
        Next
        For i As Integer = 1 To 8
            rs.Fields("Tok" & i).Value = tok(i - 1)
        Next
        rs.Fields("Tok9").Value = tok9
        rs.Fields("Gan1").Value = gan(0)
        rs.Fields("Gan2").Value = gan(1)
        rs.Fields("Futan").Value = windowPay
        rs.Fields("Sanken").Value = sanken
        rs.Fields("LumbarXP").Value = lumbarXP
        rs.Update()
        rs.Close()
        cnn.Close()
        If newFlg Then
            MsgBox("登録しました。", MsgBoxStyle.Information)
        Else
            MsgBox("変更しました。", MsgBoxStyle.Information)
        End If

        '本日の追加変更登録
        registTodayChange(syu, ind, reserveYmd, apm, nam, kana, sex, birth, memo1, windowPay, "A")

        '再表示
        btnSelectClear.PerformClick()
        displayDgvReserve(ymBox.getADYmStr())
    End Sub

    ''' <summary>
    ''' 削除ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        '選択行チェック
        Dim selectedRowsCount As Integer = 0
        For i = 0 To dgvReserve.Rows.Count - 1
            If dgvReserve.Rows.Item(i).Selected = True Then
                selectedRowsCount = selectedRowsCount + 1
            End If
        Next
        If selectedRowsCount <> 1 Then
            MsgBox("削除対象の行を１つ選択してください")
            Return
        End If

        '選択情報
        Dim index As Integer = Util.checkDBNullValue(dgvReserve.CurrentRow.Index)
        Dim ind As String = Util.checkDBNullValue(dgvReserve("Ind", index).Value)
        Dim birth As String = Util.checkDBNullValue(dgvReserve("Birth", index).Value)
        Dim nam As String = Util.checkDBNullValue(dgvReserve("Nam", index).Value)
        Dim kana As String = Util.checkDBNullValue(dgvReserve("Kana", index).Value)
        Dim reserveYmd As String = Util.checkDBNullValue(dgvReserve("Ymd", index).Value)
        Dim syu As String = Util.checkDBNullValue(dgvReserve("Syu", index).Value)
        Dim apm As String = Util.checkDBNullValue(dgvReserve("Apm", index).Value)
        Dim sex As String = Util.checkDBNullValue(dgvReserve("Sex", index).Value)
        Dim memo1 As String = Util.checkDBNullValue(dgvReserve("Memo1", index).Value)
        Dim futan As String = Util.checkDBNullValue(dgvReserve("Futan", index).Value)

        '削除処理
        Dim cnn As New ADODB.Connection
        cnn.Open(TopForm.DB_Reserve)
        Dim sql As String = "delete from RsvD where Ind = '" & ind & "' and Kana = '" & kana & "' and Nam='" & nam & "' AND Birth='" & birth & "' AND Ymd='" & reserveYmd & "'"
        Dim cmd As New ADODB.Command
        cmd.ActiveConnection = cnn
        cmd.CommandText = sql
        cmd.Execute()
        cnn.Close()
        MsgBox("削除しました", MsgBoxStyle.Information)
        inputClear()
        tabPageInputClear()
        reserveTabControl.SelectedTab = referenceTabPage

        '本日の追加変更登録
        registTodayChange(syu, ind, reserveYmd, apm, nam, kana, sex, birth, memo1, futan, "D")

        '再表示
        displayDgvReserve(ymBox.getADYmStr())
    End Sub

    ''' <summary>
    ''' 印刷ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Dim selectedRowsCount As Integer = dgvReserve.SelectedRows.Count '選択行数
        Dim rowsCount As Integer = dgvReserve.Rows.Count '全行数
        '印刷対象の行番号リスト作成
        Dim selectedRowsIndexList As New List(Of Integer)
        If selectedRowsCount = 0 Then '未選択時は全ての行が対象とする
            For i = 0 To rowsCount - 1
                selectedRowsIndexList.Add(i)
            Next
        Else
            For Each row As DataGridViewRow In dgvReserve.SelectedRows
                selectedRowsIndexList.Add(row.Index)
            Next
            selectedRowsIndexList.Sort()
        End If

        '貼り付けデータ作成
        Dim dataList As New List(Of String(,))
        Dim dataArray(34, 30) As String
        Dim borderIndexList As New List(Of Integer())
        Dim indexList As New List(Of Integer)
        Dim arrayRowIndex As Integer = 0
        Dim count As Integer = 1
        For Each index As Integer In selectedRowsIndexList
            If arrayRowIndex = 35 Then
                dataList.Add(dataArray.Clone())
                Array.Clear(dataArray, 0, dataArray.Length)
                arrayRowIndex = 0

                borderIndexList.Add(indexList.ToArray())
                indexList.Clear()
            End If

            'No.
            dataArray(arrayRowIndex, 0) = count
            '予定
            Dim formattedDate As String = Util.checkDBNullValue(dgvReserve("Ymd", index).FormattedValue)
            dataArray(arrayRowIndex, 1) = formattedDate '日付
            dataArray(arrayRowIndex, 2) = Util.checkDBNullValue(dgvReserve("Day", index).FormattedValue) '曜日
            dataArray(arrayRowIndex, 3) = Util.checkDBNullValue(dgvReserve("Apm", index).FormattedValue) '時間
            If arrayRowIndex <> 0 AndAlso formattedDate <> "" Then
                '罫線リストへインデックス追加
                indexList.Add(arrayRowIndex + 1)
            End If
            '種別
            Dim syu As String = Util.checkDBNullValue(dgvReserve("Syu", index).Value)
            dataArray(arrayRowIndex, 4) = syu
            '氏名
            dataArray(arrayRowIndex, 5) = Util.checkDBNullValue(dgvReserve("Nam", index).Value)
            'カナ
            dataArray(arrayRowIndex, 6) = Util.checkDBNullValue(dgvReserve("Kana", index).Value)
            '性別
            dataArray(arrayRowIndex, 7) = Util.checkDBNullValue(dgvReserve("Sex", index).Value)
            '生年月日
            dataArray(arrayRowIndex, 8) = Util.checkDBNullValue(dgvReserve("Birth", index).FormattedValue)
            '年齢
            dataArray(arrayRowIndex, 9) = dgvReserve("Age", index).Value
            '企業名
            dataArray(arrayRowIndex, 10) = Util.checkDBNullValue(dgvReserve("Ind", index).Value)
            '窓口負担
            Dim futan As String = Util.checkDBNullValue(dgvReserve("Futan", index).Value)
            dataArray(arrayRowIndex, 13) = If(futan = 0, "", futan)
            'メモ
            Dim memo As String = Util.checkDBNullValue(dgvReserve("Memo1", index).Value)
            dataArray(arrayRowIndex, 14) = memo
            '血液
            If syu = "個人" Then
                Dim kjn1 As Integer = dgvReserve("Kjn1", index).Value
                dataArray(arrayRowIndex, 15) = If(kjn1 = 1, "1", "")
            ElseIf syu = "企業" Then
                Dim kig1 As Integer = dgvReserve("Kig1", index).Value
                dataArray(arrayRowIndex, 15) = If(kig1 = 1, "1", "")
            ElseIf syu = "生活" Then
                dataArray(arrayRowIndex, 15) = 1
            End If
            '心電図
            If syu = "個人" Then
                Dim kjn2 As Integer = dgvReserve("Kjn2", index).Value
                dataArray(arrayRowIndex, 16) = If(kjn2 = 1, "1", "")
            ElseIf syu = "企業" OrElse syu = "特定" Then
                Dim kig2 As Integer = dgvReserve("Kig2", index).Value
                dataArray(arrayRowIndex, 16) = If(kig2 = 1, "1", "")
            ElseIf syu = "生活" Then
                dataArray(arrayRowIndex, 16) = 1
            End If
            '胸部XP
            If syu = "個人" Then
                Dim kjn3 As Integer = dgvReserve("Kjn3", index).Value
                dataArray(arrayRowIndex, 17) = If(kjn3 = 1, "1", "")
            ElseIf syu = "企業" Then
                Dim kig3 As Integer = dgvReserve("Kig3", index).Value
                dataArray(arrayRowIndex, 17) = If(kig3 = 1, "1", "")
            ElseIf syu = "生活" Then
                dataArray(arrayRowIndex, 17) = 1
                If memo.IndexOf("レントゲン無") >= 0 Then
                    dataArray(arrayRowIndex, 17) = ""
                End If
            End If
            '腰椎XP
            Dim lumbarXP As Integer = dgvReserve("LumbarXP", index).Value
            dataArray(arrayRowIndex, 18) = If(lumbarXP = 1, "2", "")
            '超音波
            If syu = "個人" Then
                Dim kjn4 As Integer = dgvReserve("Kjn4", index).Value
                dataArray(arrayRowIndex, 19) = If(kjn4 = 1, "1", "")
            ElseIf syu = "企業" Then
                Dim kig4 As Integer = dgvReserve("Kig4", index).Value
                dataArray(arrayRowIndex, 19) = If(kig4 = 1, "1", "")
            End If
            '胃Ba
            If syu = "個人" Then
                Dim kjn5 As Integer = dgvReserve("Kjn5", index).Value
                dataArray(arrayRowIndex, 20) = If(kjn5 = 1, "1", "")
            ElseIf syu = "企業" Then
                Dim kig5 As Integer = dgvReserve("Kig5", index).Value
                dataArray(arrayRowIndex, 20) = If(kig5 = 1, "1", "")
            ElseIf syu = "生活" Then
                Dim sei3 As Integer = dgvReserve("Sei3", index).Value
                dataArray(arrayRowIndex, 20) = If(sei3 = 1, "1", "")
            End If
            '保険種別
            Dim tok1 As String = Util.checkDBNullValue(dgvReserve("Tok1", index).Value)
            dataArray(arrayRowIndex, 22) = tok1
            '尿採取
            Dim tok7 As String = Util.checkDBNullValue(dgvReserve("Tok7", index).Value)
            dataArray(arrayRowIndex, 23) = If(tok7 = "○", "1", "")
            '採血数
            dataArray(arrayRowIndex, 24) = If(tok1 = "国保", "3", If(tok1 = "社・家" OrElse tok1 = "共済", "2", ""))
            '大腸がん
            Dim gan2 As Integer = dgvReserve("Gan2", index).Value
            dataArray(arrayRowIndex, 26) = If(gan2 = 1, "1", "")
            If memo.IndexOf("大腸") >= 0 Then
                dataArray(arrayRowIndex, 26) = "1"
            End If
            'ABC
            Dim tok6 As String = Util.checkDBNullValue(dgvReserve("Tok6", index).Value)
            dataArray(arrayRowIndex, 27) = If(tok6 = "○", "1", "")
            '心機能
            Dim tok5 As String = Util.checkDBNullValue(dgvReserve("Tok5", index).Value)
            dataArray(arrayRowIndex, 28) = If(tok5 = "○", "1", "")
            'PSA
            Dim tok8 As String = Util.checkDBNullValue(dgvReserve("Tok8", index).Value)
            dataArray(arrayRowIndex, 29) = If(tok8 = "○", "1", "")
            '尿中Alb
            dataArray(arrayRowIndex, 30) = If(tok7 = "○", "1", "")

            arrayRowIndex += 1
            count += 1
        Next
        dataList.Add(dataArray.Clone())
        borderIndexList.Add(indexList.ToArray())

        'エクセル
        Dim objExcel As Excel.Application = CreateObject("Excel.Application")
        Dim objWorkBooks As Excel.Workbooks = objExcel.Workbooks
        Dim objWorkBook As Excel.Workbook = objWorkBooks.Open(TopForm.excelFilePass)
        Dim oSheet As Excel.Worksheet = objWorkBook.Worksheets("予定表")
        objExcel.Calculation = Excel.XlCalculation.xlCalculationManual
        objExcel.ScreenUpdating = False

        '年月
        oSheet.Range("G2").Value = ymBox.EraText & " 年 " & ymBox.MonthText & " 月"
        '印刷日時
        oSheet.Range("I2").Value = DateTime.Now.ToString()

        '必要枚数コピペ
        For i As Integer = 0 To dataList.Count - 2
            Dim xlPasteRange As Excel.Range = oSheet.Range("A" & (40 + (39 * i))) 'ペースト先
            oSheet.Rows("1:39").copy(xlPasteRange)
            oSheet.HPageBreaks.Add(oSheet.Range("A" & (40 + (39 * i)))) '改ページ
        Next

        'データ貼り付け
        For i As Integer = 0 To dataList.Count - 1
            oSheet.Range("B" & (4 + 39 * i), "AF" & (38 + 39 * i)).Value = dataList(i)

            For Each excelRowIndex As Integer In borderIndexList(i)
                Dim border As Excel.Border = oSheet.Range("B" & (39 * i + excelRowIndex + 3), "AF" & (39 * i + excelRowIndex + 3)).Borders(Excel.XlBordersIndex.xlEdgeTop)
                border.LineStyle = Excel.XlLineStyle.xlContinuous
                border.Weight = Excel.XlBorderWeight.xlThin
            Next
        Next

        objExcel.Calculation = Excel.XlCalculation.xlCalculationAutomatic
        objExcel.ScreenUpdating = True

        '変更保存確認ダイアログ非表示
        objExcel.DisplayAlerts = False

        '印刷
        If rbtnPrint.Checked = True Then
            oSheet.PrintOut()
        ElseIf rbtnPreview.Checked = True Then
            objExcel.Visible = True
            oSheet.PrintPreview(1)
        End If

        ' EXCEL解放
        objExcel.Quit()
        Marshal.ReleaseComObject(objWorkBook)
        Marshal.ReleaseComObject(objExcel)
        oSheet = Nothing
        objWorkBook = Nothing
        objExcel = Nothing
    End Sub

    ''' <summary>
    ''' 本日の追加変更登録
    ''' </summary>
    ''' <param name="syu">種別</param>
    ''' <param name="ind">企業名</param>
    ''' <param name="ymd">予約日</param>
    ''' <param name="apm">ampm</param>
    ''' <param name="nam">氏名</param>
    ''' <param name="kana">カナ</param>
    ''' <param name="sex">性別</param>
    ''' <param name="birth">生年月日</param>
    ''' <param name="memo1">メモ１</param>
    ''' <param name="futan">窓口負担金額</param>
    ''' <param name="type">A:(追加変更) or D:(削除)</param>
    ''' <remarks></remarks>
    Private Sub registTodayChange(syu As String, ind As String, ymd As String, apm As String, nam As String, kana As String, sex As String, birth As String, memo1 As String, futan As String, type As String)
        '本日日付
        Dim nowYmd As String = Today.ToString("yyyy/MM/dd")

        '本日日付より前の予約日の場合は何もしない
        If ymd < nowYmd Then
            Return
        End If

        '登録
        Dim cnn As New ADODB.Connection
        cnn.Open(TopForm.DB_Reserve)
        Dim rs As New ADODB.Recordset
        rs.Open("Change", cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        rs.AddNew()
        rs.Fields("AddDate").Value = nowYmd
        rs.Fields("Syu").Value = syu
        rs.Fields("Ind").Value = ind
        rs.Fields("Ymd").Value = ymd
        rs.Fields("Apm").Value = apm
        rs.Fields("Nam").Value = nam
        rs.Fields("Kana").Value = kana
        rs.Fields("Sex").Value = sex
        rs.Fields("Birth").Value = birth
        rs.Fields("Memo1").Value = memo1
        rs.Fields("Futan").Value = futan
        rs.Fields("Type").Value = type
        rs.Update()
        rs.Close()
        cnn.Close()

        '本日の追加変更フォームの更新(再表示処理)
        TopForm.todayChangeForm.displayDgvToday()
    End Sub
End Class