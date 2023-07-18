
namespace SystemVentas.Application.Core
{
    public class ServiceResult
    {
        public ServiceResult()
        {
            this.Success = true;
        }

        public bool Success { get; set; }
        public string Message { get; set; } = null!;
        public dynamic Data { get; set; } = null!;
    }
}
