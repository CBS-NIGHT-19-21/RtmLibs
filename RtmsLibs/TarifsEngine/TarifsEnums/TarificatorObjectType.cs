using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.TarifsEngine.TarifsEnums
{
    /// <summary>
    /// Тип объекта почтоой связи согласно тарификатору
    /// </summary>
    public enum TarificatorObjectType
    {
        Место_Приема = 1,
        Место_Назначения = 2,
        Место_МЖД_ПО_Исходящего_отправлния = 3,
        Место_МЖД_ПО_Входящего_отправления = 4,
        Место_перегрузки = 5,
        Прочее = 0
    }
}
