<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Change_log
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Change_log))
        Me.TextBox8 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(14, 19)
        Me.TextBox8.Multiline = True
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.ReadOnly = True
        Me.TextBox8.Size = New System.Drawing.Size(310, 249)
        Me.TextBox8.TabIndex = 38
        Me.TextBox8.Text = resources.GetString("TextBox8.Text")
        '
        'Change_log
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(339, 287)
        Me.Controls.Add(Me.TextBox8)
        Me.Name = "Change_log"
        Me.Text = "Change_log"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
End Class
