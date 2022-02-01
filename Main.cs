using Newtonsoft.Json;
using System;
using System.Text;
using System.Windows.Forms;

namespace EEW_Viewer
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Version.Text = "EEW_Viewer by Project-S Version: 2.2　";//β
            JsonTimer.Start();
        }
        public void EEW(object sender, EventArgs e)
        {
            try
            {
                string json;
                using (var wc = new System.Net.WebClient())
                {

                    //取得URL設定
                    string Time1 = DateTime.Now.ToString("yyyyMMddhhmmss");
                    long Time2 = Convert.ToInt64(Time1);
                    long Time3 = Time2 - 1;
                    string AccessTime = "http://www.kmoni.bosai.go.jp/webservice/hypo/eew/" + Time3 + ".json".ToString() + ".json";
                    wc.Encoding = Encoding.UTF8;
                    //通常
                    json = wc.DownloadString(AccessTime);

                    //テスト用 EEW予報　震度2
                    //json = wc.DownloadString("http://www.kmoni.bosai.go.jp/webservice/hypo/eew/20220123095750.json");

                    //テスト用　EEW予報 震度不明
                    //json = wc.DownloadString("http://www.kmoni.bosai.go.jp/webservice/hypo/eew/20210705012355.json");

                    //テスト用　EEW警報　2021福島県沖
                    //json = wc.DownloadString("http://www.kmoni.bosai.go.jp/webservice/hypo/eew/20210213231450.json");


                    Loading.Text = $"";
                    var jsonData = JsonConvert.DeserializeObject<EEW_JSON>(json);
                    string _Data = jsonData.Message;
                    string _Alert = jsonData.Alertflg;
                    string _Depth = jsonData.Depth;
                    string _Num = jsonData.Report_num;
                    string _Cancel = jsonData.Is_cancel;
                    string _Final = jsonData.Is_final;
                    string _DataTime = jsonData.Report_Time;
                    string _Training = jsonData.Is_training;
                    string _Shingen = jsonData.Region_name;
                    string _Shindo = jsonData.Calcintensity;
                    string _M = jsonData.Magunitude;

                    int IBCR1 = 0;
                    int IBCG1 = 0;
                    int IBCB1 = 0;
                    int ITCR1 = 0;
                    int ITCG1 = 0;
                    int ITCB1 = 0;
                    int IBCR2 = 0;
                    int IBCG2 = 0;
                    int IBCB2 = 0;
                    int ITCR2 = 0;
                    int ITCG2 = 0;
                    int ITCB2 = 0;

                    SAIDAISINDO.Text = $"";
                    sindo.Text = $"";
                    Singen.Text = $"";
                    M_Depth.Text = $"";
                    YohouKeihou_Hou_Final_Time.Text = $"";
                    Tunami.Text = $"";

                    string DataTime = _DataTime;
                    bool Tsunami_Warn = false;
                    bool Warning = false;
                    bool Data = false;
                    bool Final = false;
                    bool PLUM = false;



                    //震度別背景色未実装
                    if (jsonData.Calcintensity == "不明")
                    {
                        sindo.Text = "0";
                        IBCR2 = 70;
                        IBCG2 = 80;
                        IBCB2 = 100;
                        ITCR2 = 255;
                        ITCG2 = 255;
                        ITCB2 = 255;
                    }
                    else if (jsonData.Calcintensity == "1") ;
                    {
                        IBCR2 = 70;
                        IBCG2 = 100;
                        IBCB2 = 110;
                        ITCR2 = 255;
                        ITCG2 = 255;
                        ITCB2 = 255;
                        //↓臨時
                        IBCR2 = 30;
                        IBCG2 = 40;
                        IBCB2 = 60;
                    }
                    /*
                    if (_Shindo == "2") ;
                    {
                        IBCR2 = 30;
                        IBCG2 = 110;
                        IBCB2 = 230;
                        ITCR2 = 255;
                        ITCG2 = 255;
                        ITCB2 = 255;
                    }
                    if (_Shindo == "3") ;
                    {
                        IBCR2 = 0;
                        IBCG2 = 200;
                        IBCB2 = 200;
                        ITCR2 = 0;
                        ITCG2 = 0;
                        ITCB2 = 0;
                    }
                    if (_Shindo == "4") ;
                    {
                        IBCR2 = 250;
                        IBCG2 = 250;
                        IBCB2 = 100;
                        ITCR2 = 0;
                        ITCG2 = 0;
                        ITCB2 = 0;
                    }
                    if (_Shindo == "5弱") ;
                    {
                        IBCR2 = 255;
                        IBCG2 = 180;
                        IBCB2 = 0;
                        ITCR2 = 0;
                        ITCG2 = 0;
                        ITCB2 = 0;
                    }
                    if (_Shindo == "5強") ;
                    {
                        IBCR2 = 255;
                        IBCG2 = 120;
                        IBCB2 = 0;
                        ITCR2 = 0;
                        ITCG2 = 0;
                        ITCB2 = 0;
                    }
                    if (_Shindo == "6弱") ;
                    {
                        IBCR2 = 230;
                        IBCG2 = 0;
                        IBCB2 = 0;
                        ITCR2 = 255;
                        ITCG2 = 255;
                        ITCB2 = 255;
                    }
                    if (_Shindo == "6強") ;
                    {
                        IBCR2 = 160;
                        IBCG2 = 0;
                        IBCB2 = 0;
                        ITCR2 = 255;
                        ITCG2 = 255;
                        ITCB2 = 255;
                    }
                    if (_Shindo == "7") ;
                    {
                        IBCR2 = 150;
                        IBCG2 = 0;
                        IBCB2 = 150;
                        ITCR2 = 255;
                        ITCG2 = 255;
                        ITCB2 = 255;
                    }*/

                    if (jsonData.Alertflg == "予報")
                    {
                        IBCR1 = 25;
                        IBCG1 = 100;
                        IBCB1 = 25;
                        ITCR1 = 255;
                        ITCG1 = 255;
                        ITCB1 = 255;
                        YohouKeihou_Hou_Final_Time.Text = $"緊急地震速報 {_Alert}  第{_Num}報         {DataTime}　　　";
                        SAIDAISINDO.Text = $"最大震度";
                        sindo.Text = $"{_Shindo}";
                        Singen.Text = $"{_Shingen}";
                        M_Depth.Text = $"M{_M}    {_Depth}";

                        double M = Convert.ToDouble(_M);

                        if (M >= 6.5)
                        {
                            Tunami.Text = $"津波発生の\n可能性あり";
                        }
                        if (M <= 1.1)
                        {
                            M_Depth.Text = $"PLUM法による予測";
                        }

                        if (jsonData.Is_final == "true")
                        {
                            YohouKeihou_Hou_Final_Time.Text = $"緊急地震速報 {_Alert}  第{_Num}報  最終   {DataTime}　　　";
                        }
                    }
                    else if (jsonData.Alertflg == "警報")
                    {
                        IBCR1 = 255;
                        IBCG1 = 0;
                        IBCB1 = 0;
                        ITCR1 = 255;
                        ITCG1 = 255;
                        ITCB1 = 255;
                        YohouKeihou_Hou_Final_Time.Text = $"緊急地震速報 {_Alert}  第{_Num}報         {DataTime}　　　";
                        SAIDAISINDO.Text = $"最大震度";
                        sindo.Text = $"{_Shindo}";
                        Singen.Text = $"{_Shingen}";
                        M_Depth.Text = $"M{_M}    {_Depth}";

                        double M = Convert.ToDouble(_M);
                        if (M >= 6.5)
                        {
                            Tunami.Text = $"津波発生の\n可能性あり";
                        }
                        

                        if (Final = true)
                        {
                            YohouKeihou_Hou_Final_Time.Text = $"緊急地震速報 {_Alert}  第{_Num}報  最終   {DataTime}　　　";
                        }
                    }
                    else
                    {
                        IBCR1 = 30;
                        IBCG1 = 40;
                        IBCB1 = 60;
                        IBCR2 = 30;
                        IBCG2 = 40;
                        IBCB2 = 60;
                        ITCR1 = 255;
                        ITCG1 = 255;
                        ITCB1 = 255;
                        ITCR2 = 30;
                        ITCG2 = 40;
                        ITCB2 = 60;
                        SAIDAISINDO.Text = $"";
                        sindo.Text = $"";
                        Singen.Text = $"";
                        M_Depth.Text = $"";
                        YohouKeihou_Hou_Final_Time.Text = $"緊急地震速報は受信していません";
                    }



                    var InfoBackgroundColor1 = System.Drawing.Color.FromArgb(IBCR1, IBCG1, IBCB1);
                    var InfoTextColor1 = System.Drawing.Color.FromArgb(ITCR1, ITCG1, ITCB1);
                    var InfoBackgroundColor2 = System.Drawing.Color.FromArgb(IBCR2, IBCG2, IBCB2);
                    var InfoTextColor2 = System.Drawing.Color.FromArgb(ITCR2, ITCG2, ITCB2);
                    YohouKeihou_Hou_Final_Time.BackColor = InfoBackgroundColor1;
                    YohouKeihou_Hou_Final_Time.ForeColor = InfoTextColor1;
                    Back.BackColor = InfoBackgroundColor2;
                    SAIDAISINDO.BackColor = InfoBackgroundColor2;
                    Singen.BackColor = InfoBackgroundColor2;
                    sindo.BackColor = InfoBackgroundColor2;
                    M_Depth.BackColor = InfoBackgroundColor2;
                    Tunami.BackColor = InfoBackgroundColor2;
                    Warn.BackColor = InfoBackgroundColor2;
                    Back.ForeColor = InfoTextColor2;
                    SAIDAISINDO.ForeColor = InfoTextColor2;
                    Singen.ForeColor = InfoTextColor2;
                    sindo.ForeColor = InfoTextColor2;
                    M_Depth.ForeColor = InfoTextColor2;
                    Tunami.ForeColor = InfoTextColor2;
                    Warn.ForeColor = InfoTextColor2;

                    Time1 = null;
                    Time2 = 0;
                    Time3 = 0;
                    AccessTime = null;


                    _Data = null;
                    _Alert = null;
                    _Shingen = null;
                    _Shindo = null;
                    _M = null;
                    _Depth = null;
                    _Num = null;
                    _Cancel = null;
                    _Final = null;
                    _DataTime = null;
                    _Training = null;


                    DataTime = null;
                    Final = false;
                   



                }
            }
            catch (Exception ex)
            {

            }

        }


        public class EEW_JSON
        {
            //メッセージ
            public string Message { get; set; }
            //更新時刻
            public string Report_Time { get; set; }
            //震源名
            public string Region_name { get; set; }
            //キャンセルか
            public string Is_cancel { get; set; }
            //深さ
            public string Depth { get; set; }
            //最大震度
            public string Calcintensity { get; set; }
            //最終報か
            public string Is_final { get; set; }
            //訓練法か
            public string Is_traning { get; set; }
            //マグニチュード
            public string Magunitude { get; set; }
            //報数
            public string Report_num { get; set; }
            //予報警報
            public string Alertflg { get; set; }
            //訓練報
            public string Is_training { get; set; }
            //発生時刻
            public string Origin_time { get; set; }

        }
    }
}
