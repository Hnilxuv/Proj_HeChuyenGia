using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieuCheHoaHoc
{
    internal class PhanUng
    {
        private List<ChatHoaHoc> veTrai;
        private List<ChatHoaHoc> vePhai;
        private string dieuKien;

        public PhanUng(List<ChatHoaHoc> veTrai, List<ChatHoaHoc> vePhai, string dieuKien) {
            this.veTrai = veTrai;
            this.vePhai = vePhai;
            this.dieuKien = dieuKien.Trim();
        }

        public PhanUng(string trithuc) {
            veTrai = new List<ChatHoaHoc>();
            vePhai = new List<ChatHoaHoc>();
            dieuKien = "";

            string[] str = trithuc.Split(' ');
            bool isVeTrai = true;
            for (int i = 0; i < str.Length; i++) {
                if (str[i].Length > 0) {
                    if (str[i][0] == '-') {
                        isVeTrai = false;
                        if (str[i].Length > 1) {
                            i++;
                            while (str[i] != ")") {
                                dieuKien += str[i] + " ";
                                i++;
                            }
                        }
                    }
                    else if (isVeTrai) {
                        veTrai.Add(new ChatHoaHoc(str[i]));
                    }
                    else {
                        vePhai.Add(new ChatHoaHoc(str[i]));
                    }
                }
            }
        }

        public override string ToString() {
            string s = "";
            for (int i = 0; i < veTrai.Count - 1; i++) {
                s += veTrai[i] + " + ";
            }
            s += veTrai[veTrai.Count - 1] + " ";
            s += "---";
            if (dieuKien != "") {
                s += " " + dieuKien + "---";
            }
            s += "> ";
            for (int i = 0; i < vePhai.Count - 1; i++) {
                s += vePhai[i] + " + ";
            }
            s += vePhai[vePhai.Count - 1];
            return s;
        }

        public List<ChatHoaHoc> GetChatHoaHocs() {
            List<ChatHoaHoc> l = new List<ChatHoaHoc>();
            l.AddRange(veTrai);
            l.AddRange(vePhai);
            return l;
        }

        public List<ChatHoaHoc> GetVeTrai() {
            return this.veTrai;
        }

        public List<ChatHoaHoc> GetVePhai() {
            return this.vePhai;
        }

        public string ToText() {
            string s = "";
            foreach (ChatHoaHoc chh in veTrai) {
                s += chh.ToString();
                s += " ";
            }
            s += "-";
            if (dieuKien != "") {
                s += "( " + dieuKien.Trim() + " )";
            }

            foreach (ChatHoaHoc chh in vePhai) {
                s += " ";
                s += chh.ToString();
            }
            return s;
        }

        public override bool Equals(object obj) {
            return obj is PhanUng ung && ung.ToText().ToLower() == this.ToText().ToLower();
        }
    }
}