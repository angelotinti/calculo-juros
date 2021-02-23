namespace CalculaJuros.App.Integrations
{
    public class ReadTaxaJurosResult
    {
        public bool Success { get; set; }
        public float? Value { get; set; }
        public string Message { get; set; }

        public static ReadTaxaJurosResult IsSuccess(float value)
        {
            return new ReadTaxaJurosResult
            {
                Success = true,
                Value = value
            };
        }

        public static ReadTaxaJurosResult IsError(string message = null)
        {
            return new ReadTaxaJurosResult
            {
                Success = false,
                Message = message
            };
        }
    }
}
