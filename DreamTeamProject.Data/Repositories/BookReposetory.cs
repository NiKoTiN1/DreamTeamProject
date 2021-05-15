using DreamTeamProject.Data.Interfaces;

namespace DreamTeamProject.Data.Repositories
{
    public class BookReposetory: IBookReposetory
    {
        public BookReposetory(IBaseReposetory baseReposetory)
        {
            this.baseReposetory = baseReposetory;
        }

        private readonly IBaseReposetory baseReposetory;
    }
}
