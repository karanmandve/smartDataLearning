﻿using core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.App.User.Command
{
    public class SendOtpCommand : IRequest<object>
    {
        public string Email { get; set; }
    }

    //public class UserLoginQuery : IRequest<Object>
    //{
    //    public domain.ModelDto.LoginDto LoginUser { get; set; }
    //    public string Otp { get; set; } // Add OTP property
    //}

    public class SendOtpQueryHandler : IRequestHandler<SendOtpCommand, object>
    {
        private readonly IAppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService; // Add email service

        public SendOtpQueryHandler(IAppDbContext context, IConfiguration configuration, IEmailService emailService)
        {
            _context = context;
            _configuration = configuration;
            _emailService = emailService;
        }

        public async Task<object> Handle(SendOtpCommand request, CancellationToken cancellationToken)
        {
            var email = request.Email;

            var userExist = await _context.Set<domain.User>().FirstOrDefaultAsync(x => x.Email == email);

            if (userExist == null)
            {
                return "Email or Password Invalid";

            }


            var otp = new Random().Next(100000, 999999).ToString();

            await _context.Set<domain.Otp>().AddAsync(new domain.Otp { Email = email, Code = otp, Expiration = DateTime.Now.AddMinutes(5) });
            await _context.SaveChangesAsync();

            // Send OTP to user's email
            await _emailService.SendEmailAsync(email, "Your OTP Code", $"Your OTP code is {otp}");

            return new { Message = "OTP sent to your email" };
        }
    }
}
