using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace CEDMobile
{
    public class DatabaseUtil
    {
        readonly SQLiteAsyncConnection db;

        public DatabaseUtil(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Student>().Wait();
            db.CreateTableAsync<Product>().Wait();
        }

        public Task<List<Student>> GetStudentAsync()
        {
            return db.Table<Student>().ToListAsync();
        }

        public Task<int> InsertStudentAsync(Student student)
        {
            return db.InsertAsync(student);
        }

        public Task<int> UpdateStudentAsync(Student student)
        {
            return db.UpdateAsync(student);
        }
        public Task<int> DeleteStudentAsync(Student student)
        {
            return db.DeleteAsync(student);
        }


        public Task<List<Product>> GetProductAsync()
        {
            return db.Table<Product>().ToListAsync();
        }

        public Task<int> InsertProductAsync(Product prod)
        {
            return db.InsertAsync(prod);
        }

        public Task<int> UpdateProductAsync(Product prod)
        {
            return db.UpdateAsync(prod);
        }
        public Task<int> DeleteProductAsync(Product prod)
        {
            return db.DeleteAsync(prod);
        }
    }
}