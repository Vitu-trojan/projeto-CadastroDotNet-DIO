using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroDotNet
{
     public class Anime : Base
    {
        private Categoria Categoria { get; set; }
        private string Nome { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Anime(int id, Categoria categoria, string nome, string descricao, int ano)
        {
            this.Id = id;
            this.Categoria = categoria;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retornar = "";
            retornar += "Categoria: " + this.Categoria + "\n";
            retornar += "Nome: " + this.Nome + "\n";
            retornar += "Descrição: " + this.Descricao + "\n";
            retornar += "Ano de Lançamento: " + this.Ano + "\n";
            retornar += "Excluído: " + this.Excluido;
            return retornar;
        }

        public string RetornarNome()
        {
            return this.Nome;
        }

        public int RetornarId()
        {
            return this.Id;
        }

        public bool EstaExcluido()
        {
            return Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}
