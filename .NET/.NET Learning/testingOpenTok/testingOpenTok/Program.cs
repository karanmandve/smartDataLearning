using OpenTokSDK;
using System.Net;
namespace testingOpenTok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // For .NET Core or .NET 5+ you can set the security protocol to TLS 1.2 or higher
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //WebRequest.DefaultWebProxy = new WebProxy("192.168.1.100:8080", true);
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;





            // Application credentials
            string ApplicationId = "022a52e5-b155-43f1-b116-7a09a19685ea";

            // Read the private key from a file
            string PrivateKey = File.ReadAllText("../../../private.key"); // Provide the correct path to your private key
            //string PrivateKey = "-----BEGIN PRIVATE KEY-----MIIEvwIBADANBgkqhkiG9w0BAQEFAASCBKkwggSlAgEAAoIBAQCc64Cnrko6OGBTFIVQi+DEPBHH54anRYgkCYJkelbI8R3pRv4T5SrNkksLD9x2FFHcLN3dn0J+7+p++Q042+ss+wOEPe6IS/YwEm5gk841xwnKobU9uhT3h6spQH7h9uhmr4uGYBkvq3aHv3Ht4b7VXeA65PgGeL2+5LJA9VSTpEJ+ofXbgodq7FzC1BbxAqLKorkEkW2mfqTcuBIild3RfPBV26ZB3ogrjaqu5gwO1BQC9BiKakOVeHWcWst1hEEmrWC/Rw1ZYWY4QIcIEdtfSM/cddoqmV163AB/g+IIlODYayBt67TcSWc/O0VA0Jpupfmqq1uVU2IDIY5LT23FAgMBAAECggEAB5RSdwbym+RMNscXd2ACP8g8/aBfvyWbIU56R1snZPZMgQ+GRzS7AAnwaPzfo65wk8dxAfrmzdXNyEtESbpJnjcToOgS5O9yWTkSrsSE4dEW1nxAElayG5CogkoUttpjuE4DWb67iLNp+r2TBa/xNUIfCgk0N6/OTnGicIPJDYZ+ tO5INfjke9MGV3DtliNsBpQnjykQt0a5dveKoZTqWu6zGZ+Mn/+Wya8ImTzH7QCXoOrBpY5RqeZ2eNUuCZ7WNTJ15COPEun75rfDInZkhCdkQmpVuHfYHjSuxlyjpjMUndywMs5SyOhu6iwUdZaGrl2MvrmEJF7LXkbXNgC/QAwKBgQDQwkCWWXWq7haQkRL6ldi94RkcL14vAfHb4iGyRXmgTBa1CE0/usERtuDWD3hgMEBJvra3EUfONbgDqYzpNrMcDHTgfH79yo9o0pR1y4IAmmYs+CtEKVUs+aJW0CUHDzI/pL8cYFoboB9GVnMDTEkMKBYdr9Hg87/7dke/pXxcqwKBgQDAbiNAg3UHIUmXwG5WDYakF+crljDedV2yuT4N7jYAzHDdGf0DX/8IH9rdQQ+F9UKqPZO/La8TtBdFfEYw8yvlp9qutrckLrMH5OktkGIp5gKBv/jk86y1nar3RyyNWaUNeAxDfIiEGlLBIwmmN2e28xRnHV1DF/o/fB7lK+J/TwKBgQCudXgmbdKxK1G+NQ8oTWwZmvEyJb/PBxAJkxxX8EmplYzwc2SjWr4YwL17BuixcgF336KwsQdSJICIxvwUtfrO+PX/2OsDy3E3x6v8GTump2G2ORtnVidxc5mgdUhMcv2qRFLWMwt6xMD+Nibd3bW6LBH3c0SxeuK5Emr5lSGuCwKBgQC5U9mjsnetTEPiYTRisFgyBctgUR/zwDljfcDkDb34+uzgJL1m2Ld4jaVuXdCjhViVOQTopQjvAw0+oLfBQRHP9t9IUTUFJezK944TkfDYxWs4pzkA2CZIK/eSe/vOjr3FwQ6emHuqLufwltweN1IuAuJthPxjN96N8e6XbLKRRQKBgQCN14ATvdPclgQgk0JptdywlVYIwQZcdEnB53tV9haUvLlHCHbX93RnXUa3kllHXrZMdWypFBbHrMsDSW16TOu3qCvCNpHsJf5AGPhDK+rBe/XrBnp3NyHDj2tHnbYCGw5bm6HJAtCalF6BK0A5FF5g5B+rFF8VJjd2Y85guBzesA==-----END PRIVATE KEY-----";
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
