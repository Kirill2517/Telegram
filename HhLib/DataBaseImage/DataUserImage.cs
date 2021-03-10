using System;
using System.Collections.Generic;
using System.Text;

namespace HhLib.DataBaseImage
{
    public class DataUserImage : BDImageBase
    {
        public override string Title => "DataUser";
        public override string IdFieldName => "id";
        public override string InsertCommand => $"INSERT INTO {Title} (`email`, `firstName`, `middleName`, `birthday`, `surname`, `phone`, `password`) ";
    }
}
