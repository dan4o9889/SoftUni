using Git.Services;
using Git.ViewModels.Repositories;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoriesService;
        public RepositoriesController(IRepositoriesService repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {
            if(!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var repositories = this.repositoriesService.GetAll();
            return this.View(repositories);
        }
        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }
        [HttpPost]
        public HttpResponse Create(CreateRepositoryInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            if(string.IsNullOrEmpty(input.Name) || input.Name.Length<3 || input.Name.Length>10)
            {
                return this.Error("Name must be between 3 and 10 symbols!");
            }
            this.repositoriesService.CreateRepository(input, this.GetUserId());
            return this.Redirect("/Repositories/All");
        }
    }
}
