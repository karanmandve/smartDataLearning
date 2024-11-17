using OpenTokSDK;
namespace testingOpenTok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Application credentials
            string ApplicationId = "23ac46c2-0e01-4f82-a9b8-36c54dcfa325";

            // Read the private key from a file
            string PrivateKey = File.ReadAllText("../../../private.key"); // Provide the correct path to your private key

            // Initialize OpenTok with Application ID and Private Key (for Bearer authentication)
            var OpenTok = new OpenTok(ApplicationId, PrivateKey);

            // Create a session that will attempt to transmit streams directly between clients
            var session = OpenTok.CreateSession();
            //string token = session.GenerateToken();
            //Console.WriteLine(token);

            // Store this sessionId in the database for later use
            string sessionId = session.Id;

            Console.WriteLine("Session ID: " + sessionId);

            //var expireTime = DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds();
            double inOneWeek = (DateTime.UtcNow.Add(TimeSpan.FromDays(7)).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            //string token = session.GenerateToken(role: Role.MODERATOR, expireTime: inOneWeek, data: "name=Johnny");

            var token = OpenTok.GenerateToken(sessionId, role: Role.PUBLISHER, expireTime: inOneWeek);
            Console.WriteLine(token);

        }
    }
}
