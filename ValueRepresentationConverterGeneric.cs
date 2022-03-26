using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlockchain;

public class ValueRepresentationConverterGeneric<T> : ValueRepresentationConverter
{
    public ValueRepresentationConverterGeneric()
        : base(typeof(T))
    {
    }
}
