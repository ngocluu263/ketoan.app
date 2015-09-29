using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsVproUtility
/// </summary>
public class Utils
{
    public static int CIntDef(object Expression, int DefaultValue)
    {
        try
        {
            return System.Convert.ToInt32(Expression);
        }
        catch (Exception)
        {
            return DefaultValue;
        }
    }

    public static string CStrGuid(object Expression, string DefaultValue)
    {
        try
        {
            Guid g;
            g = new Guid(Expression.ToString());
            return Expression.ToString();
        }
        catch (Exception)
        {
            return DefaultValue;
        }
    }

    public static long CLngDef(object Expression, int DefaultValue)
    {
        try
        {
            return System.Convert.ToInt32(Expression);
        }
        catch (Exception)
        {
            return DefaultValue;
        }
    }

    public static bool CBoolDef(object Experssion, bool DefaultValue)
    {
        try
        {
            return System.Convert.ToBoolean(Experssion);
        }
        catch (Exception)
        {
            return DefaultValue;
        }
    }

    public static decimal CDecDef(object Expression, decimal DefaultValue)
    {
        try
        {
            return System.Convert.ToDecimal(Expression);
        }
        catch (Exception)
        {
            return DefaultValue;
        }
    }

    public static double CDblDef(object Expression, double DefaultValue)
    {
        try
        {
            return System.Convert.ToDouble(Expression);
        }
        catch (Exception)
        {
            return DefaultValue;
        }
    }

    public static DateTime CDateDef(object Expression, DateTime DefaultValue)
    {
        try
        {
            return System.Convert.ToDateTime(Expression);
        }
        catch (Exception)
        {
            return DefaultValue;
        }
    }

    public static string CStrDef(object Expression, string DefaultValue)
    {
        try
        {
            return Expression.ToString().Trim();
        }
        catch (Exception)
        {
            return DefaultValue;
        }
    }
}