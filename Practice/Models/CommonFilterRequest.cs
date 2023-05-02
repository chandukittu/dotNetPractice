namespace Practice.Models
{
    public class CommonFilterRequest
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public string SearchValue { get; set; }
        public string SortOrder { get; set; }
        public string SortColumn { get; set; }

    }
}
