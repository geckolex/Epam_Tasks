using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Person
{
    interface IPersonAccessor
    {
        void GetAll(); // получение все записи
        void GetByName(); // поиск значение по имени
        void Update(); // обновить записи
        void Add(); // добвление новой записи
        void Delete(); // удалить запись
    }
}
