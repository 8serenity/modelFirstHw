using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionsLesson
{
    class Program
    {
        //Создать любые две связанные таблицы посредством ModelFirst.Осуществить вставку обоих сушностей в таблицы посредством транзакции.
        static void Main(string[] args)
        {
            using (var context = new asdasdEntities())
            {
                var transaction = context.Database.BeginTransaction();

                try
                {
                    context.UserSet.Add(new UserSet { Name = "Ablai" });
                    context.SaveChanges();
                    context.QuerySet.Add(new QuerySet { Text = "asoifaseofij", UserId = 1 });
                    context.QuerySet.Add(new QuerySet { Text = "asdfasdfasdf", UserId = 1 });
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
