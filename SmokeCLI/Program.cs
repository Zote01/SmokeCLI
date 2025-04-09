using SmokeCLI;

List<Resident> residents = new();

using (StreamReader sr = new(@"../../../src/smoking.txt", System.Text.Encoding.UTF8))
{
    sr.ReadLine();
    while (!sr.EndOfStream)
    {
        residents.Add(new Resident(sr.ReadLine()));
    }
}

Console.WriteLine("5. feladat");
var f05 = residents.Take(10).ToList();
foreach (var item in f05)
{
    Console.WriteLine(item);
}

var f06 = residents.Where(x => x.Smoke == "Yes" && x.Nationality.NationalityName == "British" && x.MaritalStatus == "Married" && x.Gender == "Male" && x.GrossIncome != "Unknown" && x.GrossIncome != "Under 2600" && x.GrossIncome != "Above 36400" && x.GrossIncome != "Refused");

if (f06.Any())
{
    List<int> maxJovedelem = new();
    foreach (var item in f06)
    {
        if (int.Parse(item.GrossIncome.Split(" to ")[0]) > int.Parse(item.GrossIncome.Split(" to ")[1])){
            maxJovedelem.Add(int.Parse(item.GrossIncome.Split(" to ")[0]));
        }
        else
        {
            maxJovedelem.Add(int.Parse(item.GrossIncome.Split(" to ")[1]));
        }
    }

    Console.WriteLine($"A leszűrt lakosok maximális jövedelmének maximuma: {maxJovedelem.Max()} angol font.\n");
}
foreach (var item in f06)
{
    Console.WriteLine(item);
}

Console.WriteLine("7. feladat: Fájlba írás");
using (StreamWriter sw = new(@"../../../src/wales.txt"))
{
    var f07 = residents.Where(x => x.Age >= 25 && x.Age <= 30 && x.Region == "Wales" && x.Smoke == "No").OrderByDescending(x => x.Age);
    foreach (var item in f07)
    {
        sw.WriteLine($"{item.Age} {item.Gender} {item.Qualification}"); 
    }
}