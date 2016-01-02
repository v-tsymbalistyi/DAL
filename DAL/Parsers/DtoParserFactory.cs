using System;

namespace DAL.Parsers
{
    internal static class DtoParserFactory
    {

        // GetParser
        internal static DtoParser GetParser(Type dtoType)
        {
            switch (dtoType.Name)
            {
                case "PersonDto":
                    return new PersonDtoParser();
                //case "PostDTO":
                //    return new DTOParser_Post();
                //    break;
                //case "SiteProfileDTO":
                //    return new DTOParser_SiteProfile();
                //    break;
            }
            // if we reach this point then we failed to find a matching type. Throw
            // an exception.
            throw new Exception("Unknown Type");
        }

    }
}
