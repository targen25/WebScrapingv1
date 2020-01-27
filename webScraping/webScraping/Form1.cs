using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace webScraping
{
    public partial class fmWebScraping : Form
    {
         DataTable table;
         long inputYahoo = 0;
         long inputBing = 0;
         long totalWinner = 0;
         string totalWinnerDescripcion = "";

        public fmWebScraping()
        {
            InitializeComponent();
            IniTable();
        }

        private void IniTable()
        {
            table = new DataTable();
            table.Columns.Add("Search Engines Yahoo", typeof(string));
            table.Columns.Add("Search Engines Bing", typeof(string));
            table.Columns.Add("Winner", typeof(string));
            dgvResult.DataSource = table;
        }
        private void buSearch_Click(object sender, EventArgs e)
        {
            string[] inputs;
            int star, end;
            string textQuotationMarkTemp, onlyWordWithSpace;
            string textQuotationMark = "";
            List<string> items = new List<string>();
            //--checking if the text contains a quotation mark
            if (txSearch.Text.Contains("\""))
            {
                star = txSearch.Text.IndexOf("\"")+1;
                textQuotationMarkTemp = txSearch.Text.Substring(star, txSearch.Text.Length - star);                
                end = textQuotationMarkTemp.IndexOf("\"");
                textQuotationMark = textQuotationMarkTemp.Substring(0, end);
                onlyWordWithSpace = txSearch.Text.Remove(star-1, end+2);
                inputs = onlyWordWithSpace.Split(' ');
            }
            else
            {
                inputs = txSearch.Text.Split(' ');
            }
            
            //---filling the items list with the result of the inputs array
            for (int i = 0; i < inputs.Length; ++i)
            {
                if (inputs[i] != "")
                {
                    items.Add(inputs[i]);
                }                
            }
            //---add to the list the work between quotation marks
            if (txSearch.Text.Contains("\""))
            {
                items.Add(textQuotationMark);
            }                
            //---call the method GetHtml for each item of list items
            for (int i= 0; i< items.Count; i++)
            {
                table.Rows.Add(inputYahoo, inputBing, "");
                GetHtml(i, items[i]);
            }
            

        }
        private async void GetHtml(int row,string item)
        {
            inputYahoo = 0;
            inputBing = 0;
            //----Result of yahoo
            SearchEngine oSearchYahoo = Creator.CreatorSearchEngine(Creator.YAHOO);
            inputYahoo = await oSearchYahoo.GetResult(item);
            table.Rows[row][0] = inputYahoo;
            //----Result of bing
            SearchEngine oSearchBind = Creator.CreatorSearchEngine(Creator.BING);
            inputBing = await oSearchBind.GetResult(item);
            table.Rows[row][1] = inputBing;
            //---Compare the result of the two search engines
            if (inputYahoo > inputBing)
            {
                table.Rows[row][2] = "Yahoo "+item;
            }
            else
            {
                table.Rows[row][2] = "Bing " + item;
            }
        }

        private void buClear_Click(object sender, EventArgs e)
        {
            txSearch.Text = "";
            txTotalWinner.Text = "";
            totalWinnerDescripcion = "";
            IniTable();
            table.Clear();
            inputYahoo = 0;
            inputBing = 0;
            totalWinner = 0;

        }

        private void buShowTotalWinner_Click(object sender, EventArgs e)
        {
            long totalWinnerTemp = 0;
            string totalWinnerDescripcionTemp = "";
            long value1 = 0;
            long value2 = 0;
            //---Searching the highest value of each row
            for (int fila = 0; fila < table.Rows.Count; fila++)
            {
                value1 = Convert.ToInt64(dgvResult.Rows[fila].Cells[0].Value.ToString());
                value2 = Convert.ToInt64(dgvResult.Rows[fila].Cells[1].Value.ToString());
                totalWinnerDescripcionTemp = dgvResult.Rows[fila].Cells[2].Value.ToString();
                if (value1 > value2)
                {
                   totalWinnerTemp = value1;
                }
                else
                {
                    totalWinnerTemp = value2;
                }
                if (totalWinnerTemp > totalWinner)
                {
                    totalWinner = totalWinnerTemp;
                    totalWinnerDescripcion = totalWinnerDescripcionTemp;
                }
            }
            //---Showing the total winner of two search engines
            txTotalWinner.Text = totalWinnerDescripcion;

        }
    }
}
