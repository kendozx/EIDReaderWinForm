// Decompiled with JetBrains decompiler
// Type: EIDReaderForSAP.ContextMenus
// Assembly: EIDReaderForSAP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D226410D-D631-4893-A417-67A5726464ED
// Assembly location: C:\EIDReaderForSAP\EIDReaderForSAP.exe

using System;
using System.Drawing;
using System.Windows.Forms;

namespace EIDReaderWinForm
{
    internal class ContextMenus
    {
        private bool isAboutLoaded;
        private bool isSettingsLoaded;
        private ContextMenuStrip menu;
        private ProcessIcon processIcon;

        public ContextMenuStrip Create(ProcessIcon pi)
        {
            this.processIcon = pi;
            this.menu = new MaterialSkin.Controls.MaterialContextMenuStrip();
            ToolStripMenuItem toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem1.Text = "QUERY Employees";
            toolStripMenuItem1.Click += new EventHandler(this.Query_Click);
            toolStripMenuItem1.Image = (Image)Properties.Resources.search_24;
            this.menu.Items.Add((ToolStripItem)toolStripMenuItem1);
            ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem2.Text = "ADD New Employee";
            toolStripMenuItem2.Click += new EventHandler(this.Insert_Click);
            toolStripMenuItem2.Image = (Image)Properties.Resources.businessman_24;
            this.menu.Items.Add((ToolStripItem)toolStripMenuItem2);
            this.menu.Items.Add((ToolStripItem)new ToolStripSeparator());

            ToolStripMenuItem toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripMenuItem4.Text = "OPTION";
            toolStripMenuItem4.Click += new EventHandler(this.Settings_Click);
            toolStripMenuItem4.Image = (Image)Properties.Resources.settings_24;
            this.menu.Items.Add((ToolStripItem)toolStripMenuItem4);
            this.menu.Items.Add((ToolStripItem)new ToolStripSeparator());
            ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem3.Text = "EXIT";
            toolStripMenuItem3.Click += new EventHandler(this.Exit_Click);
            toolStripMenuItem3.Image = (Image)Properties.Resources.export_24;
            this.menu.Items.Add((ToolStripItem)toolStripMenuItem3);

            if (!this.isAboutLoaded)
            {
                this.isAboutLoaded = true;
                //int num = (int)new Form02_Insert().ShowDialog();
                MainStatic.form2.ShowDialog();
                this.isAboutLoaded = false;
            }

            return this.menu;
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            if (this.isSettingsLoaded)
                return;
            this.isSettingsLoaded = true;
            //int num = (int) new SettingsBox().ShowDialog();
            MainStatic.form_option = new Option();
            int num = (int)MainStatic.form_option.ShowDialog();
            this.isSettingsLoaded = false;
        }

        private void Query_Click(object sender, EventArgs e)
        {
            if (this.isAboutLoaded)
                return;
            this.isAboutLoaded = true;
            MainStatic.form1 = new Form01_Query();
            int num = (int)MainStatic.form1.ShowDialog();
            this.isAboutLoaded = false;
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            if (this.isAboutLoaded)
                return;
            this.isAboutLoaded = true;
            //int num = (int)new Form02_Insert().ShowDialog();
            //MainStatic.form2 = new Form02_Insert();
            //int num = (int)MainStatic.form2.ShowDialog();
            MainStatic.form2.Visible = true;
            this.isAboutLoaded = false;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            if(MainStatic.form1 != null)
                MainStatic.form1.Close();
            if (MainStatic.form2 != null)
                MainStatic.form2.Close();
            if (MainStatic.form_option != null)
                MainStatic.form_option.Close();
            Application.Exit();
        }
    }
}
