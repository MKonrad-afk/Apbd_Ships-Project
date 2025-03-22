using System.Collections.Generic;

namespace Apbd_miniProject01
{
    public static class SerialNumberRegister
    {
        static List<SerialNumber> serialNumbers = new List<SerialNumber>(); 

        public static SerialNumber generateSerialNUmber()
        {
            SerialNumber tempSerialNumber;
            bool isUnique;

            do
            {
                tempSerialNumber = new SerialNumber();
                tempSerialNumber.createSerialNumber();
                isUnique = true;

                foreach (var number in serialNumbers)
                {
                    if (number.Equals(tempSerialNumber))
                    {
                        isUnique = false;
                        break; 
                    }
                }
            } while (!isUnique); 

            serialNumbers.Add(tempSerialNumber);
            return tempSerialNumber;
        }
    }
}