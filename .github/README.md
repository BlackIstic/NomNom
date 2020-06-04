## MacMan

Našim projektom je 2D akčná hra, ktorá sa hratelnosťou podobá Pacmanovi, s tým že má inú tématiku a prvky ako pacman.
Hlavnou témou našej hry je satyricky boj zlého jedla proti dobrému

## Index

- [Prostredie](https://github.com/BlackIstic/NomNom#prostredie)
- [Skripty](https://github.com/BlackIstic/NomNom#skripty)
- [Prvky hry](https://github.com/BlackIstic/NomNom#prvky-hry)
  - [Ovladanie](https://github.com/BlackIstic/NomNom#ovladanie)
- [Instalacia](https://github.com/BlackIstic/NomNom#instalacia)
- [Tvorcovia](https://github.com/BlackIstic/NomNom#tvorcovia)
- [To-do](https://github.com/BlackIstic/NomNom#to-do)


## Prostredie

[[Back to top]](https://github.com/BlackIstic/NomNom#index)

Pri našej hre sme sa rozhodli pre vývoj v hernom engine unity.
Na implementáciu databázy sme použili SQLite. 
Pri grafike došlo k viacerým iteráciam ale na koniec sme sa rozhodli pre jednoduchú minimalistickú grafiku.

## Skripty
[[Back to top]](https://github.com/BlackIstic/NomNom#index)

Kód je rozdelený do 11 skriptov.
 Každý skript tvorí ucelenú časť, ktorá je pripojená prislúchajúcim objektom. 
 - Infopanel.cs obsluhuje funkcie panela na výpis bodov 
 - Tlacidlo.cs mení obrazovky podla účela tlačidla
 - Macman_pohyb.cs ovláda pohyb postavičky pomocou vstupov z klávesnice
 - Np.cs rieši správnu reakciu nepriatela na objekty v hre 
 - Bod.cs rieši pripočítavanie bodu
 - Specialny1.cs odstranuje nepriatela po získaní špecialneho predmetu
 - Specialny2.cs zrýchli hráča a dá mu možnosť prechádzať cez steny
 - PohybNP2.cs riesi pohyb nepriatela pomocou vodidiel
 - PohybNP3.cs riesi pohyb nepriatela pomocou súradníc hráča
 - Bodydodatabazy.cs rieši pridávanie záznamov po skončení hry do databázy 
 - Databaza.cs rieši čítanie s databázy.
 
## Prvky hry

[[Back to top]](https://github.com/BlackIstic/NomNom#index)

- Počet bodov ukazujúci ako si hráč vedie
- Tabuľka výsledkov najlepších pokusov hráča
- Špecialne predmety
 V hre sú momentálne tri tipy predmetov, 
 - zmrzlina ktorá predstavuje bonusové body, 
 - hamburger ktorý umožní zríchlený pohyb a pohyb cez steny, 
 - pohár cocacoly ktorý odstány nepriatelov na dobu 15 sekúnd. 
 V hre sú tieto predmety roztrúsené po mape a nachádzajú sa zväčša na nebezpečných miestach
- Nepriatelia s rôznym spôsobom pohybu

![](hra.gif)

## Ovladanie

[[Back to top]](https://github.com/BlackIstic/NomNom#index)

|              | Button              		 | Button  alternativa |
|--------------|-----------------------------|---------------------|
| pohyb vľavo  | <kbd>šipka vľavo</kbd>      | <kbd>a</kbd>        |
| pohyb vpravo | <kbd>šipka vpravo</kbd>     | <kbd>d</kbd>        |
| pohyb hore   | <kbd>šipka hore</kbd> 		 | <kbd>w</kbd>        |
| pohyb dole   | <kbd>šipka dole</kbd>     	 | <kbd>s</kbd>        |

## Instalacia

[[Back to top]](https://github.com/BlackIstic/NomNom#index)

 Naša hra je jednoduchá, nie je potrebné nič inštalovať, stačí spustiť exe súbor a hra sa zapne.
 Na úvod sa hráč dostane do jednoduchého menu po stlačení na novú hru ho presunie na obrazovku tutoriálu kde sú vysvetlené všetky základné informácie
 

### Tvorcovia

[[Back to top]](https://github.com/BlackIstic/NomNom#index)

- Dominik Tóbi

  - Bodydodatabazy.cs a Databaza.cs
  Mojou hlavnou úlohou v tíme bolo analyzovať a navrhnúť využívanie databázy v našej hre. Keďže v našej hre získava hráč body navrhol som využiť databázu na prácu s týmito údajmi v podobe štatistiky najlepších hráčov. Prvotným návrhom bolo využitie MySQL, no po analýze údajov, som došiel k poznaniu, že pre náš projekt by bolo jednoduchšie využitie SQLite. SQLite nie je databázový engine typu klient-server, čo vyhovuje pre náš projekt, keďže chceme mať našu hru nezávislú od internetového pripojenia a nemusíme následne riešiť zapisovanie viacerých hráčov súčasne do jednej databázy. Pre fungovanie našej databázy som musel stiahnuť pár súborov a to Mono.Data.Sqlite.dll, sqlite3.def a sqlite3.dll, ktoré som v našom projekte uložil do časti pluginov. Tieto súbory sú volne dostupné na internete. Pre prvotné vytvorenie databázy som použil program DBBrowserforSQLite. 
Pre prácu s databázou som sa rozhodol vytvoriť dva skripty a to Bodydodatabazy.cs, ktorý slúži na ukladanie súborov do databázy, a Databaza.cs, ktorý slúži na čítanie z databázy.
Script na zápis má dve funkcie a to zmenmeno, ktorá slúži na uloženie mena hráča, ktoré hráč zadá do textového boxu po ukončení hry, ktorý sa objaví pri výhre alebo prehre, a funkcie zápis, ktorá slúži na zápis týchto informácií do databázy. Funkcia zápis by mohla byť použitá ostatnými členmi tímu, ak by potrebovali uložiť údaje do databázy, s tým, že by potrebovali pozmeniť len jediný textový reťazec sqlQuery, v ktorom je napísaný sql príkaz. Čiže je potrebná len základná znalosť sql jazyka.    
Script Databaza.cs som použil pri práci so scénou score, kde som potreboval načítať a zobraziť informácie databázy. Keďže v hernom engine Unity nie je widget typu tabuľky, bolo nutné vyriešiť zobrazenie. V databáze je momentálne uložená jedna tabuľka, ktorá má dva stĺpce, a to meno a body, preto som sa to rozhodol vyriešiť jednoduchými textovými widgetmi. Na začiatku je tabuľka prázdna a po každej hre sa napĺňa novými údajmi, no stovky údajov by boli pre hráča zbytočné, preto som sa výpis rozhodol limitovať na maximálny počet desiatich zápisov s najlepšími výsledkami. Ako aj predchádzajúci script je použitie tohto skriptu ostatnými členmi tímu jednoduché a je potrebná len maličká úprava sql príkazu.  

  - PohybNP2.cs a PohybNP3.cs
  Nasledujúcou úlohou bolo vytvorenie viacerých skriptov pre pohyb nepriateľov. 
Pre prvý skript PohybNP2.cs som sa rozhodol implementovať pohyb nepriateľa pomocou vodidiel. Tento pohyb funguje tak, že na mape je súbor neviditeľných bodov, v ktorom sa nepriateľ pohybu podľa zadaného poradia, má teda predurčenú opakujúcu sa trasu. Práca s týmto skriptom je jednoduchá, keďže jediným obmedzením je veľkosť mapy a čas pre vytvorenie poradovníka navštívenia vodidiel. Pri druhom skripte som sa rozhodol implementovať pohyb pomocou získavania polohy hráča, a tým nabudiť v hráčovi pocit neustáleho potreby neustáleho pohybu. 	Obidva skripty by sú jednoduché na použitie a je možná ich kombinácia. Pre nepriateľa by na prvotný pohyb boli využité vodidlá a ako náhle by sa hráč priblížil na určitú vzdialenosť od nepriateľov, by nepriateľ využil druhú skript a riadil sa podľa polohy hráča. 

- Martina Brečková
- Akbota Kassym

### To-do

[[Back to top]](https://github.com/BlackIstic/NomNom#index)

- [x] Hlavne menu hry
- [x] 2D grafika pre prvky hry
- [x] Tabuľka skóre hráčov
- [ ] možnosť pozastavenia hry
- [ ] možnosť výberu začiatočného levela




