using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lancamentos.Business.LancamentoBLL.Interface
{
    public interface IMessagePublisher
    {
        Task PublishAsync<T>(T message);
    }
}
