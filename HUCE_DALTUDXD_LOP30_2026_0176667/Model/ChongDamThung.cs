using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUCE_DALTUDXD_LOP30_2026_0176667.Model
{
    public class ChongDamThung
    {
        public MongDon MongDon { get; set; }
        public DuLieuDat DuLieuDat { get; set; }

        // Thông số đầu vào
        public float ChieuDayLopBaoVe { get; set; }  // cm

        public float h0 { get; set; }           // chiều cao làm việc (cm)

        // Kết quả tính toán
        public double Pomax { get; set; } // Phản lực đất đáy móng max (T/m²)
        public double Pomin { get; set; } // Phản lực đất đáy móng min (T/m²)

        public double Po { get; set; }
        public double Pot { get; set; }
        public double Pdt { get; set; }   // Áp lực đâm thủng (T)
        public double Pcdt { get; set; }  // Lực chống đâm thủng (T)

        // Các hệ số trung gian
        public double Ldt { get; set; }          // chu vi tiết diện nguy hiểm

        public string CheckResult { get; set; } = string.Empty;


        public static ChongDamThung ThongTinCdt { get; set; } = null!;

    }
}
