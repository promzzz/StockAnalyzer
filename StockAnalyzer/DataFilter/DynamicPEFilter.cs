﻿using StockAnalyzer.DataSource;
using StockAnalyzer.DataSource.TushareData;
using StockAnalyzer.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalyzer.DataFilter
{
    public class DynamicPEFilter : PEFilter
    {
        public DynamicPEFilter(double limitPE) : base(limitPE)
        {
            m_filterDesc = "DynamicPE";
        }

        public override bool getNumericValue(string stockID, out double val)
        {
            return calcDynamicPE(stockID, out val);
        }

        public static bool calcDynamicPE(string stockID, out double val)
        {
            StockMarketData md = StockDataCenter.getInstance().getMarketData(stockID);

            string year = GlobalConfig.getInstance().curYear;
            string quarter = GlobalConfig.getInstance().curQuarter;
            StockReportData rd = StockDBVisitor.getInstance().getStockReportData(stockID, year, quarter);

            val = 0.0;
            if (md != null && rd != null)
            {
                double profitVal = getEstimateProfitValue(rd.net_profits, quarter);
                val = md.totalCapitalisation * 10000.0 / profitVal;
                return true;
            }

            return false;
        }

        public static double getEstimateProfitValue(double profit, string quarter)
        {
            double quad = 4.0 / double.Parse(quarter);
            return profit * quad;
        }
    }
}
