using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sabio.Models;
using Sabio.Models.Domain.Providers;
using Sabio.Services;
using Sabio.Services.Interfaces;
using Sabio.Web.Controllers;
using Sabio.Web.Models.Responses;

namespace Sabio.Web.Api.Controllers
{
    [Route("api/admin")]
    //[Authorize(Roles="SysAdmin")]
    [ApiController]
    public class SysAdminController : BaseApiController
    {
        private IAuthenticationService<int> _authService = null;
        private ICompliantProviderService _service = null;

        public SysAdminController(ICompliantProviderService service, ILogger<SysAdminController> logger, IAuthenticationService<int> authService) : base(logger) {
            _authService = authService;
            _service = service;
        }

        [HttpGet("providers/{stateId:int}")]
        public ActionResult<CompliantProvider> SortCompliantByState(int stateId) {
            int code = 200;
            BaseResponse res = null;
            
            try
            {
                
                CompliantProvider cp = _service.SortCompliantByState(stateId);
                if (cp == null)
                {
                    code = 404;
                    res = new ErrorResponse("App resource not found");
                }
                else
                {
                    res = new ItemResponse<CompliantProvider> { Item = cp };
                   
                }
            }
            catch (Exception ex)
            {
                code = 500;
                res = new ErrorResponse(ex.Message);
                base.Logger.LogError(ex.ToString());
            }
            return StatusCode(code, res);
        }
        [HttpGet("providers")]
        public ActionResult<CompliantProvider> SortCompliantProviders() {
            int code = 200;
            BaseResponse res = null;
            //IUserAuthData uData = _authService.GetCurrentUser();
            try
            {
                CompliantProvider cp = _service.SortCompliantProviders();
                if (cp == null)
                {
                    code = 404;
                    res = new ErrorResponse("App resource not found");
                }
                else
                {
                    res = new ItemResponse<CompliantProvider> { Item = cp };
                }
            }
            catch (Exception ex)
            {
                code = 500;
                res = new ErrorResponse(ex.Message);
                base.Logger.LogError(ex.ToString());
            }
            return StatusCode(code, res);
        }
      
        
    }
}