﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalyzer.DataFilter
{
    public interface IStockFilter
    {
        List<string> filter(List<string> src);
    }
}
