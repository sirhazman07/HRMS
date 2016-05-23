using Domain.Models;
using Services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class TrainingSessionService
    {
        private readonly ITrainingSessionRepository _repoTrainingSession;
        private readonly ISiteRepository _repoSite;
        private readonly ITrainingRepository _repoTraining;
        private readonly IEmployeeInPositionRepository _repoEmployeeInPosition;
        public TrainingSessionService(ITrainingSessionRepository repotrainingSession, ISiteRepository repoSite, ITrainingRepository repoTraining, IEmployeeInPositionRepository repoEmployeeInPosition)
        {
            _repoTrainingSession = repotrainingSession;
            _repoSite = repoSite;
            _repoTraining = repoTraining;
            _repoEmployeeInPosition = repoEmployeeInPosition;
        }
        public TrainingSession AddTrainingSession(int siteId, int trainingId, int employeeTrainerId, DateTime start, int duration, bool deliveried)
        {
            var site = _repoSite.Get(siteId);
            var training = _repoTraining.Get(trainingId);
            var employeeTrainer = _repoEmployeeInPosition.Get(employeeTrainerId);
            var trainingsession = new TrainingSession
            {
                Site = site,
                Training = training,
                EmployeeInTrainingPostion = (employeeTrainer as EmployeeInTrainingPosition),
                Start = start,
                DurationInMinutes = duration,
                Delivered = deliveried
            };
            _repoTrainingSession.Add(trainingsession);
            return trainingsession;
        }
        public TrainingSession UpdateTrainingSession(int id, int siteId, int trainingId, int employeeTrainerId, DateTime start, int duration, bool deliveried)
        {
            var trainingSession = _repoTrainingSession.Get(id);
            var site = _repoSite.Get(siteId);
            var training = _repoTraining.Get(trainingId);
            var employeeTrainer = _repoEmployeeInPosition.Get(employeeTrainerId);
            trainingSession.Site = site;
            trainingSession.Training = training;
            trainingSession.EmployeeInTrainingPostion = (employeeTrainer as EmployeeInTrainingPosition);
            trainingSession.Start = start;
            trainingSession.DurationInMinutes = duration;
            trainingSession.Delivered = deliveried;
            _repoTrainingSession.Update(trainingSession);
            return trainingSession;
        }
        public void DeleteTrainingSession(int id)
        {
            _repoTrainingSession.Delete(_repoTrainingSession.Get(id));
        }
        public IQueryable<TrainingSession> AsQueryable()
        {
            return _repoTrainingSession.AsQueryable();
        }

    }
 }

