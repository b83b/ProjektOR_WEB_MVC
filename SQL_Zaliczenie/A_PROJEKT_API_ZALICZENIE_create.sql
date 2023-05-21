-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2023-05-21 18:59:05.457

-- tables
-- Table: OsobaPraca
CREATE TABLE OsobaPraca (
    id int  NOT NULL IDENTITY,
    Imie varchar(20)  NOT NULL,
    Nazwisko varchar(20)  NOT NULL,
    DataZatrudnienia date  NOT NULL,
    DataOdejsciaZPracy date  NULL,
    Symbol char(3)  NOT NULL,
    Wydzial int  NOT NULL,
    Stanowisko int  NOT NULL,
    PrzelozonyRekurencja int  NULL,
    Email varchar(100)  NOT NULL,
    CONSTRAINT OsobaPraca_pk PRIMARY KEY  (id)
);

-- Table: ProjektOR
CREATE TABLE ProjektOR (
    id int  NOT NULL IDENTITY,
    NumerProjektu int  NOT NULL,
    Rok int  NOT NULL,
    Hiperlacze varchar(500)  NULL,
    DataWplywu date  NOT NULL,
    DataZatwierdzeniaOd date  NULL,
    DataZatwierdzeniaDo date  NULL,
    Uwagi varchar(500)  NULL,
    KontynuowaniePoProjekcie int  NULL,
    Typ int  NOT NULL,
    OsobaProwadzaca int  NOT NULL,
    OsobaZatwierdzajaca int  NULL,
    Status int  NOT NULL,
    CONSTRAINT ProjektOR_pk PRIMARY KEY  (id)
);

-- Table: Stanowisko
CREATE TABLE Stanowisko (
    id int  NOT NULL IDENTITY,
    Nazwa varchar(100)  NOT NULL,
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

-- Table: ZarzadcaDrogi
CREATE TABLE ZarzadcaDrogi (
    id int  NOT NULL IDENTITY,
    Nazwa varchar(500)  NOT NULL,
    Adres varchar(500)  NULL,
    Dzielnica int  NULL,
    CONSTRAINT ZarzadcaDrogi_pk PRIMARY KEY  (id)
);

-- Table: Zarzadca_Projekt
CREATE TABLE Zarzadca_Projekt (
    ProjektOR_id int  NOT NULL,
    ZarzadcaDrogi_id int  NOT NULL,
    CONSTRAINT Zarzadca_Projekt_pk PRIMARY KEY  (ProjektOR_id,ZarzadcaDrogi_id)
);

-- foreign keys
-- Reference: Osoba_praca_Osoba_praca (table: OsobaPraca)
ALTER TABLE OsobaPraca ADD CONSTRAINT Osoba_praca_Osoba_praca
    FOREIGN KEY (PrzelozonyRekurencja)
    REFERENCES OsobaPraca (id);

-- Reference: Osoba_praca_Stanowisko (table: OsobaPraca)
ALTER TABLE OsobaPraca ADD CONSTRAINT Osoba_praca_Stanowisko
    FOREIGN KEY (Stanowisko)
    REFERENCES Stanowisko (id);

-- Reference: Osoba_praca_Wydzial (table: OsobaPraca)
ALTER TABLE OsobaPraca ADD CONSTRAINT Osoba_praca_Wydzial
    FOREIGN KEY (Wydzial)
    REFERENCES Wydzial (id);

-- Reference: Projekt_OR_Status (table: ProjektOR)
ALTER TABLE ProjektOR ADD CONSTRAINT Projekt_OR_Status
    FOREIGN KEY (Status)
    REFERENCES Status (id);

-- Reference: Projekt_OR_Typ (table: ProjektOR)
ALTER TABLE ProjektOR ADD CONSTRAINT Projekt_OR_Typ
    FOREIGN KEY (Typ)
    REFERENCES Typ (id);

-- Reference: Zarzadca_Projekt_ProjektOR (table: Zarzadca_Projekt)
ALTER TABLE Zarzadca_Projekt ADD CONSTRAINT Zarzadca_Projekt_ProjektOR
    FOREIGN KEY (ProjektOR_id)
    REFERENCES ProjektOR (id);

-- Reference: Zarzadca_Projekt_ZarzadcaDrogi (table: Zarzadca_Projekt)
ALTER TABLE Zarzadca_Projekt ADD CONSTRAINT Zarzadca_Projekt_ZarzadcaDrogi
    FOREIGN KEY (ZarzadcaDrogi_id)
    REFERENCES ZarzadcaDrogi (id);

-- Reference: kontynuowany_po_projekcie (table: ProjektOR)
ALTER TABLE ProjektOR ADD CONSTRAINT kontynuowany_po_projekcie
    FOREIGN KEY (KontynuowaniePoProjekcie)
    REFERENCES ProjektOR (id);

-- Reference: prowadzacy (table: ProjektOR)
ALTER TABLE ProjektOR ADD CONSTRAINT prowadzacy
    FOREIGN KEY (OsobaProwadzaca)
    REFERENCES OsobaPraca (id);

-- Reference: zatwierdzajacy (table: ProjektOR)
ALTER TABLE ProjektOR ADD CONSTRAINT zatwierdzajacy
    FOREIGN KEY (OsobaZatwierdzajaca)
    REFERENCES OsobaPraca (id);

-- End of file.

