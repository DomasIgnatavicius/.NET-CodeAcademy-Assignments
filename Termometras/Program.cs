
// 1. Paprašykite naudotojo įvesti 1 skaičių - temperatūrą pagal Celsijų.

Console.WriteLine("Iveskite temperatura(celsijus): ");
double tempCelsijus = double.Parse(Console.ReadLine());

// Temperatura pagal farenheita ir kelvina

double tempFarenheitais = Math.Round(tempCelsijus * 1.8 + 32, 2);
Console.WriteLine($"Farenheitais: {tempFarenheitais}F");

double tempKelvinais = Math.Round( tempCelsijus + 273.15, 2);
Console.WriteLine($"Kelvinais: {tempKelvinais}K");

Console.WriteLine();

// - Gautą temperatūrą pagal farenheitą perskaičiuokite į Celsijų
// ir patikrinkite ar sutampa su įvestu skaičių (išveskite true/false)
// - Gautą temperatūrą pagal kelviną perskaičiuokite į celsijų
// ir patikrinkite ar sutampa su įvestu skaičiu (išveskite true/false)
// - Paskaičiuotą temperatūrą pagal farenheita peverskite į kelviną
//   ir patikrinkite ar sutampa su ankstesniais skaičiavimais (išveskite true/false)

double FtoC = Math.Round( (tempFarenheitais - 32) / 1.8, 2); // farenheitai i celsijus
Console.WriteLine($"{tempFarenheitais}F yra {FtoC}C {tempCelsijus == FtoC}");

double KtoC =  Math.Round(tempKelvinais - 273.15, 2); // Kelvinai i celsijus
Console.WriteLine($"{tempKelvinais}K yra {KtoC}C {tempCelsijus == KtoC}");

double FtoK = Math.Round((tempFarenheitais + 459.67) * 5/9, 2); // Fenrenheitai i kelvinus
Console.WriteLine($"{tempFarenheitais}F yra {FtoK}K {tempKelvinais == FtoK}");

Console.WriteLine();

//- Nupieškite termometrą pagal Celsijų

// a) Atvaizduokite skalę, sugraduotą kas 5 laipsnius C priklausomai nuo įvestos temperatūros pridedant
// ir atimant 40 laipsnių (tarkime įvesta buvo 10, tuomet skalė bus nuo -30 iki +50)

int virsausAmpliture = Convert.ToInt32(tempCelsijus) + 40;
int apaciosAmplitude = Convert.ToInt32(tempCelsijus) - 40;
Console.WriteLine(virsausAmpliture);
Console.WriteLine(apaciosAmplitude);

Console.WriteLine();

Console.WriteLine("|-------------------|");
Console.WriteLine("|   ^C         ^F");

Console.WriteLine($"| {tempCelsijus+40,4} - | | - {Math.Round(tempCelsijus+40) * 1.8 + 32, -4} |");
Console.WriteLine($"| {tempCelsijus+35,4} - | | - {convertCtoF(tempCelsijus + 35),-4} |");
Console.WriteLine($"| {tempCelsijus+30,4} - | | - {convertCtoF(tempCelsijus + 30),-4} |");
Console.WriteLine($"| {tempCelsijus+25,4} - | | - {convertCtoF(tempCelsijus + 25),-4} |");
Console.WriteLine($"| {tempCelsijus+20,4} - | | - {convertCtoF(tempCelsijus + 20),-4} |");
Console.WriteLine($"| {tempCelsijus+15,4} - | | - {convertCtoF(tempCelsijus + 15),-4} |");
Console.WriteLine($"| {tempCelsijus+10,4} - | | - {convertCtoF(tempCelsijus + 10),-4} |");
Console.WriteLine($"| {tempCelsijus+5,4} - | | - {convertCtoF(tempCelsijus + 5),-4} |");
Console.WriteLine($"| {tempCelsijus,4} - |#| - {convertCtoF(tempCelsijus),-4} |"); // vidurio taskas
Console.WriteLine($"| {tempCelsijus-5,4} - |#| - {convertCtoF(tempCelsijus - 5),-4} |");
Console.WriteLine($"| {tempCelsijus-10,4} - |#| - {convertCtoF(tempCelsijus - 10),-4} |");
Console.WriteLine($"| {tempCelsijus-15,4} - |#| - {convertCtoF(tempCelsijus - 15),-4} |");
Console.WriteLine($"| {tempCelsijus-20,4} - |#| - {convertCtoF(tempCelsijus - 20),-4} |");
Console.WriteLine($"| {tempCelsijus-25,4} - |#| - {convertCtoF(tempCelsijus - 25),-4} |");
Console.WriteLine($"| {tempCelsijus-30,4} - |#| - {convertCtoF(tempCelsijus - 30),-4} |");
Console.WriteLine($"| {tempCelsijus-35,4} - |#| - {convertCtoF(tempCelsijus - 35),-4} |");
Console.WriteLine($"| {tempCelsijus-40,4} - |#| - {convertCtoF(tempCelsijus - 40),-4} |");
Console.WriteLine("|-------------------|");



double convertCtoF(double C)
{
    double converted = Math.Round(C * 1.8 + 32, 2);
    return converted;
}