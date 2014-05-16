using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
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
