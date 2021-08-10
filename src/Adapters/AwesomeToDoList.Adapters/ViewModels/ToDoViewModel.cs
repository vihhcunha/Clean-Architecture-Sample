﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeToDoList.Adapters.ViewModels
{
    public class ToDoViewModel
    {
        [Key]
        public Guid IdToDo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [DisplayName("Nome")]
        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime? Prevision { get; set; }

        public DateTime Created { get; set; }

        public bool Done { get; set; }

        public DateTime? DateDone { get; set; }

    }
}
