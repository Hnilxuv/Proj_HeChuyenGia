using System;
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

        public static void toFile(List<PhanUng> pus) {
            StreamWriter sw = new StreamWriter(triThucPath);
            foreach (PhanUng pu in pus) {
                sw.WriteLine(pu.ToText());
            }
            sw.Close();
        }

        public DataTriThuc() {
            // lay data tu file
            phanUngs = new List<PhanUng>();

            StreamReader sr = new StreamReader(triThucPath);
            while (!sr.EndOfStream) {
                phanUngs.Add(new PhanUng(sr.ReadLine()));
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