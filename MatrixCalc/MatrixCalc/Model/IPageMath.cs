﻿using System;
using System.Collections.Generic;

namespace MatrixCalc.Model
{
	public interface IPageMath
	{
        int CalculateMax(List<InputEntry> EntryList);
        int CalculateMin(List<InputEntry> EntryList);
        int CalculateAverage(List<InputEntry> EntryList);
        int CalculateSum(List<InputEntry> EntryLists);
    }
}

