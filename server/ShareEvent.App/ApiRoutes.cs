using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareEvent.App
{
    public class ApiRoutes
    {
        private const string Root = "api";

        public static class Events
        {
            public const string Confirm = Root + "/event";
            public const string Retrieve = Root + "/event/{id}";
        }
    }
}
