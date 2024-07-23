namespace obsCommon.configFontIcon.commandContract.Exceptions
{
    /// <summary>
    /// Provide not found exception
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
