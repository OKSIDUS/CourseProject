using System.ComponentModel.DataAnnotations;

namespace UserCollection.WebAPI.Models
{
    public class CustomFieldForData<T>
    {
        public int Id { get; set; }
        public T? CustomField1Data { get; set; }
        public T? CustomField2Data { get; set; }
        public T? CustomField3Data { get; set; }
    }
}
