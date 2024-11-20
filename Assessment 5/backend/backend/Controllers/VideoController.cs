using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OpenTokSDK;
using System;
using System.IO;
using Vonage.Pricing;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly OpenTokSDK.OpenTok _openTok;
        private readonly string _apiApplicationId;
        private readonly string _apiPrivateKey;
        private readonly ILogger<VideoController> _logger;

        public VideoController(IConfiguration configuration, ILogger<VideoController> logger)
        {
            _apiApplicationId = configuration["Vonage:ApplicationId"];
            _apiPrivateKey = configuration["Vonage:PrivateKey"];
            _logger = logger;

            if (string.IsNullOrEmpty(_apiApplicationId) || string.IsNullOrEmpty(_apiPrivateKey))
            {
                _logger.LogError("Vonage ApplicationId or PrivateKey is missing.");
                throw new ArgumentException("Vonage ApplicationId or PrivateKey is missing.");
            }

            _openTok = new OpenTokSDK.OpenTok(_apiApplicationId, _apiPrivateKey);

        }

        [HttpGet("session")]
        public IActionResult CreateSession()
        {
            try
            {
                _logger.LogInformation("Creating a new Vonage session.");
                var session = _openTok.CreateSession();
                _logger.LogInformation("Session created successfully with ID: {SessionId}", session.Id);
                return Ok(new { sessionId = session.Id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating session");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating session: " + ex.Message);
            }
        }

        [HttpGet("token/{sessionId}")]
        public IActionResult GenerateToken(string sessionId)
        {
            try
            {
                _logger.LogInformation("Generating token for session ID: {SessionId}", sessionId);

                // Calculate the Unix timestamp for 1 hour from now
                var expireTime = DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds();

                var token = _openTok.GenerateToken(sessionId, role: Role.PUBLISHER, expireTime: expireTime);
                _logger.LogInformation("Token generated successfully.");

                return Ok(new { token });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while generating token");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error generating token: " + ex.Message);
            }
        }
    }
}
