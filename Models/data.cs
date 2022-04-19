using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using tintucbongda.Data;
using System;
using System.Linq;
namespace tintucbongda.Models
{
    public class data
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new tintucbongdaContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<tintucbongdaContext>>()))
            {
                // Kiểm tra thông tin cuốn sách đã tồn tại hay chưa
                if (context.timkiem.Any())
                {
                    return; // Không thêm nếu cuốn sách đã tồn tại trong DB
                }
                context.timkiem.AddRange(
                new timkiem
                {
                    Title = "u23",
                    ReleaseDate = DateTime.Parse("2022-03-02"),
                    Genre = "châu á",
                    Price = 11.98M
                },
                new timkiem
                {
                    Title = "c1",
                    ReleaseDate = DateTime.Parse("2022-03-01"),
                    Genre = "châu âu",
                    Price = 18.59M
                },
                new timkiem
                {
                    Title = "c2",
                    ReleaseDate = DateTime.Parse("2022-05-15"),
                    Genre = "châu âu",
                    Price = 1
                },
                new timkiem
                {
                    Title = "wc",
                    ReleaseDate = DateTime.Parse("2022-03-01"),
                    Genre = "thế giới",
                    Price = 18.59M
                }
                );
                context.SaveChanges();//lưu dữ liệu
            }
        }
    }
}
