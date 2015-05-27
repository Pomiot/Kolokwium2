using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagePublisher
{
    public abstract class MessageSearcher
    {
        public abstract Func<Message, bool> Searcher();
    }
}
