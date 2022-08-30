namespace DEDSEC.Domain.Exceptions
{
    /// <summary>
    /// Исключение, возникающее если при логине пользователь, не имеющий прав администратора, отмечает галочку IsAdmin
    /// </summary>
    public class AdministrationCodeMissingException : Exception
    {
        public bool IsAdmin { get; set; }

        public AdministrationCodeMissingException(bool isAdmin)
        {
            IsAdmin = isAdmin;
        }

        public AdministrationCodeMissingException(string? message, bool isAdmin) : base(message)
        {
            IsAdmin = isAdmin;
        }

        public AdministrationCodeMissingException(string? message, Exception? innerException, bool isAdmin) : base(message, innerException)
        {
            IsAdmin = isAdmin;
        }
    }
}
