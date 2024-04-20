CREATE TABLE Film (
    FilmID INTEGER PRIMARY KEY AUTOINCREMENT,
    FilmAdi TEXT NOT NULL
);

CREATE TABLE Salon (
    SalonID INTEGER PRIMARY KEY AUTOINCREMENT,
    SalonAdi TEXT NOT NULL,
    KoltukKapasitesi INTEGER NOT NULL
);

CREATE TABLE Seans (
    SeansID INTEGER PRIMARY KEY AUTOINCREMENT,
    FilmID INTEGER,
    SalonID INTEGER,
    TarihSaat DATETIME,
    FOREIGN KEY (FilmID) REFERENCES Film(FilmID),
    FOREIGN KEY (SalonID) REFERENCES Salon(SalonID)
);
