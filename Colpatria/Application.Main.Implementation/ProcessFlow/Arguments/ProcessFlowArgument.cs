using System.Collections.Generic;
using Application.Main.Definition.ProcessFlow.Api;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;
using Core.Entities.ProcessModel;
using Crosscutting.Common.Tools.DataType;

namespace Application.Main.Implementation.ProcessFlow.Arguments
{
    public class ProcessFlowArgument :  IProcessFlowArgument
    {
        public IList<FieldValueOrder> Form { get; set; }
        public int OwnerId { get; set; }

        //public IProcessFlowArgument Make(IList<FieldValueOrder> form, int ownerId)
        //{
        //    return new ProcessFlowArgument()
        //    {
        //        Form = form,
        //        OwnerId = ownerId
        //    };
        //}

        public Execution Execution { get; set; }
        public IProcessFlowUser User { get; set; }
        public bool IsSubmitting { get; set; }
        public IEnumerable<IStep> Steps { get; set; }
    }
}