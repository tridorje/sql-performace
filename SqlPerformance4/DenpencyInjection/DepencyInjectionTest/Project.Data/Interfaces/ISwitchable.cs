using System;
using System.Collections.Generic;
using System.Text;
using YayoiApp.Data.Enums;

namespace YayoiApp.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { set; get; }
    }
}
