using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace DTcms.Common
{
    public class DTDateTime
    {
        public static readonly DateTime MinDateTime = SqlDateTime.MinValue.Value;
        public static readonly DateTime MaxDateTime = SqlDateTime.MaxValue.Value;
    }
}
