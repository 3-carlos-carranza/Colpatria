using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities.Process;

namespace Core.DataTransferObject.Vib
{
    public static class MapperPagesWithSectionsExtension
    {
        public static IEnumerable<Page> Map(this IEnumerable<MapperPagesWithSections> rows)
        {
            if (rows == null) throw new ArgumentNullException(nameof(rows));
            var list = new List<Page>();

            foreach (var p in rows)
            {
                if (list.Any(s => s.Id == p.PageId)) continue;
                var page = new Page
                {
                    Id = p.PageId,
                    Name = p.PageName,
                    ProcessId = p.PageProcessId,
                    Order = p.PageOrder,
                    NameAlias = p.PageNameAlias,
                    IsVisible = p.PageIsVisible,
                    Enable = p.PageEnable
                };
                foreach (var s in rows)
                {
                    if (s.SectionPageId != p.PageId) continue;
                    var section = new Section
                    {
                        Id = s.SectionId,
                        Description = s.SectionDescription,
                        Enable = s.SectionEnable,
                        IsVisible = s.SectionIsVisible,
                        Name = s.SectionName,
                        NameAlias = s.SectionNameAlias,
                        Order = s.SectionOrder,
                        ReadOnly = s.SectionReadOnly,
                        PageId = s.SectionPageId,
                        Type = s.SectionType,
                        ActionMethod = s.SectionActionMethod,
                        Action = s.SectionAction,
                        Controller = s.SectionController
                    };
                    page.Section.Add(section);
                }
                list.Add(page);
            }
            return list;
        }
    }
}