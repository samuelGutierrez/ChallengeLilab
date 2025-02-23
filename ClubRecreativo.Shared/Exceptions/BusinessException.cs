namespace ClubRecreativo.Shared.Exceptions
{
    /// <summary>
    /// Excepción para errores de negocio específicos.
    /// </summary>
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message) { }
    }
}
