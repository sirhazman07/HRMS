using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Areas.Trainings.Models
{
    public class TrainingSessionViewModel
    {
        private System.DateTime _start;
        private string _startTimeZone;
        private string _endTimeZone;
        private int _durationInMinutes;
        private bool _delivered;
        private string _recurrenceRule;
        private string _recurrenceException;
        

        public int Id { get; set; }
        public int SiteId { get; set; }
        public int TrainingId { get; set; }
        public Nullable<int> EmployeeTrainerId { get; set; }
        public System.DateTime Start
        {
            get
            {
                return _start;
            }
            set
            {
                _start = value;
            }
        }
        public int DurationInMinutes
        {
            get
            {
                return _durationInMinutes;
            }
            set
            {
                _durationInMinutes = value;
            }
        }
        public bool Delivered
        {
            get
            {
                return _delivered;
            }
            set
            {
                _delivered = value;
            }
        }
        public string RecurrenceRule
        {
            get
            {
                return _recurrenceRule;
            }
            set
            {
                _recurrenceRule = value;
            }
        }
        public string RecurrenceException
        {
            get
            {
                return _recurrenceException;
            }
            set
            {
                _recurrenceException = value;
            }
        }
    }
}