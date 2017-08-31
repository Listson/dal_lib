using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sunshineiot.Utils.EPPlus.DataValidation.Formulas.Contracts;

namespace Sunshineiot.Utils.EPPlus.DataValidation.Contracts
{
    public interface IExcelDataValidationWithFormula<T> : IExcelDataValidation
        where T : IExcelDataValidationFormula
    {
        T Formula { get; }
    }
}
