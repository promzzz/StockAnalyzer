﻿using StockAnalyzer.DataAnalyze;
using StockAnalyzer.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalyzer.DataFilter
{
    public class PriceScaleFilter : StockFilter
    {
        private double m_ratio = 0.3;

        public PriceScaleFilter(double ratio) {
            m_ratio = ratio;
        }

        public override bool filterMethod(string stockID)
        {
            StockMarketData md = StockDataCenter.getInstance().getMarketData(stockID);

            if (md != null &&
                PriceAnalyzer.isPriceScaleSatisfied(stockID, md.latestPrice, m_ratio))
            {
                return true;
            }

            return false;
        }
    }
}
