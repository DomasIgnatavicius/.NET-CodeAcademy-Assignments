

string asmensKodas;
string vardasPavarde;
int amzius;
DateTime gimimoData;
string lytis = "Nezinomas";


Console.WriteLine("Iveskite savo varda ir pavarde:");
vardasPavarde = Console.ReadLine();

// Ar punktas buvo uzpildytas
if (string.IsNullOrEmpty(vardasPavarde))
{
    Console.WriteLine("Punktas yra privalomas");
    Environment.Exit(1);
}


Console.WriteLine("Iveskite asmens koda: ");
asmensKodas = Console.ReadLine();

//Ar geras asmens kodo ilgis, ar jame tik skaiciai, ar nera null arba empty, ar prasideda teisingu skaiciumi
if (!asmensKodas.StartsWith("1") && !asmensKodas.StartsWith("2") && !asmensKodas.StartsWith("3") && !asmensKodas.StartsWith("4") && !asmensKodas.StartsWith("5") && !asmensKodas.StartsWith("6") )
{
    Console.WriteLine("Asmens kodo pirmas skaicius yra neteisingas");
    Environment.Exit(1);
}
if (string.IsNullOrEmpty(asmensKodas))
{
    Console.WriteLine("Punktas yra privalomas");
    Environment.Exit(1);
}
if (!long.TryParse(asmensKodas, out _))
{
    Console.WriteLine("Ivestas neteisingas asmens kodas, jame gali buti tik skaiciai");
    Environment.Exit(1);
}
if (asmensKodas.Length != 11)
{
    Console.WriteLine("Ivestas neteisingas asmens kodas, skaitmenu per daug arba per mazai");
    Environment.Exit(1);
}




Console.WriteLine("Iveskite amziu, sveikuoju skaiciumi. Punktas neprivalomas");
string amziusString = Console.ReadLine();

// Ar amzius ivestas geru formatu, ar amzius nera null arba empty
if(!string.IsNullOrEmpty(amziusString))
{
    bool isAmziusNumeric = int.TryParse(amziusString, out amzius);
    if(!isAmziusNumeric) 
    {
        Console.WriteLine("Bandykite dar karta ir iveskite amziu sveikuoju skaiciumi skaiciumi");
        Environment.Exit(1);
    }
}
else
{
    amzius = -1;
}



Console.WriteLine("Iveskite gimimo data(formato pvz. 2001-01-01). Punktas neprivalomas");
string gimimoDataString = Console.ReadLine();

//Ar data nera tucia arba null, ar ivesta data yra valid
if (!string.IsNullOrEmpty(gimimoDataString))
{
    bool isGimimoDataValid = DateTime.TryParse(gimimoDataString, out gimimoData);
    if (!isGimimoDataValid)
    {
        Console.WriteLine("Bandykite dar karta ir iveskite gimimo data teisingu formatu");
        Environment.Exit(1);
    }
}
else
{
    gimimoData = DateTime.MinValue;
}

//Lyties nustatymas
if (asmensKodas.StartsWith("1") || asmensKodas.StartsWith("3") || asmensKodas.StartsWith("5"))
{
    lytis = "Vyras";
}
if(asmensKodas.StartsWith("2") || asmensKodas.StartsWith("4") || asmensKodas.StartsWith("6"))
{
    lytis = "Moteris";
}


//Patikimumo rodiklio nustatymas

string patikimumoRodiklis = "";
string gimimoDataPagalAsmensKodaString = "";
DateTime gimimoDataPagalAsmensKoda = DateTime.MinValue;
int paskaiciuotasAmzius;

if (amzius == -1 && gimimoData == DateTime.MinValue) // neivesta nei data nei amzius
{
    patikimumoRodiklis = "Patikimumui truksta duomenu";
}

else if (amzius == -1 && gimimoData != DateTime.MinValue)// ivesta data, neivestas amzius
{
    
    string gimimoDiena = $"{asmensKodas[5]}{asmensKodas[6]}";
    string gimimoMenuo = $"{asmensKodas[3]}{asmensKodas[4]}";
    string gimimoMetai = "";
    if (asmensKodas.StartsWith("1") || asmensKodas.StartsWith("2"))
    {
         gimimoMetai = $"18{asmensKodas[1]}{asmensKodas[2]}";
    }
    else if (asmensKodas.StartsWith("3") || asmensKodas.StartsWith("4"))
    {
         gimimoMetai = $"19{asmensKodas[1]}{asmensKodas[2]}";
    }
    else if (asmensKodas.StartsWith("5") || asmensKodas.StartsWith("6"))
    {
         gimimoMetai = $"20{asmensKodas[1]}{asmensKodas[2]}";
    }
    gimimoDataPagalAsmensKodaString = $"{gimimoMetai}-{gimimoMenuo}-{gimimoDiena}";
    gimimoDataPagalAsmensKoda = DateTime.Parse(gimimoDataPagalAsmensKodaString);
    if (gimimoData == gimimoDataPagalAsmensKoda)
    {
        patikimumoRodiklis = "Amzius patikimas";
    }
    else
        patikimumoRodiklis = "Amzius pameluotas";
}

else if(amzius != -1 && gimimoData == DateTime.MinValue) // ivestas amzius, neivesta data
{
    DateTime dabartis = DateTime.Now;
    string gimimoMetai = "";
    string gimimoDiena = $"{asmensKodas[5]}{asmensKodas[6]}";
    string gimimoMenuo = $"{asmensKodas[3]}{asmensKodas[4]}";
    if (asmensKodas.StartsWith("1") || asmensKodas.StartsWith("2"))
    {
        gimimoMetai = $"18{asmensKodas[1]}{asmensKodas[2]}";
    }
    else if (asmensKodas.StartsWith("3") || asmensKodas.StartsWith("4"))
    {
        gimimoMetai = $"19{asmensKodas[1]}{asmensKodas[2]}";
    }
    else if (asmensKodas.StartsWith("5") || asmensKodas.StartsWith("6"))
    {
        gimimoMetai = $"20{asmensKodas[1]}{asmensKodas[2]}";
    }
    gimimoDataPagalAsmensKodaString = $"{gimimoMetai}-{gimimoMenuo}-{gimimoDiena}";
    gimimoDataPagalAsmensKoda = DateTime.Parse(gimimoDataPagalAsmensKodaString);
    DateTime gimimoMataidDate = dabartis.AddYears(-amzius);
    Console.WriteLine(gimimoMataidDate);
    if(gimimoMataidDate.Year == gimimoDataPagalAsmensKoda.Year) // Jeigu jums 2022 turi sueiti 22, bet kol kas esate 21, programa paskaicuioja kad jus turetumet but gimes 2001 ir meta amzius pameluotas, nes neatsizvelgia i menesi ir diena
    {
        patikimumoRodiklis = "Amzius patikimas";
    }
    else
    {
        patikimumoRodiklis = "Amzius pameluotas";
    }
}

else if(amzius != -1 && gimimoData != DateTime.MinValue) // ivestas ir amzius ir data
{
    DateTime dabartis = DateTime.Now;
    string gimimoMetai = "";
    string gimimoDiena = $"{asmensKodas[5]}{asmensKodas[6]}";
    string gimimoMenuo = $"{asmensKodas[3]}{asmensKodas[4]}";
    if (asmensKodas.StartsWith("1") || asmensKodas.StartsWith("2"))
    {
        gimimoMetai = $"18{asmensKodas[1]}{asmensKodas[2]}";
    }
    else if (asmensKodas.StartsWith("3") || asmensKodas.StartsWith("4"))
    {
        gimimoMetai = $"19{asmensKodas[1]}{asmensKodas[2]}";
    }
    else if (asmensKodas.StartsWith("5") || asmensKodas.StartsWith("6"))
    {
        gimimoMetai = $"20{asmensKodas[1]}{asmensKodas[2]}";
    }
    gimimoDataPagalAsmensKodaString = $"{gimimoMetai}-{gimimoMenuo}-{gimimoDiena}";
    gimimoDataPagalAsmensKoda = DateTime.Parse(gimimoDataPagalAsmensKodaString);
    DateTime gimimoMataidDate = dabartis.AddYears(-amzius);
    if (gimimoMataidDate.Year == gimimoDataPagalAsmensKoda.Year && gimimoData == gimimoDataPagalAsmensKoda) // Jeigu jums 2022 turi sueiti 22, bet kol kas esate 21, programa paskaicuioja kad jus turetumet but gimes 2001 ir meta amzius pameluotas, nes neatsizvelgia i menesi ir diena
    {
        patikimumoRodiklis = "Amzius tikras";
    }
    else if(gimimoMataidDate.Year == gimimoDataPagalAsmensKoda.Year || gimimoData == gimimoDataPagalAsmensKoda)
    {
        patikimumoRodiklis = "Amzius nepatikimas";
    }
    else
    {
        patikimumoRodiklis = "Amzius pameluotas";
    }
}

// asmens kodo tikrinimas

double S = char.GetNumericValue(asmensKodas[0]) * 1 + char.GetNumericValue(asmensKodas[1]) * 2 + char.GetNumericValue(asmensKodas[2]) * 3 + char.GetNumericValue(asmensKodas[3]) * 4 + char.GetNumericValue(asmensKodas[4]) * 5 + char.GetNumericValue(asmensKodas[5]) * 6 + char.GetNumericValue(asmensKodas[6]) * 7 + char.GetNumericValue(asmensKodas[7]) * 8 + char.GetNumericValue(asmensKodas[8]) * 9 + char.GetNumericValue(asmensKodas[9]) * 1;
double liekana = S % 11;
double K;
if (liekana != 10)
{
    K = liekana;
}
else
{
    S = char.GetNumericValue(asmensKodas[0]) * 3 + char.GetNumericValue(asmensKodas[1]) * 4 + char.GetNumericValue(asmensKodas[2]) * 5 + char.GetNumericValue(asmensKodas[3]) * 6 + char.GetNumericValue(asmensKodas[4]) * 7 + char.GetNumericValue(asmensKodas[5]) * 8 + char.GetNumericValue(asmensKodas[6]) * 9 + char.GetNumericValue(asmensKodas[7]) * 1 + char.GetNumericValue(asmensKodas[8]) * 2 + char.GetNumericValue(asmensKodas[9]) * 3;
    liekana = S % 11;
    if (liekana != 10)
    {
        K = liekana;
    }
    else
        K = 0;
}


// -------------ISVEDIMAS------------


Console.WriteLine("################################################################################################");
Console.WriteLine("################################################################################################");
Console.WriteLine("################################## ATASKAITA APIE ASMENI #######################################");
Console.WriteLine($"##################################       {DateTime.Now.ToString("yyyy-MM-dd")}      #######################################");
Console.WriteLine("################################################################################################");
Console.WriteLine("################################################################################################");
Console.WriteLine("################################################################################################");
Console.WriteLine($"##{String.Format("{0,44}", "Vardas, pavarde")} ## {String.Format("{0,-44}", vardasPavarde)}##");
Console.WriteLine("################################################################################################");
Console.WriteLine("################################################################################################");
Console.WriteLine($"##{String.Format("{0,44}", "Lytis")} ## {String.Format("{0,-44}", lytis)}##");
Console.WriteLine("################################################################################################");
Console.WriteLine("################################################################################################");
Console.WriteLine($"##{String.Format("{0,44}", "Asmens kodas")} ## {String.Format("{0,-44}", Convert.ToString(K) == Convert.ToString(asmensKodas[10]) ? asmensKodas : "Kodas neteisingas")}##");
Console.WriteLine("################################################################################################");
Console.WriteLine("################################################################################################");
Console.WriteLine($"##{String.Format("{0,44}", "Amziaus patikimumas")} ## {String.Format("{0,-44}", Convert.ToString(K) == Convert.ToString(asmensKodas[10]) ? patikimumoRodiklis : "Patikimumui truksta duomenu")}##");
Console.WriteLine("################################################################################################");
Console.WriteLine("################################################################################################");
Console.WriteLine("################################################################################################");