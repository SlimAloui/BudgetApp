namespace BudgetAppAPI.Models
{
    public class TransactionNormale
    {
        public int Id { get; set; }
        public decimal Montant { get; set; }
        public DateTime DateTransaction { get; set; }
        public TypeTransactionNormale TypeTransaction { get; set; }  // "revenu" ou "depense"
        public string? Description { get; set; }

        public required Utilisateur Utilisateur { get; set; }
        public required Categorie Categorie { get; set; }
        public required Compte Compte { get; set; }
    }

    public enum TypeTransactionNormale
    {
        revenu,
        depense
    }
}
