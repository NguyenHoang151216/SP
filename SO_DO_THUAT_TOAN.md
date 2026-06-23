# So do thuat toan ung dung tinh toan va thiet ke mong don

Tai lieu nay tong hop luong xu ly chinh cua ung dung WPF `.NET 8` trong du an `HUCE_DALTUDXD_LOP30_2026_0176667`. Ung dung duoc to chuc theo mo hinh gan MVVM:

- `View/MainWindow.xaml.cs`: dieu huong man hinh, chon lop dat va mong dang tinh.
- `Model/*`: luu cau truc du lieu mong, dat, ket qua tinh toan.
- `ViewModel/*`: chua cac buoc tinh toan va kiem tra.
- `Commands/HeSoTraCuu.cs`: tra he so Terzaghi theo goc ma sat, co noi suy tuyen tinh.

## 1. So do tong quat toan ung dung

```mermaid
flowchart TD
    A([Bat dau]) --> B[Khoi dong MainWindow]
    B --> C[Hien thi man hinh chinh]
    C --> D{Nguoi dung chon chuc nang}

    D -->|Nhap du lieu| E[Nhap thong so dat]
    E --> F[Luu lop dat vao DuLieuDat.ThongTinDat]
    F --> G[Nhap thong so mong]
    G --> H{Du lieu mong hop le?}
    H -->|Khong| H1[Thong bao loi va yeu cau nhap lai]
    H1 --> G
    H -->|Co| I[Luu mong vao DanhSachMong cua lop dat dang chon]
    I --> J[Cap nhat DatDangChon va MongDangChon]

    D -->|Kiem tra suc chiu tai| K[Lay mong va lop dat dang tinh]
    K --> L[Tra he so Ngamma, Nq, Nc]
    L --> M[Tinh Ptx, Rd, Pmax, Pmin]
    M --> N{Ptx <= Rd va Pmax <= 1.2Rd?}
    N -->|Dat| N1[Ket luan nen dat du suc chiu tai]
    N -->|Khong dat| N2[Ket luan nen dat khong du suc chiu tai]
    N1 --> O[Luu SucChiuTai.ThongTinSucChiuTai]
    N2 --> O

    D -->|Kiem tra do lun| P[Lay Ptx tu ket qua suc chiu tai hoac tu tinh lai]
    P --> Q[Tinh Pgl = Ptx - gamma_dat * chieu_sau_chon_mong]
    Q --> Q1[Hien thi ket qua do lun]

    D -->|Kiem tra chong dam thung| R[Lay mong va lop dat dang tinh]
    R --> S[Kiem tra kich thuoc mong, cot, h0]
    S --> T[Tinh Po, Pomax, Pomin]
    T --> U[Tinh Ldt, Pot, Pdt, Pcdt]
    U --> V{Pdt <= Pcdt?}
    V -->|Dat| V1[Mong du kha nang chong dam thung]
    V -->|Khong dat| V2[Can tang chieu day mong hoac cuong do be tong]
    V1 --> W[Luu ChongDamThung.ThongTinCdt]
    V2 --> W

    D -->|Tinh cot thep| X[Lay ket qua chong dam thung da luu]
    X --> Y[Tinh momen theo phuong dai va phuong ngan]
    Y --> Z[Tinh Fa yeu cau dai va ngan]
    Z --> AA[Luu TinhToanCotThep.ThongTinCt]

    D -->|Bo tri cot thep| AB[Nhap duong kinh va khoang cach thep]
    AB --> AC[Tinh so thanh va dien tich thep thuc te]
    AC --> AD{Dien tich thuc te >= dien tich yeu cau?}
    AD -->|Dat ca hai phuong| AE[Thong bao bo tri dat yeu cau]
    AD -->|Khong dat| AF[Thong bao phuong con thieu thep]
    AE --> AG[Luu CotThepBoTri.ThongTinBoTri]
    AF --> AB

    D -->|Xem so lieu| AH[Mo SolieuWindow]
    AH --> AI[Hien thi thong so mong va danh sach lop dat da luu]

    D -->|Thoat| AJ([Ket thuc])
```

## 2. So do nhap va chon du lieu

```mermaid
flowchart TD
    A([Bat dau nhap du lieu]) --> B{Nhap lop dat hay nhap mong?}

    B -->|Lop dat| C[Nguoi dung nhap: loai dat, trang thai, phi, E, c, gamma, chieu day]
    C --> D[Them lop dat moi voi IdDat = so lop + 1]
    D --> E[Gan DuLieuDat.DatDangChon = lop dat moi]
    E --> F[Cap nhat combobox lop dat o MainWindow]

    B -->|Mong| G[Chon lop dat dang gan voi mong]
    G --> H[Nguoi dung nhap kich thuoc, tai trong, vat lieu]
    H --> I{Kiem tra du lieu}
    I -->|Sai| J[Thong bao loi]
    J --> H
    I -->|Dung| K[Tra cuong do be tong theo mac B15-B30]
    K --> L[Tra cuong do thep theo CB240-CB500]
    L --> M{Dang sua mong cu?}
    M -->|Co| N[Cap nhat mong cu]
    M -->|Khong| O[Them mong moi vao DanhSachMong cua lop dat]
    N --> P[Gan mong.LopDat = DatDangChon]
    O --> P
    P --> Q[Cap nhat MongDangChon, ThongTinMong, MongDangTinhToan]
    Q --> R([Ket thuc nhap du lieu])
```

## 3. So do thuat toan suc chiu tai nen dat

Nguon xu ly chinh: `ViewModel/SucChiuTaiViewModel.cs` va `Commands/HeSoTraCuu.cs`.

```mermaid
flowchart TD
    A([Bat dau tinh suc chiu tai]) --> B[Lay du lieu mong va lop dat]
    B --> C{Kich thuoc mong va gamma dat hop le?}
    C -->|Khong| D[Thong bao du lieu khong hop le]
    D --> Z([Ket thuc])

    C -->|Co| E[Tra he so theo goc ma sat phi]
    E --> F{phi co trong bang tra?}
    F -->|Co| G[Lay truc tiep Ngamma, Nq, Nc]
    F -->|Khong| H[Noi suy tuyen tinh giua 2 goc gan nhat]
    G --> I[Tinh alpha1, alpha2, alpha3]
    H --> I

    I --> J[Tinh Ptx = N/(B*L) + gamma_tb*D]
    J --> K[Tinh Rd theo cong thuc Terzaghi co he so an toan Fs]
    K --> L[Tinh momentTerm = 6*M/(B*L^2)]
    L --> M[Tinh Pmax = Ptx + momentTerm]
    M --> N[Tinh Pmin = Ptx - momentTerm]
    N --> O{Ptx <= Rd?}
    O -->|Khong| P[Nen dat khong du suc chiu tai]
    O -->|Co| Q{Pmax <= 1.2*Rd?}
    Q -->|Khong| P
    Q -->|Co| R[Nen dat du suc chiu tai]
    P --> S[Luu ket qua vao SucChiuTai.ThongTinSucChiuTai]
    R --> S
    S --> Z([Ket thuc])
```

## 4. So do thuat toan do lun hien tai

Trong code hien tai, module do lun moi tinh `Pgl`, chua tinh tong do lun `S`.

```mermaid
flowchart TD
    A([Bat dau tinh do lun]) --> B[Lay mong va lop dat dang tinh]
    B --> C{Da co ket qua suc chiu tai phu hop?}
    C -->|Co| D[Lay Ptx tu SucChiuTai.ThongTinSucChiuTai]
    C -->|Khong| E{B va L cua mong hop le?}
    E -->|Khong| F[Gan Ptx = 0]
    E -->|Co| G[Tinh Ptx = N/(B*L) + gamma_tb*D]
    D --> H[Tinh Pgl]
    F --> H
    G --> H
    H --> I[Pgl = Ptx - gamma_dat * chieu_sau_chon_mong]
    I --> J[Hien thi ket qua Pgl]
    J --> K([Ket thuc])
```

## 5. So do thuat toan chong dam thung

Nguon xu ly chinh: `ViewModel/ChongDamThungViewModel.cs`.

```mermaid
flowchart TD
    A([Bat dau chong dam thung]) --> B[Lay thong so mong, cot, be tong, lop bao ve]
    B --> C{B_mong, L_mong, b_cot, l_cot hop le?}
    C -->|Khong| D[Thong bao kich thuc khong hop le]
    D --> Z([Ket thuc])
    C -->|Co| E[Tinh h0 = chieu_cao_mong - lop_bao_ve]
    E --> F{h0 > 0?}
    F -->|Khong| G[Thong bao h0 khong hop le]
    G --> Z

    F -->|Co| H[Tinh Po = N/(B*L) + gamma_tb*D]
    H --> I[Tinh momentTerm = 6*M/(B*L^2)]
    I --> J[Tinh Pomax = Po + momentTerm]
    J --> K[Tinh Pomin = Po - momentTerm]
    K --> L[Tinh Ldt = (L_mong - L_cot)/2 - h0]
    L --> M[Tinh Pot noi suy tu Pomin den Pomax]
    M --> N[Tinh Pdt = (Pomax + Pot)/2 * Ldt * B_mong]
    N --> O[Tinh Pcdt = Rb*1000*h0*(b_cot + h0)]
    O --> P{Pdt <= Pcdt?}
    P -->|Co| Q[Ket luan mong du chong dam thung]
    P -->|Khong| R[Ket luan khong dat, can tang h hoac Rb]
    Q --> S[Luu ChongDamThung.ThongTinCdt]
    R --> S
    S --> Z([Ket thuc])
```

## 6. So do thuat toan tinh dien tich cot thep yeu cau

Nguon xu ly chinh: `ViewModel/TinhToanCotThepViewModel.cs`. Buoc nay nen thuc hien sau khi da tinh va luu chong dam thung, vi can `Pomax`, `Pomin`, `Po`, `h0`.

```mermaid
flowchart TD
    A([Bat dau tinh cot thep]) --> B[Lay mong, lop dat, ket qua chong dam thung]
    B --> C{Cuong do thep > 0 va h0 > 0?}
    C -->|Khong| D[Thong bao thong so vat lieu khong hop le]
    D --> Z([Ket thuc])

    C -->|Co| E[Tinh theo phuong canh dai]
    E --> F[Lng = L_mong - (L_mong - L_cot)/2]
    F --> G[Pong = Pomin + (Pomax - Pomin)*(L_mong - Lng)/L_mong]
    G --> H[Mlng = (Pong + Pomax)/2 * Lng^2/2 * B_mong]
    H --> I[Fa_dai = Mlng*1000000/(0.9*Rs*h0*1000)]

    I --> J[Tinh theo phuong canh ngan]
    J --> K[Bng = (B_mong - B_cot)/2]
    K --> L[Mbng = Po + Bng^2/2 * L_mong]
    L --> M[Fa_ngan = Mbng*1000000/(0.9*Rs*h0*1000)]
    M --> N[Luu TinhToanCotThep.ThongTinCt]
    N --> Z([Ket thuc])
```

## 7. So do thuat toan bo tri cot thep

Nguon xu ly chinh: `ViewModel/BoTriCotThepViewModel.cs`.

```mermaid
flowchart TD
    A([Bat dau bo tri cot thep]) --> B[Lay mong, ket qua tinh cot thep, ket qua chong dam thung]
    B --> C[Nhap duong kinh va khoang cach thep 2 phuong]
    C --> D{Du lieu dau vao hop le?}
    D -->|Khong| E[Thong bao yeu cau nhap lai]
    E --> C

    D -->|Co| F[Tinh cot thep phuong dai]
    F --> G[As1_dai = pi*phi_dai^2/4]
    G --> H[L_hieu_luc = L_mong*1000 - 2*lop_bao_ve*1000]
    H --> I[n_dai = ceil(L_hieu_luc/a_dai) + 1]
    I --> J[As_dai = n_dai * As1_dai]

    J --> K[Tinh cot thep phuong ngan]
    K --> L[As1_ngan = pi*phi_ngan^2/4]
    L --> M[B_hieu_luc = B_mong*1000 - 2*lop_bao_ve*1000]
    M --> N[n_ngan = ceil(B_hieu_luc/a_ngan) + 1]
    N --> O[As_ngan = n_ngan * As1_ngan]

    O --> P{As_dai >= Fa_dai va As_ngan >= Fa_ngan?}
    P -->|Co| Q[Thong bao bo tri thoa man]
    P -->|Khong| R[Thong bao phuong thieu thep]
    Q --> S[Luu CotThepBoTri.ThongTinBoTri]
    R --> C
    S --> Z([Ket thuc])
```

## 8. Trinh tu su dung khuyen nghi

```mermaid
flowchart LR
    A[Nhap lop dat] --> B[Nhap thong so mong]
    B --> C[Kiem tra suc chiu tai]
    C --> D[Kiem tra do lun]
    D --> E[Kiem tra chong dam thung]
    E --> F[Tinh dien tich cot thep yeu cau]
    F --> G[Bo tri cot thep]
    G --> H[Xem so lieu hoac luu ket qua]
```

## 9. Ghi chu thiet ke

- `MainWindow` la bo dieu phoi: moi chuc nang deu lay `MongDon.LayMongDangChon()` va `DuLieuDat.LayDatDangChon()` truoc khi mo Page tinh toan.
- Ket qua trung gian duoc luu bang static property: `SucChiuTai.ThongTinSucChiuTai`, `ChongDamThung.ThongTinCdt`, `TinhToanCotThep.ThongTinCt`, `CotThepBoTri.ThongTinBoTri`.
- Neu nguoi dung bo qua mot buoc, module sau co the thieu ket qua dau vao. Vi vay trong bao cao nen trinh bay trinh tu khuyen nghi nhu muc 8.
- Module do lun hien tai moi tinh `Pgl`; neu can so do tinh lun day du, can bo sung cong thuc tinh `S` theo lop dat va chieu sau anh huong.
