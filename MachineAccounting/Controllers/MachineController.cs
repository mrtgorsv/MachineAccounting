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
    [Route("machine")]
    public class MachineController : Controller
    {
        private readonly IMachineService _machineService;
        private readonly IMachineOrderService _machineOrderService;
        private readonly IMapper _mapper;

        public MachineController(IMachineService service, IMapper mapper, IMachineOrderService machineOrderService)
        {
            _machineService = service;
            _mapper = mapper;
            _machineOrderService = machineOrderService;
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
        [HttpGet("/delete/{id}")]
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

        [HttpGet("/buy/{id}")]
        public async Task<IActionResult> Buy([FromRoute] int id)
        {
            var machine = await _machineService.GetAsync(id);
            var machineViewModel = _mapper.Map<MachineOrderViewModel>(machine);
            machineViewModel.Rest = machine.Rest;
            machineViewModel.MachineName = machine.Name;
            machineViewModel.MachineId = machine.Id;
            return View(machineViewModel);
        }

        [HttpPost("/buy/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Buy([FromRoute] int id, [FromForm] MachineOrderViewModel machine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _machineOrderService.CreateAsync(_mapper.Map<MachineOrder>(machine));

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