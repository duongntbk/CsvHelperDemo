using CsvHelper.Configuration;

namespace CsvHelperDemo
{
    public class PersonMapWithConverter : ClassMap<PersonV2>
    {
        public PersonMapWithConverter()
        {
            Map(p => p.FirstName);
            Map(p => p.LastName);
            Map(p => p.Age);
            Map(p => p.IsActive).TypeConverter<CustomBooleanConverter>();
        }
    }
}
