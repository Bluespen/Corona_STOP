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
                        if (e.Index != ix) chk_listbox.SetItemChecked(ix, false);
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
    }
}
