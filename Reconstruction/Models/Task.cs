using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reconstruction
{
    public partial class Task : BaseViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTasks { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int IdStatus { get; set; }
        public int? IdUserClient { get; set; }
        public int? IdUserWorker { get; set; } = null;

        private Status _statusNavigation;
        public virtual Status IdStatusNavigation
        {
            get => _statusNavigation;
            set
            {
                _statusNavigation = value;
                OnPropertyChanged();
            }
        }
        public virtual User? IdUserClientNavigation { get; set; }
        public virtual User? IdUserWorkerNavigation { get; set; } = null;
    }
}
