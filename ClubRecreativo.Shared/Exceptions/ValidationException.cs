namespace ClubRecreativo.Shared.Exceptions
{
    /// <summary>
    /// Excepción lanzada cuando la validación de un objeto falla.
    /// </summary>
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }
}
