using System.Text.RegularExpressions;
using DocumentValidation.Validates;

namespace DocumentValidation;
public static class Validate
{
    static readonly CpfValidate cpf = new CpfValidate();
    static readonly CnpjValidate cnpj = new CnpjValidate();

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

    public static bool ValidateCnpj(this string fullCnpj){
        var regex = @"^([0-9]{2}.[0-9]{3}.[0-9]{3}/[0-9]{4}-[0-9]{2})|([0-9]{14})$";

        bool cnpjValidate = ValidateRule(regex, fullCnpj);

        if (!cnpjValidate)
            return false;
        else
            return Validate.cnpj.MathValidate(fullCnpj);
    }

    public static bool ValidateCpf(this string fullCpf)
    {
        var regex = @"^([0-9]{3}.[0-9]{3}.[0-9]{3}.[0-9]{2})$";

        bool cpfValidate = ValidateRule(regex, fullCpf);

        if (!cpfValidate)
            return false;
        else
            return Validate.cpf.MathValidate(fullCpf);

    }
}
