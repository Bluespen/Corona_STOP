using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Microsoft.Office.Interop.Excel;
using System.ComponentModel.Design;

namespace team_proj
{

    public partial class Form3 : Form
    {
        static string cur_path = Directory.GetCurrentDirectory().ToString();
        static string prj_path = Path.GetFullPath(Path.Combine(cur_path, @"..\..\..\"));
        string excel_path = Path.GetFullPath(Path.Combine(prj_path, @"proj_exel.xlsx"));
        static string station_txt = Path.GetFullPath(Path.Combine(prj_path, @"station.txt"));
        StaInfo[] staInfos;
        public Form3()
        {
            InitializeComponent();

        }
        public Excel excel;




        private void Form3_Load(object sender, EventArgs e)
        {
            string path = excel_path;
            excel = new Excel(excel_path, 1);

            string[] textValue = System.IO.File.ReadAllLines(station_txt);
            staInfos = new StaInfo[textValue.Length];

            int i = 0;
            foreach (string item in textValue)
            {
                staInfos[i] = new StaInfo(item, i + 1);
                i++;
            }

            OpenFile(excel);
        }




        public void OpenFile(Excel excel)
        {


            int ttTime;
            ttTime = Convert.ToInt32(label2.Text.ToString());// 시간으로 열 잡기



            /*
            int staName = 0;

            if (label1.Text == "4.19민주묘지역")
            {
                staName = 1;
            }
            if (label1.Text == "가락시장역")
            {
                staName = 2;
            }
            if (label1.Text == "가산디지털단지역")
            {
                staName = 3;
            }
            if (label1.Text == "가양역")
            {
                staName = 4;
            }
            if (label1.Text == "가오리역")
            {
                staName = 5;
            }
            if (label1.Text == "가좌역")
            {
                staName = 6;
            }
            if (label1.Text == "가천대역")
            {
                staName = 7;
            }
            if (label1.Text == "가평역")
            {
                staName = 8;
            }
            if (label1.Text == "간석역")
            {
                staName = 9;
            }
            if (label1.Text == "갈매역")
            {
                staName = 10;
            }
            if (label1.Text == "강남역")
            {
                staName = 11;
            }
            if (label1.Text == "강남구청역")
            {
                staName = 12;
            }
            if (label1.Text == "강동역")
            {
                staName = 13;
            }
            if (label1.Text == "강동구청역")
            {
                staName = 14;
            }
            if (label1.Text == "강매역")
            {
                staName = 15;
            }
            if (label1.Text == "강변역")
            {
                staName = 16;
            }
            if (label1.Text == "강촌역")
            {
                staName = 17;
            }
            if (label1.Text == "개롱역")
            {
                staName = 18;
            }
            if (label1.Text == "개봉역")
            {
                staName = 19;
            }
            if (label1.Text == "개포동역")
            {
                staName = 20;
            }
            if (label1.Text == "개화역")
            {
                staName = 21;
            }
            if (label1.Text == "개화산역")
            {
                staName = 22;
            }
            if (label1.Text == "거여역")
            {
                staName = 23;
            }
            if (label1.Text == "건대입구역")
            {
                staName = 24;
            }
            if (label1.Text == "검암역")
            {
                staName = 25;
            }
            if (label1.Text == "경기광주역")
            {
                staName = 26;
            }
            if (label1.Text == "경마공원역")
            {
                staName = 27;
            }
            if (label1.Text == "경복궁역")
            {
                staName = 28;
            }
            if (label1.Text == "경찰병원역")
            {
                staName = 29;
            }
            if (label1.Text == "계양역")
            {
                staName = 30;
            }
            if (label1.Text == "고덕역")
            {
                staName = 31;
            }
            if (label1.Text == "고려대역")
            {
                staName = 32;
            }
            if (label1.Text == "고색역")
            {
                staName = 33;
            }
            if (label1.Text == "고속터미널역")
            {
                staName = 34;
            }
            if (label1.Text == "고잔역")
            {
                staName = 35;
            }
            if (label1.Text == "곡산역")
            {
                staName = 36;
            }
            if (label1.Text == "곤지암역")
            {
                staName = 37;
            }
            if (label1.Text == "공덕역")
            {
                staName = 38;
            }
            if (label1.Text == "공릉역")
            {
                staName = 39;
            }
            if (label1.Text == "공항시장역")
            {
                staName = 40;
            }
            if (label1.Text == "공항화물청사역")
            {
                staName = 41;
            }
            if (label1.Text == "과천역")
            {
                staName = 42;
            }
            if (label1.Text == "관악역")
            {
                staName = 43;
            }
            if (label1.Text == "광나루역")
            {
                staName = 44;
            }
            if (label1.Text == "광명역")
            {
                staName = 45;
            }
            if (label1.Text == "광명사거리역")
            {
                staName = 46;
            }
            if (label1.Text == "광운대역")
            {
                staName = 47;
            }
            if (label1.Text == "광화문역")
            {
                staName = 48;
            }
            if (label1.Text == "광흥창역")
            {
                staName = 49;
            }
            if (label1.Text == "교대역")
            {
                staName = 50;
            }
            if (label1.Text == "구로역")
            {
                staName = 51;
            }
            if (label1.Text == "구로디지털단지역")
            {
                staName = 52;
            }
            if (label1.Text == "구룡역")
            {
                staName = 53;
            }
            if (label1.Text == "구리역")
            {
                staName = 54;
            }
            if (label1.Text == "구반포역")
            {
                staName = 55;
            }
            if (label1.Text == "구산역")
            {
                staName = 56;
            }
            if (label1.Text == "구성역")
            {
                staName = 57;
            }
            if (label1.Text == "구의역")
            {
                staName = 58;
            }
            if (label1.Text == "구일역")
            {
                staName = 59;
            }
            if (label1.Text == "구파발역")
            {
                staName = 60;
            }
            if (label1.Text == "국수역")
            {
                staName = 61;
            }
            if (label1.Text == "국회의사당역")
            {
                staName = 62;
            }
            if (label1.Text == "군자역")
            {
                staName = 63;
            }
            if (label1.Text == "군포역")
            {
                staName = 64;
            }
            if (label1.Text == "굴봉산역")
            {
                staName = 65;
            }
            if (label1.Text == "굴포천역")
            {
                staName = 66;
            }
            if (label1.Text == "굽은다리역")
            {
                staName = 67;
            }
            if (label1.Text == "금곡역")
            {
                staName = 68;
            }
            if (label1.Text == "금릉역")
            {
                staName = 69;
            }
            if (label1.Text == "금정역")
            {
                staName = 70;
            }
            if (label1.Text == "금천구청역")
            {
                staName = 71;
            }
            if (label1.Text == "금촌역")
            {
                staName = 72;
            }
            if (label1.Text == "금호역")
            {
                staName = 73;
            }
            if (label1.Text == "기흥역")
            {
                staName = 74;
            }
            if (label1.Text == "길동역")
            {
                staName = 75;
            }
            if (label1.Text == "길음역")
            {
                staName = 76;
            }
            if (label1.Text == "김유정역")
            {
                staName = 77;
            }
            if (label1.Text == "김포공항역")
            {
                staName = 78;
            }
            if (label1.Text == "까치산역")
            {
                staName = 79;
            }
            if (label1.Text == "까치울역")
            {
                staName = 80;
            }
            if (label1.Text == "낙성대역")
            {
                staName = 81;
            }
            if (label1.Text == "남구로역")
            {
                staName = 82;
            }
            if (label1.Text == "남동인더스파크역")
            {
                staName = 83;
            }
            if (label1.Text == "남부터미널역")
            {
                staName = 84;
            }
            if (label1.Text == "남성역")
            {
                staName = 85;
            }
            if (label1.Text == "남영역")
            {
                staName = 86;
            }
            if (label1.Text == "남춘천역")
            {
                staName = 87;
            }
            if (label1.Text == "남태령역")
            {
                staName = 88;
            }
            if (label1.Text == "남한산성입구역")
            {
                staName = 89;
            }
            if (label1.Text == "내방역")
            {
                staName = 90;
            }
            if (label1.Text == "노들역")
            {
                staName = 91;
            }
            if (label1.Text == "노량진역")
            {
                staName = 92;
            }
            if (label1.Text == "노원역")
            {
                staName = 93;
            }
            if (label1.Text == "녹번역")
            {
                staName = 94;
            }
            if (label1.Text == "녹사평역")
            {
                staName = 95;
            }
            if (label1.Text == "녹양역")
            {
                staName = 96;
            }
            if (label1.Text == "녹천역")
            {
                staName = 97;
            }
            if (label1.Text == "논현역")
            {
                staName = 98;
            }
            if (label1.Text == "능곡역")
            {
                staName = 99;
            }
            if (label1.Text == "단대오거리역")
            {
                staName = 100;
            }

            //101
            if (label1.Text == "달월역")
            {
                staName = 101;
            }
            if (label1.Text == "답십리역")
            {
                staName = 102;
            }
            if (label1.Text == "당고개역")
            {
                staName = 103;
            }
            if (label1.Text == "당산역")
            {
                staName = 104;
            }
            if (label1.Text == "당정역")
            {
                staName = 105;
            }
            if (label1.Text == "대곡역")
            {
                staName = 106;
            }
            if (label1.Text == "대공원역")
            {
                staName = 107;
            }
            if (label1.Text == "대림역")
            {
                staName = 108;
            }
            if (label1.Text == "대모산입구역")
            {
                staName = 109;
            }
            if (label1.Text == "대방역")
            {
                staName = 110;
            }
            if (label1.Text == "대성리역")
            {
                staName = 111;
            }
            if (label1.Text == "대야미역")
            {
                staName = 112;
            }
            if (label1.Text == "대청역")
            {
                staName = 113;
            }
            if (label1.Text == "대치역")
            {
                staName = 114;
            }
            if (label1.Text == "대화역")
            {
                staName = 115;
            }
            if (label1.Text == "대흥역")
            {
                staName = 116;
            }
            if (label1.Text == "덕계역")
            {
                staName = 117;
            }
            if (label1.Text == "덕소역")
            {
                staName = 118;
            }
            if (label1.Text == "덕정역")
            {
                staName = 119;
            }
            if (label1.Text == "도곡역")
            {
                staName = 120;
            }
            if (label1.Text == "도농역")
            {
                staName = 121;
            }
            if (label1.Text == "도림천역")
            {
                staName = 122;
            }
            if (label1.Text == "도봉역")
            {
                staName = 123;
            }
            if (label1.Text == "도봉산역")
            {
                staName = 124;
            }
            if (label1.Text == "도심역")
            {
                staName = 125;
            }
            if (label1.Text == "도원역")
            {
                staName = 126;
            }
            if (label1.Text == "도화역")
            {
                staName = 127;
            }
            if (label1.Text == "독립문역")
            {
                staName = 128;
            }
            if (label1.Text == "독바위역")
            {
                staName = 129;
            }
            if (label1.Text == "독산역")
            {
                staName = 130;
            }
            if (label1.Text == "돌곶이역")
            {
                staName = 131;
            }
            if (label1.Text == "동대문역")
            {
                staName = 132;
            }
            if (label1.Text == "동대문역사문화공원역")
            {
                staName = 133;
            }
            if (label1.Text == "동대입구역")
            {
                staName = 134;
            }
            if (label1.Text == "동두천역")
            {
                staName = 135;
            }
            if (label1.Text == "동두천중앙역")
            {
                staName = 136;
            }
            if (label1.Text == "동묘앞역")
            {
                staName = 137;
            }
            if (label1.Text == "동암역")
            {
                staName = 138;
            }
            if (label1.Text == "동인천역")
            {
                staName = 139;
            }
            if (label1.Text == "동작역")
            {
                staName = 140;
            }
            if (label1.Text == "두정역")
            {
                staName = 141;
            }
            if (label1.Text == "둔촌동역")
            {
                staName = 142;
            }
            if (label1.Text == "둔촌오륜역")
            {
                staName = 143;
            }
            if (label1.Text == "등촌역")
            {
                staName = 144;
            }
            if (label1.Text == "디지털미디어시티역")
            {
                staName = 145;
            }
            if (label1.Text == "뚝섬역")
            {
                staName = 146;
            }
            if (label1.Text == "뚝섬유원지역")
            {
                staName = 147;
            }
            if (label1.Text == "마곡역")
            {
                staName = 148;
            }
            if (label1.Text == "마곡나루역")
            {
                staName = 149;
            }
            if (label1.Text == "마두역")
            {
                staName = 150;
            }
            if (label1.Text == "마들역")
            {
                staName = 151;
            }
            if (label1.Text == "마석역")
            {
                staName = 152;
            }
            if (label1.Text == "마장역")
            {
                staName = 153;
            }
            if (label1.Text == "마천역")
            {
                staName = 154;
            }
            if (label1.Text == "마포역")
            {
                staName = 155;
            }
            if (label1.Text == "마포구청역")
            {
                staName = 156;
            }
            if (label1.Text == "망우역")
            {
                staName = 157;
            }
            if (label1.Text == "망원역")
            {
                staName = 158;
            }
            if (label1.Text == "망월사역")
            {
                staName = 159;
            }
            if (label1.Text == "망포역")
            {
                staName = 160;
            }
            if (label1.Text == "매교역")
            {
                staName = 161;
            }
            if (label1.Text == "매봉역")
            {
                staName = 162;
            }
            if (label1.Text == "매탄권선역")
            {
                staName = 163;
            }
            if (label1.Text == "먹골역")
            {
                staName = 164;
            }
            if (label1.Text == "면목역")
            {
                staName = 165;
            }
            if (label1.Text == "명동역")
            {
                staName = 166;
            }
            if (label1.Text == "명일역")
            {
                staName = 167;
            }
            if (label1.Text == "명학역")
            {
                staName = 168;
            }
            if (label1.Text == "모란역")
            {
                staName = 169;
            }
            if (label1.Text == "목동역")
            {
                staName = 170;
            }
            if (label1.Text == "몽촌토성역")
            {
                staName = 171;
            }
            if (label1.Text == "무악재역")
            {
                staName = 172;
            }
            if (label1.Text == "문래역")
            {
                staName = 173;
            }
            if (label1.Text == "문산역")
            {
                staName = 174;
            }
            if (label1.Text == "문정역")
            {
                staName = 175;
            }
            if (label1.Text == "미금역")
            {
                staName = 176;
            }
            if (label1.Text == "미사역")
            {
                staName = 177;
            }
            if (label1.Text == "미아역")
            {
                staName = 178;
            }
            if (label1.Text == "미아사거리역")
            {
                staName = 179;
            }
            if (label1.Text == "반월역")
            {
                staName = 180;
            }
            if (label1.Text == "반포역")
            {
                staName = 181;
            }
            if (label1.Text == "발산역")
            {
                staName = 182;
            }
            if (label1.Text == "방배역")
            {
                staName = 183;
            }
            if (label1.Text == "방이역")
            {
                staName = 184;
            }
            if (label1.Text == "방학역")
            {
                staName = 185;
            }
            if (label1.Text == "방화역")
            {
                staName = 186;
            }
            if (label1.Text == "배방역")
            {
                staName = 187;
            }
            if (label1.Text == "백마역")
            {
                staName = 188;
            }
            if (label1.Text == "백석역")
            {
                staName = 189;
            }
            if (label1.Text == "백양리역")
            {
                staName = 190;
            }
            if (label1.Text == "백운역")
            {
                staName = 191;
            }
            if (label1.Text == "버티고개역")
            {
                staName = 192;
            }
            if (label1.Text == "범계역")
            {
                staName = 193;
            }
            if (label1.Text == "별내역")
            {
                staName = 194;
            }
            if (label1.Text == "병점역")
            {
                staName = 195;
            }
            if (label1.Text == "보라매역")
            {
                staName = 196;
            }
            if (label1.Text == "보문역")
            {
                staName = 197;
            }
            if (label1.Text == "보산역")
            {
                staName = 198;
            }
            if (label1.Text == "보정역")
            {
                staName = 199;
            }
            if (label1.Text == "복정역")
            {
                staName = 200;
            }
            //200
            if (label1.Text == "봉명역")
            {
                staName = 201;
            }
            if (label1.Text == "봉은사역")
            {
                staName = 202;
            }
            if (label1.Text == "봉천역")
            {
                staName = 203;
            }
            if (label1.Text == "봉화산역")
            {
                staName = 204;
            }
            if (label1.Text == "부개역")
            {
                staName = 205;
            }
            if (label1.Text == "부발역")
            {
                staName = 206;
            }
            if (label1.Text == "부천역")
            {
                staName = 207;
            }
            if (label1.Text == "부천시청역")
            {
                staName = 208;
            }
            if (label1.Text == "부천종합운동장역")
            {
                staName = 209;
            }
            if (label1.Text == "부평역")
            {
                staName = 210;
            }
            if (label1.Text == "부평구청역")
            {
                staName = 211;
            }
            if (label1.Text == "북한산보국문역")
            {
                staName = 212;
            }
            if (label1.Text == "북한산우이역")
            {
                staName = 213;
            }
            if (label1.Text == "불광역")
            {
                staName = 214;
            }
            if (label1.Text == "사가정역")
            {
                staName = 215;
            }
            if (label1.Text == "사당역")
            {
                staName = 216;
            }
            if (label1.Text == "사릉역")
            {
                staName = 217;
            }
            if (label1.Text == "사리역")
            {
                staName = 218;
            }
            if (label1.Text == "사평역")
            {
                staName = 219;
            }
            if (label1.Text == "산본역")
            {
                staName = 220;
            }
            if (label1.Text == "산성역")
            {
                staName = 221;
            }
            if (label1.Text == "삼각지역")
            {
                staName = 222;
            }
            if (label1.Text == "삼동역")
            {
                staName = 223;
            }
            if (label1.Text == "삼산체육관역")
            {
                staName = 224;
            }
            if (label1.Text == "삼성역")
            {
                staName = 225;
            }
            if (label1.Text == "삼성중앙역")
            {
                staName = 226;
            }
            if (label1.Text == "삼송역")
            {
                staName = 227;
            }
            if (label1.Text == "삼양역")
            {
                staName = 228;
            }
            if (label1.Text == "삼양사거리역")
            {
                staName = 229;
            }
            if (label1.Text == "삼전역")
            {
                staName = 230;
            }
            if (label1.Text == "상갈역")
            {
                staName = 231;
            }
            if (label1.Text == "상계역")
            {
                staName = 232;
            }
            if (label1.Text == "상도역")
            {
                staName = 233;
            }
            if (label1.Text == "상동역")
            {
                staName = 234;
            }
            if (label1.Text == "상록수역")
            {
                staName = 235;
            }
            if (label1.Text == "상봉역")
            {
                staName = 236;
            }
            if (label1.Text == "상수역")
            {
                staName = 237;
            }
            if (label1.Text == "상왕십리역")
            {
                staName = 238;
            }
            if (label1.Text == "상월곡역")
            {
                staName = 239;
            }
            if (label1.Text == "상일동역")
            {
                staName = 240;
            }
            if (label1.Text == "상천역")
            {
                staName = 241;
            }
            if (label1.Text == "새절역")
            {
                staName = 242;
            }
            if (label1.Text == "샛강역")
            {
                staName = 243;
            }
            if (label1.Text == "서강대역")
            {
                staName = 244;
            }
            if (label1.Text == "서대문역")
            {
                staName = 245;
            }
            if (label1.Text == "서동탄역")
            {
                staName = 246;
            }
            if (label1.Text == "서빙고역")
            {
                staName = 247;
            }
            if (label1.Text == "서울역")
            {
                staName = 248;
            }
            if (label1.Text == "서울숲역")
            {
                staName = 249;
            }
            if (label1.Text == "서정리역")
            {
                staName = 250;
            }
            if (label1.Text == "서초역")
            {
                staName = 251;
            }
            if (label1.Text == "서현역")
            {
                staName = 252;
            }
            if (label1.Text == "석계역")
            {
                staName = 253;
            }
            if (label1.Text == "석수역")
            {
                staName = 254;
            }
            if (label1.Text == "석촌역")
            {
                staName = 255;
            }
            if (label1.Text == "석촌고분역")
            {
                staName = 256;
            }
            if (label1.Text == "선릉역")
            {
                staName = 257;
            }
            if (label1.Text == "선바위역")
            {
                staName = 258;
            }
            if (label1.Text == "선유도역")
            {
                staName = 259;
            }
            if (label1.Text == "선정릉역")
            {
                staName = 260;
            }
            if (label1.Text == "성균관대역")
            {
                staName = 261;
            }
            if (label1.Text == "성수역")
            {
                staName = 262;
            }
            if (label1.Text == "성신여대입구역")
            {
                staName = 263;
            }
            if (label1.Text == "성환역")
            {
                staName = 264;
            }
            if (label1.Text == "세류역")
            {
                staName = 265;
            }
            if (label1.Text == "세마역")
            {
                staName = 266;
            }
            if (label1.Text == "세종대왕릉역")
            {
                staName = 267;
            }
            if (label1.Text == "소래포구역")
            {
                staName = 268;
            }
            if (label1.Text == "소사역")
            {
                staName = 269;
            }
            if (label1.Text == "소요산역")
            {
                staName = 270;
            }
            if (label1.Text == "솔밭공원역")
            {
                staName = 271;
            }
            if (label1.Text == "솔샘역")
            {
                staName = 272;
            }
            if (label1.Text == "송내역")
            {
                staName = 273;
            }
            if (label1.Text == "송도역")
            {
                staName = 274;
            }
            if (label1.Text == "송정역")
            {
                staName = 275;
            }
            if (label1.Text == "송탄역")
            {
                staName = 276;
            }
            if (label1.Text == "송파역")
            {
                staName = 277;
            }
            if (label1.Text == "송파나루역")
            {
                staName = 278;
            }
            if (label1.Text == "수내역")
            {
                staName = 279;
            }
            if (label1.Text == "수락산역")
            {
                staName = 280;
            }
            if (label1.Text == "수리산역")
            {
                staName = 281;
            }
            if (label1.Text == "수색역")
            {
                staName = 282;
            }
            if (label1.Text == "수서역")
            {
                staName = 283;
            }
            if (label1.Text == "수원역")
            {
                staName = 284;
            }
            if (label1.Text == "수원시청역")
            {
                staName = 285;
            }
            if (label1.Text == "수유역")
            {
                staName = 286;
            }
            if (label1.Text == "수진역")
            {
                staName = 287;
            }
            if (label1.Text == "숙대입구역")
            {
                staName = 288;
            }
            if (label1.Text == "숭실대입구역")
            {
                staName = 289;
            }
            if (label1.Text == "숭의역")
            {
                staName = 290;
            }
            if (label1.Text == "시청역")
            {
                staName = 291;
            }
            if (label1.Text == "신갈역")
            {
                staName = 292;
            }
            if (label1.Text == "신금호역")
            {
                staName = 293;
            }
            if (label1.Text == "신길역")
            {
                staName = 294;
            }
            if (label1.Text == "신길온천역")
            {
                staName = 295;
            }
            if (label1.Text == "신내역")
            {
                staName = 296;
            }
            if (label1.Text == "신논현역")
            {
                staName = 297;
            }
            if (label1.Text == "신답역")
            {
                staName = 298;
            }
            if (label1.Text == "신당역")
            {
                staName = 299;
            }
            if (label1.Text == "신대방역")
            {
                staName = 300;
            }
            //300
            if (label1.Text == "신대방삼거리역")
            {
                staName = 301;
            }
            if (label1.Text == "신도림역")
            {
                staName = 302;
            }
            if (label1.Text == "신둔도예촌역")
            {
                staName = 303;
            }
            if (label1.Text == "신림역")
            {
                staName = 304;
            }
            if (label1.Text == "신목동역")
            {
                staName = 305;
            }
            if (label1.Text == "신반포역")
            {
                staName = 306;
            }
            if (label1.Text == "신방화역")
            {
                staName = 307;
            }
            if (label1.Text == "신사역")
            {
                staName = 308;
            }
            if (label1.Text == "신설동역")
            {
                staName = 309;
            }
            if (label1.Text == "신용산역")
            {
                staName = 310;
            }
            if (label1.Text == "신원역")
            {
                staName = 311;
            }
            if (label1.Text == "신이문역")
            {
                staName = 312;
            }
            if (label1.Text == "신정역")
            {
                staName = 313;
            }
            if (label1.Text == "신정네거리역")
            {
                staName = 314;
            }
            if (label1.Text == "신중동역")
            {
                staName = 315;
            }
            if (label1.Text == "신창역")
            {
                staName = 316;
            }
            if (label1.Text == "신촌역")
            {
                staName = 317;
            }
            if (label1.Text == "신포역")
            {
                staName = 318;
            }
            if (label1.Text == "신풍역")
            {
                staName = 319;
            }
            if (label1.Text == "신흥역")
            {
                staName = 320;
            }
            if (label1.Text == "쌍문역")
            {
                staName = 321;
            }
            if (label1.Text == "쌍용역")
            {
                staName = 322;
            }
            if (label1.Text == "아산역")
            {
                staName = 323;
            }
            if (label1.Text == "아신역")
            {
                staName = 324;
            }
            if (label1.Text == "아차산역")
            {
                staName = 325;
            }
            if (label1.Text == "아현역")
            {
                staName = 326;
            }
            if (label1.Text == "안국역")
            {
                staName = 327;
            }
            if (label1.Text == "안산역")
            {
                staName = 328;
            }
            if (label1.Text == "안암역")
            {
                staName = 329;
            }
            if (label1.Text == "안양역")
            {
                staName = 330;
            }
            if (label1.Text == "암사역")
            {
                staName = 331;
            }
            if (label1.Text == "압구정역")
            {
                staName = 332;
            }
            if (label1.Text == "압구정로데오역")
            {
                staName = 333;
            }
            if (label1.Text == "애오개역")
            {
                staName = 334;
            }
            if (label1.Text == "야당역")
            {
                staName = 335;
            }
            if (label1.Text == "야목역")
            {
                staName = 336;
            }
            if (label1.Text == "야탑역")
            {
                staName = 337;
            }
            if (label1.Text == "약수역")
            {
                staName = 338;
            }
            if (label1.Text == "양수역")
            {
                staName = 339;
            }
            if (label1.Text == "양원역")
            {
                staName = 340;
            }
            if (label1.Text == "양재역")
            {
                staName = 341;
            }
            if (label1.Text == "양정역")
            {
                staName = 342;
            }
            if (label1.Text == "양주역")
            {
                staName = 343;
            }
            if (label1.Text == "양천구청역")
            {
                staName = 344;
            }
            if (label1.Text == "양천향교역")
            {
                staName = 345;
            }
            if (label1.Text == "양평역")
            {
                staName = 346;
            }
            if (label1.Text == "어린이대공원역")
            {
                staName = 347;
            }
            if (label1.Text == "어천역")
            {
                staName = 348;
            }
            if (label1.Text == "언주역")
            {
                staName = 349;
            }
            if (label1.Text == "여의나루역")
            {
                staName = 350;
            }
            if (label1.Text == "여의도역")
            {
                staName = 351;
            }
            if (label1.Text == "여주역")
            {
                staName = 352;
            }
            if (label1.Text == "역곡역")
            {
                staName = 353;
            }
            if (label1.Text == "역삼역")
            {
                staName = 354;
            }
            if (label1.Text == "역촌역")
            {
                staName = 355;
            }
            if (label1.Text == "연수역")
            {
                staName = 356;
            }
            if (label1.Text == "연신내역")
            {
                staName = 357;
            }
            if (label1.Text == "염창역")
            {
                staName = 358;
            }
            if (label1.Text == "영등포역")
            {
                staName = 359;
            }
            if (label1.Text == "영등포시장역")
            {
                staName = 360;
            }
            if (label1.Text == "영종역")
            {
                staName = 361;
            }
            if (label1.Text == "영통역")
            {
                staName = 362;
            }
            if (label1.Text == "오금역")
            {
                staName = 363;
            }
            if (label1.Text == "오류동역")
            {
                staName = 364;
            }
            if (label1.Text == "오리역")
            {
                staName = 365;
            }
            if (label1.Text == "오목교역")
            {
                staName = 366;
            }
            if (label1.Text == "오목천역")
            {
                staName = 367;
            }
            if (label1.Text == "오빈역")
            {
                staName = 368;
            }
            if (label1.Text == "오산역")
            {
                staName = 369;
            }
            if (label1.Text == "오산대역")
            {
                staName = 370;
            }
            if (label1.Text == "오이도역")
            {
                staName = 371;
            }
            if (label1.Text == "옥수역")
            {
                staName = 372;
            }
            if (label1.Text == "온수역")
            {
                staName = 373;
            }
            if (label1.Text == "온양온천역")
            {
                staName = 374;
            }
            if (label1.Text == "올림픽공원역")
            {
                staName = 375;
            }
            if (label1.Text == "왕십리역")
            {
                staName = 376;
            }
            if (label1.Text == "외대앞역")
            {
                staName = 377;
            }
            if (label1.Text == "용답역")
            {
                staName = 378;
            }
            if (label1.Text == "용두역")
            {
                staName = 379;
            }
            if (label1.Text == "용마산역")
            {
                staName = 380;
            }
            if (label1.Text == "용문역")
            {
                staName = 381;
            }
            if (label1.Text == "용산역")
            {
                staName = 382;
            }
            if (label1.Text == "우장산역")
            {
                staName = 383;
            }
            if (label1.Text == "운길산역")
            {
                staName = 384;
            }
            if (label1.Text == "운서역")
            {
                staName = 385;
            }
            if (label1.Text == "운정역")
            {
                staName = 386;
            }
            if (label1.Text == "원당역")
            {
                staName = 387;
            }
            if (label1.Text == "원덕역")
            {
                staName = 388;
            }
            if (label1.Text == "원인재역")
            {
                staName = 389;
            }
            if (label1.Text == "원흥역")
            {
                staName = 390;
            }
            if (label1.Text == "월계역")
            {
                staName = 391;
            }
            if (label1.Text == "월곡역")
            {
                staName = 392;
            }
            if (label1.Text == "월곶역")
            {
                staName = 393;
            }
            if (label1.Text == "월드컵경기장역")
            {
                staName = 394;
            }
            if (label1.Text == "월롱역")
            {
                staName = 395;
            }
            if (label1.Text == "을지로3가역")
            {
                staName = 396;
            }
            if (label1.Text == "을지로4가역")
            {
                staName = 397;
            }
            if (label1.Text == "을지로입구역")
            {
                staName = 398;
            }
            if (label1.Text == "응봉역")
            {
                staName = 399;
            }
            if (label1.Text == "응암역")
            {
                staName = 400;
            }
            //401

            if (label1.Text == "의왕역")
            {
                staName = 401;
            }
            if (label1.Text == "의정부역")
            {
                staName = 402;
            }
            if (label1.Text == "이대역")
            {
                staName = 403;
            }
            if (label1.Text == "이매역")
            {
                staName = 404;
            }
            if (label1.Text == "이수역")
            {
                staName = 405;
            }
            if (label1.Text == "이천역")
            {
                staName = 406;
            }
            if (label1.Text == "이촌역")
            {
                staName = 407;
            }
            if (label1.Text == "이태원역")
            {
                staName = 408;
            }
            if (label1.Text == "인덕원역")
            {
                staName = 409;
            }
            if (label1.Text == "인천역")

            {
                staName = 410;
            }
            if (label1.Text == "인천공항2터미널역")
            {
                staName = 411;
            }
            if (label1.Text == "인천논현역")
            {
                staName = 412;
            }
            if (label1.Text == "인하대역")
            {
                staName = 413;
            }
            if (label1.Text == "일산역")
            {
                staName = 414;
            }
            if (label1.Text == "일원역")
            {
                staName = 415;
            }
            if (label1.Text == "임진강역")
            {
                staName = 416;
            }
            if (label1.Text == "잠실역")
            {
                staName = 417;
            }
            if (label1.Text == "잠실나루역")
            {
                staName = 418;
            }
            if (label1.Text == "잠실새내역")
            {
                staName = 419;
            }
            if (label1.Text == "잠원역")
            {
                staName = 420;
            }
            if (label1.Text == "장승배기역")
            {
                staName = 421;
            }
            if (label1.Text == "장암역")
            {
                staName = 422;
            }
            if (label1.Text == "장지역")
            {
                staName = 423;
            }
            if (label1.Text == "장한평역")
            {
                staName = 424;
            }
            if (label1.Text == "정릉역")
            {
                staName = 425;
            }
            if (label1.Text == "정발산역")
            {
                staName = 426;
            }
            if (label1.Text == "정부과천청사역")
            {
                staName = 427;
            }
            if (label1.Text == "정왕역")
            {
                staName = 428;
            }
            if (label1.Text == "정자역")
            {
                staName = 429;
            }
            if (label1.Text == "제기동역")
            {
                staName = 430;
            }
            if (label1.Text == "제물포역")
            {
                staName = 431;
            }
            if (label1.Text == "종각역")
            {
                staName = 432;
            }
            if (label1.Text == "종로3가역")
            {
                staName = 433;
            }
            if (label1.Text == "종로5가역")
            {
                staName = 434;
            }
            if (label1.Text == "종합운동장역")
            {
                staName = 435;
            }
            if (label1.Text == "주안역")
            {
                staName = 436;
            }
            if (label1.Text == "주엽역")
            {
                staName = 437;
            }
            if (label1.Text == "죽전역")
            {
                staName = 438;
            }
            if (label1.Text == "중계역")
            {
                staName = 439;
            }
            if (label1.Text == "중곡역")
            {
                staName = 440;
            }
            if (label1.Text == "중동역")
            {
                staName = 441;
            }
            if (label1.Text == "중랑역")
            {
                staName = 442;
            }
            if (label1.Text == "중앙역")
            {
                staName = 443;
            }
            if (label1.Text == "중앙보훈병원역")
            {
                staName = 444;
            }
            if (label1.Text == "중화역")
            {
                staName = 445;
            }
            if (label1.Text == "증미역")
            {
                staName = 446;
            }
            if (label1.Text == "증산역")
            {
                staName = 447;
            }
            if (label1.Text == "지제역")
            {
                staName = 448;
            }
            if (label1.Text == "지축역")
            {
                staName = 449;
            }
            if (label1.Text == "지평역")
            {
                staName = 450;
            }
            if (label1.Text == "지행역")
            {
                staName = 451;
            }
            if (label1.Text == "직산역")
            {
                staName = 452;
            }
            if (label1.Text == "진위역")
            {
                staName = 453;
            }
            if (label1.Text == "창동역")
            {
                staName = 454;
            }
            if (label1.Text == "창신역")
            {
                staName = 455;
            }
            if (label1.Text == "천마산역")
            {
                staName = 456;
            }
            if (label1.Text == "천안역")
            {
                staName = 457;
            }
            if (label1.Text == "천왕역")
            {
                staName = 458;
            }
            if (label1.Text == "천호역")
            {
                staName = 459;
            }
            if (label1.Text == "철산역")
            {
                staName = 460;
            }
            if (label1.Text == "청구역")
            {
                staName = 461;
            }
            if (label1.Text == "청담역")
            {
                staName = 462;
            }
            if (label1.Text == "청라국제도시역")
            {
                staName = 463;
            }
            if (label1.Text == "청량리역")
            {
                staName = 464;
            }
            if (label1.Text == "청명역")
            {
                staName = 465;
            }
            if (label1.Text == "청평역")
            {
                staName = 466;
            }
            if (label1.Text == "초월역")
            {
                staName = 467;
            }
            if (label1.Text == "초지역")
            {
                staName = 468;
            }
            if (label1.Text == "총신대입구역")
            {
                staName = 469;
            }
            if (label1.Text == "춘의역")
            {
                staName = 470;
            }
            if (label1.Text == "춘천역")
            {
                staName = 471;
            }
            if (label1.Text == "충무로역")
            {
                staName = 472;
            }
            if (label1.Text == "충정로역")
            {
                staName = 473;
            }
            if (label1.Text == "탄현역")
            {
                staName = 474;
            }
            if (label1.Text == "태릉입구역")
            {
                staName = 475;
            }
            if (label1.Text == "태평역")
            {
                staName = 476;
            }
            if (label1.Text == "퇴계원역")
            {
                staName = 477;
            }
            if (label1.Text == "파주역")
            {
                staName = 478;
            }
            if (label1.Text == "판교역")
            {
                staName = 479;
            }
            if (label1.Text == "팔당역")
            {
                staName = 480;
            }
            if (label1.Text == "평내호평역")
            {
                staName = 481;
            }
            if (label1.Text == "평촌역")
            {
                staName = 482;
            }
            if (label1.Text == "평택역")
            {
                staName = 483;
            }
            if (label1.Text == "풍산역")
            {
                staName = 484;
            }
            if (label1.Text == "하계역")
            {
                staName = 485;
            }
            if (label1.Text == "하남풍산역")
            {
                staName = 486;
            }
            if (label1.Text == "학동역")
            {
                staName = 487;
            }
            if (label1.Text == "학여울역")
            {
                staName = 488;
            }
            if (label1.Text == "한강진역")
            {
                staName = 489;
            }
            if (label1.Text == "한남역")
            {
                staName = 490;
            }
            if (label1.Text == "한대앞역")
            {
                staName = 491;
            }
            if (label1.Text == "한성대입구역")
            {
                staName = 492;
            }
            if (label1.Text == "한성백제역")
            {
                staName = 493;
            }
            if (label1.Text == "한양대역")
            {
                staName = 494;
            }
            if (label1.Text == "한티역")
            {
                staName = 495;
            }
            if (label1.Text == "합정역")
            {
                staName = 496;
            }
            if (label1.Text == "행당역")
            {
                staName = 497;
            }
            if (label1.Text == "행신역")
            {
                staName = 498;
            }
            if (label1.Text == "혜화역")
            {
                staName = 499;
            }
            if (label1.Text == "호구포역")
            {
                staName = 500;
            }
            //500

            if (label1.Text == "홍제역")
            {
                staName = 501;
            }
            if (label1.Text == "화계역")
            {
                staName = 502;
            }
            if (label1.Text == "화곡역")
            {
                staName = 503;
            }
            if (label1.Text == "화랑대역")
            {
                staName = 504;
            }
            if (label1.Text == "화서역")
            {
                staName = 505;
            }
            if (label1.Text == "화전역")
            {
                staName = 506;
            }
            if (label1.Text == "화정역")
            {
                staName = 507;
            }
            if (label1.Text == "회기역")
            {
                staName = 508;
            }
            if (label1.Text == "회룡역")
            {
                staName = 509;
            }
            if (label1.Text == "회현역")
            {
                staName = 510;
            }
            if (label1.Text == "효창공원앞역")
            {
                staName = 511;
            }
            if (label1.Text == "흑석역")
            {
                staName = 512;
            }
            if (label1.Text == "초지역")
            {
                staName = 513;
            }
            if (label1.Text == "총신대입구역")
            {
                staName = 514;
            }
            if (label1.Text == "춘의역")
            {
                staName = 515;
            }
            if (label1.Text == "춘천역")
            {
                staName = 516;
            }
            if (label1.Text == "탄현역")
            {
                staName = 517;
            }
            if (label1.Text == "태릉입구역")
            {
                staName = 518;
            }
            if (label1.Text == "태평역")
            {
                staName = 519;
            }
            if (label1.Text == "퇴계원역")
            {
                staName = 520;
            }
            if (label1.Text == "파주역")
            {
                staName = 521;
            }
            if (label1.Text == "판교역")
            {
                staName = 522;
            }
            if (label1.Text == "팔당역")
            {
                staName = 523;
            }
            if (label1.Text == "평내호평역")
            {
                staName = 524;
            }
            if (label1.Text == "평촌역")
            {
                staName = 525;
            }
            if (label1.Text == "평택역")
            {
                staName = 526;
            }
            if (label1.Text == "풍산역")
            {
                staName = 527;
            }
            if (label1.Text == "하계역")
            {
                staName = 528;
            }
            if (label1.Text == "하남풍산역")
            {
                staName = 529;
            }
            if (label1.Text == "학동역")
            {
                staName = 530;
            }
            if (label1.Text == "학여울역")
            {
                staName = 531;
            }
            if (label1.Text == "한강진역")
            {
                staName = 532;
            }
            if (label1.Text == "한남역")
            {
                staName = 533;
            }
            if (label1.Text == "한대앞역")
            {
                staName = 534;
            }
            if (label1.Text == "한성대입구역")
            {
                staName = 535;
            }
            if (label1.Text == "한성백제역")
            {
                staName = 536;
            }
            if (label1.Text == "한양대역")
            {
                staName = 537;
            }
            if (label1.Text == "한티역")
            {
                staName = 538;
            }
            if (label1.Text == "합정역")
            {
                staName = 539;
            }
            if (label1.Text == "행당역")
            {
                staName = 540;
            }
            if (label1.Text == "행신역")
            {
                staName = 541;
            }
            if (label1.Text == "혜화역")
            {
                staName = 542;
            }
            if (label1.Text == "호구포역")
            {
                staName = 543;
            }
            if (label1.Text == "홍대입구역")
            {
                staName = 544;
            }
            if (label1.Text == "홍제역")
            {
                staName = 545;
            }
            if (label1.Text == "화계역")
            {
                staName = 546;
            }
            if (label1.Text == "화곡역")
            {
                staName = 547;
            }
            if (label1.Text == "화랑대역")
            {
                staName = 548;
            }
            if (label1.Text == "화서역")
            {
                staName = 549;
            }
            if (label1.Text == "화전역")
            {
                staName = 550;
            }
            if (label1.Text == "화정역")
            {
                staName = 551;
            }
            if (label1.Text == "회기역")
            {
                staName = 552;
            }
            if (label1.Text == "회룡역")
            {
                staName = 553;
            }
            if (label1.Text == "회현역")
            {
                staName = 554;
            }
            if (label1.Text == "흑석역")
            {
                staName = 555;
            }
            */
            int i = 0;
            foreach (StaInfo item in staInfos)
            {
                if (label1.Text == item.Name)
                {
                    int Udong = Convert.ToInt32(excel.ReadCell(item.Num, ttTime));
                    //label4.Text = excel.ReadCell(item.Num, ttTime);//1분당으로 할지 시간 정하기
                    label4.Text = (Udong / 4).ToString() + "명"; // 검파노초


                    if ((Udong / 4) >= 3200)
                    {
                        label7.ForeColor = Color.Red; //한량 탑승인원 320명 초과 시 1량에 코로나 확진자가 있을시 밀집접촉자 최대 64명
                        label7.Text = "매우 위험!";
                        return;
                    }
                    if ((Udong / 4) >= 2400 && (Udong / 4) < 3200)
                    {
                        label7.ForeColor = Color.Yellow; //한량 탑승인원 320명 초과 시 밀집접촉자 최대 32명 ,최소 4명
                        label7.Text = "위험!";
                        return;
                    }
                    if ((Udong / 4) >= 1000 && (Udong / 4) < 2399)
                    {
                        label7.ForeColor = Color.Green; // 밀접접촉 4명
                        label7.Text = "보통!";
                        return;
                    }
                    if ((Udong / 4) < 1000)
                    {
                        label7.ForeColor = Color.Blue;// 1명 이하
                        label7.Text = "안전!";
                        return;
                    }
                }




            }
            /*
            int Name;
            Name = Convert.ToInt32(staName);
            int Udong =Convert.ToInt32(excel.ReadCell(Name, ttTime));
            //label4.Text = excel.ReadCell(Name, ttTime); // 앞에가 역 이름 뒤에가 시간
            int minUdong = (Udong / 60);
            label4.Text = minUdong.ToString();
            */




        }



        public Form3(string data, string Time)
        {
            InitializeComponent();
            station = data;
            time = Time;
            label1.Text = station;
            label2.Text = Time;

            label1.Font = new System.Drawing.Font("맑은고딕", 25, FontStyle.Bold);
            label2.Font = new System.Drawing.Font("맑은고딕", 9, FontStyle.Bold);
            label3.Font = new System.Drawing.Font("맑은고딕", 9, FontStyle.Bold);
            label4.Font = new System.Drawing.Font("맑은고딕", 9, FontStyle.Bold);
            label5.Font = new System.Drawing.Font("맑은고딕", 9, FontStyle.Bold);
            label6.Font = new System.Drawing.Font("맑은고딕", 9, FontStyle.Bold);
            label7.Font = new System.Drawing.Font("맑은고딕", 27, FontStyle.Bold);
        }



        private string station;

        private string time;

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            excel.Excel_Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
