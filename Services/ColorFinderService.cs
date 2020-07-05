using MapleAutoBooster.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace MapleAutoBooster.Service
{
    public sealed class ColorFinderService : AbstractService
    {
        public const int FindWith = 170;

        private Rectangle FinderRec;
        private Point StartPoint;
        private Color FindColor;

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

        public override void SetDefaultOperations()
        {
            List<Tuple<string, string>> defaultOp = new List<Tuple<string, string>>();
            defaultOp.Add(new Tuple<string, string>("0", "SetColor-255,0,0"));
            defaultOp.Add(new Tuple<string, string>("0", "SetFinderRec-350,180"));
            defaultOp.Add(new Tuple<string, string>("0", "SetMapleStartPoint"));

            defaultOp.Add(new Tuple<string, string>("1", "FindColorWork-500"));

            foreach (var operations in defaultOp.GroupBy(x => x.Item1))
            {
                var opObject = new OperateObject();
                opObject.OperateId = Guid.NewGuid().ToString();
                opObject.OperateTarget = operations.Key;
                opObject.Operations = new List<IOperation>();
                foreach (var item in operations)
                {
                    opObject.Operations.Add(new Operation(item.Item2));
                }
                this.Operations.Add(opObject);
            }
        }

        public string SetColor(string colorTxt)
        {
            string[] rgb = colorTxt.Split(',');
            if (rgb.Length < 3)
                throw new Exception("无法识别的颜色");
            FindColor = Color.FromArgb(Convert.ToInt32(rgb[0]), Convert.ToInt32(rgb[1]), Convert.ToInt32(rgb[2]));
            return $"查找目标颜色是：{FindColor.R}.{FindColor.G}.{FindColor.B}";
        }

        public string SetFinderRec(string recTxt)
        {
            string[] rec = recTxt.Split(',');
            if (rec.Length < 2)
                throw new Exception("无法识别的矩形");
            FinderRec = new Rectangle(0, 0, Convert.ToInt32(rec[0]), Convert.ToInt32(rec[1]));
            return $"查找区域范围是：[{FinderRec.Width},{FinderRec.Height}]";
        }

        public string SetMapleStartPoint()
        {
            RECT rect = new RECT();
            GetWindowRect(FindWindow("MapleStoryClass", "MapleStory"), ref rect);
            StartPoint = new Point(rect.Left, rect.Top);
            return $"查找区域起点是：[{StartPoint.X},{StartPoint.Y}]";
        }

        public string FindColorWork(string sleepTime)
        {
            if (Runtime)
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
            return $"以起点[{StartPoint.X},{StartPoint.Y}]，在[{FinderRec.Width},{FinderRec.Height}]范围内，找目标RGB:{FindColor.R}.{FindColor.G}.{FindColor.B}颜色";
        }

    }
}
