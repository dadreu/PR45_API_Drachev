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
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public string Priority { get; set; }
        /// <summary>
        /// Дата выполнения
        /// </summary>
        public DateTime DateExecute { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Выполнение
        /// </summary>
        public bool Done { get; set; }
    }
}
