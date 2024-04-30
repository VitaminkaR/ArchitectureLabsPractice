using Grpc.Core;
using L4GRPCService;

namespace L4GRPCService.Services
{
    public class MatrixService : Matrix.MatrixBase
    {
        private readonly ILogger<MatrixService> _logger;
        public MatrixService(ILogger<MatrixService> logger)
        {
            _logger = logger;
        }

        public override Task<MatrixReply> CalculateMatrix(MatrixRequest request, ServerCallContext context)
        {
            int size = (int)Math.Sqrt(request.M.Count);
            int[,] ar = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == j)
                        ar[i, j] = 0;
                    else
                        ar[i, j] = request.M[i * size + j];

                    if (i > j)
                        ar[i, j] *= ar[i, j];
                }
            }



            MatrixReply mr = new MatrixReply();
            foreach (var item in ar)
                mr.M.Add(item);
            return Task.FromResult(mr);
        }
    }
}
