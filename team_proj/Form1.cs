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

namespace team_proj
{
    public partial class Form1 : Form
    {
        static string cur_path = Directory.GetCurrentDirectory().ToString();
        static string prj_path = Path.GetFullPath(Path.Combine(cur_path, @"..\..\..\"));
        // 현재 실행 파일의 위치를 가져와서, 3개 상위 폴더(프로젝트 폴더)의 위치를 만듦
        static string seoulmap_path = Path.GetFullPath(Path.Combine(prj_path, @"seoul_map.png"));
        static string gu_txt = Path.GetFullPath(Path.Combine(prj_path, @"gu.txt"));
        static string station_txt = Path.GetFullPath(Path.Combine(prj_path, @"station.txt"));
        // 구와 역 리스트를 가져옴 (축적 조절에서 사용)

        public Form1()
        {
            InitializeComponent();
            picbox_map.Image = Image.FromFile(seoulmap_path);
            btn_find.Image = Image.FromFile(Path.GetFullPath(Path.Combine(prj_path, @"find_btn.png")));
            change_chklist_item(station_txt);
            
        }

        private void change_chklist_item(string path)
        {
            chk_listbox.Items.Clear();

            foreach (string line in File.ReadLines(path))
            {
                chk_listbox.Items.Add(line);
            }
        }

        private void scr_time_ValueChanged(object sender, EventArgs e)
        {
            lbl_nowTime.Text = scr_time.Value.ToString();
        }

        private void scr_scale_ValueChanged(object sender, EventArgs e)
        {
            
            if (scr_scale.Value == 0)
            {
                lbl_scale.Text = "서울시";
                change_chklist_item(station_txt);
                picbox_map.Image = Image.FromFile(seoulmap_path);
            } 
            else if (scr_scale.Value == 1)
            {
                lbl_scale.Text = "구";
                change_chklist_item(gu_txt);
            } 
            else if (scr_scale.Value == 2)
            {
                lbl_scale.Text = "역";
                change_chklist_item(station_txt);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            if (scr_scale.Value == 1)
                change_chklist_item(gu_txt);
            else
                change_chklist_item(station_txt);
        }

        private void chk_listbox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (scr_scale.Value == 1)
                if (e.NewValue == CheckState.Checked)
                    for (int ix = 0; ix < chk_listbox.Items.Count; ++ix)
                    {
                        if (e.Index != ix) chk_listbox.SetItemChecked(ix, false);
                    }
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            if (scr_scale.Value == 1)
            {
                string gumap_path = Path.GetFullPath(Path.Combine(prj_path, @"gu\"));
                string pic_name = chk_listbox.CheckedItems[0].ToString() + ".png";

                gumap_path = Path.GetFullPath(Path.Combine(gumap_path, pic_name));

                picbox_map.Image = Image.FromFile(gumap_path);
            }
        }

        private void btn_find_Click(object sender, EventArgs e)
        {
            if (scr_scale.Value == 0)
            {
                Find_item(textBox1.Text);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (scr_scale.Value == 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Find_item(textBox1.Text);
                }
                if(e.KeyCode == Keys.Back)
                {
                    change_chklist_item(station_txt);
                }
            }
        }
        private void Find_item(string item)
        {
            Point parentPoint = this.Location;
            int fontSize10 = 10;
            int fontSize8 = 8;
            
            int ix = Get_item(item);
            if (ix < 0) 
                return;
            chk_listbox.Items.Clear();
            chk_listbox.Items.Add(item);
            chk_listbox.SetItemChecked(0, true);

            Form2 fm = new Form2();
            fm.StartPosition = FormStartPosition.Manual;
            if (item == "가락시장역")
            { 
                fm.Location = new Point(parentPoint.X + 666 , parentPoint.Y + 403 );
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "가산디지털단지역")
            {
                fm.Location = new Point(parentPoint.X + 380, parentPoint.Y+ 420 );
                fm.label1.Text = item;
                fm.label1.Font = new Font(Font.FontFamily, fontSize10);
                fm.label1.Location = new Point(0, 45);
                fm.ShowDialog();
            }
            if (item == "강남역") 
            {
                fm.Location = new Point(parentPoint.X + 563, parentPoint.Y + 386);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "강남구청역")
            {
                fm.Location = new Point(parentPoint.X + 585, parentPoint.Y + 363);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "강동역")
            {
                fm.Location = new Point(parentPoint.X + 680, parentPoint.Y + 316);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "강동구청역")
            {
                fm.Location = new Point(parentPoint.X + 669, parentPoint.Y + 337);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "강변역")
            {
                fm.Location = new Point(parentPoint.X + 635, parentPoint.Y + 336);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "강일역")
            {
                fm.Location = new Point(parentPoint.X + 718, parentPoint.Y + 298);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "개롱역")
            {
                fm.Location = new Point(parentPoint.X + 688, parentPoint.Y + 393);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "개화산역")
            {
                fm.Location = new Point(parentPoint.X + 298, parentPoint.Y + 258);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "거여역")
            {
                fm.Location = new Point(parentPoint.X + 696, parentPoint.Y + 398);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "건대입구역")
            {
                fm.Location = new Point(parentPoint.X + 610, parentPoint.Y + 329);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "경복궁역")
            {
                fm.Location = new Point(parentPoint.X + 489, parentPoint.Y + 264);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "경찰병원역")
            {
                fm.Location = new Point(parentPoint.X + 674, parentPoint.Y + 398);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "고덕역")
            {
                fm.Location = new Point(parentPoint.X + 701, parentPoint.Y + 298);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "고려대역")
            {
                fm.Location = new Point(parentPoint.X + 564, parentPoint.Y + 251);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "고속터미널역")
            {
                fm.Location = new Point(parentPoint.X + 538, parentPoint.Y + 379);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "공덕역")
            {
                fm.Location = new Point(parentPoint.X + 460, parentPoint.Y + 322);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "광나루역")
            {
                fm.Location = new Point(parentPoint.X + 649, parentPoint.Y + 310);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "광명사거리역")
            {
                fm.Location = new Point(parentPoint.X + 349, parentPoint.Y + 423);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "광화문역")
            {
                fm.Location = new Point(parentPoint.X + 495, parentPoint.Y + 270);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "광흥창역")
            {
                fm.Location = new Point(parentPoint.X + 443, parentPoint.Y + 315);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "교대역")
            {
                fm.Location = new Point(parentPoint.X + 546, parentPoint.Y + 391);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "구로디지털단지역")
            {
                fm.Location = new Point(parentPoint.X + 398, parentPoint.Y + 414);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "구산역")
            {
                fm.Location = new Point(parentPoint.X + 432, parentPoint.Y + 216);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "구의역")
            {
                fm.Location = new Point(parentPoint.X + 626, parentPoint.Y + 331);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "구파발역")
            {
                fm.Location = new Point(parentPoint.X + 428, parentPoint.Y + 166);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "군자역")
            {
                fm.Location = new Point(parentPoint.X + 622, parentPoint.Y + 298);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "굽은다리역")
            {
                fm.Location = new Point(parentPoint.X + 689, parentPoint.Y + 308);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "금호역")
            {
                fm.Location = new Point(parentPoint.X + 541, parentPoint.Y + 313);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "길동역")
            {
                fm.Location = new Point(parentPoint.X + 690, parentPoint.Y + 313);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "길음역")
            {
                fm.Location = new Point(parentPoint.X + 567, parentPoint.Y + 213);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "김포공항역")
            {
                fm.Location = new Point(parentPoint.X + 292, parentPoint.Y + 272);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "까치산역")
            {
                fm.Location = new Point(parentPoint.X + 344, parentPoint.Y + 344);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "까치울역")
            {
                fm.Location = new Point(parentPoint.X + 296, parentPoint.Y + 374);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "낙성대역")
            {
                fm.Location = new Point(parentPoint.X + 474, parentPoint.Y + 429);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "남구로역")
            {
                fm.Location = new Point(parentPoint.X + 388, parentPoint.Y + 412);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "남부터미널역")
            {
                fm.Location = new Point(parentPoint.X + 553, parentPoint.Y + 422);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "남성역")
            {
                fm.Location = new Point(parentPoint.X + 485, parentPoint.Y + 408);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "남태령역")
            {
                fm.Location = new Point(parentPoint.X + 506, parentPoint.Y + 443);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "남한산성입구역")
            {
                fm.Location = new Point(parentPoint.X + 722, parentPoint.Y + 463);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "내방역")
            {
                fm.Location = new Point(parentPoint.X + 518, parentPoint.Y + 401);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "노원역")
            {
                fm.Location = new Point(parentPoint.X + 607, parentPoint.Y + 129);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "녹번역")
            {
                fm.Location = new Point(parentPoint.X + 447, parentPoint.Y + 231);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "녹사평역")
            {
                fm.Location = new Point(parentPoint.X + 497, parentPoint.Y + 333);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "논현역")
            {
                fm.Location = new Point(parentPoint.X + 559, parentPoint.Y + 372);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "단대오거리역")
            {
                fm.Location = new Point(parentPoint.X + 716, parentPoint.Y + 473);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "답십리역")
            {
                fm.Location = new Point(parentPoint.X + 592, parentPoint.Y + 289);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "당고개역")
            {
                fm.Location = new Point(parentPoint.X + 633, parentPoint.Y + 107);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "당산역")
            {
                fm.Location = new Point(parentPoint.X + 413, parentPoint.Y + 340);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "대림역")
            {
                fm.Location = new Point(parentPoint.X + 395, parentPoint.Y + 402);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "대청역")
            {
                fm.Location = new Point(parentPoint.X + 616, parentPoint.Y + 413);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "대치역")
            {
                fm.Location = new Point(parentPoint.X + 601, parentPoint.Y + 414);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "대흥역")
            {
                fm.Location = new Point(parentPoint.X + 454, parentPoint.Y + 317);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "도곡역")
            {
                fm.Location = new Point(parentPoint.X + 594, parentPoint.Y + 417);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "도림천역")
            {
                fm.Location = new Point(parentPoint.X + 379, parentPoint.Y + 369);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "도봉산역")
            {
                fm.Location = new Point(parentPoint.X + 589, parentPoint.Y + 83);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "독립문역")
            {
                fm.Location = new Point(parentPoint.X + 476, parentPoint.Y + 272);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "독바위역")
            {
                fm.Location = new Point(parentPoint.X + 451, parentPoint.Y + 213);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "돌곶이역")
            {
                fm.Location = new Point(parentPoint.X + 593, parentPoint.Y + 217);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "동대문역")
            {
                fm.Location = new Point(parentPoint.X + 532, parentPoint.Y + 273);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "동대문역사문화공원역")
            {
                fm.Location = new Point(parentPoint.X + 528, parentPoint.Y + 284);
                fm.label1.Text = item;
                fm.label1.Font = new Font(Font.FontFamily, fontSize8);
                fm.label1.Location = new Point(2, 47);
                fm.ShowDialog();
            }
            if (item == "동대입구역")
            {
                fm.Location = new Point(parentPoint.X + 527, parentPoint.Y + 292);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "동묘앞역")
            {
                fm.Location = new Point(parentPoint.X + 536, parentPoint.Y + 273);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "동작역")
            {
                fm.Location = new Point(parentPoint.X + 496, parentPoint.Y + 388);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "둔촌동역")
            {
                fm.Location = new Point(parentPoint.X + 686, parentPoint.Y + 339);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "디지털미디어시티역")
            {
                fm.Location = new Point(parentPoint.X + 410, parentPoint.Y + 261);
                fm.label1.Text = item;
                fm.label1.Font = new Font(Font.FontFamily, fontSize10);
                fm.label1.Location = new Point(0, 45);
                fm.ShowDialog();
            }
            if (item == "뚝섬역")
            {
                fm.Location = new Point(parentPoint.X + 577, parentPoint.Y + 316);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "뚝섬유원지역")
            {
                fm.Location = new Point(parentPoint.X + 605, parentPoint.Y + 345);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "마곡역")
            {
                fm.Location = new Point(parentPoint.X + 323, parentPoint.Y + 290);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "마들역")
            {
                fm.Location = new Point(parentPoint.X + 605, parentPoint.Y + 113);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "마장역")
            {
                fm.Location = new Point(parentPoint.X + 582, parentPoint.Y + 288);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "마천역")
            {
                fm.Location = new Point(parentPoint.X + 710, parentPoint.Y + 399);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "마포역")
            {
                fm.Location = new Point(parentPoint.X + 455, parentPoint.Y + 330);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "마포구청역")
            {
                fm.Location = new Point(parentPoint.X + 410, parentPoint.Y + 287);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "망원역")
            {
                fm.Location = new Point(parentPoint.X + 420, parentPoint.Y + 300);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "매봉역")
            {
                fm.Location = new Point(parentPoint.X + 587, parentPoint.Y + 421);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "먹골역")
            {
                fm.Location = new Point(parentPoint.X + 620, parentPoint.Y + 211);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "면목역")
            {
                fm.Location = new Point(parentPoint.X + 628, parentPoint.Y + 243);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "명동역")
            {
                fm.Location = new Point(parentPoint.X + 508, parentPoint.Y + 293);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "명일역")
            {
                fm.Location = new Point(parentPoint.X + 689, parentPoint.Y + 302);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "모란역")
            {
                fm.Location = new Point(parentPoint.X + 684, parentPoint.Y + 486);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "목동역")
            {
                fm.Location = new Point(parentPoint.X + 366, parentPoint.Y + 348);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "몽촌토성역")
            {
                fm.Location = new Point(parentPoint.X + 658, parentPoint.Y + 360);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "무악재역")
            {
                fm.Location = new Point(parentPoint.X + 463, parentPoint.Y + 257);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "문래역")
            {
                fm.Location = new Point(parentPoint.X + 397, parentPoint.Y + 364);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "문정역")
            {
                fm.Location = new Point(parentPoint.X + 671, parentPoint.Y + 412);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "미아역")
            {
                fm.Location = new Point(parentPoint.X + 558, parentPoint.Y + 174);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "미아사거리역")
            {
                fm.Location = new Point(parentPoint.X + 566, parentPoint.Y + 202);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "반포역")
            {
                fm.Location = new Point(parentPoint.X + 544, parentPoint.Y + 376);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "발산역")
            {
                fm.Location = new Point(parentPoint.X + 333, parentPoint.Y + 294);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "방배역")
            {
                fm.Location = new Point(parentPoint.X + 529, parentPoint.Y + 412);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "방이역")
            {
                fm.Location = new Point(parentPoint.X + 676, parentPoint.Y + 377);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "방화역")
            {
                fm.Location = new Point(parentPoint.X + 303, parentPoint.Y + 245);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "버티고개역")
            {
                fm.Location = new Point(parentPoint.X + 531, parentPoint.Y + 309);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "보라매역")
            {
                fm.Location = new Point(parentPoint.X + 426, parentPoint.Y + 391);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "보문역")
            {
                fm.Location = new Point(parentPoint.X + 542, parentPoint.Y + 257);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "복정역")
            {
                fm.Location = new Point(parentPoint.X + 683, parentPoint.Y + 439);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "봉은사역")
            {
                fm.Location = new Point(parentPoint.X + 603, parentPoint.Y + 364);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "봉천역")
            {
                fm.Location = new Point(parentPoint.X + 451, parentPoint.Y + 424);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "봉화산역")
            {
                fm.Location = new Point(parentPoint.X + 646, parentPoint.Y + 197);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "부천시청역")
            {
                fm.Location = new Point(parentPoint.X + 246, parentPoint.Y + 379);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "부천종합운동장역")
            {
                fm.Location = new Point(parentPoint.X + 281, parentPoint.Y + 376);
                fm.label1.Text = item;
                fm.label1.Font = new Font(Font.FontFamily, fontSize10);
                fm.label1.Location = new Point(0, 45);
                fm.ShowDialog();
            }
            if (item == "불광역")
            {
                fm.Location = new Point(parentPoint.X + 444, parentPoint.Y + 222);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "사가정역")
            {
                fm.Location = new Point(parentPoint.X + 629, parentPoint.Y + 255);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "사당역")
            {
                fm.Location = new Point(parentPoint.X + 501, parentPoint.Y + 429);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "산성역")
            {
                fm.Location = new Point(parentPoint.X + 714, parentPoint.Y + 457);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "삼각지역")
            {
                fm.Location = new Point(parentPoint.X + 483, parentPoint.Y + 330);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "삼성역")
            {
                fm.Location = new Point(parentPoint.X + 603, parentPoint.Y + 373);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "삼성중앙역")
            {
                fm.Location = new Point(parentPoint.X + 597, parentPoint.Y + 366);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "상계역")
            {
                fm.Location = new Point(parentPoint.X + 623, parentPoint.Y + 122);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "상도역")
            {
                fm.Location = new Point(parentPoint.X + 464, parentPoint.Y + 387);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "상봉역")
            {
                fm.Location = new Point(parentPoint.X + 627, parentPoint.Y + 231);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "상수역")
            {
                fm.Location = new Point(parentPoint.X + 436, parentPoint.Y + 315);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "상왕십리역")
            {
                fm.Location = new Point(parentPoint.X + 557, parentPoint.Y + 288);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "상월곡역")
            {
                fm.Location = new Point(parentPoint.X + 586, parentPoint.Y + 222);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "상일동역")
            {
                fm.Location = new Point(parentPoint.X + 710, parentPoint.Y + 297);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "새절역")
            {
                fm.Location = new Point(parentPoint.X + 423, parentPoint.Y + 240);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "서대문역")
            {
                fm.Location = new Point(parentPoint.X + 482, parentPoint.Y + 279);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "서울대입구역")
            {
                fm.Location = new Point(parentPoint.X + 463, parentPoint.Y + 426);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "서울역")
            {
                fm.Location = new Point(parentPoint.X + 486, parentPoint.Y + 305);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "서초역")
            {
                fm.Location = new Point(parentPoint.X + 538, parentPoint.Y + 393);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "석계역")
            {
                fm.Location = new Point(parentPoint.X + 607, parentPoint.Y + 208);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "석촌역")
            {
                fm.Location = new Point(parentPoint.X + 648, parentPoint.Y + 378);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "선릉역")
            {
                fm.Location = new Point(parentPoint.X + 588, parentPoint.Y + 378);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "선정릉역")
            {
                fm.Location = new Point(parentPoint.X + 586, parentPoint.Y + 369);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "성수역")
            {
                fm.Location = new Point(parentPoint.X + 587, parentPoint.Y + 320);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "성신여대입구역")
            {
                fm.Location = new Point(parentPoint.X + 553, parentPoint.Y + 231);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "송정역")
            {
                fm.Location = new Point(parentPoint.X + 302, parentPoint.Y + 276);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "송파역")
            {
                fm.Location = new Point(parentPoint.X + 656, parentPoint.Y + 388);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "수락산역")
            {
                fm.Location = new Point(parentPoint.X + 603, parentPoint.Y + 99);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "수서역")
            {
                fm.Location = new Point(parentPoint.X + 645, parentPoint.Y + 418);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "수유역")
            {
                fm.Location = new Point(parentPoint.X + 561, parentPoint.Y + 160);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "수진역")
            {
                fm.Location = new Point(parentPoint.X + 696, parentPoint.Y + 481);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "숙대입구역")
            {
                fm.Location = new Point(parentPoint.X + 487, parentPoint.Y + 315);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "숭실대입구역")
            {
                fm.Location = new Point(parentPoint.X + 471, parentPoint.Y + 398);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "시청역")
            {
                fm.Location = new Point(parentPoint.X + 494, parentPoint.Y + 285);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신금호역")
            {
                fm.Location = new Point(parentPoint.X + 552, parentPoint.Y + 305);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신길역")
            {
                fm.Location = new Point(parentPoint.X + 423, parentPoint.Y + 365);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신내역")
            {
                fm.Location = new Point(parentPoint.X + 657, parentPoint.Y + 201);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신답역")
            {
                fm.Location = new Point(parentPoint.X + 583, parentPoint.Y + 281);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신당역")
            {
                fm.Location = new Point(parentPoint.X + 536, parentPoint.Y + 285);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신대방역")
            {
                fm.Location = new Point(parentPoint.X + 417, parentPoint.Y + 410);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신대방삼거리역")
            {
                fm.Location = new Point(parentPoint.X + 436, parentPoint.Y + 392);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신도림역")
            {
                fm.Location = new Point(parentPoint.X + 391, parentPoint.Y + 384);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신림역")
            {
                fm.Location = new Point(parentPoint.X + 437, parentPoint.Y + 418);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신사역")
            {
                fm.Location = new Point(parentPoint.X + 549, parentPoint.Y + 364);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신설동역")
            {
                fm.Location = new Point(parentPoint.X + 554, parentPoint.Y + 270);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신용산역")
            {
                fm.Location = new Point(parentPoint.X + 478, parentPoint.Y + 340);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신정역")
            {
                fm.Location = new Point(parentPoint.X + 353, parentPoint.Y + 344);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신정네거리역")
            {
                fm.Location = new Point(parentPoint.X + 347, parentPoint.Y + 354);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신중동역")
            {
                fm.Location = new Point(parentPoint.X + 258, parentPoint.Y + 381);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신촌역")
            {
                fm.Location = new Point(parentPoint.X + 454, parentPoint.Y + 294);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신풍역")
            {
                fm.Location = new Point(parentPoint.X + 411, parentPoint.Y + 391);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신흥역")
            {
                fm.Location = new Point(parentPoint.X + 706, parentPoint.Y + 478);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "쌍문역")
            {
                fm.Location = new Point(parentPoint.X + 569, parentPoint.Y + 144);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "아차산역")
            {
                fm.Location = new Point(parentPoint.X + 634, parentPoint.Y + 305);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "아현역")
            {
                fm.Location = new Point(parentPoint.X + 469, parentPoint.Y + 294);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "안국역")
            {
                fm.Location = new Point(parentPoint.X + 512, parentPoint.Y + 261);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "안암역")
            {
                fm.Location = new Point(parentPoint.X + 552, parentPoint.Y + 258);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "암사역")
            {
                fm.Location = new Point(parentPoint.X + 674, parentPoint.Y + 302);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "압구정역")
            {
                fm.Location = new Point(parentPoint.X + 556, parentPoint.Y + 351);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "애오개역")
            {
                fm.Location = new Point(parentPoint.X + 470, parentPoint.Y + 307);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "약수역")
            {
                fm.Location = new Point(parentPoint.X + 533, parentPoint.Y + 295);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "양재역")
            {
                fm.Location = new Point(parentPoint.X + 577, parentPoint.Y + 425);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "양천구청역")
            {
                fm.Location = new Point(parentPoint.X + 358, parentPoint.Y + 363);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "양평역")
            {
                fm.Location = new Point(parentPoint.X + 384, parentPoint.Y + 349);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "어린이대공원역")
            {
                fm.Location = new Point(parentPoint.X + 616, parentPoint.Y + 314);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "언주역")
            {
                fm.Location = new Point(parentPoint.X + 575, parentPoint.Y + 375);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "여의나루역")
            {
                fm.Location = new Point(parentPoint.X + 442, parentPoint.Y + 345);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "여의도역")
            {
                fm.Location = new Point(parentPoint.X + 438, parentPoint.Y + 351);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "역삼역")
            {
                fm.Location = new Point(parentPoint.X + 576, parentPoint.Y + 381);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "역촌역")
            {
                fm.Location = new Point(parentPoint.X + 436, parentPoint.Y + 225);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "연신내역")
            {
                fm.Location = new Point(parentPoint.X + 437, parentPoint.Y + 207);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "영등포구청역")
            {
                fm.Location = new Point(parentPoint.X + 404, parentPoint.Y + 357);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "영등포시장역")
            {
                fm.Location = new Point(parentPoint.X + 412, parentPoint.Y + 358);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "오금역")
            {
                fm.Location = new Point(parentPoint.X + 681, parentPoint.Y + 389);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "오목교역")
            {
                fm.Location = new Point(parentPoint.X + 375, parentPoint.Y + 347);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "옥수역")
            {
                fm.Location = new Point(parentPoint.X + 546, parentPoint.Y + 329);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "온수역")
            {
                fm.Location = new Point(parentPoint.X + 311, parentPoint.Y + 404);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "올림픽공원역")
            {
                fm.Location = new Point(parentPoint.X + 679, parentPoint.Y + 367);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "왕십리역")
            {
                fm.Location = new Point(parentPoint.X + 571, parentPoint.Y + 294);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "용답역")
            {
                fm.Location = new Point(parentPoint.X + 586, parentPoint.Y + 298);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "용두역")
            {
                fm.Location = new Point(parentPoint.X + 572, parentPoint.Y + 277);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "용마산역")
            {
                fm.Location = new Point(parentPoint.X + 629, parentPoint.Y + 270);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "우장산역")
            {
                fm.Location = new Point(parentPoint.X + 331, parentPoint.Y + 304);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "월곡역")
            {
                fm.Location = new Point(parentPoint.X + 574, parentPoint.Y + 232);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "월드컵경기장역")
            {
                fm.Location = new Point(parentPoint.X + 406, parentPoint.Y + 274);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "을지로3가역")
            {
                fm.Location = new Point(parentPoint.X + 519, parentPoint.Y + 284);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "을지로4가역")
            {
                fm.Location = new Point(parentPoint.X + 524, parentPoint.Y + 284);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "을지로입구역")
            {
                fm.Location = new Point(parentPoint.X + 506, parentPoint.Y + 283);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "응암역")
            {
                fm.Location = new Point(parentPoint.X + 426, parentPoint.Y + 230);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "이대역")
            {
                fm.Location = new Point(parentPoint.X + 462, parentPoint.Y + 296);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "이수역")
            {
                fm.Location = new Point(parentPoint.X + 502, parentPoint.Y + 404);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "이촌역")
            {
                fm.Location = new Point(parentPoint.X + 483, parentPoint.Y + 355);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "이태원역")
            {
                fm.Location = new Point(parentPoint.X + 512, parentPoint.Y + 331);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "일원역")
            {
                fm.Location = new Point(parentPoint.X + 629, parentPoint.Y + 431);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "잠실역")
            {
                fm.Location = new Point(parentPoint.X + 643, parentPoint.Y + 367);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "잠실나루역")
            {
                fm.Location = new Point(parentPoint.X + 644, parentPoint.Y + 354);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "잠실새내역")
            {
                fm.Location = new Point(parentPoint.X + 631, parentPoint.Y + 369);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "잠원역")
            {
                fm.Location = new Point(parentPoint.X + 541, parentPoint.Y + 367);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "장승배기역")
            {
                fm.Location = new Point(parentPoint.X + 451, parentPoint.Y + 385);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "장암역")
            {
                fm.Location = new Point(parentPoint.X + 602, parentPoint.Y + 64);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "장지역")
            {
                fm.Location = new Point(parentPoint.X + 677, parentPoint.Y + 423);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "장한평역")
            {
                fm.Location = new Point(parentPoint.X + 607, parentPoint.Y + 294);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "제기동역")
            {
                fm.Location = new Point(parentPoint.X + 576, parentPoint.Y + 264);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "종각역")
            {
                fm.Location = new Point(parentPoint.X + 502, parentPoint.Y + 273);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "종로3가역")
            {
                fm.Location = new Point(parentPoint.X + 518, parentPoint.Y + 269);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "종로5가역")
            {
                fm.Location = new Point(parentPoint.X + 527, parentPoint.Y + 273);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "종합운동장역")
            {
                fm.Location = new Point(parentPoint.X + 621, parentPoint.Y + 370);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "중계역")
            {
                fm.Location = new Point(parentPoint.X + 611, parentPoint.Y + 151);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "중곡역")
            {
                fm.Location = new Point(parentPoint.X + 626, parentPoint.Y + 284);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "중화역")
            {
                fm.Location = new Point(parentPoint.X + 621, parentPoint.Y + 222);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "증산역")
            {
                fm.Location = new Point(parentPoint.X + 416, parentPoint.Y + 248);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "지축역")
            {
                fm.Location = new Point(parentPoint.X + 425, parentPoint.Y + 141);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "창동역")
            {
                fm.Location = new Point(parentPoint.X + 587, parentPoint.Y + 135);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "창신역")
            {
                fm.Location = new Point(parentPoint.X + 536, parentPoint.Y + 265);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "천왕역")
            {
                fm.Location = new Point(parentPoint.X + 335, parentPoint.Y + 412);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "천호역")
            {
                fm.Location = new Point(parentPoint.X + 673, parentPoint.Y + 315);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "철산역")
            {
                fm.Location = new Point(parentPoint.X + 363, parentPoint.Y + 427);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "청구역")
            {
                fm.Location = new Point(parentPoint.X + 535, parentPoint.Y + 290);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "청담역")
            {
                fm.Location = new Point(parentPoint.X + 595, parentPoint.Y + 359);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "청량리역")
            {
                fm.Location = new Point(parentPoint.X + 591, parentPoint.Y + 253);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "총신대입구역")
            {
                fm.Location = new Point(parentPoint.X + 502, parentPoint.Y + 401);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "춘의역")
            {
                fm.Location = new Point(parentPoint.X + 268, parentPoint.Y + 381);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "충무로역")
            {
                fm.Location = new Point(parentPoint.X + 520, parentPoint.Y + 289);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "충정로역")
            {
                fm.Location = new Point(parentPoint.X + 475, parentPoint.Y + 290);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "태릉입구역")
            {
                fm.Location = new Point(parentPoint.X + 619, parentPoint.Y + 204);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "하계역")
            {
                fm.Location = new Point(parentPoint.X + 614, parentPoint.Y + 168);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "학동역")
            {
                fm.Location = new Point(parentPoint.X + 571, parentPoint.Y + 366);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "학여울역")
            {
                fm.Location = new Point(parentPoint.X + 607, parentPoint.Y + 410);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "한강진역")
            {
                fm.Location = new Point(parentPoint.X + 526, parentPoint.Y + 320);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "한성대입구역")
            {
                fm.Location = new Point(parentPoint.X + 530, parentPoint.Y + 242);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "한양대역")
            {
                fm.Location = new Point(parentPoint.X + 576, parentPoint.Y + 303);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "합정역")
            {
                fm.Location = new Point(parentPoint.X + 427, parentPoint.Y + 313);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "행당역")
            {
                fm.Location = new Point(parentPoint.X + 562, parentPoint.Y + 300);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "혜화역")
            {
                fm.Location = new Point(parentPoint.X + 522, parentPoint.Y + 251);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "홍대입구역")
            {
                fm.Location = new Point(parentPoint.X + 444, parentPoint.Y + 294);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "홍제역")
            {
                fm.Location = new Point(parentPoint.X + 451, parentPoint.Y + 243);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "화곡역")
            {
                fm.Location = new Point(parentPoint.X + 335, parentPoint.Y + 320);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "화랑대역")
            {
                fm.Location = new Point(parentPoint.X + 630, parentPoint.Y + 199);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "회현역")
            {
                fm.Location = new Point(parentPoint.X + 496, parentPoint.Y + 296);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "효창공원앞역")
            {
                fm.Location = new Point(parentPoint.X + 472, parentPoint.Y + 328);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
        }
        
        private int Get_item(string text)
        {
            int ix = 0;
            foreach (object o in chk_listbox.Items)
            {
                if (text == o.ToString())
                {
                    return ix;
                }
                ix++;
            }
            return -1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ArrayList alist = new ArrayList();

            if (textBox1.Text != chk_listbox.Items.ToString())
            {
                if (textBox1.Text == "")
                    change_chklist_item(station_txt);
                else
                {
                    change_chklist_item(station_txt);
                    foreach (object o in chk_listbox.Items)
                    {
                        if (o.ToString().Contains(textBox1.Text))
                            alist.Add(o);
                    }
                    chk_listbox.Items.Clear();
                    foreach (object k in alist)
                        chk_listbox.Items.Add(k);
                }
            }

        }

        private void chk_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = chk_listbox.SelectedIndex;
            string item = chk_listbox.SelectedItem.ToString();
            textBox1.Text = item;
        }
    }
}
