
using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using SMAS.MSStudent.API.Application.Commands;
using SMAS.MSStudent.API.Application.DomainEventHandlers;
using SMAS.MSStudent.API.Application.DTOs;
using SMAS.MSStudent.API.Application.Models;
using SMAS.MSStudent.API.Application.Queries;
using SMAS.MSStudent.Domain;

namespace SMAS.MSStudent.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<StudentsController> _logger;
        public StudentsController(ILogger<StudentsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        //// Create
        //[HttpPost]
        //public async Task<IActionResult> Create(StudentDTO dto, CancellationToken cancellationToken = default)
        //{
        //    if (null == dto)
        //        return BadRequest();
        //    var command = new CreateStudent(Guid.NewGuid(), dto.Firstname, dto.Lastname, dto.Email);
        //    await _mediator.Publish(command, cancellationToken);
        //    return CreatedAtAction("GetStudent", new { id = command.Id }, command);
        //}

        //[HttpGet, Route("{id:guid}", Name = "GetStudent")]
        //public async Task<IActionResult> GetStudent(Guid id, CancellationToken cancellationToken = default)
        //{
        //    var query = new StudentById(id);
        //    var result = await _mediator.Send(query, cancellationToken);
        //    if (null == result)

        //        return NotFound();

        //    return Ok(result);
        //}


        [HttpPost]
        public virtual IActionResult CreateStudent([FromBody] StudentModel model)
        {
            var item = new Application.DTOs.Student();
            item.Name = model.Name;
            item.Code = model.Code;
            item.Id;
            var _studentService = new StudentService(new ModelContext());
            _studentService.InsertStudent(item);
            return Ok(item);
        }
        [HttpGet]
        [Route("getbyid/{studentId}")]
        public virtual IActionResult GetStudentByid(int StudentId)
        {
            var _studentService = new StudentService(new ModelContext());
            var item = _studentService.GetStudentById(StudentId);
            return Ok(item);
        }

        [HttpDelete]
        public virtual IActionResult DeleteStudent(int StudentId)
        {
            var _studentService = new StudentService(new ModelContext());
            var mss = _studentService.DeleteStudentById(StudentId);
            return Ok(mss);
        }
        [HttpGet]
        public virtual IActionResult GetAllStudent()
        {
            var _studentService = new StudentService(new ModelContext());
            var items = _studentService.GetAllStudent();
            return Ok(items);
        }
    }
}
