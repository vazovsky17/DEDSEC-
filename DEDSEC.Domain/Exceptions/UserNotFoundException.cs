namespace DEDSEC.Domain.Exceptions
{
    /// <summary>
    /// Исключение, возникающее, если пользователь с таким никнеймом не был найден
    /// </summary>
    public class UserNotFoundException : Exception
    {
        public string Nickname { get; set; }

        public UserNotFoundException(string nickname)
        {
            Nickname = nickname;
        }

        public UserNotFoundException(string message, string nickname) : base(message)
        {
            Nickname = nickname;
        }

        public UserNotFoundException(string message, Exception innerException, string nickname) : base(message, innerException)
        {
            Nickname = nickname;
        }
    }
}
