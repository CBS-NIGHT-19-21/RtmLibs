using RtmLib.MailsAbstractions;
using RtmLib.Rtm002Lib;
using RtmLib.Rtm003Classes.BatchClasses;
using RtmLib.Rtm003Lib;
using RtmLib.TarifsEngine;
using RtmLib.TarifsEngine.TarifsEnums;
using RtmLib.TarifsEngine.TarifsSettings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.Rtm003Classes
{
    public abstract class RtmBatch : ICollection<RtmEntry> , IRtmPartPost
    {
        /// <summary>
        /// Заголовок для всех отправлений(для формрования файла)
        /// </summary>
        public abstract string EntityHeader { get; }
        protected List<RtmEntry> rtmCollection = new List<RtmEntry>();
        #region CollectionRegion
        public RtmEntry this[int index] => rtmCollection[index];
        public int Count => rtmCollection.Count;

        public bool IsReadOnly => false;

        public void Add(RtmEntry item)
        {
            rtmCollection.Add(item);
        }

        public void Clear()
        {
            rtmCollection.Clear();
        }

        public bool Contains(RtmEntry item)
        {
            return rtmCollection.Contains(item);
        }

        public void CopyTo(RtmEntry[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<RtmEntry> GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool Remove(RtmEntry item)
        {
            return rtmCollection.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public void SetEntryCollection(List<RtmEntry> entrys)
        {
            this.rtmCollection = entrys;
        }

        #endregion
        private object _suncObj = new object();
        /// <summary>
        /// Имя файла для ini файла
        /// </summary>
        public string BathchFileName => $"{GetFileProtectedName()}h.ini";
        /// <summary>
        /// Имя для текстовика с отрпавлениями
        /// </summary>
        public string BatchFileInName => $"{GetFileProtectedName()}.txt";
        /// <summary>
        /// Имя для zip архива
        /// </summary>
        public string BatchZipFileName => $"F{GetFileProtectedName()}.zip";
        /// <summary>
        /// Стандартная кодировка для списка отправлений для кодировки
        /// </summary>
        public Encoding DefaultEncoding => Encoding.GetEncoding(866);
        protected virtual string GetFileProtectedName()
        {
            var innString = SenderBatch.Inn.Length != 12 ? $"{new string('0', 12 - SenderBatch.Inn.Length)}{SenderBatch.Inn}" : SenderBatch.Inn;
            var yearString = DateBath.Year.ToString().Substring(3, 1);
            var dayString = DateBath.DayOfYear.ToString().Length != 3 ? $"{new string('0', 3 - DateBath.DayOfYear.ToString().Length)}{DateBath.DayOfYear}" : DateBath.DayOfYear.ToString();
            var spiNumString = ListNum.ToString("00000");
            return $"{innString}{yearString}{dayString}{spiNumString}";
        }
        #region ConstructirsRegion
        public RtmBatch()
        {

        }
        #endregion
        #region RtmRegion
        /// <summary>
        /// Формируем файлы для отправки
        /// </summary>
        /// <param name="directoryToSave"></param>
        public void CreateRtmFiles(string directoryToSave)
        {
            // Проверка на ошибки в определениях
            if (rtmCollection.Any(x => x.IsTarifsCalculate == false || x.ErrorsEntity.Count != 0))
            {
                throw new ArgumentException("Пристуствуют ошибки. Необходимо проверить ошибки отправлений или спписка");
            }


            var directorName = Path.GetDirectoryName(directoryToSave);
            if (!Directory.Exists(directorName))
            {
                Directory.CreateDirectory(directorName);
            }
            // Готовим файл с содержимым текстом
            using (StreamWriter sw = new StreamWriter(Path.Combine(directorName, BatchFileInName), true, DefaultEncoding))
            {
                sw.WriteLine(EntityHeader);
                foreach (var entry in rtmCollection)
                {
                    sw.WriteLine(entry.GetRtmString());
                }
            }
            // Готовим файл с ini файлом
            using (StreamWriter sw = new StreamWriter(Path.Combine(directorName, BathchFileName), true, DefaultEncoding))
            {
                sw.Write(CreateRtm());
            }
            // Зипуем файлы
            GetZipFiles(Path.Combine(directorName, BatchZipFileName), new string[] { Path.Combine(directorName, BatchFileInName), Path.Combine(directorName, BathchFileName) });
        }
        /// <summary>
        /// Архивирум данные в архивы
        /// </summary>
        /// <param name="fileNames"></param>
        /// <param name="filesToZip"></param>
        private void GetZipFiles(string fileNames, string[] filesToZip)
        {
            var zip = ZipFile.Open(fileNames, ZipArchiveMode.Create);
            foreach (var file in filesToZip)
            {
                zip.CreateEntryFromFile(file, Path.GetFileName(file));
            }
            zip.Dispose();
        }
        /// <summary>
        /// Формируем данные по основному файлу (h)
        /// </summary>
        /// <returns></returns>
        public abstract string CreateRtm();
        /// <summary>
        /// Проверяем тарифы
        /// </summary>
        public void CheckTarifs()
        {
            Task.Run(async () => await CheckTarisAsync()).Wait();
        }
        private async Task CheckTarisAsync()
        {
            var tarifsEngine = new TarigsMainEngine();
            foreach (var rtmEntry in rtmCollection)
            {
                var tarifsQuery = new TarifsQuery
                {
                    Weight = rtmEntry.Delivertyty.Weight,
                    ClosedPostOffice = ClosedPerDeliveryEnum.No,
                    DateDelivery = DateBath,
                    DirectCtgEnum = DirectCtgBatch,
                    Dogovor = SenderBatch.Contracts is null ? null : new DogovorQueryClass { DogNumber = SenderBatch.Contracts.NameContract, Inn = SenderBatch.Inn, RegionId = SenderBatch.RegionSender },
                    ErrorCodeQuery = ErrorCodeQueryEnum.ErrorCode,
                    IndexOpsFrom = IndexFrom,
                    IndexOpsTo = rtmEntry.Delivertyty.Recipient.AddressRcpn.IndexTo.AddressString,
                    MailCtgEnum = MailCtgBatch,
                    MailRuncQuery = MailRankRtm,
                    MailTypeEnum = MailTypeBatch,
                    PostMarks = MarksBatch,
                    PreferDeliv = TransTypeBatch == TransTypes.Авиа ? TarifsSenderHelper.OnlyAvia : TarifsSenderHelper.PreferLand,
                    Region = SenderBatch.RegionSender,
                    Sumnp = rtmEntry.Delivertyty.AddictionalInfoPaument is null ? 0 : rtmEntry.Delivertyty.AddictionalInfoPaument.SumNp,
                    Sumoc = rtmEntry.Delivertyty.AddictionalInfoPaument is null ? 0 : rtmEntry.Delivertyty.AddictionalInfoPaument.SumOp,
                    TarifOutputFormat = TarifsQuerySettingsEnum.json
                };
                // Делаем запрос на тариф
                try
                {
                    var resoult = await tarifsEngine.GetTarifs(tarifsQuery.QueryString);
                    if (resoult.Errors is null)
                    {

                        rtmEntry.IsTarifsCalculate = true;
                        rtmEntry.Delivertyty.Payment = new PaymentClass
                        {
                            AirRate = resoult.Avia,
                            MassRate = resoult.Ground,
                            ServicesRate = resoult.Service,
                            CurrencyRate = resoult.Cover,
                            Nds = resoult.Nds,
                            Ndsrate = resoult.Ndsrate,
                            Pay = resoult.Pay,
                            Paymark = resoult.Paymark,
                            Paynds = resoult.Paynds
                        };
                    }
                    else
                    {
                        IsBrokenBatch = true;
                        foreach (var errors in resoult.Errors)
                        {
                            rtmEntry.ErrorsEntity.Add(new ErrorsClassRtm { ErrorMassage = errors.ErrorMassage, MethodRiseError = "TarifsCheck" });
                        }
                    }
                }
                catch (Exception ex)
                {
                    IsBrokenBatch = true;
                    rtmEntry.ErrorsEntity.Add(new ErrorsClassRtm { ErrorMassage = ex.Message, MethodRiseError = "TarifsCheck" });
                }
            }
        }

        #endregion
        #region MainSettingsRegion
        public MailTypes MailTypeBatch { get; set; }
        public MailCtg MailCtgBatch { get; set; }
        public MailRank MailRankRtm { get; set; }
        public List<PostMark> MarksBatch { get; set; }
        public PayType PayTypeBatch { get; set; }
        public PayTypeNot PayTypeNotBatch { get; set; }
        public TransTypes TransTypeBatch { get; set; }
        public DirectCtg DirectCtgBatch { get; set; }
        public SenderClass SenderBatch { get; set; }
        public DateTime DateBath { get; set; }
        public int ListNum { get; set; }
        public string IndexFrom { get; set; }
        public bool IsBrokenBatch { get; set; }
        #endregion
    }
}
