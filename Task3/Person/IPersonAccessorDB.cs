using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Task3
{
    interface IPersonAccessorDB
    {
        void GetAll(Type t); // получение все записи
        void GetByName(FieldInfo fieldInfo, Type t); // поиск значение по имени
        void Update(FieldInfo fieldInfo, Type t); // обновить записи
        void Add(FieldInfo fieldInfo, FieldInfo fieldInfo2,Type t); // добвление новой записи
        void Delete(Type t); // удалить запись
    }
}
