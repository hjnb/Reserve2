<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 検索
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.toDateLabel = New System.Windows.Forms.Label()
        Me.fromDateLabel = New System.Windows.Forms.Label()
        Me.dgvSearch = New System.Windows.Forms.DataGridView()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.searchTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(269, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 12)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "～"
        '
        'toDateLabel
        '
        Me.toDateLabel.AutoSize = True
        Me.toDateLabel.Location = New System.Drawing.Point(296, 17)
        Me.toDateLabel.Name = "toDateLabel"
        Me.toDateLabel.Size = New System.Drawing.Size(0, 12)
        Me.toDateLabel.TabIndex = 10
        '
        'fromDateLabel
        '
        Me.fromDateLabel.AutoSize = True
        Me.fromDateLabel.Location = New System.Drawing.Point(195, 17)
        Me.fromDateLabel.Name = "fromDateLabel"
        Me.fromDateLabel.Size = New System.Drawing.Size(0, 12)
        Me.fromDateLabel.TabIndex = 9
        '
        'dgvSearch
        '
        Me.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSearch.Location = New System.Drawing.Point(13, 53)
        Me.dgvSearch.Name = "dgvSearch"
        Me.dgvSearch.RowTemplate.Height = 21
        Me.dgvSearch.Size = New System.Drawing.Size(515, 172)
        Me.dgvSearch.TabIndex = 8
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(381, 12)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 7
        Me.btnSearch.Text = "検索"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'searchTextBox
        '
        Me.searchTextBox.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.searchTextBox.Location = New System.Drawing.Point(31, 14)
        Me.searchTextBox.Name = "searchTextBox"
        Me.searchTextBox.Size = New System.Drawing.Size(140, 19)
        Me.searchTextBox.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(40, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 11)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "(半角ｶﾅで入力して下さい)"
        '
        '検索
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 233)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.toDateLabel)
        Me.Controls.Add(Me.fromDateLabel)
        Me.Controls.Add(Me.dgvSearch)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.searchTextBox)
        Me.Name = "検索"
        Me.Text = "検索"
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents toDateLabel As System.Windows.Forms.Label
    Friend WithEvents fromDateLabel As System.Windows.Forms.Label
    Friend WithEvents dgvSearch As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents searchTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
