using core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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

        // Generate OTP
        //var otp = new Random().Next(100000, 999999).ToString();
        // Store OTP in database or cache with expiration time
        //await _context.Set<domain.Otp>().AddAsync(new domain.Otp { Email = userExist.Email, Code = otp, Expiration = DateTime.Now.AddMinutes(5) });
        await _context.SaveChangesAsync();

        // Send OTP to user's email
        //await _emailService.SendEmailAsync(userExist.Email, "Your OTP Code", $"Your OTP code is {otp}");

        return new { Message = "Login Successfull" };
    }
}
