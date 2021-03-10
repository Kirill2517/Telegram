using System;
using System.Collections.Generic;
using System.Text;

namespace HhLib.DataBaseImage
{
    public abstract class BDImageBase
    {
        public abstract string Title { get; }
        public abstract string IdFieldName { get; }
        public abstract string InsertCommand { get; }
    }
}
