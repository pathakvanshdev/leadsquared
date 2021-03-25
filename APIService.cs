using System;
using System.IO;
using System.Net;

namespace leadsquared
{
    public class APIService
    {
        APIAdapter _adapter = new APIAdapter();

        public string getBattleUnit(int id)
        {

            try
            {
                string url = String.Format("https://age-of-empires-2-api.herokuapp.com/api/v1/unit/" + id);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if(response.StatusCode==HttpStatusCode.NotFound)return null;

                string responseFromServer;
                // Get the stream containing content returned by the server.
                // The using block ensures the stream is automatically closed.
                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    responseFromServer = reader.ReadToEnd();
                    // Display the content.
                }

                // Close the response.
                response.Close();

                return responseFromServer;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}