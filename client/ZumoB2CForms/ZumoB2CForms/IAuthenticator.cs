using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZumoB2CForms
{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateAsync();
    }
}
