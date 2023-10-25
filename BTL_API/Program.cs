using BusinessLogicLayer;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();
builder.Services.AddTransient<IKhachRepository, KhachHangRepository>();
builder.Services.AddTransient<IKhachBusiness, KhachBusiness>();
builder.Services.AddTransient<INhaccRepository, NhaCCRepository>();
builder.Services.AddTransient<INhaCCBusiness, NhaccBusiness>();
builder.Services.AddTransient<INhanVienRepository, NhanVienRepository>();
builder.Services.AddTransient<INhanVienBusiness, NhanvienBusiness>();
builder.Services.AddTransient<IHoaDonNhapRepository, HoaDonNhapRepository>();
builder.Services.AddTransient<IHoaDonNhapBusiness, HoaDonNhapBusiness>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserBusiness, UserBusiness>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
