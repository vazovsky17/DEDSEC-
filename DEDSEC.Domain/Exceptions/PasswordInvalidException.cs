namespace DEDSEC.Domain.Exceptions
{
    /// <summary>
    /// Исключение, возникающее при попытке ввести неверный пароль
    /// </summary>
    public class PasswordInvalidException : Exception
    {
        public string Nickname { get; set; }
        public string Password { get; set; }

        public PasswordInvalidException(string nickname, string password)
        {
            Nickname = nickname;
            Password = password;
        }

        public PasswordInvalidException(string message, string nickname, string password) : base(message)
        {
            Nickname = nickname;
            Password = password;
        }

        public PasswordInvalidException(string message, Exception innerException, string nickname, string password) : base(message, innerException)
        {
            Nickname = nickname;
            Password = password;
        }
    }
}
