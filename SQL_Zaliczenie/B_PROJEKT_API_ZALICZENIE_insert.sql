----Baza danych--->  ProjektOR


--STATUS---------------------------------------------------------------------------------------------------------------
INSERT INTO Status (Nazwa)
VALUES ('Zatwierdzony'),
		('Odrzucony'),
		('Odes³any bez zatwierdzenia'),
		('Wycofany'),
		('Opinia'),
		('Oczekuj¹cy')

--TYP---------------------------------------------------------------------------------------------------------------
INSERT INTO Typ (Typ)
VALUES ('Sta³a'),
		('Czasowa'),
		('OS'),
		('Opinia')


---ZARZADCA DROGI ---------------------------------------------------------------------------------------------------------------
INSERT INTO Zarzadca_drogi (Nazwa)
VALUES ('Zarz¹d Dróg Miejskich'),
('Zarz¹d Terenów Publicznych'),
('Zarz¹d Transportu Miejskiego'),
('Zarz¹d Zieleni'),
('Bemowo'),
('Bia³o³êka'),
('Bielany'),
('Mokotów'),
('Ochota'),
('Praga-Po³udnie'),
('Praga-Pó³noc'),
('Rembertów'),
('Targówek'),
('Ursus'),
('Ursynów'),
('Wawer'),
('Weso³a'),
('Wilanów'),
('W³ochy'),
('Wola'),
('¯oliborz')


--WYDZIAL---------------------------------------------------------------------------------------------------------------
INSERT INTO Wydzial (Nazwa, Symbol)
VALUES ('Wydzia³ Organizacji Ruchu','ZR-OR'),
		('Wydzia³ Sterowania Ruchem','ZR-SR'),
		('Wydzia³ Ewidencji i Rozwoju','ZR-ER'),
		('Samodzielne Wieloosobowe Stanowisko Pracy ds Organizacyjnych','ZR-SE'),
		('Samodzielne Wieloosobowe Stanowisko Pracy ds. Analiz Ruchu','ZR-AN'),
		('Samodzielne Jednoosobowe Stanowisko Pracy ds. Obs³ugi Prawnej','ZR-RP')


--STANOWISKO---------------------------------------------------------------------------------------------------------------
INSERT INTO Stanowisko(nazwa)
VALUES ('Podinspektor'),
		('Specjalista'),
		('Inspektor'),
		('G³ówny Specjalista'),
		('Kierownik'),
		('Z-ca Naczelnika'),
		('Naczelnik'),
		('Z-ca Dyrektora'),
		('Dyrektor')


--OSOBA PRACA---------------------------------------------------------------------------------------------------------------
INSERT INTO Osoba_praca (Imie, Nazwisko, Data_zatrudnienia, Symbol_w_systemie, Wydzial_id, Stanowisko_id)
				VALUES ('Jan', 'Kowalski', '2022-04-15', 'JAK', 1,4 ),
					   ('Pawe³', 'Nowak', '2021-04-15', 'PAN', 2,3 )


--PROJEKT OR---------------------------------------------------------------------------------------------------------------
INSERT INTO Projekt_OR (
    Numer_projektu, 
	Rok, 
	Data_wplywu, 
	Data_zatwierdzenia_od, 
	Data_zatwierdzenia_do, 
	Uwagi,  
	Typ_id, 
	id_Osoba_praca_prowadzacy, 
	id_Osoba_praca_zatwierdzajacy, 
	Status_id,
	Email)
VALUES (300, 2023,'2023-03-12', '2023-04-15', '2024-04-15', 'brak uwag',1, 2,2,1, 'asd@wp.pl')

