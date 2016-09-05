namespace Core.DataTransferObject.SQL
{
    public class MapperPagesWithSections
    {
        //Page
        public int PageId { get; set; }
        public int PageProcessId { get; set; }
        public string PageName { get; set; }
        public int PageOrder { get; set; }
        public bool PageIsVisible { get; set; }
        public string PageNameAlias { get; set; }
        public bool PageEnable { get; set; }
        //Section
        public int SectionId { get; set; }
        public int SectionPageId { get; set; }
        public string SectionName { get; set; }
        public string SectionDescription { get; set; }
        public int SectionOrder { get; set; }
        public string SectionNameAlias { get; set; }
        public bool SectionReadOnly { get; set; }
        public int SectionType { get; set; }
        public bool SectionIsVisible { get; set; }
        public bool SectionEnable { get; set; }
        public string SectionActionMethod { get; set; }
        public string SectionAction { get; set; }
        public string SectionController { get; set; }
    }
}