using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.TarifsEngine.TarifsEnums
{
    public enum TarifsErrorsType
    {
        /// <summary>
        /// внутренняя системная ошибка сервиса;
        /// </summary>
        Inernal = 0,
        /// <summary>
        /// ошибка, произошедшая при расчете тарифа;
        /// </summary>
        CalculateError = 1,
        /// <summary>
        /// ошибка, произошедшая при расчете контрольного срока;
        /// </summary>
        ContrDatesErrors = 2,
        /// <summary>
        /// ошибка, не относящаяся к конкретному расчету (например, неверный формат входного запроса).
        /// </summary>
        OthersErrors = 3
    }
}
