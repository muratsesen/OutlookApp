public class DeleteMessagesRequest
{
    public List<Request> Requests { get; set; }
}
public class Request
{
    public int Id { get; set; }
    public string Method { get; set; }
    public string Url { get; set; }
}
