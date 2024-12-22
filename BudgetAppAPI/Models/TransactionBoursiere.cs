namespace BudgetAppAPI.Models
{
    public class TransactionBoursiere
    {
        public int Id { get; set; }
        public decimal Quantite { get; set; }
        public decimal PrixUnitaire { get; set; }
        public decimal Taxe { get; set; }
        public decimal Frais { get; set; }
        public DateTime DateTransaction { get; set; }
        public required TypeTransactionBoursiere TypeTransaction { get; set; }
        public required string Description { get; set; }
        public required Utilisateur Utilisateur { get; set; }
        public required Compte Compte { get; set; }
        public required Actif Actif { get; set; }
    }

    public enum TypeTransactionBoursiere
    {
        achat,
        vente
    }
}
