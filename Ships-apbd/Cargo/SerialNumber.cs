using System;

namespace Apbd_miniProject01
{
    public class SerialNumber
    {
        private string FirstPart;
        private char SecondPart;
        private int ThirdPart;

        public void createSerialNumber()
        {
            FirstPart = "KON";
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            SecondPart = chars[new Random().Next(chars.Length)];
            ThirdPart = new Random().Next(0, 9);
        }

        public override string ToString()
        {
            return FirstPart +"-" + SecondPart+"-" + ThirdPart;
        }
    }
}