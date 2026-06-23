using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUCE_DALTUDXD_LOP30_2026_0176667.Model
{
    public class SucChiuTai
    {
        public static SucChiuTai? ThongTinSucChiuTai { get; set; }

        public MongDon MongDon { get; set; }

        public DuLieuDat DuLieuDat { get; set; }

        public double Alpha1 { get; set; }
        public double Alpha2 { get; set; } = 1;
        public double Alpha3 { get; set; }
        public double Ngamma { get; set; }

        public double Nq { get; set; }
        public double Nc { get; set; }

        public double Fs = 0;


        public double Rd { get; set; }
        public double Ptx { get; set; }
        public double Pmax { get; set; }
        public double Pmin { get; set; }
    }
}
