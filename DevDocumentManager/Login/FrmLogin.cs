using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraPrinting;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DevDocumentManager
{
    public partial class FrmLogin : XtraForm
    {
        public FrmLogin()
        {
            InitializeComponent();
            InitCustomUI();
        }

        private void InitCustomUI()
        {
            // 设置窗体属性
            this.Text = "用户登录";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ClientSize = new Size(350, 260);
            this.LookAndFeel.SkinName = "Office 2019 Colorful";

            // Logo
            var logo = new PictureEdit
            {
                Image = Properties.Resources.Logo_png, // 替换为你的Logo资源
                Location = new Point(120, 15),
                Size = new Size(170, 60),
                BorderStyle = BorderStyles.NoBorder,
            };
            logo.Properties.SizeMode = PictureSizeMode.Squeeze;

            // 用户名
            var lblUser = new LabelControl
            {
                Text = "用户名",
                Location = new Point(50, 90),
                Font = new Font("微软雅黑", 10)
            };
            var txtUser = new TextEdit
            {
                Name = "txtUser",
                Location = new Point(120, 85),
                Width = 170,
                Properties = { NullValuePrompt = "请输入用户名" }
            };
            txtUser.Properties.Appearance.Font = new Font("微软雅黑", 10);

            // 密码
            var lblPwd = new LabelControl
            {
                Text = "密码",
                Location = new Point(50, 130),
                Font = new Font("微软雅黑", 10)
            };
            var txtPwd = new TextEdit
            {
                Name = "txtPwd",
                Location = new Point(120, 125),
                Width = 170,
                Properties = { PasswordChar = '●', NullValuePrompt = "请输入密码" }
            };
            txtPwd.Properties.Appearance.Font = new Font("微软雅黑", 10);

            // 登录按钮
            var btnLogin = new SimpleButton
            {
                Text = "登录",
                Location = new Point(120, 170),
                Width = 170,
                Height = 32,
                Appearance = { BackColor = Color.FromArgb(0, 120, 215), ForeColor = Color.White }
            };
            btnLogin.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;

            // 记住密码
            var chkRemember = new CheckEdit
            {
                Text = "记住密码",
                Location = new Point(120, 210),
                Width = 85
            };

            // 忘记密码
            var lblForget = new LabelControl
            {
                Text = "忘记密码？",
                Location = new Point(210, 212),
                ForeColor = Color.FromArgb(0, 120, 215),
                Cursor = Cursors.Hand
            };

            // 添加控件
            this.Controls.Add(logo);
            this.Controls.Add(lblUser);
            this.Controls.Add(txtUser);
            this.Controls.Add(lblPwd);
            this.Controls.Add(txtPwd);
            this.Controls.Add(btnLogin);
            this.Controls.Add(chkRemember);
            this.Controls.Add(lblForget);

            // 回车登录
            this.AcceptButton = btnLogin;
        }
    }
}