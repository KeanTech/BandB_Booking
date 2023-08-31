using B_B_api.Data;
using System.Security.Cryptography;
using System.Text;

namespace B_B_api.Managers
{
    public class LoginManager
    {
        public string GenerateSalt()
        {
            using (var randomGenerator = new RNGCryptoServiceProvider())
            {
                byte[] buff = new byte[8];
                randomGenerator.GetBytes(buff);

                return Convert.ToBase64String(buff);
            }
        }

        public bool CheckUsername(string username, BedAndBreakfastContext context)
        {
            var user = context.Users.Where(x => x.Username.Equals(username)).FirstOrDefault();
            if (user != null)
            {
                string name = user.Username;
                if (username == name)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public string CreateHashedPassword(string passwrd, string salt)
        {
            byte[] pwdWithSalt = Encoding.ASCII.GetBytes(string.Concat(passwrd, salt));
            using (var sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(pwdWithSalt));
            }
        }

        public string GetSaltFromDB(string username, BedAndBreakfastContext context)
        {
            var user = context.Users.Where(x => x.Username.Equals(username)).FirstOrDefault();
            return user.PasswordSalt;
        }

        public string GetHashedPasswordFromDB(string username, BedAndBreakfastContext context)
        {
            var user = context.Users.Where(x => x.Username == username).FirstOrDefault();
            return user.Password;
        }

        public bool ValidatePassword(string password, string salt, string HashedPassword)
        {
            string tempPwd = "";
            byte[] pwdWithSaltFromDB = Encoding.ASCII.GetBytes(string.Concat(password, salt));
            using (var sha256 = SHA256.Create())
            {
                tempPwd = Convert.ToBase64String(sha256.ComputeHash(pwdWithSaltFromDB));
            }
            if (tempPwd == HashedPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
