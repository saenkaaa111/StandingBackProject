namespace StandingBackProject.Business.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
        public NotFoundException(string entityName, int id) : base($"{entityName} c Id = {id} не найден") { }
    }
}
