using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Queue_Monitoring
{
    public partial class FullSchedule : Form
    {
        string xlsfilename = "";
        string xlsfilepath = @"\\caicssarea51\Support\Team_Schedules-DoNotDelete\Sage_100_ERP\Current Schedule\";
        string AnalystName = string.Empty;
        public FullSchedule(string Analyst)
        {
            InitializeComponent();
            if (Analyst.Trim() != "")
            {
                AnalystName = Analyst;
                
            }
        }

        private void FullSchedule_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = DateTime.Today.DayOfWeek.ToString();
                foreach (string vfile in Directory.GetFiles(xlsfilepath))
                {
                    DateTime Latesttime = DateTime.Today;

                    if (vfile.Contains('~') == false && vfile.Contains(".xls"))
                    {
                        if (xlsfilename == string.Empty)
                        {
                            Latesttime = File.GetLastWriteTime(vfile);
                            xlsfilename = vfile;
                        }
                        if (File.GetLastWriteTime(vfile) > Latesttime)
                        {
                            Latesttime = File.GetLastWriteTime(vfile);
                            xlsfilename = vfile.Remove(vfile.LastIndexOf('\\'));

                        }

                    }
                }

                string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + xlsfilename + ";Extended Properties=\"Excel 12.0;HDR=NO;Readonly=True;IMEX=1\"";
                DataTable ds = new DataTable();
                using (OleDbConnection oledb = new OleDbConnection(ConnectionString))
                {
                    oledb.Open();
                    OleDbDataAdapter ad = new OleDbDataAdapter("select * from [" + DateTime.Now.DayOfWeek + "$A5:BM]", oledb);
                    ad.Fill(ds);
                    ExcelSchedule.AutoGenerateColumns = true;
                    ExcelSchedule.DataSource = ds;
                    oledb.Close();
                }
                SetColTimes();
                SelectAnalystRow();
            }
                
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }
        private void SelectAnalystRow()
        {
            foreach (DataGridViewRow  row in ExcelSchedule.Rows)
            {
                if (row.Cells["F1"].Value.ToString() == AnalystName)
                {
                    ExcelSchedule.Columns["F1"].Frozen = true;
                    //ExcelSchedule.Columns["F1"].AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    row.Selected = true;
                    ExcelSchedule.FirstDisplayedScrollingRowIndex = row.Index;
                    string tmpcolumn = CurrentTimeColumn();
                    ExcelSchedule.FirstDisplayedScrollingColumnIndex = ExcelSchedule.Columns[CurrentTimeColumn()].Index;
                    row.Cells[0].Selected = true;
                }
            }

        }

        private string CurrentTimeColumn()
        {
            int hours = DateTime.Now.Hour;
            int minutes = DateTime.Now.Minute;
            hours = (hours - 5) * 4;
            minutes = minutes / 15;
            int currentrowposition = hours + minutes + 6;
            if (currentrowposition > 65) { currentrowposition = -1; }
            return "F" + currentrowposition.ToString();
        }
        private void SetColTimes()
        {
            foreach (DataGridViewColumn col in ExcelSchedule.Columns)
            {
                int tmpcolheaderint = Convert.ToInt32(col.Name.Replace('F',' ').Trim());
                if (tmpcolheaderint >= 6)
                {
                    //very ugly but it works, would like to change to a formula at some point
                    switch (tmpcolheaderint)
                    {
                        case 6:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "5:00";break;
                        case 7:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "5:15"; break;
                        case 8:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "5:30"; break;
                        case 9:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "5:45"; break;
                        case 10:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "6:00"; break;
                        case 11:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "6:15"; break;
                        case 12:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "6:30"; break;
                        case 13:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "6:45"; break;
                        case 14:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "7:00"; break;
                        case 15:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "7:15"; break;
                        case 16:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "7:30"; break;
                        case 17:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "7:45"; break;
                        case 18:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "8:00"; break;
                        case 19:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "8:15"; break;
                        case 20:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "8:30"; break;
                        case 21:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "8:45"; break;
                        case 22:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "9:00"; break;
                        case 23:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "9:15"; break;
                        case 24:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "9:30"; break;
                        case 25:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "9:45"; break;
                        case 26:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "10:00"; break;
                        case 27:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "10:15"; break;
                        case 28:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "10:30"; break;
                        case 29:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "10:45"; break;
                        case 30:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "11:00"; break;
                        case 31:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "11:15"; break;
                        case 32:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "11:30"; break;
                        case 33:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "11:45"; break;
                        case 34:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "12:00"; break;
                        case 35:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "12:15"; break;
                        case 36:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "12:30"; break;
                        case 37:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "12:45"; break;
                        case 38:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "1:00"; break;
                        case 39:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "1:15"; break;
                        case 40:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "1:30"; break;
                        case 41:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "1:45"; break;
                        case 42:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "2:00"; break;
                        case 43:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "2:15"; break;
                        case 44:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "2:30"; break;
                        case 45:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "2:45"; break;
                        case 46:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "3:00"; break;
                        case 47:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "3:15"; break;
                        case 48:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "3:30"; break;
                        case 49:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "3:45"; break;
                        case 50:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "4:00"; break;
                        case 51:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "4:15"; break;
                        case 52:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "4:30"; break;
                        case 53:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "4:45"; break;
                        case 54:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "5:00"; break;
                        case 55:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "5:15"; break;
                        case 56:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "5:30"; break;
                        case 57:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "5:45"; break;
                        case 58:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "6:00"; break;
                        case 59:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "6:15"; break;
                        case 60:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "6:30"; break;
                        case 61:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "6:45"; break;
                        case 62:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "7:00"; break;
                        case 63:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "7:15"; break;
                        case 64:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "7:30"; break;
                        case 65:
                            ExcelSchedule.Columns["F"+tmpcolheaderint.ToString()].HeaderText = "7:45"; break;
                    }
                }
            }
        }

 
    }
}
