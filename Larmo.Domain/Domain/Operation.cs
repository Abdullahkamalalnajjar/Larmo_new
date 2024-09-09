namespace Larmo.Domain.Domain;

public class Operation
{
    //private string _amount;
    //private string _clientIdentityNumber;
    //private string _iban;
    //private string _currencyType;
    //private string _beneficiaryName;
    //private string _beneficiaryCountry;
    //private string _beneficiaryCity;
    //private string _beneficiaryArea;
    //private string _beneficiaryNearestMilestone;
    //private string _sourceOfFunds;
    //private string _sendingParty;
    //private string _receivingParty;
    //private string _clientProfession;
    //private string _clientCountry;
    //private string _clientCity;
    //private string _clientArea;
    //private string _clientNearestMilestone;
    //private string _beneficiaryClientRelationship;
    //private string _beneficiaryActivity;
    //private string _operationType;
    //private string _date;

    public int Id { get; private set; }

    public string Date { get; set; }
    //public string Date
    //{
    //    get => _date.Decrypt();
    //    private set => _date = value.Encrypt();
    //}

    public string OperationType { get; set; }
    //public string OperationType
    //{
    //    get => _operationType.Decrypt();
    //    private set => _operationType = value.Encrypt();
    //}

    public string Amount { get; set; }
    //public string Amount
    //{
    //    get => _amount.Decrypt();
    //    private set => _amount = value.Encrypt();
    //}

    public string CurrencyType { get; set; }
    //public string CurrencyType
    //{
    //    get => _currencyType.Decrypt();
    //    set => _currencyType = value.Encrypt();
    //}

    public string Iban { get; set; }
    //public string Iban
    //{
    //    get => _iban.Decrypt();
    //    set => _iban = value.Encrypt();
    //}

    public string BeneficiaryName { get; set; }
    //public string BeneficiaryName
    //{
    //    get => _beneficiaryName.Decrypt();
    //    set => _beneficiaryName = value.Encrypt();
    //}

    public string BeneficiaryCountry { get; set; }
    //public string BeneficiaryCountry
    //{
    //    get => _beneficiaryCountry.Decrypt();
    //    set => _beneficiaryCountry = value.Encrypt();
    //}

    public string BeneficiaryCity { get; set; }
    //public string BeneficiaryCity
    //{
    //    get => _beneficiaryCity.Decrypt();
    //    set => _beneficiaryCity = value.Encrypt();
    //}

    public string BeneficiaryArea { get; set; }
    //public string BeneficiaryArea
    //{
    //    get => _beneficiaryArea.Decrypt();
    //    set => _beneficiaryArea = value.Encrypt();
    //}

    public string BeneficiaryNearestMilestone { get; set; }
    //public string BeneficiaryNearestMilestone
    //{
    //    get => _beneficiaryNearestMilestone.Decrypt();
    //    set => _beneficiaryNearestMilestone = value.Encrypt();
    //}

    public string SourceOfFunds { get; set; }
    //public string SourceOfFunds
    //{
    //    get => _sourceOfFunds.Decrypt();
    //    set => _sourceOfFunds = value.Encrypt();
    //}

    public string SendingParty { get; set; }
    //public string SendingParty
    //{
    //    get => _sendingParty.Decrypt();
    //    set => _sendingParty = value.Encrypt();
    //}

    public string ReceivingParty { get; set; }
    //public string ReceivingParty
    //{
    //    get => _receivingParty.Decrypt();
    //    set => _receivingParty = value.Encrypt();
    //}

    public string ClientProfession { get; set; }
    //public string ClientProfession
    //{
    //    get => _clientProfession.Decrypt();
    //    set => _clientProfession = value.Encrypt();
    //}

    public string ClientIdentityNumber { get; set; }
    //public string ClientIdentityNumber
    //{
    //    get => _clientIdentityNumber.Decrypt();
    //    set => _clientIdentityNumber = value.Encrypt();
    //}

    public string ClientCountry { get; set; }
    //public string ClientCountry
    //{
    //    get => _clientCountry.Decrypt();
    //    set => _clientCountry = value.Encrypt();
    //}

    public string ClientCity { get; set; }
    //public string ClientCity
    //{
    //    get => _clientCity.Decrypt();
    //    set => _clientCity = value.Encrypt();
    //}

    public string ClientArea { get; set; }
    //public string ClientArea
    //{
    //    get => _clientArea.Decrypt();
    //    set => _clientArea = value.Encrypt();
    //}

    public string ClientNearestMilestone { get; set; }
    //public string ClientNearestMilestone
    //{
    //    get => _clientNearestMilestone.Decrypt();
    //    set => _clientNearestMilestone = value.Encrypt();
    //}

    public string BeneficiaryClientRelationship { get; set; }
    //public string BeneficiaryClientRelationship
    //{
    //    get => _beneficiaryClientRelationship.Decrypt();
    //    set => _beneficiaryClientRelationship = value.Encrypt();
    //}

    public string BeneficiaryActivity { get; set; }
    //public string BeneficiaryActivity
    //{
    //    get => _beneficiaryActivity.Decrypt();
    //    set => _beneficiaryActivity = value.Encrypt();
    //}

    public void SetAmount(decimal amount)
    {
        Amount = amount.ToString("0");
    }

    public void SetOperationType(OperationType operationType)
    {
        OperationType = operationType.ToString();
    }

    public void SetDate(DateTime dateTime)
    {
        Date = dateTime.ToString("dd/MM/yyyy hh:mm tt");
    }

    public void SetId(int id)
    {
        Id = id;
    }
}