using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvBuilder.Core.Interfaces
{
    public interface IByUser
    {
        public Guid UserId { get; protected set; }
    }
}
