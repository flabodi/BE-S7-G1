using BE_S7_G1.Data;
using BE_S7_G1.DTOs;
using BE_S7_G1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentResponseDTO>>> GetStudents()
        {
            var students = await _context.Students.ToListAsync();
            return students.Select(s => new StudentResponseDTO
            {
                Id = s.Id,
                Nome = s.Nome,
                Cognome = s.Cognome,
                Email = s.Email
            }).ToList();
        }

        // GET: api/student/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentResponseDTO>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            return new StudentResponseDTO
            {
                Id = student.Id,
                Nome = student.Nome,
                Cognome = student.Cognome,
                Email = student.Email
            };
        }

        // POST: api/student
        [HttpPost]
        public async Task<ActionResult<StudentResponseDTO>> PostStudent(StudentRequestDTO studentDto)
        {
            var student = new Student
            {
                Nome = studentDto.Nome,
                Cognome = studentDto.Cognome,
                Email = studentDto.Email
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, new StudentResponseDTO
            {
                Id = student.Id,
                Nome = student.Nome,
                Cognome = student.Cognome,
                Email = student.Email
            });
        }

        // PUT: api/student/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentRequestDTO studentDto)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            student.Nome = studentDto.Nome;
            student.Cognome = studentDto.Cognome;
            student.Email = studentDto.Email;

            _context.Students.Update(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/student/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
