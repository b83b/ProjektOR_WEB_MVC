----Baza danych--->  ProjektOR


--STATUS---------------------------------------------------------------------------------------------------------------
INSERT INTO Status (Nazwa)
VALUES ('Zatwierdzony'),
		('Odrzucony'),
		('Odes�any bez zatwierdzenia'),
		('Wycofany'),
		('Opinia'),
		('Oczekuj�cy')

--TYP---------------------------------------------------------------------------------------------------------------
INSERT INTO Typ (Typ)
VALUES ('Sta�a'),
		('Czasowa'),
		('OS'),
		('Opinia')


---ZARZADCA DROGI ---------------------------------------------------------------------------------------------------------------
INSERT INTO Zarzadca_drogi (Nazwa)
VALUES ('Zarz�d Dr�g Miejskich'),
('Zarz�d Teren�w Publicznych'),
('Zarz�d Transportu Miejskiego'),
('Zarz�d Zieleni'),
('Bemowo'),
('Bia�o��ka'),
('Bielany'),
('Mokot�w'),
('Ochota'),
('Praga-Po�udnie'),
('Praga-P�noc'),
('Rembert�w'),
('Targ�wek'),
('Ursus'),
('Ursyn�w'),
('Wawer'),
('Weso�a'),
('Wilan�w'),
('W�ochy'),
('Wola'),
('�oliborz')


--WYDZIAL---------------------------------------------------------------------------------------------------------------
INSERT INTO Wydzial (Nazwa, Symbol)
VALUES ('Wydzia� Organizacji Ruchu','ZR-OR'),
		('Wydzia� Sterowania Ruchem','ZR-SR'),
		('Wydzia� Ewidencji i Rozwoju','ZR-ER'),
		('Samodzielne Wieloosobowe Stanowisko Pracy ds Organizacyjnych','ZR-SE'),
		('Samodzielne Wieloosobowe Stanowisko Pracy ds. Analiz Ruchu','ZR-AN'),
		('Samodzielne Jednoosobowe Stanowisko Pracy ds. Obs�ugi Prawnej','ZR-RP')


--STANOWISKO---------------------------------------------------------------------------------------------------------------
INSERT INTO Stanowisko(nazwa)
VALUES ('Podinspektor'),
		('Specjalista'),
		('Inspektor'),
		('G��wny Specjalista'),
		('Kierownik'),
		('Z-ca Naczelnika'),
		('Naczelnik'),
		('Z-ca Dyrektora'),
		('Dyrektor')


--OSOBA PRACA---------------------------------------------------------------------------------------------------------------
INSERT INTO Osoba_praca (Imie, Nazwisko, Data_zatrudnienia, Symbol_w_systemie, Wydzial_id, Stanowisko_id)
				VALUES ('Jan', 'Kowalski', '2022-04-15', 'JAK', 1,4 ),
					   ('Pawe�', 'Nowak', '2021-04-15', 'PAN', 2,3 )


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

