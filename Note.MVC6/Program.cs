using Note.BLL;
using Note.DAL; //oracle로 변경할려면 오라클참조로 변경(코드의 유연성)
using Note.IDAL; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Note.BLL.UserBll 서비스 등록
builder.Services.AddTransient<UserBll>();
// IUserDal, UserDal 서비스 등록
builder.Services.AddTransient<IUserDal, UserDal>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

