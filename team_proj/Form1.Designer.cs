
namespace team_proj
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.chk_listbox = new System.Windows.Forms.CheckedListBox();
            this.scr_scale = new System.Windows.Forms.HScrollBar();
            this.scr_time = new System.Windows.Forms.VScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_nowTime = new System.Windows.Forms.Label();
            this.lbl_scale1 = new System.Windows.Forms.Label();
            this.lbl_scale2 = new System.Windows.Forms.Label();
            this.lbl_scale3 = new System.Windows.Forms.Label();
            this.lbl_scale = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.picbox_map = new System.Windows.Forms.PictureBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_find = new System.Windows.Forms.Button();
            this.btn_apply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_map)).BeginInit();
            this.SuspendLayout();
            // 
            // chk_listbox
            // 
            resources.ApplyResources(this.chk_listbox, "chk_listbox");
            this.chk_listbox.CheckOnClick = true;
            this.chk_listbox.FormattingEnabled = true;
            this.chk_listbox.Name = "chk_listbox";
            this.chk_listbox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chk_listbox_ItemCheck);
            // 
            // scr_scale
            // 
            resources.ApplyResources(this.scr_scale, "scr_scale");
            this.scr_scale.Maximum = 11;
            this.scr_scale.Name = "scr_scale";
            this.scr_scale.ValueChanged += new System.EventHandler(this.scr_scale_ValueChanged);
            // 
            // scr_time
            // 
            resources.ApplyResources(this.scr_time, "scr_time");
            this.scr_time.Maximum = 32;
            this.scr_time.Name = "scr_time";
            this.scr_time.ValueChanged += new System.EventHandler(this.scr_time_ValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Name = "label3";
            // 
            // lbl_nowTime
            // 
            resources.ApplyResources(this.lbl_nowTime, "lbl_nowTime");
            this.lbl_nowTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_nowTime.Name = "lbl_nowTime";
            // 
            // lbl_scale1
            // 
            resources.ApplyResources(this.lbl_scale1, "lbl_scale1");
            this.lbl_scale1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_scale1.Name = "lbl_scale1";
            // 
            // lbl_scale2
            // 
            resources.ApplyResources(this.lbl_scale2, "lbl_scale2");
            this.lbl_scale2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_scale2.Name = "lbl_scale2";
            // 
            // lbl_scale3
            // 
            resources.ApplyResources(this.lbl_scale3, "lbl_scale3");
            this.lbl_scale3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_scale3.Name = "lbl_scale3";
            // 
            // lbl_scale
            // 
            resources.ApplyResources(this.lbl_scale, "lbl_scale");
            this.lbl_scale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_scale.Name = "lbl_scale";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Name = "label5";
            // 
            // picbox_map
            // 
            resources.ApplyResources(this.picbox_map, "picbox_map");
            this.picbox_map.Name = "picbox_map";
            this.picbox_map.TabStop = false;
            // 
            // btn_clear
            // 
            resources.ApplyResources(this.btn_clear, "btn_clear");
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // btn_find
            // 
            resources.ApplyResources(this.btn_find, "btn_find");
            this.btn_find.Name = "btn_find";
            this.btn_find.UseVisualStyleBackColor = true;
            // 
            // btn_apply
            // 
            resources.ApplyResources(this.btn_apply, "btn_apply");
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.UseVisualStyleBackColor = true;
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btn_find);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_apply);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.picbox_map);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_scale3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_scale);
            this.Controls.Add(this.lbl_scale2);
            this.Controls.Add(this.lbl_scale1);
            this.Controls.Add(this.lbl_nowTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scr_time);
            this.Controls.Add(this.scr_scale);
            this.Controls.Add(this.chk_listbox);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picbox_map)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chk_listbox;
        private System.Windows.Forms.HScrollBar scr_scale;
        private System.Windows.Forms.VScrollBar scr_time;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_nowTime;
        private System.Windows.Forms.Label lbl_scale1;
        private System.Windows.Forms.Label lbl_scale2;
        private System.Windows.Forms.Label lbl_scale3;
        private System.Windows.Forms.Label lbl_scale;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picbox_map;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.Button btn_apply;
    }
}

