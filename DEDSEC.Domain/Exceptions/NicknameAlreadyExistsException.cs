namespace DEDSEC.Domain.Exceptions
{
    /// <summary>
    /// Исключение возникающее при попытке создать аккаунт с никнеймом, который уже занят
    /// </summary>
    public class NicknameAlreadyExistsException : Exception
    {
        public string Nickname { get; set; }

        public NicknameAlreadyExistsException(string nickname)
        {
            Nickname = nickname;
        }

        public NicknameAlreadyExistsException(string? message, string nickname) : base(message)
        {
            Nickname = nickname;
        }

        public NicknameAlreadyExistsException(string? message, Exception? innerException, string nickname) : base(message, innerException)
        {
            Nickname = nickname;
        }
    }
}
