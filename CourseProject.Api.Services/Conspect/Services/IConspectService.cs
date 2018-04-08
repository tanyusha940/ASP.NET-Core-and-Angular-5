using System.Collections.Generic;
using System.Threading.Tasks;
using CourseProject.Api.Services.Conspect.Models;
using CourseProject.Api.Services.LookUps.Models;
using CourseProject.Data.Model;

namespace CourseProject.Api.Services.Conspect.Services
{
  public interface IConspectService
  {
    Task<IList<ConspectTag>> GetExistingConspectTags(ICollection<LookUp> TagLookUps, Data.Model.Conspect conspect);

    Task<IList<ConspectTag>> GetNewConspectTag(Data.Model.Conspect conspect, ICollection<LookUp> TagLookUps);

    Data.Model.Conspect MapConspectDtoToConspect(ConspectDto conspectDto, UserIdentity user);

    Data.Model.Conspect MapConspectDtoToConspect(ConspectDto conspectDto, UserIdentity user, Data.Model.Conspect conspect);
  }
}