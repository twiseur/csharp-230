using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningCenterDatabase;

namespace LearningCenterRepository
{
    public class DatabaseAccessor
    {
        private static readonly LearningCenterEntities entities;

        static DatabaseAccessor()
        {
            entities = new LearningCenterEntities();
            entities.Database.Connection.Open();
        }

        public static LearningCenterEntities Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
