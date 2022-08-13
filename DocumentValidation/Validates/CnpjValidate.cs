using DocumentValidation.Interfaces;

namespace DocumentValidation.Validates
{
    public class CnpjValidate : IValidateDocuments
    {
        public bool MathValidate(string fullDocument)
        {
            List<string> wrontCnpj = new List<string>(){
                "00.000.000/0000-00",
                "11.111.111/1111-11",
                "22.222.222/2222-22",
                "33.333.333/3333-33",
                "44.444.444/4444-44",
                "55.555.555/5555-55",
                "66.666.666/6666-66",
                "77.777.777/7777-77",
                "88.888.888/8888-88",
                "99.999.999/9999-99",
            };

            foreach (var i in wrontCnpj)
            {
                if (i == fullDocument)
                    return false;
            }

            var cnpj = fullDocument.Substring(0, (fullDocument.Length - 3));
            var cnpjReverse = new string(cnpj.Reverse().ToArray());
            var digit = fullDocument.Substring(15, 2);

            int multiplies = 2;
            int result = 0;

            foreach (char i in cnpjReverse)
            {
                if (i != '.' && i != '-' && i != '/')
                {
                    result += multiplies*(int)Char.GetNumericValue(i);
                    multiplies++;
                    if (multiplies > 9)
                        multiplies = 2;
                }
            }

            var firstDigit = 11 - (result % 11);

            if (firstDigit >= 10)
                firstDigit = 0;

            if (Int32.Parse(digit.Substring(1, 1)) != firstDigit)
                return false;

            multiplies = 2;
            result = 0;
            cnpjReverse = digit.Substring(0, 1) + cnpjReverse;

            foreach (char i in cnpjReverse)
            {
                if (i != '.' && i != '-' && i != '/')
                {
                    result += multiplies*(int)Char.GetNumericValue(i);
                    multiplies++;
                    if (multiplies > 9)
                        multiplies = 2;
                }
            }

            var SecondDigit = 11 - (result % 11);

            if (SecondDigit >= 10)
                SecondDigit = 0;

            if (Int32.Parse(digit.Substring(1, 1)) != SecondDigit)
                return false;

            return true;
        
        }
    }
}
