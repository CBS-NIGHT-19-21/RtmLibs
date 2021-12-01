using RtmLib.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.Rtm003Classes
{
    public class RtmThreeTwentyEntry : RtmEntry
    {
        public const string dockVersion = "RTM0003-14-18";
        public override string GetRtmString()
        {
            if(ErrorsEntity.Count != 0)
            {
               
                throw new ArgumentException($"Отправление исключено. Обнаружены ошибки в количестве: {ErrorsEntity.Count}");
            }
            return $"{Delivertyty.Barcode.BarcodeString}|{Delivertyty.Weight}|{Delivertyty.Payment.MassRate.ValNds}|{Delivertyty.AddictionalInfoPaument?.SumNp}|{Delivertyty.AddictionalInfoPaument?.SumOp}|{Delivertyty.Payment.CurrencyRate?.ValNds}|{Delivertyty.Payment.AirRate?.ValNds}|" +
                $"{Delivertyty.Recipient.RecipientName}|{Delivertyty.Recipient.AddressRcpn.GetAddressRtmEntryThreeTwenty()}|{Delivertyty.Comment}|{Delivertyty.Recipient.CountryRcpn.Id}|{Delivertyty.Recipient.TelRcpn}|{Delivertyty.Gabarits?.Length}|{Delivertyty.Gabarits?.Width}|{Delivertyty.Gabarits?.Height}|{Delivertyty.Gabarits?.VolumeWeight}|" +
                $"|{Delivertyty.AttachmatsDelivery?.SMSNoticeR}|{Delivertyty.AttachmatsDelivery?.MPODeclaration}|{Delivertyty.AddictionalInfoPaument?.PaymentCurrency}|{Delivertyty.SenderName?.SenderName}||{Delivertyty.MailType.GetEnumCode()}";
        }
    }
}
