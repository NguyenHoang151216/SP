using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUCE_DALTUDXD_LOP30_2026_0176667.Model
{
    public class TinhToanCotThep
    {
        // Liên kết với các model khác
        public MongDon MongDon { get; set; }
        public DuLieuDat DuLieuDat { get; set; }
        public SucChiuTai SucChiuTai { get; set; }

        // Dữ liệu đầu vào
        public double Pong { get; set; } // Áp lực tiêu chuẩn (T/m²)
        public double Bng { get; set; }  // Chiều rộng ngắn móng (m)    
        public double Lng { get; set; }  // Chiều dài móng (m)



        // Thông số vật liệu
        public double Rs { get; set; } = 280; // Cường độ thép (MPa) - giá trị mặc định
        public double Ho { get; set; } = 0.05; // Khoảng cách từ mép đến trọng tâm cốt thép (m)

        // Tính toán theo phương cạnh dài
        public double Mlng { get; set; }    // Momen theo phương dài (T.m)
        public double FaYeuCauDai { get; set; } // Diện tích cốt thép yêu cầu theo phương dài (mm²)

        // Tính toán theo phương cạnh ngắn  
        public double Mbng { get; set; }     // Momen theo phương ngắn (T.m)
        public double FaYeuCauNgan { get; set; } // Diện tích cốt thép yêu cầu theo phương ngắn (mm²)


        public static TinhToanCotThep ThongTinCt { get; set; }

    }
}