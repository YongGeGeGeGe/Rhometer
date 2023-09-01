using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rheometer_Torque.UserControls
{
    public partial class Dashboard4 : UserControl
    {
        private float _value = 26;
        private float _valueMin = 0;
        private float _valueMax = 30;
        private float _safeValue = 25;
        private string _unitString = "单位";

        public float Value { get { return _value; } set { _value = value; this.Refresh(); } }
        public float ValueMin { get { return _valueMin; } set { _valueMin = value; this.Refresh(); } }
        public float SafeValue { get { return _safeValue; } set { _safeValue = value; this.Refresh(); } }
        public float ValueMax { get { return _valueMax; } set { _valueMax = value; this.Refresh(); } }
        public string UnitString { get { return _unitString; } set { _unitString = value; this.Refresh(); } }

        public Dashboard4()
        {
            InitializeComponent();
        }

        private void Dashboard4_Load(object sender, EventArgs e)
        {

        }

        private void Dashboard4_Paint(object sender, PaintEventArgs e)
        {
            //清除
            e.Graphics.Clear(Color.White);

            //表盘
            var globalRect = e.ClipRectangle;

            var globalSquareX = globalRect.X;
            var globalSquareY = globalRect.Y;

            var globalSquareWidth = globalRect.Width;

            if (globalRect.Width < globalRect.Height)
            {
                globalSquareWidth = globalRect.Width;
                globalSquareY += (globalRect.Height - globalRect.Width) / 2;
            }
            if (globalRect.Height < globalRect.Width)
            {
                globalSquareWidth = globalRect.Height;
                globalSquareX += (globalRect.Width - globalRect.Height) / 2;
            }


            var globalSquare = new Rectangle(globalSquareX, globalSquareY, globalSquareWidth, globalSquareWidth);
            var globalSquareContent = new Rectangle(globalSquareX + 6, globalSquareY + 6, globalSquareWidth - 12, globalSquareWidth - 12);
            e.Graphics.FillEllipse(Brushes.Gray, globalSquare);
            e.Graphics.FillEllipse(Brushes.Black, globalSquareContent);

            //绘制表盘刻度  使用线条
            var scaleColor = Color.White;
            var scaleBrush = new SolidBrush(scaleColor);
            var scalePen = new Pen(scaleColor);
            var scalePenBig = new Pen(scaleColor) { Width = 3 };

            var X0 = globalSquareX + globalSquareWidth / 2;
            var Y0 = globalSquareY + globalSquareWidth / 2;

            var R0 = (globalSquareWidth / 2) - 6;
            var R1 = R0 - 16;

            var R2 = R0 - 26;


            //先绘制指针
            {
                //绘制指针
                var pointerColor = Color.GreenYellow;
                var pointerBrush = new SolidBrush(pointerColor);
                var pointerPen = new Pen(pointerColor);
                var pointerPenBG = new Pen(Color.DarkGreen);

                var R3 = R0 - 36;
                var R4 = R0 - 42;
                //背景
                List<PointF> points = new List<PointF>();

                //for (int i = -450; i <= 90; i++)
                //{

                //    if (i % 10 == 0)
                //    {
                //        var jiaodu = i / 360f * Math.PI;
                //        var X1 = X0 + R3 * Math.Cos(jiaodu);
                //        var Y1 = Y0 + R3 * Math.Sin(jiaodu);
                //        points.Add(new PointF((float)X1, (float)Y1));
                //    }

                //}
                //for (int i = 90; i >= -450; i--)
                //{

                //    if (i % 10 == 0)
                //    {
                //        var jiaodu = i / 360f * Math.PI;
                //        var X2 = X0 + R4 * Math.Cos(jiaodu);
                //        var Y2 = Y0 + R4 * Math.Sin(jiaodu);
                //        points.Add(new PointF((float)X2, (float)Y2));
                //    }

                //}
                //e.Graphics.DrawPolygon(pointerPenBG, points.ToArray());
                //前景
                points.Clear();
                var bili = (float)(Value - ValueMin) / (ValueMax - ValueMin);
                var min = -450;
                var max = 90;
                var value = min + bili * (max - min);

                for (int i = min; i <= value; i++)
                {

                    if (i % 1 == 0)
                    {
                        var jiaodu = i / 360f * Math.PI;
                        var X1 = X0 + R0 * Math.Cos(jiaodu);
                        var Y1 = Y0 + R0 * Math.Sin(jiaodu);
                        points.Add(new PointF((float)X1, (float)Y1));
                    }

                }
                for (int i = (int)value; i >= min; i--)
                {

                    if (i % 1 == 0)
                    {
                        var jiaodu = i / 360f * Math.PI;
                        var X2 = X0 + R3 * Math.Cos(jiaodu);
                        var Y2 = Y0 + R3 * Math.Sin(jiaodu);
                        points.Add(new PointF((float)X2, (float)Y2));
                    }

                }
                e.Graphics.FillPolygon(pointerBrush, points.ToArray());
                //安全值
                if (Value > SafeValue)
                {

                    var pointerSafeColor = Color.Red;
                    var pointerSafeBrush = new SolidBrush(pointerSafeColor);
                    var pointerSafePen = new Pen(pointerSafeColor);
                    var pointerSafePenBG = new Pen(pointerSafeColor);

                    var safeValueMin = SafeValue;
                    var safeValueMax = Value;

                    points.Clear();
                    var safemin = -450;
                    var safemax = 90;
                    safemin = (int)(value - 540 * (Value - SafeValue) / (ValueMax - ValueMin));

                    for (int i = safemin; i <= value; i++)
                    {

                        if (i % 1 == 0)
                        {
                            var jiaodu = i / 360f * Math.PI;
                            var X1 = X0 + R0 * Math.Cos(jiaodu);
                            var Y1 = Y0 + R0 * Math.Sin(jiaodu);
                            points.Add(new PointF((float)X1, (float)Y1));
                        }

                    }
                    for (int i = (int)value; i >= safemin; i--)
                    {

                        if (i % 1 == 0)
                        {
                            var jiaodu = i / 360f * Math.PI;
                            var X2 = X0 + R3 * Math.Cos(jiaodu);
                            var Y2 = Y0 + R3 * Math.Sin(jiaodu);
                            points.Add(new PointF((float)X2, (float)Y2));
                        }

                    }
                    e.Graphics.FillPolygon(pointerSafeBrush, points.ToArray());
                }


                //绘制指针2
                {
                    e.Graphics.FillEllipse(Brushes.Blue, X0 - 6, Y0 - 6, 12, 12);
                    var R5 = R0 - 42;
                    var jiaodu = value / 360f * Math.PI;
                    var X1 = X0 + R5 * Math.Cos(jiaodu);
                    var Y1 = Y0 + R5 * Math.Sin(jiaodu);
                    e.Graphics.DrawLine(new Pen(Color.Blue, 3), new PointF(X0, Y0), new PointF((float)X1, (float)Y1));
                }

            }
            //再绘制刻度
            for (int i = -450; i <= 90; i++)
            {

                if (i % 4.5 == 0)
                {
                    var jiaodu = i / 360f * Math.PI;
                    var X1 = X0 + R0 * Math.Cos(jiaodu);
                    var Y1 = Y0 + R0 * Math.Sin(jiaodu);
                    var X2 = X0 + R1 * Math.Cos(jiaodu);
                    var Y2 = Y0 + R1 * Math.Sin(jiaodu);
                    e.Graphics.DrawLine(scalePen, (float)X1, (float)Y1, (float)X2, (float)Y2);
                }

                if (i % 45 == 0)
                {
                    var jiaodu = i / 360f * Math.PI;
                    var X1 = X0 + R0 * Math.Cos(jiaodu);
                    var Y1 = Y0 + R0 * Math.Sin(jiaodu);
                    var X2 = X0 + R2 * Math.Cos(jiaodu);
                    var Y2 = Y0 + R2 * Math.Sin(jiaodu);
                    e.Graphics.DrawLine(scalePenBig, (float)X1, (float)Y1, (float)X2, (float)Y2);
                }
            }







            //绘制单位
            var sizeStringDW = e.Graphics.MeasureString("单位", SystemFonts.DefaultFont);
            e.Graphics.DrawString(this.UnitString, SystemFonts.DefaultFont, Brushes.White, X0 - sizeStringDW.Width / 2, Y0 - sizeStringDW.Height / 2 + 30);

            //绘制值
            var sizeString = e.Graphics.MeasureString("值", this.Font);
            e.Graphics.DrawString("值", this.Font, Brushes.White, X0 - sizeString.Width / 2, Y0 - sizeString.Height / 2 + 45);


            //绘制箭头
            //e.Graphics.FillPolygon(pointerBrush, new PointF[] { });
        }
    }
}
