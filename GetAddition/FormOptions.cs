using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetAddition
{
    public partial class FormOptions : Form
    {
        public List<string> AllProxies { get; set; }
        public List<string> Selected { get; set; }

        public FormOptions()
        {
            InitializeComponent();
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            while (lbProxies.Items.Count > 0)
            {
                var item = lbProxies.Items[0];
                lbDeleted.Items.Add(item);
                lbProxies.Items.RemoveAt(0);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<object> selected = new List<object>();
            foreach (var item in lbProxies.SelectedIndices)
            {
                selected.Add(lbProxies.Items[(int)item]);
            }
            foreach (var item in selected)
            {
                lbDeleted.Items.Add(item);
                lbProxies.Items.Remove(item);
            }
        }

        private void btnRestoreAll_Click(object sender, EventArgs e)
        {
            while (lbDeleted.Items.Count > 0)
            {
                var item = lbDeleted.Items[0];
                lbProxies.Items.Add(item);
                lbDeleted.Items.RemoveAt(0);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            List<object> selected = new List<object>();
            foreach (var item in lbDeleted.SelectedIndices)
            {
                selected.Add(lbDeleted.Items[(int)item]);
            }
            foreach (var item in selected)
            {
                lbProxies.Items.Add(item);
                lbDeleted.Items.Remove(item);
            }
        }

        private void FormOptions_Load(object sender, EventArgs e)
        {
            lbProxies.Items.Clear();
            foreach (var item in this.Selected)
            {
                lbProxies.Items.Add(item);
            }
            foreach (var item in this.AllProxies)
            {
                if (this.Selected.Contains(item) == false)
                {
                    lbDeleted.Items.Add(item);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Selected.Clear();
            foreach (var item in lbProxies.Items)
            {
                this.Selected.Add(item.ToString());
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in this.Selected)
            {
                sb.Append(item + ",");
            }
            System.IO.File.WriteAllText("settings.txt", sb.ToString().TrimEnd(new char[]{','}));
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
