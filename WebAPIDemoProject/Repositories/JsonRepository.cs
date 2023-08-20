﻿using System.Text.Json;

namespace WebAPIDemoProject.Repositories
{
    public abstract class JsonRepository<T> where T : class
    {
        
            private string path;

            protected List<T> table;

            public JsonRepository(string tableName)
            {
                path = tableName + ".json";
                table = getListFromFile();
            }

            protected void SaveChanges()
            {
                saveListToFile(table);
            }

            protected void Reload()
            {
                table = getListFromFile();
            }

            private List<T> getListFromFile()
            {
                if (File.Exists(path))
                {
                    var jsonData = File.ReadAllText(path);
                    return JsonSerializer.Deserialize<List<T>>(jsonData) ?? new List<T>();
                }
                else { return new List<T>(); }
            }

            private void saveListToFile(List<T> todoList)
            {
                var serializerOptions = new JsonSerializerOptions { WriteIndented = true };
                var jsonString = JsonSerializer.Serialize(todoList, serializerOptions);
                File.WriteAllText(path, jsonString);
            }
        }
    }

