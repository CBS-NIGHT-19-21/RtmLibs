using RtmLib.Addresses;
using RtmLib.Rtm002Lib;
using RtmLib.Rtm003Lib;
using System;
using System.Linq;


namespace RtmLib.Rtm003Classes
{
    public class RtmThreeThentyBatch : RtmBatch
    {
        public const string dockVersion = "RTM0003-14-18";
        public override string EntityHeader => "Barcode|Mass|MassRate|Payment|Value|InsrRate|AirRate|Rcpn|AddressTypeTo|NumAddressTypeTo|IndexTo|RegionTo|AreaTo|PlaceTo|LocationTo|StreetTo|HouseTo|LetterTo|SlashTo|CorpusTo|BuildingTo|HotelTo|RoomTo|Comment|MailDirect|TelAddress|Length|Width|Height|VolumeWeight|SMSNoticeR|MPODeclaration|PaymentCurrency|SndrFact|ApoNum|MailType";
        public override string CreateRtm()
        {
            if(rtmCollection.Any(x=>x.IsTarifsCalculate == false || x.ErrorsEntity.Count != 0))
            {
                throw new ArgumentException("Пристуствуют ошибки. Необходимо проверить ошибки отправлений или спписка");
            }
            return $"[Main]\n" +
                $"Inn={SenderBatch.Inn}\n" +
                $"Kpp={SenderBatch.Kpp}\n" +
                $"DepCode={SenderBatch.DepCodeSender}\n" +
                $"SndrTel={SenderBatch.SenderContacts?.TelSender[0]}\n" +
                $"SendCtg={SenderBatch.SenderCategory.GetEnumCode()}\n" +
                $"SendDate={DateBath:yyyyMMdd}\n" +
                $"ListNum={ListNum}\n" +
                $"IndexFrom={IndexFrom}\n" +
                $"MailType={MailTypeBatch.GetEnumCode()}\n" +
                $"MailCtg={MailCtgBatch.GetEnumCode()}\n" +
                $"DirectCtg={DirectCtgBatch.GetEnumCode(out bool _)}\n" +
                $"PayType={PayTypeBatch.GetEnumCode()}\n" +
                $"PayTypeNot={PayTypeNotBatch.GetEnumCode()}\n" +
                $"TransType={TransTypeBatch.GetEnumCode()}\n" +
                $"PostMark={MarksBatch.GetPostMarksSumm()}\n" +
                $"MailRank={MailRankRtm.GetEnumCode()}\n" +
                $"NumContract={SenderBatch.Contracts.NameContract}\n" +
                $"SMSNoticeS=\n" +
                $"KindJurPers=\n" +
                $"SndrFact=\n" +
                $"InnFact=\n" +
                $"KppFact=\n" +
                $"DepcodeFact=\n" +
                $"CourierFee=\n" +
                $"[Sender]\n" +
                $"Sndr={SenderBatch.SenderName}\n" +
                $"{SenderBatch.SenderAddress.GetAddressSender()}" +
                $"[Summary]\n" +
                $"MailCount={rtmCollection.Count}\n" +
                $"MailWeight={(MailCtgBatch == MailCtg.Простое? rtmCollection.GetWightBatch() : 0)}\n" +
                $"ValueSum={(MailCtgBatch == MailCtg.С_объявленной_ценностью || MailCtgBatch == MailCtg.С_объявленной_ценностью_и_наложенным_платежом || MailCtgBatch == MailCtg.С_объявленной_ценностью_и_обязательным_платежом ? rtmCollection.GetSummOp() : 0)}\n" +
                $"DeliveryRateSum={rtmCollection.GetSumm(ChosenVar.WithoutNds, SelectedProperty.MassRate)}\n" +
                $"DeliveryRateVAT={rtmCollection.GetSumm(ChosenVar.Nds, SelectedProperty.MassRate)}\n" +
                $"DeliveryRateTotal={rtmCollection.GetSumm(ChosenVar.WithNds, SelectedProperty.MassRate)}\n" +
                $"ValueSumRateTotal={(MailCtgBatch == MailCtg.С_объявленной_ценностью || MailCtgBatch == MailCtg.С_объявленной_ценностью_и_наложенным_платежом || MailCtgBatch == MailCtg.С_объявленной_ценностью_и_обязательным_платежом ? rtmCollection.GetSumm(ChosenVar.WithNds, SelectedProperty.Currenct) : 0)}\n" +
                $"ValueSumRateVAT={(MailCtgBatch == MailCtg.С_объявленной_ценностью || MailCtgBatch == MailCtg.С_объявленной_ценностью_и_наложенным_платежом || MailCtgBatch == MailCtg.С_объявленной_ценностью_и_обязательным_платежом ? rtmCollection.GetSumm(ChosenVar.Nds, SelectedProperty.Currenct) : 0)}\n" +
                $"NoticeRateTotal={rtmCollection.GetSumm(ChosenVar.WithNds, SelectedProperty.Servises)}\n" +
                $"NoticeRateVAT={rtmCollection.GetSumm(ChosenVar.Nds, SelectedProperty.Servises)}\n" +
                $"SMSNoticeTotal=\n" +
                $"SMSNoticeVAT=\n" +
                $"CourierFeeTotal=\n" +
                $"CourierFeeVAT=\n" +
                $"TotalRate={rtmCollection.GetRezValues(ChosenVar.WithNds)}\n" +
                $"TotalRateVAT={rtmCollection.GetRezValues(ChosenVar.Nds)}\n" +
                $"[DocVersion]\n" +
                $"DocVersion={dockVersion}";
        }
    }
}
