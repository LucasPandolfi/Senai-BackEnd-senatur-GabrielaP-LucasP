using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Senai.Senatur.WebApi.Controllers
{
    [Produces("Aplication/Json")]

    [Route("api/[controller]")]

    [ApiController]
    public class LoginController : ControllerBase
    {
    }
}