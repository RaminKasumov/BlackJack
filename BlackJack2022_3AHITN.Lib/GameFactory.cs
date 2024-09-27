
namespace BlackJack2022_3AHITN.Lib
{
    /// <summary>
    /// Design Pattern Factory wird hier für das Spiel angewendet
    /// </summary>
    public class GameFactory
    {
        #region method
        /// <summary>
        /// Eine neue Instanz für das Spiel wird erstellt und ausgegeben
        /// </summary>
        /// <param name="table">Name des Tischs</param>
        /// <param name="player">Name des Spielers</param>
        /// <returns>Liefert für das Spiel eine neue Instanz zurück</returns>
        public IGame CreateGame(Table table, IPlayer player)
        {
            IGame game = new Game(table, player);
            return game;
        }
        #endregion
    }
}