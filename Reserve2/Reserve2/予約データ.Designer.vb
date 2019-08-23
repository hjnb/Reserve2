<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 予約データ
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.syuBox = New System.Windows.Forms.ComboBox()
        Me.indBox = New System.Windows.Forms.TextBox()
        Me.namBox = New System.Windows.Forms.TextBox()
        Me.kanaBox = New System.Windows.Forms.TextBox()
        Me.birthBox = New ymdBox.ymdBox()
        Me.reserveYmdBox = New ymdBox.ymdBox()
        Me.sexBox = New System.Windows.Forms.ComboBox()
        Me.apmBox = New System.Windows.Forms.ComboBox()
        Me.memo1Box = New System.Windows.Forms.TextBox()
        Me.ymBox = New ymdBox.ymdBox()
        Me.dgvReserve = New System.Windows.Forms.DataGridView()
        Me.btnInputClear = New System.Windows.Forms.Button()
        Me.btnSelectClear = New System.Windows.Forms.Button()
        Me.rbtnPrint = New System.Windows.Forms.RadioButton()
        Me.rbtnPreview = New System.Windows.Forms.RadioButton()
        Me.reserveTabControl = New System.Windows.Forms.TabControl()
        Me.personalTabPage = New System.Windows.Forms.TabPage()
        Me.personalLumbarXP = New System.Windows.Forms.CheckBox()
        Me.personalWindowPay = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.personalNone = New System.Windows.Forms.RadioButton()
        Me.personalStomachCamera = New System.Windows.Forms.RadioButton()
        Me.personalStomachBa = New System.Windows.Forms.RadioButton()
        Me.personalUltrasonic = New System.Windows.Forms.CheckBox()
        Me.personalChestXP = New System.Windows.Forms.CheckBox()
        Me.personalElectro = New System.Windows.Forms.CheckBox()
        Me.personalBlood = New System.Windows.Forms.CheckBox()
        Me.companyTabPage = New System.Windows.Forms.TabPage()
        Me.companyLumbarXP = New System.Windows.Forms.CheckBox()
        Me.companyWindowPay = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.companyNone = New System.Windows.Forms.RadioButton()
        Me.companyStomachCamera = New System.Windows.Forms.RadioButton()
        Me.companyStomachBa = New System.Windows.Forms.RadioButton()
        Me.companyUltrasonic = New System.Windows.Forms.CheckBox()
        Me.companyChestXP = New System.Windows.Forms.CheckBox()
        Me.companyElectro = New System.Windows.Forms.CheckBox()
        Me.companyBlood = New System.Windows.Forms.CheckBox()
        Me.lifeStyleTabPage = New System.Windows.Forms.TabPage()
        Me.lifeStyleLumbarXP = New System.Windows.Forms.CheckBox()
        Me.lifeStyleWindowPay = New System.Windows.Forms.TextBox()
        Me.btnLifeStyle = New System.Windows.Forms.Button()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.lifeStyleNone = New System.Windows.Forms.RadioButton()
        Me.lifeStyleStomachCamera = New System.Windows.Forms.RadioButton()
        Me.lifeStyleStomachBa = New System.Windows.Forms.RadioButton()
        Me.specificTabPage = New System.Windows.Forms.TabPage()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.checkECG = New System.Windows.Forms.CheckBox()
        Me.gastricCancerRiskBox = New System.Windows.Forms.ComboBox()
        Me.diabetesBox = New System.Windows.Forms.ComboBox()
        Me.prostateCancerBox = New System.Windows.Forms.ComboBox()
        Me.cardiacBox = New System.Windows.Forms.ComboBox()
        Me.specificWindowPay = New System.Windows.Forms.TextBox()
        Me.btnTok = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.couponTicketBox = New System.Windows.Forms.CheckBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.anemiaBox = New System.Windows.Forms.ComboBox()
        Me.bloodSugarBox = New System.Windows.Forms.ComboBox()
        Me.biochemistryBox = New System.Windows.Forms.ComboBox()
        Me.insuranceTypeBox = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cancerTabPage = New System.Windows.Forms.TabPage()
        Me.cancerWindowPay = New System.Windows.Forms.TextBox()
        Me.btnGan = New System.Windows.Forms.Button()
        Me.colorectalCancerBox = New System.Windows.Forms.CheckBox()
        Me.gastricCancerBox = New System.Windows.Forms.CheckBox()
        Me.referenceTabPage = New System.Windows.Forms.TabPage()
        Me.personListBox = New System.Windows.Forms.ListBox()
        Me.referenceListBox = New System.Windows.Forms.ListBox()
        Me.sankenCenterButton = New System.Windows.Forms.RadioButton()
        Me.healthButton = New System.Windows.Forms.RadioButton()
        Me.diagnoseButton = New System.Windows.Forms.RadioButton()
        Me.btnRegist = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.dgvReserve, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.reserveTabControl.SuspendLayout()
        Me.personalTabPage.SuspendLayout()
        Me.companyTabPage.SuspendLayout()
        Me.lifeStyleTabPage.SuspendLayout()
        Me.specificTabPage.SuspendLayout()
        Me.cancerTabPage.SuspendLayout()
        Me.referenceTabPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(21, 159)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 12)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "AmPm"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(21, 139)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 12)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "予約日"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(21, 118)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "生年月日"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(22, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "性別"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(22, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 12)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "カナ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(22, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "氏名"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(22, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "企業名"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(22, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "種別"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(26, 191)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(22, 12)
        Me.Label11.TabIndex = 45
        Me.Label11.Text = "メモ"
        '
        'syuBox
        '
        Me.syuBox.FormattingEnabled = True
        Me.syuBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.syuBox.Items.AddRange(New Object() {"個人", "企業", "生活", "特定", "がん"})
        Me.syuBox.Location = New System.Drawing.Point(79, 20)
        Me.syuBox.Name = "syuBox"
        Me.syuBox.Size = New System.Drawing.Size(121, 20)
        Me.syuBox.TabIndex = 47
        '
        'indBox
        '
        Me.indBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.indBox.Location = New System.Drawing.Point(79, 39)
        Me.indBox.Name = "indBox"
        Me.indBox.Size = New System.Drawing.Size(121, 19)
        Me.indBox.TabIndex = 48
        '
        'namBox
        '
        Me.namBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.namBox.Location = New System.Drawing.Point(79, 57)
        Me.namBox.Name = "namBox"
        Me.namBox.Size = New System.Drawing.Size(121, 19)
        Me.namBox.TabIndex = 49
        '
        'kanaBox
        '
        Me.kanaBox.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.kanaBox.Location = New System.Drawing.Point(79, 75)
        Me.kanaBox.Name = "kanaBox"
        Me.kanaBox.Size = New System.Drawing.Size(121, 19)
        Me.kanaBox.TabIndex = 50
        '
        'birthBox
        '
        Me.birthBox.boxType = 0
        Me.birthBox.DateText = ""
        Me.birthBox.EraLabelText = "R01"
        Me.birthBox.EraText = ""
        Me.birthBox.Location = New System.Drawing.Point(78, 113)
        Me.birthBox.MonthLabelText = "08"
        Me.birthBox.MonthText = ""
        Me.birthBox.Name = "birthBox"
        Me.birthBox.Size = New System.Drawing.Size(86, 20)
        Me.birthBox.TabIndex = 52
        Me.birthBox.textReadOnly = False
        '
        'reserveYmdBox
        '
        Me.reserveYmdBox.boxType = 0
        Me.reserveYmdBox.DateText = ""
        Me.reserveYmdBox.EraLabelText = "R01"
        Me.reserveYmdBox.EraText = ""
        Me.reserveYmdBox.Location = New System.Drawing.Point(78, 135)
        Me.reserveYmdBox.MonthLabelText = "08"
        Me.reserveYmdBox.MonthText = ""
        Me.reserveYmdBox.Name = "reserveYmdBox"
        Me.reserveYmdBox.Size = New System.Drawing.Size(86, 20)
        Me.reserveYmdBox.TabIndex = 53
        Me.reserveYmdBox.textReadOnly = False
        '
        'sexBox
        '
        Me.sexBox.FormattingEnabled = True
        Me.sexBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.sexBox.Items.AddRange(New Object() {"男", "女"})
        Me.sexBox.Location = New System.Drawing.Point(79, 93)
        Me.sexBox.Name = "sexBox"
        Me.sexBox.Size = New System.Drawing.Size(44, 20)
        Me.sexBox.TabIndex = 51
        '
        'apmBox
        '
        Me.apmBox.FormattingEnabled = True
        Me.apmBox.Items.AddRange(New Object() {" 9:00", "10:30", "11:00", "13:00", "13:30", "15:00", "15:30"})
        Me.apmBox.Location = New System.Drawing.Point(79, 156)
        Me.apmBox.Name = "apmBox"
        Me.apmBox.Size = New System.Drawing.Size(121, 20)
        Me.apmBox.TabIndex = 54
        '
        'memo1Box
        '
        Me.memo1Box.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.memo1Box.Location = New System.Drawing.Point(78, 188)
        Me.memo1Box.Name = "memo1Box"
        Me.memo1Box.Size = New System.Drawing.Size(167, 19)
        Me.memo1Box.TabIndex = 55
        '
        'ymBox
        '
        Me.ymBox.boxType = 7
        Me.ymBox.DateText = ""
        Me.ymBox.EraLabelText = "R01"
        Me.ymBox.EraText = ""
        Me.ymBox.Location = New System.Drawing.Point(24, 249)
        Me.ymBox.MonthLabelText = "08"
        Me.ymBox.MonthText = ""
        Me.ymBox.Name = "ymBox"
        Me.ymBox.Size = New System.Drawing.Size(120, 46)
        Me.ymBox.TabIndex = 60
        Me.ymBox.textReadOnly = False
        '
        'dgvReserve
        '
        Me.dgvReserve.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReserve.Location = New System.Drawing.Point(24, 312)
        Me.dgvReserve.Name = "dgvReserve"
        Me.dgvReserve.RowTemplate.Height = 21
        Me.dgvReserve.Size = New System.Drawing.Size(689, 264)
        Me.dgvReserve.TabIndex = 57
        '
        'btnInputClear
        '
        Me.btnInputClear.Location = New System.Drawing.Point(170, 220)
        Me.btnInputClear.Name = "btnInputClear"
        Me.btnInputClear.Size = New System.Drawing.Size(75, 23)
        Me.btnInputClear.TabIndex = 58
        Me.btnInputClear.Text = "入力クリア"
        Me.btnInputClear.UseVisualStyleBackColor = True
        '
        'btnSelectClear
        '
        Me.btnSelectClear.Location = New System.Drawing.Point(170, 272)
        Me.btnSelectClear.Name = "btnSelectClear"
        Me.btnSelectClear.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectClear.TabIndex = 59
        Me.btnSelectClear.Text = "選択解除"
        Me.btnSelectClear.UseVisualStyleBackColor = True
        '
        'rbtnPrint
        '
        Me.rbtnPrint.AutoSize = True
        Me.rbtnPrint.Location = New System.Drawing.Point(644, 278)
        Me.rbtnPrint.Name = "rbtnPrint"
        Me.rbtnPrint.Size = New System.Drawing.Size(47, 16)
        Me.rbtnPrint.TabIndex = 65
        Me.rbtnPrint.Text = "印刷"
        Me.rbtnPrint.UseVisualStyleBackColor = True
        '
        'rbtnPreview
        '
        Me.rbtnPreview.AutoSize = True
        Me.rbtnPreview.Location = New System.Drawing.Point(644, 256)
        Me.rbtnPreview.Name = "rbtnPreview"
        Me.rbtnPreview.Size = New System.Drawing.Size(67, 16)
        Me.rbtnPreview.TabIndex = 64
        Me.rbtnPreview.Text = "プレビュー"
        Me.rbtnPreview.UseVisualStyleBackColor = True
        '
        'reserveTabControl
        '
        Me.reserveTabControl.Controls.Add(Me.personalTabPage)
        Me.reserveTabControl.Controls.Add(Me.companyTabPage)
        Me.reserveTabControl.Controls.Add(Me.lifeStyleTabPage)
        Me.reserveTabControl.Controls.Add(Me.specificTabPage)
        Me.reserveTabControl.Controls.Add(Me.cancerTabPage)
        Me.reserveTabControl.Controls.Add(Me.referenceTabPage)
        Me.reserveTabControl.Location = New System.Drawing.Point(319, 20)
        Me.reserveTabControl.Name = "reserveTabControl"
        Me.reserveTabControl.SelectedIndex = 0
        Me.reserveTabControl.Size = New System.Drawing.Size(394, 221)
        Me.reserveTabControl.TabIndex = 63
        '
        'personalTabPage
        '
        Me.personalTabPage.BackColor = System.Drawing.Color.White
        Me.personalTabPage.Controls.Add(Me.personalLumbarXP)
        Me.personalTabPage.Controls.Add(Me.personalWindowPay)
        Me.personalTabPage.Controls.Add(Me.Label13)
        Me.personalTabPage.Controls.Add(Me.personalNone)
        Me.personalTabPage.Controls.Add(Me.personalStomachCamera)
        Me.personalTabPage.Controls.Add(Me.personalStomachBa)
        Me.personalTabPage.Controls.Add(Me.personalUltrasonic)
        Me.personalTabPage.Controls.Add(Me.personalChestXP)
        Me.personalTabPage.Controls.Add(Me.personalElectro)
        Me.personalTabPage.Controls.Add(Me.personalBlood)
        Me.personalTabPage.Location = New System.Drawing.Point(4, 22)
        Me.personalTabPage.Name = "personalTabPage"
        Me.personalTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.personalTabPage.Size = New System.Drawing.Size(386, 195)
        Me.personalTabPage.TabIndex = 0
        Me.personalTabPage.Text = "個人"
        '
        'personalLumbarXP
        '
        Me.personalLumbarXP.AutoSize = True
        Me.personalLumbarXP.Location = New System.Drawing.Point(127, 77)
        Me.personalLumbarXP.Name = "personalLumbarXP"
        Me.personalLumbarXP.Size = New System.Drawing.Size(62, 16)
        Me.personalLumbarXP.TabIndex = 21
        Me.personalLumbarXP.Text = "腰椎XP"
        Me.personalLumbarXP.UseVisualStyleBackColor = True
        '
        'personalWindowPay
        '
        Me.personalWindowPay.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.personalWindowPay.Location = New System.Drawing.Point(306, 157)
        Me.personalWindowPay.Name = "personalWindowPay"
        Me.personalWindowPay.Size = New System.Drawing.Size(53, 19)
        Me.personalWindowPay.TabIndex = 20
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(247, 160)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 12)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "窓口負担"
        '
        'personalNone
        '
        Me.personalNone.AutoSize = True
        Me.personalNone.Location = New System.Drawing.Point(200, 128)
        Me.personalNone.Name = "personalNone"
        Me.personalNone.Size = New System.Drawing.Size(42, 16)
        Me.personalNone.TabIndex = 20
        Me.personalNone.Text = "なし"
        Me.personalNone.UseVisualStyleBackColor = True
        '
        'personalStomachCamera
        '
        Me.personalStomachCamera.AutoSize = True
        Me.personalStomachCamera.Location = New System.Drawing.Point(127, 128)
        Me.personalStomachCamera.Name = "personalStomachCamera"
        Me.personalStomachCamera.Size = New System.Drawing.Size(60, 16)
        Me.personalStomachCamera.TabIndex = 20
        Me.personalStomachCamera.TabStop = True
        Me.personalStomachCamera.Text = "胃カメラ"
        Me.personalStomachCamera.UseVisualStyleBackColor = True
        '
        'personalStomachBa
        '
        Me.personalStomachBa.AutoSize = True
        Me.personalStomachBa.Location = New System.Drawing.Point(46, 128)
        Me.personalStomachBa.Name = "personalStomachBa"
        Me.personalStomachBa.Size = New System.Drawing.Size(71, 16)
        Me.personalStomachBa.TabIndex = 20
        Me.personalStomachBa.TabStop = True
        Me.personalStomachBa.Text = "胃バリウム"
        Me.personalStomachBa.UseVisualStyleBackColor = True
        '
        'personalUltrasonic
        '
        Me.personalUltrasonic.AutoSize = True
        Me.personalUltrasonic.Location = New System.Drawing.Point(46, 99)
        Me.personalUltrasonic.Name = "personalUltrasonic"
        Me.personalUltrasonic.Size = New System.Drawing.Size(60, 16)
        Me.personalUltrasonic.TabIndex = 20
        Me.personalUltrasonic.Text = "超音波"
        Me.personalUltrasonic.UseVisualStyleBackColor = True
        '
        'personalChestXP
        '
        Me.personalChestXP.AutoSize = True
        Me.personalChestXP.Location = New System.Drawing.Point(46, 77)
        Me.personalChestXP.Name = "personalChestXP"
        Me.personalChestXP.Size = New System.Drawing.Size(62, 16)
        Me.personalChestXP.TabIndex = 20
        Me.personalChestXP.Text = "胸部XP"
        Me.personalChestXP.UseVisualStyleBackColor = True
        '
        'personalElectro
        '
        Me.personalElectro.AutoSize = True
        Me.personalElectro.Location = New System.Drawing.Point(46, 55)
        Me.personalElectro.Name = "personalElectro"
        Me.personalElectro.Size = New System.Drawing.Size(60, 16)
        Me.personalElectro.TabIndex = 20
        Me.personalElectro.Text = "心電図"
        Me.personalElectro.UseVisualStyleBackColor = True
        '
        'personalBlood
        '
        Me.personalBlood.AutoSize = True
        Me.personalBlood.Location = New System.Drawing.Point(46, 33)
        Me.personalBlood.Name = "personalBlood"
        Me.personalBlood.Size = New System.Drawing.Size(48, 16)
        Me.personalBlood.TabIndex = 20
        Me.personalBlood.Text = "血液"
        Me.personalBlood.UseVisualStyleBackColor = True
        '
        'companyTabPage
        '
        Me.companyTabPage.Controls.Add(Me.companyLumbarXP)
        Me.companyTabPage.Controls.Add(Me.companyWindowPay)
        Me.companyTabPage.Controls.Add(Me.Label14)
        Me.companyTabPage.Controls.Add(Me.companyNone)
        Me.companyTabPage.Controls.Add(Me.companyStomachCamera)
        Me.companyTabPage.Controls.Add(Me.companyStomachBa)
        Me.companyTabPage.Controls.Add(Me.companyUltrasonic)
        Me.companyTabPage.Controls.Add(Me.companyChestXP)
        Me.companyTabPage.Controls.Add(Me.companyElectro)
        Me.companyTabPage.Controls.Add(Me.companyBlood)
        Me.companyTabPage.Location = New System.Drawing.Point(4, 22)
        Me.companyTabPage.Name = "companyTabPage"
        Me.companyTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.companyTabPage.Size = New System.Drawing.Size(386, 195)
        Me.companyTabPage.TabIndex = 1
        Me.companyTabPage.Text = "企業"
        Me.companyTabPage.UseVisualStyleBackColor = True
        '
        'companyLumbarXP
        '
        Me.companyLumbarXP.AutoSize = True
        Me.companyLumbarXP.Location = New System.Drawing.Point(127, 77)
        Me.companyLumbarXP.Name = "companyLumbarXP"
        Me.companyLumbarXP.Size = New System.Drawing.Size(62, 16)
        Me.companyLumbarXP.TabIndex = 22
        Me.companyLumbarXP.Text = "腰椎XP"
        Me.companyLumbarXP.UseVisualStyleBackColor = True
        '
        'companyWindowPay
        '
        Me.companyWindowPay.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.companyWindowPay.Location = New System.Drawing.Point(306, 157)
        Me.companyWindowPay.Name = "companyWindowPay"
        Me.companyWindowPay.Size = New System.Drawing.Size(53, 19)
        Me.companyWindowPay.TabIndex = 9
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(247, 160)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 12)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "窓口負担"
        '
        'companyNone
        '
        Me.companyNone.AutoSize = True
        Me.companyNone.Location = New System.Drawing.Point(200, 128)
        Me.companyNone.Name = "companyNone"
        Me.companyNone.Size = New System.Drawing.Size(42, 16)
        Me.companyNone.TabIndex = 7
        Me.companyNone.TabStop = True
        Me.companyNone.Text = "なし"
        Me.companyNone.UseVisualStyleBackColor = True
        '
        'companyStomachCamera
        '
        Me.companyStomachCamera.AutoSize = True
        Me.companyStomachCamera.Location = New System.Drawing.Point(127, 128)
        Me.companyStomachCamera.Name = "companyStomachCamera"
        Me.companyStomachCamera.Size = New System.Drawing.Size(60, 16)
        Me.companyStomachCamera.TabIndex = 6
        Me.companyStomachCamera.TabStop = True
        Me.companyStomachCamera.Text = "胃カメラ"
        Me.companyStomachCamera.UseVisualStyleBackColor = True
        '
        'companyStomachBa
        '
        Me.companyStomachBa.AutoSize = True
        Me.companyStomachBa.Location = New System.Drawing.Point(46, 128)
        Me.companyStomachBa.Name = "companyStomachBa"
        Me.companyStomachBa.Size = New System.Drawing.Size(71, 16)
        Me.companyStomachBa.TabIndex = 5
        Me.companyStomachBa.TabStop = True
        Me.companyStomachBa.Text = "胃バリウム"
        Me.companyStomachBa.UseVisualStyleBackColor = True
        '
        'companyUltrasonic
        '
        Me.companyUltrasonic.AutoSize = True
        Me.companyUltrasonic.Location = New System.Drawing.Point(46, 99)
        Me.companyUltrasonic.Name = "companyUltrasonic"
        Me.companyUltrasonic.Size = New System.Drawing.Size(60, 16)
        Me.companyUltrasonic.TabIndex = 4
        Me.companyUltrasonic.Text = "超音波"
        Me.companyUltrasonic.UseVisualStyleBackColor = True
        '
        'companyChestXP
        '
        Me.companyChestXP.AutoSize = True
        Me.companyChestXP.Location = New System.Drawing.Point(46, 77)
        Me.companyChestXP.Name = "companyChestXP"
        Me.companyChestXP.Size = New System.Drawing.Size(62, 16)
        Me.companyChestXP.TabIndex = 3
        Me.companyChestXP.Text = "胸部XP"
        Me.companyChestXP.UseVisualStyleBackColor = True
        '
        'companyElectro
        '
        Me.companyElectro.AutoSize = True
        Me.companyElectro.Location = New System.Drawing.Point(46, 55)
        Me.companyElectro.Name = "companyElectro"
        Me.companyElectro.Size = New System.Drawing.Size(60, 16)
        Me.companyElectro.TabIndex = 2
        Me.companyElectro.Text = "心電図"
        Me.companyElectro.UseVisualStyleBackColor = True
        '
        'companyBlood
        '
        Me.companyBlood.AutoSize = True
        Me.companyBlood.Location = New System.Drawing.Point(46, 33)
        Me.companyBlood.Name = "companyBlood"
        Me.companyBlood.Size = New System.Drawing.Size(48, 16)
        Me.companyBlood.TabIndex = 1
        Me.companyBlood.Text = "血液"
        Me.companyBlood.UseVisualStyleBackColor = True
        '
        'lifeStyleTabPage
        '
        Me.lifeStyleTabPage.Controls.Add(Me.lifeStyleLumbarXP)
        Me.lifeStyleTabPage.Controls.Add(Me.lifeStyleWindowPay)
        Me.lifeStyleTabPage.Controls.Add(Me.btnLifeStyle)
        Me.lifeStyleTabPage.Controls.Add(Me.CheckBox2)
        Me.lifeStyleTabPage.Controls.Add(Me.CheckBox1)
        Me.lifeStyleTabPage.Controls.Add(Me.lifeStyleNone)
        Me.lifeStyleTabPage.Controls.Add(Me.lifeStyleStomachCamera)
        Me.lifeStyleTabPage.Controls.Add(Me.lifeStyleStomachBa)
        Me.lifeStyleTabPage.Location = New System.Drawing.Point(4, 22)
        Me.lifeStyleTabPage.Name = "lifeStyleTabPage"
        Me.lifeStyleTabPage.Size = New System.Drawing.Size(386, 195)
        Me.lifeStyleTabPage.TabIndex = 2
        Me.lifeStyleTabPage.Text = "生活"
        Me.lifeStyleTabPage.UseVisualStyleBackColor = True
        '
        'lifeStyleLumbarXP
        '
        Me.lifeStyleLumbarXP.AutoSize = True
        Me.lifeStyleLumbarXP.Location = New System.Drawing.Point(46, 136)
        Me.lifeStyleLumbarXP.Name = "lifeStyleLumbarXP"
        Me.lifeStyleLumbarXP.Size = New System.Drawing.Size(62, 16)
        Me.lifeStyleLumbarXP.TabIndex = 23
        Me.lifeStyleLumbarXP.Text = "腰椎XP"
        Me.lifeStyleLumbarXP.UseVisualStyleBackColor = True
        '
        'lifeStyleWindowPay
        '
        Me.lifeStyleWindowPay.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lifeStyleWindowPay.Location = New System.Drawing.Point(281, 137)
        Me.lifeStyleWindowPay.Name = "lifeStyleWindowPay"
        Me.lifeStyleWindowPay.Size = New System.Drawing.Size(62, 19)
        Me.lifeStyleWindowPay.TabIndex = 12
        '
        'btnLifeStyle
        '
        Me.btnLifeStyle.Location = New System.Drawing.Point(188, 135)
        Me.btnLifeStyle.Name = "btnLifeStyle"
        Me.btnLifeStyle.Size = New System.Drawing.Size(87, 23)
        Me.btnLifeStyle.TabIndex = 0
        Me.btnLifeStyle.Text = "窓口負担表示"
        Me.btnLifeStyle.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Enabled = False
        Me.CheckBox2.Location = New System.Drawing.Point(46, 69)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(83, 16)
        Me.CheckBox2.TabIndex = 10
        Me.CheckBox2.Text = "肝炎ウィルス"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(46, 36)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(72, 16)
        Me.CheckBox1.TabIndex = 1
        Me.CheckBox1.Text = "付加健診"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'lifeStyleNone
        '
        Me.lifeStyleNone.AutoSize = True
        Me.lifeStyleNone.Location = New System.Drawing.Point(200, 104)
        Me.lifeStyleNone.Name = "lifeStyleNone"
        Me.lifeStyleNone.Size = New System.Drawing.Size(42, 16)
        Me.lifeStyleNone.TabIndex = 8
        Me.lifeStyleNone.TabStop = True
        Me.lifeStyleNone.Text = "なし"
        Me.lifeStyleNone.UseVisualStyleBackColor = True
        '
        'lifeStyleStomachCamera
        '
        Me.lifeStyleStomachCamera.AutoSize = True
        Me.lifeStyleStomachCamera.Location = New System.Drawing.Point(123, 104)
        Me.lifeStyleStomachCamera.Name = "lifeStyleStomachCamera"
        Me.lifeStyleStomachCamera.Size = New System.Drawing.Size(60, 16)
        Me.lifeStyleStomachCamera.TabIndex = 7
        Me.lifeStyleStomachCamera.TabStop = True
        Me.lifeStyleStomachCamera.Text = "胃カメラ"
        Me.lifeStyleStomachCamera.UseVisualStyleBackColor = True
        '
        'lifeStyleStomachBa
        '
        Me.lifeStyleStomachBa.AutoSize = True
        Me.lifeStyleStomachBa.Location = New System.Drawing.Point(46, 104)
        Me.lifeStyleStomachBa.Name = "lifeStyleStomachBa"
        Me.lifeStyleStomachBa.Size = New System.Drawing.Size(71, 16)
        Me.lifeStyleStomachBa.TabIndex = 6
        Me.lifeStyleStomachBa.TabStop = True
        Me.lifeStyleStomachBa.Text = "胃バリウム"
        Me.lifeStyleStomachBa.UseVisualStyleBackColor = True
        '
        'specificTabPage
        '
        Me.specificTabPage.Controls.Add(Me.Label26)
        Me.specificTabPage.Controls.Add(Me.checkECG)
        Me.specificTabPage.Controls.Add(Me.gastricCancerRiskBox)
        Me.specificTabPage.Controls.Add(Me.diabetesBox)
        Me.specificTabPage.Controls.Add(Me.prostateCancerBox)
        Me.specificTabPage.Controls.Add(Me.cardiacBox)
        Me.specificTabPage.Controls.Add(Me.specificWindowPay)
        Me.specificTabPage.Controls.Add(Me.btnTok)
        Me.specificTabPage.Controls.Add(Me.Label25)
        Me.specificTabPage.Controls.Add(Me.Label24)
        Me.specificTabPage.Controls.Add(Me.Label23)
        Me.specificTabPage.Controls.Add(Me.Label22)
        Me.specificTabPage.Controls.Add(Me.couponTicketBox)
        Me.specificTabPage.Controls.Add(Me.Label21)
        Me.specificTabPage.Controls.Add(Me.anemiaBox)
        Me.specificTabPage.Controls.Add(Me.bloodSugarBox)
        Me.specificTabPage.Controls.Add(Me.biochemistryBox)
        Me.specificTabPage.Controls.Add(Me.insuranceTypeBox)
        Me.specificTabPage.Controls.Add(Me.Label20)
        Me.specificTabPage.Controls.Add(Me.Label19)
        Me.specificTabPage.Controls.Add(Me.Label18)
        Me.specificTabPage.Controls.Add(Me.Label17)
        Me.specificTabPage.Controls.Add(Me.Label16)
        Me.specificTabPage.Controls.Add(Me.Label15)
        Me.specificTabPage.Location = New System.Drawing.Point(4, 22)
        Me.specificTabPage.Name = "specificTabPage"
        Me.specificTabPage.Size = New System.Drawing.Size(386, 195)
        Me.specificTabPage.TabIndex = 3
        Me.specificTabPage.Text = "特定"
        Me.specificTabPage.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.ForeColor = System.Drawing.Color.Blue
        Me.Label26.Location = New System.Drawing.Point(41, 145)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(158, 12)
        Me.Label26.TabIndex = 27
        Me.Label26.Text = "(60歳以上は基本チェック入れる)"
        '
        'checkECG
        '
        Me.checkECG.AutoSize = True
        Me.checkECG.Location = New System.Drawing.Point(44, 125)
        Me.checkECG.Name = "checkECG"
        Me.checkECG.Size = New System.Drawing.Size(60, 16)
        Me.checkECG.TabIndex = 26
        Me.checkECG.Text = "心電図"
        Me.checkECG.UseVisualStyleBackColor = True
        '
        'gastricCancerRiskBox
        '
        Me.gastricCancerRiskBox.FormattingEnabled = True
        Me.gastricCancerRiskBox.Items.AddRange(New Object() {"○", "×"})
        Me.gastricCancerRiskBox.Location = New System.Drawing.Point(326, 67)
        Me.gastricCancerRiskBox.Name = "gastricCancerRiskBox"
        Me.gastricCancerRiskBox.Size = New System.Drawing.Size(51, 20)
        Me.gastricCancerRiskBox.TabIndex = 25
        '
        'diabetesBox
        '
        Me.diabetesBox.FormattingEnabled = True
        Me.diabetesBox.Items.AddRange(New Object() {"○", "×"})
        Me.diabetesBox.Location = New System.Drawing.Point(326, 86)
        Me.diabetesBox.Name = "diabetesBox"
        Me.diabetesBox.Size = New System.Drawing.Size(51, 20)
        Me.diabetesBox.TabIndex = 24
        '
        'prostateCancerBox
        '
        Me.prostateCancerBox.FormattingEnabled = True
        Me.prostateCancerBox.Items.AddRange(New Object() {"○", "×"})
        Me.prostateCancerBox.Location = New System.Drawing.Point(326, 105)
        Me.prostateCancerBox.Name = "prostateCancerBox"
        Me.prostateCancerBox.Size = New System.Drawing.Size(51, 20)
        Me.prostateCancerBox.TabIndex = 23
        '
        'cardiacBox
        '
        Me.cardiacBox.FormattingEnabled = True
        Me.cardiacBox.Items.AddRange(New Object() {"○", "×"})
        Me.cardiacBox.Location = New System.Drawing.Point(326, 48)
        Me.cardiacBox.Name = "cardiacBox"
        Me.cardiacBox.Size = New System.Drawing.Size(51, 20)
        Me.cardiacBox.TabIndex = 22
        '
        'specificWindowPay
        '
        Me.specificWindowPay.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.specificWindowPay.Location = New System.Drawing.Point(303, 142)
        Me.specificWindowPay.Name = "specificWindowPay"
        Me.specificWindowPay.Size = New System.Drawing.Size(62, 19)
        Me.specificWindowPay.TabIndex = 18
        '
        'btnTok
        '
        Me.btnTok.Location = New System.Drawing.Point(205, 140)
        Me.btnTok.Name = "btnTok"
        Me.btnTok.Size = New System.Drawing.Size(87, 23)
        Me.btnTok.TabIndex = 17
        Me.btnTok.Text = "窓口負担表示"
        Me.btnTok.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(162, 110)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(103, 12)
        Me.Label25.TabIndex = 16
        Me.Label25.Text = "④前立腺がん(PSA)"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(162, 91)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(158, 12)
        Me.Label24.TabIndex = 15
        Me.Label24.Text = "③糖尿病性腎症(尿中ｱﾙﾌﾞﾐﾝ)"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(162, 72)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(101, 12)
        Me.Label23.TabIndex = 14
        Me.Label23.Text = "②胃がんﾘｽｸ(ABC)"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(162, 53)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(121, 12)
        Me.Label22.TabIndex = 13
        Me.Label22.Text = "①心機能(NT-proBNP)"
        '
        'couponTicketBox
        '
        Me.couponTicketBox.AutoSize = True
        Me.couponTicketBox.Location = New System.Drawing.Point(237, 31)
        Me.couponTicketBox.Name = "couponTicketBox"
        Me.couponTicketBox.Size = New System.Drawing.Size(92, 16)
        Me.couponTicketBox.TabIndex = 12
        Me.couponTicketBox.Text = "無料ｸｰﾎﾟﾝ券"
        Me.couponTicketBox.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(162, 27)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(66, 12)
        Me.Label21.TabIndex = 11
        Me.Label21.Text = "ｵﾌﾟｼｮﾝ検査"
        '
        'anemiaBox
        '
        Me.anemiaBox.FormattingEnabled = True
        Me.anemiaBox.Items.AddRange(New Object() {"○", "×"})
        Me.anemiaBox.Location = New System.Drawing.Point(90, 83)
        Me.anemiaBox.Name = "anemiaBox"
        Me.anemiaBox.Size = New System.Drawing.Size(62, 20)
        Me.anemiaBox.TabIndex = 10
        '
        'bloodSugarBox
        '
        Me.bloodSugarBox.FormattingEnabled = True
        Me.bloodSugarBox.Items.AddRange(New Object() {"○", "×"})
        Me.bloodSugarBox.Location = New System.Drawing.Point(90, 65)
        Me.bloodSugarBox.Name = "bloodSugarBox"
        Me.bloodSugarBox.Size = New System.Drawing.Size(62, 20)
        Me.bloodSugarBox.TabIndex = 9
        '
        'biochemistryBox
        '
        Me.biochemistryBox.FormattingEnabled = True
        Me.biochemistryBox.Items.AddRange(New Object() {"○", "×"})
        Me.biochemistryBox.Location = New System.Drawing.Point(90, 46)
        Me.biochemistryBox.Name = "biochemistryBox"
        Me.biochemistryBox.Size = New System.Drawing.Size(62, 20)
        Me.biochemistryBox.TabIndex = 8
        '
        'insuranceTypeBox
        '
        Me.insuranceTypeBox.FormattingEnabled = True
        Me.insuranceTypeBox.Items.AddRange(New Object() {"国保", "社・家", "共済"})
        Me.insuranceTypeBox.Location = New System.Drawing.Point(90, 27)
        Me.insuranceTypeBox.Name = "insuranceTypeBox"
        Me.insuranceTypeBox.Size = New System.Drawing.Size(62, 20)
        Me.insuranceTypeBox.TabIndex = 7
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(46, 91)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(29, 12)
        Me.Label20.TabIndex = 5
        Me.Label20.Text = "貧血"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(46, 73)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(29, 12)
        Me.Label19.TabIndex = 4
        Me.Label19.Text = "血糖"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(46, 51)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(41, 12)
        Me.Label18.TabIndex = 3
        Me.Label18.Text = "生化学"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(11, 51)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(29, 12)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "採血"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(46, 27)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(29, 12)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "種別"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(11, 27)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 12)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "保険"
        '
        'cancerTabPage
        '
        Me.cancerTabPage.Controls.Add(Me.cancerWindowPay)
        Me.cancerTabPage.Controls.Add(Me.btnGan)
        Me.cancerTabPage.Controls.Add(Me.colorectalCancerBox)
        Me.cancerTabPage.Controls.Add(Me.gastricCancerBox)
        Me.cancerTabPage.Location = New System.Drawing.Point(4, 22)
        Me.cancerTabPage.Name = "cancerTabPage"
        Me.cancerTabPage.Size = New System.Drawing.Size(386, 195)
        Me.cancerTabPage.TabIndex = 4
        Me.cancerTabPage.Text = "がん"
        Me.cancerTabPage.UseVisualStyleBackColor = True
        '
        'cancerWindowPay
        '
        Me.cancerWindowPay.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cancerWindowPay.Location = New System.Drawing.Point(247, 127)
        Me.cancerWindowPay.Name = "cancerWindowPay"
        Me.cancerWindowPay.Size = New System.Drawing.Size(62, 19)
        Me.cancerWindowPay.TabIndex = 19
        '
        'btnGan
        '
        Me.btnGan.Location = New System.Drawing.Point(153, 125)
        Me.btnGan.Name = "btnGan"
        Me.btnGan.Size = New System.Drawing.Size(87, 23)
        Me.btnGan.TabIndex = 18
        Me.btnGan.Text = "窓口負担表示"
        Me.btnGan.UseVisualStyleBackColor = True
        '
        'colorectalCancerBox
        '
        Me.colorectalCancerBox.AutoSize = True
        Me.colorectalCancerBox.Location = New System.Drawing.Point(153, 47)
        Me.colorectalCancerBox.Name = "colorectalCancerBox"
        Me.colorectalCancerBox.Size = New System.Drawing.Size(68, 16)
        Me.colorectalCancerBox.TabIndex = 1
        Me.colorectalCancerBox.Text = "大腸がん"
        Me.colorectalCancerBox.UseVisualStyleBackColor = True
        '
        'gastricCancerBox
        '
        Me.gastricCancerBox.AutoSize = True
        Me.gastricCancerBox.Location = New System.Drawing.Point(72, 47)
        Me.gastricCancerBox.Name = "gastricCancerBox"
        Me.gastricCancerBox.Size = New System.Drawing.Size(56, 16)
        Me.gastricCancerBox.TabIndex = 0
        Me.gastricCancerBox.Text = "胃がん"
        Me.gastricCancerBox.UseVisualStyleBackColor = True
        '
        'referenceTabPage
        '
        Me.referenceTabPage.Controls.Add(Me.personListBox)
        Me.referenceTabPage.Controls.Add(Me.referenceListBox)
        Me.referenceTabPage.Controls.Add(Me.sankenCenterButton)
        Me.referenceTabPage.Controls.Add(Me.healthButton)
        Me.referenceTabPage.Controls.Add(Me.diagnoseButton)
        Me.referenceTabPage.Location = New System.Drawing.Point(4, 22)
        Me.referenceTabPage.Name = "referenceTabPage"
        Me.referenceTabPage.Size = New System.Drawing.Size(386, 195)
        Me.referenceTabPage.TabIndex = 5
        Me.referenceTabPage.Text = "参照"
        Me.referenceTabPage.UseVisualStyleBackColor = True
        '
        'personListBox
        '
        Me.personListBox.FormattingEnabled = True
        Me.personListBox.ItemHeight = 12
        Me.personListBox.Location = New System.Drawing.Point(243, 42)
        Me.personListBox.Name = "personListBox"
        Me.personListBox.Size = New System.Drawing.Size(120, 112)
        Me.personListBox.TabIndex = 4
        '
        'referenceListBox
        '
        Me.referenceListBox.FormattingEnabled = True
        Me.referenceListBox.ItemHeight = 12
        Me.referenceListBox.Location = New System.Drawing.Point(13, 42)
        Me.referenceListBox.Name = "referenceListBox"
        Me.referenceListBox.Size = New System.Drawing.Size(215, 112)
        Me.referenceListBox.TabIndex = 3
        '
        'sankenCenterButton
        '
        Me.sankenCenterButton.AutoSize = True
        Me.sankenCenterButton.Location = New System.Drawing.Point(259, 18)
        Me.sankenCenterButton.Name = "sankenCenterButton"
        Me.sankenCenterButton.Size = New System.Drawing.Size(84, 16)
        Me.sankenCenterButton.TabIndex = 2
        Me.sankenCenterButton.Text = "産健センター"
        Me.sankenCenterButton.UseVisualStyleBackColor = True
        '
        'healthButton
        '
        Me.healthButton.AutoSize = True
        Me.healthButton.Location = New System.Drawing.Point(125, 18)
        Me.healthButton.Name = "healthButton"
        Me.healthButton.Size = New System.Drawing.Size(128, 16)
        Me.healthButton.TabIndex = 1
        Me.healthButton.Text = "生活習慣病（Health）"
        Me.healthButton.UseVisualStyleBackColor = True
        '
        'diagnoseButton
        '
        Me.diagnoseButton.AutoSize = True
        Me.diagnoseButton.Location = New System.Drawing.Point(13, 18)
        Me.diagnoseButton.Name = "diagnoseButton"
        Me.diagnoseButton.Size = New System.Drawing.Size(106, 16)
        Me.diagnoseButton.TabIndex = 0
        Me.diagnoseButton.Text = "健診（Diagnose）"
        Me.diagnoseButton.UseVisualStyleBackColor = True
        '
        'btnRegist
        '
        Me.btnRegist.Location = New System.Drawing.Point(395, 256)
        Me.btnRegist.Name = "btnRegist"
        Me.btnRegist.Size = New System.Drawing.Size(75, 38)
        Me.btnRegist.TabIndex = 56
        Me.btnRegist.Text = "登録"
        Me.btnRegist.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(476, 256)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 38)
        Me.btnDelete.TabIndex = 62
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(557, 256)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 38)
        Me.btnPrint.TabIndex = 61
        Me.btnPrint.Text = "印刷"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(26, 297)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(145, 12)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "項目名ﾀﾞﾌﾞﾙｸﾘｯｸで並び替え"
        '
        '予約データ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 593)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.rbtnPrint)
        Me.Controls.Add(Me.rbtnPreview)
        Me.Controls.Add(Me.reserveTabControl)
        Me.Controls.Add(Me.btnRegist)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnSelectClear)
        Me.Controls.Add(Me.btnInputClear)
        Me.Controls.Add(Me.dgvReserve)
        Me.Controls.Add(Me.ymBox)
        Me.Controls.Add(Me.memo1Box)
        Me.Controls.Add(Me.apmBox)
        Me.Controls.Add(Me.sexBox)
        Me.Controls.Add(Me.reserveYmdBox)
        Me.Controls.Add(Me.birthBox)
        Me.Controls.Add(Me.kanaBox)
        Me.Controls.Add(Me.namBox)
        Me.Controls.Add(Me.indBox)
        Me.Controls.Add(Me.syuBox)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "予約データ"
        Me.Text = "予約データ"
        CType(Me.dgvReserve, System.ComponentModel.ISupportInitialize).EndInit()
        Me.reserveTabControl.ResumeLayout(False)
        Me.personalTabPage.ResumeLayout(False)
        Me.personalTabPage.PerformLayout()
        Me.companyTabPage.ResumeLayout(False)
        Me.companyTabPage.PerformLayout()
        Me.lifeStyleTabPage.ResumeLayout(False)
        Me.lifeStyleTabPage.PerformLayout()
        Me.specificTabPage.ResumeLayout(False)
        Me.specificTabPage.PerformLayout()
        Me.cancerTabPage.ResumeLayout(False)
        Me.cancerTabPage.PerformLayout()
        Me.referenceTabPage.ResumeLayout(False)
        Me.referenceTabPage.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents syuBox As System.Windows.Forms.ComboBox
    Friend WithEvents indBox As System.Windows.Forms.TextBox
    Friend WithEvents namBox As System.Windows.Forms.TextBox
    Friend WithEvents kanaBox As System.Windows.Forms.TextBox
    Friend WithEvents birthBox As ymdBox.ymdBox
    Friend WithEvents reserveYmdBox As ymdBox.ymdBox
    Friend WithEvents sexBox As System.Windows.Forms.ComboBox
    Friend WithEvents apmBox As System.Windows.Forms.ComboBox
    Friend WithEvents memo1Box As System.Windows.Forms.TextBox
    Friend WithEvents ymBox As ymdBox.ymdBox
    Friend WithEvents dgvReserve As System.Windows.Forms.DataGridView
    Friend WithEvents btnInputClear As System.Windows.Forms.Button
    Friend WithEvents btnSelectClear As System.Windows.Forms.Button
    Friend WithEvents rbtnPrint As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnPreview As System.Windows.Forms.RadioButton
    Friend WithEvents reserveTabControl As System.Windows.Forms.TabControl
    Friend WithEvents personalTabPage As System.Windows.Forms.TabPage
    Friend WithEvents personalLumbarXP As System.Windows.Forms.CheckBox
    Friend WithEvents personalWindowPay As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents personalNone As System.Windows.Forms.RadioButton
    Friend WithEvents personalStomachCamera As System.Windows.Forms.RadioButton
    Friend WithEvents personalStomachBa As System.Windows.Forms.RadioButton
    Friend WithEvents personalUltrasonic As System.Windows.Forms.CheckBox
    Friend WithEvents personalChestXP As System.Windows.Forms.CheckBox
    Friend WithEvents personalElectro As System.Windows.Forms.CheckBox
    Friend WithEvents personalBlood As System.Windows.Forms.CheckBox
    Friend WithEvents companyTabPage As System.Windows.Forms.TabPage
    Friend WithEvents companyLumbarXP As System.Windows.Forms.CheckBox
    Friend WithEvents companyWindowPay As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents companyNone As System.Windows.Forms.RadioButton
    Friend WithEvents companyStomachCamera As System.Windows.Forms.RadioButton
    Friend WithEvents companyStomachBa As System.Windows.Forms.RadioButton
    Friend WithEvents companyUltrasonic As System.Windows.Forms.CheckBox
    Friend WithEvents companyChestXP As System.Windows.Forms.CheckBox
    Friend WithEvents companyElectro As System.Windows.Forms.CheckBox
    Friend WithEvents companyBlood As System.Windows.Forms.CheckBox
    Friend WithEvents lifeStyleTabPage As System.Windows.Forms.TabPage
    Friend WithEvents lifeStyleLumbarXP As System.Windows.Forms.CheckBox
    Friend WithEvents lifeStyleWindowPay As System.Windows.Forms.TextBox
    Friend WithEvents btnLifeStyle As System.Windows.Forms.Button
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents lifeStyleNone As System.Windows.Forms.RadioButton
    Friend WithEvents lifeStyleStomachCamera As System.Windows.Forms.RadioButton
    Friend WithEvents lifeStyleStomachBa As System.Windows.Forms.RadioButton
    Friend WithEvents specificTabPage As System.Windows.Forms.TabPage
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents checkECG As System.Windows.Forms.CheckBox
    Friend WithEvents gastricCancerRiskBox As System.Windows.Forms.ComboBox
    Friend WithEvents diabetesBox As System.Windows.Forms.ComboBox
    Friend WithEvents prostateCancerBox As System.Windows.Forms.ComboBox
    Friend WithEvents cardiacBox As System.Windows.Forms.ComboBox
    Friend WithEvents specificWindowPay As System.Windows.Forms.TextBox
    Friend WithEvents btnTok As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents couponTicketBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents anemiaBox As System.Windows.Forms.ComboBox
    Friend WithEvents bloodSugarBox As System.Windows.Forms.ComboBox
    Friend WithEvents biochemistryBox As System.Windows.Forms.ComboBox
    Friend WithEvents insuranceTypeBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cancerTabPage As System.Windows.Forms.TabPage
    Friend WithEvents cancerWindowPay As System.Windows.Forms.TextBox
    Friend WithEvents btnGan As System.Windows.Forms.Button
    Friend WithEvents colorectalCancerBox As System.Windows.Forms.CheckBox
    Friend WithEvents gastricCancerBox As System.Windows.Forms.CheckBox
    Friend WithEvents referenceTabPage As System.Windows.Forms.TabPage
    Friend WithEvents personListBox As System.Windows.Forms.ListBox
    Friend WithEvents referenceListBox As System.Windows.Forms.ListBox
    Friend WithEvents sankenCenterButton As System.Windows.Forms.RadioButton
    Friend WithEvents healthButton As System.Windows.Forms.RadioButton
    Friend WithEvents diagnoseButton As System.Windows.Forms.RadioButton
    Friend WithEvents btnRegist As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
