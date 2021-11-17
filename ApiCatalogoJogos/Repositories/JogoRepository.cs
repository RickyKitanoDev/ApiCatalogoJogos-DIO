using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        //3a0ec6c5-9236-46fc-a9e8-d5a8ce9c2280
        //a483ace8-9928-449f-805f-d813f317116d
        //e484450b-da30-4cc5-9fb9-5bfb458871fe
        //5d954a36-d780-4017-bfe2-7e4b050b27d9
        //e2743d72-6e7d-47a0-80af-168a8577e2d6
        //d58d2573-7e5a-4529-bb3d-1b5f4034845f
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("3a0ec6c5-9236-46fc-a9e8-d5a8ce9c2280"), new Jogo {Id = Guid.Parse("3a0ec6c5-9236-46fc-a9e8-d5a8ce9c2280"), Nome = "Fifa 21", Produtora= "EA", Preco = 200 } },
            {Guid.Parse("a483ace8-9928-449f-805f-d813f317116d"), new Jogo {Id = Guid.Parse("a483ace8-9928-449f-805f-d813f317116d"), Nome = "Fifa 20", Produtora= "EA", Preco = 190 } },
            {Guid.Parse("e484450b-da30-4cc5-9fb9-5bfb458871fe"), new Jogo {Id = Guid.Parse("e484450b-da30-4cc5-9fb9-5bfb458871fe"), Nome = "Fifa 19", Produtora= "EA", Preco = 180 } },
            {Guid.Parse("5d954a36-d780-4017-bfe2-7e4b050b27d9"), new Jogo {Id = Guid.Parse("5d954a36-d780-4017-bfe2-7e4b050b27d9"), Nome = "Fifa 18", Produtora= "EA", Preco = 170 } },
            {Guid.Parse("e2743d72-6e7d-47a0-80af-168a8577e2d6"), new Jogo {Id = Guid.Parse("e2743d72-6e7d-47a0-80af-168a8577e2d6"), Nome = "Street Fighter V", Produtora= "Capcom", Preco = 80 } },
            {Guid.Parse("d58d2573-7e5a-4529-bb3d-1b5f4034845f"), new Jogo {Id = Guid.Parse("d58d2573-7e5a-4529-bb3d-1b5f4034845f"), Nome = "Grand Theft Auto V", Produtora= "Rockstar", Preco = 190 } },
        };

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //Fechar conexão com o banco
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return  Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return null;
            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }                 
    }
}
