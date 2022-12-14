using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Reconstruction
{
    public partial class User
    {
        public User()
        {
            TaskIdUserClientNavigations = new HashSet<Task>();
            TaskIdUserWorkerNavigations = new HashSet<Task>();
        }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsers { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public virtual ICollection<Task> TaskIdUserClientNavigations { get; set; }
        public virtual ICollection<Task> TaskIdUserWorkerNavigations { get; set; }
    }
}
