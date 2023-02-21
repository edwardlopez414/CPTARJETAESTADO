using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPPESTADOT.Models.API
{
    public class APIDATA
    {
        public Envelope Envelope { get; set; }
    }

    public class Body
    {
        public Variables Variables { get; set; }
    }

    public class Envelope
    {
        public Body Body { get; set; }
    }

    public class Variables
    {
        public string variable { get; set; }
    }

}