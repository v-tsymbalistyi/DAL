using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Common.DTO;
using DAL.Parsers;

namespace DAL
{
    public class DalBase
    {
        protected static string ConnectionString => 
            ConfigurationManager.ConnectionStrings[""].ConnectionString;

        protected static SqlConnection GetDbConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        protected static SqlCommand GetDbSqlCommand(string sqlQuery)
        {
            return new SqlCommand
            {
                Connection = GetDbConnection(),
                CommandType = CommandType.Text,
                CommandText = sqlQuery
            };
        }

        protected static SqlCommand GetDbSprocCommand(string sprocName)
        {
            return new SqlCommand(sprocName)
            {
                Connection = GetDbConnection(),
                CommandType = CommandType.StoredProcedure
            };
        }

        protected static SqlParameter CreateNullParameter(string name, SqlDbType paramType)
        {
            return new SqlParameter
            {
                SqlDbType = paramType,
                ParameterName = name,
                Value = null,
                Direction = ParameterDirection.Input
            };
        }

        protected static SqlParameter CreateNullParameter(string name, SqlDbType paramType, int size)
        {
            return new SqlParameter
            {
                SqlDbType = paramType,
                ParameterName = name,
                Size = size,
                Value = null,
                Direction = ParameterDirection.Input
            };
        }

        protected static SqlParameter CreateOutputParameter(string name, SqlDbType paramType)
        {
            return new SqlParameter
            {
                SqlDbType = paramType,
                ParameterName = name,
                Direction = ParameterDirection.Output
            };
        }


        protected static SqlParameter CreateOutputParameter(string name, SqlDbType paramType, int size)
        {
            return new SqlParameter
            {
                SqlDbType = paramType,
                Size = size,
                ParameterName = name,
                Direction = ParameterDirection.Output
            };
        }

        protected static SqlParameter CreateParameter(string name, Guid value)
        {
            if (value.Equals(CommonBase.GuidNullValue))
            {
                return CreateNullParameter(name, SqlDbType.UniqueIdentifier);
            }

            return new SqlParameter
            {
                SqlDbType = SqlDbType.UniqueIdentifier,
                ParameterName = name,
                Value = value,
                Direction = ParameterDirection.Input
            };
        }

        protected static SqlParameter CreateParameter(string name, int value)
        {
            if (value.Equals(CommonBase.IntNullValue))
            {
                return CreateNullParameter(name, SqlDbType.Int);
            }
            
            return new SqlParameter
            {
                SqlDbType = SqlDbType.Int,
                ParameterName = name,
                Value = value,
                Direction = ParameterDirection.Input
            };
        }

        protected static SqlParameter CreateParameter(string name, DateTime value)
        {
            if (value == CommonBase.DateTimeNullValue)
            {
                return CreateNullParameter(name, SqlDbType.DateTime);
            }
            else
            {
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.DateTime;
                parameter.ParameterName = name;
                parameter.Value = value;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
        }

        protected static SqlParameter CreateParameter(string name, string value, int size)
        {
            if (value == CommonBase.StringNullValue)
            {
                return CreateNullParameter(name, SqlDbType.NVarChar);
            }

            return new SqlParameter
            {
                SqlDbType = SqlDbType.NVarChar,
                Size = size,
                ParameterName = name,
                Value = value,
                Direction = ParameterDirection.Input
            };
        }

        protected static T GetSingleDto<T>(ref SqlCommand command) where T : DtoBase
        {
            T dto = null;
            try
            {
                command.Connection.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    var parser = DtoParserFactory.GetParser(typeof (T));
                    parser.PopulateOrdinals(reader);
                    dto = (T) parser.PopulateDto(reader);
                    reader.Close();
                }
                else
                {
                    dto = null;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error populating data", e);
            }
            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
            }
            return dto;
        }

        protected static List<T> GetDtoList<T>(ref SqlCommand command) where T : DtoBase
        {
            var dtoList = new List<T>();
            try
            {
                command.Connection.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    var parser = DtoParserFactory.GetParser(typeof(T));
                    parser.PopulateOrdinals(reader);
                    while (reader.Read())
                    {
                        var dto = (T)parser.PopulateDto(reader);
                        dtoList.Add(dto);
                    }
                    reader.Close();
                }
                else
                {
                    dtoList = null;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error populating data", e);
            }
            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
            }
            return dtoList;
        }
    }
}
