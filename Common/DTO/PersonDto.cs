using System;

namespace Common.DTO
{
    public class PersonDto: DtoBase
    {
        public Guid PersonGuid { get; set; }
        public int PersonId { get; set; }
        public DateTime UtcCreated { get; set; }
        public DateTime UtcModified { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string PhoneMobile { get; set; }
        public string PhoneHome { get; set; }
        public string Email { get; set; }
        public string ImAddress { get; set; }
        public int ImType { get; set; }
        public int TimeZoneId { get; set; }
        public int LanguageId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        public PersonDto()
        {
            PersonGuid = GuidNullValue;
            PersonId = IntNullValue;
            UtcCreated = DateTimeNullValue;
            UtcModified = DateTimeNullValue;
            Name = StringNullValue;
            Nickname = StringNullValue;
            PhoneMobile = StringNullValue;
            PhoneHome = StringNullValue;
            Email = StringNullValue;
            ImAddress = StringNullValue;
            ImType = IntNullValue;
            TimeZoneId = IntNullValue;
            LanguageId = IntNullValue;
            City = StringNullValue;
            State = StringNullValue;
            ZipCode = IntNullValue;
            IsNew = true;
        }
    }
}
