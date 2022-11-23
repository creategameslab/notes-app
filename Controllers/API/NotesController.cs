using Microsoft.AspNetCore.Mvc;
using Notes.Code;
using Notes.Code.Entities;

namespace Notes.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public sealed class NotesController : ControllerBase
    {
        private readonly ILogger<NotesController> _logger;
        private readonly INotesRepository _repository;

        public NotesController(INotesRepository repository,
            ILogger<NotesController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ICollection<Note>>> GetAsync()
        {
            try
            {
                return Ok(await _repository.GetNotesAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get notes: {ex}");
            }

            return BadRequest();
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Note>> PostAsync(Note model)
        {
            try
            {
                if (ModelState.IsValid) {
                    model.Created= DateTime.UtcNow;
                    model.Id = Guid.NewGuid().ToString("N");

                    var result = await _repository.AddNoteAsync(model);

                    return result ? Ok(model) : StatusCode(500);
                }

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to add notes: {ex}");
            }

            return BadRequest();
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Note>> PatchAsync(string id, Note model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Updated = DateTime.UtcNow;

                    var result = await _repository.UpdateNoteAsync(id, model);

                    return result ? Ok(model) : StatusCode(500);
                }

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to update note: {ex}");
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            var result = await _repository.DeleteNoteAsync(id);

            return result ? Ok() : NotFound();
        }

        [HttpGet("seed")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> SeedAsync()
        {
            try
            {
                await _repository.AddNoteAsync(new Note { RawText = "test 1" });
                await _repository.AddNoteAsync(new Note { RawText = "test 2" });
                await _repository.AddNoteAsync(new Note { RawText = "test 3 Plus some other information" });

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to seed: {ex}");
            }

            return BadRequest();
        }
    }
}
