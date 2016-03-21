using Bec.TargetFramework.Entities;
using System.Collections.Generic;

namespace Bec.TargetFramework.Presentation.Web.Models
{
    public interface IPendingUpdateModel
    {
        IEnumerable<FieldUpdateDTO> FieldUpdates { get; set; }
    }

    public class PendingUpdateModel<TDto> : IPendingUpdateModel
    {
        public TDto Dto { get; set; }
        public IEnumerable<FieldUpdateDTO> FieldUpdates { get; set; }
    }
}