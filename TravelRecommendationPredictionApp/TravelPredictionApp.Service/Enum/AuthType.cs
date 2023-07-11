using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPredictionApp.Service.Enum
{
    public enum AuthType
    {
        Bearer = 1,
        Basic,
        None
    }

    public enum CustomHttpMethod
    {
        Get = 1,
        Post,
        Put,
        Delete,
        Option
    }
}
