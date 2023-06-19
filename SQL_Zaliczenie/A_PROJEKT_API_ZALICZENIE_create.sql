-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2023-06-19 19:05:03.732

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
    Uwagi varchar(500)  NULL,
    Typ int  NOT NULL,
    OsobaProwadzaca int  NOT NULL,
    OsobaZatwierdzajaca int  NULL,
    Status int  NOT NULL,
    CONSTRAINT ProjektOR_pk PRIMARY KEY  (id)
);

-- Table: ProjektORZarzadcaDrogi
CREATE TABLE ProjektORZarzadcaDrogi (
    ProjektOrsId int  NOT NULL,
    ZarzadcaDrogisIdId int  NOT NULL,
    CONSTRAINT ProjektORZarzadcaDrogi_pk PRIMARY KEY  (ProjektOrsId,ZarzadcaDrogisIdId)
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
    CONSTRAINT ZarzadcaDrogi_pk PRIMARY KEY  (id)
);

-- foreign keys
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

-- Reference: prowadzacy (table: ProjektOR)
ALTER TABLE ProjektOR ADD CONSTRAINT prowadzacy
    FOREIGN KEY (OsobaProwadzaca)
    REFERENCES OsobaPraca (id);

-- Reference: zatwierdzajacy (table: ProjektOR)
ALTER TABLE ProjektOR ADD CONSTRAINT zatwierdzajacy
    FOREIGN KEY (OsobaZatwierdzajaca)
    REFERENCES OsobaPraca (id);

-- End of file.

