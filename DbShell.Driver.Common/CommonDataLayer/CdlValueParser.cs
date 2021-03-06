﻿using System;
using System.Globalization;
using DbShell.Driver.Common.Utility;
using System.Text.RegularExpressions;

namespace DbShell.Driver.Common.CommonDataLayer
{
    public sealed class CdlValueParser : ICdlValueParser
    {
        NumberFormatInfo m_numberFormat;
        DataFormatSettings m_settings;

        public CdlValueParser(DataFormatSettings settings)
        {
            m_settings = settings;
            m_numberFormat = m_settings.GetNumberFormat();
        }

        public void ParseError(string text, TypeStorage type, ICdlValueWriter writer)
        {
            var error = new DataParseError(text, type);
            //if (m_settings.LogAllErrors) ProgressInfo.Error(error.Message);
            switch (m_settings.OnErrorMode)
            {
                case OnDataErrorMode.Propagate:
                    throw error;
                case OnDataErrorMode.UseDefault:
                    m_settings.WriteErrorDefault(type, writer);
                    break;
                case OnDataErrorMode.UseNull:
                    writer.SetNull();
                    break;
            }
        }

        #region ICdlValueParser Members

        //public IProgressInfo ProgressInfo { get; set; }

        private static bool IsNullTextTest(string text)
        {
            if (String.IsNullOrWhiteSpace(text)) return true;
            string tested = text.ToUpper().Trim();
            if (tested == "NULL" || tested == "NIL") return true;
            return false;
        }

        public void ParseValue(string text, TypeStorage type, ICdlValueWriter writer)
        {
            foreach (string nulltext in m_settings.GetNullValues())
            {
                if (text == nulltext)
                {
                    writer.SetNull();
                    return;
                }
            }
            NumberStyles floatStyle = NumberStyles.Float | NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowExponent;
            NumberStyles intStyle = NumberStyles.Integer | NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite;
            NumberStyles decStyle = NumberStyles.Number | NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowExponent;
            switch (type)
            {
                case TypeStorage.Null:
                    writer.SetNull();
                    break;
                case TypeStorage.Boolean:
                    {
                        if (IsNullTextTest(text))
                        {
                            writer.SetNull();
                        }
                        else
                        {
                            bool? val = m_settings.ParseBoolean(text);
                            if (val != null) writer.SetBoolean(val.Value);
                            else writer.SetNull();
                        }
                    }
                    break;
                case TypeStorage.Byte:
                    {
                        byte val;
                        if (IsNullTextTest(text))
                        {
                            writer.SetNull();
                        }
                        else if (Byte.TryParse(text, intStyle, m_numberFormat, out val))
                        {
                            writer.SetByte(val);
                        }
                        else
                        {
                            ParseError(text, type, writer);
                        }
                    }
                    break;
                case TypeStorage.Int16:
                    {
                        short val;
                        if (IsNullTextTest(text))
                        {
                            writer.SetNull();
                        }
                        else if (Int16.TryParse(text, intStyle, m_numberFormat, out val))
                        {
                            writer.SetInt16(val);
                        }
                        else
                        {
                            ParseError(text, type, writer);
                        }
                    }
                    break;
                case TypeStorage.Int32:
                    {
                        int val;
                        if (IsNullTextTest(text))
                        {
                            writer.SetNull();
                        }
                        else if (Int32.TryParse(text, intStyle, m_numberFormat, out val))
                        {
                            writer.SetInt32(val);
                        }
                        else
                        {
                            ParseError(text, type, writer);
                        }
                    }
                    break;
                case TypeStorage.Int64:
                    {
                        long val;
                        if (IsNullTextTest(text))
                        {
                            writer.SetNull();
                        }
                        else if (Int64.TryParse(text, intStyle, m_numberFormat, out val))
                        {
                            writer.SetInt64(val);
                        }
                        else
                        {
                            ParseError(text, type, writer);
                        }
                    }
                    break;
                case TypeStorage.SByte:
                    {
                        sbyte val;
                        if (IsNullTextTest(text))
                        {
                            writer.SetNull();
                        }
                        else if (SByte.TryParse(text, intStyle, m_numberFormat, out val))
                        {
                            writer.SetSByte(val);
                        }
                        else
                        {
                            ParseError(text, type, writer);
                        }
                    }
                    break;
                case TypeStorage.UInt16:
                    {
                        ushort val;
                        if (IsNullTextTest(text))
                        {
                            writer.SetNull();
                        }
                        else if (UInt16.TryParse(text, intStyle, m_numberFormat, out val))
                        {
                            writer.SetUInt16(val);
                        }
                        else
                        {
                            ParseError(text, type, writer);
                        }
                    }
                    break;
                case TypeStorage.UInt32:
                    {
                        uint val;
                        if (IsNullTextTest(text))
                        {
                            writer.SetNull();
                        }
                        else if (UInt32.TryParse(text, intStyle, m_numberFormat, out val))
                        {
                            writer.SetUInt32(val);
                        }
                        else
                        {
                            ParseError(text, type, writer);
                        }
                    }
                    break;
                case TypeStorage.UInt64:
                    {
                        ulong val;
                        if (IsNullTextTest(text))
                        {
                            writer.SetNull();
                        }
                        else if (UInt64.TryParse(text, intStyle, m_numberFormat, out val))
                        {
                            writer.SetUInt64(val);
                        }
                        else
                        {
                            ParseError(text, type, writer);
                        }
                    }
                    break;
                case TypeStorage.Float:
                    {
                        float val;
                        if (IsNullTextTest(text))
                        {
                            writer.SetNull();
                        }
                        else if (Single.TryParse(text, floatStyle, m_numberFormat, out val))
                        {
                            writer.SetFloat(val);
                        }
                        else
                        {
                            ParseError(text, type, writer);
                        }
                    }
                    break;
                case TypeStorage.Double:
                    {
                        double val;
                        if (IsNullTextTest(text))
                        {
                            writer.SetNull();
                        }
                        else if (Double.TryParse(text, floatStyle, m_numberFormat, out val))
                        {
                            writer.SetDouble(val);
                        }
                        else
                        {
                            ParseError(text, type, writer);
                        }
                    }
                    break;
                case TypeStorage.Decimal:
                    {
                        decimal val;
                        if (IsNullTextTest(text))
                        {
                            writer.SetNull();
                        }
                        else if (Decimal.TryParse(text, decStyle, m_numberFormat, out val))
                        {
                            writer.SetDecimal(val);
                        }
                        else
                        {
                            ParseError(text, type, writer);
                        }
                    }
                    break;
                case TypeStorage.DateTime:
                    {
                        DateTime val;
                        if (IsNullTextTest(text))
                        {
                            writer.SetNull();
                        }
                        else if (DateTime.TryParseExact(text, m_settings.DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out val))
                        {
                            writer.SetDateTime(val);
                        }
                        else if (DateTime.TryParse(text, CultureInfo.InvariantCulture, DateTimeStyles.None, out val))
                        {
                            writer.SetDateTime(val);
                        }
                        else
                        {
                            ParseError(text, type, writer);
                        }
                    }
                    break;
                case TypeStorage.DateTimeEx:
                    if (IsNullTextTest(text))
                    {
                        writer.SetNull();
                    }
                    else
                    {
                        try
                        {
                            writer.SetDateTimeEx(DateTimeEx.Parse(text, m_settings.DateTimeFormat, CultureInfo.InvariantCulture));
                        }
                        catch
                        {
                            writer.SetDateTimeEx(DateTimeEx.FromDateTime(DateTime.Parse(text, CultureInfo.InvariantCulture)));
                        }
                    }
                    break;
                case TypeStorage.DateEx:
                    if (IsNullTextTest(text))
                    {
                        writer.SetNull();
                    }
                    else
                    {
                        try
                        {
                            writer.SetDateEx(DateTimeEx.Parse(text, m_settings.DateFormat, CultureInfo.InvariantCulture).DatePart);
                        }
                        catch
                        {
                            writer.SetDateEx(DateTimeEx.FromDateTime(DateTime.Parse(text, CultureInfo.InvariantCulture)).DatePart);
                        }
                    }
                    break;
                case TypeStorage.TimeEx:
                    if (IsNullTextTest(text))
                    {
                        writer.SetNull();
                    }
                    else
                    {
                        try
                        {
                            writer.SetTimeEx(DateTimeEx.Parse(text, m_settings.TimeFormat, CultureInfo.InvariantCulture).TimePart);
                        }
                        catch
                        {
                            writer.SetTimeEx(DateTimeEx.FromDateTime(DateTime.Parse(text, CultureInfo.InvariantCulture)).TimePart);
                        }
                    }
                    break;
                case TypeStorage.ByteArray:
                    if (IsNullTextTest(text))
                    {
                        writer.SetNull();
                    }
                    else if (Regex.Match(text, @"^([A-Za-z0-9+/]{4})*([A-Za-z0-9+/]{4}|[A-Za-z0-9+/]{3}=|[A-Za-z0-9+/]{2}==)$").Success)
                    {
                        writer.SetByteArray(Convert.FromBase64String(text));
                    }
                    else
                    {
                        writer.SetNull();
                    }
                    break;
                case TypeStorage.Guid:
                    if (IsNullTextTest(text))
                    {
                        writer.SetNull();
                    }
                    else
                    {
                        writer.SetGuid(new Guid(text));
                    }
                    break;
                case TypeStorage.String:
                    writer.SetString(text);
                    break;
                    //case TypeStorage.Array:
                    //    writer.SetArray(CdlArray.Parse(text));
                    //    break;
            }
        }

        #endregion
    }
}
