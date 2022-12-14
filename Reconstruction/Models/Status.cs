using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reconstruction
{
    public partial class Status:BaseViewModel
    {
        public Status()
        {
            Tasks = new HashSet<Task>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdStatus { get; set; }
        private string _status;
        public string StatusName
        {
            get=> _status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
