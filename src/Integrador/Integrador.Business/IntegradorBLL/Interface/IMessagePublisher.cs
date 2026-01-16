namespace Integrador.Business.IntegradorBLL.Interface
{
    public interface IMessagePublisher
    {
        Task PublishAsync<T>(T message);
    }
}
