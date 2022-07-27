namespace DocumentValidation.Tests;

[TestClass]
public class DocumentValidationTests
{
    // Validate Telephone
    [TestMethod]
    public void ValidatePhone5Digits()
    {
        string telephone = "(35)35123-8146";

        var validate = telephone.ValidatePhone();
        Assert.AreEqual(true, validate);
    }

    [TestMethod]
    public void ValidatePhone4Digits()
    {
        string telephone = "(11)3456-8146";

        var validate = telephone.ValidatePhone();
        Assert.AreEqual(true, validate);
    }

    [TestMethod]
    public void ValidatePhone()
    {
        string telephone = "11)346481-46";

        var validate = telephone.ValidatePhone();
        Assert.AreEqual(false, validate);
    }

    // Validate CEP

    [TestMethod]
    public void ValidateCepTrue()
    {
        string cep = "37540-000";
        var validate = cep.ValidateCep();
        Assert.AreEqual(true, validate);
    }

    [TestMethod]
    public void ValidateCepFalse()
    {
        string cep = "37540000";
        var validate = cep.ValidateCep();
        Assert.AreEqual(false, validate);
    }

    // Validate Email
    [TestMethod]
    public void ValidateEmailDot()
    {
        string email = "flavio.bergamini@hotmail.com";
        var validate = email.ValidateEmail();
        Assert.AreEqual(true, validate);
    }

    [TestMethod]
    public void ValidateEmailLine()
    {
        string email = "flavio_bergamini@hotmail.com";
        var validate = email.ValidateEmail();
        Assert.AreEqual(true, validate);
    }

    [TestMethod]
    public void ValidateEmailSingle()
    {
        string email = "flavio@hotmail.com.br";
        var validate = email.ValidateEmail();
        Assert.AreEqual(true, validate);
    }

    [TestMethod]
    public void ValidateEmailFalse()
    {
        string email = "@hotmail.com";
        var validate = email.ValidateEmail();
        Assert.AreEqual(false, validate);
    }

    [TestMethod]
    public void ValidateEmailNoServer()
    {
        string email = "flavio";
        var validate = email.ValidateEmail();
        Assert.AreEqual(false, validate);
    }

    //Validate CNPJ

    [TestMethod]
    public void ValidateCnpjTrue()
    {
        string cnpj = "43.699.281/0001-25";
        var validate = cnpj.ValidateCnpj();
        Assert.AreEqual(true, validate);
    }

    [TestMethod]
    public void ValidateCnpjFalse()
    {
        string cnpj = "43699281/0001-25";
        var validate = cnpj.ValidateCnpj();
        Assert.AreEqual(false, validate);
    }

    [TestMethod]
    public void ValidateCnpjLetter()
    {
        string cnpj = "43.6f9.2h1/0001-MB";
        var validate = cnpj.ValidateCnpj();
        Assert.AreEqual(false, validate);
    }

    //Validate CPF

    [TestMethod]
    public void ValidateCpfTrue()
    {
        string cpf = "000.999.888-77";
        var validate = cpf.ValidateCpf();
        Assert.AreEqual(true, validate);
    }

    [TestMethod]
    public void ValidateCpfFalse()
    {
        string cpf = "00099988877";
        var validate = cpf.ValidateCpf();
        Assert.AreEqual(false, validate);
    }

    [TestMethod]
    public void ValidateCpfLetter()
    {
        string cpf = "0F0.H99.M88-7B";
        var validate = cpf.ValidateCpf();
        Assert.AreEqual(false, validate);
    }
}