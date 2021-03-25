using KT.Data.Repositories.Interface;
using KT.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;


namespace KT.Data.Repositories.Imp
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MainContext _db;

        public StudentRepository(MainContext db)
        {
            _db = db;
        }

        public async Task Add(Student student)
        {
            _db.AddAsync(student);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var studentEnity = await GetById(id);

            if (studentEnity != null)
            {                
                _db.Remove(studentEnity);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<Student>> Get()
        {
            return await Task.Run(() => _db.Student.ToList());
        }

        public async Task<Student> GetById(int id)
        {
            return await Task.Run(() => _db.Student.FirstOrDefault(student => student.Id == id));
        }

        public async Task Update(int id, Student student)
        {
            var studentEnity = await GetById(id);

            if (studentEnity != null)
            {
                student.Id = id;
                _db.Update(student);
                await _db.SaveChangesAsync();
            }
        }        
    }
}
