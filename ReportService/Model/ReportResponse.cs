namespace ReportService.Model
{
    public class ReportResponse<T>
    {
        public string Message { get; set; }
        public bool Result { get; set; }
        public T Response { get; set; }
    }
}
