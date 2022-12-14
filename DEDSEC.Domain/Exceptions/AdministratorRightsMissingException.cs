namespace DEDSEC.Domain.Exceptions
{
    /// <summary>
    /// Исключение, возникающее, если при логине пользователь, имеющий права администратора, забывает поставить галочку IsAdmin
    /// </summary>
    public class AdministratorRightsMissingException : Exception
    {
        public bool IsAdmin { get; set; }

        public AdministratorRightsMissingException(bool isAdmin)
        {
            IsAdmin = isAdmin;
        }

        public AdministratorRightsMissingException(string? message, bool isAdmin) : base(message)
        {
            IsAdmin = isAdmin;
        }

        public AdministratorRightsMissingException(string? message, Exception? innerException, bool isAdmin) : base(message, innerException)
        {
            IsAdmin = isAdmin;
        }
    }
}
