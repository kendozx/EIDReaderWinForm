// Decompiled with JetBrains decompiler
// Type: EIDReaderForSAP.ProcessIcon
// Assembly: EIDReaderForSAP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D226410D-D631-4893-A417-67A5726464ED
// Assembly location: C:\EIDReaderForSAP\EIDReaderForSAP.exe

using EIDReaderWinForm.Properties;
using System;
using System.Windows.Forms;

namespace EIDReaderWinForm
{
  internal class ProcessIcon : IDisposable
  {
    private static NotifyIcon ni;

    public ProcessIcon()
    {
      if (ProcessIcon.ni != null)
        return;
      ProcessIcon.ni = new NotifyIcon();
      Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
    }

    public NotifyIcon getNotifyIcon()
    {
      return ProcessIcon.ni;
    }

    public void Display()
    {
      ProcessIcon.ni.MouseClick += new MouseEventHandler(this.ni_MouseClick);
      ProcessIcon.ni.Icon = Properties.Resources.iconE2;
      ProcessIcon.ni.Text = "e-ID Reader to SuccessFactors";
      ProcessIcon.ni.Visible = true;
      ProcessIcon.ni.ContextMenuStrip = new ContextMenus().Create();
    }

    public void Dispose()
    {
      ProcessIcon.ni.Dispose();
    }

    private void ni_MouseClick(object sender, MouseEventArgs e)
    {
      int num = (int) e.Button;
    }

    private void OnApplicationExit(object sender, EventArgs e)
    {
      ProcessIcon.ni.Dispose();
    }
  }
}
