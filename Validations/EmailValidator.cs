using Dapper;

namespace geradoc_v2.Validations {
    public class EmailValidator {
        public static bool CheckEmail(Database _context, string email) {

            bool emailChecked = _context
                     .Connection
                     .Query<bool>("spChecarEmail", new {
                         Email = email
                     }, commandType: System.Data.CommandType.StoredProcedure)
                     .FirstOrDefault();

            return emailChecked;
        }


    }
}
