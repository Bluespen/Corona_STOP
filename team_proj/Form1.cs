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
using _Excel = Microsoft.Office.Interop.Excel;


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

        StaInfo sta = new StaInfo("강남역", 1); // class 받아오기
        StaInfo[] staa;

        ArrayList gangnam = new ArrayList();
        ArrayList gangdong = new ArrayList();
        ArrayList gangbouk = new ArrayList();
        ArrayList gangseu = new ArrayList();
        ArrayList gwanak = new ArrayList();
        ArrayList gwangjin = new ArrayList();
        ArrayList guro = new ArrayList();
        ArrayList gumchun = new ArrayList();
        ArrayList nowon = new ArrayList();
        ArrayList dobong = new ArrayList();
        ArrayList dongdemun = new ArrayList();
        ArrayList dongjak = new ArrayList();
        ArrayList mapo = new ArrayList();
        ArrayList seudemun = new ArrayList();
        ArrayList seucho = new ArrayList();
        ArrayList sungdong = new ArrayList();
        ArrayList sungbuk = new ArrayList();
        ArrayList songpa = new ArrayList();
        ArrayList yangchun = new ArrayList();
        ArrayList youngdungpo = new ArrayList();
        ArrayList yongsan = new ArrayList();
        ArrayList eunpyung = new ArrayList();
        ArrayList jongro = new ArrayList();
        ArrayList jung = new ArrayList();
        ArrayList jungrang = new ArrayList();

        public Form1()
        {
            InitializeComponent();
            picbox_map.Image = Image.FromFile(seoulmap_path);
            btn_find.Image = Image.FromFile(Path.GetFullPath(Path.Combine(prj_path, @"find_btn.png")));
            change_chklist_item(gu_txt);
            parent_initialize();
            gu_initialize();

            //GuInfo GuGu = new GuInfo("강남구", sta);
            //MessageBox.Show(GuGu.StaInfos[0].Name);
        }


        private void parent_initialize()
        {
            lbl_가락시장역.Parent = picbox_map;
            lbl_가산디지털단지역.Parent = picbox_map;
            lbl_가좌역.Parent = picbox_map;
            lbl_강남구청역.Parent = picbox_map;
            lbl_강남역.Parent = picbox_map;
            lbl_강동구청역.Parent = picbox_map;
            lbl_강동역.Parent = picbox_map;
            lbl_강변역.Parent = picbox_map;
            lbl_개롱역.Parent = picbox_map;
            lbl_개봉역.Parent = picbox_map;
            lbl_개포동역.Parent = picbox_map;
            lbl_개화산역.Parent = picbox_map;
            lbl_거여역.Parent = picbox_map;
            lbl_건대입구역.Parent = picbox_map;
            lbl_경복궁역.Parent = picbox_map;
            lbl_경찰병원역.Parent = picbox_map;
            lbl_고려대역.Parent = picbox_map;
            lbl_고속터미널역.Parent = picbox_map;
            lbl_공덕역.Parent = picbox_map;
            lbl_공릉역.Parent = picbox_map;
            lbl_광나루역.Parent = picbox_map;
            lbl_광명사거리역.Parent = picbox_map;
            lbl_광운대역.Parent = picbox_map;
            lbl_광화문역.Parent = picbox_map;
            lbl_광흥창역.Parent = picbox_map;
            lbl_교대역.Parent = picbox_map;
            lbl_구로디지털단지역.Parent = picbox_map;
            lbl_구로역.Parent = picbox_map;
            lbl_구룡역.Parent = picbox_map;
            lbl_구반포역.Parent = picbox_map;
            lbl_구산역.Parent = picbox_map;
            lbl_구의역.Parent = picbox_map;
            lbl_구일역.Parent = picbox_map;
            lbl_구파발역.Parent = picbox_map;
            lbl_국회의사당역.Parent = picbox_map;
            lbl_군자역.Parent = picbox_map;
            lbl_굽은다리역.Parent = picbox_map;
            lbl_금천구청역.Parent = picbox_map;
            lbl_길동역.Parent = picbox_map;
            lbl_길음역.Parent = picbox_map;
            lbl_김포공항역.Parent = picbox_map;
            lbl_까치산역.Parent = picbox_map;
            lbl_낙성대역.Parent = picbox_map;
            lbl_남구로역.Parent = picbox_map;
            lbl_남부터미널역.Parent = picbox_map;
            lbl_남성역.Parent = picbox_map;
            lbl_남영역.Parent = picbox_map;
            lbl_남태령역.Parent = picbox_map;
            lbl_내방역.Parent = picbox_map;
            lbl_노들역.Parent = picbox_map;
            lbl_노량진역.Parent = picbox_map;
            lbl_노원역.Parent = picbox_map;
            lbl_녹번역.Parent = picbox_map;
            lbl_녹사평역.Parent = picbox_map;
            lbl_녹천역.Parent = picbox_map;
            lbl_논현역.Parent = picbox_map;
            lbl_답십리역.Parent = picbox_map;
            lbl_당고개역.Parent = picbox_map;
            lbl_당산역.Parent = picbox_map;
            lbl_대림역.Parent = picbox_map;
            lbl_대모산입구역.Parent = picbox_map;
            lbl_대방역.Parent = picbox_map;
            lbl_대청역.Parent = picbox_map;
            lbl_대치역.Parent = picbox_map;
            lbl_대흥역.Parent = picbox_map;
            lbl_도곡역.Parent = picbox_map;
            lbl_도림천역.Parent = picbox_map;
            lbl_도봉산역.Parent = picbox_map;
            lbl_도봉역.Parent = picbox_map;
            lbl_독립문역.Parent = picbox_map;
            lbl_독바위역.Parent = picbox_map;
            lbl_독산역.Parent = picbox_map;
            lbl_돌곶이역.Parent = picbox_map;
            lbl_동대문역.Parent = picbox_map;
            lbl_동대문역사문화공원역.Parent = picbox_map;
            lbl_동대입구역.Parent = picbox_map;
            lbl_동묘앞역.Parent = picbox_map;
            lbl_동작역.Parent = picbox_map;
            lbl_둔촌동역.Parent = picbox_map;
            lbl_둔촌오륜역.Parent = picbox_map;
            lbl_등촌역.Parent = picbox_map;
            lbl_디지털미디어시티역.Parent = picbox_map;
            lbl_뚝섬역.Parent = picbox_map;
            lbl_뚝섬유원지역.Parent = picbox_map;
            lbl_마곡나루역.Parent = picbox_map;
            lbl_마곡역.Parent = picbox_map;
            lbl_마들역.Parent = picbox_map;
            lbl_마장역.Parent = picbox_map;
            lbl_마천역.Parent = picbox_map;
            lbl_마포구청역.Parent = picbox_map;
            lbl_마포역.Parent = picbox_map;
            lbl_망우역.Parent = picbox_map;
            lbl_망우역.Parent = picbox_map;
            lbl_망원역.Parent = picbox_map;
            lbl_매봉역.Parent = picbox_map;
            lbl_먹골역.Parent = picbox_map;
            lbl_면목역.Parent = picbox_map;
            lbl_명동역.Parent = picbox_map;
            lbl_명일역.Parent = picbox_map;
            lbl_목동역.Parent = picbox_map;
            lbl_몽촌토성역.Parent = picbox_map;
            lbl_홍제역.Parent = picbox_map;
            lbl_문래역.Parent = picbox_map;
            lbl_문정역.Parent = picbox_map;
            lbl_미아사거리역.Parent = picbox_map;
            lbl_미아역.Parent = picbox_map;
            lbl_반포역.Parent = picbox_map;
            lbl_반포역.Parent = picbox_map;
            lbl_발산역.Parent = picbox_map;
            lbl_방배역.Parent = picbox_map;
            lbl_방이역.Parent = picbox_map;
            lbl_방학역.Parent = picbox_map;
            lbl_버티고개역.Parent = picbox_map;
            lbl_보라매역.Parent = picbox_map;
            lbl_보문역.Parent = picbox_map;
            lbl_복정역.Parent = picbox_map;
            lbl_봉은사역.Parent = picbox_map;
            lbl_봉천역.Parent = picbox_map;
            lbl_봉화산역.Parent = picbox_map;
            lbl_봉화산역.Parent = picbox_map;
            lbl_불광역.Parent = picbox_map;
            lbl_사가정역.Parent = picbox_map;
            lbl_사당역.Parent = picbox_map;
            lbl_사평역.Parent = picbox_map;
            lbl_삼각지역.Parent = picbox_map;
            lbl_삼성중앙역.Parent = picbox_map;
            lbl_삼전역.Parent = picbox_map;
            lbl_상계역.Parent = picbox_map;
            lbl_상도역.Parent = picbox_map;
            lbl_상봉역.Parent = picbox_map;
            lbl_상수역.Parent = picbox_map;
            lbl_상왕십리역.Parent = picbox_map;
            lbl_상월곡역.Parent = picbox_map;
            lbl_상일동역.Parent = picbox_map;
            lbl_새절역.Parent = picbox_map;
            lbl_샛강역.Parent = picbox_map;
            lbl_서대문역.Parent = picbox_map;
            lbl_서빙고역.Parent = picbox_map;
            lbl_서울대입구역.Parent = picbox_map;
            lbl_서울숲역.Parent = picbox_map;
            lbl_서울역.Parent = picbox_map;
            lbl_서초역.Parent = picbox_map;
            lbl_석계역.Parent = picbox_map;
            lbl_석계역.Parent = picbox_map;
            lbl_석수역.Parent = picbox_map;
            lbl_석촌고분역.Parent = picbox_map;
            lbl_석촌역.Parent = picbox_map;
            lbl_선릉역.Parent = picbox_map;
            lbl_선유도역.Parent = picbox_map;
            lbl_선정릉역.Parent = picbox_map;
            lbl_성수역.Parent = picbox_map;
            lbl_성신여대입구역.Parent = picbox_map;
            lbl_송정역.Parent = picbox_map;
            lbl_송파나루역.Parent = picbox_map;
            lbl_송파역.Parent = picbox_map;
            lbl_수락산역.Parent = picbox_map;
            lbl_수색역.Parent = picbox_map;
            lbl_수서역.Parent = picbox_map;
            lbl_수유역.Parent = picbox_map;
            lbl_숙대입구역.Parent = picbox_map;
            lbl_숭실대입구역.Parent = picbox_map;
            lbl_시청역.Parent = picbox_map;
            lbl_신금호역.Parent = picbox_map;
            lbl_신길역.Parent = picbox_map;
            lbl_신내역.Parent = picbox_map;
            lbl_신내역.Parent = picbox_map;
            lbl_신논현역.Parent = picbox_map;
            lbl_신답역.Parent = picbox_map;
            lbl_신당역.Parent = picbox_map;
            lbl_신대방삼거리역.Parent = picbox_map;
            lbl_신대방역.Parent = picbox_map;
            lbl_신도림역.Parent = picbox_map;
            lbl_신림역.Parent = picbox_map;
            lbl_신목동역.Parent = picbox_map;
            lbl_신반포역.Parent = picbox_map;
            lbl_신방화역.Parent = picbox_map;
            lbl_신사역.Parent = picbox_map;
            lbl_신설동역.Parent = picbox_map;
            lbl_신용산역.Parent = picbox_map;
            lbl_신이문역.Parent = picbox_map;
            lbl_신정네거리역.Parent = picbox_map;
            lbl_신정역.Parent = picbox_map;
            lbl_신촌역1.Parent = picbox_map;
            lbl_신촌역2.Parent = picbox_map;
            lbl_신풍역.Parent = picbox_map;
            lbl_쌍문역.Parent = picbox_map;
            lbl_아차산역.Parent = picbox_map;
            lbl_아현역.Parent = picbox_map;
            lbl_안국역.Parent = picbox_map;
            lbl_안암역.Parent = picbox_map;
            lbl_압구정로데오역.Parent = picbox_map;
            lbl_압구정역.Parent = picbox_map;
            lbl_애오개역.Parent = picbox_map;
            lbl_약수역.Parent = picbox_map;
            lbl_양원역.Parent = picbox_map;
            lbl_양원역.Parent = picbox_map;
            lbl_양재시민의숲역.Parent = picbox_map;
            lbl_양재역.Parent = picbox_map;
            lbl_양천구청역.Parent = picbox_map;
            lbl_양천향교역.Parent = picbox_map;
            lbl_양평역.Parent = picbox_map;
            lbl_어린이대공원역.Parent = picbox_map;
            lbl_언주역.Parent = picbox_map;
            lbl_여의나루역.Parent = picbox_map;
            lbl_여의도역.Parent = picbox_map;
            lbl_역삼역.Parent = picbox_map;
            lbl_역촌역.Parent = picbox_map;
            lbl_연신내역.Parent = picbox_map;
            lbl_염창역.Parent = picbox_map;
            lbl_영등포구청역.Parent = picbox_map;
            lbl_영등포시장역.Parent = picbox_map;
            lbl_영등포역.Parent = picbox_map;
            lbl_오금역.Parent = picbox_map;
            lbl_오류동역.Parent = picbox_map;
            lbl_오목교역.Parent = picbox_map;
            lbl_옥수역.Parent = picbox_map;
            lbl_온수역.Parent = picbox_map;
            lbl_올림픽공원역.Parent = picbox_map;
            lbl_왕십리역.Parent = picbox_map;
            lbl_외대앞역.Parent = picbox_map;
            lbl_용답역.Parent = picbox_map;
            lbl_용두역.Parent = picbox_map;
            lbl_용마산역.Parent = picbox_map;
            lbl_용산역.Parent = picbox_map;
            lbl_우장산역.Parent = picbox_map;
            lbl_월계역.Parent = picbox_map;
            lbl_월곡역.Parent = picbox_map;
            lbl_월드컵경기장역.Parent = picbox_map;
            lbl_을지로3가역.Parent = picbox_map;
            lbl_을지로4가역.Parent = picbox_map;
            lbl_을지로입구역.Parent = picbox_map;
            lbl_응봉역.Parent = picbox_map;
            lbl_응암역.Parent = picbox_map;
            lbl_이대역.Parent = picbox_map;
            lbl_이수역.Parent = picbox_map;
            lbl_이촌역.Parent = picbox_map;
            lbl_이태원역.Parent = picbox_map;
            lbl_일원역.Parent = picbox_map;
            lbl_잠실나루역.Parent = picbox_map;
            lbl_잠실새내역.Parent = picbox_map;
            lbl_잠실역.Parent = picbox_map;
            lbl_잠원역.Parent = picbox_map;
            lbl_장승배기역.Parent = picbox_map;
            lbl_장지역.Parent = picbox_map;
            lbl_장한평역.Parent = picbox_map;
            lbl_정릉역.Parent = picbox_map;
            lbl_제기동역.Parent = picbox_map;
            lbl_종각역.Parent = picbox_map;
            lbl_종로3가역.Parent = picbox_map;
            lbl_종로5가역.Parent = picbox_map;
            lbl_종합운동장역.Parent = picbox_map;
            lbl_중계역.Parent = picbox_map;
            lbl_중곡역.Parent = picbox_map;
            lbl_중랑역.Parent = picbox_map;
            lbl_중화역.Parent = picbox_map;
            lbl_증미역.Parent = picbox_map;
            lbl_증산역.Parent = picbox_map;
            lbl_창동역.Parent = picbox_map;
            lbl_창신역.Parent = picbox_map;
            lbl_천왕역.Parent = picbox_map;
            lbl_천호역.Parent = picbox_map;
            lbl_청계산입구역.Parent = picbox_map;
            lbl_청구역.Parent = picbox_map;
            lbl_청담역.Parent = picbox_map;
            lbl_청량리역.Parent = picbox_map;
            lbl_총신대입구역.Parent = picbox_map;
            lbl_충무로역.Parent = picbox_map;
            lbl_태릉입구역.Parent = picbox_map;
            lbl_하계역.Parent = picbox_map;
            lbl_학동역.Parent = picbox_map;
            lbl_학여울역.Parent = picbox_map;
            lbl_한강진역.Parent = picbox_map;
            lbl_한남역.Parent = picbox_map;
            lbl_한성대입구역.Parent = picbox_map;
            lbl_한성백제역.Parent = picbox_map;
            lbl_한양대역.Parent = picbox_map;
            lbl_한티역.Parent = picbox_map;
            lbl_합정역.Parent = picbox_map;
            lbl_행당역.Parent = picbox_map;
            lbl_혜화역.Parent = picbox_map;
            lbl_홍대입구역.Parent = picbox_map;
            lbl_홍제역.Parent = picbox_map;
            lbl_화곡역.Parent = picbox_map;
            lbl_화랑대역.Parent = picbox_map;
            lbl_회기역.Parent = picbox_map;
            lbl_회현역.Parent = picbox_map;
            lbl_효창공원앞역.Parent = picbox_map;
            lbl_흑석역.Parent = picbox_map;

        }
        private void gu_initialize()
        {
            gangnam.Add(lbl_압구정역);
            gangnam.Add(lbl_압구정로데오역);
            gangnam.Add(lbl_신사역);
            gangnam.Add(lbl_논현역);
            gangnam.Add(lbl_신논현역);
            gangnam.Add(lbl_강남역);
            gangnam.Add(lbl_양재역);
            gangnam.Add(lbl_매봉역);
            gangnam.Add(lbl_도곡역);
            gangnam.Add(lbl_대치역);
            gangnam.Add(lbl_학여울역);
            gangnam.Add(lbl_대청역);
            gangnam.Add(lbl_일원역);
            gangnam.Add(lbl_수서역);
            gangnam.Add(lbl_대모산입구역);
            gangnam.Add(lbl_개포동역);
            gangnam.Add(lbl_구룡역);
            gangnam.Add(lbl_한티역);
            gangnam.Add(lbl_선릉역);
            gangnam.Add(lbl_선정릉역);
            gangnam.Add(lbl_강남구청역);
            gangnam.Add(lbl_역삼역);
            gangnam.Add(lbl_삼성중앙역);
            gangnam.Add(lbl_봉은사역);
            gangnam.Add(lbl_청담역);
            gangnam.Add(lbl_언주역);
            gangnam.Add(lbl_학동역);

            gangdong.Add(lbl_천호역);
            gangdong.Add(lbl_암사역);
            gangdong.Add(lbl_둔촌동역);
            gangdong.Add(lbl_강동역);
            gangdong.Add(lbl_길동역);
            gangdong.Add(lbl_굽은다리역);
            gangdong.Add(lbl_명일역);
            gangdong.Add(lbl_고덕역);
            gangdong.Add(lbl_상일동역);
            gangdong.Add(lbl_강일역);

            gangbouk.Add(lbl_미아사거리역);
            gangbouk.Add(lbl_미아역);
            gangbouk.Add(lbl_수유역);

            gangseu.Add(lbl_증미역);
            gangseu.Add(lbl_가양역);
            gangseu.Add(lbl_양천향교역);
            gangseu.Add(lbl_마곡나루역);
            gangseu.Add(lbl_신방화역);
            gangseu.Add(lbl_개화산역);
            gangseu.Add(lbl_개화역);
            gangseu.Add(lbl_김포공항역);
            gangseu.Add(lbl_송정역);
            gangseu.Add(lbl_마곡역);
            gangseu.Add(lbl_발산역);
            gangseu.Add(lbl_우장산역);
            gangseu.Add(lbl_화곡역);
            gangseu.Add(lbl_까치산역);

            gwanak.Add(lbl_낙성대역);
            gwanak.Add(lbl_서울대입구역);
            gwanak.Add(lbl_봉천역);
            gwanak.Add(lbl_신림역);
            gwanak.Add(lbl_신대방역);

            gwangjin.Add(lbl_중곡역);
            gwangjin.Add(lbl_군자역);
            gwangjin.Add(lbl_아차산역);
            gwangjin.Add(lbl_어린이대공원역);
            gwangjin.Add(lbl_건대입구역);
            gwangjin.Add(lbl_뚝섬유원지역);
            gwangjin.Add(lbl_구의역);
            gwangjin.Add(lbl_강변역);
            gwangjin.Add(lbl_광나루역);

            guro.Add(lbl_구로디지털단지역);
            guro.Add(lbl_대림역);
            guro.Add(lbl_남구로역);
            guro.Add(lbl_신도림역);
            guro.Add(lbl_도림천역);
            guro.Add(lbl_구로역);
            guro.Add(lbl_구일역);
            guro.Add(lbl_개봉역);
            guro.Add(lbl_오류동역);
            guro.Add(lbl_온수역);
            guro.Add(lbl_천왕역);
            guro.Add(lbl_광명사거리역);

            gumchun.Add(lbl_가산디지털단지역);
            gumchun.Add(lbl_독산역);
            gumchun.Add(lbl_금천구청역);
            gumchun.Add(lbl_석수역);

            nowon.Add(lbl_수락산역);
            nowon.Add(lbl_마들역);
            nowon.Add(lbl_노원역);
            nowon.Add(lbl_중계역);
            nowon.Add(lbl_하계역);
            nowon.Add(lbl_공릉역);
            nowon.Add(lbl_태릉입구역);
            nowon.Add(lbl_화랑대역);
            nowon.Add(lbl_석계역);
            nowon.Add(lbl_광운대역);
            nowon.Add(lbl_월계역);
            nowon.Add(lbl_녹천역);

            dobong.Add(lbl_쌍문역);
            dobong.Add(lbl_창동역);
            dobong.Add(lbl_방학역);
            dobong.Add(lbl_도봉역);
            dobong.Add(lbl_도봉산역);

            dongdemun.Add(lbl_신이문역);
            dongdemun.Add(lbl_외대앞역);
            dongdemun.Add(lbl_회기역);
            dongdemun.Add(lbl_청량리역);
            dongdemun.Add(lbl_제기동역);
            dongdemun.Add(lbl_장한평역);
            dongdemun.Add(lbl_용두역);
            dongdemun.Add(lbl_신설동역);

            dongjak.Add(lbl_사당역);
            dongjak.Add(lbl_이수역);
            dongjak.Add(lbl_총신대입구역);
            dongjak.Add(lbl_동작역);
            dongjak.Add(lbl_흑석역);
            dongjak.Add(lbl_노들역);
            dongjak.Add(lbl_노량진역);
            dongjak.Add(lbl_신대방삼거리역);
            dongjak.Add(lbl_장승배기역);
            dongjak.Add(lbl_상도역);
            dongjak.Add(lbl_숭실대입구역);
            dongjak.Add(lbl_남성역);

            mapo.Add(lbl_아현역);
            mapo.Add(lbl_애오개역);
            mapo.Add(lbl_공덕역);
            mapo.Add(lbl_마포역);
            mapo.Add(lbl_대흥역);
            mapo.Add(lbl_광흥창역);
            mapo.Add(lbl_상수역);
            mapo.Add(lbl_합정역);
            mapo.Add(lbl_망원역);
            mapo.Add(lbl_마포구청역);
            mapo.Add(lbl_월드컵경기장역);
            mapo.Add(lbl_디지털미디어시티역);
            mapo.Add(lbl_홍대입구역);

            seudemun.Add(lbl_충정로역);
            seudemun.Add(lbl_서대문역);
            seudemun.Add(lbl_가좌역);
            seudemun.Add(lbl_무악재역);
            seudemun.Add(lbl_홍제역);

            seucho.Add(lbl_잠원역);
            seucho.Add(lbl_고속터미널역);
            seucho.Add(lbl_사평역);
            seucho.Add(lbl_반포역);
            seucho.Add(lbl_교대역);
            seucho.Add(lbl_남부터미널역);
            seucho.Add(lbl_서초역);
            seucho.Add(lbl_방배역);
            seucho.Add(lbl_내방역);
            seucho.Add(lbl_신반포역);
            seucho.Add(lbl_구반포역);
            seucho.Add(lbl_양재시민의숲역);
            seucho.Add(lbl_청계산입구역);
            seucho.Add(lbl_남태령역);

            sungdong.Add(lbl_성수역);
            sungdong.Add(lbl_뚝섬역);
            sungdong.Add(lbl_서울숲역);
            sungdong.Add(lbl_용답역);
            sungdong.Add(lbl_답십리역);
            sungdong.Add(lbl_신답역);
            sungdong.Add(lbl_마장역);
            sungdong.Add(lbl_한양대역);
            sungdong.Add(lbl_왕십리역);
            sungdong.Add(lbl_행당역);
            sungdong.Add(lbl_신금호역);
            sungdong.Add(lbl_응봉역);
            sungdong.Add(lbl_옥수역);
            sungdong.Add(lbl_상왕십리역);
            sungdong.Add(lbl_금호역);

            sungbuk.Add(lbl_돌곶이역);
            sungbuk.Add(lbl_상월곡역);
            sungbuk.Add(lbl_월곡역);
            sungbuk.Add(lbl_고려대역);
            sungbuk.Add(lbl_안암역);
            sungbuk.Add(lbl_보문역);
            sungbuk.Add(lbl_한성대입구역);
            sungbuk.Add(lbl_성신여대입구역);
            sungbuk.Add(lbl_길음역);
            sungbuk.Add(lbl_정릉역);

            songpa.Add(lbl_종합운동장역);
            songpa.Add(lbl_잠실새내역);
            songpa.Add(lbl_잠실역);
            songpa.Add(lbl_삼전역);
            songpa.Add(lbl_석촌고분역);
            songpa.Add(lbl_석촌역);
            songpa.Add(lbl_송파역);
            songpa.Add(lbl_가락시장역);
            songpa.Add(lbl_문정역);
            songpa.Add(lbl_장지역);
            songpa.Add(lbl_복정역);
            songpa.Add(lbl_잠실나루역);
            songpa.Add(lbl_몽촌토성역);
            songpa.Add(lbl_송파나루역);
            songpa.Add(lbl_한성백제역);
            songpa.Add(lbl_경찰병원역);
            songpa.Add(lbl_마천역);
            songpa.Add(lbl_거여역);
            songpa.Add(lbl_개롱역);
            songpa.Add(lbl_오금역);
            songpa.Add(lbl_방이역);
            songpa.Add(lbl_둔촌오륜역);
            songpa.Add(lbl_강동구청역);

            yangchun.Add(lbl_양천구청역);
            yangchun.Add(lbl_신정네거리역);
            yangchun.Add(lbl_신정역);
            yangchun.Add(lbl_목동역);
            yangchun.Add(lbl_오목교역);
            yangchun.Add(lbl_신목동역);
            yangchun.Add(lbl_염창역);
            yangchun.Add(lbl_등촌역);

            youngdungpo.Add(lbl_대방역);
            youngdungpo.Add(lbl_샛강역);
            youngdungpo.Add(lbl_여의도역);
            youngdungpo.Add(lbl_여의나루역);
            youngdungpo.Add(lbl_국회의사당역);
            youngdungpo.Add(lbl_당산역);
            youngdungpo.Add(lbl_선유도역);
            youngdungpo.Add(lbl_양평역);
            youngdungpo.Add(lbl_영등포구청역);
            youngdungpo.Add(lbl_영등포시장역);
            youngdungpo.Add(lbl_신길역);
            youngdungpo.Add(lbl_영등포역);
            youngdungpo.Add(lbl_문래역);
            youngdungpo.Add(lbl_신풍역);
            youngdungpo.Add(lbl_보라매역);

            yongsan.Add(lbl_숙대입구역);
            yongsan.Add(lbl_남영역);
            yongsan.Add(lbl_효창공원앞역);
            yongsan.Add(lbl_용산역);
            yongsan.Add(lbl_신용산역);
            yongsan.Add(lbl_삼각지역);
            yongsan.Add(lbl_이촌역);
            yongsan.Add(lbl_서빙고역);
            yongsan.Add(lbl_한남역);
            yongsan.Add(lbl_녹사평역);
            yongsan.Add(lbl_이태원역);
            yongsan.Add(lbl_한강진역);

            eunpyung.Add(lbl_수색역);
            eunpyung.Add(lbl_증산역);
            eunpyung.Add(lbl_새절역);
            eunpyung.Add(lbl_응암역);
            eunpyung.Add(lbl_역촌역);
            eunpyung.Add(lbl_불광역);
            eunpyung.Add(lbl_독바위역);
            eunpyung.Add(lbl_연신내역);
            eunpyung.Add(lbl_구산역);
            eunpyung.Add(lbl_구파발역);
            eunpyung.Add(lbl_녹번역);

            jongro.Add(lbl_독립문역);
            jongro.Add(lbl_경복궁역);
            jongro.Add(lbl_안국역);
            jongro.Add(lbl_광화문역);
            jongro.Add(lbl_종각역);
            jongro.Add(lbl_종로3가역);
            jongro.Add(lbl_종로5가역);
            jongro.Add(lbl_동대문역);
            jongro.Add(lbl_동묘앞역);
            jongro.Add(lbl_창신역);
            jongro.Add(lbl_혜화역);

            jung.Add(lbl_신당역);
            jung.Add(lbl_동대문역사문화공원역);
            jung.Add(lbl_을지로4가역);
            jung.Add(lbl_을지로3가역);
            jung.Add(lbl_을지로입구역);
            jung.Add(lbl_시청역);
            jung.Add(lbl_서울역);
            jung.Add(lbl_회현역);
            jung.Add(lbl_명동역);
            jung.Add(lbl_충무로역);
            jung.Add(lbl_버티고개역);
            jung.Add(lbl_약수역);
            jung.Add(lbl_청구역);
            jung.Add(lbl_동대입구역);

            jungrang.Add(lbl_먹골역);
            jungrang.Add(lbl_중화역);
            jungrang.Add(lbl_상봉역);
            jungrang.Add(lbl_중랑역);
            jungrang.Add(lbl_면목역);
            jungrang.Add(lbl_사가정역);
            jungrang.Add(lbl_용마산역);
            jungrang.Add(lbl_망우역);
            jungrang.Add(lbl_양원역);
            jungrang.Add(lbl_신내역);
            jungrang.Add(lbl_봉화산역);
        }

        // input: 바꾸고 싶은 체크리스트 경로 이름
        // output: 체크리스트 갱신
        private void change_chklist_item(string path)
        {
            chk_listbox.Items.Clear();

            foreach (string line in File.ReadLines(path))
            {
                chk_listbox.Items.Add(line);
            }
        }


        // input: 구 이름
        // output: 사진 창에 해당 구 사진 출력
        private void gu_picture_change(string gu_name)
        {
            string gumap_path = Path.GetFullPath(Path.Combine(prj_path, @"gu\"));
            string pic_name = gu_name.ToString() + ".png";
            gumap_path = Path.GetFullPath(Path.Combine(gumap_path, pic_name));

            picbox_map.Image = Image.FromFile(gumap_path);

            if (gu_name == "강남구")
            {
                foreach (System.Windows.Forms.Label name in gangnam)
                {
                    name.BringToFront();
                }
            }
            if (gu_name == "강동구")
            {
                foreach (System.Windows.Forms.Label name in gangdong)
                {
                    name.BringToFront();
                }
            }
            if (gu_name == "강북구")
            {
                foreach (System.Windows.Forms.Label name in gangbouk)
                {
                    name.BringToFront();
                }
            }
            if (gu_name == "강서구")
            {
                foreach (System.Windows.Forms.Label name in gangseu)
                {
                    name.BringToFront();
                }
            }
            if (gu_name == "관악구")
            {
                foreach (System.Windows.Forms.Label name in gwanak)
                {
                    name.BringToFront();
                }
            }
            if (gu_name == "광진구")
            {
                foreach (System.Windows.Forms.Label name in gwangjin)
                {
                    name.BringToFront();
                }
            }
            if (gu_name == "구로구")
            {
                foreach (System.Windows.Forms.Label name in guro)
                {
                    name.BringToFront();
                }
            }
            if (gu_name == "금천구")
            {
                foreach (System.Windows.Forms.Label name in gumchun)
                {
                    name.BringToFront();
                }
            }
            if (gu_name == "노원구")
            {
                foreach (System.Windows.Forms.Label name in nowon)
                {
                    name.BringToFront();
                }
            }
            if (gu_name == "도봉구")
            {
                foreach (System.Windows.Forms.Label name in dobong)
                {
                    name.BringToFront();
                }
            }
            if (gu_name == "동대문구")
            {
                foreach (System.Windows.Forms.Label name in dongdemun)
                {
                    name.BringToFront();
                }
            }
            if (gu_name == "동작구")
            {
                foreach (System.Windows.Forms.Label name in dongjak)
                {
                    name.BringToFront();
                }
            }
            if (gu_name == "마포구")
            {
                foreach (System.Windows.Forms.Label name in mapo)
                {
                    name.BringToFront();
                }
            }
            if (gu_name == "서대문구")
            {
                foreach (System.Windows.Forms.Label name in seudemun)
                {
                    name.BringToFront();
                }
            }
            if (gu_name == "서초구")
            {
                foreach (System.Windows.Forms.Label name in seucho)
                {
                    name.BringToFront();
                }
            }
            if (gu_name == "성동구")
            {
                foreach (System.Windows.Forms.Label name in sungdong)
                {
                    name.BringToFront();
                }
            }
            if (gu_name == "성북구")
            {
                foreach (System.Windows.Forms.Label name in sungbuk)
                {
                    name.BringToFront();
                }
            }
            if (gu_name == "송파구")
            {
                foreach (System.Windows.Forms.Label name in songpa)
                {
                    name.BringToFront();
                }
            }
            if (gu_name == "양천구")
            {
                foreach (System.Windows.Forms.Label name in yangchun)
                {
                    name.BringToFront();
                }
            }
            if (gu_name == "영등포구")
            {
                foreach (System.Windows.Forms.Label name in youngdungpo)
                {
                    name.BringToFront();
                }
            }
            if (gu_name == "용산구")
            {
                foreach (System.Windows.Forms.Label name in yongsan)
                {
                    name.BringToFront();
                }
            }
            if (gu_name == "은평구")
            {
                foreach (System.Windows.Forms.Label name in eunpyung)
                {
                    name.BringToFront();
                }
            }
            if (gu_name == "종로구")
            {
                foreach (System.Windows.Forms.Label name in jongro)
                {
                    name.BringToFront();
                }
            }
            if (gu_name == "중구")
            {
                foreach (System.Windows.Forms.Label name in jung)
                {
                    name.BringToFront();
                }
            }
            if (gu_name == "중랑구")
            {
                foreach (System.Windows.Forms.Label name in jungrang)
                {
                    name.BringToFront();
                }
            }
        }


        private void gu_select(string gu_name)
        {
            string Staname_path = Path.GetFullPath(Path.Combine(prj_path, @"gugu\"));
            string Sta_name = gu_name.ToString() + ".txt";
            string[] textValue = System.IO.File.ReadAllLines(Staname_path + Sta_name);
            if (textValue.Length > 0)
            {
                staa = new StaInfo[textValue.Length];
                for (int i = 0; i < textValue.Length; i++)
                {
                    Find_item(textValue[i]);
                    staa[i] = new StaInfo(textValue[i], i);
                }
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
                lbl_scale.Text = "구";
                change_chklist_item(gu_txt);
                picbox_map.Image = Image.FromFile(seoulmap_path);
            }
            else if (scr_scale.Value == 1)
            {
                lbl_scale.Text = "역";
                change_chklist_item(station_txt);
            }
        }


        private void btn_clear_Click(object sender, EventArgs e)
        {
            if (scr_scale.Value == 0)
            {
                for (int ix = 0; ix < chk_listbox.Items.Count; ++ix)
                    chk_listbox.SetItemChecked(ix, false);
                picbox_map.Image = Image.FromFile(seoulmap_path);
            }

            if (scr_scale.Value == 1) // 역 초기화시키기
            {
                change_chklist_item(station_txt);
                textBox1.Text = "";
            }
        }


        private void chk_listbox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // listbox에서 하나씩만 체크되게 함
            if (scr_scale.Value == 0)
            {
                if (e.NewValue == CheckState.Checked)// 체크 되어있을경우 체크리스트 해제
                    for (int ix = 0; ix < chk_listbox.Items.Count; ++ix)
                        if (e.Index != ix) chk_listbox.SetItemChecked(ix, false);
            }

        }


        private void chk_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scr_scale.Value == 0)
            {

                if (chk_listbox.CheckedItems.Count == 0)
                {
                    picbox_map.Image = Image.FromFile(seoulmap_path);
                    return;
                }
                gu_picture_change(chk_listbox.CheckedItems[0].ToString());
                gu_select(chk_listbox.CheckedItems[0].ToString());
            }
            if (scr_scale.Value == 1)
            {
                int index = chk_listbox.SelectedIndex;
                if (chk_listbox.CheckedItems.Count == 0)
                {
                    picbox_map.Image = Image.FromFile(seoulmap_path);
                    return;
                }
                string item = chk_listbox.SelectedItem.ToString();
                textBox1.Text = item;
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
                if (e.KeyCode == Keys.Back)
                {
                    change_chklist_item(station_txt);
                }
            }
        }


        private void btn_find_Click(object sender, EventArgs e)
        {
            if (lbl_nowTime.Text == "3")
            {
                MessageBox.Show("3시에는 지하철이 다니지 않습니다", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (scr_scale.Value == 1)
            {
                Find_item(textBox1.Text);
            }
        }


        private void Find_item(string item)
        {
            System.Drawing.Point parentPoint = this.Location;
            //int fontSize10 = 10;
            //int fontSize8 = 8;

            int ix = Get_item(item);
            if (ix < 0)
                return;
            chk_listbox.Items.Clear();
            chk_listbox.Items.Add(item);
            chk_listbox.SetItemChecked(0, true);

            Form2 fm = new Form2(lbl_nowTime.Text);
            fm.StartPosition = FormStartPosition.Manual;

            if (item == "가락시장역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 660, parentPoint.Y + 390);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "가산디지털단지역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 380, parentPoint.Y + 420);
                fm.label1.Text = item;
                //fm.label1.Font = new Font(Font.FontFamily, fontSize10);
                //fm.label1.Location = new System.Drawing.Point(0, 45);
                fm.ShowDialog();
            }
            if (item == "강남역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 563, parentPoint.Y + 386);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "강남구청역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 585, parentPoint.Y + 363);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "강동역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 680, parentPoint.Y + 316);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "강동구청역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 669, parentPoint.Y + 337);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "강변역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 635, parentPoint.Y + 336);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "강일역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 718, parentPoint.Y + 298);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "개롱역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 688, parentPoint.Y + 393);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "개화산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 298, parentPoint.Y + 258);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "거여역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 696, parentPoint.Y + 398);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "건대입구역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 610, parentPoint.Y + 329);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "경복궁역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 489, parentPoint.Y + 264);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "경찰병원역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 674, parentPoint.Y + 398);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "고덕역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 701, parentPoint.Y + 298);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "고려대역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 564, parentPoint.Y + 251);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "고속터미널역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 538, parentPoint.Y + 379);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "공덕역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 460, parentPoint.Y + 322);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "광나루역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 649, parentPoint.Y + 310);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "광명사거리역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 349, parentPoint.Y + 423);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "광화문역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 495, parentPoint.Y + 270);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "광흥창역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 443, parentPoint.Y + 315);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "교대역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 546, parentPoint.Y + 391);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "구로디지털단지역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 398, parentPoint.Y + 414);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "구산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 432, parentPoint.Y + 216);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "구의역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 626, parentPoint.Y + 331);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "구파발역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 428, parentPoint.Y + 166);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "군자역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 622, parentPoint.Y + 298);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "굽은다리역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 689, parentPoint.Y + 308);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "금호역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 541, parentPoint.Y + 313);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "길동역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 690, parentPoint.Y + 313);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "길음역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 567, parentPoint.Y + 213);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "김포공항역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 292, parentPoint.Y + 272);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "까치산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 344, parentPoint.Y + 344);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "까치울역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 296, parentPoint.Y + 374);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "낙성대역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 474, parentPoint.Y + 429);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "남구로역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 388, parentPoint.Y + 412);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "남부터미널역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 553, parentPoint.Y + 422);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "남성역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 485, parentPoint.Y + 408);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "남태령역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 506, parentPoint.Y + 443);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "남한산성입구역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 722, parentPoint.Y + 463);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "내방역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 518, parentPoint.Y + 401);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "노원역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 607, parentPoint.Y + 129);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "녹번역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 447, parentPoint.Y + 231);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "녹사평역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 497, parentPoint.Y + 333);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "논현역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 559, parentPoint.Y + 372);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "단대오거리역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 716, parentPoint.Y + 473);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "답십리역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 592, parentPoint.Y + 289);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "당고개역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 633, parentPoint.Y + 107);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "당산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 413, parentPoint.Y + 340);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "대림역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 395, parentPoint.Y + 402);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "대청역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 616, parentPoint.Y + 413);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "대치역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 601, parentPoint.Y + 414);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "대흥역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 454, parentPoint.Y + 317);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "도곡역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 594, parentPoint.Y + 417);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "도림천역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 379, parentPoint.Y + 369);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "도봉산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 589, parentPoint.Y + 83);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "독립문역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 476, parentPoint.Y + 272);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "독바위역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 451, parentPoint.Y + 213);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "돌곶이역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 593, parentPoint.Y + 217);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "동대문역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 532, parentPoint.Y + 273);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "동대문역사문화공원역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 528, parentPoint.Y + 284);
                fm.label1.Text = item;
                //fm.label1.Font = new Font(Font.FontFamily, fontSize8);
                //fm.label1.Location = new System.Drawing.Point(2, 47);
                fm.ShowDialog();
            }
            if (item == "동대입구역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 527, parentPoint.Y + 292);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "동묘앞역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 536, parentPoint.Y + 273);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "동작역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 496, parentPoint.Y + 388);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "둔촌동역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 686, parentPoint.Y + 339);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "디지털미디어시티역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 410, parentPoint.Y + 261);
                fm.label1.Text = item;
                //fm.label1.Font = new Font(Font.FontFamily, fontSize10);
                //fm.label1.Location = new System.Drawing.Point(0, 45);
                fm.ShowDialog();
            }
            if (item == "뚝섬역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 577, parentPoint.Y + 316);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "뚝섬유원지역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 605, parentPoint.Y + 345);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "마곡역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 323, parentPoint.Y + 290);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "마들역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 605, parentPoint.Y + 113);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "마장역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 582, parentPoint.Y + 288);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "마천역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 710, parentPoint.Y + 399);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "마포역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 455, parentPoint.Y + 330);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "마포구청역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 410, parentPoint.Y + 287);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "망원역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 420, parentPoint.Y + 300);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "매봉역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 587, parentPoint.Y + 421);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "먹골역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 620, parentPoint.Y + 211);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "면목역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 628, parentPoint.Y + 243);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "명동역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 508, parentPoint.Y + 293);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "명일역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 689, parentPoint.Y + 302);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "모란역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 684, parentPoint.Y + 486);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "목동역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 366, parentPoint.Y + 348);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "몽촌토성역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 658, parentPoint.Y + 360);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "무악재역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 463, parentPoint.Y + 257);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "문래역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 397, parentPoint.Y + 364);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "문정역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 671, parentPoint.Y + 412);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "미아역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 558, parentPoint.Y + 174);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "미아사거리역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 566, parentPoint.Y + 202);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "반포역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 544, parentPoint.Y + 376);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "발산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 333, parentPoint.Y + 294);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "방배역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 529, parentPoint.Y + 412);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "방이역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 676, parentPoint.Y + 377);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "방화역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 303, parentPoint.Y + 245);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "버티고개역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 531, parentPoint.Y + 309);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "보라매역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 426, parentPoint.Y + 391);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "보문역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 542, parentPoint.Y + 257);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "복정역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 683, parentPoint.Y + 439);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "봉은사역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 603, parentPoint.Y + 364);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "봉천역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 451, parentPoint.Y + 424);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "봉화산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 646, parentPoint.Y + 197);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "부천시청역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 246, parentPoint.Y + 379);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "부천종합운동장역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 281, parentPoint.Y + 376);
                fm.label1.Text = item;
                //fm.label1.Font = new Font(Font.FontFamily, fontSize10);
                //fm.label1.Location = new System.Drawing.Point(0, 45);
                fm.ShowDialog();
            }
            if (item == "불광역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 444, parentPoint.Y + 222);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "사가정역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 629, parentPoint.Y + 255);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "사당역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 501, parentPoint.Y + 429);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "산성역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 714, parentPoint.Y + 457);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "삼각지역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 483, parentPoint.Y + 330);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "삼성역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 603, parentPoint.Y + 373);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "삼성중앙역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 597, parentPoint.Y + 366);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "상계역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 623, parentPoint.Y + 122);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "상도역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 464, parentPoint.Y + 387);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "상봉역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 627, parentPoint.Y + 231);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "상수역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 436, parentPoint.Y + 315);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "상왕십리역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 557, parentPoint.Y + 288);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "상월곡역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 586, parentPoint.Y + 222);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "상일동역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 710, parentPoint.Y + 297);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "새절역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 423, parentPoint.Y + 240);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "서대문역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 482, parentPoint.Y + 279);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "서울대입구역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 463, parentPoint.Y + 426);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "서울역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 486, parentPoint.Y + 305);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "서초역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 538, parentPoint.Y + 393);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "석계역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 607, parentPoint.Y + 208);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "석촌역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 648, parentPoint.Y + 378);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "선릉역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 588, parentPoint.Y + 378);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "선정릉역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 586, parentPoint.Y + 369);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "성수역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 587, parentPoint.Y + 320);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "성신여대입구역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 553, parentPoint.Y + 231);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "송정역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 302, parentPoint.Y + 276);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "송파역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 656, parentPoint.Y + 388);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "수락산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 603, parentPoint.Y + 99);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "수서역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 645, parentPoint.Y + 418);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "수유역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 561, parentPoint.Y + 160);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "수진역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 696, parentPoint.Y + 481);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "숙대입구역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 487, parentPoint.Y + 315);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "숭실대입구역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 471, parentPoint.Y + 398);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "시청역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 494, parentPoint.Y + 285);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신금호역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 552, parentPoint.Y + 305);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신길역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 423, parentPoint.Y + 365);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신내역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 657, parentPoint.Y + 201);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신답역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 583, parentPoint.Y + 281);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신당역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 536, parentPoint.Y + 285);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신대방역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 417, parentPoint.Y + 410);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신대방삼거리역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 436, parentPoint.Y + 392);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신도림역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 391, parentPoint.Y + 384);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신림역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 437, parentPoint.Y + 418);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신사역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 549, parentPoint.Y + 364);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신설동역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 554, parentPoint.Y + 270);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신용산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 478, parentPoint.Y + 340);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신정역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 353, parentPoint.Y + 344);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신정네거리역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 347, parentPoint.Y + 354);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신중동역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 258, parentPoint.Y + 381);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신풍역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 411, parentPoint.Y + 391);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신흥역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 706, parentPoint.Y + 478);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "쌍문역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 569, parentPoint.Y + 144);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "아차산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 634, parentPoint.Y + 305);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "아현역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 469, parentPoint.Y + 294);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "안국역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 512, parentPoint.Y + 261);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "안암역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 552, parentPoint.Y + 258);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "암사역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 674, parentPoint.Y + 302);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "압구정역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 556, parentPoint.Y + 351);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "애오개역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 470, parentPoint.Y + 307);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "약수역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 533, parentPoint.Y + 295);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "양재역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 577, parentPoint.Y + 425);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "양천구청역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 358, parentPoint.Y + 363);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "양평역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 384, parentPoint.Y + 349);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "어린이대공원역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 616, parentPoint.Y + 314);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "언주역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 575, parentPoint.Y + 375);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "여의나루역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 442, parentPoint.Y + 345);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "여의도역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 438, parentPoint.Y + 351);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "역삼역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 576, parentPoint.Y + 381);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "역촌역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 436, parentPoint.Y + 225);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "연신내역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 437, parentPoint.Y + 207);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "영등포구청역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 404, parentPoint.Y + 357);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "영등포시장역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 412, parentPoint.Y + 358);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "오금역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 681, parentPoint.Y + 389);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "오목교역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 375, parentPoint.Y + 347);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "옥수역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 546, parentPoint.Y + 329);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "온수역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 311, parentPoint.Y + 404);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "올림픽공원역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 679, parentPoint.Y + 367);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "왕십리역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 571, parentPoint.Y + 294);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "용답역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 586, parentPoint.Y + 298);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "용두역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 572, parentPoint.Y + 277);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "용마산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 629, parentPoint.Y + 270);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "우장산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 331, parentPoint.Y + 304);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "월곡역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 574, parentPoint.Y + 232);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "월드컵경기장역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 406, parentPoint.Y + 274);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "을지로3가역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 519, parentPoint.Y + 284);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "을지로4가역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 524, parentPoint.Y + 284);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "을지로입구역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 506, parentPoint.Y + 283);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "응암역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 426, parentPoint.Y + 230);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "이대역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 462, parentPoint.Y + 296);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "이수역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 502, parentPoint.Y + 404);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "이촌역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 483, parentPoint.Y + 355);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "이태원역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 512, parentPoint.Y + 331);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "일원역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 629, parentPoint.Y + 431);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "잠실역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 643, parentPoint.Y + 367);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "잠실나루역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 644, parentPoint.Y + 354);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "잠실새내역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 631, parentPoint.Y + 369);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "잠원역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 541, parentPoint.Y + 367);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "장승배기역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 451, parentPoint.Y + 385);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "장암역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 602, parentPoint.Y + 64);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "장지역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 677, parentPoint.Y + 423);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "장한평역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 607, parentPoint.Y + 294);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "제기동역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 576, parentPoint.Y + 264);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "종각역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 502, parentPoint.Y + 273);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "종로3가역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 518, parentPoint.Y + 269);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "종로5가역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 527, parentPoint.Y + 273);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "종합운동장역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 621, parentPoint.Y + 370);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "중계역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 611, parentPoint.Y + 151);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "중곡역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 626, parentPoint.Y + 284);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "중화역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 621, parentPoint.Y + 222);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "증산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 416, parentPoint.Y + 248);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "지축역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 425, parentPoint.Y + 141);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "창동역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 587, parentPoint.Y + 135);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "창신역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 536, parentPoint.Y + 265);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "천왕역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 335, parentPoint.Y + 412);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "천호역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 673, parentPoint.Y + 315);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "철산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 363, parentPoint.Y + 427);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "청구역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 535, parentPoint.Y + 290);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "청담역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 595, parentPoint.Y + 359);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "청량리역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 591, parentPoint.Y + 253);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "총신대입구역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 502, parentPoint.Y + 401);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "춘의역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 268, parentPoint.Y + 381);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "충무로역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 520, parentPoint.Y + 289);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "충정로역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 475, parentPoint.Y + 290);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "태릉입구역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 619, parentPoint.Y + 204);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "하계역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 614, parentPoint.Y + 168);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "학동역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 571, parentPoint.Y + 366);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "학여울역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 607, parentPoint.Y + 410);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "한강진역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 526, parentPoint.Y + 320);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "한성대입구역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 530, parentPoint.Y + 242);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "한양대역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 576, parentPoint.Y + 303);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "합정역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 427, parentPoint.Y + 313);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "행당역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 562, parentPoint.Y + 300);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "혜화역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 522, parentPoint.Y + 251);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "홍대입구역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 444, parentPoint.Y + 294);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "홍제역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 451, parentPoint.Y + 243);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "화곡역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 335, parentPoint.Y + 320);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "화랑대역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 630, parentPoint.Y + 199);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "회현역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 496, parentPoint.Y + 296);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "효창공원앞역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + 472, parentPoint.Y + 328);
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


        // input: 역의 이름 string
        // output: 현재 체크된 구에 input 역이 있다면, gumap_click 함수 호출
        private void station_lbl_click(string item)
        {
            string path = Path.GetFullPath(Path.Combine(prj_path, @"gugu\"));
            if ((chk_listbox.CheckedItems.Count != 0) && (scr_scale.Value == 0))
            {
                path = Path.GetFullPath(Path.Combine(path, chk_listbox.CheckedItems[0].ToString() + ".txt"));
                foreach (string line in File.ReadLines(path))
                {
                    if (item == line)
                    {
                        gumap_click(item);
                        return;
                    }
                }
            }
        }


        // input: 역의 이름 string
        // output: 표시된 구 지도 위에 Form2 출력
        private void gumap_click(string item)
        {
            System.Drawing.Point parentPoint = this.Location;
            parentPoint.X = parentPoint.X + 250;
            parentPoint.Y = parentPoint.Y + 60;

            Form2 fm = new Form2(lbl_nowTime.Text);
            fm.StartPosition = FormStartPosition.Manual;

            if (item == "가락시장역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_가락시장역.Location.X, parentPoint.Y + lbl_가락시장역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "가산디지털단지역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_가산디지털단지역.Location.X, parentPoint.Y + lbl_가산디지털단지역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "가양역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + picbox_map.Location.X, parentPoint.Y + picbox_map.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "가좌역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_가좌역.Location.X, parentPoint.Y + lbl_가좌역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "강남구청역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_강남구청역.Location.X, parentPoint.Y + lbl_강남구청역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "강남역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_강남역.Location.X, parentPoint.Y + lbl_강남역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "강동구청역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_강동구청역.Location.X, parentPoint.Y + lbl_강동구청역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "강동역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_강동역.Location.X, parentPoint.Y + lbl_강동역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "강변역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_강변역.Location.X, parentPoint.Y + lbl_강변역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "개롱역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_개롱역.Location.X, parentPoint.Y + lbl_개롱역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "개봉역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_개봉역.Location.X, parentPoint.Y + lbl_개봉역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "개포동역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_개포동역.Location.X, parentPoint.Y + lbl_개포동역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "개화산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_개화산역.Location.X, parentPoint.Y + lbl_개화산역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "개화역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_개화역.Location.X, parentPoint.Y + lbl_개화역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "거여역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_거여역.Location.X, parentPoint.Y + lbl_거여역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "건대입구역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_건대입구역.Location.X, parentPoint.Y + lbl_건대입구역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "경복궁역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_경복궁역.Location.X, parentPoint.Y + lbl_경복궁역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "경찰병원역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_경찰병원역.Location.X, parentPoint.Y + lbl_경찰병원역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "고려대역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_고려대역.Location.X, parentPoint.Y + lbl_고려대역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "고속터미널역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_고속터미널역.Location.X, parentPoint.Y + lbl_고속터미널역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "공덕역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_공덕역.Location.X, parentPoint.Y + lbl_공덕역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "공릉역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_공릉역.Location.X, parentPoint.Y + lbl_공릉역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "광나루역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_광나루역.Location.X, parentPoint.Y + lbl_광나루역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "광명사거리역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_광명사거리역.Location.X, parentPoint.Y + lbl_광명사거리역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "광운대역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_광운대역.Location.X, parentPoint.Y + lbl_광운대역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "광화문역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_광화문역.Location.X, parentPoint.Y + lbl_광화문역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "광흥창역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_광흥창역.Location.X, parentPoint.Y + lbl_광흥창역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "교대역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_교대역.Location.X, parentPoint.Y + lbl_교대역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "구로디지털단지역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_구로디지털단지역.Location.X, parentPoint.Y + lbl_구로디지털단지역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "구로역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_구로역.Location.X, parentPoint.Y + lbl_구로역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "구룡역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_구룡역.Location.X, parentPoint.Y + lbl_구룡역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "구반포역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_구반포역.Location.X, parentPoint.Y + lbl_구반포역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "구산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_구산역.Location.X, parentPoint.Y + lbl_구산역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "구의역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_구의역.Location.X, parentPoint.Y + lbl_구의역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "구일역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_구일역.Location.X, parentPoint.Y + lbl_구일역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "구파발역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_구파발역.Location.X, parentPoint.Y + lbl_구파발역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "국회의사당역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_국회의사당역.Location.X, parentPoint.Y + lbl_국회의사당역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "군자역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_군자역.Location.X, parentPoint.Y + lbl_군자역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "굽은다리역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_굽은다리역.Location.X, parentPoint.Y + lbl_굽은다리역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "금천구청역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_금천구청역.Location.X, parentPoint.Y + lbl_금천구청역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "길동역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_길동역.Location.X, parentPoint.Y + lbl_길동역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "길음역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_길음역.Location.X, parentPoint.Y + lbl_길음역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "김포공항역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_김포공항역.Location.X, parentPoint.Y + lbl_김포공항역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "까치산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_까치산역.Location.X, parentPoint.Y + lbl_까치산역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "낙성대역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_낙성대역.Location.X, parentPoint.Y + lbl_낙성대역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "남구로역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_남구로역.Location.X, parentPoint.Y + lbl_남구로역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "남부터미널역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_남부터미널역.Location.X, parentPoint.Y + lbl_남부터미널역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "남성역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_남성역.Location.X, parentPoint.Y + lbl_남성역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "남영역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_남영역.Location.X, parentPoint.Y + lbl_남영역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "남태령역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_남태령역.Location.X, parentPoint.Y + lbl_남태령역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "내방역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_내방역.Location.X, parentPoint.Y + lbl_내방역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "노들역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_노들역.Location.X, parentPoint.Y + lbl_노들역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "노량진역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_노량진역.Location.X, parentPoint.Y + lbl_노량진역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "노원역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_노원역.Location.X, parentPoint.Y + lbl_노원역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "녹번역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_녹번역.Location.X, parentPoint.Y + lbl_녹번역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "녹사평역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_녹사평역.Location.X, parentPoint.Y + lbl_녹사평역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "녹천역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_녹천역.Location.X, parentPoint.Y + lbl_녹천역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "논현역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_논현역.Location.X, parentPoint.Y + lbl_논현역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "답십리역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_답십리역.Location.X, parentPoint.Y + lbl_답십리역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "당고개역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_당고개역.Location.X, parentPoint.Y + lbl_당고개역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "당산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_당산역.Location.X, parentPoint.Y + lbl_당산역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "대림역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_대림역.Location.X, parentPoint.Y + lbl_대림역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "대모산입구역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_대모산입구역.Location.X, parentPoint.Y + lbl_대모산입구역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "대방역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_대방역.Location.X, parentPoint.Y + lbl_대방역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "대청역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_대청역.Location.X, parentPoint.Y + lbl_대청역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "대치역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_대치역.Location.X, parentPoint.Y + lbl_대치역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "대흥역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_대흥역.Location.X, parentPoint.Y + lbl_대흥역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "도림천역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_도림천역.Location.X, parentPoint.Y + lbl_도림천역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "도봉산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_도봉산역.Location.X, parentPoint.Y + lbl_도봉산역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "도봉역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_도봉역.Location.X, parentPoint.Y + lbl_도봉역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "독립문역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_독립문역.Location.X, parentPoint.Y + lbl_독립문역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "독바위역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_독바위역.Location.X, parentPoint.Y + lbl_독바위역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "독산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_독산역.Location.X, parentPoint.Y + lbl_독산역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "돌곶이역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_돌곶이역.Location.X, parentPoint.Y + lbl_돌곶이역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "동대문역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_동대문역.Location.X, parentPoint.Y + lbl_동대문역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "동대문역사문화공원역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_동대문역사문화공원역.Location.X, parentPoint.Y + lbl_동대문역사문화공원역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "동대입구역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_동대입구역.Location.X, parentPoint.Y + lbl_동대입구역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "동묘앞역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_동묘앞역.Location.X, parentPoint.Y + lbl_동묘앞역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "동작역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_동작역.Location.X, parentPoint.Y + lbl_동작역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "둔촌동역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_둔촌동역.Location.X, parentPoint.Y + lbl_둔촌동역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "둔촌오륜역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_둔촌오륜역.Location.X, parentPoint.Y + lbl_둔촌오륜역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "등촌역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_등촌역.Location.X, parentPoint.Y + lbl_등촌역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "디지털미디어시티역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_디지털미디어시티역.Location.X, parentPoint.Y + lbl_디지털미디어시티역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "뚝섬역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_뚝섬역.Location.X, parentPoint.Y + lbl_뚝섬역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "뚝섬유원지역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_뚝섬유원지역.Location.X, parentPoint.Y + lbl_뚝섬유원지역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "마곡나루역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_마곡나루역.Location.X, parentPoint.Y + lbl_마곡나루역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "마곡역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_마곡역.Location.X, parentPoint.Y + lbl_마곡역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "마들역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_마들역.Location.X, parentPoint.Y + lbl_마들역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "마장역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_마장역.Location.X, parentPoint.Y + lbl_마장역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "마천역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_마천역.Location.X, parentPoint.Y + lbl_마천역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "마포구청역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_마포구청역.Location.X, parentPoint.Y + lbl_마포구청역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "마포역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_마포역.Location.X, parentPoint.Y + lbl_마포역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "망우역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_망우역.Location.X, parentPoint.Y + lbl_망우역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "망원역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_망원역.Location.X, parentPoint.Y + lbl_망원역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "매봉역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_매봉역.Location.X, parentPoint.Y + lbl_매봉역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "먹골역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_먹골역.Location.X, parentPoint.Y + lbl_먹골역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "면목역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_면목역.Location.X, parentPoint.Y + lbl_면목역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "명동역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_명동역.Location.X, parentPoint.Y + lbl_명동역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "목동역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_목동역.Location.X, parentPoint.Y + lbl_목동역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "몽촌토성역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_몽촌토성역.Location.X, parentPoint.Y + lbl_몽촌토성역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "무악재역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_홍제역.Location.X, parentPoint.Y + lbl_홍제역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "문래역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_문래역.Location.X, parentPoint.Y + lbl_문래역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "문정역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_문정역.Location.X, parentPoint.Y + lbl_문정역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "미아사거리역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_미아사거리역.Location.X, parentPoint.Y + lbl_미아사거리역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "미아역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_미아역.Location.X, parentPoint.Y + lbl_미아역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "반포역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_반포역.Location.X, parentPoint.Y + lbl_반포역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "발산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_발산역.Location.X, parentPoint.Y + lbl_발산역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "방배역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_방배역.Location.X, parentPoint.Y + lbl_방배역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "방이역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_방이역.Location.X, parentPoint.Y + lbl_방이역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "방학역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_방학역.Location.X, parentPoint.Y + lbl_방학역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "버티고개역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_버티고개역.Location.X, parentPoint.Y + lbl_버티고개역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "보라매역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_보라매역.Location.X, parentPoint.Y + lbl_보라매역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "보문역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_보문역.Location.X, parentPoint.Y + lbl_보문역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "복정역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_복정역.Location.X, parentPoint.Y + lbl_복정역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "봉은사역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_봉은사역.Location.X, parentPoint.Y + lbl_봉은사역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "봉천역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_봉천역.Location.X, parentPoint.Y + lbl_봉천역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "봉화산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_봉화산역.Location.X, parentPoint.Y + lbl_봉화산역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "불광역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_불광역.Location.X, parentPoint.Y + lbl_불광역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "사가정역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_사가정역.Location.X, parentPoint.Y + lbl_사가정역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "사당역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_사당역.Location.X, parentPoint.Y + lbl_사당역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "사평역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_사평역.Location.X, parentPoint.Y + lbl_사평역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "삼각지역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_삼각지역.Location.X, parentPoint.Y + lbl_삼각지역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "삼성중앙역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_삼성중앙역.Location.X, parentPoint.Y + lbl_삼성중앙역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "삼전역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_삼전역.Location.X, parentPoint.Y + lbl_삼전역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "상계역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_상계역.Location.X, parentPoint.Y + lbl_상계역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "상도역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_상도역.Location.X, parentPoint.Y + lbl_상도역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "상봉역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_상봉역.Location.X, parentPoint.Y + lbl_상봉역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "상왕십리역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_상왕십리역.Location.X, parentPoint.Y + lbl_상왕십리역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "상월곡역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_상월곡역.Location.X, parentPoint.Y + lbl_상월곡역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "상일동역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_상일동역.Location.X, parentPoint.Y + lbl_상일동역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "새절역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_새절역.Location.X, parentPoint.Y + lbl_새절역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "샛강역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_샛강역.Location.X, parentPoint.Y + lbl_샛강역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "서대문역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_서대문역.Location.X, parentPoint.Y + lbl_서대문역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "서빙고역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_서빙고역.Location.X, parentPoint.Y + lbl_서빙고역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "서울대입구역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_서울대입구역.Location.X, parentPoint.Y + lbl_서울대입구역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "서울숲역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_서울숲역.Location.X, parentPoint.Y + lbl_서울숲역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "서울역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_서울역.Location.X, parentPoint.Y + lbl_서울역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "서초역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_서초역.Location.X, parentPoint.Y + lbl_서초역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "석계역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_석계역.Location.X, parentPoint.Y + lbl_석계역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "석수역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_석수역.Location.X, parentPoint.Y + lbl_석수역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "석촌고분역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_석촌고분역.Location.X, parentPoint.Y + lbl_석촌고분역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "석촌역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_석촌역.Location.X, parentPoint.Y + lbl_석촌역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "선릉역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_선릉역.Location.X, parentPoint.Y + lbl_선릉역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "선유도역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_선유도역.Location.X, parentPoint.Y + lbl_선유도역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "선정릉역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_선정릉역.Location.X, parentPoint.Y + lbl_선정릉역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "성수역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_성수역.Location.X, parentPoint.Y + lbl_성수역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "성신여대입구역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_성신여대입구역.Location.X, parentPoint.Y + lbl_성신여대입구역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "송정역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_송정역.Location.X, parentPoint.Y + lbl_송정역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "송파나루역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_송파나루역.Location.X, parentPoint.Y + lbl_송파나루역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "송파역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_송파역.Location.X, parentPoint.Y + lbl_송파역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "수락산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_수락산역.Location.X, parentPoint.Y + lbl_수락산역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "수색역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_수색역.Location.X, parentPoint.Y + lbl_수색역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "수서역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_수서역.Location.X, parentPoint.Y + lbl_수서역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "수유역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_수유역.Location.X, parentPoint.Y + lbl_수유역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "숙대입구역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_숙대입구역.Location.X, parentPoint.Y + lbl_숙대입구역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "숭실대입구역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_숭실대입구역.Location.X, parentPoint.Y + lbl_숭실대입구역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "시청역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_시청역.Location.X, parentPoint.Y + lbl_시청역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신금호역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_신금호역.Location.X, parentPoint.Y + lbl_신금호역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신길역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_신길역.Location.X, parentPoint.Y + lbl_신길역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신내역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_신내역.Location.X, parentPoint.Y + lbl_신내역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신논현역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_신논현역.Location.X, parentPoint.Y + lbl_신논현역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신답역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_신답역.Location.X, parentPoint.Y + lbl_신답역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신당역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_신당역.Location.X, parentPoint.Y + lbl_신당역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신대방삼거리역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_신대방삼거리역.Location.X, parentPoint.Y + lbl_신대방삼거리역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신대방역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_신대방역.Location.X, parentPoint.Y + lbl_신대방역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신도림역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_신도림역.Location.X, parentPoint.Y + lbl_신도림역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신림역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_신림역.Location.X, parentPoint.Y + lbl_신림역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신목동역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_신목동역.Location.X, parentPoint.Y + lbl_신목동역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신반포역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_신반포역.Location.X, parentPoint.Y + lbl_신반포역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신방화역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_신방화역.Location.X, parentPoint.Y + lbl_신방화역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신사역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_신사역.Location.X, parentPoint.Y + lbl_신사역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신설동역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_신설동역.Location.X, parentPoint.Y + lbl_신설동역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신용산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_신용산역.Location.X, parentPoint.Y + lbl_신용산역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신이문역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_신이문역.Location.X, parentPoint.Y + lbl_신이문역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신정네거리역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_신정네거리역.Location.X, parentPoint.Y + lbl_신정네거리역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신정역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_신정역.Location.X, parentPoint.Y + lbl_신정역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "신촌역1")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_신촌역1.Location.X, parentPoint.Y + lbl_신촌역1.Location.Y);
                fm.label1.Text = "신촌역";
                fm.ShowDialog();
            }
            if (item == "신촌역2")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_신촌역2.Location.X, parentPoint.Y + lbl_신촌역2.Location.Y);
                fm.label1.Text = "신촌역";
                fm.ShowDialog();
            }
            if (item == "신풍역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_신풍역.Location.X, parentPoint.Y + lbl_신풍역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "쌍문역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_쌍문역.Location.X, parentPoint.Y + lbl_쌍문역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "아차산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_아차산역.Location.X, parentPoint.Y + lbl_아차산역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "아현역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_아현역.Location.X, parentPoint.Y + lbl_아현역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "안국역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_안국역.Location.X, parentPoint.Y + lbl_안국역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "안암역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_안암역.Location.X, parentPoint.Y + lbl_안암역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "암사역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_암사역.Location.X, parentPoint.Y + lbl_암사역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "압구정로데오역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_압구정로데오역.Location.X, parentPoint.Y + lbl_압구정로데오역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "압구정역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_압구정역.Location.X, parentPoint.Y + lbl_압구정역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "애오개역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_애오개역.Location.X, parentPoint.Y + lbl_애오개역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "약수역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_약수역.Location.X, parentPoint.Y + lbl_약수역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "양원역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_양원역.Location.X, parentPoint.Y + lbl_양원역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "양재시민의숲역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_양재시민의숲역.Location.X, parentPoint.Y + lbl_양재시민의숲역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "양재역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_양재역.Location.X, parentPoint.Y + lbl_양재역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "양천구청역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_양천구청역.Location.X, parentPoint.Y + lbl_양천구청역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "양천향교역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_양천향교역.Location.X, parentPoint.Y + lbl_양천향교역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "양평역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_양평역.Location.X, parentPoint.Y + lbl_양평역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "어린이대공원역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_어린이대공원역.Location.X, parentPoint.Y + lbl_어린이대공원역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "언주역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_언주역.Location.X, parentPoint.Y + lbl_언주역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "여의나루역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_여의나루역.Location.X, parentPoint.Y + lbl_여의나루역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "여의도역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_여의도역.Location.X, parentPoint.Y + lbl_여의도역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "역삼역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_역삼역.Location.X, parentPoint.Y + lbl_역삼역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "역촌역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_역촌역.Location.X, parentPoint.Y + lbl_역촌역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "연신내역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_연신내역.Location.X, parentPoint.Y + lbl_연신내역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "염창역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_염창역.Location.X, parentPoint.Y + lbl_염창역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "영등포구청역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_영등포구청역.Location.X, parentPoint.Y + lbl_영등포구청역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "영등포시장역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_영등포시장역.Location.X, parentPoint.Y + lbl_영등포시장역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "영등포역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_영등포역.Location.X, parentPoint.Y + lbl_영등포역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "오금역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_오금역.Location.X, parentPoint.Y + lbl_오금역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "오류동역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_오류동역.Location.X, parentPoint.Y + lbl_오류동역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "오목교역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_오목교역.Location.X, parentPoint.Y + lbl_오목교역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "옥수역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_옥수역.Location.X, parentPoint.Y + lbl_옥수역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "온수역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_온수역.Location.X, parentPoint.Y + lbl_온수역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "올림픽공원역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_올림픽공원역.Location.X, parentPoint.Y + lbl_올림픽공원역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "왕십리역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_왕십리역.Location.X, parentPoint.Y + lbl_왕십리역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "외대앞역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_외대앞역.Location.X, parentPoint.Y + lbl_외대앞역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "용답역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_용답역.Location.X, parentPoint.Y + lbl_용답역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "용두역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_용두역.Location.X, parentPoint.Y + lbl_용두역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "용마산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_용마산역.Location.X, parentPoint.Y + lbl_용마산역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "용산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_용산역.Location.X, parentPoint.Y + lbl_용산역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "우장산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_우장산역.Location.X, parentPoint.Y + lbl_우장산역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "월계역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_월계역.Location.X, parentPoint.Y + lbl_월계역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "월곡역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_월곡역.Location.X, parentPoint.Y + lbl_월곡역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "월드컵경기장역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_월드컵경기장역.Location.X, parentPoint.Y + lbl_월드컵경기장역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "을지로3가역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_을지로3가역.Location.X, parentPoint.Y + lbl_을지로3가역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "을지로4가역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_을지로4가역.Location.X, parentPoint.Y + lbl_을지로4가역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "을지로입구역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_을지로입구역.Location.X, parentPoint.Y + lbl_을지로입구역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "응봉역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_응봉역.Location.X, parentPoint.Y + lbl_응봉역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "응암역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_응암역.Location.X, parentPoint.Y + lbl_응암역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "이대역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_이대역.Location.X, parentPoint.Y + lbl_이대역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "이수역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_이수역.Location.X, parentPoint.Y + lbl_이수역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "이촌역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_이촌역.Location.X, parentPoint.Y + lbl_이촌역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "이태원역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_이태원역.Location.X, parentPoint.Y + lbl_이태원역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "일원역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_일원역.Location.X, parentPoint.Y + lbl_일원역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "잠실나루역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_잠실나루역.Location.X, parentPoint.Y + lbl_잠실나루역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "잠실새내역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_잠실새내역.Location.X, parentPoint.Y + lbl_잠실새내역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "잠실역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_잠실역.Location.X, parentPoint.Y + lbl_잠실역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "잠원역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_잠원역.Location.X, parentPoint.Y + lbl_잠원역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "장승배기역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_장승배기역.Location.X, parentPoint.Y + lbl_장승배기역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "장지역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_장지역.Location.X, parentPoint.Y + lbl_장지역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "장한평역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_장한평역.Location.X, parentPoint.Y + lbl_장한평역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "정릉역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_정릉역.Location.X, parentPoint.Y + lbl_정릉역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "제기동역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_제기동역.Location.X, parentPoint.Y + lbl_제기동역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "종각역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_종각역.Location.X, parentPoint.Y + lbl_종각역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "종로3가역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_종로3가역.Location.X, parentPoint.Y + lbl_종로3가역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "종로5가역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_종로5가역.Location.X, parentPoint.Y + lbl_종로5가역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "종합운동장역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_종합운동장역.Location.X, parentPoint.Y + lbl_종합운동장역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "중계역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_중계역.Location.X, parentPoint.Y + lbl_중계역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "중곡역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_중곡역.Location.X, parentPoint.Y + lbl_중곡역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "중랑역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_중랑역.Location.X, parentPoint.Y + lbl_중랑역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "중화역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_중화역.Location.X, parentPoint.Y + lbl_중화역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "증미역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_증미역.Location.X, parentPoint.Y + lbl_증미역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "증산역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_증산역.Location.X, parentPoint.Y + lbl_증산역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "창동역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_창동역.Location.X, parentPoint.Y + lbl_창동역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "창신역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_창신역.Location.X, parentPoint.Y + lbl_창신역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "천왕역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_천왕역.Location.X, parentPoint.Y + lbl_천왕역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "천호역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_천호역.Location.X, parentPoint.Y + lbl_천호역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "청계산입구역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_청계산입구역.Location.X, parentPoint.Y + lbl_청계산입구역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "청구역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_청구역.Location.X, parentPoint.Y + lbl_청구역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "청담역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_청담역.Location.X, parentPoint.Y + lbl_청담역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "청량리역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_청량리역.Location.X, parentPoint.Y + lbl_청량리역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "총신대입구역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_총신대입구역.Location.X, parentPoint.Y + lbl_총신대입구역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "충무로역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_충무로역.Location.X, parentPoint.Y + lbl_충무로역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "충정로역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_충정로역.Location.X, parentPoint.Y + lbl_충정로역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "태릉입구역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_태릉입구역.Location.X, parentPoint.Y + lbl_태릉입구역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "하계역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_하계역.Location.X, parentPoint.Y + lbl_하계역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "학동역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_학동역.Location.X, parentPoint.Y + lbl_학동역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "학여울역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_학여울역.Location.X, parentPoint.Y + lbl_학여울역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "한강진역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_한강진역.Location.X, parentPoint.Y + lbl_한강진역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "한남역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_한남역.Location.X, parentPoint.Y + lbl_한남역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "한성대입구역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_한성대입구역.Location.X, parentPoint.Y + lbl_한성대입구역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "한성백제역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_한성백제역.Location.X, parentPoint.Y + lbl_한성백제역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "한양대역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_한양대역.Location.X, parentPoint.Y + lbl_한양대역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "한티역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_한티역.Location.X, parentPoint.Y + lbl_한티역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "합정역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_합정역.Location.X, parentPoint.Y + lbl_합정역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "행당역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_행당역.Location.X, parentPoint.Y + lbl_행당역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "혜화역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_혜화역.Location.X, parentPoint.Y + lbl_혜화역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "홍대입구역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_홍대입구역.Location.X, parentPoint.Y + lbl_홍대입구역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "홍제역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_홍제역.Location.X, parentPoint.Y + lbl_홍제역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "화곡역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_화곡역.Location.X, parentPoint.Y + lbl_화곡역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "화랑대역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_화랑대역.Location.X, parentPoint.Y + lbl_화랑대역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "회기역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_회기역.Location.X, parentPoint.Y + lbl_회기역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "회현역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_회현역.Location.X, parentPoint.Y + lbl_회현역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "효창공원앞역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_효창공원앞역.Location.X, parentPoint.Y + lbl_효창공원앞역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "흑석역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_흑석역.Location.X, parentPoint.Y + lbl_흑석역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "강일역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_강일역.Location.X, parentPoint.Y + lbl_강일역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "고덕역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_고덕역.Location.X, parentPoint.Y + lbl_고덕역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
            if (item == "금호역")
            {
                fm.Location = new System.Drawing.Point(parentPoint.X + lbl_금호역.Location.X, parentPoint.Y + lbl_금호역.Location.Y);
                fm.label1.Text = item;
                fm.ShowDialog();
            }
        }


        private void lbl_가락시장역_Click(object sender, EventArgs e)
        {
            station_lbl_click("가락시장역");
        }
        private void lbl_가산디지털단지역_Click(object sender, EventArgs e)
        {
            station_lbl_click("가산디지털단지역");
        }
        private void lbl_가양역_Click(object sender, EventArgs e)
        {
            station_lbl_click("가양역");
        }
        private void lbl_가오리역_Click(object sender, EventArgs e)
        {
            station_lbl_click("가오리역");
        }
        private void lbl_가좌역_Click(object sender, EventArgs e)
        {
            station_lbl_click("가좌역");
        }
        private void lbl_강남구청역_Click(object sender, EventArgs e)
        {
            station_lbl_click("강남구청역");
        }
        private void lbl_강남역_Click(object sender, EventArgs e)
        {
            station_lbl_click("강남역");
        }
        private void lbl_강동구청역_Click(object sender, EventArgs e)
        {
            station_lbl_click("강동구청역");
        }
        private void lbl_강동역_Click(object sender, EventArgs e)
        {
            station_lbl_click("강동역");
        }
        private void lbl_강변역_Click(object sender, EventArgs e)
        {
            station_lbl_click("강변역");
        }
        private void lbl_개롱역_Click(object sender, EventArgs e)
        {
            station_lbl_click("개롱역");
        }
        private void lbl_개봉역_Click(object sender, EventArgs e)
        {
            station_lbl_click("개봉역");
        }
        private void lbl_개포동역_Click(object sender, EventArgs e)
        {
            station_lbl_click("개포동역");
        }
        private void lbl_개화산역_Click(object sender, EventArgs e)
        {
            station_lbl_click("개화산역");
        }
        private void lbl_개화역_Click(object sender, EventArgs e)
        {
            station_lbl_click("개화역");
        }
        private void lbl_거여역_Click(object sender, EventArgs e)
        {
            station_lbl_click("거여역");
        }
        private void lbl_건대입구역_Click(object sender, EventArgs e)
        {
            station_lbl_click("건대입구역");
        }
        private void lbl_경복궁역_Click(object sender, EventArgs e)
        {
            station_lbl_click("경복궁역");
        }
        private void lbl_경찰병원역_Click(object sender, EventArgs e)
        {
            station_lbl_click("경찰병원역");
        }
        private void lbl_고려대역_Click(object sender, EventArgs e)
        {
            station_lbl_click("고려대역");
        }
        private void lbl_고속터미널역_Click(object sender, EventArgs e)
        {
            station_lbl_click("고속터미널역");
        }
        private void lbl_공덕역_Click(object sender, EventArgs e)
        {
            station_lbl_click("공덕역");
        }
        private void lbl_공릉역_Click(object sender, EventArgs e)
        {
            station_lbl_click("공릉역");
        }
        private void lbl_광나루역_Click(object sender, EventArgs e)
        {
            station_lbl_click("광나루역");
        }
        private void lbl_광명사거리역_Click(object sender, EventArgs e)
        {
            station_lbl_click("광명사거리역");
        }
        private void lbl_광운대역_Click(object sender, EventArgs e)
        {
            station_lbl_click("광운대역");
        }
        private void lbl_광화문역_Click(object sender, EventArgs e)
        {
            station_lbl_click("광화문역");
        }
        private void lbl_광흥창역_Click(object sender, EventArgs e)
        {
            station_lbl_click("광흥창역");
        }
        private void lbl_교대역_Click(object sender, EventArgs e)
        {
            station_lbl_click("교대역");
        }
        private void lbl_구로디지털단지역_Click(object sender, EventArgs e)
        {
            station_lbl_click("구로디지털단지역");
        }
        private void lbl_구로역_Click(object sender, EventArgs e)
        {
            station_lbl_click("구로역");
        }
        private void lbl_구룡역_Click(object sender, EventArgs e)
        {
            station_lbl_click("구룡역");
        }
        private void lbl_구반포역_Click(object sender, EventArgs e)
        {
            station_lbl_click("구반포역");
        }
        private void lbl_구산역_Click(object sender, EventArgs e)
        {
            station_lbl_click("구산역");
        }
        private void lbl_구의역_Click(object sender, EventArgs e)
        {
            station_lbl_click("구의역");
        }
        private void lbl_구일역_Click(object sender, EventArgs e)
        {
            station_lbl_click("구일역");
        }
        private void lbl_구파발역_Click(object sender, EventArgs e)
        {
            station_lbl_click("구파발역");
        }
        private void lbl_국회의사당역_Click(object sender, EventArgs e)
        {
            station_lbl_click("국회의사당역");
        }
        private void lbl_군자역_Click(object sender, EventArgs e)
        {
            station_lbl_click("군자역");
        }
        private void lbl_굽은다리역_Click(object sender, EventArgs e)
        {
            station_lbl_click("굽은다리역");
        }
        private void lbl_금천구청역_Click(object sender, EventArgs e)
        {
            station_lbl_click("금천구청역");
        }
        private void lbl_길동역_Click(object sender, EventArgs e)
        {
            station_lbl_click("길동역");
        }
        private void lbl_길음역_Click(object sender, EventArgs e)
        {
            station_lbl_click("길음역");
        }
        private void lbl_김포공항역_Click(object sender, EventArgs e)
        {
            station_lbl_click("김포공항역");
        }
        private void lbl_까치산역_Click(object sender, EventArgs e)
        {
            station_lbl_click("까치산역");
        }
        private void lbl_낙성대역_Click(object sender, EventArgs e)
        {
            station_lbl_click("낙성대역");
        }
        private void lbl_남구로역_Click(object sender, EventArgs e)
        {
            station_lbl_click("남구로역");
        }
        private void lbl_남부터미널역_Click(object sender, EventArgs e)
        {
            station_lbl_click("남부터미널역");
        }
        private void lbl_남성역_Click(object sender, EventArgs e)
        {
            station_lbl_click("남성역");
        }
        private void lbl_남영역_Click(object sender, EventArgs e)
        {
            station_lbl_click("남영역");
        }
        private void lbl_남태령역_Click(object sender, EventArgs e)
        {
            station_lbl_click("남태령역");
        }
        private void lbl_내방역_Click(object sender, EventArgs e)
        {
            station_lbl_click("내방역");
        }
        private void lbl_노들역_Click(object sender, EventArgs e)
        {
            station_lbl_click("노들역");
        }
        private void lbl_노량진역_Click(object sender, EventArgs e)
        {
            station_lbl_click("노량진역");
        }
        private void lbl_노원역_Click(object sender, EventArgs e)
        {
            station_lbl_click("노원역");
        }
        private void lbl_녹번역_Click(object sender, EventArgs e)
        {
            station_lbl_click("녹번역");
        }
        private void lbl_녹사평역_Click(object sender, EventArgs e)
        {
            station_lbl_click("녹사평역");
        }
        private void lbl_녹천역_Click(object sender, EventArgs e)
        {
            station_lbl_click("녹천역");
        }
        private void lbl_논현역_Click(object sender, EventArgs e)
        {
            station_lbl_click("논현역");
        }
        private void lbl_답십리역_Click(object sender, EventArgs e)
        {
            station_lbl_click("답십리역");
        }
        private void lbl_당고개역_Click(object sender, EventArgs e)
        {
            station_lbl_click("당고개역");
        }
        private void lbl_당산역_Click(object sender, EventArgs e)
        {
            station_lbl_click("당산역");
        }
        private void lbl_대림역_Click(object sender, EventArgs e)
        {
            station_lbl_click("대림역");
        }
        private void lbl_대모산입구역_Click(object sender, EventArgs e)
        {
            station_lbl_click("대모산입구역");
        }
        private void lbl_대방역_Click(object sender, EventArgs e)
        {
            station_lbl_click("대방역");
        }
        private void lbl_대청역_Click(object sender, EventArgs e)
        {
            station_lbl_click("대청역");
        }
        private void lbl_대치역_Click(object sender, EventArgs e)
        {
            station_lbl_click("대치역");
        }
        private void lbl_대흥역_Click(object sender, EventArgs e)
        {
            station_lbl_click("대흥역");
        }
        private void lbl_도곡역_Click(object sender, EventArgs e)
        {
            station_lbl_click("도곡역");
        }
        private void lbl_도림천역_Click(object sender, EventArgs e)
        {
            station_lbl_click("도림천역");
        }
        private void lbl_도봉산역_Click(object sender, EventArgs e)
        {
            station_lbl_click("도봉산역");
        }
        private void lbl_도봉역_Click(object sender, EventArgs e)
        {
            station_lbl_click("도봉역");
        }
        private void lbl_독립문역_Click(object sender, EventArgs e)
        {
            station_lbl_click("독립문역");
        }
        private void lbl_독바위역_Click(object sender, EventArgs e)
        {
            station_lbl_click("독바위역");
        }
        private void lbl_독산역_Click(object sender, EventArgs e)
        {
            station_lbl_click("독산역");
        }
        private void lbl_돌곶이역_Click(object sender, EventArgs e)
        {
            station_lbl_click("돌곶이역");
        }
        private void lbl_동대문역_Click(object sender, EventArgs e)
        {
            station_lbl_click("동대문역");
        }
        private void lbl_동대문역사문화공원역_Click(object sender, EventArgs e)
        {
            station_lbl_click("동대문역사문화공원역");
        }
        private void lbl_동대입구역_Click(object sender, EventArgs e)
        {
            station_lbl_click("동대입구역");
        }
        private void lbl_동묘앞역_Click(object sender, EventArgs e)
        {
            station_lbl_click("동묘앞역");
        }
        private void lbl_동작역_Click(object sender, EventArgs e)
        {
            station_lbl_click("동작역");
        }
        private void lbl_둔촌동역_Click(object sender, EventArgs e)
        {
            station_lbl_click("둔촌동역");
        }
        private void lbl_둔촌오륜역_Click(object sender, EventArgs e)
        {
            station_lbl_click("둔촌오륜역");
        }
        private void lbl_등촌역_Click(object sender, EventArgs e)
        {
            station_lbl_click("등촌역");
        }
        private void lbl_디지털미디어시티역_Click(object sender, EventArgs e)
        {
            station_lbl_click("디지털미디어시티역");
        }
        private void lbl_뚝섬역_Click(object sender, EventArgs e)
        {
            station_lbl_click("뚝섬역");
        }
        private void lbl_뚝섬유원지역_Click(object sender, EventArgs e)
        {
            station_lbl_click("뚝섬유원지역");
        }
        private void lbl_마곡나루역_Click(object sender, EventArgs e)
        {
            station_lbl_click("마곡나루역");
        }
        private void lbl_마곡역_Click(object sender, EventArgs e)
        {
            station_lbl_click("마곡역");
        }
        private void lbl_마들역_Click(object sender, EventArgs e)
        {
            station_lbl_click("마들역");
        }
        private void lbl_마장역_Click(object sender, EventArgs e)
        {
            station_lbl_click("마장역");
        }
        private void lbl_마천역_Click(object sender, EventArgs e)
        {
            station_lbl_click("마천역");
        }
        private void lbl_마포구청역_Click(object sender, EventArgs e)
        {
            station_lbl_click("마포구청역");
        }
        private void lbl_마포역_Click(object sender, EventArgs e)
        {
            station_lbl_click("마포역");
        }
        private void lbl_망우역_Click(object sender, EventArgs e)
        {
            station_lbl_click("망우역");
        }
        private void lbl_망원역_Click(object sender, EventArgs e)
        {
            station_lbl_click("망원역");
        }
        private void lbl_매봉역_Click(object sender, EventArgs e)
        {
            station_lbl_click("매봉역");
        }
        private void lbl_먹골역_Click(object sender, EventArgs e)
        {
            station_lbl_click("먹골역");
        }
        private void lbl_면목역_Click(object sender, EventArgs e)
        {
            station_lbl_click("면목역");
        }
        private void lbl_명동역_Click(object sender, EventArgs e)
        {
            station_lbl_click("명동역");
        }
        private void lbl_명일역_Click(object sender, EventArgs e)
        {
            station_lbl_click("명일역");
        }
        private void lbl_목동역_Click(object sender, EventArgs e)
        {
            station_lbl_click("목동역");
        }
        private void lbl_몽촌토성역_Click(object sender, EventArgs e)
        {
            station_lbl_click("몽촌토성역");
        }
        private void lbl_무악재역_Click(object sender, EventArgs e)
        {
            station_lbl_click("무악재역");
        }
        private void lbl_문래역_Click(object sender, EventArgs e)
        {
            station_lbl_click("문래역");
        }
        private void lbl_문정역_Click(object sender, EventArgs e)
        {
            station_lbl_click("문정역");
        }
        private void lbl_미아사거리역_Click(object sender, EventArgs e)
        {
            station_lbl_click("미아사거리역");
        }
        private void lbl_미아역_Click(object sender, EventArgs e)
        {
            station_lbl_click("미아역");
        }
        private void lbl_반포역_Click(object sender, EventArgs e)
        {
            station_lbl_click("반포역");
        }
        private void lbl_발산역_Click(object sender, EventArgs e)
        {
            station_lbl_click("발산역");
        }
        private void lbl_방배역_Click(object sender, EventArgs e)
        {
            station_lbl_click("방배역");
        }
        private void lbl_방이역_Click(object sender, EventArgs e)
        {
            station_lbl_click("방이역");
        }
        private void lbl_방학역_Click(object sender, EventArgs e)
        {
            station_lbl_click("방학역");
        }
        private void lbl_버티고개역_Click(object sender, EventArgs e)
        {
            station_lbl_click("버티고개역");
        }
        private void lbl_보라매역_Click(object sender, EventArgs e)
        {
            station_lbl_click("보라매역");
        }
        private void lbl_보문역_Click(object sender, EventArgs e)
        {
            station_lbl_click("보문역");
        }
        private void lbl_복정역_Click(object sender, EventArgs e)
        {
            station_lbl_click("복정역");
        }
        private void lbl_봉은사역_Click(object sender, EventArgs e)
        {
            station_lbl_click("봉은사역");
        }
        private void lbl_봉천역_Click(object sender, EventArgs e)
        {
            station_lbl_click("봉천역");
        }
        private void lbl_봉화산역_Click(object sender, EventArgs e)
        {
            station_lbl_click("봉화산역");
        }
        private void lbl_북한산보국문역_Click(object sender, EventArgs e)
        {
            station_lbl_click("북한산보국문역");
        }
        private void lbl_북한산우이역_Click(object sender, EventArgs e)
        {
            station_lbl_click("북한산우이역");
        }
        private void lbl_불광역_Click(object sender, EventArgs e)
        {
            station_lbl_click("불광역");
        }
        private void lbl_사가정역_Click(object sender, EventArgs e)
        {
            station_lbl_click("사가정역");
        }
        private void lbl_사당역_Click(object sender, EventArgs e)
        {
            station_lbl_click("사당역");
        }
        private void lbl_사평역_Click(object sender, EventArgs e)
        {
            station_lbl_click("사평역");
        }
        private void lbl_삼각지역_Click(object sender, EventArgs e)
        {
            station_lbl_click("삼각지역");
        }
        private void lbl_삼성중앙역_Click(object sender, EventArgs e)
        {
            station_lbl_click("삼성중앙역");
        }
        private void lbl_삼양사거리역_Click(object sender, EventArgs e)
        {
            station_lbl_click("삼양사거리역");
        }
        private void lbl_삼양역_Click(object sender, EventArgs e)
        {
            station_lbl_click("삼양역");
        }
        private void lbl_삼전역_Click(object sender, EventArgs e)
        {
            station_lbl_click("삼전역");
        }
        private void lbl_상계역_Click(object sender, EventArgs e)
        {
            station_lbl_click("상계역");
        }
        private void lbl_상도역_Click(object sender, EventArgs e)
        {
            station_lbl_click("상도역");
        }
        private void lbl_상봉역_Click(object sender, EventArgs e)
        {
            station_lbl_click("상봉역");
        }
        private void lbl_상수역_Click(object sender, EventArgs e)
        {
            station_lbl_click("상수역");
        }
        private void lbl_상왕십리역_Click(object sender, EventArgs e)
        {
            station_lbl_click("상왕십리역");
        }
        private void lbl_상월곡역_Click(object sender, EventArgs e)
        {
            station_lbl_click("상월곡역");
        }
        private void lbl_새절역_Click(object sender, EventArgs e)
        {
            station_lbl_click("새절역");
        }
        private void lbl_샛강역_Click(object sender, EventArgs e)
        {
            station_lbl_click("샛강역");
        }
        private void lbl_서강대역_Click(object sender, EventArgs e)
        {
            station_lbl_click("서강대역");
        }
        private void lbl_서대문역_Click(object sender, EventArgs e)
        {
            station_lbl_click("서대문역");
        }
        private void lbl_서빙고역_Click(object sender, EventArgs e)
        {
            station_lbl_click("서빙고역");
        }
        private void lbl_서울대입구역_Click(object sender, EventArgs e)
        {
            station_lbl_click("서울대입구역");
        }
        private void lbl_서울숲역_Click(object sender, EventArgs e)
        {
            station_lbl_click("서울숲역");
        }
        private void lbl_서울역_Click(object sender, EventArgs e)
        {
            station_lbl_click("서울역");
        }
        private void lbl_서초역_Click(object sender, EventArgs e)
        {
            station_lbl_click("서초역");
        }
        private void lbl_석계역_Click(object sender, EventArgs e)
        {
            station_lbl_click("석계역");
        }
        private void lbl_석수역_Click(object sender, EventArgs e)
        {
            station_lbl_click("석수역");
        }
        private void lbl_석촌고분역_Click(object sender, EventArgs e)
        {
            station_lbl_click("석촌고분역");
        }
        private void lbl_석촌역_Click(object sender, EventArgs e)
        {
            station_lbl_click("석촌역");
        }
        private void lbl_선릉역_Click(object sender, EventArgs e)
        {
            station_lbl_click("선릉역");
        }
        private void lbl_선유도역_Click(object sender, EventArgs e)
        {
            station_lbl_click("선유도역");
        }
        private void lbl_선정릉역_Click(object sender, EventArgs e)
        {
            station_lbl_click("선정릉역");
        }
        private void lbl_성수역_Click(object sender, EventArgs e)
        {
            station_lbl_click("성수역");
        }
        private void lbl_성신여대입구역_Click(object sender, EventArgs e)
        {
            station_lbl_click("성신여대입구역");
        }
        private void lbl_솔밭공원역_Click(object sender, EventArgs e)
        {
            station_lbl_click("솔밭공원역");
        }
        private void lbl_솔샘역_Click(object sender, EventArgs e)
        {
            station_lbl_click("솔샘역");
        }
        private void lbl_송정역_Click(object sender, EventArgs e)
        {
            station_lbl_click("송정역");
        }
        private void lbl_송파나루역_Click(object sender, EventArgs e)
        {
            station_lbl_click("송파나루역");
        }
        private void lbl_송파역_Click(object sender, EventArgs e)
        {
            station_lbl_click("송파역");
        }
        private void lbl_수락산역_Click(object sender, EventArgs e)
        {
            station_lbl_click("수락산역");
        }
        private void lbl_수색역_Click(object sender, EventArgs e)
        {
            station_lbl_click("수색역");
        }
        private void lbl_수서역_Click(object sender, EventArgs e)
        {
            station_lbl_click("수서역");
        }
        private void lbl_수유역_Click(object sender, EventArgs e)
        {
            station_lbl_click("수유역");
        }
        private void lbl_숙대입구역_Click(object sender, EventArgs e)
        {
            station_lbl_click("숙대입구역");
        }
        private void lbl_숭실대입구역_Click(object sender, EventArgs e)
        {
            station_lbl_click("숭실대입구역");
        }
        private void lbl_시청역_Click(object sender, EventArgs e)
        {
            station_lbl_click("시청역");
        }
        private void lbl_신금호역_Click(object sender, EventArgs e)
        {
            station_lbl_click("신금호역");
        }
        private void lbl_신길역_Click(object sender, EventArgs e)
        {
            station_lbl_click("신길역");
        }
        private void lbl_신내역_Click(object sender, EventArgs e)
        {
            station_lbl_click("신내역");
        }
        private void lbl_신논현역_Click(object sender, EventArgs e)
        {
            station_lbl_click("신논현역");
        }
        private void lbl_신답역_Click(object sender, EventArgs e)
        {
            station_lbl_click("신답역");
        }
        private void lbl_신당역_Click(object sender, EventArgs e)
        {
            station_lbl_click("신당역");
        }
        private void lbl_신대방삼거리역_Click(object sender, EventArgs e)
        {
            station_lbl_click("신대방삼거리역");
        }
        private void lbl_신대방역_Click(object sender, EventArgs e)
        {
            station_lbl_click("신대방역");
        }
        private void lbl_신도림역_Click(object sender, EventArgs e)
        {
            station_lbl_click("신도림역");
        }
        private void lbl_신림역_Click(object sender, EventArgs e)
        {
            station_lbl_click("신림역");
        }
        private void lbl_신목동역_Click(object sender, EventArgs e)
        {
            station_lbl_click("신목동역");
        }
        private void lbl_신반포역_Click(object sender, EventArgs e)
        {
            station_lbl_click("신반포역");
        }
        private void lbl_신방화역_Click(object sender, EventArgs e)
        {
            station_lbl_click("신방화역");
        }
        private void lbl_신사역_Click(object sender, EventArgs e)
        {
            station_lbl_click("신사역");
        }
        private void lbl_신설동역_Click(object sender, EventArgs e)
        {
            station_lbl_click("신설동역");
        }
        private void lbl_신용산역_Click(object sender, EventArgs e)
        {
            station_lbl_click("신용산역");
        }
        private void lbl_신이문역_Click(object sender, EventArgs e)
        {
            station_lbl_click("신이문역");
        }
        private void lbl_신정네거리역_Click(object sender, EventArgs e)
        {
            station_lbl_click("신정네거리역");
        }
        private void lbl_신정역_Click(object sender, EventArgs e)
        {
            station_lbl_click("신정역");
        }
        private void lbl_신풍역_Click(object sender, EventArgs e)
        {
            station_lbl_click("신풍역");
        }
        private void lbl_쌍문역_Click(object sender, EventArgs e)
        {
            station_lbl_click("쌍문역");
        }
        private void lbl_아차산역_Click(object sender, EventArgs e)
        {
            station_lbl_click("아차산역");
        }
        private void lbl_아현역_Click(object sender, EventArgs e)
        {
            station_lbl_click("아현역");
        }
        private void lbl_안국역_Click(object sender, EventArgs e)
        {
            station_lbl_click("안국역");
        }
        private void lbl_안암역_Click(object sender, EventArgs e)
        {
            station_lbl_click("안암역");
        }
        private void lbl_암사역_Click(object sender, EventArgs e)
        {
            station_lbl_click("암사역");
        }
        private void lbl_압구정로데오역_Click(object sender, EventArgs e)
        {
            station_lbl_click("압구정로데오역");
        }
        private void lbl_압구정역_Click(object sender, EventArgs e)
        {
            station_lbl_click("압구정역");
        }
        private void lbl_애오개역_Click(object sender, EventArgs e)
        {
            station_lbl_click("애오개역");
        }
        private void lbl_약수역_Click(object sender, EventArgs e)
        {
            station_lbl_click("약수역");
        }
        private void lbl_양원역_Click(object sender, EventArgs e)
        {
            station_lbl_click("양원역");
        }
        private void lbl_양재시민의숲역_Click(object sender, EventArgs e)
        {
            station_lbl_click("양재시민의숲역");
        }
        private void lbl_양재역_Click(object sender, EventArgs e)
        {
            station_lbl_click("양재역");
        }
        private void lbl_양천구청역_Click(object sender, EventArgs e)
        {
            station_lbl_click("양천구청역");
        }
        private void lbl_양천향교역_Click(object sender, EventArgs e)
        {
            station_lbl_click("양천향교역");
        }
        private void lbl_양평역_Click(object sender, EventArgs e)
        {
            station_lbl_click("양평역");
        }
        private void lbl_어린이대공원역_Click(object sender, EventArgs e)
        {
            station_lbl_click("어린이대공원역");
        }
        private void lbl_언주역_Click(object sender, EventArgs e)
        {
            station_lbl_click("언주역");
        }
        private void lbl_여의나루역_Click(object sender, EventArgs e)
        {
            station_lbl_click("여의나루역");
        }
        private void lbl_여의도역_Click(object sender, EventArgs e)
        {
            station_lbl_click("여의도역");
        }
        private void lbl_역삼역_Click(object sender, EventArgs e)
        {
            station_lbl_click("역삼역");
        }
        private void lbl_역촌역_Click(object sender, EventArgs e)
        {
            station_lbl_click("역촌역");
        }
        private void lbl_연신내역_Click(object sender, EventArgs e)
        {
            station_lbl_click("연신내역");
        }
        private void lbl_염창역_Click(object sender, EventArgs e)
        {
            station_lbl_click("염창역");
        }
        private void lbl_영등포구청역_Click(object sender, EventArgs e)
        {
            station_lbl_click("영등포구청역");
        }
        private void lbl_영등포시장역_Click(object sender, EventArgs e)
        {
            station_lbl_click("영등포시장역");
        }
        private void lbl_영등포역_Click(object sender, EventArgs e)
        {
            station_lbl_click("영등포역");
        }
        private void lbl_오금역_Click(object sender, EventArgs e)
        {
            station_lbl_click("오금역");
        }
        private void lbl_오류동역_Click(object sender, EventArgs e)
        {
            station_lbl_click("오류동역");
        }
        private void lbl_오목교역_Click(object sender, EventArgs e)
        {
            station_lbl_click("오목교역");
        }
        private void lbl_옥수역_Click(object sender, EventArgs e)
        {
            station_lbl_click("옥수역");
        }
        private void lbl_온수역_Click(object sender, EventArgs e)
        {
            station_lbl_click("온수역");
        }
        private void lbl_왕십리역_Click(object sender, EventArgs e)
        {
            station_lbl_click("왕십리역");
        }
        private void lbl_용답역_Click(object sender, EventArgs e)
        {
            station_lbl_click("용답역");
        }
        private void lbl_용두역_Click(object sender, EventArgs e)
        {
            station_lbl_click("용두역");
        }
        private void lbl_용마산역_Click(object sender, EventArgs e)
        {
            station_lbl_click("용마산역");
        }
        private void lbl_용산역_Click(object sender, EventArgs e)
        {
            station_lbl_click("용산역");
        }
        private void lbl_우장산역_Click(object sender, EventArgs e)
        {
            station_lbl_click("우장산역");
        }
        private void lbl_월계역_Click(object sender, EventArgs e)
        {
            station_lbl_click("월계역");
        }
        private void lbl_월곡역_Click(object sender, EventArgs e)
        {
            station_lbl_click("월곡역");
        }
        private void lbl_월드컵경기장역_Click(object sender, EventArgs e)
        {
            station_lbl_click("월드컵경기장역");
        }
        private void lbl_을지로3가역_Click(object sender, EventArgs e)
        {
            station_lbl_click("을지로3가역");
        }
        private void lbl_을지로4가역_Click(object sender, EventArgs e)
        {
            station_lbl_click("을지로4가역");
        }
        private void lbl_을지로입구역_Click(object sender, EventArgs e)
        {
            station_lbl_click("을지로입구역");
        }
        private void lbl_응봉역_Click(object sender, EventArgs e)
        {
            station_lbl_click("응봉역");
        }
        private void lbl_응암역_Click(object sender, EventArgs e)
        {
            station_lbl_click("응암역");
        }
        private void lbl_이대역_Click(object sender, EventArgs e)
        {
            station_lbl_click("이대역");
        }
        private void lbl_이수역_Click(object sender, EventArgs e)
        {
            station_lbl_click("이수역");
        }
        private void lbl_이촌역_Click(object sender, EventArgs e)
        {
            station_lbl_click("이촌역");
        }
        private void lbl_이태원역_Click(object sender, EventArgs e)
        {
            station_lbl_click("이태원역");
        }
        private void lbl_일원역_Click(object sender, EventArgs e)
        {
            station_lbl_click("일원역");
        }
        private void lbl_잠실나루역_Click(object sender, EventArgs e)
        {
            station_lbl_click("잠실나루역");
        }
        private void lbl_잠실새내역_Click(object sender, EventArgs e)
        {
            station_lbl_click("잠실새내역");
        }
        private void lbl_잠실역_Click(object sender, EventArgs e)
        {
            station_lbl_click("잠실역");
        }
        private void lbl_잠원역_Click(object sender, EventArgs e)
        {
            station_lbl_click("잠원역");
        }
        private void lbl_장승배기역_Click(object sender, EventArgs e)
        {
            station_lbl_click("장승배기역");
        }
        private void lbl_장지역_Click(object sender, EventArgs e)
        {
            station_lbl_click("장지역");
        }
        private void lbl_장한평역_Click(object sender, EventArgs e)
        {
            station_lbl_click("장한평역");
        }
        private void lbl_정릉역_Click(object sender, EventArgs e)
        {
            station_lbl_click("정릉역");
        }
        private void lbl_제기동역_Click(object sender, EventArgs e)
        {
            station_lbl_click("제기동역");
        }
        private void lbl_종각역_Click(object sender, EventArgs e)
        {
            station_lbl_click("종각역");
        }
        private void lbl_종로3가역_Click(object sender, EventArgs e)
        {
            station_lbl_click("종로3가역");
        }
        private void lbl_종로5가역_Click(object sender, EventArgs e)
        {
            station_lbl_click("종로5가역");
        }
        private void lbl_종합운동장역_Click(object sender, EventArgs e)
        {
            station_lbl_click("종합운동장역");
        }
        private void lbl_중계역_Click(object sender, EventArgs e)
        {
            station_lbl_click("중계역");
        }
        private void lbl_중곡역_Click(object sender, EventArgs e)
        {
            station_lbl_click("중곡역");
        }
        private void lbl_중랑역_Click(object sender, EventArgs e)
        {
            station_lbl_click("중랑역");
        }
        private void lbl_중화역_Click(object sender, EventArgs e)
        {
            station_lbl_click("중화역");
        }
        private void lbl_증미역_Click(object sender, EventArgs e)
        {
            station_lbl_click("증미역");
        }
        private void lbl_증산역_Click(object sender, EventArgs e)
        {
            station_lbl_click("증산역");
        }
        private void lbl_창동역_Click(object sender, EventArgs e)
        {
            station_lbl_click("창동역");
        }
        private void lbl_창신역_Click(object sender, EventArgs e)
        {
            station_lbl_click("창신역");
        }
        private void lbl_천왕역_Click(object sender, EventArgs e)
        {
            station_lbl_click("천왕역");
        }
        private void lbl_천호역_Click(object sender, EventArgs e)
        {
            station_lbl_click("천호역");
        }
        private void lbl_청계산입구역_Click(object sender, EventArgs e)
        {
            station_lbl_click("청계산입구역");
        }
        private void lbl_청구역_Click(object sender, EventArgs e)
        {
            station_lbl_click("청구역");
        }
        private void lbl_청담역_Click(object sender, EventArgs e)
        {
            station_lbl_click("청담역");
        }
        private void lbl_청량리역_Click(object sender, EventArgs e)
        {
            station_lbl_click("청량리역");
        }
        private void lbl_총신대입구역_Click(object sender, EventArgs e)
        {
            station_lbl_click("총신대입구역");
        }
        private void lbl_충무로역_Click(object sender, EventArgs e)
        {
            station_lbl_click("충무로역");
        }
        private void lbl_충정로역_Click(object sender, EventArgs e)
        {
            station_lbl_click("충정로역");
        }
        private void lbl_태릉입구역_Click(object sender, EventArgs e)
        {
            station_lbl_click("태릉입구역");
        }
        private void lbl_하계역_Click(object sender, EventArgs e)
        {
            station_lbl_click("하계역");
        }
        private void lbl_학동역_Click(object sender, EventArgs e)
        {
            station_lbl_click("학동역");
        }
        private void lbl_학여울역_Click(object sender, EventArgs e)
        {
            station_lbl_click("학여울역");
        }
        private void lbl_한강진역_Click(object sender, EventArgs e)
        {
            station_lbl_click("한강진역");
        }
        private void lbl_한남역_Click(object sender, EventArgs e)
        {
            station_lbl_click("한남역");
        }
        private void lbl_한성대입구역_Click(object sender, EventArgs e)
        {
            station_lbl_click("한성대입구역");
        }
        private void lbl_한성백제역_Click(object sender, EventArgs e)
        {
            station_lbl_click("한성백제역");
        }
        private void lbl_한양대역_Click(object sender, EventArgs e)
        {
            station_lbl_click("한양대역");
        }
        private void lbl_한티역_Click(object sender, EventArgs e)
        {
            station_lbl_click("한티역");
        }
        private void lbl_합정역_Click(object sender, EventArgs e)
        {
            station_lbl_click("합정역");
        }
        private void lbl_행당역_Click(object sender, EventArgs e)
        {
            station_lbl_click("행당역");
        }
        private void lbl_혜화역_Click(object sender, EventArgs e)
        {
            station_lbl_click("혜화역");
        }
        private void lbl_홍대입구역_Click(object sender, EventArgs e)
        {
            station_lbl_click("홍대입구역");
        }
        private void lbl_홍제역_Click(object sender, EventArgs e)
        {
            station_lbl_click("홍제역");
        }
        private void lbl_화계역_Click(object sender, EventArgs e)
        {
            station_lbl_click("화계역");
        }
        private void lbl_화곡역_Click(object sender, EventArgs e)
        {
            station_lbl_click("화곡역");
        }
        private void lbl_화랑대역_Click(object sender, EventArgs e)
        {
            station_lbl_click("화랑대역");
        }
        private void lbl_회기역_Click(object sender, EventArgs e)
        {
            station_lbl_click("회기역");
        }
        private void lbl_회현역_Click(object sender, EventArgs e)
        {
            station_lbl_click("회현역");
        }
        private void lbl_효창공원앞역_Click(object sender, EventArgs e)
        {
            station_lbl_click("효창공원앞역");
        }


        private void lbl_강일역_Click(object sender, EventArgs e)
        {
            station_lbl_click("강일역");
        }
        private void lbl_고덕역_Click(object sender, EventArgs e)
        {
            station_lbl_click("고덕역");
        }
        private void lbl_금호역_Click(object sender, EventArgs e)
        {
            station_lbl_click("금호역");
        }
        private void lbl_신촌역1_Click(object sender, EventArgs e)
        {
            station_lbl_click("신촌역1");
        }
        private void lbl_신촌역2_Click(object sender, EventArgs e)
        {
            station_lbl_click("신촌역2");
        }

        private void lbl_상일동역_Click(object sender, EventArgs e)
        {
            station_lbl_click("상일동역");
        }

        private void lbl_올림픽공원역_Click(object sender, EventArgs e)
        {
            station_lbl_click("올림픽공원역");
        }

        private void lbl_외대앞역_Click(object sender, EventArgs e)
        {
            station_lbl_click("외대앞역");
        }

        private void lbl_흑석역_Click(object sender, EventArgs e)
        {
            station_lbl_click("흑석역");
        }
    }
}