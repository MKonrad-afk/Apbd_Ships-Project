using System.Collections.Generic;

namespace Apbd_miniProject01
{
    public static class SerialNumberRegister
    {
        static List<SerialNumber> serialNumbers;
        
        
        public static SerialNumber generateSerialNUmber()
        {
            SerialNumber tempSerialNumber = new SerialNumber();
            tempSerialNumber.createSerialNumber();
            foreach (var number in serialNumbers)
            {
                if (number.getSerialNumber().Equals(tempSerialNumber.getSerialNumber()))
                {
                    generateSerialNUmber();
                }
            }
            serialNumbers.Add(tempSerialNumber);
            return tempSerialNumber;
        }
    }
    
}