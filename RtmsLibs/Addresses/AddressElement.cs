using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.Addresses
{
    /// <summary>
    /// Элемент адреса
    /// </summary>
    public class AddressElement
    {
        public int MaxLengthElement { get; }
        public int MinLengthElement { get; }

        public AddressElement(string addressElemetn, string addressVal = null, int maxElementLength = 0, int minElementLenth = 0)
        {
            AddressElementName = addressVal;
            AddressString = addressElemetn;
            MaxLengthElement = maxElementLength;
            MinLengthElement = minElementLenth;
        }
        /// <summary>
        /// Элемент адреса. Заголовок адреса (кв. город. район и так далее)
        /// </summary>
        public string AddressElementName { get; set; }
        /// <summary>
        /// Сам адрес без родительского элемента
        /// </summary>
        public string AddressString { get; set; }
        public override string ToString()
        {
            if(MaxLengthElement != 0 && MaxLengthElement < $"{AddressElementName} {AddressString}".Length)
            {
                return $"{AddressString}".Trim();
            }
            return $"{AddressElementName} {AddressString}".Trim();
        }

    }
}
