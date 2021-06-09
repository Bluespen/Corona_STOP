using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace team_proj
{
    public class Excel
    {
        string path = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;


        public Excel(string path, int Sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[Sheet];
        }
        public string ReadCell(int i, int j)
        {

            i++;
            j++;
            Range startRange = ws.Cells[i, j];
            Range endRange = ws.Cells[i + 1, j + 1];
            Range range = ws.get_Range(startRange, endRange);

            Object[,] rawData = range.Value;

            string data = "";
            
            return rawData[1,2].ToString();


        }
        public void Excel_Close()
        {
            wb.Close();
            excel.Quit();

            System.Diagnostics.Process[] AfterExcelProcess;
            AfterExcelProcess = System.Diagnostics.Process.GetProcessesByName("EXCEL");

            for(int i = 0; i< AfterExcelProcess.Length;i++)
            {
               // if (!arlProcessID.Contains(AfterExcelProcess[i].Id))
                    AfterExcelProcess[i].Kill();
            }

        }

        ~Excel()
        {
            wb.Close();
            excel.Quit();
        }


    }
}
