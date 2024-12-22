namespace BudgetAppAPI.Models
{
    public enum TypeCompte
    {
        Bancaire,
        Boursiere
    }

    public class Compte
    {
        public int Id { get; set; }
        public required string Nom { get; set; }
        public TypeCompte TypeCompte { get; set; }
        public decimal SoldeCash { get; set; }
        public required Utilisateur Utilisateur { get; set; }
        public List<TransactionNormale> TransactionsNormales { get; set; } = [];
        public List<TransactionBoursiere> TransactionsBoursieres { get; set; } = [];
    }
}
    