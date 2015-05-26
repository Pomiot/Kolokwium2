using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagePublisher
{
    /// <summary>
    /// Your TODO: please follow insstruction 
    /// </summary>
    public class MessagesViewModel
    {
        private readonly IDispatcher _dispatcher;

        public MessagesViewModel(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;            
        }

    }
}
