using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        void CreateRepository(CreateRepositoryInputModel repository, string userId);
        IEnumerable<RepositoryViewModel> GetAll();

    }
}
