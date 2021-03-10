using System;
using System.Collections.Generic;
using System.Text;

namespace HhLib.DataBaseImage
{
    public class ApplicantImage : BDImageBase
    {
        public override string Title => "Applicant";
        public override string IdFieldName => "idApplicant";
        public override string InsertCommand => $"INSERT INTO {Title} ({IdFieldName})";
    }
}
