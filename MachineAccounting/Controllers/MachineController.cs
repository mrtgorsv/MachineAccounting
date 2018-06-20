using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MachineAccounting.DataContext.Models;
using MachineAccounting.Infrastructure.Services;
using MachineAccounting.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MachineAccounting.Web.Controllers
{
    [Route("api/machine")]
    public class MachineController : Controller
    {
        private readonly IMachineService _machineService;
        private readonly IMapper _mapper;

        public MachineController(IMachineService service, IMapper mapper)
        {
            _machineService = service;
            _mapper = mapper;
        }

        // GET: api/Machine
        [HttpGet("/list")]
        public async Task<IActionResult> Index()
        {
            MachineListViewModel viewModel = new MachineListViewModel();
            viewModel.AddRange(await _machineService.GetListAsync());
            return View(viewModel);
        }

        [HttpGet("/edit/{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var machine = await _machineService.GetAsync(id);

            if (machine == null)
            {
                return NotFound();
            }

            var machineViewModel = _mapper.Map<MachineEditViewModel>(machine);
            machineViewModel.MachineTypeList = CreateMachineTypeList();
            machineViewModel.StorageList = CreateStorageList();

            return View(machineViewModel);
        }

        [HttpPost("/edit/{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] MachineEditViewModel machine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != machine.Id)
            {
                return BadRequest();
            }
            try
            {
                await _machineService.UpdateAsync(_mapper.Map<Machine>(machine));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("/create")]
        public async Task<IActionResult> Create()
        {
            var machineViewModel = _mapper.Map<MachineEditViewModel>(_machineService.New());
            machineViewModel.MachineTypeList = CreateMachineTypeList();
            machineViewModel.StorageList = CreateStorageList();
            return View(machineViewModel);
        }

        [HttpPost("/create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] MachineEditViewModel machine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _machineService.CreateAsync(_mapper.Map<Machine>(machine));

            return RedirectToAction(nameof(Index));
        }

        // DELETE: api/Machine/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var machine = await _machineService.GetAsync(id);
            if (machine == null)
            {
                return NotFound();
            }
            await _machineService.DeleteAsync(machine);

            return RedirectToAction(nameof(Index));
        }

        private bool MachineExists(int id)
        {
            return _machineService.Exists(id);
        }

        private List<SelectListItem> CreateStorageList()
        {
            return _machineService.GetStorageList().Select(s => _mapper.Map<SelectListItem>(s)).ToList();
        }

        private List<SelectListItem> CreateMachineTypeList()
        {
            return _machineService.GetMachineTypeList().Select(s => _mapper.Map<SelectListItem>(s)).ToList();
        }
    }
}