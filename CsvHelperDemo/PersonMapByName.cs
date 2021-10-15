using CsvHelper.Configuration;

namespace CsvHelperDemo
{
    public class PersonMapByName : ClassMap<PersonV1>
    {
        public PersonMapByName()
        {
            Map(p => p.FirstName).Name("名");
            Map(p => p.LastName).Name("姓");
            Map(p => p.Age).Name("年齢");
            Map(p => p.IsActive).Name("アクティブ");
        }
    }
}
