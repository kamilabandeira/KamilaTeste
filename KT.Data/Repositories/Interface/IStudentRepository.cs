using KT.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KT.Data.Repositories.Interface
{
    public interface IStudentRepository
    {
        public Task<List<Student>> Get();
        public Task<Student> GetById(int id);
        public Task Add(Student student);
        public Task Update(int id, Student student);
        public Task Delete(int id);
    }
}
