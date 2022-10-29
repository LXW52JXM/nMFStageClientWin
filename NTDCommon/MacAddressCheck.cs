using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTDCommon
{
    class MacAddressCheck
    {
        private static List<string> ListStr = new List<string>
        {
            "02-00-4C-4F-4F-50",//陈文凭mac
            "00-E0-4C-1A-19-A6",//陈文凭台式电脑mac
            "D0-5F-64-33-55-4C",//赵长华笔记本
            "68-ED-A4-3B-4E-52",
            "68-ED-A4-3B-4F-07",
            "68-ED-A4-3B-4F-10",//河北保定
            "68-ED-A4-3B-4F-0F",
            "00-E0-4C-36-1D-55",
            "68-ED-A4-3C-90-20",//樱花梦1
            "68-ED-A4-3C-90-25",//樱花梦2
            "68-ED-A4-3C-90-1F",//N213400284
            "68-ED-A4-3B-4D-CF",//N213400284
            "00-E0-4F-68-90-17",
            "FC-F8-AE-B5-C5-E2",
            "08-97-98-76-D1-C2",
            "80-EA-07-DF-B5-F0",//192.168.0.113
            "80-86-F2-4F-34-31",//192.168.0.114
            "00-E0-4F-68-8C-D6"
        };

        public static bool CheckMacAddress(string s) {

            int i = ListStr.Where(it => it == s).Count();
            return i > 0;
        }
        public static bool CheckMacAddress(List<string> list)
        {
            foreach (var data in list) {
              int i = ListStr.Where(it => it == data).Count();
                if (i > 0) return true;
            }
            return false;
        }

        public static bool CheckMacAddress(List<string> list,out string macStr)
        {
            macStr = string.Empty;
            foreach (var data in list)
            {
                int i = ListStr.Where(it => it == data).Count();
                if (i > 0)
                {
                    macStr = data;
                    return true;
                } 
            }
            return false;
        }
    }
}
