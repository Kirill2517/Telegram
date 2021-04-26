using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramLib.Share.Utils.Extensions;

namespace TelegramLib.Resume.enums
{
    [Flags]
    [JsonConverter(typeof(FlagConverter))]
    public enum ResumeEnum
    {
        Id = 1,
        Owner = 2,
        Speciality = 4,
        workExperience = 8,
        desiredSalary = 16,
        description = 32,
        title = 64,
        created = 128,
        skills = 256
    }
}
