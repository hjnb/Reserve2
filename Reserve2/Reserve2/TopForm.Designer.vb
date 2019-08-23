<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TopForm
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
        Me.menuBar = New System.Windows.Forms.MenuStrip()
        Me.予約データToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.産健センター扱いToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.検索ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.本日の追加変更ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'menuBar
        '
        Me.menuBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.予約データToolStripMenuItem, Me.産健センター扱いToolStripMenuItem, Me.検索ToolStripMenuItem, Me.本日の追加変更ToolStripMenuItem, Me.終了ToolStripMenuItem})
        Me.menuBar.Location = New System.Drawing.Point(0, 0)
        Me.menuBar.Name = "menuBar"
        Me.menuBar.Size = New System.Drawing.Size(582, 24)
        Me.menuBar.TabIndex = 0
        Me.menuBar.Text = "MenuStrip1"
        '
        '予約データToolStripMenuItem
        '
        Me.予約データToolStripMenuItem.Name = "予約データToolStripMenuItem"
        Me.予約データToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.予約データToolStripMenuItem.Text = "予約データ"
        '
        '産健センター扱いToolStripMenuItem
        '
        Me.産健センター扱いToolStripMenuItem.Name = "産健センター扱いToolStripMenuItem"
        Me.産健センター扱いToolStripMenuItem.Size = New System.Drawing.Size(101, 20)
        Me.産健センター扱いToolStripMenuItem.Text = "産健センター扱い"
        '
        '検索ToolStripMenuItem
        '
        Me.検索ToolStripMenuItem.Name = "検索ToolStripMenuItem"
        Me.検索ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.検索ToolStripMenuItem.Text = "検索"
        '
        '終了ToolStripMenuItem
        '
        Me.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem"
        Me.終了ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.終了ToolStripMenuItem.Text = "終了"
        '
        '本日の追加変更ToolStripMenuItem
        '
        Me.本日の追加変更ToolStripMenuItem.Name = "本日の追加変更ToolStripMenuItem"
        Me.本日の追加変更ToolStripMenuItem.Size = New System.Drawing.Size(101, 20)
        Me.本日の追加変更ToolStripMenuItem.Text = "本日の追加変更"
        '
        'TopForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 324)
        Me.Controls.Add(Me.menuBar)
        Me.MainMenuStrip = Me.menuBar
        Me.Name = "TopForm"
        Me.Text = "Reserve -検診予約-"
        Me.menuBar.ResumeLayout(False)
        Me.menuBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents menuBar As System.Windows.Forms.MenuStrip
    Friend WithEvents 予約データToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 産健センター扱いToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 検索ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 終了ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 本日の追加変更ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
