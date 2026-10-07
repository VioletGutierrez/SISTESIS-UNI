using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistesisUni.Core.Application.DTOs;
using SistesisUni.Core.Application.Interfaces;
using SistesisUni.Core.Domain.Entities;

namespace SistesisUni.Api.Controllers
{
    [ApiController]
    [Route("api/v1/theses")]
    [Authorize]
    public class ThesesController : ControllerBase
    {
        private readonly IThesisRepository _repository;
        public ThesesController(IThesisRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var theses = await _repository.GetAllAsync();
            return Ok(theses.Select(t => new ThesisResponseDto(
                t.Id, t.Title, t.AbstractText, t.StudentId,
                t.DocumentUrl, t.Status.ToString(), t.CreatedAt)));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var thesis = await _repository.GetByIdAsync(id);
            if (thesis == null) return NotFound();
            return Ok(new ThesisResponseDto(
                thesis.Id, thesis.Title, thesis.AbstractText, thesis.StudentId,
                thesis.DocumentUrl, thesis.Status.ToString(), thesis.CreatedAt));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateThesisDto dto)
        {
            var thesis = new Thesis(dto.Title, dto.AbstractText, dto.StudentId, dto.DocumentUrl);
            await _repository.AddAsync(thesis);
            return CreatedAtAction(nameof(GetById), new { id = thesis.Id }, thesis.Id);
        }

        [HttpPatch("{id:guid}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] ThesisStatus status)
        {
            var thesis = await _repository.GetByIdAsync(id);
            if (thesis == null) return NotFound();
            thesis.UpdateStatus(status);
            await _repository.UpdateAsync(thesis);
            return NoContent();
        }
    }
}