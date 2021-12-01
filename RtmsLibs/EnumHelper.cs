using RtmLib.Rtm002Lib;
using RtmLib.TarifsEngine.TarifsEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib
{
    /// <summary>
    /// Класс для получения строк и кодов перечислений
    /// </summary>
    public static class EnumHelper
    {
        #region AddressTypeRegion
        /// <summary>
        /// Получаем строку наименвоание типа адреса
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this AddressType type)
        {
            switch (type)
            {
                case AddressType.Стандратный_Адрес:
                    return "Стандартный адрес";
                case AddressType.А_я:
                    return "Абонентский ящик";
                case AddressType.До_Восстребования:
                    return "До востребования";
                case AddressType.Войсковая_часть:
                    return "Войсковая часть";
                case AddressType.Гостиница:
                    return "Гостиница";
                case AddressType.Войсковая_часть_ЮЯ:
                    return "Войсковая часть ЮЯ";
                case AddressType.Полевая_почта:
                    return "Полевая почта";
                default:
                    throw new NotImplementedException("Данный тип адреса не реализован");
            }
        }
        /// <summary>
        /// Получаем код типа адреса
        /// </summary>
        /// <returns></returns>
        public static int GetEnumCode(this AddressType type)
        {
            switch (type)
            {
                case AddressType.Стандратный_Адрес:
                    return 1;
                case AddressType.А_я:
                    return 2;
                case AddressType.До_Восстребования:
                    return 3;
                case AddressType.Войсковая_часть:
                    return 4;
                case AddressType.Гостиница:
                    return 5;
                case AddressType.Войсковая_часть_ЮЯ:
                    return 6;
                case AddressType.Полевая_почта:
                    return 7;
                default:
                    throw new NotImplementedException("Данный тип адреса не реализован");
            }
        }
        /// <summary>
        /// Получить <see cref="AddressType"/> по коду типа int
        /// </summary>
        /// <param name="code">Код для парса по addressType</param>
        /// <returns></returns>
        public static AddressType GetTypeByCode(this int code)
        {
            switch (code)
            {
                case 1:
                    return AddressType.Стандратный_Адрес;
                case 2:
                    return AddressType.А_я;
                case 3:
                    return AddressType.До_Восстребования;
                case 4:
                    return AddressType.Войсковая_часть;
                case 5:
                    return AddressType.Гостиница;
                case 6:
                    return AddressType.Войсковая_часть_ЮЯ;
                case 7:
                    return AddressType.Полевая_почта;
                default:
                    throw new NotFiniteNumberException("Тип адреса для данного кода не реализован");
            }
        }
        #endregion

        #region DirectionCtgRegion
        /// <summary>
        /// Получам наименование направления отправлений по РТМ 002
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this DirectCtg direct, out bool isRtm)
        {
            switch (direct)
            {
                case DirectCtg.Внутренняя:
                    {
                        isRtm = true;
                        return "Внутренняя";
                    }
                case DirectCtg.Международная:
                    {
                        isRtm = true;
                        return "Внутренняя";
                    }
                case DirectCtg.Входящее_Международное:
                    {
                        isRtm = false;
                        return "входящее международное";
                    }
                case DirectCtg.Внутреннее_Возвратное:
                    {
                        isRtm = false;
                        return "транзитное международное";
                    }
                case DirectCtg.Тразнитное_Международное:
                    {
                        isRtm = false;
                        return "внутреннее возвратное";
                    }
                default:
                    throw new NotImplementedException("Данный вид классификации отправлений не реализован");
            }
        }
        /// <summary>
        /// Получаем кот днаправления по РТМ 002
        /// </summary>
        /// <returns></returns>
        public static int GetEnumCode(this DirectCtg direct, out bool isRtm)
        {
            switch (direct)
            {
                case DirectCtg.Внутренняя:
                    {
                        isRtm = true;
                        return 1;
                    }
                case DirectCtg.Международная:
                    {
                        isRtm = true;
                        return 2;
                    }
                case DirectCtg.Входящее_Международное:
                    {
                        isRtm = false;
                        return 3;
                    }
                case DirectCtg.Внутреннее_Возвратное:
                    {
                        isRtm = false;
                        return 5;
                    }
                case DirectCtg.Тразнитное_Международное:
                    {
                        isRtm = false;
                        return 4;
                    }
                default:
                    throw new NotImplementedException("Данный вид классификации отправлений не реализован");
            }
        }
        /// <summary>
        /// Получить <see cref="DirectCtg"/> по коду типа int
        /// </summary>
        /// <param name="code">Код для парса по <see cref="DirectCtg"/></param>
        /// <returns></returns>
        public static DirectCtg GetTypeDirectByCode(this int code)
        {
            switch (code)
            {
                case 1:
                    return DirectCtg.Внутренняя;
                case 2:
                    return DirectCtg.Международная;
                case 3:
                    return DirectCtg.Входящее_Международное;
                case 4:
                    return DirectCtg.Тразнитное_Международное;
                case 5:
                    return DirectCtg.Внутреннее_Возвратное;
                default:
                    throw new NotFiniteNumberException("Тип адреса для данного кода не реализован");
            }
        }
        #endregion

        #region MailCategotyRegion
        /// <summary>
        /// Получам наименование категории ПО по РТМ 002
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this MailCtg direct)
        {
            switch (direct)
            {
                case MailCtg.Простое:
                    return "Простое";
                case MailCtg.Заказное:
                    return "Заказное";
                case MailCtg.С_объявленной_ценностью:
                    return "С объявленной ценностью";
                case MailCtg.Обыкновенное:
                    return "Обыкновенное";
                case MailCtg.С_объявленной_ценностью_и_наложенным_платежом:
                    return "С объявленной ценностью и наложенным платежом";
                case MailCtg.Не_определена:
                    return "Не определена";
                case MailCtg.С_объявленной_ценностью_и_обязательным_платежом:
                    return "С объявленной ценностью и обязательным платежом";
                case MailCtg.С_обязательным_платежом:
                    return "С обязательным платежом";
                default:
                    throw new NotImplementedException("Данный вид категории почтовых отправлений не реализован");
            }
        }
        /// <summary>
        /// Получаем кот категории ПО по РТМ 002
        /// </summary>
        /// <returns></returns>
        public static int GetEnumCode(this MailCtg direct)
        {
            switch (direct)
            {
                case MailCtg.Простое:
                    return 0;
                case MailCtg.Заказное:
                    return 1;
                case MailCtg.С_объявленной_ценностью:
                    return 2;
                case MailCtg.Обыкновенное:
                    return 3;
                case MailCtg.С_объявленной_ценностью_и_наложенным_платежом:
                    return 4;
                case MailCtg.Не_определена:
                    return 5;
                case MailCtg.С_объявленной_ценностью_и_обязательным_платежом:
                    return 6;
                case MailCtg.С_обязательным_платежом:
                    return 7;
                default:
                    throw new NotImplementedException("Данный вид категории почтовых отправлений не реализован");
            }
        }
        /// <summary>
        /// Получить <see cref="MailCtg"/> по коду типа int
        /// </summary>
        /// <param name="code">Код для парса по <see cref="MailCtg"/></param>
        /// <returns></returns>
        public static MailCtg GetTypeMailCtgByCode(this int code)
        {
            switch (code)
            {
                case 0:
                    return MailCtg.Простое;
                case 1:
                    return MailCtg.Заказное;
                case 2:
                    return MailCtg.С_объявленной_ценностью;
                case 3:
                    return MailCtg.Обыкновенное;
                case 4:
                    return MailCtg.С_объявленной_ценностью_и_наложенным_платежом;
                case 5:
                    return MailCtg.Не_определена;
                case 6:
                    return MailCtg.С_объявленной_ценностью_и_обязательным_платежом;
                case 7:
                    return MailCtg.С_обязательным_платежом;
                default:
                    throw new NotFiniteNumberException("Тип адреса для данного кода не реализован");
            }
        }
        #endregion

        #region MailRanckRegion
        /// <summary>
        /// Получам наименование разряда ПО по РТМ 002
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this MailRank direct)
        {
            switch (direct)
            {
                case MailRank.Без_разряда:
                    return "Без разряда";
                case MailRank.Правительственное:
                    return "Правительственное";
                case MailRank.Воинское:
                    return "Воинское";
                case MailRank.Служебное:
                    return "Служебное";
                case MailRank.Судебное:
                    return "Судебное";
                case MailRank.Президентское:
                    return "Президентское";
                case MailRank.Кредитное:
                    return "Кредитное";
                case MailRank.Межоператорское:
                    return "Межоператорское";
                case MailRank.Административное:
                    return "Административное";
                default:
                    throw new NotImplementedException("Данный вид разряда почтовых отправлений не реализован");
            }
        }
        /// <summary>
        /// Получаем код разряда ПО по РТМ 002
        /// </summary>
        /// <returns></returns>
        public static int GetEnumCode(this MailRank direct)
        {
            switch (direct)
            {
                case MailRank.Без_разряда:
                    return 0;
                case MailRank.Правительственное:
                    return 1;
                case MailRank.Воинское:
                    return 2;
                case MailRank.Служебное:
                    return 3;
                case MailRank.Судебное:
                    return 4;
                case MailRank.Президентское:
                    return 5;
                case MailRank.Кредитное:
                    return 6;
                case MailRank.Межоператорское:
                    return 7;
                case MailRank.Административное:
                    return 8;
                default:
                    throw new NotImplementedException("Данный вид разряда почтовых отправлений не реализован");
            }
        }
        /// <summary>
        /// Получить <see cref="MailRank"/> по коду типа int
        /// </summary>
        /// <param name="code">Код для парса по <see cref="MailRank"/></param>
        /// <returns></returns>
        public static MailRank GetTypeMailRankByCode(this int code)
        {
            switch (code)
            {
                case 0:
                    return MailRank.Без_разряда;
                case 1:
                    return MailRank.Правительственное;
                case 2:
                    return MailRank.Воинское;
                case 3:
                    return MailRank.Служебное;
                case 4:
                    return MailRank.Судебное;
                case 5:
                    return MailRank.Президентское;
                case 6:
                    return MailRank.Кредитное;
                case 7:
                    return MailRank.Межоператорское;
                case 8:
                    return MailRank.Административное;
                default:
                    throw new NotFiniteNumberException($"{nameof(MailRank)} для данного кода не реализован");
            }
        }
        #endregion

        #region MailTypesRegion
        /// <summary>
        /// Получам наименование типа ПО по РТМ 002
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this MailTypes direct)
        {
            switch (direct)
            {
                case MailTypes.Не_определено:
                    return "Не определено";
                case MailTypes.Бланк_почтового_перевода:
                    return "Бланк почтового перевода";
                case MailTypes.Письмо:
                    return "Письмо";
                case MailTypes.Бандероль:
                    return "Бандероль";
                case MailTypes.Посылка:
                    return "Посылка";
                case MailTypes.Мелкий_пакет:
                    return "Мелкий пакет";
                case MailTypes.Почтовая_карточка:
                    return "Почтовая карточка";
                case MailTypes.Отправление_EMS:
                    return "Отправление EMS";
                case MailTypes.Секограмма:
                    return "Секограмма";
                case MailTypes.Мешок_М:
                    return "Мешок \"М\"";
                case MailTypes.Отправление_ВСД:
                    return "Отправление ВСД";
                case MailTypes.Письмо_2_0:
                    return "Письмо 2.0";
                case MailTypes.Бланк_уведомления:
                    return "Бланк уведомления";
                case MailTypes.Газетная_пачка:
                    return "Газетная пачка";
                case MailTypes.Сгруппированные_отправления_Консигнация:
                    return "Сгруппированные отправления \"Консигнация\"";
                case MailTypes.Письмо_1_класса:
                    return "Письмо 1 класса";
                case MailTypes.Бандероль_1_класса:
                    return "Бандероль 1 класса";
                case MailTypes.Бланк_уведомления_1_класса:
                    return "Бланк уведомления 1 класса";
                case MailTypes.Сумка_страховая:
                    return "Сумка страховая";
                case MailTypes.ОВПО_письмо:
                    return "ОВПО – письмо";
                case MailTypes.Мультиконверт:
                    return "Мультиконверт";
                case MailTypes.Тяжеловесное_почтовое_отправление:
                    return "Тяжеловесное почтовое отправление";
                case MailTypes.ОВПО_карточка:
                    return "ОВПО – карточка";
                case MailTypes.Посылка_онлайн:
                    return "Посылка онлайн";
                case MailTypes.Курьер_онлайн:
                    return "Курьер онлайн";
                case MailTypes.Отправление_ДМ:
                    return "Отправление ДМ";
                case MailTypes.Пакет_ДМ:
                    return "Пакет ДМ";
                case MailTypes.Посылка_стандарт:
                    return "Посылка стандарт";
                case MailTypes.Посылка_курьер_EMS:
                    return "Посылка курьер EMS/Посылка курьер";
                case MailTypes.Посылка_экспресс:
                    return "Посылка экспресс";
                case MailTypes.Бизнес_курьер:
                    return "Бизнес курьер";
                case MailTypes.Бизнес_курьер_экспресс:
                    return "Бизнес курьер экспресс";
                case MailTypes.Письмо_Экспресс:
                    return "Письмо Экспресс";
                case MailTypes.Письмо_Курьерское:
                    return "Письмо Курьерское";
                case MailTypes.EMS_оптимальное:
                    return "EMS оптимальное";
                case MailTypes.Бандероль_комплект:
                    return "Бандероль-комплект";
                case MailTypes.Трек_открытка:
                    return "Трек-открытка";
                case MailTypes.Трек_письмо:
                    return "Трек-письмо";
                case MailTypes.Посылка_экомпро:
                    return "Посылка-экомпро";
                case MailTypes.КПО_стандарт:
                    return "КПО-стандарт";
                case MailTypes.КПО_эконом:
                    return "КПО-эконом";
                case MailTypes.EMS_РТ:
                    return "EMS РТ";
                case MailTypes.Посылка_онлайн_плюс:
                    return "Посылка онлайн плюс";
                case MailTypes.Курьер_онлайн_плюс:
                    return "Курьер онлайн плюс";
                case MailTypes.Резерв:
                    return "Резерв";
                case MailTypes.Резерв_2:
                    return "Резерв";
                case MailTypes.ВГПО_1_кл:
                    return "ВГПО 1 кл";
                case MailTypes.Посылка_1_го_класса:
                    return "Посылка 1-го класса";
                case MailTypes.Письмо_1_го_класса_2_0:
                    return "Письмо 1-го класса 2.0";
                case MailTypes.Письмо_1_го_класса_Курьерское:
                    return "Письмо 1-го класса Курьерское";
                case MailTypes.Пакет_ДМ_возврат:
                    return "Пакет ДМ-возврат";
                case MailTypes.Посылка_Легкий_возврат:
                    return "Посылка Легкий возврат";
                case MailTypes.EMS_Тендер:
                    return "EMS Тендер";
                case MailTypes.ЕКОМ:
                    return "ЕКОМ";
                case MailTypes.ЕКОМ_Маркетплейс:
                    return "ЕКОМ Маркетплейс";
                default:
                    throw new NotImplementedException("Данный вид типа почтовых отправлений не реализован");
            }
        }
        /// <summary>
        /// Получаем код типа ПО по РТМ 002
        /// </summary>
        /// <returns></returns>
        public static int GetEnumCode(this MailTypes direct)
        {
            switch (direct)
            {
                case MailTypes.Не_определено:
                    return 0;
                case MailTypes.Бланк_почтового_перевода:
                    return 1;
                case MailTypes.Письмо:
                    return 2;
                case MailTypes.Бандероль:
                    return 3;
                case MailTypes.Посылка:
                    return 4;
                case MailTypes.Мелкий_пакет:
                    return 5;
                case MailTypes.Почтовая_карточка:
                    return 6;
                case MailTypes.Отправление_EMS:
                    return 7;
                case MailTypes.Секограмма:
                    return 8;
                case MailTypes.Мешок_М:
                    return 9;
                case MailTypes.Отправление_ВСД:
                    return 10;
                case MailTypes.Письмо_2_0:
                    return 11;
                case MailTypes.Бланк_уведомления:
                    return 12;
                case MailTypes.Газетная_пачка:
                    return 13;
                case MailTypes.Сгруппированные_отправления_Консигнация:
                    return 14;
                case MailTypes.Письмо_1_класса:
                    return 15;
                case MailTypes.Бандероль_1_класса:
                    return 16;
                case MailTypes.Бланк_уведомления_1_класса:
                    return 17;
                case MailTypes.Сумка_страховая:
                    return 18;
                case MailTypes.ОВПО_письмо:
                    return 19;
                case MailTypes.Мультиконверт:
                    return 20;
                case MailTypes.Тяжеловесное_почтовое_отправление:
                    return 21;
                case MailTypes.ОВПО_карточка:
                    return 22;
                case MailTypes.Посылка_онлайн:
                    return 23;
                case MailTypes.Курьер_онлайн:
                    return 24;
                case MailTypes.Отправление_ДМ:
                    return 25;
                case MailTypes.Пакет_ДМ:
                    return 26;
                case MailTypes.Посылка_стандарт:
                    return 27;
                case MailTypes.Посылка_курьер_EMS:
                    return 28;
                case MailTypes.Посылка_экспресс:
                    return 29;
                case MailTypes.Бизнес_курьер:
                    return 30;
                case MailTypes.Бизнес_курьер_экспресс:
                    return 31;
                case MailTypes.Письмо_Экспресс:
                    return 32;
                case MailTypes.Письмо_Курьерское:
                    return 33;
                case MailTypes.EMS_оптимальное:
                    return 34;
                case MailTypes.Бандероль_комплект:
                    return 35;
                case MailTypes.Трек_открытка:
                    return 36;
                case MailTypes.Трек_письмо:
                    return 37;
                case MailTypes.Посылка_экомпро:
                    return 38;
                case MailTypes.КПО_стандарт:
                    return 39;
                case MailTypes.КПО_эконом:
                    return 40;
                case MailTypes.EMS_РТ:
                    return 41;
                case MailTypes.Посылка_онлайн_плюс:
                    return 42;
                case MailTypes.Курьер_онлайн_плюс:
                    return 43;
                case MailTypes.Резерв:
                    return 44;
                case MailTypes.Резерв_2:
                    return 45;
                case MailTypes.ВГПО_1_кл:
                    return 46;
                case MailTypes.Посылка_1_го_класса:
                    return 47;
                case MailTypes.Письмо_1_го_класса_2_0:
                    return 48;
                case MailTypes.Письмо_1_го_класса_Курьерское:
                    return 49;
                case MailTypes.Пакет_ДМ_возврат:
                    return 50;
                case MailTypes.Посылка_Легкий_возврат:
                    return 51;
                case MailTypes.EMS_Тендер:
                    return 52;
                case MailTypes.ЕКОМ:
                    return 53;
                case MailTypes.ЕКОМ_Маркетплейс:
                    return 54;
                default:
                    throw new NotImplementedException("Данный вид типа почтовых отправлений не реализован");
            }
        }

        /// <summary>
        /// Получить <see cref="MailTypes"/> по коду типа int
        /// </summary>
        /// <param name="code">Код для парса по <see cref="MailTypes"/></param>
        /// <returns></returns>
        public static MailTypes GetTypeMailTypeByCode(this int code)
        {
            switch (code)
            {
                case 0:
                    return MailTypes.Не_определено;
                case 1:
                    return MailTypes.Бланк_почтового_перевода;
                case 2:
                    return MailTypes.Письмо;
                case 3:
                    return MailTypes.Бандероль;
                case 4:
                    return MailTypes.Посылка;
                case 5:
                    return MailTypes.Мелкий_пакет;
                case 6:
                    return MailTypes.Почтовая_карточка;
                case 7:
                    return MailTypes.Отправление_EMS;
                case 8:
                    return MailTypes.Секограмма;
                case 9:
                    return MailTypes.Мешок_М;
                case 10:
                    return MailTypes.Отправление_ВСД;
                case 11:
                    return MailTypes.Письмо_2_0;
                case 12:
                    return MailTypes.Бланк_уведомления;
                case 13:
                    return MailTypes.Газетная_пачка;
                case 14:
                    return MailTypes.Сгруппированные_отправления_Консигнация;
                case 15:
                    return MailTypes.Письмо_1_класса;
                case 16:
                    return MailTypes.Бандероль_1_класса;
                case 17:
                    return MailTypes.Бланк_уведомления_1_класса;
                case 18:
                    return MailTypes.Сумка_страховая;
                case 19:
                    return MailTypes.ОВПО_письмо;
                case 20:
                    return MailTypes.Мультиконверт;
                case 21:
                    return MailTypes.Тяжеловесное_почтовое_отправление;
                case 22:
                    return MailTypes.ОВПО_карточка;
                case 23:
                    return MailTypes.Посылка_онлайн;
                case 24:
                    return MailTypes.Курьер_онлайн;
                case 25:
                    return MailTypes.Отправление_ДМ;
                case 26:
                    return MailTypes.Пакет_ДМ;
                case 27:
                    return MailTypes.Посылка_стандарт;
                case 28:
                    return MailTypes.Посылка_курьер_EMS;
                case 29:
                    return MailTypes.Посылка_экспресс;
                case 30:
                    return MailTypes.Бизнес_курьер;
                case 31:
                    return MailTypes.Бизнес_курьер_экспресс;
                case 32:
                    return MailTypes.Письмо_Экспресс;
                case 33:
                    return MailTypes.Письмо_Курьерское;
                case 34:
                    return MailTypes.EMS_оптимальное;
                case 35:
                    return MailTypes.Бандероль_комплект;
                case 36:
                    return MailTypes.Трек_открытка;
                case 37:
                    return MailTypes.Трек_письмо;
                case 38:
                    return MailTypes.Посылка_экомпро;
                case 39:
                    return MailTypes.КПО_стандарт;
                case 40:
                    return MailTypes.КПО_эконом;
                case 41:
                    return MailTypes.EMS_РТ;
                case 42:
                    return MailTypes.Посылка_онлайн_плюс;
                case 43:
                    return MailTypes.Курьер_онлайн_плюс;
                case 44:
                    return MailTypes.Резерв;
                case 45:
                    return MailTypes.Резерв_2;
                case 46:
                    return MailTypes.ВГПО_1_кл;
                case 47:
                    return MailTypes.Посылка_1_го_класса;
                case 48:
                    return MailTypes.Письмо_1_го_класса_2_0;
                case 49:
                    return MailTypes.Письмо_1_го_класса_Курьерское;
                case 50:
                    return MailTypes.Пакет_ДМ_возврат;
                case 51:
                    return MailTypes.Посылка_Легкий_возврат;
                case 52:
                    return MailTypes.EMS_Тендер;
                case 53:
                    return MailTypes.ЕКОМ;
                case 54:
                    return MailTypes.ЕКОМ_Маркетплейс;
                default:
                    throw new NotFiniteNumberException($"{nameof(MailTypes)} для данного кода не реализован");
            }
        }

        #endregion

        #region PayTypeRegion
        /// <summary>
        /// Получаем строку наименвоание вида оплаты адреса
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this PayType type)
        {
            switch (type)
            {
                case PayType.Наличная:
                    return "Наличная";
                case PayType.Безналичная:
                    return "Безналичная ";
                case PayType.Бесплатно:
                    return "Бесплатно ";
                case PayType.Платежная_карта:
                    return "Платежная карта ";
                case PayType.Государственные_знаки_почтовой_оплаты_марками:
                    return "Государственные знаки почтовой оплаты марками ";
                case PayType.Предоплата_авансовый_платеж:
                    return "Предоплата (авансовый платеж) ";
                case PayType.Оплачено_международному_оператору:
                    return "Оплачено международному оператору ";
                case PayType.Оплачивается_получателем:
                    return "Оплачивается получателем ";
                case PayType.Государственные_знаки_почтовой_оплаты_франкирование:
                    return "Государственные знаки почтовой оплаты, франкирование ";
                case PayType.Оплачивается_ЭТП:
                    return "Оплачивается ЭТП";
                case PayType.Государственные_знаки_почтовой_оплаты_знак_онлайн_оплаты:
                    return "Государственные знаки почтовой оплаты, знак онлайн оплаты";
                default:
                    throw new NotImplementedException("Данный вид отплаты не реализован");
            }
        }
        /// <summary>
        /// Получаем код вида оплаты адреса
        /// </summary>
        /// <returns></returns>
        public static int GetEnumCode(this PayType type)
        {
            switch (type)
            {
                case PayType.Наличная:
                    return 1;
                case PayType.Безналичная:
                    return 2;
                case PayType.Бесплатно:
                    return 4;
                case PayType.Платежная_карта:
                    return 8;
                case PayType.Государственные_знаки_почтовой_оплаты_марками:
                    return 16;
                case PayType.Предоплата_авансовый_платеж:
                    return 32;
                case PayType.Оплачено_международному_оператору:
                    return 64;
                case PayType.Оплачивается_получателем:
                    return 128;
                case PayType.Государственные_знаки_почтовой_оплаты_франкирование:
                    return 265;
                case PayType.Оплачивается_ЭТП:
                    return 512;
                case PayType.Государственные_знаки_почтовой_оплаты_знак_онлайн_оплаты:
                    return 1024;
                default:
                    throw new NotImplementedException("Данный вид отплаты не реализован");
            }
        }
        /// <summary>
        /// Получить <see cref="PayType"/> по коду типа int
        /// </summary>
        /// <param name="code">Код для парса по <see cref="PayType"/></param>
        /// <returns></returns>
        public static PayType GetTypePayTypeByCode(this int code)
        {
            switch (code)
            {
                case 1:
                    return PayType.Наличная;
                case 2:
                    return PayType.Безналичная;
                case 4:
                    return PayType.Бесплатно;
                case 8:
                    return PayType.Платежная_карта;
                case 16:
                    return PayType.Государственные_знаки_почтовой_оплаты_марками;
                case 32:
                    return PayType.Предоплата_авансовый_платеж;
                case 64:
                    return PayType.Оплачено_международному_оператору;
                case 128:
                    return PayType.Оплачивается_получателем;
                case 256:
                    return PayType.Государственные_знаки_почтовой_оплаты_франкирование;
                case 512:
                    return PayType.Оплачивается_ЭТП;
                case 1024:
                    return PayType.Государственные_знаки_почтовой_оплаты_знак_онлайн_оплаты;
                default:
                    throw new NotFiniteNumberException($"{nameof(PayType)} для данного кода не реализован");
            }
        }
        /// <summary>
        /// Получаем строку наименвоание вида оплаты уведомлений адреса
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this PayTypeNot type)
        {
            switch (type)
            {
                case PayTypeNot.Наличная:
                    return "Наличная";
                case PayTypeNot.Безналичная:
                    return "Безналичная ";
                case PayTypeNot.Платежная_карта:
                    return "Платежная карта ";
                case PayTypeNot.Предоплата_авансовый_платеж:
                    return "Предоплата (авансовый платеж) ";
                default:
                    throw new NotImplementedException("Данный вид отплаты не реализован");
            }
        }
        /// <summary>
        /// Получаем код вида оплаты уведомлений адреса
        /// </summary>
        /// <returns></returns>
        public static int GetEnumCode(this PayTypeNot type)
        {
            switch (type)
            {
                case PayTypeNot.Наличная:
                    return 1;
                case PayTypeNot.Безналичная:
                    return 2;
                case PayTypeNot.Платежная_карта:
                    return 8;
                case PayTypeNot.Предоплата_авансовый_платеж:
                    return 32;
                default:
                    throw new NotImplementedException("Данный вид отплаты не реализован");
            }
        }
        /// <summary>
        /// Получить <see cref="PayTypeNot"/> по коду типа int
        /// </summary>
        /// <param name="code">Код для парса по <see cref="PayTypeNot"/></param>
        /// <returns></returns>
        public static PayTypeNot GetTypePayTypeNotByCode(this int code)
        {
            switch (code)
            {
                case 1:
                    return PayTypeNot.Наличная;
                case 2:
                    return PayTypeNot.Безналичная;
                case 8:
                    return PayTypeNot.Платежная_карта;
                case 32:
                    return PayTypeNot.Предоплата_авансовый_платеж;
                default:
                    throw new NotFiniteNumberException($"{nameof(PayTypeNot)} для данного кода не реализован");
            }
        }
        #endregion

        #region PostMarkRegion
        /// <summary>
        /// Получам наименование кодов отметки почтовых отправлений по РТМ 002
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this PostMark direct)
        {
            switch (direct)
            {
                case PostMark.Без_отметки:
                    return "Без отметки ";
                case PostMark.С_простым_уведомлением:
                    return "С простым уведомлением";
                case PostMark.С_заказным_уведомлением:
                    return "С заказным уведомлением";
                case PostMark.С_описью:
                    return "С описью";
                case PostMark.Осторожно_Хрупкая:
                    return "Осторожно (Хрупкая)";
                case PostMark.Тяжеловесная:
                    return "Тяжеловесная";
                case PostMark.Крупногабаритная_Громоздкая:
                    return "Крупногабаритная (Громоздкая)";
                case PostMark.С_доставкой_Доставка_нарочным:
                    return "С доставкой (Доставка нарочным)";
                case PostMark.Вручить_в_собственные_руки:
                    return "Вручить в собственные руки";
                case PostMark.С_документами:
                    return "С документами";
                case PostMark.С_товарами:
                    return "С товарами";
                case PostMark.Возврату_не_подлежит:
                    return "Возврату не подлежит";
                case PostMark.Нестандартная:
                    return "Нестандартная";
                case PostMark.Приграничная:
                    return "Приграничная";
                case PostMark.Застраховано:
                    return "Застраховано";
                case PostMark.С_электронным_уведомлением:
                    return "С электронным уведомлением";
                case PostMark.Курьер_бизнес_экспресс:
                    return "Курьер бизнес-экспресс";
                case PostMark.Нестандартная_до_10_кг:
                    return "Нестандартная до 10 кг";
                case PostMark.Нестандартная_до_20_кг:
                    return "Нестандартная до 20 кг";
                case PostMark.С_наложенным_платежом:
                    return "С наложенным платежом";
                case PostMark.Гарантия_сохранности:
                    return "Гарантия сохранности";
                case PostMark.Заверительный_пакет:
                    return "Заверительный пакет";
                case PostMark.Доставка_курьером:
                    return "Доставка курьером";
                case PostMark.Проверка_комплектности:
                    return "Проверка комплектности";
                case PostMark.Негабаритная:
                    return "Негабаритная";
                case PostMark.В_упаковке_Почты_России:
                    return "В упаковке Почты России";
                case PostMark.Доставка_по_звонку:
                    return "Доставка по звонку";
                case PostMark.Ценность_вложения:
                    return "Ценность вложения";
                case PostMark.С_обратной_доставкой:
                    return "С обратной доставкой";
                case PostMark.В_предоплаченном_пакете:
                    return "В предоплаченном пакете";
                case PostMark.ВСД:
                    return "ВСД";
                case PostMark.COD:
                    return "COD";
                case PostMark.Запрещено_продлевать_срок_хранения:
                    return "Запрещено продлевать срок хранения";
                case PostMark.Легкий_возврат:
                    return "Легкий возврат";
                default:
                    throw new NotImplementedException("Данный кодов отметки почтового отправления не реализован");
            }
        }
        /// <summary>
        /// Получаем кодо отметки почтовых отправлений по РТМ 002
        /// </summary>
        /// <returns></returns>
        public static long GetEnumCode(this PostMark direct)
        {
            switch (direct)
            {
                case PostMark.Без_отметки:
                    return 0;
                case PostMark.С_простым_уведомлением:
                    return 1;
                case PostMark.С_заказным_уведомлением:
                    return 2;
                case PostMark.С_описью:
                    return 4;
                case PostMark.Осторожно_Хрупкая:
                    return 8;
                case PostMark.Тяжеловесная:
                    return 16;
                case PostMark.Крупногабаритная_Громоздкая:
                    return 32;
                case PostMark.С_доставкой_Доставка_нарочным:
                    return 64;
                case PostMark.Вручить_в_собственные_руки:
                    return 128;
                case PostMark.С_документами:
                    return 256;
                case PostMark.С_товарами:
                    return 512;
                case PostMark.Возврату_не_подлежит:
                    return 1024;
                case PostMark.Нестандартная:
                    return 2048;
                case PostMark.Приграничная:
                    return 4096;
                case PostMark.Застраховано:
                    return 8192;
                case PostMark.С_электронным_уведомлением:
                    return 16384;
                case PostMark.Курьер_бизнес_экспресс:
                    return 32768;
                case PostMark.Нестандартная_до_10_кг:
                    return 65536;
                case PostMark.Нестандартная_до_20_кг:
                    return 131072;
                case PostMark.С_наложенным_платежом:
                    return 262144;
                case PostMark.Гарантия_сохранности:
                    return 524288;
                case PostMark.Заверительный_пакет:
                    return 1048576;
                case PostMark.Доставка_курьером:
                    return 2097152;
                case PostMark.Проверка_комплектности:
                    return 4194304;
                case PostMark.Негабаритная:
                    return 8388608;
                case PostMark.В_упаковке_Почты_России:
                    return 16777216;
                case PostMark.Доставка_по_звонку:
                    return 33554432;
                case PostMark.Ценность_вложения:
                    return 67108864;
                case PostMark.С_обратной_доставкой:
                    return 134217728;
                case PostMark.В_предоплаченном_пакете:
                    return 268435456;
                case PostMark.ВСД:
                    return 536870912;
                case PostMark.COD:
                    return 1073741824;
                case PostMark.Запрещено_продлевать_срок_хранения:
                    return 2147483648;
                case PostMark.Легкий_возврат:
                    return 4294967296;
                default:
                    throw new NotImplementedException("Данный кодов отметки почтового отправления не реализован");
            }
        }

        /// <summary>
        /// Получить <see cref="PostMark"/> по коду типа int
        /// </summary>
        /// <param name="code">Код для парса по <see cref="PostMark"/></param>
        /// <returns></returns>
        public static PostMark GetTypePostMarkByCode(this long code)
        {
            switch (code)
            {
                case 0:
                    return PostMark.Без_отметки;
                case 1:
                    return PostMark.С_простым_уведомлением;
                case 2:
                    return PostMark.С_заказным_уведомлением;
                case 4:
                    return PostMark.С_описью;
                case 8:
                    return PostMark.Осторожно_Хрупкая;
                case 16:
                    return PostMark.Тяжеловесная;
                case 32:
                    return PostMark.Крупногабаритная_Громоздкая;
                case 64:
                    return PostMark.С_доставкой_Доставка_нарочным;
                case 128:
                    return PostMark.Вручить_в_собственные_руки;
                case 256:
                    return PostMark.С_документами;
                case 512:
                    return PostMark.С_товарами;
                case 1024:
                    return PostMark.Возврату_не_подлежит;
                case 2048:
                    return PostMark.Нестандартная;
                case 4096:
                    return PostMark.Приграничная;
                case 8192:
                    return PostMark.Застраховано;
                case 16384:
                    return PostMark.С_электронным_уведомлением;
                case 32768:
                    return PostMark.Курьер_бизнес_экспресс;
                case 65536:
                    return PostMark.Нестандартная_до_10_кг;
                case 131072:
                    return PostMark.Нестандартная_до_20_кг;
                case 262144:
                    return PostMark.С_наложенным_платежом;
                case 524288:
                    return PostMark.Гарантия_сохранности;
                case 1048576:
                    return PostMark.Заверительный_пакет;
                case 2097152:
                    return PostMark.Доставка_курьером;
                case 4194304:
                    return PostMark.Проверка_комплектности;
                case 8388608:
                    return PostMark.Негабаритная;
                case 16777216:
                    return PostMark.В_упаковке_Почты_России;
                case 33554432:
                    return PostMark.Доставка_по_звонку;
                case 67108864:
                    return PostMark.Ценность_вложения;
                case 134217728:
                    return PostMark.С_обратной_доставкой;
                case 268435456:
                    return PostMark.В_предоплаченном_пакете;
                case 536870912:
                    return PostMark.ВСД;
                case 1073741824:
                    return PostMark.COD;
                case 2147483648:
                    return PostMark.Запрещено_продлевать_срок_хранения;
                case 4294967296:
                    return PostMark.Легкий_возврат;
                default:
                    throw new NotFiniteNumberException($"{nameof(PostMark)} для данного кода не реализован");
            }
        }


        #endregion

        #region SendrCtgRegion
        /// <summary>
        /// Получам наименование категории отправителей по РТМ 002
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this SendCtg direct)
        {
            switch (direct)
            {
                case SendCtg.Население:
                    return "Население";
                case SendCtg.Бюджетная_организация:
                    return "Бюджетная организация";
                case SendCtg.Хозрасчетная_организация:
                    return "Хозрасчетная организация";
                case SendCtg.Международный_оператор:
                    return "Международный оператор";
                case SendCtg.Корпоративный_клиент:
                    return "Корпоративный клиент";
                case SendCtg.Почтовый_оператор:
                    return "Почтовый оператор";
                default:
                    throw new NotImplementedException("Данный вид категории отправителя не реализован");
            }
        }
        /// <summary>
        /// Получаем код категории отправителей
        /// </summary>
        /// <returns></returns>
        public static int GetEnumCode(this SendCtg direct)
        {
            switch (direct)
            {
                case SendCtg.Население:
                    return 1;
                case SendCtg.Бюджетная_организация:
                    return 2;
                case SendCtg.Хозрасчетная_организация:
                    return 3;
                case SendCtg.Международный_оператор:
                    return 4;
                case SendCtg.Корпоративный_клиент:
                    return 5;
                case SendCtg.Почтовый_оператор:
                    return 6;
                default:
                    throw new NotImplementedException("Данный вид категории отправителя не реализован");
            }
        }
        /// <summary>
        /// Получить <see cref="SendCtg"/> по коду типа int
        /// </summary>
        /// <param name="code">Код для парса по <see cref="SendCtg"/></param>
        /// <returns></returns>
        public static SendCtg GetTypeSendCtgNotByCode(this int code)
        {
            switch (code)
            {
                case 1:
                    return SendCtg.Население;
                case 2:
                    return SendCtg.Бюджетная_организация;
                case 3:
                    return SendCtg.Хозрасчетная_организация;
                case 4:
                    return SendCtg.Международный_оператор;
                case 5:
                    return SendCtg.Корпоративный_клиент;
                case 6:
                    return SendCtg.Почтовый_оператор;
                default:
                    throw new NotFiniteNumberException($"{nameof(SendCtg)} для данного кода не реализован");
            }
        }
        #endregion

        #region TransTypeRegion
        /// <summary>
        /// Получам наименование способа доставки почтовых отправлений по РТМ 002
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this TransTypes direct)
        {
            switch (direct)
            {
                case TransTypes.Наземный:
                    return "Наземный";
                case TransTypes.Авиа:
                    return "Авиа";
                case TransTypes.Комбинированный:
                    return "Комбинированный";
                case TransTypes.Системой_ускоренной_почты:
                    return "Системой ускоренной почты";
                case TransTypes.Электронный:
                    return "Электронный";
                case TransTypes.Стандарт:
                    return "Стандарт ";
                default:
                    throw new NotImplementedException("Данный вид способа отправки не существует");
            }
        }
        /// <summary>
        /// Получаем код способа доставки почтовых по РТМ 002
        /// </summary>
        /// <returns></returns>
        public static int GetEnumCode(this TransTypes direct)
        {
            switch (direct)
            {
                case TransTypes.Наземный:
                    return 1;
                case TransTypes.Авиа:
                    return 2;
                case TransTypes.Комбинированный:
                    return 3;
                case TransTypes.Системой_ускоренной_почты:
                    return 4;
                case TransTypes.Электронный:
                    return 5;
                case TransTypes.Стандарт:
                    return 6;
                default:
                    throw new NotImplementedException("Данный вид способа отправки не существует");
            }
        }

        /// <summary>
        /// Получить <see cref="TransTypes"/> по коду типа int
        /// </summary>
        /// <param name="code">Код для парса по <see cref="TransTypes"/></param>
        /// <returns></returns>
        public static TransTypes GetTypeTransTypesNotByCode(this int code)
        {
            switch (code)
            {
                case 1:
                    return TransTypes.Наземный;
                case 2:
                    return TransTypes.Авиа;
                case 3:
                    return TransTypes.Комбинированный;
                case 4:
                    return TransTypes.Системой_ускоренной_почты;
                case 5:
                    return TransTypes.Электронный;
                case 6:
                    return TransTypes.Стандарт;
                default:
                    throw new NotFiniteNumberException($"{nameof(TransTypes)} для данного кода не реализован");
            }
        }
        #endregion

        #region TarificatorsEnumsRegion
        /// <summary>
        /// Получаем Назрачание объекта в рассчете согласно тарификатору
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this TarificatorObjectType direct)
        {
            switch (direct)
            {
                case TarificatorObjectType.Место_Приема:
                    return "место приема";
                case TarificatorObjectType.Место_Назначения:
                    return "место назначения";
                case TarificatorObjectType.Место_МЖД_ПО_Исходящего_отправлния:
                    return "место международного почтового обмена исходящего отправления";
                case TarificatorObjectType.Место_МЖД_ПО_Входящего_отправления:
                    return "место международного почтового обмена входящего отправления";
                case TarificatorObjectType.Место_перегрузки:
                    return "место перегрузки";
                case TarificatorObjectType.Прочее:
                    return "прочее ";
                default:
                    throw new NotImplementedException("Данный вид назачения обхекта при расчете тарифа не реализован");
            }
        }

        /// <summary>
        /// Получаем Ошибки при расчете тарифов
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this TarifsErrorsType direct)
        {
            switch (direct)
            {
                case TarifsErrorsType.Inernal:
                    return "внутренняя системная ошибка сервиса";
                case TarifsErrorsType.CalculateError:
                    return "ошибка, произошедшая при расчете тарифа";
                case TarifsErrorsType.ContrDatesErrors:
                    return "ошибка, произошедшая при расчете контрольного срока";
                case TarifsErrorsType.OthersErrors:
                    return "ошибка, не относящаяся к конкретному расчету (например, неверный формат входного запроса)";
                default:
                    throw new NotImplementedException("Данный вид ошибки при расчете тарифов не реализован");
            }
        }
        /// <summary>
        /// Получаем признак трудонодоступности в тексте
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this TarifsHard direct)
        {
            switch (direct)
            {
                case TarifsHard.Hard:
                    return "труднодоступный";
                case TarifsHard.NotHard:
                    return "не труднодоступный";
                
                default:
                    throw new NotImplementedException($"Данный вид {nameof(TarifsHard)} не реализован") ;
            }
        }
        /// <summary>
        /// Получаем признак наличия ограничений по наземной пересылке на дату расчета
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this ComboEnum direct)
        {
            switch (direct)
            {
                case ComboEnum.Combo:
                    return "ограничения есть";
                case ComboEnum.NotCombo:
                    return "ограничений нет";
                default:
                    throw new NotImplementedException($"Данный вид {nameof(ComboEnum)} не реализован");
            }
        }
        /// <summary>
        /// Получаем признак наличия ограничения по доставке на дату расчета
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this ClosedPostOffice direct)
        {
            switch (direct)
            {
                case ClosedPostOffice.Closed:
                    return "доставка возможна";
                case ClosedPostOffice.Open:
                    return "доставка запрещена";
                default:
                    throw new NotImplementedException($"Данный вид {nameof(ClosedPostOffice)} не реализован");
            }
        }

        /// <summary>
        /// Получаем признак «Возможность примерки»
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this ItemCheck direct)
        {
            switch (direct)
            {
                case ItemCheck.Yes:
                    return "возможности есть";
                case ItemCheck.No:
                    return "возможности нет";
                default:
                    throw new NotImplementedException($"Данный вид {nameof(ItemCheck)} не реализован");
            }
        }
        /// <summary>
        /// Получаем признак «Возможность проверки вложений»
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this ItemCheckView direct)
        {
            switch (direct)
            {
                case ItemCheckView.Yes:
                    return "возможности есть";
                case ItemCheckView.No:
                    return "возможности нет";
                default:
                    throw new NotImplementedException($"Данный вид {nameof(ItemCheckView)} не реализован");
            }
        }
        /// <summary>
        /// Получаем признак вывода кода ответа при ошибке расчета
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this ErrorCodeQueryEnum direct)
        {
            switch (direct)
            {
                case ErrorCodeQueryEnum.ErrorCode:
                    return "при ошибке расчета возвращается HTTPS-код ответа в диапазоне 400-499";
                case ErrorCodeQueryEnum.CodeSuccess:
                    return "при ошибке расчета возвращается HTTPS-код ответа 200";
                default:
                    throw new NotImplementedException($"Данный вид {nameof(ErrorCodeQueryEnum)} не реализован");
            }
        }
        /// <summary>
        /// Получаем признак «Частичная выдача»
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this PartOut direct)
        {
            switch (direct)
            {
                case PartOut.Yes:
                    return "возможности есть";
                case PartOut.No:
                    return "возможности нет";
                default:
                    throw new NotImplementedException($"Данный вид {nameof(PartOut)} не реализован");
            }
        }
        /// <summary>
        /// Получаем признак «Проверка работоспособности»
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this CheckWork direct)
        {
            switch (direct)
            {
                case CheckWork.Yes:
                    return "проверка есть";
                case CheckWork.No:
                    return "проверки нет";
                default:
                    throw new NotImplementedException($"Данный вид {nameof(CheckWork)} не реализован");
            }
        }
        /// <summary>
        /// Получаем признак «Является доставочным»
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this IsMoveble direct)
        {
            switch (direct)
            {
                case IsMoveble.No:
                    return "объект не является доставочным";
                case IsMoveble.Yes:
                    return "объект является доставочным";
                default:
                    throw new NotImplementedException($"Данный вид {nameof(IsMoveble)} не реализован");
            }
        }
        /// <summary>
        /// Получаем признак возможности тарификации группы отправлений
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this IsGroupEnum direct)
        {
            switch (direct)
            {
                case IsGroupEnum.No:
                    return "запрещено";
                case IsGroupEnum.Yes:
                    return "разрешено";
                default:
                    throw new NotImplementedException($"Данный вид {nameof(IsGroupEnum)} не реализован");
            }
        }
        /// <summary>
        /// Получаем признак возможности или невозможности расчета во временно закрытый для доставки период
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this ClosedPerDeliveryEnum direct)
        {
            switch (direct)
            {
                case ClosedPerDeliveryEnum.No:
                    return "Неовзможно";
                case ClosedPerDeliveryEnum.Yes:
                    return "Возможно";
                default:
                    throw new NotImplementedException($"Данный вид {nameof(ClosedPerDeliveryEnum)} не реализован");
            }
        }
        /// <summary>
        /// Получаем признак возможности тарификации группы отправлений
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this IsDogovorEnum direct)
        {
            switch (direct)
            {
                case IsDogovorEnum.No:
                    return "не используются";
                case IsDogovorEnum.Yes:
                    return "используются.";
                default:
                    throw new NotImplementedException($"Данный вид {nameof(IsDogovorEnum)} не реализован");
            }
        }
        /// <summary>
        /// Получаем указание на формат данных в ответе
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this TarifsQuerySettingsEnum direct)
        {
            switch (direct)
            {
                case TarifsQuerySettingsEnum.json:
                    return "ответ в формате JSON";
                case TarifsQuerySettingsEnum.jsontext:
                    return "ответ в формате JSON с переносом строк и отступами";
                case TarifsQuerySettingsEnum.html:
                    return "ответ в формате html";
                case TarifsQuerySettingsEnum.htmlfull:
                    return "вывод результатов в виде полной страницы html";
                case TarifsQuerySettingsEnum.text:
                    return "вывод результатов в виде неформатированного текста";
                default:
                    throw new NotImplementedException($"Данный вид {nameof(TarifsQuerySettingsEnum)} не реализован");
            }
        }
        /// <summary>
        /// Получаем признак варианта расчета
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this IsSizeEnum direct)
        {
            switch (direct)
            {
                case IsSizeEnum.Weight:
                    return "Расчет тарифа по весу";
                case IsSizeEnum.Size:
                    return "Расчет тарифа по габаритам";
                default:
                    throw new NotImplementedException($"Данный вид {nameof(IsSizeEnum)} не реализован");
            }
        }
        /// <summary>
        /// Получаем признак «Оплата картой»
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this IsCardPay direct)
        {
            switch (direct)
            {
                case IsCardPay.No:
                    return "объект не является доставочным";
                case IsCardPay.Yes:
                    return "объект является доставочным";
                default:
                    throw new NotImplementedException($"Данный вид {nameof(IsCardPay)} не реализован");
            }
        }
        /// <summary>
        /// Получаем признак «Оплата наличными»
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this IsCash direct)
        {
            switch (direct)
            {
                case IsCash.No:
                    return "объект не является доставочным";
                case IsCash.Yes:
                    return "объект является доставочным";
                default:
                    throw new NotImplementedException($"Данный вид {nameof(IsCash)} не реализован");
            }
        }
        /// <summary>
        /// Получаем признак «Партнерский»
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this IsPartner direct)
        {
            switch (direct)
            {
                case IsPartner.No:
                    return "объект не является доставочным";
                case IsPartner.Yes:
                    return "объект является доставочным";
                default:
                    throw new NotImplementedException($"Данный вид {nameof(IsPartner)} не реализован");
            }
        }
        /// <summary>
        /// Получаем признак «Пункт выдачи заказов» (ПВЗ)
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this IsPvz direct)
        {
            switch (direct)
            {
                case IsPvz.No:
                    return "объект не является ПВЗ";
                case IsPvz.Yes:
                    return "объект является ПВЗ";
                default:
                    throw new NotImplementedException($"Данный вид {nameof(IsPvz)} не реализован");
            }
        }
        /// <summary>
        /// Получаем признак разрешения на отправления с объявленной ценностью
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this CurrencySend direct)
        {
            switch (direct)
            {
                case CurrencySend.Yes:
                    return "отправления с объявленной ценностью разрешены";
                case CurrencySend.No:
                    return "отправления с объявленной ценностью запрещены";
                default:
                    throw new NotImplementedException($"Данный вид {nameof(CurrencySend)} не реализован");
            }
        }
        /// <summary>
        /// Получаем признак разрешения на отправления с объявленной ценностью
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this PaymentOndelivery direct)
        {
            switch (direct)
            {
                case PaymentOndelivery.Yes:
                    return "отправления с наложенным платежом разрешены";
                case PaymentOndelivery.No:
                    return "отправления с наложенным платежом запрещены";
                default:
                    throw new NotImplementedException($"Данный вид {nameof(PaymentOndelivery)} не реализован");
            }
        }
        /// <summary>
        /// Получаем коды типов упаковки
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this PackegeEnum direct)
        {
            switch (direct)
            {
                case PackegeEnum.Box_S:
                    return "Коробка \"S\"";
                case PackegeEnum.Package_S:
                    return "Пакет полиэтиленовый \"S\"";
                case PackegeEnum.Envelope_S:
                    return "Конверт с воздушно-пузырчатой пленкой \"S\"";
                case PackegeEnum.Box_M:
                    return "Коробка \"М\"";
                case PackegeEnum.Package_M:
                    return "Пакет полиэтиленовый \"М\"";
                case PackegeEnum.Envelope_M:
                    return "Конверт с воздушно-пузырчатой пленкой \"М\"";
                case PackegeEnum.Box_L:
                    return "Коробка \"L\"";
                case PackegeEnum.Package_L:
                    return "Пакет полиэтиленовый \"L\"";
                case PackegeEnum.Box_XL:
                    return "Коробка \"ХL\"";
                case PackegeEnum.Package_XL:
                    return "Пакет полиэтиленовый \"ХL\"";
                case PackegeEnum.NonStandart:
                    return "Нестандартная упаковка";
                
                default:
                    throw new NotImplementedException($"Данный вид {nameof(PackegeEnum)} не реализован");
            }
        }
        /// <summary>
        /// Получаем предпочтительный вариант доставки
        /// </summary>
        /// <returns></returns>
        public static string GetEnumString(this TarifsSenderHelper direct)
        {
            switch (direct)
            {
                case TarifsSenderHelper.PreferLand:
                    return "наземная доставка";
                case TarifsSenderHelper.PreferAvia:
                    return "предпочтительно воздушная доставка";
                case TarifsSenderHelper.OnlyAvia:
                    return "строго воздушная доставка";
                default:
                    throw new NotImplementedException($"Данный вид {nameof(TarifsSenderHelper)} не реализован");
            }
        }
        #endregion
        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
        
    }
}
