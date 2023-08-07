namespace Reminder
{
    public class ReminderModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
    }
}
