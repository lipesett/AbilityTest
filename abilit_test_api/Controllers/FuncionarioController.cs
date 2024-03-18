using abilit_test_api.Data;
using abilit_test_api.Models;
using abilit_test_api.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace abilit_test_api.Controllers
{
    public class FuncionarioController : Controller
    {

        private readonly AddDbContext dbContext;

        public FuncionarioController(AddDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var funcionarios = await dbContext.FuncionarioTB.Join(dbContext.GeneroTB,
                funcionario => funcionario.GeneroID, genero => genero.Id,
                (funcionario, genero) => new ExibeFuncionarioViewModel
                {
                    Id = funcionario.Id,
                    Nome = funcionario.Nome,
                    DataNascimento = funcionario.DataNascimento,
                    Salario = funcionario.Salario,
                    NomeGenero = genero.NomeGenero
                })
                .OrderBy(funcionario => funcionario.Id)
                .ToListAsync();

            return View(funcionarios);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var func = await dbContext.FuncionarioTB
                .Where(f => f.Id == id)
                .Select(funcionario => new ExibeFuncionarioViewModel
                {
                    Id = funcionario.Id,
                    Nome = funcionario.Nome,
                    DataNascimento = funcionario.DataNascimento,
                    Salario = funcionario.Salario,
                    NomeGenero = dbContext.GeneroTB
                        .FirstOrDefault(g => g.Id == funcionario.GeneroID).NomeGenero,
                    NomesDependentes = dbContext.DependentesTB
                        .Where(d => d.FuncionarioID == funcionario.Id)
                        .Select(d => d.Nome)
                        .ToList()
                }).FirstOrDefaultAsync();

            return View(func);
        }

        [HttpGet]
        public IActionResult CriarFuncionario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarFuncionario(AddFuncionarioViewModel viewModel)
        {
            var func = new FuncionarioTB
            {
                Nome = viewModel.Nome,
                DataNascimento = viewModel.DataNascimento,
                Salario = viewModel.Salario,
                GeneroID = viewModel.GeneroID
            };

            await dbContext.FuncionarioTB.AddAsync(func);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("GetAll", "Funcionario");
        }

        [HttpGet]
        public async Task<IActionResult> EditarFuncionario(int id)
        {
            var func = await dbContext.FuncionarioTB
                .Where(f => f.Id == id)
                .Select(funcionario => new ExibeFuncionarioViewModel
                {
                    Id = funcionario.Id,
                    Nome = funcionario.Nome,
                    DataNascimento = funcionario.DataNascimento,
                    Salario = funcionario.Salario,
                    GeneroID = funcionario.GeneroID,
                    NomeGenero = dbContext.GeneroTB
                        .FirstOrDefault(g => g.Id == funcionario.GeneroID).NomeGenero,
                    NomesDependentes = dbContext.DependentesTB
                        .Where(d => d.FuncionarioID == funcionario.Id)
                        .Select(d => d.Nome)
                        .ToList()
                }).FirstOrDefaultAsync();

            return View(func);
        }

        [HttpPost]
        public async Task<IActionResult> EditarFuncionario(FuncionarioTB viewModel)
        {
            var func = await dbContext.FuncionarioTB.FindAsync(viewModel.Id);

            if (func is not null)
            {
                func.Nome = viewModel.Nome;
                func.DataNascimento = viewModel.DataNascimento;
                func.Salario = viewModel.Salario;
                func.GeneroID = viewModel.GeneroID;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("GetAll", "Funcionario");
        }

        [HttpPost]
        public async Task<IActionResult> DeletarFuncionario(int id)
        {
            var func = await dbContext.FuncionarioTB.FindAsync(id);

            if (func != null)
            {
                dbContext.FuncionarioTB.Remove(func);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("GetAll", "Funcionario");
        }

    }
}
