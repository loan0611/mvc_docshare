using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DocShare.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DocShare", throwIfV1Schema: false)
        {

        }
        public DbSet<TaiLieu> TaiLieus { get; set; }
        public DbSet<ChuyenDe> ChuyenDes { get; set; }
        public DbSet<NgonNgu> NgonNgus { get; set; }
        public DbSet<TacGia> TacGias { get; set; }
        public DbSet<TuKhoa> TuKhoas { get; set; }
        public DbSet<ThanhVien> ThanhViens { get; set; }
        public DbSet<BinhLuan> BinhLuans { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<DanhSachTaiLieuYeuTich> DSTLYTs { get; set; }
        public DbSet<LichSuDownload> LichSuDownloads { get; set; }
        public DbSet<TuKhoaTaiLieu> TuKhoaTaiLieus { get; set; }
        public DbSet<DiemTichLuy> DiemTichLuys { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}