using Git.Data;
using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateRepository(CreateRepositoryInputModel repository, string userId)
        {
            var dbRepository = new Repository
            {
                CreatedOn = DateTime.Now,
                Name = repository.Name,
                IsPublic = isPublic(repository.RepositoryType),
                OwnerId = userId,
            };
            this.db.Add(dbRepository);
            this.db.SaveChanges();
        }

        public IEnumerable<RepositoryViewModel> GetAll()
            =>this.db.Repositories.Where(x=>x.IsPublic)
            .Select(x => new RepositoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Owner = x.Owner.Username,
                CreatedOn = x.CreatedOn,
                CommitsCount = x.Commits.Count(),
            }).ToList();
        public RepositoryViewModel GetById(string repositoryId)
        {
            return this.GetAll().FirstOrDefault(x => x.Id == repositoryId);
        }
        private bool isPublic(string input)
        {
            if (input.Equals("Public")) return true;
            else return false;
        }
    }
}
