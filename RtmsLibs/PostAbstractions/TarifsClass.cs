using RtmLib.Rtm002Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.PostAbstractions
{
    /// <summary>
    /// Тарифы отпралвения
    /// </summary>
    public class TarifsClass
    {
        /// <summary>
        /// Тариф за перессылку
        /// </summary>
        public long SendingTarifs { get; set; }
        /// <summary>
        /// НДС за перессылку по тарифам
        /// </summary>
        public long SendingTarifsNds { get; set; }
        /// <summary>
        /// Тариф за доп услуги
        /// </summary>
        public long ServiseTarifs { get; set; }
        /// <summary>
        /// НДС за доп услуги
        /// </summary>
        public long ServiceTarifsNds { get; set; }
        /// <summary>
        /// Есть ли доп услуги
        /// </summary>
        public bool IsService { get; set; }
        /// <summary>
        /// Доп услуги для рассчета по тарифу
        /// </summary>
        public PostMark[] Servises { get; set; }
        /// <summary>
        /// Ставка НДС (текущая)
        /// </summary>
        public int NdsRate { get; set; } = 20;
        /// <summary>
        /// Показывает флаг на оплату марками
        /// </summary>
        public bool IsMarkPay { get; set; }


    }
}
