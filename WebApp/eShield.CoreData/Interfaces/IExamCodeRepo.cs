using eShield.CoreData.Entities;

namespace eShield.CoreData.Interfaces
{
    public interface IExamCodeRepo : IGenericRepo<ExamCode>
    {
        void Save();
    }
}