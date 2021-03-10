using System;
using System.Collections.Generic;
using System.Text;

namespace HhLib.DataBaseImage
{
    public class EmployerImage : BDImageBase
    {
        public override string Title => "Employer";
        public override string IdFieldName => "idEmployer";
        public override string InsertCommand => $"INSERT INTO {Title} ({IdFieldName})";
    }
}
