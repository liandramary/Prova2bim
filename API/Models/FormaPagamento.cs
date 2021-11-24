using System;

namespace API.Models
{
    public class FormaPagamento
    {
        public FormaPagamento() => CriadoEm = DateTime.Now;
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Vezez { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}