using RtmLib.Addresses;
using RtmLib.Barcodes;
using RtmLib.Rtm002Lib;
using RtmLib.Rtm003Classes.BatchClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.MailsAbstractions
{
    /// <summary>
    /// Абстракция отправления
    /// </summary>
    public class DelivertytyAbstractionss
    {
        /// <summary>
        /// Шпи отправления
        /// </summary>
        public BarcodeClass Barcode { get; set; }
        /// <summary>
        /// Тип отправления
        /// </summary>
        public MailTypes MailType { get; set; }
        /// <summary>
        /// Категория отпралвения 
        /// </summary>
        public MailCtg MailCtgEnum { get; set; }
        /// <summary>
        /// Разряд письма
        /// </summary>
        public MailRank MailRankEnum { get; set; }
        /// <summary>
        /// Отметки пиьма
        /// </summary>
        public PostMark[] PostMarkEnum { get; set; }
        /// <summary>
        /// Вес отправления
        /// </summary>
        public int Weight { get; set; }
        /// <summary>
        /// Получатель отправления
        /// </summary>
        [Required]
        public RecipientClass Recipient { get; set; }
        /// <summary>
        /// Комментарий отправления
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Данные о отправителе
        /// </summary>
        public SenderClass SenderName { get; set; }
        /// <summary>
        /// Сбор за перессылку
        /// </summary>
        public PaymentClass Payment { get; set; }
        /// <summary>
        /// Данные по датам доставки и отправления
        /// </summary>
        public DatesDelivery Dates { get; set; }
        /// <summary>
        /// Доп информация о данных наложенного платежа и объявленной ценности
        /// </summary>
        public AddictionalPayment AddictionalInfoPaument { get; set; }
        /// <summary>
        /// Габариты отпралвения
        /// </summary>
        public GabaritsClass Gabarits { get; set; }
        /// <summary>
        /// Доп информаия об отправлении
        /// </summary>
        public Attachment AttachmatsDelivery { get; set; }

        //TODO сделать проверку отправления по отслеживанию
    }
}
