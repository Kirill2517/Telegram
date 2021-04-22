using HhLib.Share.Models;
using HhLib.Share.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.Resume.guider
{
    public class GuidResumeManager : GuidManagerBase
    {
        protected override string sqlPathFolder => base.sqlPathFolder + "/Resume";
        public async Task<Resume.model.Resume> GetResumeById(int id)
        {
            return await this.QueryCommandSingleOrDefaultAsync<Resume.model.Resume>($"{sqlPathFolder}/GetResumeById.sql".ReadStringFromatFromFile(id));
        }
    }
}
