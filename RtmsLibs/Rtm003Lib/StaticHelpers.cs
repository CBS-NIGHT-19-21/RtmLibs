using RtmLib.Rtm003Classes;
using RtmLib.TarifsEngine.TarifsSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.Rtm003Lib
{
    /// <summary>
    /// Помщьник
    /// </summary>
    public static class StaticHelpers
    {
        /// <summary>
        /// Получаем данные по весовому сбору
        /// </summary>
        /// <param name="entryes"></param>
        /// <param name="chosen"></param>
        /// <returns></returns>
        public static long GetSumm(this List<RtmEntry> entryes, ChosenVar chosen, SelectedProperty property)
        {
            long rez = 0;
            var resList = new List<TarifJsonClass>();
            switch (property)
            {
                case SelectedProperty.MassRate:
                    resList = entryes.Select(x => x.Delivertyty.Payment.MassRate).ToList();
                    break;
                case SelectedProperty.Servises:
                    resList = entryes.Select(x => x.Delivertyty.Payment.ServicesRate).ToList();
                    break;
                case SelectedProperty.Currenct:
                    resList = entryes.Select(x => x.Delivertyty.Payment.CurrencyRate).ToList();
                    break;
                default:
                    break;
            }

            switch(chosen)
            {
                case ChosenVar.MarkPay:
                    {
                        resList.ForEach(x => rez += x is null ? 0 : x.ValMark);
                        return rez;
                    }
                case ChosenVar.Nds:
                    {
                        resList.ForEach(x => rez += x is null ? 0 : x.ValNds - x.ValTarif);
                        return rez;
                    }
                case ChosenVar.WithNds:
                    {
                        resList.ForEach(x => rez += x is null ? 0 : x.ValNds);
                        return rez;
                    }
                case ChosenVar.WithoutNds:
                    {
                        resList.ForEach(x => rez += x is null ? 0 : x.ValTarif);
                        return rez;
                    }
                default:
                    break;
            }

            return rez;
        }

        /// <summary>
        /// Получить общую сумму объявленной ценнсости
        /// </summary>
        /// <param name="entryes"></param>
        /// <returns></returns>
        public static long GetSummOp(this List<RtmEntry> entryes)
        {
            long rez = 0;
            entryes.ForEach(x => rez += (long) x.Delivertyty.AddictionalInfoPaument?.SumOp);

            return rez;
        }
        /// <summary>
        /// Получаем итоговые данные по тарифам
        /// </summary>
        /// <param name="entryes"></param>
        /// <param name="chosen"></param>
        /// <returns></returns>
        public static long GetRezValues(this List<RtmEntry> entryes, ChosenVar chosen)
        {
            long rez = 0;
            switch (chosen)
            {
                case ChosenVar.Nds:
                    entryes.ForEach(x=>rez += x.Delivertyty.Payment.Nds);
                    break;
                case ChosenVar.WithNds:
                    entryes.ForEach(x => rez += x.Delivertyty.Payment.Paynds);
                    break;
                case ChosenVar.WithoutNds:
                    entryes.ForEach(x => rez += x.Delivertyty.Payment.Pay);
                    break;
                case ChosenVar.MarkPay:
                    entryes.ForEach(x => rez += x.Delivertyty.Payment.Pay);
                    break;
                default:
                    break;
            }
            return rez;
        }
        public static long GetWightBatch(this List<RtmEntry> entryes)
        {
            long rez = 0;
            entryes.ForEach(x => rez += x.Delivertyty.Weight);
            return rez;
        }
    }
    
    public enum ChosenVar
    {
        Nds = 1,
        WithNds = 2,
        WithoutNds = 3,
        MarkPay = 4
    }
    public enum SelectedProperty
    {
        MassRate = 0,
        Servises = 1,
        Currenct = 2
    }
}
