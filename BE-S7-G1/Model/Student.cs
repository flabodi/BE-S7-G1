namespace BE_S7_G1.Model
{
    public class Student
    {
        public int Id { get; set; }  // Chiave primaria
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
