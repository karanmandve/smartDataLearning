using OpenTokSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Service
{
    public class OpenTokService
    {

        private readonly OpenTok openTok;
        private readonly string apiKey = "b669c86a";
        private readonly string apiSecret = "EmUl7En92bICAKul";

        public OpenTokService()
        {
            openTok = new OpenTok(apiKey, apiSecret);
        }

        public string CreateSession()
        {
            var session = openTok.CreateSession();
            return session.Id;
        }

        public string GenerateToken(string sessionId)
        {
            return openTok.GenerateToken(sessionId);
        }

        public Archive StartRecording(string sessionId)
        {
            return openTok.StartArchive(sessionId, "Session Recording");
        }

        public void StopRecording(string archiveId)
        {
            openTok.StopArchive(archiveId);
        }


    }
}
