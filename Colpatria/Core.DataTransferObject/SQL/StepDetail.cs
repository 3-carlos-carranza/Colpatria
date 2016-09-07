using Core.Entities.SQL.Process;

namespace Core.DataTransferObject.SQL
{
    public class StepDetail : Step
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public int PageId { get; set; }
        public string PageName { get; set; }
        public string Action { get; set; }
    }
}