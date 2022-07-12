using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace PMOApp.Models
{
    public class commonModel
    {
        internal static Boolean CheckRoles(string chkR)
        {
            Boolean res = false;
            try
            {
                string[] usrRoles = (string[])App.Current.Properties["ARRuser_UserRole"]; //APP CURRENT PROPERTIES IS A DATA THAT WE STORE FOR TEMPORARY

                int pos = Array.IndexOf(usrRoles, chkR);
                if (pos > -1)
                {
                    res = true;
                }
            }
            catch
            {
                res = false;
            }
            return res;


        }
        internal static List<string> GetAllPhotosExtensions()
        {
            var list = new List<string>();
            list.Add(".jpg");
            list.Add(".png");
            list.Add(".bmp");
            list.Add(".gif");
            list.Add(".jpeg");
            list.Add(".tiff");
            return list;
        }
        public static bool IsPhoto(string fileName)
        {
            var list = GetAllPhotosExtensions();
            var filename = fileName.ToLower();
            bool isThere = false;
            foreach (var item in list)
            {
                if (filename.EndsWith(item))
                {
                    isThere = true;
                    break;
                }
            }
            return isThere;
        }
        internal static bool IsBase64String(string s)
        {
            s = s.Trim();
            return (s.Length % 4 == 0) && Regex.IsMatch(s, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);

        }
        internal static bool Parsebool(object valParameter)
        {
            try
            {
                if (valParameter != null)
                {
                    return Convert.ToBoolean(valParameter);
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        internal static int ParseInt(object valParameter)
        {
            try
            {
                if (valParameter != null)
                {
                    return Convert.ToInt32(valParameter);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        internal static String ParseString(object valParameter)
        {
            try
            {
                if (valParameter != null)
                {

                    //how to convert &amp; to a string  
                    string strVal = Convert.ToString(valParameter);
                    strVal = strVal.Replace("&apos;", "'");
                    strVal = strVal.Replace("&quot;", "\"");
                    strVal = strVal.Replace("&gt;", ">");
                    strVal = strVal.Replace("&lt;", "<");
                    strVal = strVal.Replace("&amp;", "&");

                    return strVal;
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
        }
        internal static String ParseStringtoXML(string valParameter)
        {
            try
            {
                if (valParameter != null)
                {

                    //how to convert &amp; to a string 
                    string strVal = valParameter.Replace("&", "&amp;");
                    strVal = strVal.Replace("&", "&amp;");
                    strVal = strVal.Replace("'", "&apos;");
                    strVal = strVal.Replace("\"", "&quot;");
                    strVal = strVal.Replace(">", "&gt;");
                    strVal = strVal.Replace("<", "&lt;");

                    return strVal;
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
        }
        internal static String ParseNodeString(XmlNode valParameter)
        {
            try
            {
                if (valParameter != null)
                {
                    return Convert.ToString(valParameter.InnerText);
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
        }
        internal static String Parsedate(string valParameter)
        {
            try
            {
                if (valParameter != null)
                {
                    if (valParameter.Contains("-"))
                    {

                        string[] tokens = valParameter.Split('-');
                        string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(ParseInt(tokens[1].ToString()));
                        string val = string.Format("{0} {1} {2}", tokens[2], monthName, tokens[0]);

                        return val;
                    }
                    else
                    {
                        return "";
                    }

                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
        }
        internal static DateTime ParsedateToDate(string valParameter)
        {


            DateTime dateVal = DateTime.Parse(valParameter);
            return dateVal;


        }
        internal static bool Isdate(string valParameter)
        {
            try
            {
                if (valParameter != null)
                {
                    if (valParameter.Contains("-"))
                    {

                        DateTime dateVal = DateTime.Parse(valParameter);
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        internal static bool IsNullOrWhiteSpace(String value)
        {
            if (value == null) return true;

            for (int i = 0; i < value.Length; i++)
            {
                if (!Char.IsWhiteSpace(value[i])) return false;
            }

            return true;
        }
    }
}
