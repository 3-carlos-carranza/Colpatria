using System.Collections.Generic;
using Crosscutting.Common.Tools;

namespace Application.Main.Definition.Arguments
{
    public interface ISubmitFormArgument
    {
        IList<FieldValueOrder> Form { get; set; }
        int OwnerId { get; set; }
        ISubmitFormArgument Make(IList<FieldValueOrder> form, string username, int ownerId);
    }
}