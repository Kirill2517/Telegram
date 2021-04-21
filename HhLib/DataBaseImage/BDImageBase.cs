using HhLib.DataBaseImage.Models;
using HhLib.Share.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HhLib.DataBaseImage
{
    internal abstract class BDImageBase
    {
        public abstract string Title { get; }
        public abstract string IdFieldName { get; }
        public abstract string InsertCommand { get; }
        public abstract string FieldsName { get; }
        public abstract Dictionary<string, object> UniqFields(Share.Models.Object hhObject);
        protected virtual DbIndex[] Indexes => new DbIndex[0];
        internal virtual Dictionary<DbIndex, object> GetIndexes(Share.Models.Object hhObject) { return new Dictionary<DbIndex, object>(); }
    }
}
