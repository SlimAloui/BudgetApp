namespace BudgetAppAPI.Models;
public class Budget
{
    public int Id { get; set; }
    public decimal Montant { get; set; }
    public int Mois { get; set; }
    public int Annee { get; set; }

    public required Utilisateur Utilisateur { get; set; }
    public required Categorie Categorie { get; set; }
}
