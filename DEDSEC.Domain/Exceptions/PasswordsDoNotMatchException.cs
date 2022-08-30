namespace DEDSEC.Domain.Exceptions
{
    /// <summary>
    /// Исключение, возникающее, если пароль и подтверждение пароля не совпадают
    /// </summary>
    public class PasswordsDoNotMatchException : Exception
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public PasswordsDoNotMatchException(string password, string confirmPassword)
        {
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        public PasswordsDoNotMatchException(string? message, string password, string confirmPassword) : base(message)
        {
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        public PasswordsDoNotMatchException(string? message, Exception? innerException, string password, string confirmPassword) : base(message, innerException)
        {
            Password = password;
            ConfirmPassword = confirmPassword;
        }
    }
}
