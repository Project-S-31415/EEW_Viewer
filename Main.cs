using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;//臨時ログ出力用

namespace EEW_Viewer
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            JsonTimer.Start();
        }
        public void Timer(object sender, EventArgs e)
        {
            string json;
            using (var wc = new System.Net.WebClient())
            {
                //json取得
                //取得URL設定
                string Time = DateTime.Now.ToString("yyyyMMddhhmmss");
                string AccessTime = "http://www.kmoni.bosai.go.jp/webservice/hypo/eew/" + Time + ".json".ToString() + ".json";
                //遅延
                Thread.Sleep(2000);
                wc.Encoding = Encoding.UTF8;
                //通常
                json = wc.DownloadString(AccessTime);

                //テスト用 EEW予報　震度2
                //json = wc.DownloadString("http://www.kmoni.bosai.go.jp/webservice/hypo/eew/20220123095750.json");

                //テスト用　EEW予報 震度不明
                //json = wc.DownloadString("http://www.kmoni.bosai.go.jp/webservice/hypo/eew/20210705012345.json");

                //テスト用　EEW警報　2021福島県沖
                //json = wc.DownloadString("http://www.kmoni.bosai.go.jp/webservice/hypo/eew/20210213231450.json");
            }
            //json取得タイマー
            JsonTimer.Start();
            //Now Loading解除
            Loading.Text = $"";

            var jsonData = JsonConvert.DeserializeObject<EEW_JSON>(json);



            if (jsonData.Alertflg == "予報")
            {
                YohouKeihou_Hou_Time.BackColor = System.Drawing.Color.FromArgb(25, 100, 25);
                Final.BackColor = System.Drawing.Color.FromArgb(25, 100, 25);

                YohouKeihou_Hou_Time.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                Final.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);

            }
            if (jsonData.Alertflg == "警報")
            {
                YohouKeihou_Hou_Time.BackColor = System.Drawing.Color.FromArgb(255, 0, 0);
                Final.BackColor = System.Drawing.Color.FromArgb(255, 0, 0);

                YohouKeihou_Hou_Time.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                Final.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);

            }






            //EEW時
            if (jsonData.Is_cancel == "false")
            {



                //予報警報　報数　時間
                YohouKeihou_Hou_Time.Text = $"緊急地震速報　{jsonData.Alertflg}　第{jsonData.Report_num}報　　　 　{jsonData.Report_Time}　　　";
                //最大震度(temp)
                SAIDAISINDO.Text = $"最大震度";
                //最大震度
                sindo.Text = $"{jsonData.Calcintensity}";
                //震源
                Singen.Text = $"{jsonData.Region_name}";
                //マグニチュード、深さ
                M_Depth.Text = $"M{jsonData.Magunitude}    {jsonData.Depth}";

            }

            //EEWなし
            if (jsonData.Is_cancel == "null")
            {

                //予報警報　報数　時間
                YohouKeihou_Hou_Time.Text = $"緊急地震速報は受信していません";

                //最大震度(temp)
                SAIDAISINDO.Text = $"　";
                //最大震度
                sindo.Text = $"　";
                //震源
                Singen.Text = $"　";
                //マグニチュード、深さ
                M_Depth.Text = $"　";

            }

            //version1.0では震度別背景色はありません。
            /*



            //代入用変換

            
            string Shindo0 = "不明";
        　　    string Shindo1 = "1";
                string Shindo2 = "2";
                string Shindo3 = "3";
                string Shindo4 = "4";
                string Shindo5 = "5弱";
                string Shindo6 = "5強";
                string Shindo7 = "6弱";
                string Shindo8 = "6強";
                string Shindo9 = "7";


       //ここはエラーでる
                //int sindo0 = short.Parse(Shindo0);
          　　  //int sindo1 = short.Parse(Shindo1);
        　　    //int sindo2 = short.Parse(Shindo2);
          　　  //int sindo3 = short.Parse(Shindo3);
        　　    //int sindo4 = short.Parse(Shindo4);
           　　 //int sindo5 = short.Parse(Shindo5);
         　　   //int sindo6 = short.Parse(Shindo6);
           　 　//int sindo7 = short.Parse(Shindo7);
            　　//int sindo8 = short.Parse(Shindo8);
        　　    //int sindo9 = short.Parse(Shindo9);

            if (jsonData.Calcintensity == "6強") ;
            {
                bool sindo_0 = true;
                File.WriteAllText(@"test.txt", "aaｆｊふぃｊaaaaaaa" + Environment.NewLine);
            }
           
          //  bool b = Convert.ToBoolean(i)




            //string Shindo = jsonData.Calcintensity;


            if (sindo.Text == "不明") ;
            {
                
            }









                //震度別
                if (jsonData.Calcintensity == "不明");
            {
                sindo.Text = "0";
                Back.BackColor = System.Drawing.Color.FromArgb(70, 80, 100);
                SAIDAISINDO.BackColor = System.Drawing.Color.FromArgb(70, 80, 100);
                Singen.BackColor = System.Drawing.Color.FromArgb(70, 80, 100);
                sindo.BackColor = System.Drawing.Color.FromArgb(70, 80, 100);
                M_Depth.BackColor = System.Drawing.Color.FromArgb(70, 80, 100);
                Tunami.BackColor = System.Drawing.Color.FromArgb(70, 80, 100);
                Warn.BackColor = System.Drawing.Color.FromArgb(70, 80, 100);

                Back.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                SAIDAISINDO.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                Singen.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                sindo.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                M_Depth.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                Tunami.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                Warn.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            }

            if (sindo.Text == "1") ;
            {
                Back.BackColor = System.Drawing.Color.FromArgb(70, 100, 110);
                SAIDAISINDO.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
                Singen.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
                sindo.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
                M_Depth.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
                Tunami.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
                Warn.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);

                Back.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                SAIDAISINDO.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                Singen.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                sindo.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                M_Depth.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                Tunami.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                Warn.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            }
            if (sindo.Text == "2") ;
            {
                Back.BackColor = System.Drawing.Color.FromArgb(30, 110, 230);
                SAIDAISINDO.BackColor = System.Drawing.Color.FromArgb(30, 110, 230);
                Singen.BackColor = System.Drawing.Color.FromArgb(30, 110, 230);
                sindo.BackColor = System.Drawing.Color.FromArgb(30, 110, 230);
                M_Depth.BackColor = System.Drawing.Color.FromArgb(30, 110, 230);
                Tunami.BackColor = System.Drawing.Color.FromArgb(30, 110, 230);
                Warn.BackColor = System.Drawing.Color.FromArgb(30, 110, 230);

                Back.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                SAIDAISINDO.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                Singen.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                sindo.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                M_Depth.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                Tunami.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                Warn.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            }
            if (sindo.Text == "3") ;
            {
                Back.BackColor = System.Drawing.Color.FromArgb(0, 200, 200);
                SAIDAISINDO.BackColor = System.Drawing.Color.FromArgb(0, 200, 200);
                Singen.BackColor = System.Drawing.Color.FromArgb(0, 200, 200);
                sindo.BackColor = System.Drawing.Color.FromArgb(0, 200, 200);
                M_Depth.BackColor = System.Drawing.Color.FromArgb(0, 200, 200);
                Tunami.BackColor = System.Drawing.Color.FromArgb(0, 200, 200);
                Warn.BackColor = System.Drawing.Color.FromArgb(0, 200, 200);

                Back.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                SAIDAISINDO.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                Singen.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                sindo.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                M_Depth.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                Tunami.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                Warn.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            }
            if (sindo.Text == "4") ;
            {
                Back.BackColor = System.Drawing.Color.FromArgb(250, 250, 100);
                SAIDAISINDO.BackColor = System.Drawing.Color.FromArgb(250, 250, 100);
                Singen.BackColor = System.Drawing.Color.FromArgb(250, 250, 100);
                sindo.BackColor = System.Drawing.Color.FromArgb(250, 250, 100);
                M_Depth.BackColor = System.Drawing.Color.FromArgb(250, 250, 100);
                Tunami.BackColor = System.Drawing.Color.FromArgb(250, 250, 100);
                Warn.BackColor = System.Drawing.Color.FromArgb(250, 250, 100);

                Back.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                SAIDAISINDO.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                Singen.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                sindo.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                M_Depth.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                Tunami.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                Warn.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            }
            if (sindo.Text == "5弱") ;
            {
                Back.BackColor = System.Drawing.Color.FromArgb(255, 180, 0);
                SAIDAISINDO.BackColor = System.Drawing.Color.FromArgb(255, 180, 0);
                Singen.BackColor = System.Drawing.Color.FromArgb(255, 180, 0);
                sindo.BackColor = System.Drawing.Color.FromArgb(255, 180, 0);
                M_Depth.BackColor = System.Drawing.Color.FromArgb(255, 180, 0);
                Tunami.BackColor = System.Drawing.Color.FromArgb(255, 180, 0);
                Warn.BackColor = System.Drawing.Color.FromArgb(255, 180, 0);

                Back.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                SAIDAISINDO.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                Singen.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                sindo.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                M_Depth.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                Tunami.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                Warn.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            }
            if (sindo.Text == "5強") ;
            {
                Back.BackColor = System.Drawing.Color.FromArgb(255, 120, 0);
                SAIDAISINDO.BackColor = System.Drawing.Color.FromArgb(255, 120, 0);
                Singen.BackColor = System.Drawing.Color.FromArgb(255, 120, 0);
                sindo.BackColor = System.Drawing.Color.FromArgb(255, 120, 0);
                M_Depth.BackColor = System.Drawing.Color.FromArgb(255, 120, 0);
                Tunami.BackColor = System.Drawing.Color.FromArgb(255, 120, 0);
                Warn.BackColor = System.Drawing.Color.FromArgb(255, 120, 0);

                Back.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                SAIDAISINDO.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                Singen.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                sindo.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                M_Depth.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                Tunami.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                Warn.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            }
            if (sindo.Text == "6弱") ;
            {
                Back.BackColor = System.Drawing.Color.FromArgb(230, 0, 0);
                SAIDAISINDO.BackColor = System.Drawing.Color.FromArgb(230, 0, 0);
                Singen.BackColor = System.Drawing.Color.FromArgb(230, 0, 0);
                sindo.BackColor = System.Drawing.Color.FromArgb(230, 0, 0);
                M_Depth.BackColor = System.Drawing.Color.FromArgb(230, 0, 0);
                Tunami.BackColor = System.Drawing.Color.FromArgb(230, 0, 0);
                Warn.BackColor = System.Drawing.Color.FromArgb(230, 0, 0);

                Back.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                SAIDAISINDO.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                Singen.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                sindo.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                M_Depth.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                Tunami.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                Warn.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            }
            if (sindo.Text == "6強") ;
            {
                Back.BackColor = System.Drawing.Color.FromArgb(160, 0, 0);
                SAIDAISINDO.BackColor = System.Drawing.Color.FromArgb(160, 0, 0);
                Singen.BackColor = System.Drawing.Color.FromArgb(160, 0, 0);
                sindo.BackColor = System.Drawing.Color.FromArgb(160, 0, 0);
                M_Depth.BackColor = System.Drawing.Color.FromArgb(160, 0, 0);
                Tunami.BackColor = System.Drawing.Color.FromArgb(160, 0, 0);
                Warn.BackColor = System.Drawing.Color.FromArgb(160, 0, 0);

                Back.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                SAIDAISINDO.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                Singen.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                sindo.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                M_Depth.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                Tunami.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                Warn.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            }
            if (sindo.Text == "7") ;
            {
                Back.BackColor = System.Drawing.Color.FromArgb(150, 0, 150);
                SAIDAISINDO.BackColor = System.Drawing.Color.FromArgb(150, 0, 150);
                Singen.BackColor = System.Drawing.Color.FromArgb(150, 0, 150);
                sindo.BackColor = System.Drawing.Color.FromArgb(150, 0, 150);
                M_Depth.BackColor = System.Drawing.Color.FromArgb(150, 0, 150);
                Tunami.BackColor = System.Drawing.Color.FromArgb(150, 0, 150);
                Warn.BackColor = System.Drawing.Color.FromArgb(150, 0, 150);

                Back.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                SAIDAISINDO.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                Singen.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                sindo.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                M_Depth.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                Tunami.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                Warn.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            }*/
         





            if (jsonData.Alertflg == null)//EEWなし
            {
                YohouKeihou_Hou_Time.Text = $"緊急地震速報は受信していません　　　　　　　　　　　　　　　　";
                sindo.Text = $"　";

                YohouKeihou_Hou_Time.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
                Final.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);

                YohouKeihou_Hou_Time.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                Final.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);

                Back.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
                SAIDAISINDO.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
                Singen.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
                sindo.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
                M_Depth.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
                Tunami.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
                Warn.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);

            }


            //上部
            //YohouKeihou_Hou_Time.Text = $"緊急地震速報 "+ jsonData.Alertflg + "第" + jsonData.Report_num + "報" + jsonData.Report_Time;

            /*
                        double tunami = 6.5;
                        string tsunami = tunami.ToString();
                        if (jsonData.Magunitude == tsunami) ;
                            {
                                Tunami.Text = $"津波発生の\r可能性あり";
                            }*/
            //震度別
            /*
            Back.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
            SAIDAISINDO.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
            Singen.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
            sindo.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
            M_Depth.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
            Tunami.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
            Warn.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //文字色　震度1,2,6-,6+,7は白
            Back.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            SAIDAISINDO.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            Singen.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            sindo.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            M_Depth.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            Tunami.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            Warn.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);

            (255, 255, 255);

            */

            //予報警報
            /*

            YohouKeihou_Hou_Time.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
            Final.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);

            YohouKeihou_Hou_Time.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            Final.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
*/


            /*color
            背景：（30, 40, 60）

            震度0：灰色（70, 80, 100

            震度1：灰色（70, 100, 110）

            震度2：青色（30, 110, 230）

            震度3：緑色（0, 200, 200）

            震度4：黄色（250, 250, 100）

            震度5弱：オレンジ色（255, 180 ,0）

            震度5強：濃いオレンジ色（255, 120, 0）

            震度6弱：赤色（230, 0, 0）

            震度6強：濃い赤色（160, 0, 0）

            震度7：紫色（150, 0, 150）

            EEW1　（255, 255, 0）

            EEW2（255, 0, 0）

             */


            //一覧
            /*
                     private System.Windows.Forms.Label Singen;
        private System.Windows.Forms.Label SAIDAISINDO;
        private System.Windows.Forms.Label M_Depth;
        private System.Windows.Forms.Label Loading;
        private System.Windows.Forms.Label sindo;
        private System.Windows.Forms.Label YohouKeihou_Hou_Time;
        private System.Windows.Forms.Label Back;
        private System.Windows.Forms.Label Final;
        private System.Windows.Forms.Timer JsonTimer;
        private System.Windows.Forms.Label Version;
        private System.Windows.Forms.Label Tunami;


       .BackColor = System.Drawing.Color.FromArgb(0, 0, 0);

       .ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
             */













        }

        public class EEW_JSON
        {


            //nullになるとエラーになるのですべてstringです。
            //メッセージ
            public string Message { get; set; }
            //更新時刻
            public string Report_Time { get; set; }
            //震源名
            public string Region_name { get; set; }
            //キャンセルか *bool
            public string Is_cancel { get; set; }
            //深さ
            public string Depth { get; set; }
            //最大震度
            public string Calcintensity { get; set; }
            //最終報か *bool
            public string Is_final { get; set; }
            //訓練法か *bool
            public string Is_traning { get; set; }
            //マグニチュード*float
            public string Magunitude { get; set; }
            //報数
            public string Report_num { get; set; }
            //予報警報
            public string Alertflg { get; set; }

        }
    }

    // <auto-generated />
    //
    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using EEW_json;
    //
    //    var eewJson = EewJson.FromJson(jsonString);

    namespace EEW_json
    {
        using Newtonsoft.Json;
        using Newtonsoft.Json.Converters;
        using System;
        using System.Globalization;

        public partial class EEW_JSON
        {

            [JsonProperty("result")]
            public Result Result { get; set; }

            [JsonProperty("report_time")]
            public string ReportTime { get; set; }

            [JsonProperty("region_code")]
            public string RegionCode { get; set; }

            [JsonProperty("request_time")]
            public string RequestTime { get; set; }

            [JsonProperty("region_name")]
            public string RegionName { get; set; }

            [JsonProperty("longitude")]
            public string Longitude { get; set; }

            [JsonProperty("is_cancel")]
            public bool IsCancel { get; set; }

            [JsonProperty("depth")]
            public string Depth { get; set; }

            [JsonProperty("calcintensity")]
            public string Calcintensity { get; set; }

            [JsonProperty("is_final")]
            public bool IsFinal { get; set; }

            [JsonProperty("is_training")]
            public bool IsTraining { get; set; }

            [JsonProperty("latitude")]
            public string Latitude { get; set; }

            [JsonProperty("origin_time")]
            public string OriginTime { get; set; }

            [JsonProperty("security")]
            public Security Security { get; set; }

            [JsonProperty("magunitude")]
            public string Magunitude { get; set; }

            [JsonProperty("report_num")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long ReportNum { get; set; }

            [JsonProperty("request_hypo_type")]
            public string RequestHypoType { get; set; }

            [JsonProperty("report_id")]
            public string ReportId { get; set; }

            [JsonProperty("alertflg")]
            public string Alertflg { get; set; }
        }

        public partial class Result
        {
            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("is_auth")]
            public bool IsAuth { get; set; }
        }

        public partial class Security
        {
            [JsonProperty("realm")]
            public string Realm { get; set; }

            [JsonProperty("hash")]
            public string Hash { get; set; }
        }

        public partial class EewJson
        {
            public static EewJson FromJson(string json) => JsonConvert.DeserializeObject<EewJson>(json, EEW_json.Converter.Settings);
        }

        public static class Serialize
        {
            public static string ToJson(this EewJson self) => JsonConvert.SerializeObject(self, EEW_json.Converter.Settings);
        }

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }

        internal class ParseStringConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (long.TryParse(value, out long l))
                {
                    return l;
                }
                throw new Exception("Cannot unmarshal type long");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (long)untypedValue;
                serializer.Serialize(writer, value.ToString());
                return;
            }

            public static readonly ParseStringConverter Singleton = new ParseStringConverter();
        }
    }
}