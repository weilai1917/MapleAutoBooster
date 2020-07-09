using MapleAutoBooster.Abstract;
using MapleAutoBooster.ServiceAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace MapleAutoBooster.Service
{
    [ServiceType]
    [Description("矩形范围内找色")]
    public sealed class ColorFinderService : AbstractBoosterService
    {
        public const int FindWith = 170;

        private Rectangle FinderRec;
        private Point StartPoint;
        private Color FindColor;

        #region WIN
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left; //最左坐标
            public int Top; //最上坐标
            public int Right; //最右坐标
            public int Bottom; //最下坐标
        }
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
        #endregion

        public override List<Tuple<string, string>> SetDefaultOperations()
        {
            var defaultOp = new List<Tuple<string, string>>();
            defaultOp.Add(new Tuple<string, string>("0", "SetColor[255,0,0]"));
            defaultOp.Add(new Tuple<string, string>("0", "SetFinderRec[350,180]"));
            defaultOp.Add(new Tuple<string, string>("0", "SetMapleStartPoint[]"));
            defaultOp.Add(new Tuple<string, string>("1", "FindColorWork[500]"));
            return defaultOp;
        }

        [ServiceMethod]
        [Description("查找目标颜色是：{0}.{1}.{2}")]
        public void SetColor(string r, string g, string b)
        {
            FindColor = Color.FromArgb(Convert.ToInt32(r), Convert.ToInt32(g), Convert.ToInt32(b));
        }

        [ServiceMethod]
        [Description("查找区域范围是：[{0},{1}]")]
        public void SetFinderRec(string w, string h)
        {
            FinderRec = new Rectangle(0, 0, Convert.ToInt32(w), Convert.ToInt32(h));
        }

        [ServiceMethod]
        [Description("查找区域起点是：[]")]
        public void SetMapleStartPoint()
        {
            RECT rect = new RECT();
            GetWindowRect(FindWindow("MapleStoryClass", "MapleStory"), ref rect);
            StartPoint = new Point(rect.Left, rect.Top);
        }

        [ServiceMethod]
        [Description("以起点[{0},{1}]，在[{2},{3}]范围内，找目标RGB:{4}.{5}.{6}颜色")]
        public void FindColorWork(string sleepTime)
        {
            Bitmap bitmap = new Bitmap(FinderRec.Width + FindWith, FinderRec.Height, PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(StartPoint.X, StartPoint.Y, FindWith - 5, -5, new Size(FinderRec.Width + FindWith, FinderRec.Height), CopyPixelOperation.SourceCopy);
            }
            for (int i = FindWith; i < FinderRec.Width + FindWith; i++)
            {
                for (int j = 0; j < FinderRec.Height; j++)
                {
                    Color sample = new Color();
                    sample = bitmap.GetPixel(i, j);
                    if (FindColor.R == sample.R
                        && FindColor.B == sample.B
                        && FindColor.G == sample.G)
                    {
                        throw new OperationCanceledException($"目标颜色{FindColor.ToString()}已找到。");
                    }
                }
            }
            //bitmap.Save("D:\\ASD.jpg");
            Thread.Sleep(Convert.ToInt32(sleepTime));
        }

    }
}
