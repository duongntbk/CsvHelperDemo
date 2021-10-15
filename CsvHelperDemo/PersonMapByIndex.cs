using CsvHelper.Configuration;

namespace CsvHelperDemo
{
    public class PersonMapByIndex : ClassMap<PersonV1>
    {
        public PersonMapByIndex()
        {
            Map(p => p.FirstName).Index(0);
            Map(p => p.LastName).Index(1);
            Map(p => p.Age).Index(2);
            Map(p => p.IsActive).Index(4);
        }
    }
}
