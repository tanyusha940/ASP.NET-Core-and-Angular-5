using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseProject.Api.Services.Conspect.Models;
using CourseProject.Api.Services.LookUps.Models;
using CourseProject.Data.Model;
using CourseProject.Data.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Api.Services.Conspect.Services
{
  public class ConspectService : IConspectService
  {
    private readonly ApplicationContext context;

    public ConspectService(ApplicationContext context)
    {
      this.context = context;
    }

    public Data.Model.Conspect MapConspectDtoToConspect(ConspectDto conspectDto, UserIdentity user)
    {
      return new Data.Model.Conspect
      {
        Name = conspectDto.Name,
        Content = conspectDto.Content,
        SpecialityNumberId = conspectDto.SpecialityNumberId,
        CreatedDate = DateTime.Now,
        Active = true,
        User = user
      };
    }

    public Data.Model.Conspect MapConspectDtoToConspect(ConspectDto conspectDto, UserIdentity user, Data.Model.Conspect conspect)
    {
        conspect.Name = conspectDto.Name;
        conspect.Content = conspectDto.Content;
        conspect.SpecialityNumberId = conspectDto.SpecialityNumberId;
        conspect.CreatedDate = conspectDto.CreatedDate;
        conspect.Active = true;
        conspect.User = user;
        conspect.UpdatedDate = DateTime.Now;

        return conspect;
    }

    public async Task<IList<ConspectTag>> GetExistingConspectTags(ICollection<LookUp> TagLookUps,
      Data.Model.Conspect conspect)
    {
      var tagNames = TagLookUps.Select(tag => tag.Text.ToLower());
      var existingTags = context.Tags.Where(tag => tagNames.Contains(tag.Text.ToLower()));
      var conspectTags = await existingTags.Select(tag => new ConspectTag
        {
          TagId = tag.Id,
          Conspect = conspect
        })
        .ToListAsync();

      return conspectTags;
    }

    public async Task<IList<ConspectTag>> GetNewConspectTag(Data.Model.Conspect conspect, ICollection<LookUp> TagLookUps)
    {
      var tagNames = TagLookUps.Select(tag => tag.Text.ToLower());
      var existingTags = await context.Tags.Where(tag => tagNames.Contains(tag.Text.ToLower())).ToListAsync();
      var newTags = tagNames.Where(name => !existingTags.Select(tag => tag.Text).Contains(name)).ToList();
      var newConspectTags = newTags.Select(tag => new ConspectTag
        {
          Conspect = conspect,
          Tag = new Data.Model.Tag
          {
            Text = tag,
            Active = true
          }
        })
        .ToList();

      return newConspectTags;
    }
  }
}