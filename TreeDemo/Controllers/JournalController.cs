using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TreeDemo.Controllers
{
    [ApiController]
    public class JournalController : ControllerBase
    {
        private IJournalService _journalService;

        public JournalController(IJournalService journalService)
        {
            _journalService = journalService;
        }

        /// <summary>
        /// Provides the pagination API. Skip means the number of items should be skipped by server. 
        /// Take means the maximum number items should be returned by server. All fields of the filter are optional.
        /// </summary>
        [HttpPost]
        [Route("api.user.journal.getRange")]
        [ProducesResponseType(typeof(MRange), StatusCodes.Status200OK)]
        public async Task<MRange> GetRange(
            [Required] int skip, [Required] int take, [Required] VJournalFilter filter)
        {
            return await _journalService.GetJournalRange(skip, take, filter);
        }

        /// <summary>
        /// Returns the information about an particular event by ID.
        /// </summary>
        [HttpPost]
        [Route("api.user.journal.getSingle")]
        [ProducesResponseType(typeof(MJournalInfo), StatusCodes.Status200OK)]
        public async Task<MJournalInfo> GetSingle(long id)
        {
            return await _journalService.GetSingleJournalInfo(id);
        }
    }
}
