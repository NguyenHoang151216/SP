using System;

namespace HUCE_DALTUDXD_LOP30_2026_0176667.Model
{
    public class MongDon
    {
        public int IdMong { get; set; }
        public string TenMong { get; set; }
        public float N { get; set; }
        public float Q { get; set; }
        public float Momen { get; set; }
        public float chieuRongCot { get; set; }
        public float chieuDaiCot { get; set; }
        public string macBeTong { get; set; }
        public string macThep { get; set; }
        public float cuongDoBeTong { get; set; }
        public float cuongDoThep { get; set; }
        public float chieuDaiMong { get; set; }
        public float chieuRongMong { get; set; }
        public float chieuCaoMong { get; set; }

        public float chieuSauChonMong { get; set; }
        public DuLieuDat LopDat { get; set; }

        // Constructor
        public MongDon()
        {
            TenMong = string.Empty;
        }

        public string TenHienThi
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(TenMong))
                    return TenMong;

                return IdMong > 0 ? $"Mong {IdMong}" : "Mong moi";
            }
        }

        public static MongDon ThongTinMong { get; set; }
        public static MongDon MongDangChon { get; set; }

        public static MongDon LayMongDangChon()
        {
            return MongDangChon
                ?? ThongTinMong
                ?? HUCE_DALTUDXD_LOP30_2026_0176667.Model.DuLieuDat.LayDatDangChon()?.LayMongDangTinhToan();
        }

        public DuLieuDat LayLopDatTinhToan()
        {
            return LopDat ?? HUCE_DALTUDXD_LOP30_2026_0176667.Model.DuLieuDat.LayDatDangChon();
        }
    }
}
