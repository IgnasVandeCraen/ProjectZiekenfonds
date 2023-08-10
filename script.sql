INSERT Bestemmingen ( [adres], [plaats], [postcode], [land]) VALUES (N'1 Liberty Island', N'New York', N'NY 10004', N'United States of America');
INSERT Bestemmingen ( [adres], [plaats], [postcode], [land]) VALUES (N'Champ de Mars, 5 Avenue Anatole', N'Paris', N'75007', N'France');
INSERT Bestemmingen ( [adres], [plaats], [postcode], [land]) VALUES (N'Dharmapuri, Forest Colony', N'Agra', N'282001', N'India');
INSERT Bestemmingen ( [adres], [plaats], [postcode], [land]) VALUES (N'Badaling, Yanqing', N'Beijing', N'100070', N'China');
INSERT Bestemmingen ( [adres], [plaats], [postcode], [land]) VALUES (N'Bennelong Point', N'Sydney', N'NSW 2000', N'Australia');
INSERT Bestemmingen ( [adres], [plaats], [postcode], [land]) VALUES (N'Santa Marta, Cosme Velho', N'Rio de Janeiro', N'22241-125', N'Brazil');
INSERT Bestemmingen ( [adres], [plaats], [postcode], [land]) VALUES (N'Piazza del Colosseo', N'Rome', N'00184', N'Italy');
GO

INSERT Themas ( [naam], [kleurHex]) VALUES (N'Natuur', N'7CFC00');
INSERT Themas ( [naam], [kleurHex]) VALUES (N'Geschiedenis', N'D2B48C');
INSERT Themas ( [naam], [kleurHex]) VALUES (N'Avontuur', N'ADD8E6');
INSERT Themas ( [naam], [kleurHex]) VALUES (N'Romantiek', N'FFB6C1');
INSERT Themas ( [naam], [kleurHex]) VALUES (N'Strand', N'FFEC8B');
GO

INSERT Leeftijdscategorieen ( [naam], [minLeeftijd], [maxLeeftijd]) VALUES (N'Kind', 1, 16);
INSERT Leeftijdscategorieen ( [naam], [minLeeftijd], [maxLeeftijd]) VALUES (N'Jongvolwassene', 17, 25);
INSERT Leeftijdscategorieen ( [naam], [minLeeftijd], [maxLeeftijd]) VALUES (N'Volwassene', 26, 65);
INSERT Leeftijdscategorieen ( [naam], [minLeeftijd], [maxLeeftijd]) VALUES (N'Senior', 66, 100);
GO

INSERT INTO Gebruikers ([email], [wachtwoord], [voornaam], [achternaam], [admin], [lid], [medischeGegevens], [aanmaakdatum], [leeftijdscategorieId]) VALUES ('gebruiker1@example.com', 'wachtwoord1', 'Jan', 'Janssen', 0, 1, NULL, '2023-08-01', 1);
INSERT INTO Gebruikers ([email], [wachtwoord], [voornaam], [achternaam], [admin], [lid], [medischeGegevens], [aanmaakdatum], [leeftijdscategorieId]) VALUES ('gebruiker2@example.com', 'wachtwoord2', 'Sara', 'De Vries', 1, 1, 'Medische informatie 1', '2023-08-01', 2);
INSERT INTO Gebruikers ([email], [wachtwoord], [voornaam], [achternaam], [admin], [lid], [medischeGegevens], [aanmaakdatum], [leeftijdscategorieId]) VALUES ('gebruiker3@example.com', 'wachtwoord3', 'Michiel', 'Pietersen', 0, 1, NULL, '2023-08-01', 3);
INSERT INTO Gebruikers ([email], [wachtwoord], [voornaam], [achternaam], [admin], [lid], [medischeGegevens], [aanmaakdatum], [leeftijdscategorieId]) VALUES ('gebruiker4@example.com', 'wachtwoord4', 'Eva', 'Bakker', 0, 0, NULL, '2023-08-01', 1);
INSERT INTO Gebruikers ([email], [wachtwoord], [voornaam], [achternaam], [admin], [lid], [medischeGegevens], [aanmaakdatum], [leeftijdscategorieId]) VALUES ('gebruiker5@example.com', 'wachtwoord5', 'David', 'Smit', 0, 1, NULL, '2023-08-01', 2);
INSERT INTO Gebruikers ([email], [wachtwoord], [voornaam], [achternaam], [admin], [lid], [medischeGegevens], [aanmaakdatum], [leeftijdscategorieId]) VALUES ('gebruiker6@example.com', 'wachtwoord6', 'Laura', 'Hendriks', 1, 1, 'Medische informatie 2', '2023-08-01', 3);
INSERT INTO Gebruikers ([email], [wachtwoord], [voornaam], [achternaam], [admin], [lid], [medischeGegevens], [aanmaakdatum], [leeftijdscategorieId]) VALUES ('gebruiker7@example.com', 'wachtwoord7', 'Robbert', 'Vermeulen', 0, 1, NULL, '2023-08-01', 1);
INSERT INTO Gebruikers ([email], [wachtwoord], [voornaam], [achternaam], [admin], [lid], [medischeGegevens], [aanmaakdatum], [leeftijdscategorieId]) VALUES ('gebruiker8@example.com', 'wachtwoord8', 'Lotte', 'Visser', 0, 0, NULL, '2023-08-01', 2);
INSERT INTO Gebruikers ([email], [wachtwoord], [voornaam], [achternaam], [admin], [lid], [medischeGegevens], [aanmaakdatum], [leeftijdscategorieId]) VALUES ('gebruiker9@example.com', 'wachtwoord9', 'Daniël', 'Bos', 1, 1, 'Medische informatie 3', '2023-08-01', 3);
INSERT INTO Gebruikers ([email], [wachtwoord], [voornaam], [achternaam], [admin], [lid], [medischeGegevens], [aanmaakdatum], [leeftijdscategorieId]) VALUES ('gebruiker10@example.com', 'wachtwoord10', 'Anouk', 'Kuijpers', 0, 1, NULL, '2023-08-01', 1);
INSERT INTO Gebruikers ([email], [wachtwoord], [voornaam], [achternaam], [admin], [lid], [medischeGegevens], [aanmaakdatum], [leeftijdscategorieId]) VALUES ('gebruiker11@example.com', 'wachtwoord11', 'Kevin', 'Bakker', 0, 0, NULL, '2023-08-01', 2);
INSERT INTO Gebruikers ([email], [wachtwoord], [voornaam], [achternaam], [admin], [lid], [medischeGegevens], [aanmaakdatum], [leeftijdscategorieId]) VALUES ('gebruiker12@example.com', 'wachtwoord12', 'Emma', 'Jacobs', 1, 1, 'Medische informatie 4', '2023-08-01', 3);
INSERT INTO Gebruikers ([email], [wachtwoord], [voornaam], [achternaam], [admin], [lid], [medischeGegevens], [aanmaakdatum], [leeftijdscategorieId]) VALUES ('gebruiker13@example.com', 'wachtwoord13', 'Willem', 'De Boer', 0, 1, NULL, '2023-08-01', 1);
INSERT INTO Gebruikers ([email], [wachtwoord], [voornaam], [achternaam], [admin], [lid], [medischeGegevens], [aanmaakdatum], [leeftijdscategorieId]) VALUES ('gebruiker14@example.com', 'wachtwoord14', 'Olivia', 'Verhoeven', 0, 0, NULL, '2023-08-01', 2);
INSERT INTO Gebruikers ([email], [wachtwoord], [voornaam], [achternaam], [admin], [lid], [medischeGegevens], [aanmaakdatum], [leeftijdscategorieId]) VALUES ('gebruiker15@example.com', 'wachtwoord15', 'Mika', 'Huisman', 1, 1, 'Medische informatie 5', '2023-08-01', 2);
INSERT INTO Gebruikers ([email], [wachtwoord], [voornaam], [achternaam], [admin], [lid], [medischeGegevens], [aanmaakdatum], [leeftijdscategorieId]) VALUES ('gebruiker16@example.com', 'wachtwoord16', 'Sophie', 'Mulder', 0, 1, NULL, '2023-08-01', 2);
GO

INSERT INTO Inschrijvingen ([gebruikerId], [groepreisId]) VALUES (1, 4);
INSERT INTO Inschrijvingen ([gebruikerId], [groepreisId]) VALUES (2, 1);
INSERT INTO Inschrijvingen ([gebruikerId], [groepreisId]) VALUES (3, 2);
INSERT INTO Inschrijvingen ([gebruikerId], [groepreisId]) VALUES (4, 7);
INSERT INTO Inschrijvingen ([gebruikerId], [groepreisId]) VALUES (5, 5);
INSERT INTO Inschrijvingen ([gebruikerId], [groepreisId]) VALUES (6, 3);
INSERT INTO Inschrijvingen ([gebruikerId], [groepreisId]) VALUES (7, 4);
INSERT INTO Inschrijvingen ([gebruikerId], [groepreisId]) VALUES (8, 1);
INSERT INTO Inschrijvingen ([gebruikerId], [groepreisId]) VALUES (9, 2);
INSERT INTO Inschrijvingen ([gebruikerId], [groepreisId]) VALUES (10, 7);
GO

INSERT INTO Groepsreizen ([naam], [beschrijving], [startdatum], [einddatum], [maxInschrijvingen], [prijs], [aanmaakdatum], [leeftijdscategorieId], [bestemmingId], [themaId]) VALUES (N'Avontuurlijke Reis naar New York', N'Een spannende avontuurlijke reis naar New York', '2023-09-15', '2023-09-25', 4, 1500.00, '2023-08-01', 2, 1, 1);
INSERT INTO Groepsreizen ([naam], [beschrijving], [startdatum], [einddatum], [maxInschrijvingen], [prijs], [aanmaakdatum], [leeftijdscategorieId], [bestemmingId], [themaId]) VALUES (N'Romantisch Uitje naar Parijs', N'Een romantische reis naar de stad van de liefde, Parijs', '2023-10-10', '2023-10-15', 3, 1200.00, '2023-08-01', 3, 2, 4);
INSERT INTO Groepsreizen ([naam], [beschrijving], [startdatum], [einddatum], [maxInschrijvingen], [prijs], [aanmaakdatum], [leeftijdscategorieId], [bestemmingId], [themaId]) VALUES (N'Cultuur- en Historische Tour naar Agra', N'Een reis vol geschiedenis en cultuur naar Agra, India', '2023-11-20', '2023-11-30', 5, 1800.00, '2023-08-01', 3, 3, 2);
INSERT INTO Groepsreizen ([naam], [beschrijving], [startdatum], [einddatum], [maxInschrijvingen], [prijs], [aanmaakdatum], [leeftijdscategorieId], [bestemmingId], [themaId]) VALUES (N'Ontdekkingstocht in Beijing', N'Een avontuurlijke reis naar Beijing om nieuwe culturen te ontdekken', '2023-12-05', '2023-12-15', 6, 2000.00, '2023-08-01', 1, 4, 1);
INSERT INTO Groepsreizen ([naam], [beschrijving], [startdatum], [einddatum], [maxInschrijvingen], [prijs], [aanmaakdatum], [leeftijdscategorieId], [bestemmingId], [themaId]) VALUES (N'Ontspannende Strandvakantie in Sydney', N'Een heerlijke strandvakantie in Sydney, Australië', '2024-01-10', '2024-01-20', 4, 1700.00, '2023-08-01', 2, 5, 5);
INSERT INTO Groepsreizen ([naam], [beschrijving], [startdatum], [einddatum], [maxInschrijvingen], [prijs], [aanmaakdatum], [leeftijdscategorieId], [bestemmingId], [themaId]) VALUES (N'Natuur en Avontuur in Rio de Janeiro', N'Een combinatie van avontuur en natuurschoon in Rio de Janeiro, Brazilië', '2024-02-15', '2024-02-25', 5, 1900.00, '2023-08-01', 3, 6, 3);
INSERT INTO Groepsreizen ([naam], [beschrijving], [startdatum], [einddatum], [maxInschrijvingen], [prijs], [aanmaakdatum], [leeftijdscategorieId], [bestemmingId], [themaId]) VALUES (N'Historische Tour naar Rome', N'Een historische reis naar Rome, Italië', '2024-03-10', '2024-03-20', 6, 2100.00, '2023-08-01', 1, 7, 2);
GO