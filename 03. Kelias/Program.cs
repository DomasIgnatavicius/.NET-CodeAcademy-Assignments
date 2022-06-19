
//PARAŠYTI PROGRAMĄ KURI PRAŠO ĮVESTI ATSTUMĄ (KILOMENTRAIS) TARP TAŠKŲ A IR B IR
//DVIEJŲ TRANSPORTO PRIEMONIŲ GREITĮ (KM/H).
//VIENA TRANSPORTO PRIEMONĖS PRADEDA VAŽIUOTI IŠ A, KITA IŠ B.STARTUOJA VIENU METU.

Console.WriteLine("Iveskite atstuma(km) tarp A ir B");
double atstumas = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Iveskite pirmos transporto priemones greiti, kuri keliaus is tasko A: ");
double greitisA = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Iveskite antros transporto priemones greiti, kuri keliaus is tasko B: ");
double greitisB = Convert.ToDouble(Console.ReadLine());

Console.WriteLine();


// -PASKAIČIUOTI ATSTUMĄ NUO A IKI VIETOS KURIOJE TRASPORTO PRIEMONĖS SUTITIKS METRAIS.
// -PASKAIČIUOTI LAIKĄ KADA TRASPORTO PRIEMONĖS SUSITIKS SEKUNDĖMIS.

// Pagal proporcija apsiskaiciavau laika, kada transporto priemones susitiks, tada ta laika padauginau is greicioA
// ir gavau kokiu atstumu susitiko nuo tasko A


//PVZ: atstumas: 40, greitisA: 32km/h, greitisB: 64km/h

// kartu per valanda nuvazious 240% viso kelio(96km)
double kiekProcKelioNuvaziavoKartuSudejus = (greitisA + greitisB) * 100 / atstumas;

// Kad nuvaziuotu 100% kelio reikes 0.4166666666666667h
double kiekValanduReikesVisamKeliuiNuvaziuoti = 100 / kiekProcKelioNuvaziavoKartuSudejus;

// automobilis A per 0.4166666666666667h nuvaziuos, 13.473684210526315km, tuo tarpu automobilis B nuvaziuos 26.666666666666668
double susitikimoAtstumasRelativeToA = greitisA * kiekValanduReikesVisamKeliuiNuvaziuoti;
double susitikimoAtstumasRelativeToB = greitisB * kiekValanduReikesVisamKeliuiNuvaziuoti;
// Console.WriteLine(susitikimoAtstumasRelativeToB + susitikimoAtstumasRelativeToA == atstumas); TRUE

double susitikimoAtstumasRelativeToAMetrais = susitikimoAtstumasRelativeToA * 1000;
double kadaSusitiksSekundemis = kiekValanduReikesVisamKeliuiNuvaziuoti * (double)3600;

Console.WriteLine($"Susitikimo atstumas nuo tasko A: {Math.Round(susitikimoAtstumasRelativeToAMetrais, 2)}km");
Console.WriteLine($"Laikas po kurio susitiks transporto priemones: {kadaSusitiksSekundemis}s");

Console.WriteLine();

// - PASKAIČIUOTI LAIKĄ, KADA TRASPORTUO PRIEMONĖS PASIEKS GALIUTINIUS TAŠKUS MINUTĖMIS.

double pasieksGalutiniTaskaAutomobilisAMinutemis = (atstumas / greitisA) * 60;
double pasieksGalutiniTaskaAutomobilisBMinutemis = (atstumas / greitisB) * 60;

Console.WriteLine($"Transporto priemone A galutini tiksla pasieks per {pasieksGalutiniTaskaAutomobilisAMinutemis} min");
Console.WriteLine($"Transporto priemone B galutini tiksla pasieks per {pasieksGalutiniTaskaAutomobilisBMinutemis} min");
Console.WriteLine();

//- PASKAIČIUOTI KIEK GRAMŲ CO2 IŠSKYRĖ ABI TRASPORTO PIEMONĖS KARTU SUDĖJUS. CO2 NORMA YRA 95 g/km.

double CO2isskirimas = atstumas * 2 * 95;

Console.WriteLine($"Vaziuodamos transporto priemones kartu isskyre {CO2isskirimas} g CO2");

Console.WriteLine();

/*-GRAFIŠKAI PAVAIZDUOTI KELIĄ NUO A IKI B SUSKIRSTYTĄ Į 20 LYGIŲ SEGMENTŲ (TARKIME ĮVESTAS ATSTUMAS YRA 100KM, TUOMENT TURĖSIME 20 SEGMENTU PO 5KM).  
    A) PARODYTI VISO KELIO ILGĮ KM
    B) PARODYTI SEGMENTO ILGĮ KM
    C) PARODYTI KURIAME SEGMENTE TRASPORTO PREMONĖS SUTIKS IR ATSTUMĄ IKI SUSITIKIMO (TAŠKAS V)
    D) PARODYTI ABIEJŲ TRANSPORTO PRIEMONIŲ VAŽIAVIMO TRUKMĘ
    if naudoti negalima, ternary operator (?) naudoti negalima, ciklų naudoti negalima*/

int dvidesimtadalis = Convert.ToInt32(atstumas) / 20;
int segmentoIlgis = Convert.ToInt32(susitikimoAtstumasRelativeToA);

Console.WriteLine($"   {dvidesimtadalis}km  {dvidesimtadalis}km  {dvidesimtadalis}km  {dvidesimtadalis}km  {dvidesimtadalis}km  {dvidesimtadalis}km  {dvidesimtadalis}km  {dvidesimtadalis}km  {dvidesimtadalis}km  {dvidesimtadalis}km  {dvidesimtadalis}km  {dvidesimtadalis}km  {dvidesimtadalis}km  {dvidesimtadalis}km  {dvidesimtadalis}km  {dvidesimtadalis}km  {dvidesimtadalis}km  {dvidesimtadalis}km  {dvidesimtadalis}km  {dvidesimtadalis}km");
Console.WriteLine($"A|____|____|____|____|____|____|____|____|____|____|____|____|____|____|____|____|____|____|____|____|");
Console.WriteLine($"|-----------------------------------------{atstumas}km-------------------------------------------------------|");
