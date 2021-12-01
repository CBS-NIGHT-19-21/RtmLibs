using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.Rtm003Lib
{
    /// <summary>
    /// Интерфейс работы с РТМ файлами
    /// </summary>
    public interface IRtmPartPost
    {
        /// <summary>
        /// Сформировать файл РТМ
        /// </summary>
        string CreateRtm();
        /// <summary>
        /// Проверить тарфы в файле РТМ
        /// </summary>
        void CheckTarifs();

    }
}
