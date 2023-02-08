namespace Infrastructure.Commons.Bases
{
    public class BasePaginationRequest
    {
        public int NumPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        private readonly int MaxPageSize = 50;
        public string Order { get; set; } = "asc";
        public string? Sort { get; set; } = null;

        public int Records
        {
            get => PageSize;
            set
            {
                PageSize = (value > MaxPageSize) ? MaxPageSize : value;
            }
        }
    }
}
