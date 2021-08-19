using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieuCheHoaHoc
{
    internal class ChatHoaHoc : IComparable<ChatHoaHoc>
    {
        private string name;

        public ChatHoaHoc(string name) {
            this.name = name;
        }

        public int CompareTo(ChatHoaHoc other) {
            return this.ToString().ToLower().CompareTo(other.ToString().ToLower());
        }

        public override bool Equals(object obj) {
            return obj is ChatHoaHoc &&
                   name.ToLower() == (obj as ChatHoaHoc).name.ToLower();
        }

        public override int GetHashCode() {
            return 363513814 + EqualityComparer<string>.Default.GetHashCode(name);
        }

        public override string ToString() {
            return name;
        }
    }
}