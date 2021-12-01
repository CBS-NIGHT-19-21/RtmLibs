using RtmLib.Rtm002Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.Rtm002Check
{
    public static class PostMarksHelper
    {
        public static int GetMaxPow(long value, out long rezValues)
        {
            if (value > 0)
            {
                if (value == 1)
                {
                    rezValues = 0;
                    return 0;
                }

                var logItem = Math.Floor(Math.Log(value, 2));
                rezValues = value - (long)Math.Pow(2, logItem);
                return (int)logItem;

            }
            else
            {
                rezValues = -1;
                return -1;
            }
        }
        /// <summary>
        /// Получаем данные по powtMars
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static List<PostMark> IsContainsValues(long value)
        {
            var itemCheck = value;
            List<PostMark> postMarks = new List<PostMark>();
            while(itemCheck > 0)
            {
                var powItem = GetMaxPow(itemCheck, out long rezVal);
                var itemPowCheck = (long)Math.Pow(2, powItem);
                postMarks.Add(itemPowCheck.GetTypePostMarkByCode());
                itemCheck = rezVal;
            }
            return postMarks;
        }
    }
}
