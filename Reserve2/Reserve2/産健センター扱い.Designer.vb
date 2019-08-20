<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 産健センター扱い
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
        Me.btnRegist = New System.Windows.Forms.Button()
        Me.dgvSanken = New System.Windows.Forms.DataGridView()
        CType(Me.dgvSanken, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnRegist
        '
        Me.btnRegist.Location = New System.Drawing.Point(114, 482)
        Me.btnRegist.Name = "btnRegist"
        Me.btnRegist.Size = New System.Drawing.Size(75, 40)
        Me.btnRegist.TabIndex = 3
        Me.btnRegist.Text = "登録"
        Me.btnRegist.UseVisualStyleBackColor = True
        '
        'dgvSanken
        '
        Me.dgvSanken.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSanken.Location = New System.Drawing.Point(24, 18)
        Me.dgvSanken.Name = "dgvSanken"
        Me.dgvSanken.RowTemplate.Height = 21
        Me.dgvSanken.Size = New System.Drawing.Size(265, 445)
        Me.dgvSanken.TabIndex = 2
        '
        '産健センター扱い
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(313, 541)
        Me.Controls.Add(Me.btnRegist)
        Me.Controls.Add(Me.dgvSanken)
        Me.Name = "産健センター扱い"
        Me.Text = "産健センター扱い"
        CType(Me.dgvSanken, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnRegist As System.Windows.Forms.Button
    Friend WithEvents dgvSanken As System.Windows.Forms.DataGridView
End Class
