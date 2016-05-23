using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Domain.Models;
using Services.Service.Interfaces;
using UI.Areas.Trainings.Models;

namespace UI.Api
{
    public class TrainingSessionController : ApiController
    {
        private readonly ITrainingSessionService _trainingSessionService;
        public TrainingSessionController(ITrainingSessionService trainingSessionService)
        {
            _trainingSessionService = trainingSessionService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = _trainingSessionService.AsQueryable().Select(t => new TrainingSessionViewModel
            {
                Id = t.Id,
                SiteId = t.SiteId,
                TrainingId = t.TrainingId,
                EmployeeTrainerId = t.EmployeeTrainerId,
                Start = t.Start,
                DurationInMinutes = t.DurationInMinutes,
                Delivered = t.Delivered
            }).ToList();
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Post(TrainingSessionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _trainingSessionService.AddTrainingSession(model.SiteId, model.TrainingId, model.EmployeeTrainerId.Value, model.Start, model.DurationInMinutes, model.Delivered);

            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }

        [HttpPut]
        public IHttpActionResult Update(TrainingSessionViewModel model)
        {
            var update = _trainingSessionService.UpdateTrainingSession(model.Id, model.SiteId, model.TrainingId, model.EmployeeTrainerId.Value, model.Start, model.DurationInMinutes, model.Delivered);
            return Ok(update);
        }

        [HttpDelete]
        public IHttpActionResult Delete(TrainingSessionViewModel model)
        {
            _trainingSessionService.DeleteTrainingSession(model.Id);
            return Ok();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
