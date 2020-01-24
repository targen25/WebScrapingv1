using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace webScraping
{
    public partial class fmWebScraping : Form
    {
         DataTable table;
         int inputYahoo = 0;
         int inputBind = 0;

        public fmWebScraping()
        {
            InitializeComponent();
            IniTable();
        }

        private void IniTable()
        {
            table = new DataTable();
            table.Columns.Add("Search Engines Yahoo", typeof(string));
            table.Columns.Add("Search Engines Bind", typeof(string));
            table.Columns.Add("Winner", typeof(string));
            dgvResult.DataSource = table;
        }
        private void buSearch_Click(object sender, EventArgs e)
        {
            var input = "\""+ txSearch.Text+"\"";
            table.Rows.Add(inputYahoo, inputBind, "");
            GetHtml(input);
            
        }
        private async void GetHtml(string input)
        {
            //----Result of yahoo
            EntityResult eResult = new EntityResult();
            inputYahoo = await eResult.GetResultYahoo(input);
            table.Rows[0][0] = inputYahoo;
            //----Result of bind
            inputBind = await eResult.GetResultBind(input);
            table.Rows[0][1] = inputBind;
            //---Compare the result of the two search engines
            if (inputYahoo > inputBind)
            {
                table.Rows[0][2] = "Yahoo";
            }
            else
            {
                table.Rows[0][2] = "Bind";
            }

        }

        private void buClear_Click(object sender, EventArgs e)
        {
            txSearch.Text = "";
            IniTable();
            table.Clear();
            inputYahoo = 0;
            inputBind = 0;

        }
    }
}
