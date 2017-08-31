using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sunshineiot.Utils.EPPlus.DataValidation.Formulas.Contracts;

namespace Sunshineiot.Utils.EPPlus.DataValidation.Contracts
{
    /// <summary>
    /// Data validation interface for custom validation.
    /// </summary>
    public interface IExcelDataValidationCustom : IExcelDataValidationWithFormula<IExcelDataValidationFormula>, IExcelDataValidationWithOperator
    {
    }
}
