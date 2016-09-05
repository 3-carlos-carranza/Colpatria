using System;
using System.Collections.Generic;
using Application.Main.Definition.Arguments;
using Crosscutting.Common.Tools;

namespace Application.Main.Implementation.ProcessFlow.Arguments
{
    public class SubmitFormArgument : StepArgument, ISubmitFormArgument
    {
        public IList<FieldValueOrder> Form { get; set; }
        public int OwnerId { get; set; }

        public ISubmitFormArgument Make(IList<FieldValueOrder> form, string username, int ownerId)
        {
            return new SubmitFormArgument()
            {
                Form = form,
                Username = username,
                OwnerId = ownerId
            };
        }
    }
}