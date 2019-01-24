using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace LineGraphTest
{
    public partial class LineChartControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("<B><Font color = '##4a235a'>&nbsp;&nbsp; The Defect comparison Chart January Vs February (2018) for the Maersk run and support apps - A POC for cloud migration and Morderization (POC4)</font></B>");
            DrawChart();
            Response.Write("<br><I>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;- A demo by IBM cloud innovation team, Maersk Account</I></br>");
            Response.Write("<br> &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<B><Font color = '#ca5236'> X-Axis --> Number of defects </B>(Blue line refers to January and Brown line refers to Feb 2018)</forn><br>");
            Response.Write("<br> &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<B><Font color = '#1d8f90'> Y-Axis --> MaerskLine Application Names</B></forn><br>");

        }

        public void DrawChart()
        {
            DataSet ds = new DataSet();

            foreach (DataTable dataTable in ds.Tables)
                dataTable.BeginLoadData();

            String FilePath ="";

            //FilePath = Server.MapPath()

            ds.ReadXml("C:\\LineGraphTest\\Barchart.xml");
            DataTable ChartData = ds.Tables[0];

            string[] XPointMember = new string[ChartData.Rows.Count];
            int[] YPointMember = new int[ChartData.Rows.Count];

            for (int count = 0; count < ChartData.Rows.Count; count++)
            {
                //storing Values for X axis   
                XPointMember[count] = ChartData.Rows[count]["Over"].ToString();
                //storing values for Y Axis   
                YPointMember[count] = Convert.ToInt32(ChartData.Rows[count]["Run"]);

            }

            //binding chart control   
            Graph.Series[0].Points.DataBindXY(XPointMember, YPointMember);

            //Setting width of line   

            Graph.Series[0].BorderWidth = 1;
            Graph.Series[0].IsValueShownAsLabel = true;
            //setting Chart type    
            //LineChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType;
            Graph.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Bar;
            // Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;   
            // Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;   
            //  Chart1.Series[0].ChartType = SeriesChartType.Spline;   
            //Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;  
            Graph.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            Graph.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            //Graph.ChartAreas["ChartArea1"].AxisY.CustomLabels.Add("teess");


            DataSet ds1 = new DataSet();

            foreach (DataTable dataTable in ds1.Tables)
                dataTable.BeginLoadData();
            ds1.ReadXml("C:\\LineGraphTest\\Barchart1.xml");
            DataTable ChartData1 = ds1.Tables[0];

            string[] XPointMember1 = new string[ChartData1.Rows.Count];
            int[] YPointMember1 = new int[ChartData1.Rows.Count];

            for (int count = 0; count < ChartData1.Rows.Count; count++)
            {
                //storing Values for X axis   
                XPointMember[count] = ChartData1.Rows[count]["Over"].ToString();
                //storing values for Y Axis   
                YPointMember[count] = Convert.ToInt32(ChartData1.Rows[count]["Run"]);

            }

            //binding chart control   
            Graph.Series[1].Points.DataBindXY(XPointMember, YPointMember);
            Graph.Series[1].BorderWidth = 1;
            Graph.Series[1].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Bar;
            //Graph.Series[1].Color = Red; 
            Graph.Series[1].IsValueShownAsLabel = true;
            Graph.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            Graph.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
        }
    }
}