using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace HUCE_DALTUDXD_LOP30_2026_0176667.Model
{
    public class DuLieuDat
    {
        public DuLieuDat()
        {
            DanhSachMong = new ObservableCollection<MongDon>();
        }

        public int IdDat { get; set; }
        public string LoaiDat { get; set; }
        public string TrangThai { get; set; }
        public double GocMaSat { get; set; }
        public double ModunNenEp { get; set; }
        public double LucDinh { get; set; }
        public double DungTrong { get; set; }

        public double ChieuDay { get; set; }
        public ObservableCollection<MongDon> DanhSachMong { get; set; }
        public MongDon MongDangTinhToan { get; set; }

        public string TenHienThi
        {
            get
            {
                var tenLoaiDat = string.IsNullOrWhiteSpace(LoaiDat) ? "Lớp đất" : LoaiDat;
                var trangThai = string.IsNullOrWhiteSpace(TrangThai) ? string.Empty : $" - {TrangThai}";
                return IdDat > 0 ? $"Lớp {IdDat}: {tenLoaiDat}{trangThai}" : tenLoaiDat;
            }
        }

        public static ObservableCollection<DuLieuDat> ThongTinDat { get; set; } = new ObservableCollection<DuLieuDat>();
        public static DuLieuDat DatDangChon { get; set; }

        public static DuLieuDat LayDatDangChon()
        {
            return DatDangChon ?? ThongTinDat.FirstOrDefault();
        }

        public MongDon LayMongDangTinhToan()
        {
            return MongDangTinhToan ?? DanhSachMong.FirstOrDefault();
        }
    }
}
