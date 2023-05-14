-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2023-05-12 09:58:38.897
----Baza danych--->  ProjektOR
-- tables
-- Table: Osoba_praca
CREATE TABLE Osoba_praca (
    id int  NOT NULL IDENTITY,
    Imie varchar(20)  NOT NULL,
    Nazwisko varchar(20)  NOT NULL,
    Data_zatrudnienia date  NOT NULL,
    Data_odejscia_z_pracy date  NULL,
    Symbol_w_systemie char(3)  NOT NULL,
    Wydzial_id int  NOT NULL,
    Stanowisko_id int  NOT NULL,
    id_przelozony_rekurencja int  NULL,
    CONSTRAINT Osoba_praca_pk PRIMARY KEY  (id)
);

-- Table: Projekt_OR
CREATE TABLE Projekt_OR (
    id int  NOT NULL IDENTITY,
    Numer_projektu int  NOT NULL,
    Rok int  NOT NULL,
    Hiperlacze varchar(500)  NULL,
    Data_wplywu date  NOT NULL,
    Data_zatwierdzenia_od date  NULL,
    Data_zatwierdzenia_do date  NULL,
    Uwagi varchar(500)  NULL,
    kontynuowany_po_projekcie_id int  NULL,
    Typ_id int  NOT NULL,
    id_Osoba_praca_prowadzacy int  NOT NULL,
    id_Osoba_praca_zatwierdzajacy int  NULL,
    Status_id int  NOT NULL,
	Email varchar(100) NOT NULL
    CONSTRAINT Projekt_OR_pk PRIMARY KEY  (id)
);

-- Table: Stanowisko
CREATE TABLE Stanowisko (
    id int  NOT NULL IDENTITY,
    nazwa varchar(100)  NOT NULL,
    CONSTRAINT Stanowisko_pk PRIMARY KEY  (id)
);

-- Table: Status
CREATE TABLE Status (
    id int  NOT NULL IDENTITY,
    Nazwa varchar(500)  NOT NULL,
    CONSTRAINT Status_pk PRIMARY KEY  (id)
);

-- Table: Typ
CREATE TABLE Typ (
    id int  NOT NULL IDENTITY,
    Typ varchar(100)  NOT NULL,
    CONSTRAINT Typ_pk PRIMARY KEY  (id)
);

-- Table: Wydzial
CREATE TABLE Wydzial (
    id int  NOT NULL IDENTITY,
    Nazwa varchar(500)  NOT NULL,
    Symbol varchar(20)  NOT NULL,
    CONSTRAINT Wydzial_pk PRIMARY KEY  (id)
);

-- Table: Zarzadca_Projekt
CREATE TABLE Zarzadca_Projekt (
    Zarzadca_drogi_id int  NOT NULL,
    Projekt_OR_id int  NOT NULL,
    CONSTRAINT Zarzadca_Projekt_pk PRIMARY KEY  (Zarzadca_drogi_id,Projekt_OR_id)
);

-- Table: Zarzadca_drogi
CREATE TABLE Zarzadca_drogi (
    id int  NOT NULL IDENTITY,
    Nazwa varchar(500)  NOT NULL,
    Adres varchar(500)  NULL,
    Dzielnica int  NULL,
    CONSTRAINT Zarzadca_drogi_pk PRIMARY KEY  (id)
);

-- foreign keys
-- Reference: Osoba_praca_Osoba_praca (table: Osoba_praca)
ALTER TABLE Osoba_praca ADD CONSTRAINT Osoba_praca_Osoba_praca
    FOREIGN KEY (id_przelozony_rekurencja)
    REFERENCES Osoba_praca (id);

-- Reference: Osoba_praca_Stanowisko (table: Osoba_praca)
ALTER TABLE Osoba_praca ADD CONSTRAINT Osoba_praca_Stanowisko
    FOREIGN KEY (Stanowisko_id)
    REFERENCES Stanowisko (id);

-- Reference: Osoba_praca_Wydzial (table: Osoba_praca)
ALTER TABLE Osoba_praca ADD CONSTRAINT Osoba_praca_Wydzial
    FOREIGN KEY (Wydzial_id)
    REFERENCES Wydzial (id);

-- Reference: Projekt_OR_Status (table: Projekt_OR)
ALTER TABLE Projekt_OR ADD CONSTRAINT Projekt_OR_Status
    FOREIGN KEY (Status_id)
    REFERENCES Status (id);

-- Reference: Projekt_OR_Typ (table: Projekt_OR)
ALTER TABLE Projekt_OR ADD CONSTRAINT Projekt_OR_Typ
    FOREIGN KEY (Typ_id)
    REFERENCES Typ (id);

-- Reference: Zarzadca_Projekt_Projekt_OR (table: Zarzadca_Projekt)
ALTER TABLE Zarzadca_Projekt ADD CONSTRAINT Zarzadca_Projekt_Projekt_OR
    FOREIGN KEY (Projekt_OR_id)
    REFERENCES Projekt_OR (id);

-- Reference: Zarzadca_Projekt_Zarzadca_drogi (table: Zarzadca_Projekt)
ALTER TABLE Zarzadca_Projekt ADD CONSTRAINT Zarzadca_Projekt_Zarzadca_drogi
    FOREIGN KEY (Zarzadca_drogi_id)
    REFERENCES Zarzadca_drogi (id);

-- Reference: kontynuowany_po_projekcie (table: Projekt_OR)
ALTER TABLE Projekt_OR ADD CONSTRAINT kontynuowany_po_projekcie
    FOREIGN KEY (kontynuowany_po_projekcie_id)
    REFERENCES Projekt_OR (id);

-- Reference: prowadzacy (table: Projekt_OR)
ALTER TABLE Projekt_OR ADD CONSTRAINT prowadzacy
    FOREIGN KEY (id_Osoba_praca_prowadzacy)
    REFERENCES Osoba_praca (id);

-- Reference: zatwierdzajacy (table: Projekt_OR)
ALTER TABLE Projekt_OR ADD CONSTRAINT zatwierdzajacy
    FOREIGN KEY (id_Osoba_praca_zatwierdzajacy)
    REFERENCES Osoba_praca (id);

-- End of file.

