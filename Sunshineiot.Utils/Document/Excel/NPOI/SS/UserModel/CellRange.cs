﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sunshineiot.Utils.NPOI.SS.UserModel
{
    public interface ICellRange<T> : IEnumerable<T> where T : ICell
    {
        int Width { get; }
        int Height { get; }
        int Size { get; }
        string ReferenceText { get; }
        T TopLeftCell { get; }
        T GetCell(int relativeRowIndex, int relativeColumnIndex);
        T[] FlattenedCells{get;}
        T[][] Cells { get; }
    }
}
