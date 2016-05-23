using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service.Interfaces
{
    public interface ITrainingSessionService
    {
        TrainingSession AddTrainingSession(int siteId, int trainingId, int employeeTrainerId, DateTime start, int duration, bool deliveried);
        TrainingSession UpdateTrainingSession(int id, int siteId, int trainingId, int employeeTrainerId, DateTime start, int duration, bool deliveried);
        void DeleteTrainingSession(int id);
       
        IQueryable<TrainingSession> AsQueryable();

    }
}
