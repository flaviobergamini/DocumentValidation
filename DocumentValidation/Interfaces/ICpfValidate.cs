using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentValidation.Interfaces
{
    public interface ICpfValidate
    {
        bool MathCpfValidate(string fullCpf);
    }
}
