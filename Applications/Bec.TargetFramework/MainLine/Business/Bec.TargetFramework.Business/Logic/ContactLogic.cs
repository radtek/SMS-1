using System;
using System.Linq;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;

namespace Bec.TargetFramework.Business.Logic
{
    using Bec.TargetFramework.Aop.Aspects;

    public class ContactLogic : LogicBase
    {
        [Trace(TraceExceptionsOnly = true)]
        public ContactLogic(ILogger logger, ICacheProvider cacheProvider)
            : base(logger, cacheProvider)
        {
        }
        //        scope.Save();
        //    }
        //}
        //        if (operationIds != null && operationIds.Length > 0)
        //        {
        //            operationIds.ToList().ForEach(item =>
        //            {
        //                Guid opId = Guid.Parse(item);
        //                saveContact.Operations.Add(scope.DbContext.Operations.Single(op => op.OperationID.Equals(opId)));
        //            });
        //        }
        //        if (saveContact.Operations.Count > 0)
        //        {
        //            saveContact.Operations.Clear();
        //        }
        //        if (ros.Count == 0)
        //        {
        //            saveContact = Contact;
        //        }
        //        else
        //        {
        //            saveContact = ros[0];
        //        }
        //        var ros =
        //            scope.DbContext.Contacts.Include("Operations").Where(item => item.ContactID.Equals(Contact.ContactID)).ToList();
        //public void RebuildOperationContact(string[] operationIds, Contact Contact)
        //{
        //    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
        //    {
        //        // delete existing ros
        //        var saveContact = new Contact();
        //        scope.Save();
        //    }
        //}
        //        if (selectedOperations != null && selectedOperations.Length > 0)
        //        {
        //            this.RebuildOperationContact(selectedOperations, Contact);
        //        }
        //        if (dto.ContactID != Guid.Empty)
        //        {
        //            ContactRepos.Update(Contact);
        //        }
        //        else
        //        {
        //            ContactRepos.Add(Contact);
        //        }
        //        Contact.InjectFrom(new IgnoreProps("ContactID"), dto);
        //        if (dto.ContactID != Guid.Empty)
        //        {
        //            Contact = ContactRepos.Get(dto.ContactID);
        //        }
        //        else
        //        {
        //            Contact.ContactID = Guid.NewGuid();
        //        }
        //public void SaveContact(ContactDTO dto, string[] selectedOperations)
        //{
        //    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
        //    {
        //        var ContactRepos = scope.GetGenericRepository<Contact, Guid>();
        //        var Contact = new Contact();
        //    return dto;
        //}
        //        // add selected ops
        //        dto.SelectedOperations = String.Join(",", Contact.Operations.Select(item => item.OperationID.ToString()).ToArray());
        //    }
        //        // add ops
        //        scope.GetGenericRepository<Operation, Guid>().GetAll().ForEach(item =>
        //        {
        //            var oDto = new OperationDTO();
        //            oDto.InjectFrom(item);
        //            dto.Operations.Add(oDto);
        //        });
        //        dto.InjectFrom(Contact);
        //    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
        //    {
        //        var Contact = scope.DbContext.Contacts.Include("Operations").Single(item => item.ContactID.Equals(id));
        //    var dto = new ContactDTO();
        //public ContactDTO GetContactDTO(Guid id)
        //{
        //    Ensure.NotEqual(id, Guid.Empty, "ContactID cannot be an empty guid");
        //    return dtoList;
        //}
        //            dtoList.Add(dto);
        //        });
        //    }
        //            dto.InjectFrom(item);
        //    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
        //    {
        //        scope.DbContext.Contacts.ToList().ForEach(item =>
        //        {
        //            var dto = new ContactDTO();
        //public List<ContactDTO> GetAllContactDTO()
        //{
        //    var dtoList = new List<ContactDTO>();
        //    return dto;
        //}
        //public ContactDTO CreateAndInitializeDTO()
        //{
        //    var dto = new ContactDTO();
        //    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
        //    {
        //        scope.GetGenericRepository<Operation, Guid>().GetAll().ForEach(item =>
        //        {
        //            var oDto = new OperationDTO();
        //            oDto.InjectFrom(item);
        //            dto.Operations.Add(oDto);
        //        });
        //    }
    }
}
