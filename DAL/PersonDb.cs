using System;
using System.Collections.Generic;
using System.Data;
using Common.DTO;

namespace DAL
{
    public class PersonDb: DalBase
    {
        public static PersonDto GetPersonByPersonGuid(Guid personGuid)
        {
            var command = GetDbSprocCommand("Person_GetByPersonGuid");
            command.Parameters.Add(CreateParameter("@PersonGuid", personGuid));
            return GetSingleDto<PersonDto>(ref command);
        }


        public static PersonDto GetPersonByEmail(string email)
        {
            var command = GetDbSprocCommand("Person_GetByEmail");
            command.Parameters.Add(CreateParameter("@Email", email, 100));
            return GetSingleDto<PersonDto>(ref command);
        }

        public static List<PersonDto> GetAll()
        {
            var command = GetDbSprocCommand("Person_GetAll");
            return GetDtoList<PersonDto>(ref command);
        }

        public static void SavePerson(ref PersonDto person)
        {
            var isNewRecord = person.PersonGuid.Equals(CommonBase.GuidNullValue);

            var command = GetDbSprocCommand("Person_Save");
            command.Parameters.Add(CreateParameter("@PersonGuid", person.PersonGuid));
            command.Parameters.Add(CreateParameter("@Password", person.Password, 20));
            command.Parameters.Add(CreateParameter("@Name", person.Name, 100));
            command.Parameters.Add(CreateParameter("@Nickname", person.Nickname, 50));
            command.Parameters.Add(CreateParameter("@PhoneMobile", person.PhoneMobile, 25));
            command.Parameters.Add(CreateParameter("@PhoneHome", person.PhoneHome, 25));
            command.Parameters.Add(CreateParameter("@Email", person.Email, 100));
            command.Parameters.Add(CreateParameter("@ImAddress", person.ImAddress, 50));
            command.Parameters.Add(CreateParameter("@ImType", person.ImType));
            command.Parameters.Add(CreateParameter("@TimeZoneId", person.TimeZoneId));
            command.Parameters.Add(CreateParameter("@LanguageId", person.LanguageId));
            var paramIsDuplicateEmail = CreateOutputParameter("@IsDuplicateEmail", SqlDbType.Bit);
            command.Parameters.Add(paramIsDuplicateEmail);
            var paramNewPersonGuid = CreateOutputParameter("@NewPersonGuid", SqlDbType.UniqueIdentifier);
            command.Parameters.Add(paramNewPersonGuid);

            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

            if ((bool)paramIsDuplicateEmail.Value) { throw new Common.Exceptions.DuplicateEmailException(); }

            if (isNewRecord) { person.PersonGuid = (Guid)paramNewPersonGuid.Value; }
        }
    }
}
