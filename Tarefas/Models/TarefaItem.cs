using System;
using System.ComponentModel.DataAnnotations;

namespace Tarefas.Models
{
    public class TarefaItem
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string OwnerId { get; set; }
        [Display(Name="Tarefa Completa")]
        public bool EstaCompleta { get; set; }
        [Required(ErrorMessage="O nome da tarefa é obrigatório")]
        [Display(Name="Nome da Tarefa")]
        [StringLength(200)]
        public string Nome { get; set; }
        [Required(ErrorMessage="Informe a data de conclusão da tarefa")]
        [Display(Name="Data de Conclusão")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset? DataConclusao { get; set; }
    }
}