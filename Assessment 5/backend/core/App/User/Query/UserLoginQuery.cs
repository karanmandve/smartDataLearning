using core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class UserLoginQuery : IRequest<Object>
{
    public domain.ModelDto.LoginDto LoginUser { get; set; }
    public string Otp { get; set; } // Add OTP property
}

public class UserLoginQueryHandler : IRequestHandler<UserLoginQuery, Object>
{
    private readonly IAppDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly IEmailService _emailService; // Add email service

    public UserLoginQueryHandler(IAppDbContext context, IConfiguration configuration, IEmailService emailService)
    {
        _context = context;
        _configuration = configuration;
        _emailService = emailService;
    }

    public async Task<Object> Handle(UserLoginQuery request, CancellationToken cancellationToken)
    {
        var user = request.LoginUser;

        var userExist = await _context.Set<domain.User>().FirstOrDefaultAsync(x => x.Email == user.Email);

        if (userExist == null || !BCrypt.Net.BCrypt.Verify(user.Password, userExist.Password))
        {
            return "Email or Password Invalid";
        }

        
        var claim = new[]
         {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim("Id", userExist.UserId.ToString()),
                new Claim("Email", userExist.Email),
            };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claim,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: signIn);
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        await _context.SaveChangesAsync();


        //await _context.Set<domain.Otp>().AddAsync(new domain.Otp { Email = userExist.Email, Code = otp, Expiration = DateTime.Now.AddMinutes(5) });
        // Generate OTP
        //var otp = new Random().Next(100000, 999999).ToString();
        // Store OTP in database or cache with expiration time

        // Send OTP to user's email
        //await _emailService.SendEmailAsync(userExist.Email, "Your OTP Code", $"Your OTP code is {otp}");

        //return new { Message = "Login Successfull" };

        return new
        {
            Token = jwt,
            Expiration = token.ValidTo
        };




    }
}
