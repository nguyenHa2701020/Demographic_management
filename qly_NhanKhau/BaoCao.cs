using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qly_NhanKhau
{
    public partial class BaoCao : Form
    {
        public BaoCao()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
        public void ShowReport(string reportFileName, string recordFilter, string reportTitle = "")
        {
            //1. Nap report
            ReportDocument rpt = new ReportDocument();
            string path = string.Format("{0}\\Reports\\{1}", Application.StartupPath, reportFileName);
            
            rpt.Load(path);
            //2. Cap nhat nguon du lieu
            TableLogOnInfo logOnInfo = new TableLogOnInfo();
            logOnInfo.ConnectionInfo.ServerName = ".\\MAYCHU";
            logOnInfo.ConnectionInfo.DatabaseName = "SQL_QLNK";
            logOnInfo.ConnectionInfo.UserID = "HaNguyen";
            logOnInfo.ConnectionInfo.Password = "123456";
            foreach (Table t in rpt.Database.Tables)
            {
                t.ApplyLogOnInfo(logOnInfo);

            }
            //3.
            if (!string.IsNullOrEmpty(recordFilter))
            {
                rpt.RecordSelectionFormula = recordFilter;
            }
            if (!string.IsNullOrEmpty(reportTitle))
            {
                rpt.SummaryInfo.ReportTitle = reportTitle;
            }

            rpt.SummaryInfo.ReportTitle = "DANH SÁCH";
            //4. Hien thi
            crystalReportViewer1.ReportSource = rpt;

        }

        private void BaoCao_Load(object sender, EventArgs e)
        {

        }
    }
}

