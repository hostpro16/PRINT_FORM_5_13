using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRINT_FORM_5_13
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }



        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Tạo DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("ean", typeof(string));
            dt.Columns.Add("mnozstvi", typeof(string));
            dt.Columns.Add("hsd", typeof(string));

            // Thêm thủ công từng dòng dữ liệu
            dt.Rows.Add("02114111", "9", "12.05.2025");
            dt.Rows.Add("05064900", "2", "09.04.2025");
            dt.Rows.Add("05065450", "18", "09.04.2025");
            dt.Rows.Add("05062690", "23", "10.04.2025");
            dt.Rows.Add("05062691", "103", "10.04.2025");
            dt.Rows.Add("05063697", "1", "10.04.2025");
            dt.Rows.Add("05063698", "1", "10.04.2025");
            dt.Rows.Add("05065071", "1", "10.04.2025");
            dt.Rows.Add("05060065", "1", "11.04.2025");
            dt.Rows.Add("05060072", "1", "11.04.2025");
            dt.Rows.Add("05063578", "3", "11.04.2025");
            dt.Rows.Add("05064906", "2", "11.04.2025");
            dt.Rows.Add("05061883", "1", "21.04.2025");
            dt.Rows.Add("05061898", "1", "21.04.2025");
            dt.Rows.Add("05060383", "4", "22.04.2025");
            dt.Rows.Add("01020563", "48", "14.04.2025");
            dt.Rows.Add("01014222", "48", "16.04.2025");
            dt.Rows.Add("01014223", "240", "17.04.2025");
            dt.Rows.Add("01014387", "120", "22.04.2025");
            dt.Rows.Add("01014385", "320", "22.04.2025");
            dt.Rows.Add("01080014", "24", "23.04.2025");
            dt.Rows.Add("01010884", "102", "30.04.2025");
            dt.Rows.Add("01012545", "120", "30.04.2025");
            dt.Rows.Add("01012101", "48", "30.04.2025");
            dt.Rows.Add("01014199", "310", "30.04.2025");
            dt.Rows.Add("01014200", "24", "30.04.2025");
            dt.Rows.Add("01014366", "1500", "31.05.2025");


            // Tạo DataTable mới để chứa kết quả sau khi rã dòng
            DataTable dtExpanded = new DataTable();
            dtExpanded.Columns.Add("ean", typeof(string));
            dtExpanded.Columns.Add("mnozstvi", typeof(string));
            dtExpanded.Columns.Add("hsd", typeof(string));

            // Lặp qua từng dòng trong DataTable gốc
            foreach (DataRow row in dt.Rows)
            {
                string ean = row["ean"].ToString();
                string hsd = row["hsd"].ToString();
                int mnozstvi = int.Parse(row["mnozstvi"].ToString());

                // Thêm 'mnozstvi' dòng mới, mỗi dòng chỉ có số lượng = 1
                for (int i = 0; i < mnozstvi; i++)
                {
                    dtExpanded.Rows.Add(ean, "1", hsd);
                }
            }

            int totalRows = dtExpanded.Rows.Count;
            int rowsPerPage = 65;
            int totalPages = (int)Math.Ceiling((double)totalRows / rowsPerPage);

            MessageBox.Show($"{totalPages} trang");

        }
    }
}
