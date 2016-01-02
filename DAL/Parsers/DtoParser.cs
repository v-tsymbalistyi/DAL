using System.Data.SqlClient;
using Common.DTO;

namespace DAL.Parsers
{
    abstract class DtoParser
    {
        public abstract DtoBase PopulateDto(SqlDataReader reader);
        public abstract void PopulateOrdinals(SqlDataReader reader);
    }
}
