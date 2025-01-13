using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XM1.SportsData.Producer.Application.Interface
{
    public interface ISecretsManager
    {
        T GetSecret<T>(string secretName);
    }
}
