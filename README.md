# Neat Reads

__DOKUMANTACIJA__

>Stevan Zubović 33/18

>Akademija tehničko-umetničkih strukovnih studija Beograd odsek visoka škola za informacione i komunikacione tehnologije

__Sadržaj__

1. Tema projekta
2. Funkcionalnosti projekta
3. Opis
4. Baza podataka

Neat Reads

1. Tema Projekta :

 Projekat predstavlja sistem za agregaciju knjiga i platformu na kojoj se mogu ostaviti utisci o njima.


2. Funkcionalnosti

* Registracija, login

* Crud operacije nad svim entitetima

* Prava pristupa operacijama na nivou korisnika

* Mogućnost upload-a fajla

* Serverska validacija i izveštavanje o greškama

* Logovanje svake aktivnosi na aplikaciji
---
 &nbsp;

3. Opis 

Svi korisnici imaju mogućnost registracije a registrovani mogućnost logovanja.

Za neautentifikovane korisnike postoje mogućnosti pretrage knjiga, njihovih autora i utisaka 

drugih korisnika aplikacije. Korisnici sa odgovarajućim privilegijama mogu postavljati svoje   utiske.

Korisnik "admin1" ima sva prava u aplikaciji dok korisnik "user" ima samo prava pretrage i 

postavljanja utisaka. admin1 password: admin12345, user password: user12345.

4. Baza podataka:
 
 ![Baza podataka](https://github.com/stevanzubovic/asp-api/blob/main/database_diagram.jpg)

