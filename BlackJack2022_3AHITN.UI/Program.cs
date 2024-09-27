using BlackJack2022_3AHITN.Lib;

namespace BlackJack2022_3AHITN.UI
{
    static class Program
    {
        static void Main()
        {
            //Begrüßung
            Console.WriteLine("Lieber Kunde, willkommen zu diesem Programm!");
            Console.WriteLine("In diesem Programm geht es um die Karten des Spiels BLACKJACK, mit denen Sie spielen und viel Gewinn machen können.");
            Console.WriteLine();

            //Sprint 6
            string answer;
            IPlayerStrategy playerStrategy = null!;
            do
            {
                //Eingabeaufforderung
                Console.Write("Bitte geben Sie ihren Namen ein, um das SPIEL BLACKJACK spielen zu können: ");
                string playerName = Console.ReadLine()!;
                Console.WriteLine();

                //Name des Tischs
                Console.Write("Bitte geben Sie den Namen des Tischs ein: ");
                string tableName = Console.ReadLine()!;
                Console.WriteLine();

                //Strategie
                Console.Write("Bitte geben Sie jetzt ein, mit welcher Strategie Sie spielen wollen (Optionen: Hardhands, Softhands): ");
                string strategy = Console.ReadLine()!;
                Console.WriteLine();

                //Es wird überprüft, welche Strategie vom Spieler ausgewählt wurde
                if (strategy == "Hardhands" || strategy == "hardhands")
                {
                    playerStrategy = new PlayerStrategyHardHands();
                }
                else if (strategy == "Softhands" || strategy == "softhands")
                {
                    playerStrategy = new PlayerStrategySoftHands();
                }

                //Factory für den Spieler und das Spiel werden initialisiert
                PlayerFactory playerFactory = new PlayerFactory();
                GameFactory gameFactory = new GameFactory();

                //Alle nötigen Instanzen für das Spiel werden erstellt
                Table table = new Table(tableName);

                Player player;
                if (!File.Exists($"{playerName}.json"))
                {
                    player = (Player)playerFactory.CreatePlayer(playerName, table, playerStrategy);
                }
                else
                {
                    //Liest das Guthaben des Spielers von der Datei ab
                    using Stream stream = new FileStream($"{playerName}.json", FileMode.Open, FileAccess.Read);
                    player = Player.ReadJson(stream);
                    player.CardSource = new SevenCardSource();
                    player.SetPlayerStrategy(playerStrategy);
                    stream.Close();
                }

                IGame game = gameFactory.CreateGame(table, player);

                game.GameStarted += ConsoleGameStarted!;
                game.PlayerActionPerformed += ConsolePlayerActionPerformed!;
                game.DealerActionPerformed += ConsoleDealerActionPerformed!;
                game.GameFinished += ConsoleGameFinished!;
                game.GameClosed += ConsoleGameClosed!;

                //Wetteinsatz
                Console.Write($"Bitte geben Sie Ihren Einsatz ein (Budget: {player.Balance} Euro): ");
                int playerBet = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                while (playerBet < table.MinimumBet || playerBet > player.Balance)
                {
                    Console.WriteLine("Ihr Einsatz darf nicht weniger als 5 Euro und nicht mehr als Ihr ganzes Kapital sein!!!");
                    Console.WriteLine();
                    Console.Write($"Bitte geben Sie Ihren Einsatz ein (Budget: {player.Balance} Euro): ");
                    playerBet = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                }

                //Spieler macht seine Wette
                player.Bet(playerBet);

                //Spiel wird gestartet …
                game.StartGame();

                //Wenn der Spieler am Anfang des Spiels den Status BlackJack nicht hat, dann kann er Hit oder Stand machen
                if (game.Player.GetHandStatus() != HandStatus.BlackJack)
                {
                    while (!game.Player.HasFinished)
                    {
                        Console.Write("Welche Aktion möchten Sie jetzt ausführen (Hit, Stand oder automatisch)? ");
                        string action = Console.ReadLine()!;
                        Console.WriteLine();

                        if (action == "Hit" || action == "hit" || action == "H" || action == "h")
                        {
                            game.Play(PlayerAction.Hit, false);
                            if (game.Player.HasFinished)
                            {
                                game.PlayGameToEnd();
                            }
                        }
                        else if (action == "Automatisch" || action == "automatisch" || action == "auto")
                        {
                            game.Play();
                            if (game.Player.HasFinished)
                            {
                                game.PlayGameToEnd();
                            }
                        }
                        else if (action == "Stand" || action == "stand" || action == "S" || action == "s")
                        {
                            game.Play(PlayerAction.Stand, false);
                            game.PlayGameToEnd();
                        }
                    }
                }
                else
                {
                    game.PlayGameToEnd();
                }

                player.Payout(game.GetWinRatio());

                //Schreibt das Guthaben des Spielers in eine Datei rein
                using (Stream stream = new FileStream($"{player.GetName()}.json", FileMode.Create, FileAccess.Write))
                {
                    player.WriteJson(stream);
                    stream.Close();
                }

                Console.Write("Wollen Sie das BLACKJACK-SPIEL nochmal spielen? ");
                answer = Console.ReadLine()!;
                Console.WriteLine();

            } while (answer == "Ja" || answer == "ja" || answer == "J" || answer == "j");

            Console.WriteLine("Das SPIEL ist jetzt komplett zu ENDE.");
            Console.WriteLine();

            //Ende
            Console.WriteLine("Das Programm wurde von Ramin Kasumov aus der Klasse 3AHITN erstellt.");
            Console.WriteLine("Ich hoffe, dass Ihnen das Programm gut gefallen hat.");
            Console.WriteLine("Danke für die Aufmerksamkeit und Auf Wiedersehen!");
            Console.ReadKey();
        }

        private static void ConsoleGameStarted(object sender, EventArgs e)
        {
            Console.WriteLine("***Das SPIEL hat GESTARTET.");
            Console.WriteLine(sender);
            Console.WriteLine();
        }

        private static void ConsoleGameFinished(object sender, EventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("***Das SPIEL ist zu ENDE.");
            Console.WriteLine(sender);
        }

        private static void ConsoleGameClosed(object sender, EventArgs e)
        {
            Console.WriteLine("***Das SPIEL wurde GESCHLOSSEN.");
            Console.WriteLine();
        }

        private static void ConsoleDealerActionPerformed(object sender, EventArgs e)
        {
            Console.WriteLine(((Game)sender).Dealer);
            Console.WriteLine();
        }

        private static void ConsolePlayerActionPerformed(object sender, PlayerEventArgs e)
        {
            Console.WriteLine(e.Player);
            Console.WriteLine();
            if (e.Player.HasFinished)
            {
                Console.WriteLine(((Game)sender).Dealer);
                Console.WriteLine();
            }
        }
    }
}
