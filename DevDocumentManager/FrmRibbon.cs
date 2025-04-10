using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;

namespace DevDocumentManager
{
	public partial class FrmRibbon: DevExpress.XtraEditors.XtraForm
	{
        public FrmRibbon()
		{
            InitializeComponent();
		}


        #region 打开窗体和关闭窗体的方法

        private void LoadTabPageForm(XtraTabControl tabcontrol, Form form, String title)
        {
            bool found = false;
            XtraTabPage selectedPage = null;
            foreach (XtraTabPage page in tabcontrol.TabPages)
            {
                if (page.Tag != null && page.Text == title)
                {
                    found = true;
                    selectedPage = page;
                    break;
                }
            }
            if (!found)
            {
                selectedPage = new XtraTabPage();
                selectedPage.Text = title;
                selectedPage.Tag = form;
                form.TopLevel = false;
                form.Dock = DockStyle.Fill;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Show();
                selectedPage.Controls.Clear();
                selectedPage.Controls.Add(form);

                if (!form.IsDisposed)
                {
                    tabcontrol.SelectedTabPage = selectedPage;
                    tabcontrol.TabPages.Add(selectedPage);   //把tabpage加入到tabcontrol里
                }
            }
            else
            {
                if (selectedPage.Tag != null && selectedPage.Tag != form)
                {
                    form.TopLevel = false;
                    form.Dock = DockStyle.Fill;
                    form.FormBorderStyle = FormBorderStyle.None;
                    form.Show();
                    selectedPage.Controls.Clear();
                    selectedPage.Controls.Add(form);
                }
            }
            selectedPage.BringToFront();
            tabcontrol.SelectedTabPage = selectedPage;
        }

        #endregion

        /// <summary>
        /// 客户管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmCustomerManagement frmCustomer = new FrmCustomerManagement();

            LoadTabPageForm(xTabPages, frmCustomer, "客户管理");
        }
    }
}