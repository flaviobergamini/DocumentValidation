using System.Text.RegularExpressions;

namespace DocumentValidation;
public static class Validate
{
    private static bool ValidateRule(string rule, string word){

        var validate = new Regex(rule);

        if (validate.IsMatch(word))
            return true;
        else
            return false;
    }
    public static bool ValidatePhone(this string phone){
        var regex = @"^\(([1-9]){2}\)(?:([0-9]{5})|([0-9]{4}))-([0-9]{4})$";
        return ValidateRule(regex, phone);
    }

    public static bool ValidateCep(this string cep){
        var regex = @"^(([0-9]){5})-([0-9]{3})$";
        return ValidateRule(regex, cep);
    }

    public static bool ValidateEmail(this string email){
        var regex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return ValidateRule(regex, email);
    }

    public static bool ValidateCnpj(this string cnpj){
        var regex = @"^([0-9]{2}.[0-9]{3}.[0-9]{3}/[0-9]{4}-[0-9]{2})|([0-9]{14})$";
        return ValidateRule(regex, cnpj);
    }

    public static bool ValidateCpf(this string fullCpf)
    {
        var regex = @"^([0-9]{3}.[0-9]{3}.[0-9]{3}.[0-9]{2})$";

        bool cpfValidate = ValidateRule(regex, fullCpf);

        if (!cpfValidate)
            return false;
        else
        {
            List<string> wrontCpf = new List<string>(){
                "000.000.000-00",
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
                if (i == fullCpf)
                    return false;
            }
            var cpf = fullCpf.Substring(0, (fullCpf.Length - 3));
            var digit = fullCpf.Substring(12, 2);

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
            {
                return false;
            }

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
            {
                return false;
            }

            return true;
        }

    }
}
