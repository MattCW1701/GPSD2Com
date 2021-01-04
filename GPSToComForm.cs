using System;
using System.IO;
using System.IO.Ports;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GPSD2Com
{
  public partial class GPSToComForm : Form
  {
    Thread thTCPReadThread;
    public delegate void UpdateTextbox(string sText);
    public UpdateTextbox UpdateTextboxDelegate;
    private volatile bool bTerminateTCPThread = false;
    private volatile bool bLogging = false;

    TcpClient tcpClient;
    NetworkStream nsStream;
    StreamWriter swWriter;

    /// <summary>
    /// Constructor
    /// </summary>
    public GPSToComForm()
    {
      InitializeComponent();      
      UpdateTextboxDelegate = new UpdateTextbox(UpdateTextboxMethod);
    }

    /// <summary>
    /// Load method
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void GPSToComForm_Load(object sender, EventArgs e)
    {
      string[] sarPortNames = SerialPort.GetPortNames();
      foreach (string sPortName in sarPortNames)
      {
        cboSerialport.Items.Add(sPortName);
      }
      cboSerialport.Text = sarPortNames[0];
      txtHost.Text = GPSDirectToCom.Properties.Settings.Default.DefaultHostname;      
    }

    /// <summary>
    /// Closing handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void GPSToComForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      Cleanup();
      GPSDirectToCom.Properties.Settings.Default.DefaultHostname = txtHost.Text;
      GPSDirectToCom.Properties.Settings.Default.Save();
    }

    /// <summary>
    /// Start button handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnStart_Click(object sender, EventArgs e)
    {
      if(chkLogging.Checked)
      {
        swWriter = new StreamWriter($"GPSDToCom_{DateTime.Now.ToString("yyyyMMddHHmmss")}.log");
        bLogging = true;
      }
      bTerminateTCPThread = false;
      
      if (SetupGPSDConnection())
      {
        SetupSerial();
        EnableControls(true);
        thTCPReadThread = new Thread(ReadTCPMethod);
        thTCPReadThread.Start();
      }        
    }

    /// <summary>
    /// Stop button handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnStop_Click(object sender, EventArgs e)
    {
      Cleanup();
      EnableControls(false);
    }

    /// <summary>
    /// Method to update text box with the specified text
    /// </summary>
    /// <param name="sText"></param>
    private void UpdateTextboxMethod(string sText)
    {
      txtOutput.Text = sText;
    }

    /// <summary>
    /// Method to setup and open the serial port
    /// </summary>
    private void SetupSerial()
    {
      if (!string.IsNullOrWhiteSpace(cboSerialport.Text))
      {
        oTransmitPort.BaudRate = 4800;
        oTransmitPort.PortName = cboSerialport.Text;
        oTransmitPort.Open();
      }
    }

    /// <summary>
    /// Method to setup the TCP connection to GPSD and start the main listening thread
    /// </summary>
    private bool SetupGPSDConnection()
    {
      try
      {
        tcpClient = new TcpClient(txtHost.Text, int.Parse(txtPort.Text));
      }
      catch(Exception ex)
      {
        MessageBox.Show(ex.Message, "Error");
        return false;
      }
      
      nsStream = tcpClient.GetStream();
      if (!tcpClient.Connected)
        return false;
      byte[] data = Encoding.ASCII.GetBytes("?WATCH={\"enable\":true,\"nmea\":true}");
      nsStream.Write(data, 0, data.Length);
      return true;
    }

    /// <summary>
    /// Method to read from the TCP connectionss
    /// </summary>
    private void ReadTCPMethod()
    {     
      while(!bTerminateTCPThread)
      {
        byte[] yarData = new byte[256];
        if (!nsStream.CanRead || !nsStream.DataAvailable)
          continue;
        int bytes = nsStream.Read(yarData, 0, yarData.Length);
        string sRead = Encoding.ASCII.GetString(yarData, 0, bytes);
        txtOutput.Invoke(UpdateTextboxDelegate, sRead);
        
        oTransmitPort.Write(sRead);
        if(bLogging)
          swWriter.WriteLine(sRead);
      }
    }

    /// <summary>
    /// Method to close the serial port
    /// </summary>
    private void CloseSerial()
    {
      try
      {
        oTransmitPort.Close();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    /// <summary>
    /// Enables or disables the screen controls
    /// </summary>
    /// <param name="bRunning">Pass true if the read loop will be running</param>
    private void EnableControls(bool bRunning)
    {
      btnStart.Enabled = !bRunning;      
      chkLogging.Enabled = !bRunning;
      cboSerialport.Enabled = !bRunning;
      txtHost.Enabled = !bRunning;
      txtPort.Enabled = !bRunning;

      btnStop.Enabled = bRunning;
    }

    /// <summary>
    /// Safely handle stopping the threads and closing network and serial resources
    /// </summary>
    private void Cleanup()
    {
      bTerminateTCPThread = true;
      if (thTCPReadThread != null && thTCPReadThread.IsAlive)
        thTCPReadThread.Join(500);
      //thTCPReadThread.Abort();
      if (oTransmitPort.IsOpen)
      {
        Thread thCloseSerial = new Thread(new ThreadStart(CloseSerial));
        thCloseSerial.Start();
      }
      if (nsStream != null)
        nsStream.Close();
      if (tcpClient != null)
        tcpClient.Close();
      if (bLogging)
        swWriter.Close();
    }
  }
}
