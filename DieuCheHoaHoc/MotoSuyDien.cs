using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieuCheHoaHoc
{
    internal class MotoSuyDien
    {
        private List<PhanUng> tapLuat;
        private List<ChatHoaHoc> allChatHoaHoc;
        private Dictionary<ChatHoaHoc, List<ChatHoaHoc>> fpg;

        public MotoSuyDien(DataTriThuc dt) {
            this.tapLuat = dt.GetPhanUngs();
            this.allChatHoaHoc = dt.GetChatHoaHocs();
            fpg = new Dictionary<ChatHoaHoc, List<ChatHoaHoc>>();
            foreach (PhanUng pu in tapLuat) {
                foreach (ChatHoaHoc dich in pu.GetVePhai()) {
                    foreach (ChatHoaHoc nguon in pu.GetVeTrai()) {
                        if (!fpg.ContainsKey(dich)) {
                            fpg[dich] = new List<ChatHoaHoc>();
                        }
                        fpg[dich].Add(nguon);
                    }
                }
            }
        }

        /// <summary>
        /// lấy ra bậc của các chất theo đồ thị fpg đã xây được
        /// </summary>
        /// <returns></returns>
        public Dictionary<ChatHoaHoc, int> getHeuristic(ChatHoaHoc root) {
            // lay ra bac cua cac chat
            Dictionary<ChatHoaHoc, int> bac = new Dictionary<ChatHoaHoc, int>();
            Dictionary<ChatHoaHoc, bool> visited = new Dictionary<ChatHoaHoc, bool>();

            //bfs tu root
            BFS(root, 0);

            void BFS(ChatHoaHoc r, int n) {
                bac[r] = n;
                visited[r] = true;
                if (fpg.ContainsKey(r)) {
                    foreach (ChatHoaHoc chh in fpg[r]) {
                        if (!visited.ContainsKey(chh)) {
                            BFS(chh, n + 1);
                        }
                    }
                }
            }

            //tat ca cac chat khong co bac se co bac la vo cung
            foreach (ChatHoaHoc chh in allChatHoaHoc) {
                if (!visited.ContainsKey(chh)) {
                    bac[chh] = 100000;
                }
            }

            return bac;
        }

        /// <summary>
        /// chuỗi các phản ứng để từ chatHoaHocs tạo thành chatCanDieuChe
        /// </summary>
        /// <returns></returns>
        public List<PhanUng> suyDien(HashSet<ChatHoaHoc> chatHoaHocs, ChatHoaHoc chatCanDieuChe) {
            // su dung data tri thuc de thuc hien suy dien tien
            List<PhanUng> kq = new List<PhanUng>(); //kq là những luật được sử dụng đẻ suy diễn
            HashSet<ChatHoaHoc> tg = chatHoaHocs; //TG
            C5.IntervalHeap<PhanUng> sat = new C5.IntervalHeap<PhanUng>(new PhanUngComparer(getHeuristic(chatCanDieuChe), chatCanDieuChe)); //SAT
            Dictionary<PhanUng, bool> visited = new Dictionary<PhanUng, bool>();

            while (!tg.Contains(chatCanDieuChe)) {
                // them vao SAT cac luat co the su dung den hien tai
                foreach (PhanUng pu in tapLuat) { 
                    bool ok = true;
                    //xét các chất trong TG phù hợp với luật nào
                    foreach (ChatHoaHoc chh in pu.GetVeTrai()) { 
                        if (!tg.Contains(chh)) {
                            ok = false;
                            break;
                        }
                    }
                    //Nếu luật đó phù hợp và chưa được thêm
                    if (ok && !visited.ContainsKey(pu)) {
                        // thêm luật vào SAT
                        sat.Add(pu);
                        //đánh dấu đã được thêm
                        visited[pu] = true;
                    }
                }

                //Nếu tập SAT hết luật thì dừng
                if (sat.Count == 0) {
                    break;
                }

                // Lấy ra luật được chọn để dùng
                PhanUng duocChon = sat.DeleteMin();
                kq.Add(duocChon);
                foreach (ChatHoaHoc chh in duocChon.GetVePhai()) {
                    tg.Add(chh);
                }
            }

            if (tg.Contains(chatCanDieuChe)) {
                return kq;
            }
            else {
                return new List<PhanUng>();
            }
        }
    }
}