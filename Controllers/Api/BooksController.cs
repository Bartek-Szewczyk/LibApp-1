using AutoMapper;
using LibApp.Data;
using LibApp.Dtos;
using LibApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace LibApp.Controllers.Api
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepo _repository;
        private readonly IMapper _mapper;
        
        public BooksController(IBooksRepo repository,  IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/books
        [HttpGet]
        [Authorize(Roles = "Owner, StoreManager, User")]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            var booksItems = _repository.GetAllBooks();
            return Ok(_mapper.Map<IEnumerable<BookDto>>(booksItems));
        }
        
        //GET api/books/{id}
        [HttpGet("{id}", Name = "GetBookById")]
        [Authorize(Roles = "Owner, StoreManager, User")]
        public ActionResult<Book> GetBookById(int id)
        {
            var bookItem = _repository.GetBookById(id);

            if (bookItem == null)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<BookDto>(bookItem));
        }
        
    }
}
