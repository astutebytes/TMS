using AutoMapper;
using TMS.Domain.Entities;
using TMS.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using TMS.Application.Interfaces;
using TMS.Application.Common.Constants;
using Microsoft.AspNetCore.Authorization;

namespace TMS.WebApi.Controllers
{
    public class EventController(IUnitOfWork uow, IMapper mapper) : BaseApiController
    {
        [Authorize(Policy = RolesPolicy.ORGANIZER_POLICY)]
        [HttpPost("create")]
        public async Task<ActionResult> Create(EventDto eventDto)
        {
            var eventToAdd = mapper.Map<TMSEvent>(eventDto);

            uow.EventRepository.AddEvent(eventToAdd);
            if (await uow.Complete()) return Ok(eventToAdd);

            return BadRequest("Problem while creating new event");
        }
    }
}
