using System.ComponentModel.DataAnnotations;

namespace UserCollection.WebAPI.Models
{
    public class CustomFieldsModel
    {
        public int Id { get; set; }
        public bool CustomField1State { get; set; }
        public string CustomField1Name { get; set; } = string.Empty;

        public bool CustomField2State { get; set; }
        public string CustomField2Name { get; set; } = string.Empty;

        public bool CustomField3State { get; set; }
        public string CustomField3Name { get; set; } = string.Empty;
    }
}
