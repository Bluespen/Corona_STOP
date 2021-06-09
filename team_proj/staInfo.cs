using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team_proj
{
    public class StaInfo
    {

        public StaInfo()
        {

        }

        public StaInfo(string name, int num)
        {
            this.name = name;
            this.num = num;
        }

        private string name;
        public string Name
        {
            get
            {

                return name;

            }
            set
            {
                name = value;
            }
        }
        private int num;
        public int Num
        {
            get
            {
                return num;
            }
            set
            {
                num = value;
            }
        }




    }
}
