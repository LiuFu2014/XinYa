using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XinYa.DAL;

namespace XinYa.UI.WorkStation
{
    public partial class frm_WorkStationView : Form
    {
        public frm_WorkStationView()
        {
            InitializeComponent();
            this.dgv_Main.AutoGenerateColumns = false;
            DataInit();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void DataInit()
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                dgv_Main.DataSource = db.TB_SecondWorkStationInfo.ToList();
            }
        }
    }
}
