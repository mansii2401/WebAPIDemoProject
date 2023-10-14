namespace WebAPIDemoProject.Entities.DTO
{
    public class Response<T>
    {
        public T Result { get; set; }
        public string StatusMessage { get; set; }
    }
}