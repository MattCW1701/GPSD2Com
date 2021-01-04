namespace GPSD2Com
{
  partial class GPSToComForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.oTransmitPort = new System.IO.Ports.SerialPort(this.components);
      this.cboSerialport = new System.Windows.Forms.ComboBox();
      this.txtHost = new System.Windows.Forms.TextBox();
      this.lblSerialPort = new System.Windows.Forms.Label();
      this.lblHostName = new System.Windows.Forms.Label();
      this.btnStart = new System.Windows.Forms.Button();
      this.txtOutput = new System.Windows.Forms.TextBox();
      this.btnStop = new System.Windows.Forms.Button();
      this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
      this.lblPort = new System.Windows.Forms.Label();
      this.txtPort = new System.Windows.Forms.TextBox();
      this.chkLogging = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // cboSerialport
      // 
      this.cboSerialport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboSerialport.FormattingEnabled = true;
      this.cboSerialport.Location = new System.Drawing.Point(112, 14);
      this.cboSerialport.Name = "cboSerialport";
      this.cboSerialport.Size = new System.Drawing.Size(253, 28);
      this.cboSerialport.Sorted = true;
      this.cboSerialport.TabIndex = 4;
      // 
      // txtHost
      // 
      this.txtHost.Location = new System.Drawing.Point(112, 48);
      this.txtHost.Name = "txtHost";
      this.txtHost.Size = new System.Drawing.Size(253, 26);
      this.txtHost.TabIndex = 0;
      // 
      // lblSerialPort
      // 
      this.lblSerialPort.AutoSize = true;
      this.lblSerialPort.Location = new System.Drawing.Point(24, 17);
      this.lblSerialPort.Name = "lblSerialPort";
      this.lblSerialPort.Size = new System.Drawing.Size(82, 20);
      this.lblSerialPort.TabIndex = 2;
      this.lblSerialPort.Text = "Serial Port";
      this.lblSerialPort.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // lblHostName
      // 
      this.lblHostName.AutoSize = true;
      this.lblHostName.Location = new System.Drawing.Point(17, 51);
      this.lblHostName.Name = "lblHostName";
      this.lblHostName.Size = new System.Drawing.Size(89, 20);
      this.lblHostName.TabIndex = 3;
      this.lblHostName.Text = "Host Name";
      this.lblHostName.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // btnStart
      // 
      this.btnStart.Location = new System.Drawing.Point(112, 80);
      this.btnStart.Name = "btnStart";
      this.btnStart.Size = new System.Drawing.Size(75, 30);
      this.btnStart.TabIndex = 2;
      this.btnStart.Text = "Start";
      this.btnStart.UseVisualStyleBackColor = true;
      this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
      // 
      // txtOutput
      // 
      this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtOutput.Location = new System.Drawing.Point(13, 117);
      this.txtOutput.Multiline = true;
      this.txtOutput.Name = "txtOutput";
      this.txtOutput.ReadOnly = true;
      this.txtOutput.Size = new System.Drawing.Size(546, 254);
      this.txtOutput.TabIndex = 5;
      // 
      // btnStop
      // 
      this.btnStop.Enabled = false;
      this.btnStop.Location = new System.Drawing.Point(194, 80);
      this.btnStop.Name = "btnStop";
      this.btnStop.Size = new System.Drawing.Size(75, 30);
      this.btnStop.TabIndex = 3;
      this.btnStop.Text = "Stop";
      this.btnStop.UseVisualStyleBackColor = true;
      this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
      // 
      // lblPort
      // 
      this.lblPort.AutoSize = true;
      this.lblPort.Location = new System.Drawing.Point(371, 51);
      this.lblPort.Name = "lblPort";
      this.lblPort.Size = new System.Drawing.Size(38, 20);
      this.lblPort.TabIndex = 7;
      this.lblPort.Text = "Port";
      // 
      // txtPort
      // 
      this.txtPort.Location = new System.Drawing.Point(416, 48);
      this.txtPort.MaxLength = 6;
      this.txtPort.Name = "txtPort";
      this.txtPort.Size = new System.Drawing.Size(100, 26);
      this.txtPort.TabIndex = 1;
      this.txtPort.Text = "2947";
      // 
      // chkLogging
      // 
      this.chkLogging.AutoSize = true;
      this.chkLogging.Location = new System.Drawing.Point(416, 18);
      this.chkLogging.Name = "chkLogging";
      this.chkLogging.Size = new System.Drawing.Size(92, 24);
      this.chkLogging.TabIndex = 8;
      this.chkLogging.Text = "Logging";
      this.chkLogging.UseVisualStyleBackColor = true;
      // 
      // GPSToComForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(571, 383);
      this.Controls.Add(this.chkLogging);
      this.Controls.Add(this.txtPort);
      this.Controls.Add(this.lblPort);
      this.Controls.Add(this.btnStop);
      this.Controls.Add(this.txtOutput);
      this.Controls.Add(this.btnStart);
      this.Controls.Add(this.lblHostName);
      this.Controls.Add(this.lblSerialPort);
      this.Controls.Add(this.txtHost);
      this.Controls.Add(this.cboSerialport);
      this.Name = "GPSToComForm";
      this.Text = "GPSD2Com";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GPSToComForm_FormClosing);
      this.Load += new System.EventHandler(this.GPSToComForm_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.IO.Ports.SerialPort oTransmitPort;
    private System.Windows.Forms.ComboBox cboSerialport;
    private System.Windows.Forms.TextBox txtHost;
    private System.Windows.Forms.Label lblSerialPort;
    private System.Windows.Forms.Label lblHostName;
    private System.Windows.Forms.Button btnStart;
    private System.Windows.Forms.TextBox txtOutput;
    private System.Windows.Forms.Button btnStop;
    private System.IO.Ports.SerialPort serialPort2;
    private System.Windows.Forms.Label lblPort;
    private System.Windows.Forms.TextBox txtPort;
    private System.Windows.Forms.CheckBox chkLogging;
  }
}

