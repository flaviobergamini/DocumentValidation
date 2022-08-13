using DocumentValidation.Interfaces;

namespace DocumentValidation.Validates
{
    public class CpfValidate: IValidateDocuments
    {
        public bool MathValidate(string fullDocument)
        {
            List<string> wrontCpf = new List<string>(){
                "000.000.000-00",
                "111.111.111-11",
                "222.222.222-22",
                "333.333.333-33",
                "444.444.444-44",
                "555.555.555-55",
                "666.666.666-66",
                "777.777.777-77",
                "888.888.888-88",
                "999.999.999-99",
            };

            foreach (var i in wrontCpf)
            {
                if (i == fullDocument)
                    return false;
            }
            var cpf = fullDocument.Substring(0, (fullDocument.Length - 3));
            var digit = fullDocument.Substring(12, 2);

            int multiplies = 10;
            int result = 0;

            foreach (char i in cpf)
            {
                if (i != '.' && i != '-')
                {
                    result += multiplies*(int)Char.GetNumericValue(i);
                    multiplies--;
                }
            }

            var firstDigit = 11 - (result % 11);

            if (firstDigit >= 10)
                firstDigit = 0;

            if (Int32.Parse(digit.Substring(0, 1)) != firstDigit)
                return false;

            multiplies = 11;
            result = 0;
            cpf = cpf + digit.Substring(0, 1);

            foreach (char i in cpf)
            {
                if (i != '.' && i != '-')
                {
                    result += multiplies*(int)Char.GetNumericValue(i);
                    multiplies--;
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
