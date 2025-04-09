using SmokeCLI;

internal class Resident
{
    private static int szamID = 1;
    public int Age { get; set; }
    public string AmtWeekdays { get; set; }
    public string AmtWeekends { get; set; }
    public Ethnicity Ethnicity { get; set; }
    public string Gender { get; set; }
    public string GrossIncome { get; set; }
    public string Qualification { get; set; }
    public string MaritalStatus { get; set; }
    public Nationality Nationality { get; set; }
    public string Region { get; set; }
    public string Smoke { get; set; }
    public string Type { get; set; }
    public int ResidentId { get; set; }

    public Resident(string sor)
    {
        var v = sor.Split(';');
        Age = int.Parse(v[0]);
        AmtWeekdays = v[1];
        AmtWeekends = v[2];
        Ethnicity = new Ethnicity(int.Parse(v[3]), v[4]);
        Gender = v[5];
        GrossIncome = v[6];
        Qualification = v[7];
        MaritalStatus = v[8];
        Nationality = new Nationality(int.Parse(v[9]), v[10]);
        Region = v[11];
        Smoke = v[12];
        Type = v[13];

        ResidentId = szamID++;
    }

    public double Average()
    {
        if (AmtWeekdays == "NA" || AmtWeekends == "NA")
        {
            return 0;
            //return double.NaN;
        }
        else
        {
            return Math.Round((double.Parse(AmtWeekdays) + double.Parse(AmtWeekends)) / 7.0, 2);
        }
    }

    public override string ToString()
    {
        string AtlagCigi = String.Empty;
        //string AtlagCigi = double.IsNaN(Average()) ? "NaN" : Average().ToString();

        if (Average() == 0)
        {
            AtlagCigi = "NaN";
        }
        else
        {
            AtlagCigi = Average().ToString();
        }

        return $"\tResident ID: {ResidentId}\n" +
                $"\tAge: {Age}\n" +
                $"\tAmtWeekdays: {AmtWeekdays}\n" +
                $"\tAmtWeekends: {AmtWeekends}\n" +
                $"\tEthnicity: {Ethnicity.EthniName}\n" +
                $"\tGender: {Gender}\n" +
                $"\tGross Income: {GrossIncome}\n" +
                $"\tQualification: {Qualification}\n" +
                $"\tMarital Status: {MaritalStatus}\n" +
                $"\tNationality: {Nationality.NationalityName}\n" +
                $"\tRegion: {Region}\n" +
                $"\tSmoke: {Smoke}\n" +
                $"\tType: {Type}\n" +
                $"\tAverage: {AtlagCigi}\n";
    }
}
