namespace ClubRecreativo.Shared.Exceptions
{
    /// <summary>
    /// Excepción lanzada cuando un recurso no es encontrado.
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}
