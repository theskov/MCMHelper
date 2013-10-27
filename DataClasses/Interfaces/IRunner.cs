﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface IRunner
    {
        IEnumerable<string> GetSellerList(string cardName);
    }
}
