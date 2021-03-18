﻿using HhLib.Share.Models;
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
        public abstract string FieldsName { get; }
        public abstract Dictionary<string, object> UniqFields(HhObject hhObject);
    }
}
