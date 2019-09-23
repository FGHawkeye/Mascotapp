using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DB
{
    public interface IDBInterface
    {
        SQLiteConnection CreateConnection();
    }
}
