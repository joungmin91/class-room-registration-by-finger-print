using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassRoomRegistration
{
    public class ValidateInput
    {
        public static bool CheckAllowKeyCharNumber(int value)
        {
            if (value >= 48 && value <= 57)
            {
                return true;
            }

            if (value >= 65 && value <= 90)
            {
                return true;
            }

            if (value >= 97 && value <= 122)
            {
                return true;
            }

            if (value == 127 || value == 9 || value == 8)
            {
                return true;
            }

            return false;
        }

        public static bool CheckAllowKeyNumber(int value)
        {
            if (value >= 48 && value <= 57)
            {
                return true;
            }

            if (value == 127 || value == 9 || value == 8)
            {
                return true;
            }

            return false;
        }
    }
}
