using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;

namespace CsvHelperDemo
{
    public class CustomBooleanConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            return text.Equals("Yes", StringComparison.OrdinalIgnoreCase);
        }

        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            if (value is bool boolVal)
            {
                return boolVal ? "Yes" : "No";
            }

            throw new ArgumentException("Value must be a boolean");
        }
    }
}
