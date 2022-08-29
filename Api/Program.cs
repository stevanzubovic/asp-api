using Api.Core;
using Application;
using Application.Commands.Authors;
using Application.Commands.Books;
using Application.Commands.Genres;
using Application.Commands.Reviews;
using Application.Commands.Users;
using Application.Email;
using Application.Queries;
using EfDataAccess;
using Implementation.Commands;
using Implementation.Email;
using Implementation.Logging;
using Implementation.Queries;
using Implementation.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
//builder.Services.AddTransient<IApplicationActor, AdminFakeApiActor>();
builder.Services.AddTransient<IApplicationActor>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();

    var user = accessor.HttpContext.User;

    if (user.FindFirst("ActorData") == null)
    {
        var unauthorisedUser = new JwtActor
        {
            Id = 0,
            Identity = "Unauthorised actor",
            AllowedUseCases = new List<int> { 13, 9, 6, 12, 21 }
        };

        return unauthorisedUser;
    }

    var actorString = user.FindFirst("ActorData").Value;

    var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

    return actor;
});
builder.Services.AddTransient<UseCaseExecutor>();
builder.Services.AddTransient<IUseCaseLogger, SQLLogger>();
builder.Services.AddTransient<JwtManager>();
builder.Services.AddTransient<IEmailSender, SmtpEmailSender>();

builder.Services.AddTransient<LibraryContext>();

builder.Services.AddAutoMapper(typeof(EfCreateBook).Assembly);
builder.Services.AddAutoMapper(typeof(EfCreateAuthor).Assembly);
builder.Services.AddAutoMapper(typeof(EfCreateGenre).Assembly);
builder.Services.AddAutoMapper(typeof(EfCreateUser).Assembly);

#region Authors
builder.Services.AddTransient<IGetOneAuthorQuery, EfGetOneAuthor>();
builder.Services.AddTransient<IGetAuthorsQuery, EfGetAuthors>();
builder.Services.AddTransient<ICreateAuthorCommand, EfCreateAuthor>();
builder.Services.AddTransient<IDeleteAuthorCommand, EfDeleteAuthor>();
builder.Services.AddTransient<IUpdateAuthorCommand, EfUpdateAuthor>();
#endregion

#region Genres
builder.Services.AddTransient<IDeleteGenreCommand, EfDeleteGenre>();
builder.Services.AddTransient<ICreateGenreCommand, EfCreateGenre>();
builder.Services.AddTransient<IGetOneGenreQuery, EfGetOneGenre>();
builder.Services.AddTransient<IGetGenresQuery, EfGetGenres>();
builder.Services.AddTransient<IUpdateGenreCommand, EfUpdateGenre>();
#endregion

#region Books
builder.Services.AddTransient<IGetOneBookQuery, EfGetOneBook>();
builder.Services.AddTransient<IGetBooksQuery, EfGetBooks>();
builder.Services.AddTransient<ICreateBookCommand, EfCreateBook>();
builder.Services.AddTransient<IDeleteBookCommand, EfDeleteBook>();
builder.Services.AddTransient<IUpdateBookCommand, EfUpdateBook>();
#endregion

#region Users
builder.Services.AddTransient<ICreateUserCommand, EfCreateUser>();
builder.Services.AddTransient<IDeleteUserCommand, EfDeleteUser>();
builder.Services.AddTransient<IGetOneUserQuery, EfGetOneUser>();
builder.Services.AddTransient<IGetUsersQuery, EfGetUsers>();
builder.Services.AddTransient<IUpdateUserCommand, EfUpdateUser>();
#endregion

#region Reviews
builder.Services.AddTransient<ICreateReviewCommand, EfCreateReview>();
builder.Services.AddTransient<IDeleteReviewCommand, EfDeleteReview>();
builder.Services.AddTransient<IUpdateReviewCommand, EfUpdateReview>();
builder.Services.AddTransient<IGetOneReviewQuery, EfGetOneReview>();
builder.Services.AddTransient<IGetReviewsQuery, EfGetReviews>();
#endregion

builder.Services.AddTransient<IGetLogsQuery, EfGetLogs>();

#region Validators
builder.Services.AddTransient<CreateBookValidator>();
builder.Services.AddTransient<CreateAuthorValidator>();
builder.Services.AddTransient<GenreValidator>();
builder.Services.AddTransient<UserValidator>();
builder.Services.AddTransient<ReviewValidator>();
#endregion


builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = "asp_api",
        ValidateIssuer = true,
        ValidAudience = "Any",
        ValidateAudience = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.MapControllers();


app.UseRouting();
app.UseMiddleware<GlobalExceptionHandler>();

app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
