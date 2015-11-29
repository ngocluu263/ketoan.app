using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ketoansoft.app.Class.Global
{
    public class Const
    {
        //system
        public const string DATABASEXML_FILEPATH = "\\XML\\Database.xml";
        public const string ACTIVATEXML_FILEPATH = "\\XML\\Activate.xml";
        public static bool ISCHANGEDATABASE = false;
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["ketoansoft.app.Properties.Settings.dbConnectionString"].ConnectionString;
        public static System.Data.SqlClient.SqlConnectionStringBuilder builder;
        //Danh mục chung
        public const int DANHMUCTAIKHOAN = 2;
        public const int DANHMUCCACLOAICHUNGTU = 3;
        public const int DOITUONGPHAPNHAN = 4;
        public const int DANHMUCNHOM = 5;
        public const int DANHMUCDIENGIAI = 6;
        public const int DANHMUCCACCONGTRINH = 7;
        public const int DANHMUCCAUTHANHSANPHAM = 8;
        public const int KHAIBAOTENCAPHHDTCP = 9;
        public const int DANHMUCKHEUOC = 10;
        public const int DANHMUCBAOCAOTHEOF8D = 11;
        public const int DANHMUCDOITUONGGIATHANH = 12;
        public const int DANHMUCSOHOADON = 13;
        public const int DANHMUCNHOMHH = 14;
        //Danh mục hàng hóa
        public const int HANGHOACHUNG = 21;
        public const int HANGHOATHEOKHO = 22;
        public const int HANGHOATHEOLO = 23;
        public const int KHAIBAODONGIABANTHEOVUNG = 24;
        public const int KHAIBAODONGIABANTHEONHOMDOITUONG = 25;
        public const int DANHMUCLENHSANXUAT = 26;
        public const int CHITIETLENHSANXUAT = 27;
        public const int GIABANTHEOHANGHOAVANGAYAPDUNG = 28;
        //Danh mục công nợ
        public const int THEODOITUONG = 31;
        public const int THEOCONGTRINH = 32;
        public const int THEOHOADON = 33;
        public const int THEOHOPDONG = 34;
        public const int THEOCHUNGTUVANCHUYEN = 35;
        public const int THEOHANGHOA = 36;
        public const int THEOCONGTRINHVADOTTHANHTOAN = 37;
        public const int THEOKHEUOCVAY = 38;
        //Danh mục chi phí
        public const int YEUTOCHIPHI = 41;
        public const int SOTHEODOICHIPHITHEOBOPHAN = 42;
        public const int SOTONGHOPCHIPHITHEOCONGTRINH = 43;
        //Khai báo thông tin
        public const int CAIDATTHONGSO = 51;
        public const int KHAIBAOCHOHOTROKEKHAI = 52;
        public const int KHAIBAOCACTUYCHONRIENG = 53;
        //Khai báo cho công trình
        public const int KHAIBAOCHITIET = 61;
        public const int KHAIBAOTAIKHOANDOANHTHUVACHIPHI = 62;
        public const int KHAIBAOBANGTYLEPHANBO = 63;
        public const int XEMBANGTYLEPHANBO = 64;
        public const int XEMBANGPHANBOCHIPHI = 65;
        public const int DANHMUCCONGTRINH = 66;
        public const int XEMCHITIET1CONGTRINH = 67;
        public const int DANHMUCCONGTRINHVATHANHPHAM = 68;

        //công trình->xử lý giá thành
        public const int XUATKHOTUDONGCHOCONGTRINHTUPNK = 71;
        public const int KETCHUYENCHIPHI621622623627SANG154 = 72;
        public const int PHANBOCHIPHIGIANTIEP = 73;
        public const int PHANBOCHIPHITRUCTIEP = 74;
        public const int KETCHUYENGIAVONNHIEUCONGTRINH = 75;
        public const int KETCHUYENGIAVON1CONGTRINH = 76;
        public const int XULYGIATHANHCONGTRINH = 77;
        public const int BANGGIATHANHCONGTRINHSAUKHIXULYTHEOTHANG = 78;
        public const int GOPBANGGIATHANHCONGTRINHCANAM = 79;
        public const int GOPBANGGIATHANHCONGTRINHTUTHANGDENTHANG = 80;
        public const int XULYGIATHANH1CONGTRINHCONHIEUTHANHPHAM = 81;
        public const int XULYGIATHANHMACONGTRINHLAMATHANHPHAM = 82;
        public const int BANGGIATHANHCONGTRINHVATHANHPHAM = 83;
        //tài sản cố định->tài sản cố định
        public const int DANHMUCTAISANCODINH = 91;
        public const int XULYKHAUHAO = 92;
        public const int BANGKHAUHAOTSCDSAUKHIXULY = 93;
        public const int HACHTOANKHAUHAOVAOKTSC = 94;
        public const int INBANGKHAUHAOTSCD = 95;
        public const int CAPNHATLAITUDANHMUCTSCDVAOBANGKHTSCD = 96;
        public const int THEMTSCDVAODANHMUCTSCD = 97;
        public const int GIAMTAISANCODINH = 98;
        //tài sản cố định->chi phí chờ phân bổ
        public const int DANHMUCCHIPHICHOPHANBO = 101;
        public const int XULYCHIPHICHOPHANBO = 102;
        public const int BANGCPCPBSAUKHIXULY = 103;
        public const int HACHTOANTRICHCHIPHICHOPHANBO = 104;
        public const int INBANGCHIPHICHOPHANBO = 105;
        //tài sản cố định->lương thời vụ
        public const int DANHSACHCONGNHANTHOIVU = 111;
        public const int INHOPDONGLAODONGTHOIVU = 112;
        public const int TONGHOPLUONGCONGNHANTHEOCONGTRINH = 113;
        public const int INBANGLUONGTHOIVUTHEOCONGTRINH = 114;
        public const int INBANGCHAMCONGTHEOTUNGCONGTRINH = 115;
        //quản lý bảo hành->bảo hành
        public const int DANHMUCBAOHANH = 121;
        public const int BANGTONGHOPBAOHANH = 122;
        public const int INSOBAOHANH = 123;
        public const int CAPNHATTHONGTINTUSOCHUNGTUGOPVAODMBAOHANH = 124;
        //Bàn làm việc
        public const int SOCHUNGTUGOC = 1001;

        //Nhập phát sinh
        public const int CHITIETDONMUAHANG = 1011;

        //Quản lý lương
        public const int DANHMUCNHANVIEN = 1021;
        public const int CHAMCONG = 1022;
        public const int TIENUNGLUONG = 1023;
        public const int DANHMUCBANGLUONG = 1024;
        public const int CONGTHUCTINHLUONG = 1025;
        public const int KHAIBAOMANGAYCONG = 1026;
        public const int KHAIBAOMANGAYLE = 1027;

        //Khai báo tài chính
        public const int KHAIBAOCANDOIKETOAN = 1031;
        public const int KHAIBAOKETQUAKINHDOANH = 1032;
        public const int KHAIBAOLUUCHUYENTIENTETT = 1033;
        public const int KHAIBAOLUUCHUYENTIENTEGT = 1034;
        public const int KHAIBAOTHUYETMINH = 1035;
        public const int KHAIBAOKETQUAKINHDOANHPT = 1036;
        public const int INCANDOIPHATSINHTAIKHOAN = 1037;
    }
}
