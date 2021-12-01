﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.Rtm002Lib
{
    public enum PayType
    {
        Наличная = 0,
        Безналичная = 1,
        Бесплатно = 2,
        Платежная_карта = 3,
        Государственные_знаки_почтовой_оплаты_марками = 4,
        Предоплата_авансовый_платеж = 5,
        Оплачено_международному_оператору = 6,
        Оплачивается_получателем = 7,
        Государственные_знаки_почтовой_оплаты_франкирование = 8,
        Оплачивается_ЭТП = 9,
        Государственные_знаки_почтовой_оплаты_знак_онлайн_оплаты = 10
    }
    public enum PayTypeNot
    {
        Наличная = 0,
        Безналичная = 1,
        Платежная_карта = 2,
        Предоплата_авансовый_платеж = 3,
    }
}
