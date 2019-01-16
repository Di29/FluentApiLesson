using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApiLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            using ( var context = new SportContext())
            {
                /*
                HashSet<Player> playersWithSeven = new HashSet<Player>();

                var players = context.Players.ToList();
                foreach(var player in players)
                {
                    if(player.Number == 7)
                    {
                        playersWithSeven.Add(player);
                    }
                }
                */

                //var result = from player in context.Players
                //             where player.Number == 7
                //             select player;
                var result = from player in context.Players
                             where player.Number == 7
                             select new
                             {
                                 UniqueIdentifier = Guid.NewGuid(),
                                 PlayerName = player.FullName,
                                 //Команда = player.Team.Name,
                                 Команда = context.Teams.FirstOrDefault(team => team.Name.Contains("a"))
                             };
                //Console.WriteLine(result.ToList()[0].Команда);

                //from временная_переменная
                //in набор_данных
                //where условие
                //select временная_переменная

                var anotherResult = context.Players.Where(player => player.Number == 7);
                var ronaldo = context.Players.Single(player => player.FullName == "Backhem");

                /*
                Team team = new Team
                {
                    Id = 1,
                    Name = "Manchester"
                };

                Player player = new Player
                {
                    Id = 1,
                    FullName = "Davidych",
                    Number = 0,
                    TeamId = team.Id
                };

                Player MorePlayer = new Player
                {
                    Id = 2,
                    FullName = "Backhem",
                    Number = 9,
                    TeamId = team.Id
                };

                context.Players.Add(player);
                context.Players.Add(MorePlayer);
                context.Teams.Add(team);

                context.SaveChanges();
                */
            }
        }
    }
}
