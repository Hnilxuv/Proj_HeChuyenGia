using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieuCheHoaHoc
{
    internal class DataTriThuc
    {
        public static string triThucPath = @"D:\Project\tri_thuc.txt";
        private List<PhanUng> phanUngs;

        //lưu vào file
        public static void toFile(List<PhanUng> pus) {
            StreamWriter sw = new StreamWriter(triThucPath, true);
            foreach (PhanUng pu in pus) {
                sw.Write("\n" + pu.ToText());
            }
            sw.Close();
        }

        //xoá luật
        public static void toDelete(string luat)
        {
            string tempFile = Path.GetTempFileName();

            using (var sr = new StreamReader(triThucPath))
            using (var sw = new StreamWriter(tempFile))
            {
                int d = 0;
                int d2 = dem();
                string linee;
                while ((linee = sr.ReadLine()) != null)
                {
                    if (linee != luat)
                    {
                        if (d < d2 - 2)
                        {
                            //k phải dòng cuối
                            sw.WriteLine(linee);
                        }
                        else
                        {
                            //dòng cuối cùng
                            sw.Write(linee);
                        }
                        d++;
                    }
                }
            }
            File.Delete(triThucPath);
            File.Move(tempFile, triThucPath);
        }

        //đếm số luật trong file
        public static int dem()
        {
            StreamReader sr = new StreamReader(triThucPath);
            int d2 = 0;
            string linee2;
            while ((linee2 = sr.ReadLine()) != null)
            {
                d2++;
            }
            sr.Close();
            return d2;
        }

        public DataTriThuc() {
            // lay data tu file
            phanUngs = new List<PhanUng>();

            ArrayList list = new ArrayList();

            StreamReader sr = new StreamReader(triThucPath);
            while (!sr.EndOfStream) {
                list.Add(sr.ReadLine());
            }
            for (int i = 0; i < list.Count; i++)
            {
                int j = i + 1;
                while (j < list.Count)
                {
                    var vti = list[i].ToString().Split('-');
                    var vtj = list[j].ToString().Split('-');
                    var vtit = vti[1].Split(' ');
                    var vtjt = vtj[1].Split(' ');

                    int m = 1, n = 1;
                    while (vtit[0] == "(" && vtit[m] != ")" && m < vtit.Count() - 1)
                    {
                        vtit[0] += vtit[m];
                        m++;
                    }
                    while (vtjt[0] == "(" && vtjt[n] != ")" && n < vtjt.Count() - 1)
                    {
                        vtjt[0] += vtjt[n];
                        n++;
                    }
                    if (vti[0] + vtit[0] == vtj[0] + vtjt[0])
                    {
                        list[i] = list[i] + " " + vtj.Last().Split(' ').Last();
                        list.RemoveAt(j);
                    }
                    else
                    {
                        j++;
                        break;
                    }
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                phanUngs.Add(new PhanUng(list[i].ToString()));
            }
            sr.Close();
        }

        public List<ChatHoaHoc> GetChatHoaHocs() {
            List<ChatHoaHoc> chh = new List<ChatHoaHoc>();
            foreach (PhanUng phanUng in phanUngs) {
                chh.AddRange(phanUng.GetChatHoaHocs());
            }
            HashSet<ChatHoaHoc> setchh = new HashSet<ChatHoaHoc>(chh);
            chh = setchh.ToList();
            chh.Sort();
            return chh;
        }

        public List<PhanUng> GetPhanUngs() {
            return phanUngs;
        }
    }
}