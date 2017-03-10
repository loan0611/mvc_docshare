namespace DocShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BinhLuans",
                c => new
                    {
                        MaBinhLuan = c.Int(nullable: false, identity: true),
                        MaThanhVien = c.Int(nullable: false),
                        MaTaiLieu = c.Int(nullable: false),
                        NDBinhLuan = c.String(),
                        NgayBL = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaBinhLuan);
            
            CreateTable(
                "dbo.ChuyenDes",
                c => new
                    {
                        MaChuyenDe = c.Int(nullable: false, identity: true),
                        TenChuyenDe = c.String(),
                    })
                .PrimaryKey(t => t.MaChuyenDe);
            
            CreateTable(
                "dbo.DiemTichLuys",
                c => new
                    {
                        MaThanhVien = c.Int(nullable: false, identity: true),
                        Diem = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaThanhVien);
            
            CreateTable(
                "dbo.DanhSachTaiLieuYeuTiches",
                c => new
                    {
                        MaThanhVien = c.Int(nullable: false, identity: true),
                        MaTaiLieu = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaThanhVien);
            
            CreateTable(
                "dbo.LichSuDownloads",
                c => new
                    {
                        MaThanhVien = c.Int(nullable: false, identity: true),
                        MaTaiLieu = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaThanhVien);
            
            CreateTable(
                "dbo.NgonNgus",
                c => new
                    {
                        MaNgonNgu = c.Int(nullable: false, identity: true),
                        TenNgonNgu = c.String(),
                    })
                .PrimaryKey(t => t.MaNgonNgu);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        MaRating = c.Int(nullable: false, identity: true),
                        SL1Sao = c.Int(nullable: false),
                        SL2Sao = c.Int(nullable: false),
                        SL3Sao = c.Int(nullable: false),
                        SL4Sao = c.Int(nullable: false),
                        SL5Sao = c.Int(nullable: false),
                        TBSao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaRating);
            
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        MaReply = c.Int(nullable: false, identity: true),
                        MaThanhVien = c.Int(nullable: false),
                        MaBinhLuan = c.Int(nullable: false),
                        NDReply = c.String(),
                        NgayReply = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaReply);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TacGias",
                c => new
                    {
                        MaTacGia = c.Int(nullable: false, identity: true),
                        TenTacGia = c.String(),
                    })
                .PrimaryKey(t => t.MaTacGia);
            
            CreateTable(
                "dbo.TaiLieux",
                c => new
                    {
                        MaTaiLieu = c.Int(nullable: false, identity: true),
                        MaChuyenDe = c.Int(nullable: false),
                        MaTuKhoa = c.Int(nullable: false),
                        MaNgonNgu = c.Int(nullable: false),
                        MaThanhVienUpload = c.Int(nullable: false),
                        MaThanhVienDuyet = c.Int(nullable: false),
                        MaRating = c.Int(nullable: false),
                        NhanDe = c.String(),
                        SoTrang = c.Int(nullable: false),
                        NgayUpload = c.DateTime(nullable: false),
                        KichThuoc = c.Int(nullable: false),
                        LuotXem = c.Int(nullable: false),
                        LinkFile = c.String(),
                        SoLanDownload = c.Int(nullable: false),
                        GhiChu = c.String(),
                        Phi = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Anh = c.String(),
                        TinhTrang = c.String(),
                    })
                .PrimaryKey(t => t.MaTaiLieu);
            
            CreateTable(
                "dbo.ThanhViens",
                c => new
                    {
                        MaThanhVien = c.Int(nullable: false, identity: true),
                        TenTruyCap = c.String(),
                        MatKhau = c.String(),
                        HoTen = c.String(),
                        GioiTinh = c.Boolean(nullable: false),
                        Email = c.String(),
                        NgayDangKy = c.DateTime(nullable: false),
                        QuyenHan = c.String(),
                    })
                .PrimaryKey(t => t.MaThanhVien);
            
            CreateTable(
                "dbo.TuKhoas",
                c => new
                    {
                        MaTuKhoa = c.Int(nullable: false, identity: true),
                        TenTuKhoa = c.String(),
                    })
                .PrimaryKey(t => t.MaTuKhoa);
            
            CreateTable(
                "dbo.TuKhoaTaiLieux",
                c => new
                    {
                        MaTuKhoa = c.Int(nullable: false, identity: true),
                        MaTaiLieu = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaTuKhoa);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Gender = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TuKhoaTaiLieux");
            DropTable("dbo.TuKhoas");
            DropTable("dbo.ThanhViens");
            DropTable("dbo.TaiLieux");
            DropTable("dbo.TacGias");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Replies");
            DropTable("dbo.Ratings");
            DropTable("dbo.NgonNgus");
            DropTable("dbo.LichSuDownloads");
            DropTable("dbo.DanhSachTaiLieuYeuTiches");
            DropTable("dbo.DiemTichLuys");
            DropTable("dbo.ChuyenDes");
            DropTable("dbo.BinhLuans");
        }
    }
}