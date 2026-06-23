using System;
using System.Collections.Generic;
using System.Linq;

namespace HUCE_DALTUDXD_LOP30_2026_0176667.Commands
{
    public class HeSoTraCuu
    {
        public class HeSoTinhToan
        {
            public double Ngamma { get; set; }
            public double Nq { get; set; }
            public double Nc { get; set; }
        }

        // Bảng tra cứu hệ số theo góc ma sát (Bảng Terzaghi)
        private static readonly Dictionary<double, HeSoTinhToan> BangTraCuu = new Dictionary<double, HeSoTinhToan>
        {
            { 0, new HeSoTinhToan { Ngamma = 0.0, Nq = 1.0, Nc = 5.7 } },
            { 1, new HeSoTinhToan { Ngamma = 0.1, Nq = 1.1, Nc = 6.0 } },
            { 2, new HeSoTinhToan { Ngamma = 0.2, Nq = 1.2, Nc = 6.3 } },
            { 3, new HeSoTinhToan { Ngamma = 0.3, Nq = 1.3, Nc = 6.6 } },
            { 4, new HeSoTinhToan { Ngamma = 0.4, Nq = 1.5, Nc = 7.0 } },
            { 5, new HeSoTinhToan { Ngamma = 0.5, Nq = 1.6, Nc = 7.3 } },
            { 6, new HeSoTinhToan { Ngamma = 0.6, Nq = 1.8, Nc = 7.7 } },
            { 7, new HeSoTinhToan { Ngamma = 0.7, Nq = 2.0, Nc = 8.2 } },
            { 8, new HeSoTinhToan { Ngamma = 0.9, Nq = 2.2, Nc = 8.6 } },
            { 9, new HeSoTinhToan { Ngamma = 1.0, Nq = 2.4, Nc = 9.1 } },
            { 10, new HeSoTinhToan { Ngamma = 1.2, Nq = 2.7, Nc = 9.6 } },
            { 11, new HeSoTinhToan { Ngamma = 1.4, Nq = 3.0, Nc = 10.2 } },
            { 12, new HeSoTinhToan { Ngamma = 1.6, Nq = 3.3, Nc = 10.8 } },
            { 13, new HeSoTinhToan { Ngamma = 1.9, Nq = 3.6, Nc = 11.4 } },
            { 14, new HeSoTinhToan { Ngamma = 2.2, Nq = 4.0, Nc = 12.1 } },
            { 15, new HeSoTinhToan { Ngamma = 2.5, Nq = 4.4, Nc = 12.9 } },
            { 16, new HeSoTinhToan { Ngamma = 2.9, Nq = 4.9, Nc = 13.7 } },
            { 17, new HeSoTinhToan { Ngamma = 3.4, Nq = 5.5, Nc = 14.6 } },
            { 18, new HeSoTinhToan { Ngamma = 3.9, Nq = 6.0, Nc = 15.5 } },
            { 19, new HeSoTinhToan { Ngamma = 4.4, Nq = 6.7, Nc = 16.6 } },
            { 20, new HeSoTinhToan { Ngamma = 5.0, Nq = 7.4, Nc = 17.7 } },
            { 21, new HeSoTinhToan { Ngamma = 5.6, Nq = 8.3, Nc = 18.9 } },
            { 22, new HeSoTinhToan { Ngamma = 6.4, Nq = 9.2, Nc = 20.3 } },
            { 23, new HeSoTinhToan { Ngamma = 7.2, Nq = 10.2, Nc = 21.7 } },
            { 24, new HeSoTinhToan { Ngamma = 8.3, Nq = 11.4, Nc = 23.4 } },
            { 25, new HeSoTinhToan { Ngamma = 9.7, Nq = 12.7, Nc = 25.1 } },
            { 26, new HeSoTinhToan { Ngamma = 11.4, Nq = 14.2, Nc = 27.1 } },
            { 27, new HeSoTinhToan { Ngamma = 13.3, Nq = 15.9, Nc = 29.2 } },
            { 28, new HeSoTinhToan { Ngamma = 15.4, Nq = 17.8, Nc = 31.6 } },
            { 29, new HeSoTinhToan { Ngamma = 17.6, Nq = 20.0, Nc = 34.2 } },
            { 30, new HeSoTinhToan { Ngamma = 19.7, Nq = 22.5, Nc = 37.2 } },
            { 31, new HeSoTinhToan { Ngamma = 21.8, Nq = 25.3, Nc = 40.4 } },
            { 32, new HeSoTinhToan { Ngamma = 24.5, Nq = 28.5, Nc = 44.0 } },
            { 33, new HeSoTinhToan { Ngamma = 28.4, Nq = 32.2, Nc = 48.1 } },
            { 34, new HeSoTinhToan { Ngamma = 34.1, Nq = 36.5, Nc = 52.6 } },
            { 35, new HeSoTinhToan { Ngamma = 42.4, Nq = 41.4, Nc = 57.8 } },
            { 36, new HeSoTinhToan { Ngamma = 53.5, Nq = 47.2, Nc = 63.5 } },
            { 37, new HeSoTinhToan { Ngamma = 66.3, Nq = 53.8, Nc = 70.1 } },
            { 38, new HeSoTinhToan { Ngamma = 79.4, Nq = 61.5, Nc = 77.5 } },
            { 39, new HeSoTinhToan { Ngamma = 91.2, Nq = 70.6, Nc = 86.0 } },
            { 40, new HeSoTinhToan { Ngamma = 100.4, Nq = 81.3, Nc = 95.7 } },
            { 41, new HeSoTinhToan { Ngamma = 107.3, Nq = 93.8, Nc = 106.8 } },
            { 42, new HeSoTinhToan { Ngamma = 120.3, Nq = 108.8, Nc = 119.7 } },
            { 43, new HeSoTinhToan { Ngamma = 149.5, Nq = 126.5, Nc = 134.6 } },
            { 44, new HeSoTinhToan { Ngamma = 205.2, Nq = 147.7, Nc = 151.9 } },
            { 45, new HeSoTinhToan { Ngamma = 297.5, Nq = 173.3, Nc = 172.3 } },
            { 46, new HeSoTinhToan { Ngamma = 432.3, Nq = 204.2, Nc = 196.2 } },
            { 47, new HeSoTinhToan { Ngamma = 598.4, Nq = 241.8, Nc = 224.5 } },
            { 48, new HeSoTinhToan { Ngamma = 780.1, Nq = 287.9, Nc = 258.3 } },
            { 49, new HeSoTinhToan { Ngamma = 961.8, Nq = 344.6, Nc = 298.7 } },
            { 50, new HeSoTinhToan { Ngamma = 1127.9, Nq = 415.1, Nc = 347.5 } }
        };

        public static HeSoTinhToan LayHeSoTheoGocMaSat(double gocMaSat)
        {
            // Tìm hệ số chính xác
            if (BangTraCuu.ContainsKey(gocMaSat))
            {
                return BangTraCuu[gocMaSat];
            }

            // Nội suy tuyến tính nếu không có giá trị chính xác
            var cacGoc = BangTraCuu.Keys.OrderBy(x => x).ToList();

            if (gocMaSat <= cacGoc.First())
                return BangTraCuu[cacGoc.First()];

            if (gocMaSat >= cacGoc.Last())
                return BangTraCuu[cacGoc.Last()];

            // Tìm hai điểm gần nhất để nội suy
            double gocTruoc = cacGoc.Where(x => x < gocMaSat).Max();
            double gocSau = cacGoc.Where(x => x > gocMaSat).Min();

            var heSoTruoc = BangTraCuu[gocTruoc];
            var heSoSau = BangTraCuu[gocSau];

            // Nội suy tuyến tính
            double t = (gocMaSat - gocTruoc) / (gocSau - gocTruoc);

            return new HeSoTinhToan
            {
                Ngamma = heSoTruoc.Ngamma + t * (heSoSau.Ngamma - heSoTruoc.Ngamma),
                Nq = heSoTruoc.Nq + t * (heSoSau.Nq - heSoTruoc.Nq),
                Nc = heSoTruoc.Nc + t * (heSoSau.Nc - heSoTruoc.Nc)
            };
        }
    }
}