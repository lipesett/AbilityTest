using abilit_test_api.Data;
using abilit_test_api.Models;
using abilit_test_api.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace abilit_test_api.Controllers
{
    public class DependenteController : Controller
    {
        private readonly AddDbContext dbContext;

        public DependenteController(AddDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dependents = await dbContext.DependentesTB
                .Join(dbContext.FuncionarioTB,
                    dependente => dependente.FuncionarioID, funcionario => funcionario.Id,
                    (dependente, funcionario) => new { Dependente = dependente, Funcionario = funcionario })
                .Join(dbContext.GeneroTB,
                    joined => joined.Dependente.GeneroID,
                    genero => genero.Id,
                    (joined, genero) => new ExibeDependentesViewModel
                    {
                        Id = joined.Dependente.Id,
                        Nome = joined.Dependente.Nome,
                        DataNascimento = joined.Dependente.DataNascimento,
                        GeneroID = genero.Id,
                        FuncionarioID = joined.Funcionario.Id,
                        NomeGenero = genero.NomeGenero,
                        NomeFuncionario = joined.Funcionario.Nome
                    })
                .ToListAsync();

            return View(dependents);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var dep = await dbContext.DependentesTB
                .Where(d => d.Id == id)
                .Select(dependente => new ExibeDependentesViewModel
                {
                    Id = dependente.Id,
                    Nome = dependente.Nome,
                    DataNascimento = dependente.DataNascimento,
                    GeneroID = dependente.GeneroID,
                    FuncionarioID = dependente.FuncionarioID,
                    NomeGenero = dbContext.GeneroTB
                        .FirstOrDefault(g => g.Id == dependente.GeneroID).NomeGenero,
                    NomeFuncionario = dbContext.FuncionarioTB.FirstOrDefault(d => d.Id == dependente.FuncionarioID).Nome
                }).FirstOrDefaultAsync();

            return View(dep);
        }

        [HttpGet]
        public async Task<IActionResult> CriarDependente()
        {
            var funcionarios = await dbContext.FuncionarioTB
                .OrderBy(f => f.Id)
                .ToListAsync();

            var viewModel = new ComposedModel
            {
                FuncionariosDisponiveis = funcionarios.Select(f =>
                    new SelectListItem
                    {
                        Value = f.Id.ToString(),
                        Text = f.Nome
                    }).ToList()
            };


            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CriarDependente(ComposedModel viewModel)
        {
            var func = new DependentesTB
            {
                Nome = viewModel.AddDependenteViewModel.Nome,
                DataNascimento = viewModel.AddDependenteViewModel.DataNascimento,
                GeneroID = viewModel.AddDependenteViewModel.GeneroID,
                FuncionarioID = viewModel.AddDependenteViewModel.FuncionarioID,
            };

            await dbContext.DependentesTB.AddAsync(func);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("GetAll", "Dependente");
        }

        [HttpGet]
        public async Task<IActionResult> EditarDependente(int id)
        {
            var funcionarios = await dbContext.FuncionarioTB
                .OrderBy(f => f.Id)
                .ToListAsync();

            var func = await dbContext.DependentesTB
                .Where(f => f.Id == id)
                .Select(funcionario => new ExibeDependentesViewModel
                {
                    Id = funcionario.Id,
                    Nome = funcionario.Nome,
                    DataNascimento = funcionario.DataNascimento,
                    GeneroID = funcionario.GeneroID,
                    NomeGenero = dbContext.GeneroTB
                        .FirstOrDefault(g => g.Id == funcionario.GeneroID).NomeGenero,
                    FuncionarioID = funcionario.FuncionarioID,
                    FuncionariosDisponiveis = funcionarios.Select(f =>
                    new SelectListItem
                    {
                        Value = f.Id.ToString(),
                        Text = f.Nome
                    }).ToList()
                }).FirstOrDefaultAsync();

            return View(func);
        }

        [HttpPost]
        public async Task<IActionResult> EditarDependente(DependentesTB viewModel)
        {
            var func = await dbContext.DependentesTB.FindAsync(viewModel.Id);

            if (func is not null)
            {
                func.Nome = viewModel.Nome;
                func.DataNascimento = viewModel.DataNascimento;
                func.GeneroID = viewModel.GeneroID;
                func.FuncionarioID = viewModel.FuncionarioID;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("GetAll", "Dependente");
        }

        [HttpPost]
        public async Task<IActionResult> DeletarDependente(int id)
        {
            var dep = await dbContext.DependentesTB.FindAsync(id);

            if (dep != null)
            {
                dbContext.DependentesTB.Remove(dep);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("GetAll", "Dependente");
        }


    }
}
