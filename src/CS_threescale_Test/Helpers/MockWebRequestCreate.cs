using System;
using System.Net;
using Moq;

namespace CS_threescale_Test
{
    /// <summary>
    /// A custom implementation of IWebRequestCreate for Web Requests.
    /// </summary>
    /// <summary>A web request creator for unit testing.</summary>
    public class MockWebRequestCreate : IWebRequestCreate
    {
        /// <summary>
        /// The web request.
        /// </summary>
        private static WebRequest nextRequest;

        /// <summary>
        /// Internally held lock object for multi-threading support.
        /// </summary>
        private static object lockObject = new object();

        /// <summary>
        /// Gets or sets the next request object.
        /// </summary>
        public static WebRequest NextRequest
        {
            get
            {
                return nextRequest;
            }

            set
            {
                lock (lockObject)
                {
                    nextRequest = value;
                }
            }
        }

        /// <summary>
        /// Creates the new instance of the CustomWebRequest.
        /// </summary>
        /// <param name="uri">The given Uri</param>
        /// <returns>An instantiated web request object requesting from the given Uri.</returns>
        public WebRequest Create(Uri uri)
        {
            return nextRequest;
        }

        /// <summary>
        /// Creates a Mock Web request
        /// </summary>
        /// <returns>The mocked HttpRequest object</returns>
        public static MockWebRequest CreateMockWebRequest()
        {
            var request = new MockWebRequest();
            NextRequest = request;
            return request;
        }
    }
}

