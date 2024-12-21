-- Table des utilisateurs
CREATE TABLE Utilisateurs (
    utilisateur_id INT PRIMARY KEY AUTO_INCREMENT,
    nom VARCHAR(100),
    email VARCHAR(100) UNIQUE,
    mot_de_passe VARCHAR(100)
);

-- Table des comptes bancaires
CREATE TABLE Comptes (
    compte_id INT PRIMARY KEY AUTO_INCREMENT,
    utilisateur_id INT,
    nom VARCHAR(100),
    solde_initial DECIMAL(10, 2),
    FOREIGN KEY (utilisateur_id) REFERENCES Utilisateurs(utilisateur_id)
);

-- Table des catégories de dépenses/revenus
CREATE TABLE Categories (
    categorie_id INT PRIMARY KEY AUTO_INCREMENT,
    nom VARCHAR(100)
);

-- Table des transactions (dépenses/revenus)
CREATE TABLE Transactions (
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
