using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace PlatformDemo.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        
        public class TicketsController : ControllerBase
        {
            [HttpGet]
            
            public IActionResult Get()
            {
                return Ok("Reading all the tickets.");

            }
            [HttpGet("{id}")]
            [Route("api/tickets/{id}")]
            public IActionResult GetById(int id)
            {
                return Ok($"Reading ticket #{id}.");
            }
            [HttpPost]
            
            
            public IActionResult PostV1([FromBody] Ticket ticket)
            {
                return Ok(ticket);
            }

            


            [HttpPut]

            
            
            public IActionResult Put ([FromBody] Ticket ticket)
            {
                return Ok(ticket);
            }
            [HttpDelete("{id}")]
            
            public IActionResult Delete(int id)
            {
                return Ok($"Deleting ticket #{id}.");
            }

            
        }
        }
