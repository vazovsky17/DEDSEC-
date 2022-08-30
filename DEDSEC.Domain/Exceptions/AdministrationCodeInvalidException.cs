namespace DEDSEC.Domain.Exceptions
{
    /// <summary>
    /// Исключение, возникающее при попытке ввести неверный код администратора
    /// </summary>
    public class AdministrationCodeInvalidException : Exception
    {
        public string Code { get; set; }

        public AdministrationCodeInvalidException(string code)
        {
            Code = code;
        }

        public AdministrationCodeInvalidException(string? message, string code) : base(message)
        {
            Code = code;
        }

        public AdministrationCodeInvalidException(string? message, Exception innerException, string code) : base(message, innerException)
        {
            Code = code;
        }
    }
}
