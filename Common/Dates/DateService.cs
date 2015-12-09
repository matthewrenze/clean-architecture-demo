using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Common.Dates
{
    public class DateService : IDateService
    {
        public DateTime GetDate()
        {
            return DateTime.Now.Date;
        }
    }
}
