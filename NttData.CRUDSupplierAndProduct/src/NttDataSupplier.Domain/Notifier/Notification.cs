namespace NttDataSupplier.Domain.Notifier
{
    public class Notification
    {
        public string Erro { get; }

        public Notification(string erro)
        {
            Erro = erro;
        }
    }
}
