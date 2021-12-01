 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.Barcodes
{
    /// <summary>
    /// Класс для формирования получения и проверки шртихкодов согласно РТМ 001
    /// </summary>
    public class BarcodeClass
    {
        #region PublicPropertyesRegion
        /// <summary>
        /// Итоговый штрихкод для ПО
        /// </summary>
        public string BarcodeString { get; private set; }
        /// <summary>
        /// Индекс предприятия связи места приема
        /// Позиция 1 - 6 
        /// </summary>
        public string IndexBarcode { get; private set; }
        /// <summary>
        /// Порядковый номер месяца печати штрихкодового идентификатора, начиная с 01.2000 (значение 01).
        /// Позиция  7 - 8
        /// </summary>
        public string BarcodeMonth { get; private set; }
        /// <summary>
        /// Номер почтового отправления
        /// Позиция 9 - 13 
        /// </summary>
        public string BarcodeNumber { get; private set; }
        /// <summary>
        /// Контрольный разряд
        /// </summary>
        public string BarcodeControl { get; private set; } 
        #endregion

        #region Constructirs Region
        /// <summary>
        /// Получем штрихкод отрпавления
        /// </summary>
        /// <param name="index">Индекс ОПС</param>
        /// <param name="date">Дата для расета месяца</param>
        /// <param name="poNumber">Номер ПО</param>
        public BarcodeClass(string index, DateTime date, int poNumber) : this(index, (date.Year - 2000 - 1) * 12 + date.Month, poNumber)
        {
        }
        /// <summary>
        /// Получем штрихкод отрпавления
        /// Дата принимается равной текущей дате
        /// </summary>
        /// <param name="index">Индекс ОПС</param>
        /// <param name="poNumber">Номер ПО</param>
        public BarcodeClass(string index, int poNumber) : this(index, DateTime.Now, poNumber)
        {

        }
        /// <summary>
        /// Получем штрихкод отрпавления
        /// </summary>
        /// <param name="index">Индекс ОПС</param>
        /// <param name="monthNumber">Порядковый номер месяца</param>
        /// <param name="poNumber">Номер ПО</param>
        public BarcodeClass(string index, int monthNumber, int poNumber)
        {
            if (poNumber > 100000 || monthNumber < 0 || index.Length != 6)
            {
                throw new ArgumentException("Переданы неверные аргументы для фломирвоания ШПИ");
            }
            IndexBarcode = index;
            BarcodeMonth = monthNumber.ToString("00");
            BarcodeNumber = poNumber.ToString("00000");
            GetSecretNumber();
        }
        /// <summary>
        /// Получаем класс ШПИ по строке ШПИ
        /// </summary>
        /// <param name="barcide">ШПИ</param>
        public BarcodeClass(string barcide)
        {
            if(!CheckBarcode(barcide))
            {
                throw new ArgumentException("Переданный ШПИ не соовтетсвует РТМ 001");
            }
            BarcodeMonth = barcide.Substring(6,2);
            BarcodeNumber = barcide.Substring(8, 5);
            BarcodeControl = barcide.Substring(13, 1);
            BarcodeString = barcide;
            IndexBarcode = barcide.Substring(0, 6);
        }

        #endregion

        #region LogikRegion
        /// <summary>
        /// Получаем контрольный разряд отправления
        /// </summary>
        private void GetSecretNumber()
        {
            var currString = $"{IndexBarcode}{BarcodeMonth}{BarcodeNumber}";
            int indexBarcode = 1;
            var resoult = 0;

            foreach(var charBarcode in currString)
            {
                resoult += indexBarcode % 2 == 0 ? charBarcode - '0' : (charBarcode - '0') * 3;
                indexBarcode++;
            }

            if(resoult % 10 == 0)
            {
                BarcodeControl = "0";
                return;
            }
            BarcodeString = $"{currString}{10 - resoult % 10}";
        }
        #endregion

        #region StaticMethods
        /// <summary>
        /// Получаем список штрихкодов для отправлений с начального по конечный номер
        /// Елси не переданы парамтры даты или номера месяца то месяц принимается равным текущей дате
        /// </summary>
        /// <param name="index">Индекс ОПС</param>
        /// <param name="numberStart">Начало диапозона</param>
        /// <param name="numberEnd">Окончание диапозона</param>
        /// <param name="date">Дата для формирования месяца (необязательно)</param>
        /// <param name="mouthIndex">Индекс месяца для формирования ШПИ (необязательно)</param>
        /// <returns></returns>
        public static List<BarcodeClass> GetBarcodes(string index, int numberStart, int numberEnd, DateTime? date = null, int mouthIndex = 0)
        {
            if (mouthIndex == 0 && !date.HasValue)
            {
                date = DateTime.Now;
            }
            var toContructirs = date.HasValue ? (date.Value.Year - 2000 - 1) * 12 + date.Value.Month : mouthIndex;

            var resoult = new List<BarcodeClass>();
            for (int i = numberStart; i <= numberEnd; i++)
            {
                resoult.Add(new BarcodeClass(index, toContructirs, i));
            }

            return resoult;
        }
        /// <summary>
        /// Проверяем штрихкод
        /// </summary>
        /// <param name="barcodeToCheck">Строка штрихкода для проверки</param>
        /// <returns></returns>
        public static bool CheckBarcode(string barcodeToCheck)
        {
            if (barcodeToCheck.Length != 14)
            {
                return false;
            }
            // Проверяем контрольнй разряд 
            var resoult = 0;
            for (int i = 0; i < barcodeToCheck.Length - 1; i++)
            {
                resoult += i % 2 != 0 ? barcodeToCheck[i] - '0' : (barcodeToCheck[i] - '0') * 3;
            }
            var chekcSecret = 0;
            if (resoult % 10 == 0)
            {
                chekcSecret = 0;
            }
            else
            {
                chekcSecret = 10 - resoult % 10;
            }
            if (chekcSecret != (barcodeToCheck[barcodeToCheck.Length - 1] - '0'))
            {
                return false;
            }
            return true;
        } 
        /// <summary>
        /// Получаем штрихкод
        /// </summary>
        /// <returns>Штрихкод</returns>
        public static string GetBarcodeFast (string index, DateTime date, int poNumber)
        {
            return new BarcodeClass(index, date, poNumber).BarcodeString;
        }
        /// <summary>
        /// Получаем штрихкод
        /// </summary>
        /// <returns>Штрихкод</returns>
        public static string GetBarcodeFast(string index, int poNumber)
        {
            return new BarcodeClass(index, poNumber).BarcodeString;
        }
        /// <summary>
        /// Получаем штрихкод
        /// </summary>
        /// <returns>Штрихкод</returns>
        public static string GetBarcodeFast(string index, int monthNumber, int poNumber)
        {
            return new BarcodeClass(index, monthNumber, poNumber).BarcodeString;
        }
        #endregion

    }
}
