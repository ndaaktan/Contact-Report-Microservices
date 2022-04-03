namespace ReportService.AsyncReportService
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}
