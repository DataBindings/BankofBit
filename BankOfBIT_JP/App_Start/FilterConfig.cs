﻿using System.Web;
using System.Web.Mvc;

namespace BankOfBIT_JP
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
