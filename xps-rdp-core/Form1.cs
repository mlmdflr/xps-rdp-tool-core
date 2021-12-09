using AxMSTSCLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xps_rdp_core
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 默认启动 端口默认为3389
        /// </summary>
        /// <param name="f_name"></param>
        /// <param name="server"></param>
        /// <param name="user_name"></param>
        /// <param name="user_password"></param>
        public Form1(string f_name, string server, string user_name, string user_password)
        {
            //载体窗口初始化
            FormInit(f_name, 1D, false);
            //远程对象初始化 默认是3389端口
            RdpInit(f_name, server, 3389, user_name, user_password);
        }

        /// <summary>
        /// 自定义图标
        /// </summary>
        /// <param name="f_name"></param>
        /// <param name="server"></param>
        /// <param name="user_name"></param>
        /// <param name="user_password"></param>
        /// <param name="is_u_icon"></param>
        public Form1(string f_name, string server, string user_name, string user_password, bool is_u_icon)
        {
            //载体窗口初始化
            FormInit(f_name, 1D, is_u_icon);
            //远程对象初始化 默认是3389端口
            RdpInit(f_name, server, 3389, user_name, user_password);
        }

        /// <summary>
        /// 自定义窗口透明度启动
        /// </summary>
        /// <param name="f_name"></param>
        /// <param name="server"></param>
        /// <param name="user_name"></param>
        /// <param name="user_password"></param>
        /// <param name="opacity"></param>
        public Form1(string f_name, string server, string user_name, string user_password, double opacity)
        {
            //载体窗口初始化
            FormInit(f_name, opacity, false);
            //远程对象初始化 默认是3389端口
            RdpInit(f_name, server, 3389, user_name, user_password);
        }

        /// <summary>
        /// 自定义窗口透明度 + 自定义图标
        /// </summary>
        /// <param name="f_name"></param>
        /// <param name="server"></param>
        /// <param name="user_name"></param>
        /// <param name="user_password"></param>
        /// <param name="opacity"></param>
        /// <param name="is_u_icon"></param>
        public Form1(string f_name, string server, string user_name, string user_password, double opacity, bool is_u_icon)
        {
            //载体窗口初始化
            FormInit(f_name, opacity, is_u_icon);
            //远程对象初始化 默认是3389端口
            RdpInit(f_name, server, 3389, user_name, user_password);
        }


        /// <summary>
        /// 自定义端口  启动
        /// </summary>
        /// <param name="f_name"></param>
        /// <param name="server"></param>
        /// <param name="port"></param>
        /// <param name="user_name"></param>
        /// <param name="user_password"></param>
        public Form1(string f_name, string server, int port, string user_name, string user_password)
        {
            //载体窗口初始化
            FormInit(f_name, 1D, false);
            //远程对象初始化 默认是3389端口
            RdpInit(f_name, server, port, user_name, user_password);
        }



        public Form1(string f_name, string server, int port, string user_name, string user_password, bool is_u_icon)
        {
            //载体窗口初始化
            FormInit(f_name, 1D, is_u_icon);
            //远程对象初始化 默认是3389端口
            RdpInit(f_name, server, port, user_name, user_password);
        }
        /// <summary>
        /// 自定义端口 + 自定义窗口透明度 启动
        /// </summary>
        /// <param name="f_name"></param>
        /// <param name="server"></param>
        /// <param name="port"></param>
        /// <param name="user_name"></param>
        /// <param name="user_password"></param>
        /// <param name="opacity"></param>
        public Form1(string f_name, string server, int port, string user_name, string user_password, double opacity)
        {
            //载体窗口初始化
            FormInit(f_name, opacity, false);
            //远程对象初始化 默认是3389端口
            RdpInit(f_name, server, port, user_name, user_password);
        }

        /// <summary>
        /// 自定义端口 + 自定义窗口透明度 + 自定义图标
        /// </summary>
        /// <param name="f_name"></param>
        /// <param name="server"></param>
        /// <param name="port"></param>
        /// <param name="user_name"></param>
        /// <param name="user_password"></param>
        /// <param name="opacity"></param>
        /// <param name="is_u_icon"></param>
        public Form1(string f_name, string server, int port, string user_name, string user_password, double opacity, bool is_u_icon)
        {
            //载体窗口初始化
            FormInit(f_name, opacity, is_u_icon);
            //远程对象初始化 默认是3389端口
            RdpInit(f_name, server, port, user_name, user_password);
        }



        /// <summary>
        /// rdp初始化函数
        /// </summary>
        /// <param name="f_name"></param>
        /// <param name="server"></param>
        /// <param name="port"></param>
        /// <param name="user_name"></param>
        /// <param name="user_password"></param>
        private void RdpInit(string f_name, string server, int port, string user_name, string user_password)
        {
            //创建远程对象
            AxMsRdpClient7NotSafeForScripting axMsRdpc = new AxMsRdpClient7NotSafeForScripting();

            //远程对象初始化 开始
            ((ISupportInitialize)axMsRdpc).BeginInit();
            axMsRdpc.Dock = DockStyle.Fill;
            axMsRdpc.Enabled = true;
            Controls.Add(axMsRdpc);
            WindowState = FormWindowState.Maximized;
            ((ISupportInitialize)(axMsRdpc)).EndInit();
            //远程对象初始化 结束


            // RDP名字
            axMsRdpc.Name = f_name;
            // 服务器地址
            axMsRdpc.Server = server;
            // 远程登录账号
            axMsRdpc.UserName = user_name;
            // 远程端口号
            axMsRdpc.AdvancedSettings7.RDPPort = port;
            // 远程登录密码
            axMsRdpc.AdvancedSettings7.ClearTextPassword = user_password;
            // 自动控制屏幕显示尺寸
            axMsRdpc.AdvancedSettings7.SmartSizing = false;
            // 启用CredSSP身份验证（有些服务器连接没有反应，需要开启这个）
            axMsRdpc.AdvancedSettings7.EnableCredSspSupport = true;
            // 禁用公共模式
            axMsRdpc.AdvancedSettings7.PublicMode = false;
            // 颜色位数 8,16,24,32
            axMsRdpc.ColorDepth = 32;
            // 开启全屏 true|flase
            axMsRdpc.FullScreen = false;
            //设置远程桌面宽度为显示器宽度
            //axMsRdpc.DesktopWidth = ScreenArea.Width;
            //连接本地磁盘
            axMsRdpc.AdvancedSettings7.RedirectDrives = false;
            //设置远程桌面高宽为窗口高宽
            axMsRdpc.DesktopWidth = ClientRectangle.Width;
            axMsRdpc.DesktopHeight = ClientRectangle.Height;
            //共享剪贴板
            axMsRdpc.AdvancedSettings7.RedirectClipboard = true;
            //开启连接
            axMsRdpc.Connect();
        }

        /// <summary>
        /// 载体窗口初始化
        /// </summary>
        /// <param name="f_name"></param>
        /// <param name="opacity"></param>
        /// <param name="is_u_icon"></param>
        private void FormInit(string f_name, double opacity, bool is_u_icon)
        {
            //命名
            Name = f_name;
            Text = f_name;
            //图标
            if (is_u_icon)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
                Icon = (Icon)resources.GetObject("$this.Icon");
            }
            //单线边框
            FormBorderStyle = FormBorderStyle.FixedSingle;
            //窗体透明度
            Opacity = opacity;
            //初始化大小
            Size = new Size(1024, 768);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
