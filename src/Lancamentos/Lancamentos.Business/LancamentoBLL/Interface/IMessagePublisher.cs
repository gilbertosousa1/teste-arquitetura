namespace Lancamentos.Business.LancamentoBLL.Interface
{
    public interface IMessagePublisher
    {
        Task PublishAsync<T>(T message);
    }
}
