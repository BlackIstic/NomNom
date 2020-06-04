## MacMan

Našim projektom je 2D akčná hra, ktorá sa hratelnosťou podobá Pacmanovi, s tým že má inú tématiku a prvky ako pacman.
Hlavnou témou našej hry je satyricky boj zlého jedla proti dobrému

## Index

- [Prostredie](https://github.com/BlackIstic/NomNom#prostredie)
- [Skripty](https://github.com/BlackIstic/NomNom#skripty)
- [Prvky hry](https://github.com/BlackIstic/NomNom#prvky-hry)
  - [Ovladanie](https://github.com/BlackIstic/NomNom#ovladanie)
- [Installation](https://github.com/BlackIstic/NomNom#installation)
- [Tvorcovia](https://github.com/BlackIstic/NomNom#tvorcovia)
- [To-do](https://github.com/BlackIstic/NomNom#to-do)


## Prostredie

[[Back to top]](https://github.com/BlackIstic/NomNom#index)

Pri našej hre sme sa rozhodli pre vývoj v hernom engine unity.
Na implementáciu databázy sme použili SQLite. 
Pri grafike došlo k viacerým iteráciam ale na koniec sme sa rozhodli pre jednoduchú minimalistickú grafiku.

## Skripty

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


## Ovladanie

[[Back to top]](https://github.com/BlackIstic/NomNom#index)

|              | Button              		 | Button  alternativa |
|--------------|-----------------------------|---------------------|
| pohyb vľavo  | <kbd>šipka vľavo</kbd>      | <kbd>a</kbd>        |
| pohyb vpravo | <kbd>šipka vpravo</kbd>     | <kbd>d</kbd>        |
| pohyb hore   | <kbd>šipka hore</kbd> 		 | <kbd>w</kbd>        |
| pohyb dole   | <kbd>šipka dole</kbd>     	 | <kbd>s</kbd>        |

## Installation

[[Back to top]](https://github.com/BlackIstic/NomNom#index)

 Naša hra je jednoduchá, nie je potrebné nič inštalovať, stačí spustiť exe súbor a hra sa zapne.
 Na úvod sa hráč dostane do jednoduchého menu po stlačení na novú hru ho presunie na obrazovku tutoriálu kde sú vysvetlené všetky základné informácie
 

### Tvorcovia

[[Back to top]](https://github.com/BlackIstic/NomNom#index)

- Dominik Tóbi
- Martina Brečková
- Akbota Kassym

### To-do

[[Back to top]](https://github.com/BlackIstic/NomNom#index)

- [x] Hlavne menu hry
- [x] 2D grafika pre prvky hry
- [x] Tabuľka skóre hráčov
- [ ] možnosť pozastavenia hry
- [ ] možnosť výberu začiatočného levela




