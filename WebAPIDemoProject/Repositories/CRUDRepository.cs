using WebAPIDemoProject.Entities;

namespace WebAPIDemoProject.Repositories
{
    public class CRUDRepository<T> : JsonRepository<T> where T : BaseCRUD
    {
        public CRUDRepository(string tableName) : base(tableName)
        {
        }

        public T? Get(int id)
        {
            this.Reload();
            return table.FirstOrDefault(x => x.UserId == id);
        }

        public List<T> Get()
        {
            this.Reload();
            return table;
        }

        public T Add(T newItem, bool calculateId = true)
        {
            if (calculateId)
            {
                if (table.Count > 0)
                {
                    newItem.UserId = table.Last().UserId + 1;
                }
                else
                {
                    newItem.UserId = 1;
                }
            }
            table.Add(newItem);
            this.SaveChanges();
            return newItem;
        }

        public void Delete(int id)
        {
            table.RemoveAll(x => x.UserId == id);
            this.SaveChanges();
        }

        public void Update(T updatedItem)
        {
            var index = table.FindIndex(x => x.UserId == updatedItem.UserId);
            if (index > -1)
            {
                table[index] = updatedItem;
                this.SaveChanges();
            }
        }
    }
}
