using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VirtualGit.Models;
using VirtualGit.Models.Repository;


namespace VirtualGit.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVirtualModelRepository _virtualModelRepository;
        private readonly IConfiguration _config;
        public HomeController ( IVirtualModelRepository virtualModelRepository, IConfiguration config )
        {
            _virtualModelRepository=virtualModelRepository;
            _config=config;
        }
        public async Task<IActionResult> Index ( )
        {
            var con = _config["ConnectionOS"].ToString ();
            return View ( _virtualModelRepository.GetVirtualModels ( con, 0 ) );
        }
        [HttpPost]
        public async Task<IActionResult> Create ( VirtualModel virtualModel )
        {
            var con = _config["ConnectionOS"].ToString ();
            _virtualModelRepository.InsertNew ( virtualModel, true );
            return RedirectToAction ( "Index" );
        }
        [HttpGet]
        public async Task<IActionResult> Create ( )
        {
            return View ();

        }

        [HttpGet]
        public async Task<IActionResult> Edit ( int Id )
        {
            var con = _config["ConnectionOS"].ToString ();
            var Goss = _virtualModelRepository.GetVirtualModels ( con, Id ).First ();
            return View ( Goss );
        }
        [HttpPost]
        public async Task<IActionResult> Edit ( VirtualModel virtualModel )
        {
            var con = _config["ConnectionOS"].ToString ();
            _virtualModelRepository.InsertNew ( virtualModel, false );
            return RedirectToAction ( "Index" );
        }
        public async Task<IActionResult> Delete ( int ID )
        {
            //dB=new DBHelper ();
            //dB.Delete ( ID );
            return RedirectToAction ( "Index" );
        }

        public IActionResult Privacy ( )
        {
            return View ();
        }

        [ResponseCache ( Duration = 0, Location = ResponseCacheLocation.None, NoStore = true )]
        public IActionResult Error ( )
        {
            return View ( new ErrorViewModel { RequestId=Activity.Current?.Id??HttpContext.TraceIdentifier } );
        }
    }
}
