using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team_proj
{
    public class GuInfo
    {
        private List<StaInfo> staInfos = new List<StaInfo>();

        public GuInfo()
        {

        }

        public GuInfo(string name, StaInfo sta)
        {
            this.name = name;
            this.staInfos.Add(sta);

        }
        private string name;

        

        public List<StaInfo> StaInfos
        {
            get
            {
                return staInfos;
            }
        }
    }
}
