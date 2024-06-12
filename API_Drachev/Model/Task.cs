using System.ComponentModel.DataAnnotations;
using System;

namespace API_Drachev.Model
{
    /// <summary>
    /// Задачи
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Код
        /// </summary>
        public int Id { get; set; }
        /// <summary> Название
        public string Name { get; set; }
        /// <summary> Приоритет

        public string Priority { get; set; }
        /// <summary> Дата выполнения

        public DateTime DateExecute { get; set; }
        /// <summary> Описание

        public string Comment { get; set; }
        /// <summary> Выполнение

        public bool Done { get; set; }
    }
}
