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
            return table.FirstOrDefault(x => x.Id == id);
        }

        public T Add(T newItem, bool calculateId = true)
        {
            if (calculateId)
            {
                if (table.Count > 0)
                {
                    newItem.Id = table.Last().Id + 1;
                }
                else
                {
                    newItem.Id = 1;
                }
            }
            table.Add(newItem);
            this.SaveChanges();
            return newItem;
        }

        public void Delete(int id)
        {
            table.RemoveAll(x =>x.Id == id);
            this.SaveChanges();
        }

        public void Update(T updatedItem) 
        {
           var index = table.FindIndex(x => x.Id == updatedItem.Id);
            if(index > -1)
            {
                table[index] = updatedItem;
                this.SaveChanges();
            }
        }
    }
}
