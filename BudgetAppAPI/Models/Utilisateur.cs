namespace BudgetAppAPI.Models;
public class Utilisateur
{
    public int Id { get; set; }
    public required string Nom { get; set; }
    public required string Email { get; set; }
    public required string MotDePasse { get; set; }
    public List<Compte> Comptes { get; set; } = [];
}
