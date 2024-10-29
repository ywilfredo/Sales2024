using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.Models;
using Sales.Repository.Interfaces;
using Vereyon.Web;

namespace Sales.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IFlashMessage _flashMessage;
        public CountryController( ICountryRepository countryRepository, IFlashMessage flashMessage)
        {
            _countryRepository = countryRepository;
            _flashMessage = flashMessage;
        }
        public IActionResult Index()
        {
            IEnumerable<Country> countries = _countryRepository.AllCountries;
            return View(countries);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Country country)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _countryRepository.CreateAsync(country);
                    _flashMessage.Confirmation("El País se creó correctamente");
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException!.Message.Contains("UNIQUE constraint failed: Countries.Name"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un país con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }

            }
            return View(country);
        }

        public IActionResult Edit(int id)
        {
            Country? country = _countryRepository.GetById(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        [HttpPost]
        public IActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _countryRepository.Update(country);
                    _flashMessage.Confirmation("El País se actualizó correctamente");
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException!.Message.Contains("UNIQUE constraint failed: Countries.Name"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un país con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(country);
        }

        public IActionResult Delete(int id)
        {
            Country? country = _countryRepository.GetById(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        [HttpPost]
        public IActionResult Delete(Country country)
        {
            _countryRepository.Delete(country);
            _flashMessage.Confirmation("El País se eliminó correctamente");
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Country? country = _countryRepository.GetById(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }
    }
}
