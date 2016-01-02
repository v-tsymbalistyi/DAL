using System.Data.SqlClient;
using Common.DTO;

namespace DAL.Parsers
{
    internal class PersonDtoParser : DtoParser
    {
        private int _ordPersonGuid;
        private int _ordPersonId;
        private int _ordUtcCreated;
        private int _ordUtcModified;
        private int _ordPassword;
        private int _ordName;
        private int _ordNickname;
        private int _ordPhoneMobile;
        private int _ordPhoneHome;
        private int _ordEmail;
        private int _ordImAddress;
        private int _ordImType;
        private int _ordTimeZoneId;
        private int _ordLanguageId;
        private int _ordCity;
        private int _ordState;
        private int _ordZipCode;


        public override void PopulateOrdinals(SqlDataReader reader)
        {
            _ordPersonGuid = reader.GetOrdinal("person_guid");
            _ordPersonId = reader.GetOrdinal("person_id");
            _ordUtcCreated = reader.GetOrdinal("utc_created");
            _ordUtcModified = reader.GetOrdinal("utc_modified");
            _ordPassword = reader.GetOrdinal("password");
            _ordName = reader.GetOrdinal("name");
            _ordNickname = reader.GetOrdinal("nickname");
            _ordPhoneMobile = reader.GetOrdinal("phone_mobile");
            _ordPhoneHome = reader.GetOrdinal("phone_home");
            _ordEmail = reader.GetOrdinal("email");
            _ordImAddress = reader.GetOrdinal("im_address");
            _ordImType = reader.GetOrdinal("im_type");
            _ordTimeZoneId = reader.GetOrdinal("time_zone_id");
            _ordLanguageId = reader.GetOrdinal("language_id");
            _ordCity = reader.GetOrdinal("city");
            _ordState = reader.GetOrdinal("state_code");
            _ordZipCode = reader.GetOrdinal("zip_code");
        }

        public override DtoBase PopulateDto(SqlDataReader reader)
        {
            var person = new PersonDto();
            
            if (!reader.IsDBNull(_ordPersonGuid))
            {
                person.PersonGuid = reader.GetGuid(_ordPersonGuid);
            }

            if (!reader.IsDBNull(_ordPersonId))
            {
                person.PersonId = reader.GetInt32(_ordPersonId);
            }

            if (!reader.IsDBNull(_ordUtcCreated))
            {
                person.UtcCreated = reader.GetDateTime(_ordUtcCreated);
            }

            if (!reader.IsDBNull(_ordUtcModified))
            {
                person.UtcModified = reader.GetDateTime(_ordUtcModified);
            }

            if (!reader.IsDBNull(_ordPassword))
            {
                person.Password = reader.GetString(_ordPassword);
            }

            if (!reader.IsDBNull(_ordName))
            {
                person.Name = reader.GetString(_ordName);
            }

            if (!reader.IsDBNull(_ordNickname))
            {
                person.Nickname = reader.GetString(_ordNickname);
            }

            if (!reader.IsDBNull(_ordPhoneMobile))
            {
                person.PhoneMobile = reader.GetString(_ordPhoneMobile);
            }

            if (!reader.IsDBNull(_ordPhoneHome))
            {
                person.PhoneHome = reader.GetString(_ordPhoneHome);
            }

            if (!reader.IsDBNull(_ordEmail))
            {
                person.Email = reader.GetString(_ordEmail);
            }

            if (!reader.IsDBNull(_ordImAddress))
            {
                person.ImAddress = reader.GetString(_ordImAddress);
            }

            if (!reader.IsDBNull(_ordImType))
            {
                person.ImType = reader.GetInt32(_ordImType);
            }

            if (!reader.IsDBNull(_ordTimeZoneId))
            {
                person.TimeZoneId = reader.GetInt32(_ordTimeZoneId);
            }

            if (!reader.IsDBNull(_ordLanguageId))
            {
                person.LanguageId = reader.GetInt32(_ordLanguageId);
            }

            if (!reader.IsDBNull(_ordCity))
            {
                person.City = reader.GetString(_ordCity);
            }

            if (!reader.IsDBNull(_ordState))
            {
                person.State = reader.GetString(_ordState);
            }

            if (!reader.IsDBNull(_ordZipCode))
            {
                person.ZipCode = reader.GetInt32(_ordZipCode);
            }

            person.IsNew = false;

            return person;
        }
    }
}
