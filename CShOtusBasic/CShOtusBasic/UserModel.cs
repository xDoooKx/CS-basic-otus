﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShOtusBasic
{
    public class UserModel
    {
        public static bool IsNameSet { get; private set; } = false;
        public static string UserName { get; private set; } = "Безымянный";


        public static string SetUserName(string? userName)
        {
            if (String.IsNullOrWhiteSpace(userName)) return "FAIL";

            UserName = userName;
            IsNameSet = true;

            return "OK";
        }
    }
}
