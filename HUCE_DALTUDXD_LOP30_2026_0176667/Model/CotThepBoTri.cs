using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUCE_DALTUDXD_LOP30_2026_0176667.Model
{
    public class CotThepBoTri
    {
        public MongDon MongDon { get; set; }

        public DuLieuDat DuLieuDat { get; set; }



        public double DuongKinhThepDai { get; set; } // mm
        public double SoLuongThepDai { get; set; }
        public double KhoangCachThepDai { get; set; } // mm
        public double DienTichThepDai { get; set; } // mm²


        public double DuongKinhThepNgan { get; set; } // mm
        public double SoLuongThepNgan { get; set; }
        public double KhoangCachThepNgan { get; set; } // mm
        public double DienTichThepNgan { get; set; } // mm²


        public static CotThepBoTri ThongTinBoTri { get; set; } = null!;

    }
}
