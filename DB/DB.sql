-- Table des utilisateurs
CREATE TABLE Utilisateurs (
    utilisateur_id INT PRIMARY KEY AUTO_INCREMENT,
    nom VARCHAR(100),
    email VARCHAR(100) UNIQUE,
    mot_de_passe VARCHAR(100)
);

-- Table des comptes bancaires et de bourse
CREATE TABLE Comptes (
    compte_id INT PRIMARY KEY AUTO_INCREMENT,
    utilisateur_id INT,
    nom VARCHAR(100),
    type_compte ENUM('Bancaire', 'Bourse') NOT NULL,
    solde_cash DECIMAL(10, 2),  -- Partie cash du compte
    FOREIGN KEY (utilisateur_id) REFERENCES Utilisateurs(utilisateur_id)
);

-- Table des catégories de dépenses/revenus/investissements
CREATE TABLE Categories (
    categorie_id INT PRIMARY KEY AUTO_INCREMENT,
    nom VARCHAR(100)
);

-- Table des actifs boursiers
CREATE TABLE Actifs (
    actif_id INT PRIMARY KEY AUTO_INCREMENT,
    compte_id INT,
    nom_actif VARCHAR(100),
    quantite DECIMAL(10, 2),
    valeur_unitaire DECIMAL(10, 2),
    FOREIGN KEY (compte_id) REFERENCES Comptes(compte_id)
);

-- Table des transactions normales
CREATE TABLE Transactions_Normales (
    transaction_id INT PRIMARY KEY AUTO_INCREMENT,
    utilisateur_id INT,
    categorie_id INT,
    compte_id INT,
    montant DECIMAL(10, 2),
    date_transaction DATE,
    type_transaction ENUM('revenu', 'depense'),
    description TEXT,
    FOREIGN KEY (utilisateur_id) REFERENCES Utilisateurs(utilisateur_id),
    FOREIGN KEY (categorie_id) REFERENCES Categories(categorie_id),
    FOREIGN KEY (compte_id) REFERENCES Comptes(compte_id)
);

-- Table des transactions boursières
CREATE TABLE Transactions_Boursieres (
    transaction_id INT PRIMARY KEY AUTO_INCREMENT,
    utilisateur_id INT,
    compte_id INT,
    actif_id INT,
    quantite DECIMAL(10, 2),
    prix_unitaire DECIMAL(10, 2),
    taxe DECIMAL(10, 2),
    frais DECIMAL(10, 2),
    date_transaction DATE,
    type_transaction ENUM('achat', 'vente'),
    description TEXT,
    FOREIGN KEY (utilisateur_id) REFERENCES Utilisateurs(utilisateur_id),
    FOREIGN KEY (compte_id) REFERENCES Comptes(compte_id),
    FOREIGN KEY (actif_id) REFERENCES Actifs(actif_id)
);


-- Table des budgets mensuels
CREATE TABLE Budgets (
    budget_id INT PRIMARY KEY AUTO_INCREMENT,
    utilisateur_id INT,
    categorie_id INT,
    montant DECIMAL(10, 2),
    mois INT,
    annee INT,
    FOREIGN KEY (utilisateur_id) REFERENCES Utilisateurs(utilisateur_id),
    FOREIGN KEY (categorie_id) REFERENCES Categories(categorie_id)
);
