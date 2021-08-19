using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieuCheHoaHoc
{
    internal class PhanUngComparer : IComparer<PhanUng>
    {
        private Dictionary<ChatHoaHoc, int> cmp;
        private ChatHoaHoc chh;

        public PhanUngComparer(Dictionary<ChatHoaHoc, int> d, ChatHoaHoc c) {
            cmp = d;
            chh = c;
        }

        public int Compare(PhanUng x, PhanUng y) {
            List<ChatHoaHoc> vpx = x.GetVePhai();
            List<ChatHoaHoc> vpy = y.GetVePhai();
            int bx = cmp[vpx[0]];
            for (int i = 1; i < vpx.Count; i++) {
                bx = Math.Min(cmp[vpx[i]], bx);
            }
            int by = cmp[vpy[0]];
            for (int i = 1; i < vpy.Count; i++) {
                by = Math.Min(cmp[vpy[i]], by);
            }
            return bx - by;
        }
    }
}