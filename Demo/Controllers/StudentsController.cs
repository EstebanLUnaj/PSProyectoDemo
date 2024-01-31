﻿using Aplication.Interfaces;
using Aplication.UseCase.Students.GetAll;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentServices _services;

        public StudentsController(IStudentServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _services.GetAll();
            return new JsonResult(result);
        
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var result = await _services.GetById(id);
            return new JsonResult(result);
        }



        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentRequest request)
        {
            var result = await _services.CreateStudent(request);
            return new JsonResult(result) { StatusCode = 201};
        }

    }
}
