using MelonStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MelonStore.Api.EnumConverters
{
    public static class Converter
    {
        public static Category GetCategory(string category)
        {
            if (category == Category.Jeans.ToString())
            {
                return Category.Jeans;
            }

            return default(Category);
        }

        public static Gender GetGender(string gender)
        {
            Gender result = default(Gender);

            return result;
        }
    }
}