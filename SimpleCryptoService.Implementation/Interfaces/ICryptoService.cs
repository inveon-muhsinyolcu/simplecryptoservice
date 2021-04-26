namespace SimpleCryptoService.Implementation.Interfaces
{

    /// <summary>
    /// Interface for Simple Crypto Service
    /// </summary>
    public interface ICryptoService
    {
        string FormatTypeName { get; set; }
        int HashIterations { get; set; }
        int SaltSize { get; set; }
        int HashByteSize { get; set; }
        string PlainText { get; set; }
        string HashedText { get; }
        string Salt { get; set; }
        string SplitterChar { get; set; }


        string Compute();
        string Compute(string textToHash);
        string Compute(string textToHash, string salt);

        bool Compare(string passwordHash1, string passwordHash2);

        string GenerateSalt();
    }
}
