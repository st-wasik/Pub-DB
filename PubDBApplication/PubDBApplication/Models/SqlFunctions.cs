using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Web;

namespace PubDBApplication.Models
{
    public class SqlFunctions
    {
        [DbFunction("PubDBModel.Store", "totalPrice")]
        public static Decimal TotalPrice(int id)
        {
            throw new NotSupportedException("Direct calls are not supported.");
        }
    }
}