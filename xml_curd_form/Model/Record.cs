namespace xml_curd_form.Model
{
    [Serializable]
    public class Route
    {
        public string Title { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public decimal Distance { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
       
    }

}